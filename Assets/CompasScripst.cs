using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompasScripst : MonoBehaviour
{
    private GameObject Cha;
    private Transform Chara;
    private SpriteRenderer sprtR;
    public GameObject manager;

    // Start is called before the first frame update
    void Start()
    {
        sprtR = GetComponent<SpriteRenderer>();
        Cha = GameObject.FindWithTag("Chara");
        Chara = Cha.transform;
        manager = GameObject.FindWithTag("mannager");
    }

    // Update is called once per frame
    void Update()
    {
        if (-3.2f < Chara.position.y)
        {
            sprtR.sortingOrder = 5;
        }
        else
        {
            sprtR.sortingOrder = 3;
        }
    }

    public void TakeMe()
    {
        gameObject.SetActive(false);
        manager.GetComponent<lugge>().AddCompas();
        manager.GetComponent<sceneManager>().DestroyPass();
    }
}
