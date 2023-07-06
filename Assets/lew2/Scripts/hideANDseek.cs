using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hideANDseek : MonoBehaviour
{
    [SerializeField] private GameObject Hide;
    GameObject hide_pl;
    int hideNow=1;
    bool timatohide = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void HideNow(int r)
    {
        Debug.Log("call me");
        if (timatohide)
        {
            if (r == 1)
            {
                switch (hideNow)
                {
                    case 1:
                        hide_pl = Instantiate(Hide, new Vector3(-2.67f, -0.94f, 0.0f), transform.rotation);
                        Debug.Log("here");
                        break;
                    case 2:
                        hide_pl = Instantiate(Hide, new Vector3(2.17f, -0.94f, 0.0f), transform.rotation);
                        break;
                }
            }else
            {
                switch (hideNow)
                {
                    case 3:
                        hide_pl = Instantiate(Hide, new Vector3(-3.07f, 0.09f, 0.0f), transform.rotation);
                        break;
                    case 4:
                        hide_pl = Instantiate(Hide, new Vector3(2.67f, 0.09f, 0.0f), transform.rotation);
                        break;
                }
            }
        }
    }

    public void boyfound()
    {
        hideNow++;
        timatohide = false;
    }

    public void HideAway()
    {
        timatohide = true;
        GameObject.FindWithTag("boy").GetComponent<boyControll>().HideNN();
    }
    public void Desi() { if (hide_pl != null) { Destroy(hide_pl); } }
    public int WhatHidingPl() { return hideNow; }
    public bool Hideing() { return timatohide; }

}
