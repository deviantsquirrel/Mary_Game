using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class callnexttt : MonoBehaviour
{
    private GameObject manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindWithTag("mannager");
    }

    // Update is called once per frame
    public void CretedRepo()
    {
        manager.GetComponent<sceneManager>().CreateRepo();
    }
}
