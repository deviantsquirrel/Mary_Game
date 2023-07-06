using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maControll : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;
    private SpriteRenderer sprtR;
    private Rigidbody2D rb2d;

    private bool kill = false;
    private bool dothis = true;
    private bool gonow = false;

    [SerializeField] float speed = 0.03f;

    void Start()
    {
        animator = GetComponent<Animator>();
        sprtR = GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (kill)
        {

            if (!GameObject.FindWithTag("Chara").GetComponent<MainCharacter>().isIteratorSpeaking())
            {
                Debug.Log(rb2d.position.y);
                animator.SetInteger("state", 2);
                if (rb2d.position.x > 0.676f && !gonow)
                {
                    rb2d.MovePosition(rb2d.position + new Vector2(-1.0f, 0.0f) * speed);
                }
                else if (rb2d.position.y > -0.17f)
                {
                    animator.SetInteger("state", 3);
                    rb2d.MovePosition(rb2d.position + new Vector2(0.0f, -1.0f) * speed);
                    if (rb2d.position.y < 0.5f && dothis)
                    {
                        dothis = false;
                        sprtR.sortingLayerName = "cover car";
                        gonow = true;
                    }
                }
                else if (rb2d.position.x < 1.371f && gonow)
                {
                    animator.SetInteger("state", 4);
                    rb2d.MovePosition(rb2d.position + new Vector2(1.0f, 0.0f) * speed);
                }
                else
                {
                    kill = false;
                    animator.SetInteger("state", 5);
                    GameObject.FindWithTag("mannager").GetComponent<controllbasment>().killing();
                    GameObject.FindWithTag("girl").GetComponent<girlControll>().die();
                    StartCoroutine(mowee());
                }
            }

        }
    }

    private IEnumerator mowee()
    {
        yield return new WaitForSeconds(2f);
        animator.SetInteger("state", 6);
        transform.position = new Vector3(1.019f, 0.038f, 0.0f);
        yield return new WaitForSeconds(3f);
        GameObject.FindWithTag("mannager").GetComponent<sceneManager>().BlackscrRR();
    }

    public void killnow()
    {
        kill = true;
        GameObject.FindWithTag("basi").GetComponent<basi>().Deletedoor();
       
    }
    public void die()
    {
        animator.SetInteger("state", 1);
        transform.position = new Vector3(1.829f, 1.331f, 0.0f);
        StartCoroutine(dead());
    }

    private IEnumerator dead()
    {
        yield return new WaitForSeconds(2f);
        animator.SetInteger("state", 12);
        transform.position = new Vector3(1.505f, 0.521f, 0.0f);
    }

}
