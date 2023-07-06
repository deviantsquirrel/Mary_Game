using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CupsFall : MonoBehaviour
{

    [SerializeField] private GameObject Cup;
    [SerializeField] private Transform CupT;
    [SerializeField] private int CupAmount;
    [SerializeField] private GameObject[] FallingPlaces;
    [SerializeField] private TMP_Text texxto;

    private GameObject manager;
    private int indexPlace;
    private float TimeToSpawn;
    private int amountC = 0;
    private GameObject playerR;
    [SerializeField] private GameObject Cplayer;
    private bool second = false;
    //private GameObject InsideOldLaColiders;
    void Start()
    {
        //uppSec();
        if (!second) { GameObject.FindWithTag("insColider").GetComponent<insideroomControllers>().DestriyCuppy(); }
        
        TimeToSpawn = 0f;
        indexPlace = 0;
        manager = GameObject.FindWithTag("mannager");
        playerR = GameObject.FindWithTag("Chara");
        if (manager.GetComponent<sceneManager>().retLanguage() == 1)
        {
            texxto.text = "Лаві кубкі!";
        }
    }
    //public void uppSec() {
    //    if (playerR.GetComponent<MainCharacter>().IsSecond()) { second = true; }
    //    }
    // Update is called once per frame
    void Update()
    {
        TimeToSpawn += Time.deltaTime;
        if (TimeToSpawn >= 1f)
        {
            TimeToSpawn = 0f;
            Instantiate(Cup, new Vector3(FallingPlaces[indexPlace].transform.position.x, 2.16f, 0.0f), CupT.rotation, CupT);
            indexPlace++;
           amountC ++;
            if(indexPlace>= CupAmount)
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

            manager.GetComponent<lugge>().AddCup();
            manager.GetComponent<sceneManager>().FinishMiniGame();
            playerR.GetComponent<MainCharacter>().SetFree();
        }
        
    }

}
