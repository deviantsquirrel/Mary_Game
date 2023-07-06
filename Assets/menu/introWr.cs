using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class introWr : MonoBehaviour
{
    [SerializeField] private TMP_Text textLable;
    int phase = 0;
    private Coroutine typingCoroutine;
    string TextToType;
    private bool IsRunning;
    private float speed = 50f;


    void Start()
    {
        if(GameObject.FindWithTag("mannager").GetComponent<sceneManager>().retLanguage() == 1)
        {
            TextToType = "што здарылася?\r\nдзе я?\r\nсамае галоўнае хто я?";
        }
        else { TextToType = "What happened?\r\nWhere am I?\r\nMost importantly who am I?"; }
        typingCoroutine = StartCoroutine(TypeText(TextToType));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (phase == 1)
            {
                GameObject.FindWithTag("Chara").GetComponent<MainCharacter>().CanMoveNow();
                GameObject.FindWithTag("mannager").GetComponent<sceneManager>().DsstroyInto();
            }
            Debug.Log("Space");
            if (IsRunning)
            {
                StopCoroutine(typingCoroutine);
                textLable.text = TextToType;
                IsRunning = false;
                phase++;
            }
            
        }
    }

    private IEnumerator TypeText(string textToType)
    {
        textLable.text = string.Empty;
        IsRunning = true;
        float t = 0;
        int charindex = 0;
        while (charindex < textToType.Length)
        {
            int lastcharacterIndex = charindex;
            t += Time.deltaTime * speed;
            charindex = Mathf.FloorToInt(t);
            charindex = Mathf.Clamp(charindex, 0, textToType.Length);

            for (int i = lastcharacterIndex; i < charindex; i++)
            {
                bool isLast = i >= textToType.Length - 1;

                textLable.text = textToType.Substring(0, i + 1);
                yield return new WaitForSeconds(0.05f);
            }
            
            yield return null;
        }
        IsRunning = false;
        phase++;
    }
}
