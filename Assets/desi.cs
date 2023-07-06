using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class desi : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.tag == "Chara")
        {
            Destroy(gameObject);
        }
    }
}
