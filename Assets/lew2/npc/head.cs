using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class head : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb2d;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.MovePosition(rb2d.position + new Vector2(0.0f, 1.0f) * 0.01f);
        if (rb2d.position.y > 5.0f) { Destroy(gameObject); }
    }
}
