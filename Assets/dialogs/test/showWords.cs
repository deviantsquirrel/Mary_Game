using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showWords : MonoBehaviour
{

    public void FirstPasrt()
    {
        Debug.Log("First response clicked");

    }
    public void Second()
    {
        Debug.Log("Seconfd response clicked");

    }
    public void Third()
    {
        Debug.Log("Third response clicked");

    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {

        if (hitInfo.gameObject.tag == "Chara")
        {
            GameObject.FindWithTag("cheker").GetComponent<CheakRepeat>().ChangeCondition();
            Debug.Log("Hit Chara");
        }
        

    }
}
