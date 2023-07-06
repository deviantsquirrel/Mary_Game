using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldLady : MonoBehaviour
{
    [SerializeField] float speed = 0.01f;
    [SerializeField] Transform Chara;
    private GameObject Cha;
    private GameObject manager;
    private Animator animator;
    private bool FollowNowGo;
    private Rigidbody2D rb2d;
    private SpriteRenderer sprtR;
    private float myY;
    private float myX;
    private float sign;
    private int dira;
    private bool walkinsidehouse;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        sprtR = GetComponent<SpriteRenderer>();
        Cha = GameObject.FindWithTag("Chara");
        Chara = Cha.transform;
        manager = GameObject.FindWithTag("mannager");
        animator = GetComponent<Animator>();
        //animator.SetBool("walk", false);
        //FollowNowGo = true;
    }

    void Update()
    {
        myY = rb2d.transform.position.y;
        myX = rb2d.transform.position.x;
        if (FollowNowGo)
        {
            //Debug.Log("Go");
            if (Mathf.Abs(myY - Chara.position.y) > 1.0)
            {
                sign = (myY - Chara.position.y < 0) ? 1.0f : -1.0f;
                Vector2 delta = new Vector2(0.0f, sign);
                Vector2 newPosition = rb2d.position + delta * speed;
                rb2d.MovePosition(newPosition);
                //Debug.Log("Hori");
                dira = (myY - Chara.position.y < 0) ? 1 : 3;
                animator.SetBool("walk", true);
                animator.SetInteger("dir", dira);
            }
             if (Mathf.Abs(myX - Chara.position.x) > 1.0)
            {
                sign = (myX - Chara.position.x < 0) ? 1.0f : -1.0f;
                Vector2 delta = new Vector2(sign, 0.0f);
                Vector2 newPosition = rb2d.position + delta * speed;
                rb2d.MovePosition(newPosition);
                //Debug.Log("Vert");
                dira = (myX - Chara.position.x < 0) ? 2 : 4;
                animator.SetBool("walk", true);
                animator.SetInteger("dir", dira);
            }
             if(Mathf.Abs(myY - Chara.position.y) <= 1.0 && Mathf.Abs(myX - Chara.position.x) < 1.0)
            {
                animator.SetBool("walk", false);
            }
        }
        if(myY < Chara.position.y)
        {
            sprtR.sortingOrder = 5;
        }else
        {
            sprtR.sortingOrder = 3;
        }
        if (walkinsidehouse)
        {
            
             if (myY < -3.0f) 
            {
                rb2d.MovePosition(rb2d.position + new Vector2(0.0f, 1.0f) * speed*0.6f);
                animator.SetBool("walk", true);
                animator.SetInteger("dir", 1);
            }else if (myX < -4.23f)
            {
                rb2d.MovePosition(rb2d.position + new Vector2(1.0f, 0.0f) * speed * 0.6f);
                animator.SetBool("walk", true);
                animator.SetInteger("dir", 2);
            }
            else if (myY < -2.2f)
            {
                rb2d.MovePosition(rb2d.position + new Vector2(0.0f, 1.0f) * speed * 0.6f);
                animator.SetBool("walk", true);
                animator.SetInteger("dir", 1);
            }
            else
            {
                walkinsidehouse = false;
                Destroy(gameObject);
            }
        }

    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.tag == "Chara")
        {
            animator.SetBool("walk", true);
            animator.SetBool("walk", false);

        }
    }

    public void FollowChara()
    {
        FollowNowGo = true;
        Debug.Log("Following");
    }

    public void StoopFollow()
    {
        FollowNowGo = false;
        animator.SetInteger("dir", 1);
        animator.SetBool("walk", false);
    }

    public void SetNameCharlie()
    {
        manager.GetComponent<RememberThings>().SetNameCharlie();
    }
    public void SetNameAlexi()
    {
        manager.GetComponent<RememberThings>().SetNameAlexi();
    }
        public void SetNameAvery()
        {
            manager.GetComponent<RememberThings>().SetNameAvery();
        }

    public void Foll()
    {
        manager.GetComponent<sceneManager>().TalkingOverOldLady();
        Debug.Log("Following!!!!!!!!!!!!");
    }
    public void GoInsidehouse() { walkinsidehouse = true; }
}