using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

using TMPro;


public class TypeWritter : MonoBehaviour
{

    private float speed = 20f;
    public bool IsRunning { get; private set; }


    private readonly List<Punktuations> punktuations = new List<Punktuations>()
    {
        new Punktuations(new HashSet<char>() { '.', '!', '?' }, 0.6f),
        new Punktuations(new HashSet<char>() { ',', ';', ':' }, 0.3f)
    };
    private Coroutine typingCoroutine;

    public void Run(string textToType, TMP_Text textLable)
    {
        typingCoroutine = StartCoroutine(TypeText(textToType, textLable));
    }
    public void Stop()
    {
        StopCoroutine(typingCoroutine);
        IsRunning= false;
    }
    private IEnumerator TypeText(string textToType, TMP_Text textLable)
    {
        IsRunning = true;
        textLable.text = string.Empty;

        float t = 0;
        int charindex = 0;
        while (charindex < textToType.Length)
        {
            int lastcharacterIndex = charindex;
            t += Time.deltaTime*speed;
            charindex = Mathf.FloorToInt(t);
            charindex = Mathf.Clamp(charindex, 0, textToType.Length);

            for (int i = lastcharacterIndex;i<charindex;i++)
            {
                bool isLast = i >= textToType.Length - 1;

                textLable.text = textToType.Substring(0, i+1);
                if (IsPunku(textToType[i],out float waittime)&& !isLast && !IsPunku(textToType[i+1], out _)){
                    yield return new WaitForSeconds(waittime);
                }
            }

            yield return null;
        }
        IsRunning = false;
        //textLable.text = textToType;
    }


    private bool IsPunku(char character, out float waittime)
    {
        foreach(Punktuations puCategory in punktuations)
        {
            if (puCategory.punktuations.Contains(character))
            {
                waittime = puCategory.waittime;
                return true;
            }
        }
        waittime = default;
        return false;
    }

    private readonly struct Punktuations
    {
        public readonly HashSet<char> punktuations;
        public readonly float waittime;
        public Punktuations(HashSet<char> punk, float waitime)
        {
            punktuations = punk;
            waittime = waitime;
        }
    }
}
