using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lugge : MonoBehaviour
{
    [SerializeField] private GameObject Luggage;
    [SerializeField] private GameObject Compass;
    [SerializeField] private GameObject HighLight;
    private List<GameObject> Possesions = new List<GameObject>();
    private bool ISopen;
    private int IndexLast;
    private float HIPos;

    private GameObject compass;

    [SerializeField] private GameObject Album;
    private GameObject album;
    private bool Has_Album = false;
    [SerializeField] private GameObject One_GKey;
    [SerializeField] private GameObject Two_GKey;
    [SerializeField] private GameObject Three_GKey;
    [SerializeField] private GameObject Complete_GKey;
    private GameObject GoldKey;
    private int GoldKeyCounter;

    [SerializeField] private GameObject Vewspsper;
    private GameObject vewspsper;

    [SerializeField] private GameObject SilverKey;
    private GameObject silverKey;

    [SerializeField] private GameObject Kettle;
    private GameObject kettle;

    [SerializeField] private GameObject TeaCups;
    private GameObject teaCups;

    [SerializeField] private GameObject Tea_Artemisia;
    [SerializeField] private GameObject Tea_Beladonna;
    [SerializeField] private GameObject Tea_Lupinos;
    [SerializeField] private GameObject Tea_Chamomile;
    private GameObject tea;

    [SerializeField] private GameObject SpiderLotiion;
    private GameObject spiderLotiion = null;

    [SerializeField] private GameObject TomatoesAndLattice;
    private GameObject tomatoes = null;

    [SerializeField] private GameObject Salatbowl;
    private GameObject salatbowl;

    private bool Has_Veg;
    private bool Has_Loti;
    private bool kettleEmpty = true;
    private bool GoodTea ;
    private bool HasNewsOrAlbum = false;
    private bool AlbumhasbeenUsed = false;

    [SerializeField] GameObject FoundBothhh;
    private GameObject DioPlace;

    [SerializeField] private GameObject Icard;
    [SerializeField] private GameObject IIcard;
    [SerializeField] private GameObject IIIcard;
    [SerializeField] private GameObject IVcard;
    [SerializeField] private GameObject Vcard;
    [SerializeField] private GameObject VIicard;
    [SerializeField] private GameObject Tasks;
    [SerializeField] private GameObject Codes;
    [SerializeField] private GameObject FrozenFood;
    [SerializeField] private GameObject ReadyFood;
    [SerializeField] private GameObject Knife;
    [SerializeField] private GameObject Buble;
    [SerializeField] private GameObject DRI;
    [SerializeField] private GameObject DRII;
    [SerializeField] private GameObject DRIII;
    [SerializeField] private GameObject DRIV;
    [SerializeField] private GameObject Bible;
    private GameObject cards;
    private GameObject fooD;
    private GameObject tasks;
    private GameObject codes;
    private GameObject knife;
    private GameObject buble;
    private GameObject drI;
    private GameObject drII;
    private GameObject drIII;
    private GameObject drIV;
    private GameObject bible;
    private int cardCounter = 0;
    private bool Has_knife = false;
    private bool Has_frozenfood = false;
    private bool Has_readyfood = false;
    private bool foodINstove = false;
    private bool has_tasks = false;

    [SerializeField] private GameObject PicI;
    private GameObject picI;
    [SerializeField] private GameObject PicII;
    private GameObject picII;
    [SerializeField] private GameObject PicIII;
    private GameObject picIII;
    [SerializeField] private GameObject PicIV;
    private GameObject picIV;
    private int pic_count = 0;

    [SerializeField] private GameObject Compasdown;
    private GameObject compasdown;

    int levle = 0;
    // Start is called before the first frame update
    void Start()
    {
        Luggage.SetActive(false);
        ISopen = false;
        IndexLast = 0;
        HIPos = 0.3f;
        GoldKeyCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (IndexLast > 0)
        {
            if(Possesions[IndexLast-1]== compass){
            }
        }
        if (Input.GetKeyDown(KeyCode.Q)&& !ISopen)
        {
            OpenUp();
        }
        else if(Input.GetKeyDown(KeyCode.Q) && ISopen)
        {
            Luggage.SetActive(false);
            ISopen = false;
        }

        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (ISopen)
            {
                if (HIPos < 1.0f) { HIPos += 13.0f; }
                HighLight.transform.position = new Vector3(HIPos -= 1.0f, -0.24f, 0.0f);
            }
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (ISopen)
            {
                if (HIPos > 13.0f) { HIPos -= 13.0f; }
                HighLight.transform.position = new Vector3(HIPos += 1.0f, -0.24f, 0.0f);
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Usee();
        }
        if (HasNewsOrAlbum&& Has_Album && !GameObject.FindWithTag("Chara").GetComponent<MainCharacter>().isIteratorSpeaking())
        {
            HasNewsOrAlbum = false;
            FoundBoth();
        }
    }
    public void FoundBoth()
    {
        DioPlace = Instantiate(FoundBothhh, new Vector3(0.0f, 0.0f, 0.0f), transform.rotation);
    }
    public void DelFoundBoth()
    {
        Destroy(DioPlace);
    }
    public void AddCompas()
    {
        OpenUp();
        compass = Instantiate(Compass, GameObject.Find("Luggage").transform);
        compasdown = Instantiate(Compasdown, GameObject.Find("Luggage").transform);
        Possesions.Add(compass);
        Possesions[IndexLast].transform.position = new Vector3(0.3f, -0.24f, 0.0f);
        IndexLast++;
        Debug.Log("IndexLast " + IndexLast);
    }



    public void AddAlbum()
    {
        OpenUp();
        album = Instantiate(Album, GameObject.Find("Luggage").transform);
        Possesions.Add(album);
        
        Possesions[IndexLast].transform.position = new Vector3(CoutFreePose(), -0.24f, 0.0f);
        IndexLast++;
        Has_Album = true;
        
    }
    public bool Ret_tas() { return has_tasks; }
    public void GoldKeyPiece()
    {
        OpenUp();
        if(GoldKeyCounter==0)
        {
            GoldKey = Instantiate(One_GKey, GameObject.Find("Luggage").transform);
            Possesions.Add(GoldKey);
            Possesions[IndexLast].transform.position = new Vector3(CoutFreePose(), -0.24f, 0.0f);
            IndexLast++;
            GoldKeyCounter++;
            Debug.Log(GoldKeyCounter);
            Debug.Log("IndexLast " + IndexLast);
        }
        else if (GoldKeyCounter == 1)
        {
            
            int mm = Convert.ToInt32(GoldKey.transform.position.x);
            Possesions.Remove(GoldKey);
            Destroy(GoldKey);
            IndexLast--;
            MoveStuff(mm);
            GoldKey = Instantiate(Two_GKey, GameObject.Find("Luggage").transform);
            Possesions.Add(GoldKey);
            Possesions[IndexLast].transform.position = new Vector3(CoutFreePose(), -0.24f, 0.0f);
            IndexLast++;
            Debug.Log(GoldKeyCounter);
            GoldKeyCounter++;
        }
        else if (GoldKeyCounter == 2)
        {
            int mm = Convert.ToInt32(GoldKey.transform.position.x);
            Possesions.Remove(GoldKey);
            Destroy(GoldKey);
            IndexLast--;
            MoveStuff(mm);
            GoldKey = Instantiate(Three_GKey, GameObject.Find("Luggage").transform);
            Possesions.Add(GoldKey);
            Possesions[IndexLast].transform.position = new Vector3(CoutFreePose(), -0.24f, 0.0f);
            IndexLast++;
            GoldKeyCounter++;

        }
        else if (GoldKeyCounter == 3)
        {
            int mm = Convert.ToInt32(GoldKey.transform.position.x);
            Possesions.Remove(GoldKey);
            Destroy(GoldKey);
            IndexLast--;
            MoveStuff(mm);
            GoldKey = Instantiate(Complete_GKey, GameObject.Find("Luggage").transform);
            Possesions.Add(GoldKey);
            Possesions[IndexLast].transform.position = new Vector3(CoutFreePose(), -0.24f, 0.0f);
            IndexLast++;
            GoldKeyCounter++;

        }
        Debug.Log(GoldKeyCounter);
    }

    public void AddNewspaper()
    {
        OpenUp();
        vewspsper = Instantiate(Vewspsper, GameObject.Find("Luggage").transform);
        Possesions.Add(vewspsper);

        Possesions[IndexLast].transform.position = new Vector3(CoutFreePose(), -0.24f, 0.0f);
        IndexLast++;
        HasNewsOrAlbum = true;
    }
   public bool hasBothIsIt()
    {
        return HasNewsOrAlbum;
    }
    
    public void AddSilverKey()
    {
        OpenUp();
        silverKey = Instantiate(SilverKey, GameObject.Find("Luggage").transform);
        Possesions.Add(silverKey);

        Possesions[IndexLast].transform.position = new Vector3(CoutFreePose(), -0.24f, 0.0f);
        IndexLast++;
    }
   
    public void AddKattle()
    {
        OpenUp();
        kettle = Instantiate(Kettle, GameObject.Find("Luggage").transform);
        Possesions.Add(kettle);

        Possesions[IndexLast].transform.position = new Vector3(CoutFreePose(), -0.24f, 0.0f);
        IndexLast++;
    }

    public void AddCup()
    {
        OpenUp();
        teaCups = Instantiate(TeaCups, GameObject.Find("Luggage").transform);
        Possesions.Add(teaCups);

        Possesions[IndexLast].transform.position = new Vector3(CoutFreePose(), -0.24f, 0.0f);
        IndexLast++;
    }

    public void AddLoti()
    {
        if (!hasLoti())
        {
            OpenUp();
            spiderLotiion = Instantiate(SpiderLotiion, GameObject.Find("Luggage").transform);
            Possesions.Add(spiderLotiion);
            Possesions[IndexLast].transform.position = new Vector3(CoutFreePose(), -0.24f, 0.0f);
            IndexLast++;
            Has_Loti = true;
        }
    }

    public void AddSalatoe()
    {
        
        if (!hasVeg())
        {
            OpenUp();
            tomatoes = Instantiate(TomatoesAndLattice, GameObject.Find("Luggage").transform);
            Possesions.Add(tomatoes);

            Possesions[IndexLast].transform.position = new Vector3(CoutFreePose(), -0.24f, 0.0f);
            IndexLast++;
            Has_Veg = true;
        }
        
    }

    public void AddSalatbe()
    {
        OpenUp();
        salatbowl = Instantiate(Salatbowl, GameObject.Find("Luggage").transform);
        Possesions.Add(salatbowl);

        Possesions[IndexLast].transform.position = new Vector3(CoutFreePose(), -0.24f, 0.0f);
        IndexLast++;
    }

    public void AddTea(int ch)
    {
        OpenUp();
        switch (ch)
        {
            case 0:
                tea = Instantiate(Tea_Artemisia, GameObject.Find("Luggage").transform);
                GoodTea = true;
                break;
            case 1:
                tea = Instantiate(Tea_Beladonna, GameObject.Find("Luggage").transform);
                GoodTea = false;
                break;
            case 2:
                tea = Instantiate(Tea_Lupinos, GameObject.Find("Luggage").transform);
                GoodTea = false;
                break;
            case 3:
                tea = Instantiate(Tea_Chamomile, GameObject.Find("Luggage").transform);
                GoodTea = true;
                break;
            default:
                tea = Instantiate(Tea_Chamomile, GameObject.Find("Luggage").transform);
                GoodTea = true;
                break;
        }
        Possesions.Add(tea);

        Possesions[IndexLast].transform.position = new Vector3(CoutFreePose(), -0.24f, 0.0f);
        IndexLast++;
    }

    public float CoutFreePose()
    {
        return IndexLast + 0.3f;
    }

    private void OpenUp()
    {
        if (!ISopen)
        {
            Luggage.SetActive(true);
            ISopen = true;
            HIPos = 0.3f;
            HighLight.transform.position = new Vector3(HIPos, -0.24f, 0.0f);
        }
    }

    private void MoveStuff(int indee)
    {
        if (indee < IndexLast)
        {
            for (int i= indee; i < IndexLast; i++)
            {
                Possesions[i].transform.position = new Vector3(Possesions[i].transform.position.x - 1f, -0.24f, 0.0f);
            }
        }
    }
    public void Usee()
    {
        int inde = (int)HIPos;
        if (inde >= IndexLast)
        {
            Debug.Log("No no no");
            return;
        }
        if (Possesions[inde] == spiderLotiion)
        {
            Debug.Log("Lotion used");
            gameObject.GetComponent<RememberThings>().PoisonedStatus(false);
        }else if (Possesions[inde] == tomatoes)
        {
            Debug.Log("tomatoes used");
            if (GameObject.FindWithTag("Chara").GetComponent<MainCharacter>().RetOld()){
                GameObject.FindWithTag("insColider").GetComponent<insideroomControllers>().PlaceVeg();
                Possesions.Remove(tomatoes);
                Destroy(tomatoes);
                IndexLast--;
                MoveStuff( inde);
            }
        }
        else if (Possesions[inde] == kettle)
        {
            Debug.Log("kettle used");
            if (GameObject.FindWithTag("Chara").GetComponent<MainCharacter>().IsWaterZone()&&kettleEmpty)
            {
                GameObject.FindWithTag("insColider").GetComponent<insideroomControllers>().FillKettle();
                GameObject.FindWithTag("Chara").GetComponent<MainCharacter>().WaitS(2f);
                kettleEmpty = false;
            }
            if (GameObject.FindWithTag("Chara").GetComponent<MainCharacter>().IsStoveZone() && !kettleEmpty)
            {
                GameObject.FindWithTag("insColider").GetComponent<insideroomControllers>().StoveKettle();
                Possesions.Remove(kettle);
                Destroy(kettle);
                IndexLast--;
                MoveStuff(inde);
            }
            if (GameObject.FindWithTag("insColider").GetComponent<insideroomControllers>().CupsOn())
            {
                GameObject.FindWithTag("mannager").GetComponent<LastBitController>().PourMus();
                GameObject.FindWithTag("insColider").GetComponent<insideroomControllers>().CompleteTeaQ();
                Possesions.Remove(kettle);
                Destroy(kettle);
                IndexLast--;
                MoveStuff(inde);
            }
           

        }
        else if (Possesions[inde] == album)
        {
            Debug.Log("album used");
            if (GameObject.FindWithTag("Chara").GetComponent<MainCharacter>().RetOld())
            {
                AlbumhasbeenUsed = true;
                GameObject.FindWithTag("mannager").GetComponent<LastBitController>().AlbumGo();
                Possesions.Remove(album);
                Destroy(album);
                IndexLast--;
                MoveStuff(inde);
            }
        }
        else if (Possesions[inde] == vewspsper)
        {
            Debug.Log("vewspsper used");
            Debug.Log(GameObject.FindWithTag("Chara").GetComponent<MainCharacter>().RetOld());
            Debug.Log(AlbumhasbeenUsed);
            if (GameObject.FindWithTag("Chara").GetComponent<MainCharacter>().RetOld()&& AlbumhasbeenUsed)
            {
                GameObject.FindWithTag("mannager").GetComponent<LastBitController>().News();
                Possesions.Remove(vewspsper);
                Destroy(vewspsper);
                IndexLast--;
                MoveStuff(inde);
            }
        }
        else if (Possesions[inde] == teaCups)
        {
            Debug.Log("teaCups used");
            if (GameObject.FindWithTag("Chara").GetComponent<MainCharacter>().IsTableZone())
            {
                GameObject.FindWithTag("insColider").GetComponent<insideroomControllers>().PlaceCups();
                Possesions.Remove(teaCups);
                Destroy(teaCups);
                IndexLast--;
                MoveStuff(inde);
            }
        }
        else if (Possesions[inde] == tea)
        {
            Debug.Log("teaCups tea");
            if (GameObject.FindWithTag("Chara").GetComponent<MainCharacter>().IsStoveZone() && GameObject.FindWithTag("insColider").GetComponent<insideroomControllers>().retBoil())
            {
                GameObject.FindWithTag("insColider").GetComponent<insideroomControllers>().AddTeaa();

                Possesions.Remove(tea);
                Destroy(tea);
                IndexLast--;
                MoveStuff(inde);
            }
        }
        else if (Possesions[inde] == salatbowl)
        {
            Debug.Log("salatbowl tea");
            if (GameObject.FindWithTag("Chara").GetComponent<MainCharacter>().IsTableZone())
            {
                GameObject.FindWithTag("insColider").GetComponent<insideroomControllers>().PlaceSatalB();

                Possesions.Remove(salatbowl);
                Destroy(salatbowl);
                IndexLast--;
                MoveStuff(inde);
            }
        }
        else if (Possesions[inde] == GoldKey && GoldKeyCounter==4)
        {
            Debug.Log("GoldKey tea");
            
            Possesions.Remove(GoldKey);
            Destroy(GoldKey);
            IndexLast--;
            MoveStuff(inde);
            GoldKeyCounter = 0;

            if (levle == 0)
            {
                GameObject.FindWithTag("mannager").GetComponent<LastBitController>().ComppasActive();
                if (silverKey != null)
                {
                    Possesions.Remove(silverKey);
                    Destroy(silverKey);
                    IndexLast--;
                    MoveStuff(inde);
                }
                if (album != null)
                {
                    Possesions.Remove(album);
                    Destroy(album);
                    IndexLast--;
                    MoveStuff(inde);
                }
                if (vewspsper != null)
                {
                    Possesions.Remove(vewspsper);
                    Destroy(vewspsper);
                    IndexLast--;
                    MoveStuff(inde);
                }
                if (spiderLotiion != null)
                {
                    Possesions.Remove(spiderLotiion);
                    Destroy(spiderLotiion);
                    IndexLast--;
                    MoveStuff(inde);
                }
                GameObject.FindWithTag("MainGrid").GetComponent<compa>().Truedir();
            }else if (levle == 1)
            {
                //activ dio   change comp   
                GameObject.FindWithTag("mannager").GetComponent<sceneManager>().CrEnderColi();
                GameObject.FindWithTag("MainGrid").GetComponent<compa>().Truedir();
                GameObject.FindWithTag("mannager").GetComponent<secLdialog>().CompaUsedAg();
            }
            levle++;

        }
        else if (Possesions[inde] == tasks)
        {
            Debug.Log("tasks");
            if (!GameObject.FindWithTag("Chara").GetComponent<MainCharacter>().isIteratorSpeaking())
            {
                GameObject.FindWithTag("mannager").GetComponent<secLdialog>().Tascs();
            }
        }
        else if (Possesions[inde] == fooD)
        {
            Debug.Log("fooD");
            if (GameObject.FindWithTag("Chara").GetComponent<MainCharacter>().IsStoveZone2() && Has_frozenfood)
            {
                Has_frozenfood = false;
                foodINstove = true;
                Possesions.Remove(fooD);
                Destroy(fooD);
                IndexLast--;
                MoveStuff(inde);
            }
            if (GameObject.FindWithTag("Chara").GetComponent<MainCharacter>().IsTableZone() && Has_readyfood)
            {
                Has_readyfood = false;
                Possesions.Remove(fooD);
                Destroy(fooD);
                IndexLast--;
                MoveStuff(inde);
                GameObject.FindWithTag("mannager").GetComponent<secLdialog>().goeattt();
                GameObject.FindWithTag("mannager").GetComponent<controllthese>().FirstplaseFoody();
                
            }
        }
        else if (Possesions[inde] == codes)
        {
            Debug.Log("codes");
            if (!GameObject.FindWithTag("Chara").GetComponent<MainCharacter>().isIteratorSpeaking())
            {
                GameObject.FindWithTag("mannager").GetComponent<secLdialog>().Placecodes();
            }
        }
        else if (Possesions[inde] == buble)
        {
            Debug.Log("buble");
            if (GameObject.FindWithTag("Chara").GetComponent<MainCharacter>().IsBathZone())
            {
                GameObject.FindWithTag("mannager").GetComponent<controllthese>().PourWater();
                GameObject.FindWithTag("boy").GetComponent<boyControll>().fillbath();
                GameObject.FindWithTag("mannager").GetComponent<secLdialog>().bathTrue();
                
                Possesions.Remove(buble);
                Destroy(buble);
                IndexLast--;
                MoveStuff(inde);
            }
        }
        else if (Possesions[inde] == bible)
        {
            Debug.Log("bible");
            if (GameObject.FindWithTag("Chara").GetComponent<MainCharacter>().IsBedZone())
            {
                GameObject.FindWithTag("mannager").GetComponent<secLdialog>().placebible();
                GameObject.FindWithTag("mannager").GetComponent<secLdialog>().slepTrue();
                Possesions.Remove(bible);
                Destroy(bible);
                IndexLast--;
                MoveStuff(inde);
            }
        }
        else if (Possesions[inde] == knife)
        {
            Debug.Log("knife");
            if (GameObject.FindWithTag("Chara").GetComponent<MainCharacter>().IsSee())
            {
                GameObject.FindWithTag("mannager").GetComponent<controllthese>().killsee();
                GameObject.FindWithTag("mannager").GetComponent<secLdialog>().tearBear();

            }else if(GameObject.FindWithTag("Chara").GetComponent<MainCharacter>().IsHear())
            {
                GameObject.FindWithTag("mannager").GetComponent<controllthese>().killhear();
                GameObject.FindWithTag("mannager").GetComponent<secLdialog>().tearBear();
            }
            else if (GameObject.FindWithTag("Chara").GetComponent<MainCharacter>().IsSpeak())
            {
                GameObject.FindWithTag("mannager").GetComponent<controllthese>().killsay();
                GameObject.FindWithTag("mannager").GetComponent<secLdialog>().tearBear();
            }
        }
        else if (Possesions[inde] == cards)
        {
            Debug.Log("cards");
            if (!GameObject.FindWithTag("Chara").GetComponent<MainCharacter>().isIteratorSpeaking())
            {
                switch (cardCounter)
                {
                    case 1:
                        GameObject.FindWithTag("mannager").GetComponent<secLdialog>().plIcard();
                        break;
                    case 2:
                        GameObject.FindWithTag("mannager").GetComponent<secLdialog>().plIIcard();
                        break;
                    case 3:
                        GameObject.FindWithTag("mannager").GetComponent<secLdialog>().plIIIcard();
                        break;
                    case 4:
                        GameObject.FindWithTag("mannager").GetComponent<secLdialog>().plIVcard();
                        break;
                    case 5:
                        GameObject.FindWithTag("mannager").GetComponent<secLdialog>().plVcard();
                        break;
                    case 6:
                        GameObject.FindWithTag("mannager").GetComponent<secLdialog>().plVIcard();
                        break;
                    default:
                        Debug.Log("Unknown");
                        break;
                }
            }
        }
        else
        {
            Debug.Log("Noting");
        }
    }
    public bool IsFoodCooki() { return foodINstove; }
    public void notFoodCooki() {  foodINstove = false; }

    public bool IsItOpen()
    {
        return ISopen;
    }

    public bool hasLoti()
    {
        return Has_Loti;
    }
    public bool hasVeg()
    {
        return Has_Veg;
    }
    public bool hasTea()
    {
        Debug.Log("the tea was " + GoodTea);
        return GoodTea;
    }




    public void AddTasks()
    {
        OpenUp();
        tasks = Instantiate(Tasks, GameObject.Find("Luggage").transform);
        Possesions.Add(tasks);
        GoldKeyCounter = 0;
        Possesions[IndexLast].transform.position = new Vector3(CoutFreePose(), -0.24f, 0.0f);
        IndexLast++;
        has_tasks = true;
    }
    public void AddCodes()
    {
        //OpenUp();
        codes = Instantiate(Codes, GameObject.Find("Luggage").transform);
        Possesions.Add(codes);

        Possesions[IndexLast].transform.position = new Vector3(CoutFreePose(), -0.24f, 0.0f);
        IndexLast++;

    }
    public void AddKnife()
    {
        OpenUp();
        knife = Instantiate(Knife, GameObject.Find("Luggage").transform);
        Possesions.Add(knife);
        GameObject.FindWithTag("mannager").GetComponent<controllthese>().use_knife();

        Possesions[IndexLast].transform.position = new Vector3(CoutFreePose(), -0.24f, 0.0f);
        IndexLast++;
        
        Has_knife = true;
    }
    public void AddFrozenFood()
    {
        OpenUp();
        fooD = Instantiate(FrozenFood, GameObject.Find("Luggage").transform);
        Possesions.Add(fooD);
        GameObject.FindWithTag("mannager").GetComponent<controllthese>().use_food();

        Possesions[IndexLast].transform.position = new Vector3(CoutFreePose(), -0.24f, 0.0f);
        IndexLast++;
        Has_frozenfood = true;
    }
    public void AddReadyFood()
    {
        if (!Has_readyfood)
        {
            OpenUp();
            fooD = Instantiate(ReadyFood, GameObject.Find("Luggage").transform);
            Possesions.Add(fooD);
            GameObject.FindWithTag("mannager").GetComponent<controllthese>().use_stove();

            Possesions[IndexLast].transform.position = new Vector3(CoutFreePose(), -0.24f, 0.0f);
            IndexLast++;
            Has_readyfood = true;
        }
        
    }
    public void AddBuble()
    {
        OpenUp();
        buble = Instantiate(Buble, GameObject.Find("Luggage").transform);
        Possesions.Add(buble);
        GameObject.FindWithTag("mannager").GetComponent<controllthese>().use_cabinet();
        GameObject.FindWithTag("ba").GetComponent<bathroom>().bathhh();

        Possesions[IndexLast].transform.position = new Vector3(CoutFreePose(), -0.24f, 0.0f);
        IndexLast++;
    }
    //public void AdddrI()
    //{
    //    OpenUp();
    //    drI = Instantiate(DRI, GameObject.Find("Luggage").transform);
    //    Possesions.Add(drI);

    //    Possesions[IndexLast].transform.position = new Vector3(CoutFreePose(), -0.24f, 0.0f);
    //    IndexLast++;
    //}
    //public void AdddrII()
    //{
    //    OpenUp();
    //    drII = Instantiate(DRII, GameObject.Find("Luggage").transform);
    //    Possesions.Add(drII);

    //    Possesions[IndexLast].transform.position = new Vector3(CoutFreePose(), -0.24f, 0.0f);
    //    IndexLast++;
    //}
    //public void AdddrIII()
    //{
    //    OpenUp();
    //    drIII = Instantiate(DRIII, GameObject.Find("Luggage").transform);
    //    Possesions.Add(drIII);

    //    Possesions[IndexLast].transform.position = new Vector3(CoutFreePose(), -0.24f, 0.0f);
    //    IndexLast++;
    //}
    //public void AdddrIV()
    //{
    //    OpenUp();
    //    drIV = Instantiate(DRIV, GameObject.Find("Luggage").transform);
    //    Possesions.Add(drIV);

    //    Possesions[IndexLast].transform.position = new Vector3(CoutFreePose(), -0.24f, 0.0f);
    //    IndexLast++;
    //    GameObject.FindWithTag("mannager").GetComponent<secLdialog>().NoLongoChoise();
    //}
    public void AdddBible()
    {
        bible = Instantiate(Bible, GameObject.Find("Luggage").transform);
        Possesions.Add(bible);
        GameObject.FindWithTag("mannager").GetComponent<controllthese>().use_books();

        Possesions[IndexLast].transform.position = new Vector3(CoutFreePose(), -0.24f, 0.0f);
        IndexLast++;
    }
    public void Add_Pic()
    {
        OpenUp();
        switch (pic_count)
        {
            case 0:
                picI = Instantiate(PicI, GameObject.Find("Luggage").transform);
                Possesions.Add(picI);
                break;
            case 1:
                picII = Instantiate(PicII, GameObject.Find("Luggage").transform);
                Possesions.Add(picII);
                break;
            case 2:
                picIII = Instantiate(PicIII, GameObject.Find("Luggage").transform);
                Possesions.Add(picIII);
                break;
            case 3:
                picIV = Instantiate(PicIV, GameObject.Find("Luggage").transform);
                Possesions.Add(picIV);
                GameObject.FindWithTag("mannager").GetComponent<secLdialog>().NoLongoChoise();
                break;
        }
        pic_count++;
        Possesions[IndexLast].transform.position = new Vector3(CoutFreePose(), -0.24f, 0.0f);
        IndexLast++;
    }
    public void CardsPiece()
    {
        OpenUp();
        if (cardCounter == 0)
        {
            cards = Instantiate(Icard, GameObject.Find("Luggage").transform);
            Possesions.Add(cards);
            Possesions[IndexLast].transform.position = new Vector3(CoutFreePose(), -0.24f, 0.0f);
            IndexLast++;
            cardCounter++;
            Debug.Log("IndexLast " + IndexLast);
        }
        else if (cardCounter > 0)
        {
            int mm = Convert.ToInt32(cards.transform.position.x);
            Possesions.Remove(cards);
            Destroy(cards);
            IndexLast--;
            MoveStuff(mm);
            if(cardCounter == 1) { cards = Instantiate(IIcard, GameObject.Find("Luggage").transform); }
            else if (cardCounter == 2) { cards = Instantiate(IIIcard, GameObject.Find("Luggage").transform); }
            else if (cardCounter == 3) { cards = Instantiate(IVcard, GameObject.Find("Luggage").transform); }
            else if (cardCounter == 4) { cards = Instantiate(Vcard, GameObject.Find("Luggage").transform); }
            else if (cardCounter == 5) { cards = Instantiate(VIicard, GameObject.Find("Luggage").transform); }
            Possesions.Add(cards);
            Possesions[IndexLast].transform.position = new Vector3(CoutFreePose(), -0.24f, 0.0f);
            IndexLast++;
            cardCounter++;
        }
    }
}
