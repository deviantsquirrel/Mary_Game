
using UnityEngine;


[CreateAssetMenu(menuName = "Dialogue/DialogOdject")]

public class DialogOdject : ScriptableObject
{
    [SerializeField][TextArea] private string[] dialogue;
    [SerializeField][TextArea] private string[] dialogue_two;
    [SerializeField] private Responce[] responces;
    [SerializeField] private bool HasNext;
    [SerializeField] private DialogOdject dialogOdject;
    [SerializeField] private bool Has_Name;
    [SerializeField] private bool Has_Consequense;
    [SerializeField] private bool Repetition;
    [SerializeField] private bool ThisLineWillHaveResponses;

    public string[] Dialogue => dialogue;
    public string[] Dialogue_two => dialogue_two;
    public Responce[] Responces => responces;
    public bool hasNext => HasNext;
    public DialogOdject NextPiese => dialogOdject;
    public bool hasName => Has_Name;
    public bool has_Consequense => Has_Consequense;
    public bool thisLineWillHaveResponses => ThisLineWillHaveResponses;
    public bool repetition => Repetition;

    public bool HasResponse => Responces != null && Responces.Length > 0;
}
