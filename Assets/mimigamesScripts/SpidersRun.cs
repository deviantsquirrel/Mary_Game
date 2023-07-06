using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpidersRun : MonoBehaviour
{
    [SerializeField] private GameObject FirstSpider;
    [SerializeField] private GameObject SecondSpider;
    [SerializeField] private GameObject ThirdSpider;
    [SerializeField] private GameObject FourthSpider;
    [SerializeField] private GameObject FifthSpider;

    private float speed = 2.0f;
    private float speedT = 3.0f;
    private float speedR = 4.0f;
    private int First_Stage;
    private int Second_Stage;
    private int Third_Stage;
    private int Fourth_Stage;
    private int Fifth_Stage;


    [SerializeField] private GameObject[] FirstPositions;
    [SerializeField] private GameObject[] SecondPositions;
    [SerializeField] private GameObject[] Thirdositions;
    [SerializeField] private GameObject[] ForthPositions;
    [SerializeField] private GameObject[] FifthPositions;
    private bool FirstGoForward;
    [SerializeField] private TMP_Text texxto;

    void Start()
    {
        First_Stage = 0;
        Second_Stage = 0;
        Third_Stage = 0;
        Fourth_Stage = 0;
        Fifth_Stage = 0;
        FirstGoForward = true;
        if (GameObject.FindWithTag("mannager").GetComponent<sceneManager>().retLanguage() == 1)
        {
            texxto.text = "не дазволь павукам далезці да цябе!";
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(First_Stage);
        FirstSpider.transform.position = Vector2.MoveTowards(FirstSpider.transform.position, FirstPositions[First_Stage].transform.position, speed * Time.deltaTime);
        if (FirstSpider.transform.position == FirstPositions[First_Stage].transform.position)
        {
            if (First_Stage == 6 && FirstGoForward)
            {
                FirstGoForward = false;
            }
            else if (First_Stage == 0 && !FirstGoForward)
            {
                FirstGoForward = true;
            }
            if (FirstGoForward)
            {
                First_Stage++;
            }
            else
            {
                First_Stage--;
            }
        }

        SecondSpider.transform.position = Vector2.MoveTowards(SecondSpider.transform.position, SecondPositions[Second_Stage].transform.position, speed * Time.deltaTime);
        if (SecondSpider.transform.position == SecondPositions[Second_Stage].transform.position)
        {
            Second_Stage = (Second_Stage == 0) ? 1 : 0;
            
        }
        ThirdSpider.transform.position = Vector2.MoveTowards(ThirdSpider.transform.position, Thirdositions[Third_Stage].transform.position, speedT * Time.deltaTime);
        if (ThirdSpider.transform.position == Thirdositions[Third_Stage].transform.position)
        {
            Third_Stage = (Third_Stage == 0) ? 1 : 0;

        }
        FourthSpider.transform.position = Vector2.MoveTowards(FourthSpider.transform.position, ForthPositions[Fourth_Stage].transform.position, speedR * Time.deltaTime);
        if (FourthSpider.transform.position == ForthPositions[Fourth_Stage].transform.position)
        {
            Fourth_Stage = (Fourth_Stage == 0) ? 1 : 0;

        }
        FifthSpider.transform.position = Vector2.MoveTowards(FifthSpider.transform.position, FifthPositions[Fifth_Stage].transform.position, speedR * Time.deltaTime);
        if (FifthSpider.transform.position == FifthPositions[Fifth_Stage].transform.position)
        {
            Fifth_Stage = (Fifth_Stage == 0) ? 1 : 0;

        }

    }


}
