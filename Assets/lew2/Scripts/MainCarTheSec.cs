using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCarTheSec : MonoBehaviour
{
    // Start is called before the first frame update


    [SerializeField] float speed = 7.0f;
    private Vector2 velocity;
    private Rigidbody2D rb2d;
    private Animator animator;
    public static int dir;
    public static int move;

    [SerializeField] private DialogUA dialogUA;
    public DialogUA DialogUA => dialogUA;
    public IInteractable Interactable { get; set; }
    private SpriteRenderer sprtR;

    public GameObject ManagerR;

   


    void Start()
    {
        velocity = new Vector2(speed, speed);
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprtR = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (dialogUA.IsOpen || ManagerR.GetComponent<lugge>().IsItOpen())
        {

            animator.SetInteger("move", 0);
            return;

        }
        float horiMove = Input.GetAxisRaw("Horizontal");
        float vertyMove = Input.GetAxisRaw("Vertical");
        Vector2 delta = new Vector2(0.0f, 0.0f);
        if (horiMove != 0f)
        {
            animator.SetInteger("move", 1);
            delta = new Vector2(horiMove, 0f);
            if (horiMove > 0) { animator.SetInteger("dir", 2); }
            else { animator.SetInteger("dir", 4); }
        }
        else if (vertyMove != 0f)
        {
            animator.SetInteger("move", 1);
            delta = new Vector2(0f, vertyMove);
            if (vertyMove > 0) { animator.SetInteger("dir", 3); }
            else { animator.SetInteger("dir", 1); }
        }
        else
        {
            animator.SetInteger("move", 0);
            delta = Vector2.zero;
        }
        delta = delta * velocity * Time.deltaTime;
        Vector2 newPosition = rb2d.position + delta;
        rb2d.MovePosition(newPosition);
        if (Input.GetKeyDown(KeyCode.E))
        {
           // Interactable?.Interact(this);
        }
    }
}
