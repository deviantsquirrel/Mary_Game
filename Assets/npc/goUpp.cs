using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goUpp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MyConse()
    {
        GameObject.FindWithTag("Chara").GetComponent<MainCharacter>().goUpp();
        GameObject.FindWithTag("oldLady").GetComponent<OldLadyIns>().goUpp();
        GameObject.FindWithTag("insColider").GetComponent<insideroomControllers>().TeaQuestInter();
        GameObject.FindWithTag("mannager").GetComponent<lugge>().AddSalatbe();
        GameObject.FindWithTag("insColider").GetComponent<insideroomControllers>().delVeg();
        Destroy(gameObject, 1f);
        

    }
}
