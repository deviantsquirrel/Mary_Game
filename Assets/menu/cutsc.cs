using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class cutsc : MonoBehaviour
{
    [SerializeField] private TMP_Text textLable;
    int phase = 0;
    private Coroutine typingCoroutine;
    string TextToType;
    private bool IsRunning;
    private float speed = 50f;


    void Start()
    {
        if (GameObject.FindWithTag("mannager").GetComponent<sceneManager>().retLanguage() == 1)
        {
            TextToType = "я нешта ўспамінаю.\r\nпах маліны, ціхія галасы, печкавы жар.\r\nмы пяклі пірог.\r\nмы ўладкавалі такі бардак. Цідарабілі мы яго?\r\nшто здарылася?\r\nхто яна?\r\nя не помню, але яна здаецца важнай.\r\nпатрэбна ўспомніць больш.";
        }
        else { TextToType = "I remember something.\r\nRasbery smell, soft voices, oven heat.\r\nI was making a pie with another kid.\r\nWe made such a mess. Did we even finish it? \r\nWhat happened?\r\nWho is she?\r\nI don't remember, but she fells important.\r\nI have to remember more."; }
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
                GameObject.FindWithTag("mannager").GetComponent<sceneManager>().DsstroyInto();//
                GameObject.FindWithTag("dod").GetComponent<Doggo>().StartSec();
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
