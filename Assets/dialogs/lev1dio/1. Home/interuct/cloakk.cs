using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class cloakk : MonoBehaviour
{
    //[SerializeField] private GameObject Cloak;
    //private GameObject cloak;
    
    void Start()
    {
        //cloak = Instantiate(Cloak, GameObject.Find("insidehouse").transform);
    }
    public void DeleteCloak()
    {
        GameObject.FindWithTag("insColider").GetComponent<insideroomControllers>().DeleteCloak();
    }
    public void Timee()
    {
        GameObject.FindWithTag("insColider").GetComponent<insideroomControllers>().Turntime();
    }
}
