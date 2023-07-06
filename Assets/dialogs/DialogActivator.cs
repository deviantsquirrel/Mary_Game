

using UnityEngine;

public class DialogActivator : MonoBehaviour, IInteractable
{
    [SerializeField] private DialogOdject[] dialogueObject;
    //private DialogResponseEvents[] AllResponces;
    [SerializeField] private ResponceEvent evenT;
    private int r = 0;
    private int InteractionCount = 0;
    private int RespoCount = 0;
    [SerializeField] private GameObject[] AllResponceObjects;
    [SerializeField] private GameObject[] AllRepetitors;
    private int RepetitorCount = 0;

    public void UpdateDialogObject(DialogOdject dialogOdject)
    {
        this.dialogueObject[InteractionCount] = dialogOdject;
    }

    private void OnTriggerEnter2D(Collider2D info)
    {
        if (info.CompareTag("Chara") && info.TryGetComponent(out MainCharacter chara))
        {
            chara.Interactable = this;
            Debug.Log("enter");
        }
    }

    private void OnTriggerExit2D(Collider2D info)
    {
        if (info.CompareTag("Chara") && info.TryGetComponent(out MainCharacter chara)){
            if (chara.Interactable is DialogActivator dialogActivator && dialogActivator == this) {
                chara.Interactable = null;
            }
        }
    }
    public void Interact(MainCharacter Chara)
    {
        Debug.Log("interu");
        if (dialogueObject.Length> InteractionCount)
        {
            Debug.Log("INTERACTION STARTTTTTTTTTTTTTTT");


            if (dialogueObject[InteractionCount].repetition)
            {
                AllRepetitors[RepetitorCount].GetComponent<CheakRepeat>().ReturnEvent().OnPickedResponse.Invoke();
                if (AllRepetitors[RepetitorCount].GetComponent<CheakRepeat>().CheakCondition())
                {
                    InteractionCount++;
                }
            }
            



            if (dialogueObject[InteractionCount].thisLineWillHaveResponses)
        {
                DialogResponseEvents[] AllResponces = AllResponceObjects[RespoCount].GetComponent<GaherREsponses>().GiveResponses();
                r = 1;
                Debug.Log("Responses length");
                Debug.Log(AllResponces.Length);
                Chara.DialogUA.CreateResponceArray(AllResponces);
                RespoCount++;
        }
        
        //Debug.Log(AllResponces.Length);
        if (dialogueObject[InteractionCount].has_Consequense)
        {
            Chara.DialogUA.ReciveAction(evenT);
        }
        foreach (DialogResponseEvents dialogResponseEvents in GetComponents<DialogResponseEvents>())
        {
            if(dialogResponseEvents.DialogOdject == dialogueObject[InteractionCount])
            {
               // Chara.DialogUA.addResponseEvents(dialogResponseEvents.events);
                break;
            }
        }
        //if(TryGetComponent(out DialogResponseEvents dialogResponseEvents) && dialogResponseEvents.DialogOdject == dialogueObject)
        //{
        //    Chara.DialogUA.addResponseEvents(dialogResponseEvents.events);
        //}
        Chara.DialogUA.ShowDialog(dialogueObject[InteractionCount]);

            //Destroy(AllResponces);

            if (!dialogueObject[InteractionCount].repetition)
            {
                InteractionCount++;
            }
            else {
                AllRepetitors[RepetitorCount].GetComponent<CheakRepeat>().ReturnEvent().OnPickedResponse.Invoke();
                //Chara.DialogUA.ReciveAction(AllRepetitors[RepetitorCount].GetComponent<CheakRepeat>().ReturnEvent());
                if (AllRepetitors[RepetitorCount].GetComponent<CheakRepeat>().CheakCondition())
                {
                    InteractionCount++;
                }
                //AllRepetitors[RepetitorCount].GetComponent<GaherREsponses>().GiveResponses();
            }
        
        }
       
    }
    

}
