using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    public GameObject Forresr_Prelude;
    public GameObject Forresr_Center;
    public GameObject Forresr_Spring;
    public GameObject Forresr_Winter;
    public GameObject Forresr_Fall;
    public GameObject Forresr_Summer;
    [SerializeField] GameObject GrandmaHouse;
    [SerializeField] GameObject GrandmaHouseColiders;

    [SerializeField] GameObject Dogo;
    [SerializeField] GameObject Bariers;
    [SerializeField] GameObject BlockCenterPass;

    [SerializeField] GameObject SpiderGame;
    [SerializeField] GameObject CupGame;
    [SerializeField] GameObject TeaGame;
    [SerializeField] GameObject CheakersGame;

    [SerializeField] GameObject OldLadyBig;
    private GameObject oldLadyBig;
    private GameObject oldLady;

    private GameObject CurrentLoad;
    private GameObject LoadCollider;
    private GameObject Doggo;
    private GameObject minigame;
    private GameObject barriers;

    [SerializeField] GameObject ForrestDialog;
    private GameObject forrestDialog;
    private int CoutCenter;

    [SerializeField] GameObject LostKeyActive;
    private GameObject Lostkeycreated;
    private GameObject KeysTalk;

    [SerializeField] GameObject wasBitten;
    [SerializeField] GameObject gatTheKey;
    [SerializeField] GameObject Repo;

    [SerializeField] GameObject BlockWayOut;
    private GameObject blockWayOut;

    [SerializeField] GameObject SofaSpider;
    private GameObject sofaSpider;

    [SerializeField] GameObject InsideHouse;
    [SerializeField] GameObject InsideHouseBariers;
    private GameObject insideHouse;


    public bool outside;
    public bool Grandmaoutside;

    [SerializeField] GameObject PlantsDoorColider;
    [SerializeField] GameObject PlantsColider;
    [SerializeField] GameObject PlantsSmall;
    [SerializeField] GameObject PlantsBig;
    [SerializeField] GameObject Loti;
    private GameObject loti;
    private GameObject plants;
    private GameObject plantsColi;
    private GameObject onlyplantsColi;
    private bool bigplants = false;
    [SerializeField] GameObject InsideLady;
    [SerializeField] GameObject OldMan;
    private GameObject oldMan;

    [SerializeField] GameObject ExitToTwo;
    [SerializeField] GameObject Wasteland;
    [SerializeField] GameObject corpse;
    private GameObject exi;

    [SerializeField] GameObject Corpi;
    private GameObject corpi;

    [SerializeField] GameObject ForrestSecond;
    [SerializeField] GameObject HouseLoan;
    [SerializeField] GameObject FirstFloor;
    [SerializeField] GameObject Lobbie;
    [SerializeField] GameObject ChildBedroom;
    [SerializeField] GameObject MasterBedroom;
    [SerializeField] GameObject Bathroom;
    [SerializeField] GameObject BasementFail;
    [SerializeField] GameObject BasementDiamond;
    [SerializeField] GameObject BasementHeart;
    [SerializeField] GameObject BasementCloves;
    [SerializeField] GameObject BasementPickes;
    [SerializeField] GameObject BasementCenter;
    [SerializeField] GameObject Girl;
    [SerializeField] GameObject Boy;
    [SerializeField] GameObject Sphynks;
    [SerializeField] GameObject Arlekin;
    [SerializeField] GameObject LotionGame;
    [SerializeField] GameObject HomeworkGame;
    [SerializeField] GameObject textRiddler;
    [SerializeField] GameObject shuff;
    [SerializeField] GameObject shufff;
    [SerializeField] GameObject Blacscr;
    [SerializeField] GameObject MaSit;
    [SerializeField] GameObject MaWalk;

    private GameObject girl;
    private GameObject mam;
    private GameObject boy;
    private GameObject sphynks;
    private GameObject arlekin;
    private GameObject blacscr;

    public bool boyexi = false;

    private int lang = 0;

    [SerializeField] GameObject intro;
    [SerializeField] GameObject cutscene;
    [SerializeField] GameObject ender;
    private GameObject screenn;
    [SerializeField] GameObject coliEnd;

    bool creEnder = false;
    private GameObject exittyty;
    void Start()
    {


       CurrentLoad = Instantiate(Forresr_Prelude, GameObject.Find("MainGrid").transform);
       CurrentLoad.transform.position = new Vector3(-0.8440801f, -1.723133f, -3.126855f);

        CoutCenter = 0;

    }
    public void ChangeLang(int aa) { lang = aa; }
    public void CrIntro() { screenn = Instantiate(intro, GameObject.Find("MainGrid").transform); }
    public void DsstroyInto() { Destroy(screenn); }

    public void CrCut() { screenn = Instantiate(cutscene, GameObject.Find("MainGrid").transform); }
    public void CrEnder() { screenn = Instantiate(ender, GameObject.Find("MainGrid").transform); }
    public void CrEnderColi() { creEnder = true; Debug.Log(creEnder); }

    public int retLanguage() { return lang; }
    public void SetLanguage(int langG) { lang = langG; }
    public void LoadForresrCenter()
    {
        Destroy(CurrentLoad);
        CurrentLoad = Instantiate(Forresr_Center, GameObject.Find("MainGrid").transform);
        //CurrentLoad.transform.parent = GameObject.Find("MainGrid").transform;
        CurrentLoad.transform.position = new Vector3(-0.72f, -0.15f, 0.0f);
        Doggo = Instantiate(Dogo, new Vector3(0.0f, 0.0f, 0.0f), transform.rotation);
        oldLadyBig = Instantiate(OldLadyBig, new Vector3(0.0f, 0.0f, 0.0f), transform.rotation);

        oldLady = oldLadyBig.transform.GetChild(0).gameObject;
        oldLady.transform.position = new Vector3(3.71f, 0.69f, 0.0f);
        //oldLady.SetActive(true);

        //Debug.Log("go");
        blockWayOut = Instantiate(BlockWayOut, new Vector3(0.0f, 0.0f, 0.0f), transform.rotation);
        GameObject.FindWithTag("MainGrid").GetComponent<compa>().Falsedir();
    }

    public void TalkingOverOldLady()
    {
        Destroy(blockWayOut);
        barriers = Instantiate(Bariers, new Vector3(0.0f, 0.0f, 0.0f), transform.rotation);
    }

    public void LoadWinter()
    {
        Destroy(CurrentLoad);
        barriers.GetComponent<LostInForrst>().CheakDirection(3);
        if (!barriers.GetComponent<LostInForrst>().FullCycle())
        {
            CurrentLoad = Instantiate(Forresr_Winter, GameObject.Find("MainGrid").transform);
            oldLady.transform.position = new Vector3(-0.19f, 4.9f, 0.0f);
        }
        else
        {
            CurrentLoad = Instantiate(Forresr_Center, GameObject.Find("MainGrid").transform);
            CallForresrDialog();
            oldLady.transform.position = new Vector3(-1.76f, -7.38f, 0.0f);
        }
    }

    public void LoadSpring()
    {
        Destroy(CurrentLoad);
        barriers.GetComponent<LostInForrst>().CheakDirection(4);
        if (!barriers.GetComponent<LostInForrst>().FullCycle())
        {
            CurrentLoad = Instantiate(Forresr_Spring, GameObject.Find("MainGrid").transform);
            oldLady.transform.position = new Vector3(6.82f, 0.89f, 0.0f);
        }
        else
        {
            CurrentLoad = Instantiate(Forresr_Center, GameObject.Find("MainGrid").transform);
            CallForresrDialog();
            oldLady.transform.position = new Vector3(-1.76f, -7.38f, 0.0f);
        }
    }

    public void LoadFall()
    {
        Destroy(CurrentLoad);
        barriers.GetComponent<LostInForrst>().CheakDirection(2);
        if (!barriers.GetComponent<LostInForrst>().FullCycle())
        {
            CurrentLoad = Instantiate(Forresr_Fall, GameObject.Find("MainGrid").transform);
            oldLady.transform.position = new Vector3(-6.6f, 1.79f, 0.0f);
        }
        else
        {
            CurrentLoad = Instantiate(Forresr_Center, GameObject.Find("MainGrid").transform);
            CallForresrDialog();
            oldLady.transform.position = new Vector3(-1.76f, -7.38f, 0.0f);
        }
    }

    public void LoadSummer()
    {
        oldLady.transform.position = new Vector3(-1.26f, -4.92f, 0.0f);
        Destroy(CurrentLoad);
        Debug.Log("LoadSummer");
        barriers.GetComponent<LostInForrst>().CheakDirection(1);

        if (barriers.GetComponent<LostInForrst>().FullCycle())
        {
            if (barriers.GetComponent<LostInForrst>().AllRihgt())
            {
                CurrentLoad = Instantiate(GrandmaHouse, GameObject.Find("MainGrid").transform);
                LoadCollider = Instantiate(GrandmaHouseColiders, new Vector3(0.0f, 0.0f, 0.0f), transform.rotation);
                Lostkeycreated = Instantiate(LostKeyActive, new Vector3(-3.5f, -3.87f, 0.0f), transform.rotation);
                oldLady.transform.position = new Vector3(-5.36f, -4.11f, 0.0f);
                blockWayOut = Instantiate(BlockWayOut, new Vector3(0.0f, 0.0f, 0.0f), transform.rotation);
                Destroy(barriers);
                oldLady.GetComponent<OldLady>().StoopFollow();
                outside = true;
                Grandmaoutside = true;
                plants = Instantiate(PlantsSmall, GameObject.Find("MainGrid").transform);
            }
            else
            {
                CurrentLoad = Instantiate(Forresr_Center, GameObject.Find("MainGrid").transform);
                CallForresrDialog();
                oldLady.transform.position = new Vector3(0.0f, 1.00f, 0.0f);
            }
        }
        else
        {
            
            CurrentLoad = Instantiate(Forresr_Summer, GameObject.Find("MainGrid").transform);
        }
    }

    public void LoadHouseFirstTime()
    {
        insideHouse = Instantiate(InsideHouse, GameObject.Find("MainGrid").transform);
        CurrentLoad.SetActive(false);
        plants.SetActive(false);
        plantsColi.SetActive(false);
        barriers = Instantiate(InsideHouseBariers, new Vector3(0.0f, 0.0f, 0.0f), transform.rotation);
        outside = false;
        Grandmaoutside = false;
        Destroy(oldLady);
        sofaSpider = Instantiate(SofaSpider, new Vector3(-2.75f, -2.4f, 0.0f), transform.rotation);
        oldLady = Instantiate(InsideLady, new Vector3(3.08f, 1.2f, 0.0f), transform.rotation);
        if (gameObject.GetComponent<RememberThings>().ReturnPoisonedStatus())
        {
            loti = Instantiate(Loti, new Vector3(3.06f, 0.41f, 0.0f), transform.rotation);

        }
        //gameObject.GetComponent<LastBitController>().CreateGran();//
        gameObject.GetComponent<LastBitController>().HouseMus();
    }

    public void LoadOutsideMiddle()
    {
        CurrentLoad.SetActive(true);
        insideHouse.SetActive(false);
        barriers.SetActive(false);
        outside = true;
        sofaSpider.SetActive(false);
        oldLady.SetActive(false);
        plantsColi.SetActive(true);
        if (gameObject.GetComponent<RememberThings>().BushStillActive()&& !gameObject.GetComponent<RememberThings>().ReturnPoisonedStatus())
        {
            LoadCollider = Instantiate(GrandmaHouseColiders, new Vector3(0.0f, 0.0f, 0.0f), transform.rotation);
        }
        if (bigplants)
        {
            plants = Instantiate(PlantsBig, GameObject.Find("MainGrid").transform);
            onlyplantsColi = Instantiate(PlantsColider, new Vector3(0.0f, 0.0f, 0.0f), transform.rotation);
        }
        else
        {
            plants = Instantiate(PlantsSmall, GameObject.Find("MainGrid").transform);
        }
        gameObject.GetComponent<LastBitController>().ForrestMus();
        gameObject.GetComponent<LastBitController>().Del_SinkMus();
    }
    public void LoadHouseAgain()
    {
        CurrentLoad.SetActive(false);
        insideHouse.SetActive(true);
        barriers.SetActive(true);
        outside = false;
        sofaSpider.SetActive(true);//chak
        oldLady.SetActive(true);
        plantsColi.SetActive(false);
        Destroy(plants);
        Destroy(onlyplantsColi);
        GameObject.FindWithTag("oldLady").GetComponent<OldLadyIns>().Cooko();
        //plants = Instantiate(PlantsBig, GameObject.Find("MainGrid").transform);
        if (gameObject.GetComponent<RememberThings>().ReturnPoisonedStatus()&& !gameObject.GetComponent<lugge>().hasLoti())
        {
            loti = Instantiate(Loti, new Vector3(3.06f, 0.41f, 0.0f), transform.rotation);
        }
        gameObject.GetComponent<LastBitController>().HouseMus();
    }

    public void LoadOutsideEnding()
    { 
        GameObject.FindWithTag("insColider").GetComponent<insideroomControllers>().HideUs();
        if (GameObject.FindWithTag("oldLady").GetComponent<thirdGran>().RUDY())
        {
            CurrentLoad = Instantiate(Wasteland, GameObject.Find("MainGrid").transform);
        }
        else
        {
            CurrentLoad.SetActive(true);
            plants = Instantiate(PlantsBig, GameObject.Find("MainGrid").transform);
        }
        plantsColi.SetActive(true);
        insideHouse.SetActive(false);
        barriers.SetActive(false);
        outside = true;
        sofaSpider.SetActive(false);
        gameObject.GetComponent<LastBitController>().hideBody();
        del_Corpi();
        gameObject.GetComponent<LastBitController>().Del_SinkMus();

        if (gameObject.GetComponent<RememberThings>().BushStillActive() && !gameObject.GetComponent<RememberThings>().ReturnPoisonedStatus())
        {
            LoadCollider = Instantiate(GrandmaHouseColiders, new Vector3(0.0f, 0.0f, 0.0f), transform.rotation);
        }
        if (!gameObject.GetComponent<lugge>().hasTea()) {
            oldMan = Instantiate(corpse, new Vector3(2.27f, -3.58f, 0.0f), transform.rotation);
        }
        if (gameObject.GetComponent<LastBitController>().ComppasHasbeenUsed())
        {
            exi = Instantiate(ExitToTwo, new Vector3(5.75f, -3.61f, 0.0f), transform.rotation);
        }
        gameObject.GetComponent<LastBitController>().ForrestMus();
    }
    public void ActivateEnding()
    {
        if(outside)
        {
            exi = Instantiate(ExitToTwo, new Vector3(5.75f, -3.61f, 0.0f), transform.rotation);
        }
    }

    public void LoadInsideEnding()
    {
        CurrentLoad.SetActive(false);
        insideHouse.SetActive(true);
        barriers.SetActive(true);
        outside = false;
        sofaSpider.SetActive(true);
        gameObject.GetComponent<LastBitController>().showBody();
        if (oldMan != null) { Destroy(oldMan); }
        if (plants != null) { Destroy(plants); }
        plantsColi.SetActive(false);
        if (exi!= null)
        {
            Destroy(exi);
        }
        gameObject.GetComponent<LastBitController>().HouseMus();
    }

    public void ManIn()
    {
        oldMan = Instantiate(OldMan, new Vector3(-1.17f, -2.16f, 0.0f), transform.rotation);

    }

    public void Place_corpi()
    {
        corpi = Instantiate(Corpi, new Vector3(4.62f, -3.26f, 0.0f), transform.rotation);

    }
    public void del_Corpi()
    {
        if (corpi != null) { Destroy(corpi); }
    }
    public bool ReturnIAmAtGrandmamasRight()
    {
        return barriers.GetComponent<LostInForrst>().AllRihgt();
    }
    public void CallForresrDialog()
    {
        Debug.Log("here FormNew" + CoutCenter);
        if (CoutCenter == 0)
        {
            forrestDialog = Instantiate(ForrestDialog, new Vector3(0.01f, -4.36f, 0.0f), transform.rotation);
            Debug.Log("here FormNew");
        }
        else
        {
            forrestDialog.SetActive(true);
        }
        CoutCenter++;
    }
    public void HideForrestDio()
    {
        Debug.Log("Hide Dio" + CoutCenter);
        forrestDialog.SetActive(false);
    }
    public void DestroyPass()
    {
        Destroy(BlockCenterPass);
    }

    public void StartSpiderGame()
    {
        minigame = Instantiate(SpiderGame, new Vector3(2.397563f, 0.3275032f, 0.0f), transform.rotation);
        DestDiologgi();
    }

    public void StartCupGame()
    {
        minigame = Instantiate(CupGame, new Vector3(0.0f, 0.0f, 0.0f), transform.rotation);
    }
    public void StartTeaGame()
    {
        minigame = Instantiate(TeaGame, new Vector3(0.0f, 0.0f, 0.0f), transform.rotation);
    }
    public void StartLotionGame()
    {
        minigame = Instantiate(LotionGame, new Vector3(0.0f, 0.0f, 0.0f), transform.rotation);
    }

    public void StartCheakersGame()
    {
        minigame = Instantiate(CheakersGame, new Vector3(0.0f, 0.0f, 0.0f), transform.rotation);
        gameObject.GetComponent<LastBitController>().CheakersMus();
    }

    public void StartHomeworkGame()
    {
        minigame = Instantiate(HomeworkGame, new Vector3(0.0f, 0.0f, 0.0f), transform.rotation);
    }
    public void StartShufIGame()
    {
        minigame = Instantiate(shuff, new Vector3(0.0f, 0.0f, 0.0f), transform.rotation);
    }
    public void StartShufIIkGame()
    {
        minigame = Instantiate(shufff, new Vector3(0.0f, 0.0f, 0.0f), transform.rotation);
    }
    public void StartTextRiddle()
    {
        minigame = Instantiate(textRiddler, new Vector3(0.0f, 0.0f, 0.0f), transform.rotation);
    }

    public void FinishMiniGame()
    {
        Destroy(minigame);
        if (outside) { Destroy(LoadCollider); }
    }
    public void CreateRepo()
    {
        KeysTalk = Instantiate(Repo, new Vector3(-5.53f, -4.16f, 0.0f), transform.rotation);
    }
    public void WasBitten()
    {
        if (outside)
        {
            Destroy(KeysTalk);
            if (Grandmaoutside) { KeysTalk = Instantiate(wasBitten, new Vector3(-5.53f, -4.16f, 0.0f), transform.rotation); }
            else if (gameObject.GetComponent<RememberThings>().BushStillActive())
            {
                LoadCollider = Instantiate(GrandmaHouseColiders, new Vector3(0.0f, 0.0f, 0.0f), transform.rotation);
            }
        }
    }
    public void GotTheKey()
    {
        if (outside)
        {
            Destroy(KeysTalk);
            gameObject.GetComponent<lugge>().GoldKeyPiece();
            gameObject.GetComponent<RememberThings>().FoundBushKey();
            
            if (Grandmaoutside) { KeysTalk = Instantiate(gatTheKey, new Vector3(-5.53f, -4.16f, 0.0f), transform.rotation); }
            
        }
        else
        {
            sofaSpider.SetActive(false);
            //Destroy(sofaSpider);
            gameObject.GetComponent<lugge>().AddSilverKey();
            gameObject.GetComponent<RememberThings>().SilverKeyFound();
        }
        
    }
    public void DestDiologgi()
    {
        if (Lostkeycreated != null) { Destroy(Lostkeycreated); }
    }
    public void CallGran()
    {
        oldLady.GetComponent<OldLady>().GoInsidehouse();
        plantsColi = Instantiate(PlantsDoorColider, new Vector3(0.0f,0.0f, 0.0f), transform.rotation);
    }
    public void TurnTime()
    {

        bigplants = true;
    }
    public void CleanUp()
    {
        if (KeysTalk != null) { Destroy(KeysTalk); }
        if (plantsColi != null) { Destroy(plantsColi); }
        if (sofaSpider != null) { Destroy(sofaSpider); }
        if (oldLady != null) { Destroy(oldLady); }
        if (oldMan != null) { Destroy(oldMan); }
    }

    public void LoadForrestSecond()
    {
        Destroy(CurrentLoad);
        CurrentLoad = Instantiate(ForrestSecond, GameObject.Find("MainGrid").transform);
        if (oldMan != null) { Destroy(oldMan); }
        if (plants != null) { Destroy(plants); }
        GameObject.FindWithTag("MainGrid").GetComponent<compa>().Falsedir();
        CrCut();
        Destroy(exi);
        GameObject.FindWithTag("Chara").GetComponent<MainCharacter>().NoMoveNow();

    }
    public void LoadSecondHouse()
    {
        gameObject.GetComponent<controllthese>().Exittt();
        Destroy(CurrentLoad);
        CurrentLoad = Instantiate(HouseLoan, GameObject.Find("MainGrid").transform);
        if (boyexi)
        {
            GameObject.FindWithTag("boy").GetComponent<boyControll>().HideAway();
        }
        if (gameObject.GetComponent<secLdialog>().isalldone())
        {
            //girl reapear
        }
        if (creEnder) { exittyty = Instantiate(coliEnd, GameObject.Find("MainGrid").transform); Debug.Log(creEnder); }
        gameObject.GetComponent<LastBitController>().ForrestMus();
        Debug.Log(creEnder);
    }
    public void CreateGirl()
    {
        girl = Instantiate(Girl, new Vector3(-2.9f, -2.364573f, 0.0f), transform.rotation);
    }
    public void LoadInsideSecondHouse()
    {
        gameObject.GetComponent<controllthese>().Exittt();
        Destroy(CurrentLoad);
        CurrentLoad = Instantiate(FirstFloor, GameObject.Find("MainGrid").transform);
        gameObject.GetComponent<controllthese>().plaseFoody();
        gameObject.GetComponent<controllthese>().plaseSee();
        gameObject.GetComponent<secLdialog>().stSomething();
        if (boyexi)
        {
            GameObject.FindWithTag("boy").GetComponent<boyControll>().SitOnSofa();
        }
        gameObject.GetComponent<LastBitController>().ForrestMus();
    }
    public void CreateBoy()
    {
        boy = Instantiate(Boy, new Vector3(1.44f, 1.83f, 0.0f), transform.rotation);
        boyexi = true;
    }
    public void LoadLobbie()
    {
        gameObject.GetComponent<controllthese>().Exittt();
        Destroy(CurrentLoad);
        CurrentLoad = Instantiate(Lobbie, GameObject.Find("MainGrid").transform);
        GameObject.FindWithTag("boy").GetComponent<boyControll>().HideAway();
        gameObject.GetComponent<hideANDseek>().Desi();
    }
    public void LoadBathroom()
    {
        gameObject.GetComponent<controllthese>().Exittt();
        Destroy(CurrentLoad);
        CurrentLoad = Instantiate(Bathroom, GameObject.Find("MainGrid").transform);
    }
    public void LoadChildRoom()
    {
        gameObject.GetComponent<controllthese>().Exittt();
        Destroy(CurrentLoad);
        CurrentLoad = Instantiate(ChildBedroom, GameObject.Find("MainGrid").transform);
        gameObject.GetComponent<controllthese>().plaseSay();
        GameObject.FindWithTag("boy").GetComponent<boyControll>().SitHomework();
        GameObject.FindWithTag("boy").GetComponent<boyControll>().InBedb();
        GameObject.FindWithTag("boy").GetComponent<boyControll>().stillsleep();
        gameObject.GetComponent<hideANDseek>().HideNow(1);
    }
    public void LoadMomRoom()
    {
        gameObject.GetComponent<controllthese>().Exittt();
        Destroy(CurrentLoad);
        CurrentLoad = Instantiate(MasterBedroom, GameObject.Find("MainGrid").transform);
        gameObject.GetComponent<controllthese>().plaseHear();
        gameObject.GetComponent<hideANDseek>().HideNow(2);
    }
    public void LoadPreCenter()
    {
        Destroy(CurrentLoad);
        Debug.Log("center");
        CurrentLoad = Instantiate(BasementFail, GameObject.Find("MainGrid").transform);
    }
    public void LoadCenter()
    {
        Destroy(CurrentLoad);
        CurrentLoad = Instantiate(BasementCenter, GameObject.Find("MainGrid").transform);
        if (GameObject.FindWithTag("boy").GetComponent<boyControll>().know())
        {
            GameObject.FindWithTag("mannager").GetComponent<secLdialog>().place_notJohn();
        }
        else { GameObject.FindWithTag("mannager").GetComponent<secLdialog>().place_John(); }
    }
    public void LoadDiamond()
    {
        Debug.Log("diamond");
        Destroy(CurrentLoad);
        CurrentLoad = Instantiate(BasementDiamond, GameObject.Find("MainGrid").transform);
    }
    public void LoadHeart()
    {
        Debug.Log("LoadHeart");
        Destroy(CurrentLoad);
        CurrentLoad = Instantiate(BasementHeart, GameObject.Find("MainGrid").transform);
    }
    public void LoadCloves()
    {
        Debug.Log("LoadCloves");
        Destroy(CurrentLoad);
        CurrentLoad = Instantiate(BasementCloves, GameObject.Find("MainGrid").transform);
    }
    public void LoadPickes()
    {
        Debug.Log("LoadPickes");
        Destroy(CurrentLoad);
        CurrentLoad = Instantiate(BasementPickes, GameObject.Find("MainGrid").transform);
    }
    public void CreateShynks()
    {
        sphynks = Instantiate(Sphynks, new Vector3(-0.22f, 0.36f, 0.0f), transform.rotation);
        GameObject.FindWithTag("Chara").GetComponent<MainCharacter>().NoMoveNow();
    }
    public void CreateArlekin()
    {
        arlekin = Instantiate(Arlekin, new Vector3(-0.11f, 0.35f, 0.0f), transform.rotation);
        GameObject.FindWithTag("Chara").GetComponent<MainCharacter>().NoMoveNow();
    }
    public void PsyGo()
    {
        sphynks.GetComponent<psynk>().Deathh();
    }
    public void Blinking()
    {
        Debug.Log("onooff");
        blacscr = Instantiate(Blacscr, GameObject.Find("MainGrid").transform);
        StartCoroutine(WaitA(0.5f));
    }
    public void BlackscrR()
    {
        blacscr = Instantiate(Blacscr, GameObject.Find("MainGrid").transform);
        StartCoroutine(WaitAA(3.5f));
    }
    public void BlackscrRR()
    {
        blacscr = Instantiate(Blacscr, GameObject.Find("MainGrid").transform);
        StartCoroutine(WaitAA(0.5f));
    }
    private IEnumerator WaitAA(float duration)
    {
        yield return new WaitForSeconds(duration);
        Destroy(blacscr);
        LoadSecondHouse();
        GameObject.FindWithTag("Chara").GetComponent<MainCharacter>().MoveAway(1f, 1.84f);
        GameObject.FindWithTag("girl").GetComponent<girlControll>().GirMove(20f, 20f);
        Destroy(mam);
    }
    public void del_Arli() { Destroy(arlekin); GameObject.FindWithTag("Chara").GetComponent<MainCharacter>().CanMoveNow(); }
    public void del_Shy() { Destroy(sphynks); }
    public void del_blacky() { Destroy(blacscr); }

    private IEnumerator WaitA(float duration)
    {
        Debug.Log("onooff");
        for(int i = 0; i < 20; i++)
        {
            yield return new WaitForSeconds(0.2f-i*0.01f);
            blacscr.SetActive(false);
            yield return new WaitForSeconds(0.1f);
            blacscr.SetActive(true);
        }
        //Destroy(blacscr);
        //load room
    }
    public void createMa()
    {
        mam = Instantiate(MaSit, GameObject.Find("MainGrid").transform);
    }
    public void createMaNorm()
    {
        Destroy(mam);
        mam = Instantiate(MaWalk, new Vector3(1.44f, 1.83f, 0.0f), transform.rotation);
    }
}
// Lostkeycreated - used in the bush interactions