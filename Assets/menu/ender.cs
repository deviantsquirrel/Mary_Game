using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ender : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TMP_Text textLable;

    void Start()
    {
        if (GameObject.FindWithTag("mannager").GetComponent<sceneManager>().retLanguage() == 1)
        {
            textLable.text = "канец дэмаверсіі. \r\n дзякуй за ўвагу";
        }
        else { textLable.text = "End of demo.\r\nThank you for playing!"; }
    }

}
