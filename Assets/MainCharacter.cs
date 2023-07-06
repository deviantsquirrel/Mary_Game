using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 2.0f;
    private Vector2 velocity;
    private Rigidbody2D rb2d;
    private Animator animator;
    public static int dir;
    public static int move;

    [SerializeField] private DialogUA dialogUA;
    public DialogUA DialogUA => dialogUA;
    public IInteractable Interactable { get; set; }
    private SpriteRenderer sprtR;

    public GameObject ManagerR;
    public bool MiniGameOn;

    public bool MiniGame_Zone;
    public bool Cup_MiniGame_Zone;
    public bool Tae_MiniGame_Zone;

    private bool callme=false;
    private int travelCount = 0;
    private bool TakenOver = false;
    private bool MoveDown = false;
    private bool Water_Zone = false;
    private bool Salattoe_Zone = false;
    private bool OldLady_Zone = false;
    private bool hasLoti = false;
    private bool Table_Zone = false;
    private bool Stove_Zone = false;
    private bool Chair_Zone = false;
    private bool BasEner_Zone = false;
    private bool WaitSS = false;
    private bool StoveInter = false;
    private bool sitfirst=false;

    private GameObject InsideOldLaColiders;
    private bool NeverbeenInHouse = true;
    private bool Ending = false;
    private bool NoMove = false;

    private bool firstTimeInsideMHouse = true;
    private bool firstTimeGoDown = true;


    private bool stove2_Zone = false;
    private bool lotion_Zone = false;
    private bool alcohol_Zone = false;

    private bool secondLv = true;
    private int dira;

    private bool HomerWork_Zone = false;
    private bool Bed_Zone = false;
    private bool Books_Zone = false;
    private bool Bath_Zone = false;

    private bool ShufI_Zone = false;
    private bool ShufII_Zone = false;

    private bool biblecollected = false;

    private bool MSee_Zone = false;
    private bool Mhear_Zone = false;
    private bool MSpeak_Zone = false;

    private bool Hide_Zone = false;

    void Start()
    {
        velocity = new Vector2(speed, speed);
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        MiniGameOn = false;
        MiniGame_Zone = false;
        Cup_MiniGame_Zone = false;
        Tae_MiniGame_Zone = false;
        sprtR = GetComponent<SpriteRenderer>();


        NoMove = true;

        //MiniGameOn = true;
    }

    void Update()
    {
        if (TakenOver)
        {
            Vector2 Dodo = new Vector2(0.0f, 1.0f);
            animator.SetInteger("move", 1);
            animator.SetInteger("dir", 3);
            Dodo = Dodo * velocity * Time.deltaTime;
            Vector2 nPosition = rb2d.position + Dodo;
            rb2d.MovePosition(nPosition);
            if (rb2d.position.y >= -1.4f)
            {
                TakenOver = false;
            }

        }
        if (MoveDown)
        {
            //rb2d.MovePosition(rb2d.position + new Vector2(rb2d.position.x, 0.17f) * speed);
            //if (rb2d.position.y <= -0.17f) { MoveDown = false; }
            rb2d.transform.position = new Vector2(rb2d.transform.position.x, 0.17f);
            MoveDown = false;
        }
        if (callme)
        {
            callme = false;
            Interactable?.Interact(this);
        }
        if (dialogUA.IsOpen || ManagerR.GetComponent<lugge>().IsItOpen() || MiniGameOn|| TakenOver|| MoveDown||WaitSS|| NoMove) {

            //Debug.Log("Cant move");
            //Debug.Log(MiniGameOn);
            //Debug.Log(WaitSS);
            //Debug.Log(NoMove);
            animator.SetInteger("move", 0);
            return;
            
        }

        float horiMove = Input.GetAxisRaw("Horizontal");
        float vertyMove = Input.GetAxisRaw("Vertical");
        Vector2 delta = new Vector2(0.0f, 0.0f);
        if (horiMove != 0f)
        {
            animator.SetInteger("move", 1);
            delta = new Vector2(horiMove, 0f);
            if (horiMove > 0) { animator.SetInteger("dir", 2); dira = 2; }
            else { animator.SetInteger("dir", 4); dira = 4; }
        }
        else if(vertyMove != 0f)
        {
            animator.SetInteger("move", 1);
            delta = new Vector2(0f, vertyMove);
            if (vertyMove > 0) { animator.SetInteger("dir", 3); dira = 3; }
            else { animator.SetInteger("dir", 1); dira = 1; }
        }
        else
        {
            animator.SetInteger("move", 0);
            delta = Vector2.zero;
        }
        delta = delta * velocity * Time.deltaTime;
        Vector2 newPosition = rb2d.position + delta;
        rb2d.MovePosition(newPosition);
        

        if (Input.GetKeyDown(KeyCode.E))
        {
            Interactable?.Interact(this);
        }

        if (Input.GetKeyDown(KeyCode.E)&& MiniGame_Zone)
        {
            ManagerR.GetComponent<sceneManager>().StartSpiderGame();
            MiniGameOn = true;
        }
        if (Input.GetKeyDown(KeyCode.E) && ShufI_Zone)
        {
            ManagerR.GetComponent<sceneManager>().StartShufIGame();
            MiniGameOn = true;
        }
        if (Input.GetKeyDown(KeyCode.E) && ShufII_Zone)
        {
            ManagerR.GetComponent<sceneManager>().StartShufIIkGame();
            MiniGameOn = true;
        }
        if (Input.GetKeyDown(KeyCode.E) && Cup_MiniGame_Zone)
        {
            ManagerR.GetComponent<sceneManager>().StartCupGame();
            MiniGameOn = true;
        }
        if (Input.GetKeyDown(KeyCode.E) && Tae_MiniGame_Zone)
        {
            ManagerR.GetComponent<sceneManager>().StartTeaGame();
            MiniGameOn = true;
        }
        if (Input.GetKeyDown(KeyCode.E) && Water_Zone)
        {
            InsideOldLaColiders.GetComponent<insideroomControllers>().WaterInteruction();
        }
        if (Input.GetKeyDown(KeyCode.E) && Salattoe_Zone)
        {
            ManagerR.GetComponent<lugge>().AddSalatoe();
        }
        if (Input.GetKeyDown(KeyCode.E) && Chair_Zone&&!sitfirst)
        {
            sitfirst = true;
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), GameObject.FindWithTag("chair").GetComponent<Collider2D>(), true);

            transform.position = new Vector3(1.057f, -0.414f, 0.0f);
            animator.SetBool("sit", true);
            sprtR.sortingLayerName="cover car";
            ManagerR.GetComponent<LastBitController>().SitTable();
            GameObject.FindWithTag("insColider").GetComponent<insideroomControllers>().RemoveCups();
            
            GameObject.FindWithTag("grandpa").GetComponent<grandPapa>().Drink();
            MiniGameOn = true;
            StartCoroutine(Waw(2f));
            //set anim sit
        }
        if (Input.GetKeyDown(KeyCode.E) && Stove_Zone)
        {
            testt();
        }
        if (Input.GetKeyDown(KeyCode.E) && Stove_Zone&& GameObject.FindWithTag("insColider").GetComponent<insideroomControllers>().IsAddTeaa()&&!StoveInter)
        {
            ManagerR.GetComponent<lugge>().AddKattle();
            GameObject.FindWithTag("insColider").GetComponent<insideroomControllers>().KettleBack();
            StoveInter = true;
        }
        if (Input.GetKeyDown(KeyCode.E) && stove2_Zone&& ManagerR.GetComponent<lugge>().IsFoodCooki())
        {
            ManagerR.GetComponent<lugge>().AddReadyFood();
        }
        if (Input.GetKeyDown(KeyCode.E) && lotion_Zone&&dira==3)
        {
            ManagerR.GetComponent<sceneManager>().StartLotionGame();
            MiniGameOn = true;
        }
        if (Input.GetKeyDown(KeyCode.E) && HomerWork_Zone && GameObject.FindWithTag("boy").GetComponent<boyControll>().DidEat())
        {
            Debug.Log("here");
            ManagerR.GetComponent<secLdialog>().homeworkFetch();
            ManagerR.GetComponent<controllthese>().use_homework();
        }
        if (Input.GetKeyDown(KeyCode.E) && Bed_Zone && GameObject.FindWithTag("boy").GetComponent<boyControll>().isInbed())
        {
            ManagerR.GetComponent<secLdialog>().readstory();
            ManagerR.GetComponent<controllthese>().use_bed();
        }
        if (Input.GetKeyDown(KeyCode.E) && Books_Zone&& dira == 3)
        {
            if (!biblecollected)
            {
                ManagerR.GetComponent<secLdialog>().readbible();
                biblecollected = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.E) && BasEner_Zone && dira == 3&& ManagerR.GetComponent<lugge>().Ret_tas()&& ManagerR.GetComponent<controllbasment>().canIgo())
        {
            if (ManagerR.GetComponent<controllbasment>().doorlocked())
            {
                StartingRiddles();
            }
            else
            {
                transform.position = new Vector3(0.24f, -0.92f, 0.0f);
                ManagerR.GetComponent<sceneManager>().LoadCloves();
                ManagerR.GetComponent<controllbasment>().startmus();
            }
        }
        if (Input.GetKeyDown(KeyCode.E) && Hide_Zone && ManagerR.GetComponent<hideANDseek>().Hideing())
        {
            int num = ManagerR.GetComponent<hideANDseek>().WhatHidingPl();
            GameObject.FindWithTag("boy").GetComponent<boyControll>().StepOutsede(num);
            ManagerR.GetComponent<secLdialog>().Hide_Seek();
            //genenrete dio that givea a drawing

            //add photo
            //boy step out 
            //Chara move
            //pos depend on num of 
            //
        }
        //if (Input.GetKeyDown(KeyCode.E) && MSee_Zone )
        //{
        //    ManagerR.GetComponent<controllthese>().killsee();
        //}
        //if (Input.GetKeyDown(KeyCode.E) && Mhear_Zone && dira == 3)
        //{
        //    ManagerR.GetComponent<controllthese>().killhear();
        //}
        //if (Input.GetKeyDown(KeyCode.E) && MSpeak_Zone && dira == 3)
        //{
        //    ManagerR.GetComponent<controllthese>().killsay();
        //}

    }
    public void StartingRiddles()
    {
        ManagerR.GetComponent<sceneManager>().StartTextRiddle();
        MiniGameOn = true;
    }
    public bool isIteratorSpeaking()
    {
        return dialogUA.IsOpen;
    }
    public void SetEnding()
    {
        Ending = true;
    }
    public void MoveAway(float xx,float yy)
    {
        transform.position = new Vector3(xx, yy, 0.0f);
        Debug.Log(xx);
    }
    public void GetUp()
    {
        Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), GameObject.FindWithTag("chair").GetComponent<Collider2D>(), false);
        transform.position = new Vector3(1.057f, -0.714f, 0.0f);
        animator.SetBool("drink", false);
        sprtR.sortingLayerName = "character";
        MiniGameOn = false;

    }
    private void testt()
    {
        Debug.Log("Stove_Zone" + Stove_Zone);
        Debug.Log("Input.GetKeyDown(KeyCode.E)" + Input.GetKeyDown(KeyCode.E));
        Debug.Log("GameObject.FindWithTag(\"insColider\").GetComponent<insideroomControllers>().IsCompleteTeaQ()" + GameObject.FindWithTag("insColider").GetComponent<insideroomControllers>().IsCompleteTeaQ());
        Debug.Log("!StoveInter" + !StoveInter);
    }
    IEnumerator Wawa(float ss)
    {
        WaitSS = true;
        yield return new WaitForSeconds(ss);
        WaitSS = false;
    }
    IEnumerator Waw(float ss)
    {
        Debug.Log("Start Waited to drink");
        yield return new WaitForSeconds(ss);
        Debug.Log("Waited to drink");
        animator.SetBool("sit", false);
        animator.SetBool("drink", true);
    }
    public void WaitS(float ss)
    {
        StartCoroutine(Wawa(ss));
    }

    public bool IsWaterZone() { return Water_Zone; }
    public bool IsBedZone() { return Bed_Zone; }
    public bool IsTableZone() { return Table_Zone; }
    public bool IsStoveZone() { return Stove_Zone; }
    public bool IsStoveZone2() { return stove2_Zone; }
    public bool Islotion_Zone() { return lotion_Zone; }
    public bool IsChairZone() { return Chair_Zone; }
    public bool IsSecond() { return secondLv; }
    public bool IsSee() { return MSee_Zone; }
    public bool IsHear() { return Mhear_Zone; }
    public bool IsSpeak() { return MSpeak_Zone; }
    
    public bool IsBathZone() { 
        if (Bath_Zone && dira == 4) { 
            return true; 
        } else {
            return false;
        } }
    private bool ChaekCountForrest()
    {
        if (travelCount < 5)
        {
            travelCount++;
            return true;
        }else
        {
            travelCount = 0;
            return false;
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.tag == "CantGo"|| hitInfo.gameObject.tag == "BigDioo")
        {
            callme = true;
            Debug.Log(hitInfo);

        }
        if (hitInfo.gameObject.tag == "loadForresrPrelude")
        {
            ManagerR.GetComponent<sceneManager>().LoadForresrCenter();
            transform.position = new Vector3(-6.18f, -2.18f, 0.0f);

        }
        if (hitInfo.gameObject.tag == "LoadWinter")
        {

            ManagerR.GetComponent<sceneManager>().LoadWinter();
            if (ChaekCountForrest()) { transform.position = new Vector3(-0.17f, 4.16f, 0.0f); } else {transform.position = new Vector3(0.087f, -3.46f, 0.0f); TakenOver = true; }
            Debug.Log("winter");
            
        }
        if (hitInfo.gameObject.tag == "loadSpering")
        {
            ManagerR.GetComponent<sceneManager>().LoadSpring();
            if (ChaekCountForrest()) { transform.position = new Vector3(5.64f, 0.93f, 0.0f); } else { transform.position = new Vector3(0.087f, -3.46f, 0.0f); TakenOver = true; }
            

        }
        if (hitInfo.gameObject.tag == "loadFall")
        {
            ManagerR.GetComponent<sceneManager>().LoadFall(); 
            if (ChaekCountForrest()) { transform.position = new Vector3(-6.28f, 1.92f, 0.0f); } else { transform.position = new Vector3(0.087f, -3.46f, 0.0f); TakenOver = true; }

        }
        if (hitInfo.gameObject.tag == "loadSummer")
        {
            ManagerR.GetComponent<sceneManager>().LoadSummer();
            if (ChaekCountForrest()) { transform.position = new Vector3(-1.171f, -4.24f, 0.0f); } else {
                if (ManagerR.GetComponent<sceneManager>().ReturnIAmAtGrandmamasRight())
                {
                    rb2d.transform.position = new Vector3(-3.88f, -4.11f, 0.0f);
                }
                else
                {
                    transform.position = new Vector3(0.087f, -3.46f, 0.0f); 
                    TakenOver = true; 
                }
            }
        }
        if (hitInfo.gameObject.tag == "insHOuse")
        {
            Debug.Log("Go inside!!");
            if (Ending) {
                ManagerR.GetComponent<sceneManager>().LoadInsideEnding();
            } else if (NeverbeenInHouse)
            {
                ManagerR.GetComponent<sceneManager>().LoadHouseFirstTime();
                NeverbeenInHouse = false;
            }
            else { ManagerR.GetComponent<sceneManager>().LoadHouseAgain(); }
            transform.position = new Vector3(-0.74f, -2.3f, 0.0f);
            animator.SetInteger("move", 1);
            animator.SetInteger("dir", 1);
            animator.SetInteger("move", 0);
            InsideOldLaColiders = GameObject.FindWithTag("insColider");
        }
        if (hitInfo.gameObject.tag == "outHouse")
        {
            if (Ending)
            {
                ManagerR.GetComponent<sceneManager>().LoadOutsideEnding();
            }
            else
            {
                ManagerR.GetComponent<sceneManager>().LoadOutsideMiddle();
            }
            Debug.Log("Go outside!!");
            
            transform.position = new Vector3(-4.3f, -2.54f, 0.0f);
            animator.SetInteger("move", 1);
            animator.SetInteger("dir", 3);
            animator.SetInteger("move", 0);

        }
        
        if (hitInfo.gameObject.tag == "oldLady")
        {
            rb2d.velocity = Vector2.zero;
            OldLady_Zone = true;

        }
        if (hitInfo.CompareTag("spider")) { MiniGame_Zone = true; }
        if (hitInfo.CompareTag("cupsCub")) {  Cup_MiniGame_Zone = true; }
        if (hitInfo.CompareTag("TeaGame"))  {Tae_MiniGame_Zone = true; }
        if (hitInfo.CompareTag("Fauset")) { Water_Zone = true; }
        if (hitInfo.CompareTag("lotopn")) { if (!ManagerR.GetComponent<lugge>().hasLoti()) { ManagerR.GetComponent<lugge>().AddLoti(); } }
        if (hitInfo.CompareTag("Salata")) { Salattoe_Zone = true;   }
        if (hitInfo.gameObject.tag == "OldManhere") { ManagerR.GetComponent<sceneManager>().ManIn(); animator.SetInteger("move", 1);
            animator.SetInteger("dir", 4);
            animator.SetInteger("move", 0);
            GameObject.FindWithTag("oldLady").GetComponent<OldLadyIns>().PutColi();
        }
        if (hitInfo.CompareTag("table")) { Table_Zone = true; }
        if (hitInfo.CompareTag("stove")) { Stove_Zone = true; }
        if (hitInfo.CompareTag("chair")) { Chair_Zone = true; }
        if (hitInfo.CompareTag("stove2")) { stove2_Zone = true; }
        if (hitInfo.CompareTag("buble_game")) { lotion_Zone = true; }
        if (hitInfo.CompareTag("homework")) { HomerWork_Zone = true; }
        if (hitInfo.CompareTag("bed")) { Bed_Zone = true; }
        if (hitInfo.CompareTag("books")) { Books_Zone = true; }
        if (hitInfo.CompareTag("bath")) { Bath_Zone = true; }

        if (hitInfo.CompareTag("nextLv")) { 
            Debug.Log("Next level");
            ManagerR.GetComponent<sceneManager>().CleanUp();
            ManagerR.GetComponent<LastBitController>().SamOver();
            GameObject.FindWithTag("insColider").GetComponent<insideroomControllers>().CleanUP();
        }
        if (hitInfo.CompareTag("startsecond")) { 
            ManagerR.GetComponent<sceneManager>().LoadForrestSecond(); 
            transform.position = new Vector3(-6.25f, -3.35f, 0.0f);
            
        }
        if (hitInfo.CompareTag("outsideMurH"))
        {
            ManagerR.GetComponent<sceneManager>().LoadSecondHouse();
            if (firstTimeGoDown)
            {
                ManagerR.GetComponent<sceneManager>().CreateGirl();
                transform.position = new Vector3(-6.25f, -2.57f, 0.0f);
                NoMove = true;
            }
        }
        if (hitInfo.CompareTag("goDown"))
        {
            ManagerR.GetComponent<sceneManager>().LoadInsideSecondHouse();
            transform.position = new Vector3(-1f, -1f, 0.0f);
            if (firstTimeGoDown)
            {
                ManagerR.GetComponent<sceneManager>().CreateBoy();
                GameObject.FindWithTag("girl").GetComponent<girlControll>().InsideNow();
                firstTimeGoDown = false;
            }
        }
        if (hitInfo.CompareTag("goUp"))
        {
            ManagerR.GetComponent<sceneManager>().LoadLobbie();
            transform.position = new Vector3(-1f, -1f, 0.0f);
        }
        if (hitInfo.CompareTag("gotoLobbie"))
        {
            ManagerR.GetComponent<sceneManager>().LoadLobbie();
            transform.position = new Vector3(-1f, -1f, 0.0f);
        }
        if (hitInfo.CompareTag("gobathroom"))
        {
            if (!GameObject.FindWithTag("boy").GetComponent<boyControll>().isbathfilled())
            {
                ManagerR.GetComponent<sceneManager>().LoadBathroom();
                transform.position = new Vector3(0.96f, -0.45f, 0.0f);
            }
        }
        if (hitInfo.CompareTag("gochildroom"))
        {
            ManagerR.GetComponent<sceneManager>().LoadChildRoom();
            transform.position = new Vector3(-3f, -1.2f, 0.0f);
        }
        if (hitInfo.CompareTag("gomomroom"))
        {
            ManagerR.GetComponent<sceneManager>().LoadMomRoom();
            transform.position = new Vector3(-1f, -1f, 0.0f);
        }
        if (hitInfo.CompareTag("Bup"))
        {
            ManagerR.GetComponent<controllbasment>().Choseroomtoload(3);
            transform.position = new Vector3(0.24f, -0.92f, 0.0f);
        }
        if (hitInfo.CompareTag("BLeft"))
        {
            ManagerR.GetComponent<controllbasment>().Choseroomtoload(4);
            transform.position = new Vector3(0.24f, -0.92f, 0.0f);
        }
        if (hitInfo.CompareTag("BRight"))
        {
            ManagerR.GetComponent<controllbasment>().Choseroomtoload(2);
            transform.position = new Vector3(0.24f, -0.92f, 0.0f);
        }
        if (hitInfo.CompareTag("BDown"))
        {
            transform.position = new Vector3(0.24f, -0.92f, 0.0f);
            ManagerR.GetComponent<controllbasment>().Choseroomtoload(1);
            
        }
        if (hitInfo.CompareTag("gothBasCenter"))
        {
            transform.position = new Vector3(0.07f, -1.1f, 0.0f);
            ManagerR.GetComponent<sceneManager>().LoadCenter();
            GameObject.FindWithTag("girl").GetComponent<girlControll>().GirMove(1.68f, -0.17f);
            ManagerR.GetComponent<sceneManager>().createMa();

        }
        if (hitInfo.CompareTag("bottlegame")) { ShufI_Zone = true; }
        if (hitInfo.CompareTag("bogame")) { ShufII_Zone = true; }
        if (hitInfo.CompareTag("monkeys")) { MSee_Zone = true; }
        if (hitInfo.CompareTag("monkey")) { Mhear_Zone = true; }
        if (hitInfo.CompareTag("monkeyspe")) { MSpeak_Zone = true; }
        if (hitInfo.CompareTag("hidePlace")) { Hide_Zone = true; }
        if (hitInfo.CompareTag("enterbasement")) { BasEner_Zone = true; }
        if (hitInfo.CompareTag("end")) { ManagerR.GetComponent<sceneManager>().CrEnder(); }
    }

    private void OnTriggerExit2D(Collider2D hitt)
    {
        if (hitt.CompareTag("spider") )
        {
            MiniGame_Zone = false;
        }
        if (hitt.CompareTag("cupsCub"))
        {
            Cup_MiniGame_Zone = false;
        }
        if (hitt.CompareTag("TeaGame"))
        {
            Tae_MiniGame_Zone = false;
        }
        if (hitt.CompareTag("Fauset"))
        {
            Water_Zone = false;
        }
        if (hitt.CompareTag("Salata"))
        {
            Salattoe_Zone = false;
        }
        if (hitt.CompareTag("oldLady"))
        {
            OldLady_Zone = false;
        }
        if (hitt.CompareTag("table")) { Table_Zone = false; }
        if (hitt.CompareTag("stove")) { Stove_Zone = false; }
        if (hitt.CompareTag("chair")) { Chair_Zone = false; }
        if (hitt.CompareTag("stove2")) { stove2_Zone = false; }
        if (hitt.CompareTag("buble_game")) { lotion_Zone = false; }
        if (hitt.CompareTag("homework")) { HomerWork_Zone = false; }
        if (hitt.CompareTag("bed")) { Bed_Zone = false; }
        if (hitt.CompareTag("books")) { Books_Zone = false; }
        if (hitt.CompareTag("bath")) { Bath_Zone = false; }
        if (hitt.CompareTag("bottlegame")) { ShufI_Zone = false; }
        if (hitt.CompareTag("bogame")) { ShufII_Zone = false; }
        if (hitt.CompareTag("monkeys")) { MSee_Zone = false; }
        if (hitt.CompareTag("monkey")) { Mhear_Zone = false; }
        if (hitt.CompareTag("monkeyspe")) { MSpeak_Zone = false; }
        if (hitt.CompareTag("hidePlace")) { Hide_Zone = false; }
        if (hitt.CompareTag("enterbasement")) { BasEner_Zone = false; }

    }
    public bool RetOld() { return OldLady_Zone; }
    public void SetFree()
    {
        MiniGameOn = false;
    }
    public void ContinuuDialogPlayer()
    {
        Interactable?.Interact(this);
    }
    public void goUpp() { MoveDown = true; }
    public void SheDiedMoveAside()
    {
        Debug.Log(dialogUA.IsOpen);
        Debug.Log(ManagerR.GetComponent<lugge>().IsItOpen());
        Debug.Log(MiniGameOn);
        Debug.Log(TakenOver);
        Debug.Log(MoveDown);
        Debug.Log(WaitSS);
        Debug.Log(NoMove);
    }
    public void CanMoveNow() { NoMove = false; }
    public void NoMoveNow() { NoMove = true; }
}
