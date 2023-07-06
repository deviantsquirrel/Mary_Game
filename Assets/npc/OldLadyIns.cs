using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldLadyIns : MonoBehaviour
{
    private GameObject Cha;
    [SerializeField] Transform Chara;
    private Animator animator;
    private Rigidbody2D rb2d;
    private SpriteRenderer sprtR;
    private float myY;
    private float myX;
    private GameObject manager;
    private bool goUU = false;
    private bool comeBack = false;

    private float speed = 0.05f;
    private int stage = 0;
    [SerializeField] private GameObject Colit;
    private GameObject colit;
    void Start()
    {

        //transform.position = new Vector3(3.08f, 1.2f, 0.0f);

        Cha = GameObject.FindWithTag("Chara");
        Chara = Cha.transform;
        // rb2d = GameObject.FindWithTag("oldLady").GetComponent<Rigidbody2D>();
        rb2d = GetComponent<Rigidbody2D>();
        sprtR = GetComponent<SpriteRenderer>();
        manager = GameObject.FindWithTag("mannager");
        animator = GetComponent<Animator>();
        Cooko();
        //goUU = true;
        //Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), GameObject.FindWithTag("coliG").GetComponent<Collider2D>(), true);
        //animator.SetInteger("state", 1);
        //animator.SetInteger("state", 2);
        //animator.SetInteger("state", 3);
        //animator.SetInteger("state", 4);
        //stage = 0; animator.SetInteger("state", 5); comeBack = true;
    }

    // Update is called once per frame
    void Update()
    {
        myY = transform.position.y;
        myX = transform.position.x;
        // rb2d.MovePosition(rb2d.position + new Vector2(-1.0f, 0.0f) * speed);
        if (goUU)
        {

            animator.SetInteger("state", 1);
            if (myX > 0.15f && stage < 1)
            {
                rb2d.MovePosition(rb2d.position + new Vector2(-1.0f, 0.0f) * speed);
            }
            else if (myY > -0.53f && stage < 2)//
            {
                stage = 1;
                animator.SetInteger("state", 2);
                rb2d.MovePosition(rb2d.position + new Vector2(0.0f, -1.0f) * speed);
            }
            else if (myX > -2.1f && stage < 3)
            {
                stage = 2;
                animator.SetInteger("state", 3);
                rb2d.MovePosition(rb2d.position + new Vector2(-1.0f, 0.0f) * speed);
            }
            else if (myY < 3.31f && stage < 4)//
            {
                stage = 3;
                animator.SetInteger("state", 4);
                rb2d.MovePosition(rb2d.position + new Vector2(0.0f, 1.0f) * speed);
            }
            else
            {
                goUU = false;
                Destroy(gameObject);
                //goDownn();//
            }
        }
        if (myY < Chara.position.y)
        {
            sprtR.sortingOrder = 5;
        }
        else
        {
            sprtR.sortingOrder = 3;
        }
    }
    public void Cooko()
    {
        animator.SetBool("home", true);
    }
    public void goUpp() { goUU = true; }
    public void goDownn() { stage = 0; Debug.Log(stage); animator.SetInteger("state", 5);  comeBack = true;}
    public void PutColi()
    {
        colit = Instantiate(Colit, new Vector3(3.08f, 0.52f, 0.0f), transform.rotation);
    }
}
