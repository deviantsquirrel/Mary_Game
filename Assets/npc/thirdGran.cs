using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thirdGran : MonoBehaviour
{
    private GameObject Cha;
    [SerializeField] Transform Chara;
    private Animator animator;
    private Rigidbody2D rb2d;
    private SpriteRenderer sprtR;
    private float myY;
    private float myX;
    private GameObject manager;
    private bool comeBack = false;
    private bool diee = false;
    private float speed = 0.05f;
    private int stage = 0;
    private int sleepCounter = 0;
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
        comeBack = true;
        animator.SetBool("comeback", true);
        comeBack = true;
    }

    // Update is called once per frame
    void Update()
    {
        myY = transform.position.y;
        myX = transform.position.x;
        
        if (comeBack)
        {

            Debug.Log(myX);
            Debug.Log(myY);
            Debug.Log(rb2d.position.y > -0.7f);
            if (rb2d.position.y > -0.7f && stage < 1)//-0.7
            {
                Debug.Log("1");
                rb2d.MovePosition(rb2d.position + new Vector2(0.0f, -1.0f) * speed);
                Debug.Log("1");
            }
            else if (myX < -0.355f && stage < 2)//0.05
            {
                Debug.Log("2");
                stage = 1;
                animator.SetInteger("state", 6);
                rb2d.MovePosition(rb2d.position + new Vector2(1.0f, 0.0f) * speed);
            }
            else if (myY > -1.39f && stage < 3)//-1.39
            {
                Debug.Log("3");
                stage = 2;
                animator.SetInteger("state", 7);
                rb2d.MovePosition(rb2d.position + new Vector2(0.0f, -1.0f) * speed);
            }
            else if (myX < 3.335f && stage < 4)//3.74
            {
                Debug.Log("4");
                stage = 3;
                animator.SetInteger("state", 8);
                rb2d.MovePosition(rb2d.position + new Vector2(1.0f, 0.0f) * speed);
            }
            else
            {
                Debug.Log("5");
                animator.SetInteger("state", 9);
                Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), GameObject.FindWithTag("chair").GetComponent<Collider2D>(), true);
                transform.position = new Vector3(3.375f, -0.568f, 0.0f);//3.375f, -0.568f
                comeBack = false;
                GameObject.FindWithTag("mannager").GetComponent<LastBitController>().GrandBacl();
            }
        }

        if (diee&& !GameObject.FindWithTag("Chara").GetComponent<MainCharacter>().isIteratorSpeaking())
        {
            diee = false;
            GameObject.FindWithTag("mannager").GetComponent<LastBitController>().DeathDiol();
            animator.SetBool("die", true);
            GameObject.FindWithTag("Chara").GetComponent<MainCharacter>().MoveAway(4.3f, -0.54f);
            GameObject.FindWithTag("Chara").GetComponent<MainCharacter>().SheDiedMoveAside();
            transform.position = new Vector3(4.0f, -1.8f, 0.0f);
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

    
    public void DieNow()
    {
        diee = true;
      
    }
    public bool RUDY()
    {
        return diee;
    }
    public void SleepyyNow()
    {
        animator.SetBool("sleppy", true);
        sleepCounter++;
        if (sleepCounter > 3)
        {
            GameObject.FindWithTag("mannager").GetComponent<LastBitController>().SleepDiol();
            animator.SetBool("fallAsleep", true);
            sprtR.sortingLayerName = "cover car";
        }
        else
        {

            StartCoroutine(Wawa(4f));
        }
    }
    IEnumerator Wawa(float ss)
    {
        yield return new WaitForSeconds(ss);
        animator.SetBool("sleppy", false);
    }

    
}
