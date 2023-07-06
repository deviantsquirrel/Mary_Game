using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class psynk : MonoBehaviour
{
    // Start is called before the first frame update
    bool diee = false;
    [SerializeField] GameObject head;
    private GameObject hh;
    private Animator animator;
    private Rigidbody2D rb2d;
    private float myY;
    private float myX;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    public void Deathh()
    {
        StartCoroutine(addd());
        animator.SetBool("die", true);
        StartCoroutine(kill());
    }
    private IEnumerator addd()
    {
        yield return new WaitForSeconds(0.3f);
        hh = Instantiate(head, new Vector3(-0.2f, 0f, 0.0f), transform.rotation);
    }
    private IEnumerator kill()
    {
        yield return new WaitForSeconds(1.5f);
        transform.position = new Vector3(1.26f, -21.53f, 0.0f);
        yield return new WaitForSeconds(1.5f);
        GameObject.FindWithTag("Chara").GetComponent<MainCharacter>().CanMoveNow();
        Destroy(hh);
        GameObject.FindWithTag("mannager").GetComponent<sceneManager>().del_Shy();
    }
}
