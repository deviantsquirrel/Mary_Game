using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class topORbottom : MonoBehaviour
{
    private GameObject Cha;
    private Transform Chara;
    private SpriteRenderer sprtR;
    private Rigidbody2D rb2d;
    private float myY;
    void Start()
    {
        sprtR = GetComponent<SpriteRenderer>();
        Cha = GameObject.FindWithTag("Chara");
        Chara = Cha.transform;
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        myY = transform.position.y;
        if (myY < Chara.position.y)
        {
            sprtR.sortingOrder = 5;
        }
        else
        {
            sprtR.sortingOrder = 3;
        }
    }
}
