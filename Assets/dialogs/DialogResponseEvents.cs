using System;
using UnityEngine;

public class DialogResponseEvents : MonoBehaviour
{
    [SerializeField] private DialogOdject dialogOdject;
    //[SerializeField] private ResponceEvent responceEvent;
    [SerializeField] private ResponceEvent[] eventss;
    public ResponceEvent[] events => eventss;

    public DialogOdject DialogOdject => dialogOdject;

    //public ResponceEvent[] events;

    public void OnValidate()
    {
        if(dialogOdject == null) return;
        if (dialogOdject.Responces == null) return;
        if (eventss != null && eventss.Length == dialogOdject.Responces.Length) return;
        if (eventss == null)
        {
            eventss = new ResponceEvent[dialogOdject.Responces.Length];

        }
        else
        {
            Array.Resize(ref eventss, dialogOdject.Responces.Length);
        }

        for(int i =0; i< dialogOdject.Responces.Length; i++)
        {
            Responce responce = dialogOdject.Responces[i];
            if (eventss[i] != null)
            {
                eventss[i].name = responce.ResponseText;
                continue;
            }
            eventss[i] = new ResponceEvent() { name = responce.ResponseText };
        }
    }
}
