using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playerRunfromSpidey : MonoBehaviour
{
    private float speed = 20.0f;
    private Vector2 velocity;
    private Rigidbody2D rb2d;
    private GameObject manager;
    private GameObject playerR;
    [SerializeField] private TMP_Text texxto;

    void Start()
    {
        velocity = new Vector2(speed, speed);
        rb2d = GetComponent<Rigidbody2D>();
        manager = GameObject.FindWithTag("mannager");
        playerR = GameObject.FindWithTag("Chara");
       
    }

    // Update is called once per frame
    void Update()
    {
        float horiMove = Input.GetAxisRaw("Horizontal");
        float vertyMove = Input.GetAxisRaw("Vertical");
        Vector2 delta = new Vector2(0.0f, 0.0f);
        if (horiMove != 0f)
        {
            delta = new Vector2(horiMove, 0f);
        }
        else if (vertyMove != 0f)
        {
            delta = new Vector2(0f, vertyMove);
        }
        else
        {
            delta = Vector2.zero;
        }
        delta = delta * velocity * Time.deltaTime;
        Vector2 newPosition = rb2d.position + delta;
        rb2d.MovePosition(newPosition);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        
        if (hitInfo.gameObject.tag == "spider")
        {
            Debug.Log("GameOver");
            FinishingUp();

        }
        if (hitInfo.gameObject.tag == "key")
        {
            Debug.Log("You won");
            manager.GetComponent<lugge>().CardsPiece();
            manager.GetComponent<controllthese>().use_scI();
            GameObject.FindWithTag("mo").GetComponent<momroom>().shudelete();
            FinishingUp();

        }
    }

    void FinishingUp()
    {
        playerR.GetComponent<MainCharacter>().SetFree();
        manager.GetComponent<sceneManager>().FinishMiniGame();
    }
}
