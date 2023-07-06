using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class girlControll : MonoBehaviour
{
    private bool talktopl = true;
    private bool gohome = false;
    private bool Leavehouse = false;
    [SerializeField] float speed = 0.01f;
    private Animator animator;
    private SpriteRenderer sprtR;
    private Rigidbody2D rb2d;
    private float myY;
    private float myX;
    private bool tell = true;
    private bool kill = false;
    private bool dothis = true;
    private bool gonow = false;
    private bool alivee = true;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprtR = GetComponent<SpriteRenderer>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
        if (talktopl)
        {
            if (rb2d.position.x > -5.4f)//-0.7
            {
                rb2d.MovePosition(rb2d.position + new Vector2(-1.0f, 0.0f) * speed);
                Debug.Log(rb2d.position.x);
            }
            else
            {
                talktopl = false;
                animator.SetInteger("state", 1);
                GameObject.FindWithTag("Chara").GetComponent<MainCharacter>().CanMoveNow();
                GameObject.FindWithTag("mannager").GetComponent<secLdialog>().FirstDio();
            }
        }
        if (gohome)
        {
            if (rb2d.position.x < -2.19f)
            {
                rb2d.MovePosition(rb2d.position + new Vector2(1.0f, 0.0f) * speed);
            }
            else if (rb2d.position.y < -2.42f)
            {
                animator.SetInteger("state", 3);
                rb2d.MovePosition(rb2d.position + new Vector2(0.0f, 1.0f) * speed);
            }
            else
            {
                transform.position = new Vector3(-66.25f, -2.57f, 0.0f);
                gohome = false;
            }
        }
        if (Leavehouse)
        {
            if (!GameObject.FindWithTag("Chara").GetComponent<MainCharacter>().isIteratorSpeaking())
            {
                if (tell) { GameObject.FindWithTag("mannager").GetComponent<lugge>().AddTasks(); tell = false; }
                
                Debug.Log(rb2d.position.y);
                animator.SetInteger("state", 5);
                if (rb2d.position.y > -1.8f)
                {
                    rb2d.MovePosition(rb2d.position + new Vector2(0.0f, -1.0f) * speed);
                }
                else
                {
                    transform.position = new Vector3(-66.25f, -2.57f, 0.0f);
                    Leavehouse = false;
                }
            }
        }
        if (kill)
        {
           
            if (!GameObject.FindWithTag("Chara").GetComponent<MainCharacter>().isIteratorSpeaking())
            {
                
                Debug.Log(rb2d.position.y);
                animator.SetInteger("state", 7);
                if (rb2d.position.x > 0.69f&&!gonow)
                {
                    rb2d.MovePosition(rb2d.position + new Vector2(-1.0f, 0.0f) * speed);
                }
                else if (rb2d.position.y < 1.29f)
                {
                    animator.SetInteger("state", 8);
                    rb2d.MovePosition(rb2d.position + new Vector2(0.0f, 1.0f) * speed);
                    if (rb2d.position.y > 0.5f&&dothis)
                    {
                        dothis = false;
                        GameObject.FindWithTag("basi").GetComponent<basi>().Deletedoor();
                        //lift
                        sprtR.sortingLayerName = "npc";
                        gonow = true;
                        GameObject.FindWithTag("mannager").GetComponent<sceneManager>().createMaNorm();
                    }
                }
                else if (rb2d.position.x < 1.33f && gonow)
                {
                    animator.SetInteger("state", 9);
                    rb2d.MovePosition(rb2d.position + new Vector2(1.0f, 0.0f) * speed);
                }
                else
                {
                    kill = false;
                    animator.SetInteger("state", 10);
                    GameObject.FindWithTag("mannager").GetComponent<controllbasment>().killing();
                    GameObject.FindWithTag("mo").GetComponent<maControll>().die();
                    StartCoroutine(mowee());

                }
            }

        }
    }
    private IEnumerator mowee()
    {
        yield return new WaitForSeconds(2f);
        animator.SetInteger("state", 11);
        transform.position = new Vector3(0.949f, 1.511f, 0.0f);
        yield return new WaitForSeconds(3f);
        //GameObject.FindWithTag("mannager").GetComponent<sceneManager>().LoadSecondHouse();
        GameObject.FindWithTag("mannager").GetComponent<sceneManager>().BlackscrRR();
    }
    public void EnterHouse()
    {
        Debug.Log(rb2d.position.x);
        animator.SetInteger("state", 2);
        gohome= true;
    }
    public void InsideNow()
    {
        animator.SetInteger("state", 4);
        transform.position = new Vector3(-0.19f, -0.78f, 0.0f);
        GameObject.FindWithTag("mannager").GetComponent<secLdialog>().SecondDio();
    }
    public void GirlLeave()
    {
        Leavehouse = true;
    }
    public void killnow()
    {
        Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), GameObject.FindWithTag("coliG").GetComponent<Collider2D>(), true);
        kill = true;
    }
    public void GirMove(float xx,float yy)
    {
        animator.SetInteger("state", 6);
        transform.position = new Vector3(xx,yy, 0.0f);
    }
    public bool isAlive() { return alivee; }
    public void died() { alivee= false; }
    public void die()
    {
        died();
        animator.SetInteger("state", 14);
        StartCoroutine(dead());
    }
    private IEnumerator dead()
    {
        yield return new WaitForSeconds(2f);
        animator.SetInteger("state", 15);
        transform.position = new Vector3(1.42f, -1.11f, 0.0f);
    }
}
