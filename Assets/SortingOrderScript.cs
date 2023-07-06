using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SortingOrderScript : MonoBehaviour
{
    private GameObject Cha;
    private Transform Chara;
    private TilemapRenderer sprtR;
    void Start()
    {
        sprtR = GetComponent<TilemapRenderer>();
        Cha = GameObject.FindWithTag("Chara");
        Chara = Cha.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Chara.position.y < - 0.12)
        {
            sprtR.sortingOrder = 3;
        }
        else
        {
            sprtR.sortingOrder = 5;
        }
    }
}
