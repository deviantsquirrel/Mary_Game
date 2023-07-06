using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class homework : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TMP_Text question;
    [SerializeField] private TMP_Text optionI;
    [SerializeField] private TMP_Text optionIL;
    [SerializeField] private TMP_Text optionIII;
    [SerializeField] private TMP_Text optionIV;
    [SerializeField] private TMP_Text time;
    private float Timeee;

    int correctAnswer = 3;
    int nurAns = 1;
    int a = 0;

    private Coroutine timerCoroutine;
    private GameObject manager;
    private GameObject playerR;

    [SerializeField] AudioClip audioClip;
    [SerializeField] AudioSource audioSource;

    int langi = 0;
    void Start()
    {
        if (GameObject.FindWithTag("mannager").GetComponent<sceneManager>().retLanguage() == 1)
        {
            langi = 1;
        }
        if (langi == 0)
        {
            question.text = "If Teresa's daughter is my daughter's mother, what am I to Teresa?";
            optionI.text = "Grandmother";
            optionIL.text = "Mother";
            optionIII.text = "Daughter";
            optionIV.text = "I am Teresa";
        }
        else
        {
            question.text = "Калі дачка Тэрэзы — маці маёй дачкі, то хто я для Тэрэзы?";
            optionI.text = "бабуля";
            optionIL.text = "маці";
            optionIII.text = "дачка";
            optionIV.text = "я і ёсць Тэрэза";
        }
        
        Timeee = 30f;
        a = (int)Math.Round(Timeee);
        time.text = a.ToString();
        manager = GameObject.FindWithTag("mannager");
        playerR = GameObject.FindWithTag("Chara");
        
    }

    // Update is called once per frame
    void Update()
    {
        Timeee -= Time.deltaTime;
        if (Timeee < 0) { TimeoOut(); }
        a = (int)Math.Round(Timeee);
        time.text = a.ToString();
    }
    public void CheakAnswer(int chosen)
    {
        audioSource.PlayOneShot(audioClip);
        AnswBlank();
        Timeee = 30f;
        a = (int)Math.Round(Timeee);
        time.text = a.ToString();
        if (chosen == correctAnswer)
        {
            if(langi == 0)
            {
                question.text = "Correct!";
            }
            else { question.text = "слушна!"; }
        }
        else {
            if (langi == 0)
            {
                question.text = "Wrong!";
            }
            else { question.text = "няслушна!"; }
        }
        nurAns++;
        timerCoroutine = StartCoroutine(TimerCoroutineTwo(1.5f));
    }
    public void OptionOneChosen()
    {
        CheakAnswer(1);
    }
    public void OptionTwoChosen()
    {
        CheakAnswer(2);
    }
    public void OptionThreeChosen()
    {
        CheakAnswer(3);
    }
    public void OptionFourChosen()
    {
        CheakAnswer(4);
    }
    public void AnswBlank()
    {
        optionI.text = "";
        optionIL.text = "";
        optionIII.text = "";
        optionIV.text = "";
    }
    public void SecondGo()
    {
        if (langi == 0)
        {
            question.text = "If  A+A+A=39, \n and B+B-A=25 \n and 6+C+B=50, \n A+B+C=?";
        }
        else
        {
            question.text = "Калі A+A+A=39, \n і B+B-A=25 \n і 6+C+B=50, \n A+B+C=?";
        }
        optionI.text = "57";
        optionIL.text = "11";
        optionIII.text = "25";
        optionIV.text = "64";
        correctAnswer = 1;
    }
    public void ThirdGo()
    {
        if (langi == 0)
        {
            question.text = "What is the probability that if you roll three dice all of them will land on 6?";
        }
        else
        {
            question.text = "Якая імавернасць таго, што калі кінуць тры кубікі, то на ўсіх выпадзе 6?";
        }
        optionI.text = "1/6";
        optionIL.text = "1/616";
        optionIII.text = "1/216";
        optionIV.text = "1/36";
        correctAnswer = 3;
    }
    public void FourthGo()
    {
        if (langi == 0)
        {
            question.text = "What is the probability that if you roll three dice they in sum will show 4?";
        }
        else
        {
            question.text = "Якая імавернасць таго, што калі кінуць тры кубікі, то ў суме выпадзе 4?";
        }
        optionI.text = "1/72";
        optionIL.text = "1/3";
        optionIII.text = "1/216";
        optionIV.text = "1/121";
        correctAnswer = 1;
    }
    public void FifthGo()
    {
        if (langi == 0)
        {
            question.text = "What is the probability that all of us can live to see another day?";
        }
        else
        {
            question.text = "Якая імавернасць таго, што ўсё мы зможам дажыць да наступнага дня?";
        }
        optionI.text = "50/50";
        optionIL.text = "100%";
        optionIII.text = "0%";
        optionIV.text = "3%";
        correctAnswer = 3;
    }
    public void SixGo()
    {
        if (langi == 0)
        {
            question.text = "What is the probability that someone lives in our basement?";
            optionI.text = "Is this a joke?";
            optionIV.text = "Is this an invitation?";
        }
        else
        {
            question.text = "Якая імавернасць таго, што ў нашым склепе нехта жыве?";
            optionI.text = "Гэта жарт?";
            optionIV.text = "Гэта запрашэнне?";
        }
        optionIL.text = "100%";
        optionIII.text = "0%";
        correctAnswer = 2;
    }
    public void SevenGo()
    {
        if (langi == 0)
        {
            question.text = "What is the probability that all of this is a dream?";
            optionI.text = "No way to tell";
            optionIL.text = "100%";
            optionIII.text = "No way";
            optionIV.text = "Highly likely";
        }
        else
        {
            question.text = "якая імавернасць, што ўсё гэта сон?";
            optionI.text = "без панятку";
            optionIL.text = "100%";
            optionIII.text = "не можа быць";
            optionIV.text = "вельмі імаверна";
        }
        
        correctAnswer = 2;
    }
    public void finishh()
    {
        AnswBlank();
        Timeee = 30f;
        if (langi == 0)
        {
            question.text = "All done! Thanks for help.";
        }
        else
        {
            question.text = "Усё гатова! Дзякуй за дапамогу.";
        }
        timerCoroutine = StartCoroutine(TimerCoroutine(3f));
    }
    public void TimeoOut()
    {
        AnswBlank();
        Timeee = 30f;
        if (langi == 0)
        {
            question.text = "OUT OF TIME!";
        }
        else
        {
            question.text = "ЧАС ВЫЙШАЎ!";
        }
        nurAns++;
        timerCoroutine = StartCoroutine(TimerCoroutineTwo(1.5f));
    }
    private IEnumerator TimerCoroutine(float duration)
    {
        yield return new WaitForSeconds(duration);

        // Perform some action after the specified duration has elapsed
        Debug.Log("Timer complete!");
        manager.GetComponent<sceneManager>().FinishMiniGame();
        playerR.GetComponent<MainCharacter>().SetFree();
        GameObject.FindWithTag("boy").GetComponent<boyControll>().Homeworkdome();
    }
    private IEnumerator TimerCoroutineTwo(float duration)
    {
        yield return new WaitForSeconds(duration);

        // Perform some action after the specified duration has elapsed
        Debug.Log("Timer complete!");
        switch (nurAns)
        {
            case 2:
                SecondGo();
                break;
            case 3:
                ThirdGo();
                break;
            case 4:
                FourthGo();
                break;
            case 5:
                FifthGo();
                break;
            case 6:
                SixGo();
                break;
            case 7:
                SevenGo();
                break;
            case 8:
                finishh();
                break;
            default:
                Debug.Log("Unknown");
                break;
        }
    }
}
