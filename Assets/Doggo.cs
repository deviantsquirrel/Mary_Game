using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doggo : MonoBehaviour
{
    [SerializeField] Transform targetFirst;
    [SerializeField] Transform targetSecond;

    [SerializeField] float speed = 0.01f;

    private Animator animator;
    private int progger = 0;

    public List<Transform> myTransforms;

    private Rigidbody2D rb2d;
    private float myY;
    private float myX;
    private float diff;
    private bool newW;
    private bool waiiit;

    float sign;
    private int dira;
    private bool SecondLevBeg = false;

    void Start()
    {
        myTransforms.Add(targetFirst);
        myTransforms.Add(targetSecond);
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        newW = true;
        waiiit = false;
        animator.SetBool("moving", false);
        animator.SetInteger("dir", 3);
        StartCoroutine(Waitingg());

    }

    void Update()
    {
        myY = rb2d.transform.position.y;
        myX = rb2d.transform.position.x;
        if (myTransforms.Count > 0 && waiiit)
        {
            animator.SetBool("moving", true);
            if (newW)
            {
                diff = Mathf.Abs(myY - myTransforms[0].position.y);
                newW= false;
                sign = (myTransforms[0].position.y > 0) ? 1.0f : -1.0f;
                dira = (myTransforms[0].position.y > 0) ? 1 : 3;
                animator.SetInteger("dir", dira);
            }
            if (diff > 0.5 && progger == 0)
            {
                Vector2 delta = new Vector2(0.0f, sign);
                Vector2 newPosition = rb2d.position + delta * speed;
                rb2d.MovePosition(newPosition);
                diff = Mathf.Abs(myY - myTransforms[0].position.y);
            }
             if (diff <= 0.5 && progger == 0)
            {
                progger = 1; 
                diff = Mathf.Abs(myX - myTransforms[0].position.x);
                sign = (myTransforms[0].position.y > 0) ? 1.0f : -1.0f;
                dira = (myTransforms[0].position.y > 0) ? 2 : 4;
                animator.SetInteger("dir", dira);
            }
            
           
            if (diff > 0.5 && progger==1)
            {
                Vector2 delta = new Vector2(sign, 0.0f);
                Vector2 newPosition = rb2d.position + delta * speed;
                rb2d.MovePosition(newPosition);
                diff = Mathf.Abs(myX - myTransforms[0].position.x);
            }
             if (diff <= 0.5 && progger == 1)
            {
                //Debug.Log("diff is"+diff);
                myTransforms.RemoveAt(0);
                if (myTransforms.Count > 0)
                {
                    progger = 0;
                    newW = true;
                }
                else
                {
                    progger = 4;
                    newW = true;
                    animator.SetBool("moving", false);
                }
            }
        }
        if (SecondLevBeg)
        {
            if (rb2d.position.x < 7f)//-0.7
            {
                animator.SetInteger("dir", 2);
                animator.SetBool("moving", true);
                rb2d.MovePosition(rb2d.position + new Vector2(1.0f, 0.0f) * speed);
                Debug.Log("1");
            }
            else
            {
                animator.SetBool("moving", false);
                SecondLevBeg = false;
            }
        }
        


    }
    private IEnumerator Waitingg()
    {
        Debug.Log("Here");
        yield return new WaitForSeconds(1.0f);
        Debug.Log("Waited");
        waiiit = true;
    }
    public void StartSec() { transform.position = new Vector3(-3.22f, -3.35f, 0.0f); SecondLevBeg =true; }


}
