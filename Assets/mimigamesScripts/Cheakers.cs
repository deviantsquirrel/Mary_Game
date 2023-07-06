using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheakers : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject Enemy;
    [SerializeField] private GameObject PlayerHi;
    [SerializeField] private GameObject Chose;
    //int[,] myArray = { { 1, 0, 1, 0, 0, 2, 0, 2 }, { 0, 1, 0, 0, 0, 0, 2, 0 }, { 1, 0, 1, 0, 0, 2, 0, 2 }, { 0, 1, 0, 0, 0, 0, 2, 0 }, { 1, 0, 1, 0, 0, 2, 0, 2 }, { 0, 1, 0, 0, 0, 0, 2, 0 }, { 1, 0, 1, 0, 0, 2, 0, 2 }, { 0, 1, 0, 0, 0, 0, 2, 0 } };
    int[,] myArray = { { 1, 0, 1, 0, 1, 0, 1, 0 }, { 0, 1, 0, 1, 0, 1, 0, 1 }, { 1, 0, 1, 0, 1, 0, 1, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 2, 0, 2, 0, 2, 0, 2 }, { 2, 0, 2, 0, 2, 0, 2, 0 }, { 0, 2, 0, 2, 0, 2, 0, 2 } };
    GameObject[,] ObjArray = new GameObject[8, 8];
    private GameObject playerHi;
    private GameObject neWW;
    private int Xh = 2;
    private int Yh = 0;
    private int Xhh = 2;
    private int Yhh = 0;

    private bool chosen = false;
    private bool confirm = false;
    private bool YouGo = false;
    private bool freetoChose = true;
    //System.Random random = new System.Random();
    // Start is called before the first frame update
    List<GameObject> myList = new List<GameObject>();
    List<GameObject> PlayermyList = new List<GameObject>();
    List<GameObject> CanBeatList = new List<GameObject>();
    List<int> CanBeatListMoveHere = new List<int>();
    void Start()
    {
        Debug.Log("x,y" + Xh + " " + Yh);
        playerHi = Instantiate(PlayerHi, new Vector2(-1.5f, 3.5f), transform.rotation);
        for (int x = 0; x < 8; x++)
        {

            for (int y = 0; y < 8; y++)
            {

                if (myArray[x, y] == 1)
                {
                    ObjArray[x, y] = Instantiate(Player, new Vector2(-3.5f + x, 3.5f - y), transform.rotation);
                    PlayermyList.Add(ObjArray[x, y]);
                }
                else if (myArray[x, y] == 2)
                {
                    ObjArray[x, y] = Instantiate(Enemy, new Vector2(-3.5f + x, 3.5f - y), transform.rotation);
                    myList.Add(ObjArray[x, y]);

                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        itsGameOver();
        if (ILost)
        {
            Debug.Log("grandpa won");
            GameObject.FindWithTag("mannager").GetComponent<LastBitController>().statsS(false);
            GameObject.FindWithTag("mannager").GetComponent<sceneManager>().FinishMiniGame();
            RemoveAll();
            GameObject.FindWithTag("mannager").GetComponent<LastBitController>().HouseMus();
            return;
        }
        if (PlaerLost)
        {
            Debug.Log("you won");
            GameObject.FindWithTag("mannager").GetComponent<LastBitController>().statsS(true);
            GameObject.FindWithTag("mannager").GetComponent<sceneManager>().FinishMiniGame();
            RemoveAll();
            GameObject.FindWithTag("mannager").GetComponent<LastBitController>().HouseMus();
            return;
        }

        if (Input.GetKeyDown(KeyCode.A) && !chosen)
        {
            //Debug.Log("63");
            for (int i = 2; i <= Xh; i += 2)
            {
                if (CheakMINE(Xh -  i, Yh))
                {
                    playerHi.transform.position = new Vector2(playerHi.transform.position.x - i , playerHi.transform.position.y);
                    Xh = Xh - i; Yh = Yh;
                    //Debug.Log("x,y" + Xh + " " + Yh + "i" + i);
                    return;
                }
                //Debug.Log(" Not mine x,y" + Xh + " " + Yh + "i" + i);
                //Debug.Log(Xh - i); Debug.Log(Yh);
            }
        }
        if (Input.GetKeyDown(KeyCode.D) && !chosen)
        {
            //Debug.Log("78");
            for (int i = 2; i < 8 - Xh; i += 2)
            {
                if (CheakMINE(Xh + i, Yh))
                {
                    playerHi.transform.position = new Vector2(playerHi.transform.position.x + i , playerHi.transform.position.y);
                    Xh = Xh + i; Yh = Yh;
                    //Debug.Log("x,y" + Xh + " " + Yh + "i" + i);
                    return;
                }
                //Debug.Log(" Not mine x,y" + Xh + " " + Yh + "i" + i);
                //Debug.Log(Xh + i); Debug.Log(Yh);
            }
        }
        if (Input.GetKeyDown(KeyCode.S) && !chosen)
        {
            //Debug.Log("93");
            int mas = 8 - Yh;
            //Debug.Log("mas" + mas);
            for (int i = 1; i < mas; i++)
            {
                //Debug.Log("i" + i);
                for (int ii = 0; ii < 8; ii++)
                {
                    //Debug.Log("ii,i" + ii + " " + i);
                    if (CheakMINE(ii, Yh + i))
                    {
                        playerHi.transform.position = new Vector2(-3.5f + ii, playerHi.transform.position.y - i);
                        Xh = ii; Yh = Yh + i;
                        //Debug.Log("x,y" + Xh + " " + Yh + "i");
                        return;
                    }
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.W) && !chosen)
        {
            //Debug.Log("113");
            for (int i = 1; i <= Yh; i++)
            {
                //Debug.Log("i" + i);
                for (int ii = 0; ii < 8; ii++)
                {
                    //Debug.Log("ii,i" + ii + " " + i);
                    if (CheakMINE(ii, Yh - i))
                    {
                        playerHi.transform.position = new Vector2(-3.5f + ii, playerHi.transform.position.y + i);
                        Xh =  ii; Yh = Yh - i;
                        //Debug.Log("This one x,y" + Xh + " " + Yh + "i");
                        return;
                    }
                    //Debug.Log("No line ii,i" + ii + " " + i);
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.E) && !chosen)
        {
            //Debug.Log("132");
            if (CheakMove(Xh, Yh))
            {
                neWW = Instantiate(Chose, new Vector2(-3.5f + Xh, 3.5f - Yh), transform.rotation);
                chosen = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.W) && chosen && freetoChose)
        {
            //Debug.Log("141");
            if (CheakMoveHere(Xh + 1, Yh - 1))
            {
                Debug.Log("Center x,y" + Xh + " " + Yh);
                playerHi.transform.position = new Vector2(-3.5f + Xh + 1f, 3.5f - Yh + 1f);
                Xhh = Xh + 1; Yhh = Yh - 1;
                Debug.Log("Will move here x,y" + Xhh + " " + Yhh);
                confirm = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.D) && chosen && freetoChose)
        {
            //Debug.Log("152");
            if (CheakMoveHere(Xh + 1, Yh + 1))
            {
                playerHi.transform.position = new Vector2(-3.5f + Xh + 1f, 3.5f - Yh - 1f);
                Xhh = Xh + 1; Yhh = Yh + 1;
                confirm = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.E) && freetoChose&&confirm)
        {
            //Debug.Log("161");
            ObjArray[Xh, Yh].transform.position = new Vector2(-3.5f + Xhh, 3.5f - Yhh);
            //Debug.Log("Confirm x,y" + Xhh + " " + Yhh);
            Destroy(neWW);

            myArray[Xh, Yh] = 0;
            Debug.Log("Center Xh, Yh is now zero" + Xh + " " + Yh);
            myArray[Xhh, Yhh] = 1;
            Debug.Log("Center x,y is here now " + Xhh + " " + Yhh);
            ObjArray[Xhh, Yhh] = ObjArray[Xh, Yh];
            ObjArray[Xh, Yh] = null;
            chosen = false;
            confirm = false;
            YouGo = true;
            Xh = Xhh; Yh = Yhh;
        }
        if (!freetoChose && Input.GetKeyDown(KeyCode.E))
        {
            //Debug.Log("188");
            if(chosimine+3< CanBeatListMoveHere.Count)
            {
                chosimine++;
            }
            else { chosimine=0; }
            
            neWW.transform.position = new Vector2(-3.5f + CanBeatListMoveHere[0 + chosimine * 2], 3.5f - CanBeatListMoveHere[1 + chosimine * 2]);
            playerHi.transform.position = new Vector2(-3.5f + CanBeatListMoveHere[0 + chosimine * 2], 3.5f - CanBeatListMoveHere[1 + chosimine * 2]);
            //neWW = Instantiate(Chose, new Vector2(CanBeatListMoveHere[0+chosimine*2], CanBeatListMoveHere[1+chosimine*2]), transform.rotation);
        }

        if (!freetoChose && Input.GetKeyDown(KeyCode.W))
        {
            //Debug.Log("Here");
            //Debug.Log("Want x y ");
            //Debug.Log(0 + chosimine * 2);
            //Debug.Log(1 + chosimine * 2);
            Debug.Log("Beat x "+CanBeatListMoveHere[0 + chosimine * 2]+"Beat y "+ CanBeatListMoveHere[1 + chosimine * 2]);
            if (CanBeatListMoveHere[0 + chosimine * 2] + 2<8&& CanBeatListMoveHere[1 + chosimine * 2] - 2 >= 0)
            {
                if (CheakMoveHere(CanBeatListMoveHere[0 + chosimine * 2] + 2, CanBeatListMoveHere[1 + chosimine * 2] - 2))
                {
                    Xh = CanBeatListMoveHere[0 + chosimine * 2] ; Yh = CanBeatListMoveHere[1 + chosimine * 2];
                    Xhh = Xh + 2; Yhh = Yh - 2;
                    playerHi.transform.position = new Vector2(-3.5f + Xhh , 3.5f - Yhh );
                    Debug.Log("can go up");

                    KillEnemy(Xh + 1, Yh - 1);


                    dothus();
                }
            }
        }
        if (!freetoChose && Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("Beat x " + CanBeatListMoveHere[0 + chosimine * 2] + "Beat y " + CanBeatListMoveHere[1 + chosimine * 2]);
            if (CanBeatListMoveHere[0 + chosimine * 2] + 2 < 8 && CanBeatListMoveHere[1 + chosimine * 2] + 2 < 8)
            {
                if (CheakMoveHere(CanBeatListMoveHere[0 + chosimine * 2] + 2, CanBeatListMoveHere[1 + chosimine * 2] + 2))
                {
                    Xh = CanBeatListMoveHere[0 + chosimine * 2]; Yh = CanBeatListMoveHere[1 + chosimine * 2] ;
                    Xhh = Xh + 2; Yhh = Yh + 2;
                    playerHi.transform.position = new Vector2(-3.5f + Xhh , 3.5f - Yhh);
                    Debug.Log("can go down");
                    KillEnemy(Xh + 1, Yh + 1);
                    dothus();
                    
                }
            }
        }
        if (!freetoChose && Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Beat x " + CanBeatListMoveHere[0 + chosimine * 2] + "Beat y " + CanBeatListMoveHere[1 + chosimine * 2]);
            if (CanBeatListMoveHere[0 + chosimine * 2] - 2 >= 0 && CanBeatListMoveHere[1 + chosimine * 2] - 2 >= 0)
            {
                if (CheakMoveHere(CanBeatListMoveHere[0 + chosimine * 2] - 2, CanBeatListMoveHere[1 + chosimine * 2] - 2))
                {
                    Xh = CanBeatListMoveHere[0 + chosimine * 2]; Yh = CanBeatListMoveHere[1 + chosimine * 2];
                    Xhh = Xh - 2; Yhh = Yh - 2;
                    playerHi.transform.position = new Vector2(-3.5f + Xhh , 3.5f - Yhh );
                    Debug.Log("can go down back");
                    KillEnemy(Xh - 1, Yh - 1);
                    dothus();
                    
                }
            }
        }
        if (!freetoChose && Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("Beat x " + CanBeatListMoveHere[0 + chosimine * 2] + "Beat y " + CanBeatListMoveHere[1 + chosimine * 2]);
            if (CanBeatListMoveHere[0 + chosimine * 2] - 2 >=0  && CanBeatListMoveHere[1 + chosimine * 2] + 2 < 8)
            {
                if (CheakMoveHere(CanBeatListMoveHere[0 + chosimine * 2] - 2, CanBeatListMoveHere[1 + chosimine * 2] + 2))
                {
                    Xh = CanBeatListMoveHere[0 + chosimine * 2]; Yh = CanBeatListMoveHere[1 + chosimine * 2];
                    Xhh = Xh - 2; Yhh = Yh + 2;
                    playerHi.transform.position = new Vector2(-3.5f + Xhh , 3.5f - Yhh );
                    Debug.Log("can go up back");
                    KillEnemy(Xh - 1, Yh + 1);
                    dothus();
                   
                }
                
            }
        }


        if (YouGo)
        {
            //showAll();
            //ShowObj();
            YouGo = false;
            RedCanGoHere();
            PlayerCanBeat();
        }


    }

    private void KillEnemy(int x, int y)
    {
        Debug.Log("Destroying" +x+" "+y);
        myArray[x, y] = 0;
        myList.Remove(ObjArray[x, y]);
        Debug.Log("myList.Count()"+ myList.Count);
        Destroy(ObjArray[x, y]);
        //ObjArray[x, y]=null;
    }


    private void dothus()
    {
       // Debug.Log("Changing white" );
        ObjArray[Xh, Yh].transform.position = new Vector2(-3.5f + Xhh, 3.5f - Yhh);
        //Debug.Log("changed white");
        Destroy(neWW);
        //Debug.Log("destroyd gey");
        myArray[Xh, Yh] = 0;
        Debug.Log("Center Xh, Yh is now zero" + Xh + " " + Yh);
        myArray[Xhh, Yhh] = 1;
        Debug.Log("Center x,y is here now " + Xhh + " " + Yhh);
        ObjArray[Xhh, Yhh] = ObjArray[Xh, Yh];
        ObjArray[Xh, Yh] = null;
        chosen = false;
        confirm = false;
        YouGo = true;
        freetoChose = true;
        Xh = Xhh; Yh = Yhh;

    }
    private bool CheakMINE(int x, int y)
    {
        if (x >= 0 && y >= 0 && x <= 7 && y <= 7) { if (myArray[x, y] == 1) { return true; } else { return false; } } else { return false; }
    }
    private bool CheakMove(int x, int y)
    {
        if (x == 7 )
        {
            return false;
        }
        else if (x == 0 && y == 0)
        {
            if (myArray[x + 1, y + 1] == 0) { return true; } else { return false; }
        }
        else if (x == 0)
        {
            if (myArray[x + 1, y - 1] == 0 || myArray[x + 1, y + 1] == 0) { return true; } else { return false; }
        }
        else if (y == 0)
        {
            if ( myArray[x + 1, y + 1] == 0) { return true; } else { return false; }
        }
        else if (y == 7)
        {
            if (myArray[x + 1, y - 1] == 0) { return true; } else { return false; }
        }
        else
        {
            if ( myArray[x + 1, y - 1] == 0 || myArray[x + 1, y + 1] == 0) { return true; } else { return false; }
        }
    }
    private bool CheakMoveHere(int x, int y)
    {
        if (x >= 0 && x < 8 && y >= 0 && y < 8)
        {
            if (myArray[x, y] == 0) { return true; } else { return false; }
        }
        else
        {
            return false;
        }
        
    }

    private int SatisfiesCondition(int x, int y)
    {
         if (x == 0)
        {
             return 0;
        }
        else if (y == 0)
        {
            if (myArray[x -1, y + 1] == 0) { return 1; } else { return 0; }
        }
        else if (y == 7)
        {
            if (myArray[x - 1, y - 1] == 0) { return 2; } else { return 0; }
        }
        else
        {
            if (myArray[x - 1, y + 1] == 0 && myArray[x - 1, y - 1] == 0) { return 3; }
            else if (myArray[x - 1, y + 1] == 0) { return 1; } else if (myArray[x - 1, y - 1] == 0) { return 2; }
            { return 0; }
        }
        //if (myArray[i - 1, ii + 1] == 0 || myArray[i - 1, ii - 1] == 0) { return true;} else { return false; }
    }


    void showAll()
    {
        for (int x = 0; x < 8; x++)
        {
            Debug.Log(myArray[x, 0] + " " + myArray[x, 1] + " " + myArray[x, 2] + " " + myArray[x, 3] + " " + myArray[x, 4] + " " + myArray[x, 5] + " " + myArray[x, 6] + " " + myArray[x, 7]);
            
        }
    }
    private void PlayerCanBeat()
    {
        ccc = PlayermyList.Count;
        CanBeatList.Clear();
        CanBeatListMoveHere.Clear();
        //Debug.Log("CanBeatListMoveHere.Count" + CanBeatListMoveHere.Count);
        chosimine = 0;
        while (ccc > 0)
        {
            if (CanUseThis(PlayermyList[ccc-1], 2))
            {
                CanBeatList.Add(PlayermyList[ccc-1]);
            }
            ccc--;
        }
        if (CanBeatList.Count > 0)
        {
            freetoChose = false;
            chosen = true;
            confirm = true;
            playerHi.transform.position = new Vector2(-3.5f + CanBeatListMoveHere[0], 3.5f - CanBeatListMoveHere[1]);
            neWW = Instantiate(Chose, new Vector2(-3.5f + CanBeatListMoveHere[0], 3.5f - CanBeatListMoveHere[1]), transform.rotation);
        }
        Debug.Log("CanBeatList.Count"+CanBeatList.Count);
    }

    bool CanUseThis(GameObject aa, int caase)
    {
        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                if (ObjArray[x, y] == aa)
                {
                    Debug.Log("Cab kill" + x+" "+y);
                    if (Chaek( x,  y, caase)) { CanBeatListMoveHere.Add(x); CanBeatListMoveHere.Add(y); return true; } else { return false; }
                }
            }
        }
        return false;
    }

    bool Chaek(int x, int y, int caase)
    {
        Debug.Log("Cheaking" + x+" "+y);
        if ((x == 0&&y == 0)|| (x == 1 && y == 1))
        {
            if (myArray[x + 1, y + 1] == caase && myArray[x + 2, y + 2] == 0) { return true; }
        }else if((x == 7&&y == 1)|| (x == 6 && y == 0))
        { 
            if (myArray[x - 1, y + 1] == caase && myArray[x - 2, y + 2] == 0) { return true; } }
        else if ((x == 0 && y == 6) || (x == 1 && y == 7))
        {
            if (myArray[x + 1, y - 1] == caase && myArray[x + 2, y - 2] == 0) { return true; }
        }
        else if ((x == 7 && y == 7) || (x == 6 && y == 6))
        {
            if (myArray[x - 1, y - 1] == caase && myArray[x - 2, y - 2] == 0) { return true; }
        }
        else if (y == 0|| y == 1)
        {
            if (myArray[x + 1, y + 1] == caase && myArray[x + 2, y + 2] == 0) { return true; }
            else if (myArray[x - 1, y + 1] == caase && myArray[x - 2, y + 2] == 0) { return true; }
        }
        else if (y == 7|| y == 6)
        {
            if (myArray[x - 1, y - 1] == caase && myArray[x - 2, y - 2] == 0) { return true; }
            else if (myArray[x + 1, y - 1] == caase && myArray[x + 2, y - 2] == 0) { return true; }
        }else if (x == 0|| x == 1)
        {
            if (myArray[x + 1, y + 1] == caase && myArray[x + 2, y + 2] == 0) { return true; }
            else if (myArray[x + 1, y - 1] == caase && myArray[x + 2, y - 2] == 0) { return true; }
        }else if (x == 7|| x == 6)
        {
            if (myArray[x - 1, y - 1] == caase && myArray[x - 2, y - 2] == 0) { return true; }
            else if (myArray[x - 1, y + 1] == caase && myArray[x - 2, y + 2] == 0) { return true; }
        }
        else
        {
            if (myArray[x - 1, y - 1] == caase && myArray[x - 2, y - 2] == 0) { return true; }
            else if (myArray[x + 1, y + 1] == caase && myArray[x + 2, y + 2] == 0) { return true; }
            else if (myArray[x + 1, y - 1] == caase && myArray[x + 2, y - 2] == 0) { return true; }
            else if (myArray[x - 1, y + 1] == caase && myArray[x - 2, y + 2] == 0) { return true; }
            
        }
        return false;
    }
    private void CanKillPlayer()
    {
        Debug.Log("Looking for a player to kill");
        int size = myList.Count;
        CanBeatListMoveHere.Clear();
        showAll();
        for (int i=0; i<size; i++)
        {
            if (CanUseThis(myList[i], 1)&& !goodd)
            {
                goodd = true;
                Debug.Log("killing player");
                //Debug.Log("Want x y ");
                int x = CanBeatListMoveHere[0];
                int y = CanBeatListMoveHere[1];

                if (x - 2 >= 0 && y - 2 >= 0) { if (myArray[x - 1, y - 1] == 1&& myArray[x - 2, y - 2] == 0) {
                        Debug.Log("Changing up left");
                        ObjArray[x, y].transform.position = new Vector2(-3.5f + x-2, 3.5f - y+2);
                        myArray[x, y] = 0;
                        myArray[x - 1, y - 1] = 0;
                        myArray[x-2, y-2] = 2;
                        ObjArray[x-2, y-2] = ObjArray[x, y];
                        ObjArray[x, y] = null;
                        Debug.Log("move" + x + " " + y);
                        PlayermyList.Remove(ObjArray[x-1, y-1]);
                        Debug.Log("PlayermyList()" + PlayermyList.Count);
                        Destroy(ObjArray[x - 1, y - 1]);
                        Movehigh();
                        showAll();
                        ShowAllll();
                        return;
                    }
                    //Debug.Log("cant Changing up left");
                }
                 if (x + 2 <8 && y + 2 < 8)
                {
                    if (myArray[x + 1, y + 1] == 1&& myArray[x +2, y +2] == 0)
                    {
                        Debug.Log("Changing down right");
                        ObjArray[x, y].transform.position = new Vector2(-3.5f + x+2, 3.5f - y-2);
                        myArray[x, y] = 0;
                        myArray[x + 2, y + 2] = 2;
                        myArray[x + 1, y + 1] = 0;
                        ObjArray[x + 2, y + 2] = ObjArray[x, y];
                        ObjArray[x, y] = null;
                        Debug.Log("Move" + x + " " + y);
                        PlayermyList.Remove(ObjArray[x+1, y+1]);
                        Debug.Log("PlayermyList()" + PlayermyList.Count);
                        Destroy(ObjArray[x + 1, y + 1]);
                        Movehigh();
                        showAll();
                        ShowAllll();
                        return;
                    }
                    //Debug.Log(" cant Changing down right");
                }
                 if (x - 2 >= 0 && y + 2 < 8)
                {
                    if (myArray[x - 1, y + 1] == 1&& myArray[x - 2, y + 2] ==0)
                    {
                        Debug.Log("Changing left down");
                        ObjArray[x, y].transform.position = new Vector2(-3.5f + x-2, 3.5f - y-2);
                        myArray[x, y] = 0;
                        myArray[x-1, y+1] = 0;
                        myArray[x - 2, y + 2] = 2;
                        ObjArray[x - 2, y + 2] = ObjArray[x, y];
                        ObjArray[x, y] = null;
                        Debug.Log("Move" + x + " " + y);
                        PlayermyList.Remove(ObjArray[x-1, y+1]);
                        Debug.Log("PlayermyList()" + PlayermyList.Count);
                        Destroy(ObjArray[x - 1, y + 1]);
                        Movehigh();
                        showAll();
                        ShowAllll();
                        return;
                    }
                    //Debug.Log("cant Changing up left");
                }
                 if (x + 2 <8 && y - 2 >= 0)
                {
                    if (myArray[x + 1, y - 1] == 1&& myArray[x + 2, y - 2] == 0)
                    {
                        Debug.Log("Changing right up");
                        ObjArray[x, y].transform.position = new Vector2(-3.5f + x+2, 3.5f - y+2);
                        myArray[x, y] = 0;
                        myArray[x +1, y - 1] = 0;
                        myArray[x + 2, y - 2] = 2;
                        ObjArray[x + 2, y - 2] = ObjArray[x, y];
                        ObjArray[x, y] = null;
                        Debug.Log("Move" + x + " " + y);
                        PlayermyList.Remove(ObjArray[x+1, y-1]);
                        Debug.Log("PlayermyList()" + PlayermyList.Count);
                        Destroy(ObjArray[x+1, y-1]);
                        Movehigh();
                        showAll();
                        ShowAllll();
                        return;
                    }
                    //Debug.Log("cant Changing up left");
                }
                
            }
            Debug.Log("Cannot kill anything");
        }
    }
    //private void ShowObj()
    //{
    //    for (int x = 0; x < 8; x++)
    //    {
    //        for (int y = 0; y < 8; y++)
    //        {
    //            if (ObjArray[x, y] == Enemy)
    //            {
    //                Debug.Log("2");
    //            }
    //            if (ObjArray[x, y] == Player)
    //            {
    //                Debug.Log("1");
    //            }
    //            else
    //            {
    //                Debug.Log("0");
    //            }

    //        }
    //    }
    //}
    private void Movehigh ()
    {
        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                if (myArray[x, y] == 1)
                {
                    playerHi.transform.position = new Vector2(-3.5f + x, 3.5f - y);
                    Xhh = x; Yhh = y;
                    Xh = Xhh; Yh = Yhh;
                    return;
                }

            }
        }
    }

    private bool goodd = false;
    GameObject randomObject;
    int ccc = 0;
    int chosimine = 0;
    bool PlaerLost = false;
    bool ILost = false;
    bool PlaerGoOn = true;
    bool IGoOn = true;

    private void itsGameOver()
    {
        PlaerLost = true;
        ILost= true;
        PlaerGoOn = false;
        IGoOn = false;
        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                if (myArray[x, y] == 1)
                {
                    PlaerGoOn = true;
                }
                if (myArray[x, y] == 2)
                {
                    IGoOn = true;
                }
            }
        }
        if (!PlaerGoOn) {
            ILost = true;
            PlaerLost = false;
            return;

        }
        if (!IGoOn)
        {
            ILost = false;
            PlaerLost = true;
            return;

        }
        for (int x = 0; x < 7; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                if (myArray[x, y] == 1)
                {
                    PlaerLost = false;
                    break;
                }
            }
        }
        for (int x = 1; x < 8; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                if (myArray[x, y] == 2)
                {
                    ILost = false;
                    break;
                }
            }
        }
        
    }

    private void RemoveAll()
    {
        foreach (GameObject obj in myList)
        {
            Destroy(obj); // destroy each object
        }
        myList.Clear();
        foreach (GameObject obj in PlayermyList)
        {
            Destroy(obj); // destroy each object
        }
        PlayermyList.Clear();

        Destroy(playerHi);
    }



    private void ShowAllll()
    {
        Debug.Log("Enemy count " + myList.Count);

        for (int i = 0; i < myList.Count; i++)
        {
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if(myArray[x, y] == 2)
                    {
                        Debug.Log("Enemy x " + x + " y " + y);
                        
                    }
                }
            }
        }
    }
    private void RedCanGoHere()
    {
        ccc = myList.Count;
        goodd = false;

        CanKillPlayer();

        while (!goodd&&ccc>0)
        {

            int randomIndex = UnityEngine.Random.Range(0, myList.Count);
            ccc--;
            // Get the object at the random index
             randomObject = myList[randomIndex];
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    
                    if (ObjArray[x, y] == randomObject)
                    {
                        Debug.Log("Looking to just move not kill now");
                        Debug.Log("It is x y " + x + " " + y);
                        if (SatisfiesCondition(x, y) !=0)
                        {
                            if ((UnityEngine.Random.Range(0, 2) == 0 && SatisfiesCondition(x, y) == 3) || SatisfiesCondition(x, y) == 1)
                            {
                                ObjArray[x, y].transform.position = new Vector2(-3.5f + x - 1, 3.5f - y - 1);
                                Debug.Log("Satisfy dpwm  " );
                                //Debug.Log(x - 1);
                                //Debug.Log(y + 1);
                                ObjArray[x - 1, y + 1] = ObjArray[x, y];
                                myArray[x - 1, y + 1] = 2;
                                //Debug.Log(x - 1);
                                //Debug.Log(y + 1);
                                //Debug.Log("taken  ");

                            }
                            else
                            {
                                ObjArray[x, y].transform.position = new Vector2(-3.5f + x - 1 , 3.5f - y + 1);
                                Debug.Log("Satisfy upp, new pos  " );
                                //Debug.Log(x - 1);
                                //Debug.Log(y - 1);
                                ObjArray[x - 1, y - 1] = ObjArray[x, y];
                                myArray[x - 1, y - 1] = 2;
                                //Debug.Log(x - 1);
                                //Debug.Log(y - 1);
                                //Debug.Log("taken  ");
                            }
                            ObjArray[x, y] = null;
                            myArray[x, y] = 0;
                            //Debug.Log(x);
                            //Debug.Log(y );
                            //Debug.Log("free  ");
                            goodd = true;
                            showAll();
                            ShowAllll();
                            break;


                        }
                    }
                }
            }
            
        }
    }
}