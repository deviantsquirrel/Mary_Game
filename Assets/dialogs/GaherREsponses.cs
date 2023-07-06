using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaherREsponses : MonoBehaviour
{
    private DialogResponseEvents[] AllResponces;
    private int r = 0;

    public DialogResponseEvents[] allResponces => AllResponces;

    void Start()
    {
        foreach (DialogResponseEvents dialogResponseEvents in GetComponents<DialogResponseEvents>())
        {
            AllResponces = GetComponents<DialogResponseEvents>();
            r++;
            Debug.Log("Object inside count "+AllResponces.Length);

        }
    }
    public DialogResponseEvents[] GiveResponses()
    {
        return AllResponces;
    }

}
