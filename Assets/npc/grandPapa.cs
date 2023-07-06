using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grandPapa : MonoBehaviour
{
    private bool GoSit = false;

    private float speed = 0.05f;
    private GameObject manager;
    private Animator animator;
    private Rigidbody2D rb2d;
    private float myY;
    private float myX;
    [SerializeField] GameObject Talk;
    private bool Trasitionsh = false;
    private bool TrasitionsH = false;
    private int st = 0;
    private bool leavethisPlase = false;
    //private GameObject talk;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        manager = GameObject.FindWithTag("mannager");
        animator = GetComponent<Animator>();
        //talk = Instantiate(Talk, new Vector3(0.0f, 0.0f, 0.0f), transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if (GoSit)
        {
            myY = rb2d.transform.position.y;
            myX = rb2d.transform.position.x;
            animator.SetInteger("state", 1);
            if (myY < -1.0f)
            {
                Debug.Log(myY);
               
                rb2d.MovePosition(rb2d.position + new Vector2(0.0f, 1.0f) * speed);
                Trasitionsh = true;

            }
            else if (myX < 3.72f)
            {
                animator.SetInteger("state", 2);
                TrasitionsH = true;
                rb2d.MovePosition(rb2d.position + new Vector2(1.0f, 0.0f) * speed);
            }
            else
            {
                animator.SetInteger("state", 3);
                rb2d.transform.position = new Vector3(3.375f, -0.341f, 0.0f);
                GoSit = false;
            }
        }
        if (leavethisPlase)
        {
            myY = rb2d.transform.position.y;
            myX = rb2d.transform.position.x;
            
            if (myX > -0.27f)
            {
               // Debug.Log(myY);

                rb2d.MovePosition(rb2d.position + new Vector2(-1.0f, 0.0f) * speed);

            }
            else if (myY > -2.46f)
            {
                animator.SetInteger("state", 6);
                rb2d.MovePosition(rb2d.position + new Vector2(0.0f, -1.0f) * speed);
            }
            else
            {
                manager.GetComponent<LastBitController>().CreateGran();
                manager.GetComponent<LastBitController>().SamOver();
                GameObject.FindWithTag("insColider").GetComponent<insideroomControllers>().SetGranhere();
                Destroy(gameObject);
            }
        }
    }
    public void GoS()
    {
        Destroy(Talk);
        GoSit = true;
        
    }
    public void Drink()
    {
        animator.SetInteger("state", 4);
    }
    public void GoAway()
    {
        leavethisPlase = true;
        animator.SetInteger("state", 5);
        transform.position = new Vector3(3.642678f, -1.198751f, 0.0f);
    }
    private void trans()
    {
        st++;
        animator.SetInteger("state",st);
    }
    
}
