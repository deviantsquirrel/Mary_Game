
using UnityEngine;

[System.Serializable]

public class Responce
{
    [SerializeField] private string responseText;
    [SerializeField] private DialogOdject dialogOdject;

    public string ResponseText => responseText;
    public DialogOdject DialogOdject => dialogOdject;
}
