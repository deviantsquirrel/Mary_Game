using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kidroom : MonoBehaviour
{
    [SerializeField] GameObject books;
    [SerializeField] GameObject homework;
    [SerializeField] GameObject bed;
    void Start()
    {
        if (GameObject.FindWithTag("mannager").GetComponent<controllthese>().iuse_bed()) { Destroy(bed); }
        if (GameObject.FindWithTag("mannager").GetComponent<controllthese>().iuse_homework()) { Destroy(homework); }
        if (GameObject.FindWithTag("mannager").GetComponent<controllthese>().iuse_books()) { Destroy(books); }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
