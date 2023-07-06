using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class momroom : MonoBehaviour
{
    [SerializeField] GameObject shu;
    [SerializeField] GameObject shuI;
    void Start()
    {
        if (GameObject.FindWithTag("mannager").GetComponent<controllthese>().iuse_scI()) { Destroy(shu); }
        if (GameObject.FindWithTag("mannager").GetComponent<controllthese>().iuse_scII()) { Destroy(shuI); }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void shudelete()
    {
        Destroy(shu);
    }
    public void shudeleteT()
    {
        Destroy(shuI);
    }
}
