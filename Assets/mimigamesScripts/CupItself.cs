using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupItself : MonoBehaviour
{
    [SerializeField] private GameObject Cup;
    [SerializeField] private GameObject PlayerR;
    private bool hadBeenAdded;
    
    void Start(){
        Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), Cup.GetComponent<Collider2D>());
        hadBeenAdded = false;
        
    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        
        if (hitInfo.gameObject.tag == "gramcollider")
        {
            Destroy(gameObject);
        }
        if (hitInfo.gameObject.tag == "player")
        {
            if (!hadBeenAdded)
            {

                PlayerR.GetComponent<PlayerCatch>().AddCup();
                hadBeenAdded = true;
            }
            PlayerR.GetComponent<PlayerCatch>().AddCup();
            Destroy(gameObject);
        }

    }
}
