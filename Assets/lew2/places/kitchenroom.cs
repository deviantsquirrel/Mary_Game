using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kitchenroom : MonoBehaviour
{
    [SerializeField] GameObject knife;
    [SerializeField] GameObject card;
    [SerializeField] GameObject food;
    [SerializeField] GameObject stove;
    void Start()
    {
        if (GameObject.FindWithTag("mannager").GetComponent<controllthese>().iuse_knife()) { Destroy(knife); }
        if (GameObject.FindWithTag("mannager").GetComponent<controllthese>().iuse_card()) { Destroy(card); }
        if (GameObject.FindWithTag("mannager").GetComponent<controllthese>().iuse_food()) { Destroy(food); }
        if (GameObject.FindWithTag("mannager").GetComponent<controllthese>().iuse_food()) { Destroy(stove); }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
