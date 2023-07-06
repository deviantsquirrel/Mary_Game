using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class lotiongo : MonoBehaviour
{
    [SerializeField] private GameObject Cup;
    [SerializeField] private Transform CupT;
    [SerializeField] private int CupAmount;
    [SerializeField] private GameObject[] FallingPlaces;
    private GameObject manager;
    private int indexPlace;
    private float TimeToSpawn;
    private int amountC = 0;
    private GameObject playerR;
    [SerializeField] private GameObject Cplayer;
    private bool second = false;
    [SerializeField] private TMP_Text texxto;
    //private GameObject InsideOldLaColiders;
    void Start()
    {
        TimeToSpawn = 0f;
        indexPlace = 0;
        manager = GameObject.FindWithTag("mannager");
        playerR = GameObject.FindWithTag("Chara");
        if (GameObject.FindWithTag("mannager").GetComponent<sceneManager>().retLanguage() == 1)
        {
            texxto.text = "Лаві бутэлькі!";
        }
    }
    
    void Update()
    {
        TimeToSpawn += Time.deltaTime;
        Debug.Log(amountC);
        if (TimeToSpawn >= 1f)
        {
            TimeToSpawn = 0f;
            Instantiate(Cup, new Vector3(FallingPlaces[indexPlace].transform.position.x, 2.16f, 0.0f), CupT.rotation, CupT);
            indexPlace++;
            amountC++;
            if (indexPlace >= CupAmount)
            {
                indexPlace = 0;
            }
        }
        if (amountC > 10)
        {
            int cCout = Cplayer.GetComponent<PlayerCatch>().Finosh();
            if (cCout > 5)
            {
                Weights.Instance.AddDexterity(10);
            }
            else
            {
                Weights.Instance.AddDexterity(-10);
            }

            //manager.GetComponent<lugge>().AddBuble();
            manager.GetComponent<lugge>().AddBuble();
            manager.GetComponent<sceneManager>().FinishMiniGame();
            playerR.GetComponent<MainCharacter>().SetFree();
        }

    }
}
