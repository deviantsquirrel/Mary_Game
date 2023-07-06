using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boyControll : MonoBehaviour
{
    [SerializeField] float speed = 0.05f;
    private Animator animator;
    private Rigidbody2D rb2d;
    private SpriteRenderer sprtR;
    private float myY;
    private float myX;

    private int playcount = 0;
    private bool aeting = false;
    private bool moveee = true;
    private bool onet = true;
    private bool onet2 = true;

    bool eaten = false;
    bool upp = false;
    bool done_homework = false;
    bool hadbath = false;

    bool doing_homework = false;
    bool having_bath = false;
    bool ready_bath = false;
    bool inBed = false;
    bool asleep = false;

    private Coroutine timerCoroutine;

    bool knowthings = false;//endinh

    bool fr_draw = false;
    bool sc_draw = false;
    bool th_draw = false;
    bool fo_draw = false;

    bool hiding = false;

    bool exist = true;

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
        if (aeting && !GameObject.FindWithTag("Chara").GetComponent<MainCharacter>().isIteratorSpeaking())
        {
            if (onet)
            {
                animator.SetInteger("stage", 1);
                transform.position = new Vector3(1.26f, 1.53f, 0.0f);
                GameObject.FindWithTag("Chara").GetComponent<MainCharacter>().MoveAway(-0.2f, 1.15f);
                onet= false;
            }
            if (rb2d.position.x > 0.47f && moveee)
            {
                animator.SetInteger("stage", 1);
                rb2d.MovePosition(rb2d.position + new Vector2(-1.0f, 0.0f) * speed);
                Debug.Log(rb2d.position.x);
            }
            else if (rb2d.position.y > -0.08f)
            {
                animator.SetInteger("stage", 2);
                rb2d.MovePosition(rb2d.position + new Vector2(0.0f, -1.0f) * speed);
                moveee = false;
                Debug.Log(rb2d.position.x);
                Debug.Log("2");
            }
            else if (rb2d.position.x > -2.7f)
            {
                animator.SetInteger("stage", 3);
                rb2d.MovePosition(rb2d.position + new Vector2(-1.0f, 0.0f) * speed);
                Debug.Log("3");
            }
            else
            {
                aeting = false;
                animator.SetInteger("stage", 4);
                transform.position = new Vector3(-3.55f, 0.14f, 0.0f);
                sprtR.sortingLayerName = "mimiGame";
                eaten = true;
                GameObject.FindWithTag("mannager").GetComponent<secLdialog>().goeatttFalse();
            }
        }
        if (upp && !GameObject.FindWithTag("Chara").GetComponent<MainCharacter>().isIteratorSpeaking())
        {
            if (onet2)
            {
                Debug.Log(onet2);
                moveee = true;
                animator.SetInteger("stage", 1);
                transform.position = new Vector3(1.26f, 1.53f, 0.0f);
                GameObject.FindWithTag("Chara").GetComponent<MainCharacter>().MoveAway(-0.2f, 1.15f);
                onet2 = false;
            }
            if (rb2d.position.x > 0.47f && moveee)
            {
                rb2d.MovePosition(rb2d.position + new Vector2(-1.0f, 0.0f) * speed);
                Debug.Log(rb2d.position.x);
            }
            else if (rb2d.position.y > -0.08f)
            {
                animator.SetInteger("stage", 2);
                rb2d.MovePosition(rb2d.position + new Vector2(0.0f, -1.0f) * speed);
                moveee = false;
                Debug.Log(rb2d.position.x);
                Debug.Log("2");
            }
            else if (rb2d.position.x > -1.41f)
            {
                animator.SetInteger("stage", 3);
                rb2d.MovePosition(rb2d.position + new Vector2(-1.0f, 0.0f) * speed);
                Debug.Log("3");
            }
            else
            {
                HideAway();
                upp = false;
                onet2 = true;
                animator.SetInteger("stage", 6);
                
            }
        }
        if (fr_draw)
        {
            if (rb2d.position.y > -1.34f)
            {
                rb2d.MovePosition(rb2d.position + new Vector2(0.0f, -1.0f) * speed);
                Debug.Log(rb2d.position.x);
            }
            else if (rb2d.position.x > -3.07f)
            {
                animator.SetInteger("stage", 3);
                rb2d.MovePosition(rb2d.position + new Vector2(-1.0f, 0.0f) * speed);
                Debug.Log(rb2d.position.x);
                Debug.Log("2");
            }
            else
            {
                HideAway();
                fr_draw = false;
                animator.SetInteger("stage", 6);
            }
        }
        if (sc_draw)
        {
            if (rb2d.position.x > -3.07f)
            {
                animator.SetInteger("stage", 3);
                rb2d.MovePosition(rb2d.position + new Vector2(-1.0f, 0.0f) * speed);
                Debug.Log(rb2d.position.x);
            }
            else
            {
                HideAway();
                sc_draw = false;
                animator.SetInteger("stage", 6);
            }
        }
        if (th_draw)
        {
            if (rb2d.position.y > -1.45f)
            {
                rb2d.MovePosition(rb2d.position + new Vector2(0.0f, -1.0f) * speed);
                Debug.Log(rb2d.position.x);
            }
            else if (rb2d.position.x < 2.03f)
            {
                animator.SetInteger("stage", 3);
                rb2d.MovePosition(rb2d.position + new Vector2(1.0f, 0.0f) * speed);
                Debug.Log(rb2d.position.x);
                Debug.Log("2");
            }
            else
            {
                HideAway();
                th_draw = false;
                animator.SetInteger("stage", 6);
            }
        }
        if (fo_draw)
        {
            if (rb2d.position.y > -1.45f)
            {
                rb2d.MovePosition(rb2d.position + new Vector2(0.0f, -1.0f) * speed);
                Debug.Log(rb2d.position.x);
            }
            else
            {
                animator.SetInteger("stage", 3);
                HideAway();
                fo_draw = false;
                animator.SetInteger("stage", 6);
            }
        }
    }
    public bool DidEat() { return eaten; }
    public void Dissapear() { exist = false; }
    public bool DidHomework() { return done_homework; }
    public bool know() { return knowthings; }
    public void HideNN() { hiding= true; }
    public void nowknow()
    {
        knowthings = true;
    }
    //public bool DidBath() { return hadbath; }
    public bool DidBath()
    {
        if (done_homework && ready_bath)
        {
            return true;
        }
        else { return false; }
    }

    public void SitHomework()
    {
        if (doing_homework) { 
            transform.position = new Vector3(0.847f, 0.687f, 0.0f);
            GameObject.FindWithTag("mannager").GetComponent<secLdialog>().StaryHomeW();
            sprtR.sortingLayerName = "cover car";
            //dio startmimigame
        }
    }

    public void InBedb()
    {
        Debug.Log("inbed");
        if (inBed&&exist)
        {
            transform.position = new Vector3(2.48f, 0.687f, 0.0f);
            animator.SetInteger("stage", 8);
            //dio startmimigame
        }
    }
    public void playHideAndSeek()
    {
        playcount++;
        //if (playcount = 1)
        //{
        //    //DO hide
        //}
    }public void Homeworkdome()
    {
        done_homework = true;
        doing_homework = false;
        GameObject.FindWithTag("mannager").GetComponent<secLdialog>().donehom();
        GameObject.FindWithTag("mannager").GetComponent<secLdialog>().studyFalse();
        GameObject.FindWithTag("mannager").GetComponent<secLdialog>().Boy_here();
    }
    public void GoEat()
    {
        aeting = true;
        onet = true;
        moveee = true;
        Debug.Log("eat");
       
    }
    public void wenthomewo()
    {
        GameObject.FindWithTag("mannager").GetComponent<secLdialog>().Boy_Nothere();
        doing_homework = true;
    }
    public void WenttoBed()
    {
        GameObject.FindWithTag("mannager").GetComponent<secLdialog>().Boy_Nothere();
        inBed = true;
    }
    public void fallasleep() { 
        asleep= true; 
        inBed= false;
        GameObject.FindWithTag("mannager").GetComponent<secLdialog>().slepFalse();
        GameObject.FindWithTag("mannager").GetComponent<secLdialog>().doneall();
    }
    public bool isInbed() { return inBed; }
    public void wentBath()
    {
        GameObject.FindWithTag("mannager").GetComponent<secLdialog>().Boy_Nothere();
        having_bath = true;
        GameObject.FindWithTag("mannager").GetComponent<secLdialog>().bathFalse();
        timerCoroutine = StartCoroutine(TimerCoroutine(10f));
    }
    private IEnumerator TimerCoroutine(float duration)
    {
        yield return new WaitForSeconds(duration);

        // Perform some action after the specified duration has elapsed
        Debug.Log("Timer complete!");
        animator.SetInteger("stage", 7);
        GameObject.FindWithTag("mannager").GetComponent<secLdialog>().donBath();
        ready_bath = false;
        having_bath = false;
        GameObject.FindWithTag("mannager").GetComponent<secLdialog>().Boy_here();

    }
    public void GoUp() { upp = true;  }
    public void fillbath() { ready_bath = true; }
    public bool isbathfilled()
    {
        return ready_bath;
    }
    public void HideAway()
    {
        transform.position = new Vector3(31.44f, 1.83f, 0.0f);
    }
    public void stillsleep()
    {
        if (asleep&&exist)
        {
            transform.position = new Vector3(2.48f, 0.687f, 0.0f);
        }
    }
    public void SitOnSofa()
    {
        if(!doing_homework&&!having_bath&&!asleep && !hiding&&exist)
        {
            transform.position = new Vector3(1.44f, 1.83f, 0.0f);
            animator.SetInteger("stage", 5);
        }
        
    }
    public void StepOutsede(int ww)
    {
        animator.SetInteger("stage", 9);//stand
        hiding = false;
        switch (ww)
        {
            case 1:
                transform.position = new Vector3(-1.53f, 0.37f, 0.0f);
                //change basi
                break;
            case 2:
                transform.position = new Vector3(2.72f, -1.07f, 0.0f);
                break;
            case 3:
                transform.position = new Vector3(-1.69f, 0.7f, 0.0f);
                break;
            case 4:
                transform.position = new Vector3(1.57f, 0.7f, 0.0f);
                break;
        }
    }
    public void GoAwayFromHide()
    {
        animator.SetInteger("stage", 1);
        switch (GameObject.FindWithTag("mannager").GetComponent<hideANDseek>().WhatHidingPl())
        {
            case 1:
                nowknow();
                fr_draw = true;
                break;
            case 2:
                sc_draw = true;
                break;
            case 3:
                th_draw = true;
                break;
            case 4:
                fo_draw = true;
                break;
        }
    }

}