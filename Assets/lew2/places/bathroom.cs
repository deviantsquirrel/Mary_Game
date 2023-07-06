using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bathroom : MonoBehaviour
{
    [SerializeField] GameObject lotion;
    [SerializeField] GameObject cardwasher;
    [SerializeField] GameObject cardbasket;
    void Start()
    {
        if (GameObject.FindWithTag("mannager").GetComponent<controllthese>().iuse_cabinet()) { Destroy(lotion); }
        if (GameObject.FindWithTag("mannager").GetComponent<controllthese>().iuse_washer()) { Destroy(cardwasher); }
        if (GameObject.FindWithTag("mannager").GetComponent<controllthese>().iuse_basket()) { Destroy(cardbasket); }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void bathhh()
    {
        Destroy(lotion);
    }
}
