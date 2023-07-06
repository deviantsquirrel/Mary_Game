using TMPro;
using System.Collections;
using UnityEngine;

public class DialogUA : MonoBehaviour
{
    [SerializeField] private TMP_Text textLable;
    //[SerializeField] private DialogOdject test;
    [SerializeField] private GameObject DialogueBox;
    private TypeWritter typeWritter;
    private ResponceHandler responceHandler;
    public bool IsOpen;
    [SerializeField] private GameObject Manager;
    private DialogResponseEvents[] AllResponces;
    private int roundd;
    private ResponceEvent evenT;
    private int Colvoresponses;

    private int lang=1;

    private void Start()
    {
        typeWritter = GetComponent<TypeWritter>();
        responceHandler = GetComponent<ResponceHandler>();
        CloseBox();
        //ShowDialog(test);
        roundd = 0;
        Colvoresponses = 0;
    }
    public void ShowDialog(DialogOdject dialogOdject)
    {
        IsOpen= true;
        DialogueBox.SetActive(true);
        StartCoroutine(StepThoughTheDialog(dialogOdject));
    }
    public void ChangeLango(int r) { if (r == 1) { lang= 2; } else { lang= 1; } }
    public void ReciveAction(ResponceEvent even)
    {
        evenT = even;
    }
    public void addResponseEvents(ResponceEvent[] responceEvent)
    {
        responceHandler.AddResponseEvents(responceEvent);
        Debug.Log("AddingResponses");
    }
    public void CreateResponceArray(DialogResponseEvents[] allResponces)
    {
        AllResponces = allResponces;
        Debug.Log("AllResponces.Length "+AllResponces.Length);
        Colvoresponses = AllResponces.Length;
    }
    private IEnumerator StepThoughTheDialog(DialogOdject dialogOdject)
    {
        //foreach(string dialogue in dialogOdject.Dialogue) {
        //    yield return typeWritter.Run(dialogue, textLable);
        //    yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        //}
        if(Colvoresponses>0&& roundd==0)
        {

            addResponseEvents(AllResponces[0].events);
        }
        if(lang==1)
        {
            for (int i = 0; i < dialogOdject.Dialogue.Length; i++)
            {
                string dialogue = dialogOdject.Dialogue[i];
                if (dialogOdject.hasName)
                {
                    dialogue = dialogue.Replace("*", Manager.GetComponent<RememberThings>().ReturnName());
                }
                yield return RunTypping(dialogue);
                textLable.text = dialogue;
                //yield return typeWritter.Run(dialogue, textLable);

                //if (i == dialogOdject.Dialogue.Length - 1 && dialogOdject.HasResponse) break;
                yield return null;
                yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
            }
        }
        else
        {
            for (int i = 0; i < dialogOdject.Dialogue_two.Length; i++)
            {
                string dialogue_two = dialogOdject.Dialogue_two[i];
                if (dialogOdject.hasName)
                {
                    dialogue_two = dialogue_two.Replace("*", Manager.GetComponent<RememberThings>().ReturnName());
                }
                yield return RunTypping(dialogue_two);
                textLable.text = dialogue_two;
                //yield return typeWritter.Run(dialogue, textLable);

                //if (i == dialogOdject.Dialogue.Length - 1 && dialogOdject.HasResponse) break;
                yield return null;
                yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
            }
        }
        
        if (dialogOdject.HasResponse)
        {
            Debug.Log("Num Responses sent" + roundd);
            addResponseEvents(AllResponces[roundd].events);
            Debug.Log("Num Responses sent" + roundd);
            responceHandler.ShowResponses(dialogOdject.Responces, lang);
            roundd++;
        }
        else if(dialogOdject.hasNext)
        {
            //dialogOdject = dialogOdject.NextPiese;
            Debug.Log("Has next");
            //roundd++;

            //addResponseEvents(AllResponces[1].events);


            //DialogResponseEvents[] NewRes = new DialogResponseEvents[AllResponces.Length - 1];
            //Array.Copy(AllResponces, 1, NewRes, 0, AllResponces.Length - 1);
            //AllResponces = NewRes;


            StartCoroutine(StepThoughTheDialog(dialogOdject.NextPiese));

        }else if (dialogOdject.has_Consequense)
        {
            Debug.Log("Consequense");
            evenT.OnPickedResponse.Invoke();
            
            roundd = 0;
            Colvoresponses = 0;
            CloseBox();
        }
        else
        {
            roundd = 0;
            Colvoresponses = 0;
            CloseBox();
        }
       
    }
    private IEnumerator RunTypping(string dialogu)
    {
        typeWritter.Run(dialogu, textLable);
        while (typeWritter.IsRunning)
        {
            yield return null;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                typeWritter.Stop();
            }
        }
    }
    public void CloseBox()
    {
        roundd = 0;
        IsOpen = false;
        DialogueBox.SetActive(false);
        textLable.text = string.Empty;
    }
}
