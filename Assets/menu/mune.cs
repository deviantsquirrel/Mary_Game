using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class mune : MonoBehaviour
{
    [SerializeField] private TMP_Text langa;
    int ll = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void langButton()
    {
        if (ll == 0) { ll = 1; langa.text = "беларускі"; }
        else { ll = 0; langa.text = "English"; }
        GameObject.FindWithTag("mannager").GetComponent<sceneManager>().ChangeLang(ll);
        GameObject.FindWithTag("canva").GetComponent<DialogUA>().ChangeLango(ll);
    }
    public void StarteGame()
    {
        GameObject.FindWithTag("mannager").GetComponent<sceneManager>().CrIntro();
        Destroy(gameObject);
    }
}
