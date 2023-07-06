using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using TMPro;

public class PlayerCatch : MonoBehaviour
{
    private float speed = 18.0f;
    private Vector2 velocity;
    private Rigidbody2D rb2d;
    private int CupsCought;
    [SerializeField] private TMP_Text Cups_Displayed;

    void Start()
    {
        velocity = new Vector2(speed, speed);
        rb2d = GetComponent<Rigidbody2D>();
        CupsCought = 0;
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

    public void AddCup()
    {
        CupsCought++;
        Cups_Displayed.text = (CupsCought/2).ToString();
    }

    public int Finosh() {
        return CupsCought;
    }
}
