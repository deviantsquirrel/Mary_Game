using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basi : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject door;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Deletedoor()
    {
        Destroy(door);
    }
}
