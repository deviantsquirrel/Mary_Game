using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class timedAnswer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TMP_Text question;
    [SerializeField] private TMP_Text time;
    [SerializeField] private TMP_Text answ;
    [SerializeField] private Button option1;
    [SerializeField] private Button option2;
    [SerializeField] private Button option3;
    [SerializeField] private Button option4;
    [SerializeField] private Button option5;
    [SerializeField] private Button option6;
    [SerializeField] private Button option7;
    [SerializeField] private Button option8;
    [SerializeField] private Button option9;
    [SerializeField] private Button option10;
    [SerializeField] private TMP_Text execute;
    [SerializeField] private TMP_Text abort;

    bool riddlegame = false;
    int phase = 0;
    string rightansw;
    string curansw = "";
    private float Timeee;
    int a = 0;
    int ansLength = 0;
    int linga = 0;

    string but_1 = "1";
    string but_2 = "2";
    string but_3 = "3";
    string but_4 = "4";
    string but_5 = "5";
    string but_6 = "6";
    string but_7 = "7";
    string but_8 = "8";
    string but_9 = "9";
    string but_10 = "0";


    private Coroutine timerCoroutine;
    private GameObject manager;
    private GameObject playerR;

    [SerializeField] AudioClip audioClip;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioSource wrong_a;
    [SerializeField] AudioSource right_a;

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindWithTag("mannager").GetComponent<sceneManager>().retLanguage() == 1)
        {
            linga = 1;
            execute.text = "Пацвердзіць";
            abort.text = "Скасаваць";
        }
        Timeee = 30f;
        a = (int)Math.Round(Timeee);
        time.text = a.ToString();
        manager = GameObject.FindWithTag("mannager");
        playerR = GameObject.FindWithTag("Chara");
        if (!GameObject.FindWithTag("mannager").GetComponent<controllbasment>().doorlocked())
        {
            FirstRiddleSetUp();
            GameObject.FindWithTag("mannager").GetComponent<controllbasment>().playRiddlemus();
        }else if(GameObject.FindWithTag("mannager").GetComponent<sceneManager>().retLanguage() == 1)
        {
            question.text = "Увядзіце камбінацыю";
            
        }
        //cheakling
        
    }

    // Update is called once per frame
    void Update()
    {
        Timeee -= Time.deltaTime;
        if (Timeee < 0) { TimeoOut(); }
        a = (int)Math.Round(Timeee);
        time.text = a.ToString();
    }

    public void CodeSetUp()
    {
        phase = 0;
        rightansw = "071";
    }
    public void But1_pressed()
    {
        curansw += but_1;
        UpdAnsw();
    }
    public void But2_pressed()
    {
        curansw += but_2;
        UpdAnsw();
    }
    public void But3_pressed()
    {
        curansw += but_3;
        UpdAnsw();
    }
    public void But4_pressed()
    {
        curansw += but_4;
        UpdAnsw();
    }
    public void But5_pressed()
    {
        curansw += but_5;
        UpdAnsw();
    }
    public void But6_pressed()
    {
        curansw += but_6;
        UpdAnsw();
    }
    public void But7_pressed()
    {
        curansw += but_7;
        UpdAnsw();
    }
    public void But8_pressed()
    {
        curansw += but_8;
        UpdAnsw();
    }
    public void But9_pressed()
    {
        curansw += but_9;
        UpdAnsw();
    }
    public void But10_pressed()
    {
        curansw += but_10;
        UpdAnsw();
    }
    private void UpdAnsw()
    {
        answ.text = curansw;
        ansLength++;
    }
    public void TimeoOut()
    {
        AnswBlank();
        Timeee = 30f;
        question.text = "OUT OF TIME!";
        ansLength = 0;
        timerCoroutine = StartCoroutine(WaitAndExitWrongRiddle(1.5f));
    }
    public void AnswBlank()
    {
        DisableButt();
        StartCoroutine(TimerCoroutineTwo(1.5f));
    }
    private IEnumerator TimerCoroutineTwo(float duration)
    {
        yield return new WaitForSeconds(duration);
        enableButtons();
    }
    private void DisableButt()
    {
        option1.interactable = false;
        option2.interactable = false;
        option3.interactable = false;
        option4.interactable = false;
        option5.interactable = false;
        option6.interactable = false;
        option7.interactable = false;
        option8.interactable = false;
        option9.interactable = false;
        option10.interactable = false;
    }
    private IEnumerator WaitAndload(float duration)
    {
        yield return new WaitForSeconds(duration);
        enableButtons();
        switch (phase)
        {
            case 1:
                SecondRiddleSetUp();
                break;
            case 2:
                ThirdRiddleSetUp();
                break;
            default: break;
        }
    }
    private IEnumerator WaitAndExit(float duration)
    {
        yield return new WaitForSeconds(duration);
        if(phase==0) {
            playerR.GetComponent<MainCharacter>().MoveAway(0.24f, -0.92f);
            manager.GetComponent<controllbasment>().startmus();
            manager.GetComponent<sceneManager>().LoadCloves();
            manager.GetComponent<controllbasment>().doorIsOpenNow();
        } else if (phase == 3){
            manager.GetComponent<sceneManager>().PsyGo();
        }
        //loadnextroom case 1 load base 3 load center
        manager.GetComponent<sceneManager>().FinishMiniGame();
        playerR.GetComponent<MainCharacter>().SetFree();
        playerR.GetComponent<MainCharacter>().CanMoveNow();
        Debug.Log("here");
        //place colli
    }
    private IEnumerator WaitAndExitWrong(float duration)
    {
        yield return new WaitForSeconds(duration);
        manager.GetComponent<sceneManager>().FinishMiniGame();
        playerR.GetComponent<MainCharacter>().SetFree();
        playerR.GetComponent<MainCharacter>().CanMoveNow();
        Debug.Log("here");
    }
    private IEnumerator WaitAndExitWrongRiddle(float duration)
    {
        yield return new WaitForSeconds(duration);
        manager.GetComponent<sceneManager>().FinishMiniGame();
        playerR.GetComponent<MainCharacter>().SetFree();
        manager.GetComponent<controllthese>().PlaceCrack();
        manager.GetComponent<controllbasment>().deathbycrack();
        playerR.GetComponent<MainCharacter>().CanMoveNow();
        Debug.Log("here");
    }
   
    private void CorrectAnswer()
    {
        DisableButt();
        if (linga == 0) { question.text = "Correct!"; }
        else { question.text = "слушна!"; }
           
        StartCoroutine(WaitAndExit(1.5f));
    }
    private void CorrectAnswer2()
    {
        DisableButt();
        if (linga == 0) { question.text = "Correct!"; }
        else { question.text = "слушна!"; }
        StartCoroutine(WaitAndload(1.5f));
    }
    
    private void WrongAnsw()
    {
        DisableButt();
        if (linga == 0) { question.text = "Wrong!"; }
        else { question.text = "няслушна!"; }
        StartCoroutine(WaitAndExitWrong(1.5f));
    }
    private void WrongAnsw2()
    {
        DisableButt();
        if (linga == 0) { question.text = "Wrong!"; }
        else { question.text = "няслушна!"; }
        StartCoroutine(WaitAndExitWrongRiddle(1.5f));
        //kill
    }
    public void clearS()
    {
        ansLength = 0;
        answ.text = "";
        curansw = "";
    }
    public void timeTocheak()
    {
        switch (phase)
        {
            case 0:
                if(ansLength==3&& curansw.Equals("071")) { CorrectAnswer(); }
                else { WrongAnsw(); }
                break;
            case 1:
                if (linga==0)
                {
                    if(ansLength == 6&& curansw.Equals("memory")) { CorrectAnswer2();}
                    else { WrongAnsw2(); }
                }
                else {
                    if (ansLength == 7&&curansw.Equals("успамін")) { CorrectAnswer2();} 
                    else { WrongAnsw2(); }
                }
                break;
            case 2:
                if (linga == 0)
                {
                    if (ansLength == 4&&curansw.Equals("love")) { CorrectAnswer2(); }
                    else { WrongAnsw2(); }
                }
                else
                {
                    if (ansLength == 5&&curansw.Equals("любоў")) {CorrectAnswer2(); }
                    else { WrongAnsw2(); }
                }
                break;
            case 3:
                if (linga == 0)
                {
                    if (ansLength == 5&&curansw.Equals("death")) { CorrectAnswer(); }
                    else { WrongAnsw2(); }
                }
                else
                {
                    if (ansLength == 6&&curansw.Equals("смерць")) { CorrectAnswer(); }
                    else { WrongAnsw2(); }
                }
                break;
            default:
                Debug.Log("Unknown");
                break;
        }
    }

    private void FirstRiddleSetUp()
    {
        phase = 1;
        Timeee = 30f;
        a = (int)Math.Round(Timeee);
        time.text = a.ToString();
        if (linga == 0)
        {
            question.text = "I can bring tears to your eyes\r\nor resurect the dead \r\nI form in an instant \r\nand last a lifetime";
            but_1 = "r";
            but_2 = "y";
            but_3 = "m";
            but_4 = "a";
            but_5 = "p";
            but_6 = "o";
            but_7 = "e";
            but_8 = "s";
            but_9 = "n";
            but_10 = "w";
            Debug.Log(linga);
        }
        else
        {
            question.text = "Я магу давесці да слёз\r\nці ўскрэсіць мёртвых\r\nЯ фармуюся ў імгненне\r\nі існую цэлае жыццё";
            but_1 = "г";
            but_2 = "а";
            but_3 = "м";
            but_4 = "у";
            but_5 = "р";
            but_6 = "л";
            but_7 = "с";
            but_8 = "п";
            but_9 = "н";
            but_10 = "і";
            Debug.Log(linga);
        }
        updateButtons();
    }
    private void SecondRiddleSetUp()
    {
        phase = 2;
        Timeee = 30f;
        a = (int)Math.Round(Timeee);
        time.text = a.ToString();
        if (linga == 0) { question.text = "Rich men want it \r\nWise men know it\r\nThe poor all need it\r\n";
            but_1 = "n";
            but_2 = "l";
            but_3 = "i";
            but_4 = "f";
            but_5 = "o";
            but_6 = "e";
            but_7 = "v";
            but_8 = "p";
            but_9 = "a";
            but_10 = "s";
        } else
        {
            question.text = "Багатыя хочуць яе, \r\nМудрыя ведаюць яе,\r\nБедным яна ўсім патрэбна.\r\n";
            but_1 = "о";
            but_2 = "т";
            but_3 = "м";
            but_4 = "л";
            but_5 = "а";
            but_6 = "ў";
            but_7 = "ю";
            but_8 = "е";
            but_9 = "к";
            but_10 = "б";
        }
        updateButtons();
    }
    private void ThirdRiddleSetUp()
    {
        phase = 3;
        Timeee = 30f;
        a = (int)Math.Round(Timeee);
        time.text = a.ToString();
        if (linga == 0)
        {
            question.text = "A nightmare for some \r\nA saviour for others, I come\r\nmy hands are cold and bleak\r\nIt's the warm hearts they seek";
            but_1 = "a";
            but_2 = "e";
            but_3 = "i";
            but_4 = "n";
            but_5 = "t";
            but_6 = "d";
            but_7 = "h";
            but_8 = "g";
            but_9 = "f";
            but_10 = "s";
        }
        else
        {
            question.text = "Кашмар для некаторых\r\nРатаваннік для іншых, я прыходжу\r\nМае рукі халодныя і змрочныя\r\nЦёплыя сэрцы - іх мэта";
            but_1 = "е";
            but_2 = "ж";
            but_3 = "р";
            but_4 = "с";
            but_5 = "м";
            but_6 = "о";
            but_7 = "а";
            but_8 = "ц";
            but_9 = "ь";
            but_10 = "т";
        }
        updateButtons();
    }
    private void updateButtons()
    {
        option1.GetComponentInChildren<Text>().text = but_1;
        option2.GetComponentInChildren<Text>().text = but_2;
        option3.GetComponentInChildren<Text>().text = but_3;
        option4.GetComponentInChildren<Text>().text = but_4;
        option5.GetComponentInChildren<Text>().text = but_5;
        option6.GetComponentInChildren<Text>().text = but_6;
        option7.GetComponentInChildren<Text>().text = but_7;
        option8.GetComponentInChildren<Text>().text = but_8;
        option9.GetComponentInChildren<Text>().text = but_9;
        option10.GetComponentInChildren<Text>().text = but_10;
    }
    private void enableButtons()
    {
        option1.interactable = true;
        option2.interactable = true;
        option3.interactable = true;
        option4.interactable = true;
        option5.interactable = true;
        option6.interactable = true;
        option7.interactable = true;
        option8.interactable = true;
        option9.interactable = true;
        option10.interactable = true;
    }
}
