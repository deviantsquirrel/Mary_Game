using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hide : MonoBehaviour
{
    private GameObject manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindWithTag("mannager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void HudeMe()
    {
        manager.GetComponent<sceneManager>().HideForrestDio();
    }
}
