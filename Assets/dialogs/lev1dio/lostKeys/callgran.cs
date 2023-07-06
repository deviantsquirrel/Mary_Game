using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class callgran : MonoBehaviour
{
    void Start() { }
    public void CallGrand()
    {
        Debug.Log("go inside");
        GameObject.FindWithTag("mannager").GetComponent<sceneManager>().CallGran();
       
    }
    public void Callhjh()
    {
        Debug.Log("go inside");

    }
}
