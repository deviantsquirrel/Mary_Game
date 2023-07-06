using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderGamePlayer : MonoBehaviour
{
    private float speed = 12.0f;
    private Vector2 velocity;
    private Rigidbody2D rb2d;
    private GameObject manager;
    private GameObject playerR;

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
        //string s = LayerMask.LayerToName(hitInfo.transform.gameObject.layer);
        //Debug.Log(s);
        //Debug.Log(hitInfo);
        if (hitInfo.gameObject.tag == "spider")
        {
            manager.GetComponent<sceneManager>().WasBitten();
            manager.GetComponent<RememberThings>().PoisonedStatus(true);
            Debug.Log("GameOver");
            FinishingUp();

        }
        if (hitInfo.gameObject.tag == "key")
        {
            Debug.Log("You won");
            manager.GetComponent<sceneManager>().GotTheKey();
            manager.GetComponent<RememberThings>().FoundBushKey();
            FinishingUp();

        }
    }

    void FinishingUp()
    {
        manager.GetComponent<sceneManager>().DestDiologgi();
        playerR.GetComponent<MainCharacter>().SetFree();
        manager.GetComponent<sceneManager>().FinishMiniGame();
    }
 }
