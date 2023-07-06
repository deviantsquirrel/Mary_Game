using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastBitController : MonoBehaviour
{
    [SerializeField] GameObject StatrterTalk;
    [SerializeField] GameObject Explainer;
    [SerializeField] GameObject OneWon;
    [SerializeField] GameObject OneLost;
    [SerializeField] GameObject LL;
    [SerializeField] GameObject WW;
    [SerializeField] GameObject WL;
    [SerializeField] GameObject LW;
    [SerializeField] GameObject GoodTea;
    [SerializeField] GameObject BadTea;
    [SerializeField] GameObject LLL;
    [SerializeField] GameObject WWW;
    [SerializeField] GameObject WWL;
    [SerializeField] GameObject LLW;
    [SerializeField] GameObject Answer;


    [SerializeField] GameObject Sam;
    [SerializeField] GameObject noSam;
    [SerializeField] GameObject DoorIntSimp;
    private GameObject DoorPlace;
    private GameObject AnyMPlace;
    [SerializeField] GameObject AnyMin;
    //[SerializeField] GameObject GettingSleepy; //Amin yeld return bool thingy 
    [SerializeField] GameObject UseAlbumNoGrandk;
    [SerializeField] GameObject UseNewspaper;
    private GameObject DioPlace;
    [SerializeField] GameObject Grann;
    [SerializeField] GameObject DeathTalk;
    [SerializeField] GameObject SleepTalk;
    [SerializeField] GameObject CompasActiv;
    private GameObject grann;
    private bool First;
    private bool Second;
    private bool Third;
    private bool compasUsed = false;
    int round = 0;

    bool knowsSam = false;

    [SerializeField] AudioSource ambient;
    [SerializeField] AudioSource effect;

    [SerializeField] AudioClip forrst;
    [SerializeField] AudioClip house;
    [SerializeField] AudioClip cheakers;
    //[SerializeField] AudioClip spiderr;
    //[SerializeField] AudioClip nervous;

    [SerializeField] GameObject waterOn;//
    [SerializeField] GameObject cattleOn;//
    [SerializeField] AudioClip putkettle;//cups
    [SerializeField] AudioClip fillcups;
    private GameObject sinkk;
    private GameObject boill;
    //bool singOn = true;
    // Start is called before the first frame update
    void Start()
    {
        ForrestMus();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ForrestMus(){  ambient.clip = forrst; }
    public void HouseMus() { ambient.clip = house;  }
    public void CheakersMus() { ambient.Stop(); ambient.clip = cheakers; }
    public void PlateMus() { effect.PlayOneShot(putkettle); }
    public void PourMus() { effect.PlayOneShot(fillcups); }
    public void SinkMus() { sinkk = Instantiate(waterOn, new Vector3(2.34f, -0.71f, 0.0f), transform.rotation); }
    public void BoilMus() { boill = Instantiate(cattleOn, new Vector3(2.34f, -0.71f, 0.0f), transform.rotation); }
    public void Del_SinkMus() { if (sinkk != null) { Destroy(sinkk); } }
    public void Del_BoilMus() { Destroy(boill); }

    public void SitTable()
    {
        StartCoroutine(Wawa());
    }

    IEnumerator Wawa()
    {
        yield return new WaitForSeconds(3f);
        Debug.Log("waited");
        StaryDoil();
    }
    void StaryDoil()
    {
        Destroy(DioPlace);
        DioPlace = Instantiate(StatrterTalk, new Vector3(2.34f, -0.71f, 0.0f), transform.rotation);
    }

    public void Explain()//call outside
    {
        Destroy(DioPlace);
        DioPlace = Instantiate(Explainer, new Vector3(2.34f, -0.71f, 0.0f), transform.rotation);
    }

    //scrip for child had starter foer game
    //cheakers pass the stat here

    public void statsS(bool res)
    {
        round++;
        if (round == 1) { First = res; StartOne(res); }
        else if (round == 2) { Second = res; StartTwo(res); }
        else if (round == 3) { Third = res; StartThree(res); }
    }
    private void StartOne(bool res)
    {
        Destroy(DioPlace);
        if (res) {
            DioPlace = Instantiate(OneWon, new Vector3(2.34f, -0.71f, 0.0f), transform.rotation);
        }
        else
        {
            DioPlace = Instantiate(OneLost, new Vector3(2.34f, -0.71f, 0.0f), transform.rotation);
        }
    }
    private void StartTwo(bool res)
    {
        Destroy(DioPlace);
        if (res && First)
        {
            DioPlace = Instantiate(WW, new Vector3(2.34f, -0.71f, 0.0f), transform.rotation);
        }
        else if (!res && !First)
        {
            DioPlace = Instantiate(LL, new Vector3(2.34f, -0.71f, 0.0f), transform.rotation);
        }
        else if (res && !First)
        {
            DioPlace = Instantiate(LW, new Vector3(2.34f, -0.71f, 0.0f), transform.rotation);
        }
        else if (!res && First)
        {
            DioPlace = Instantiate(WL, new Vector3(2.34f, -0.71f, 0.0f), transform.rotation);
        }
    }
    private void StartThree(bool res)
    {
        Destroy(DioPlace);
        if (res && First && Second)
        {
            DioPlace = Instantiate(WWW, new Vector3(2.34f, -0.71f, 0.0f), transform.rotation);
        }
        else if (!res && !First && !Second)
        {
            DioPlace = Instantiate(LLL, new Vector3(2.34f, -0.71f, 0.0f), transform.rotation);
        }
        else if (res)
        {
            DioPlace = Instantiate(LLW, new Vector3(2.34f, -0.71f, 0.0f), transform.rotation);
        }
        else if (!res)
        {
            DioPlace = Instantiate(WWL, new Vector3(2.34f, -0.71f, 0.0f), transform.rotation);
        }
    }
    public void SayBey()//good bad tea
    {
        Destroy(DioPlace);
        if (GameObject.FindWithTag("mannager").GetComponent<lugge>().hasTea())
        {
            DioPlace = Instantiate(GoodTea, new Vector3(2.34f, -0.71f, 0.0f), transform.rotation);
        }
        else
        {
            DioPlace = Instantiate(BadTea, new Vector3(2.34f, -0.71f, 0.0f), transform.rotation);
        }
    }
    public void AswerWWW()
    {
        Destroy(DioPlace);
        DioPlace = Instantiate(Answer, new Vector3(2.34f, -0.71f, 0.0f), transform.rotation);
    }
    public void GrandBacl()
    {
        Destroy(DioPlace);
        if(!First&&!Second&&!Third)
        {
            DioPlace = Instantiate(noSam, new Vector3(2.34f, -0.71f, 0.0f), transform.rotation);
        }
        else { DioPlace = Instantiate(Sam, new Vector3(2.34f, -0.71f, 0.0f), transform.rotation); }
        DoorPlace = Instantiate(DoorIntSimp, new Vector3(-0.06f, -3.63f, 0.0f), transform.rotation);
        AnyMPlace = Instantiate(AnyMin, new Vector3(3.5f, -0.71f, 0.0f), transform.rotation);
        
    }
       public void SamOver()
    {
        if (DioPlace != null) { Destroy(DioPlace); }
    }
    public void AlbumGo()
    {
        cleanDi();
        //Destroy(DioPlace);
        DioPlace = Instantiate(UseAlbumNoGrandk, new Vector3(2.34f, -0.71f, 0.0f), transform.rotation);
    }
    public void News()
    {
        //Destroy(DioPlace);
        cleanDi();
        DioPlace = Instantiate(UseNewspaper, new Vector3(2.34f, -0.71f, 0.0f), transform.rotation);
    }
    public void CreateGran()
    {
        grann = Instantiate(Grann, new Vector3(-2.06f, 5.8f, 0.0f), transform.rotation);
    }

    public void hideBody()
    {
        grann.SetActive(false);
        Debug.Log("Hide");
    }
    public void showBody()
    {
        grann.SetActive(true);
    }
    public void DeathDiol()
    {
        cleanDi();
        DioPlace = Instantiate(DeathTalk, new Vector3(2.34f, -0.71f, 0.0f), transform.rotation);
        GameObject.FindWithTag("Chara").GetComponent<MainCharacter>().SetEnding();
        Destroy(DoorPlace);
        Destroy(AnyMPlace);
    }
    public void SleepDiol()
    {
        cleanDi();
        DioPlace = Instantiate(SleepTalk, new Vector3(2.34f, -0.71f, 0.0f), transform.rotation);
        GameObject.FindWithTag("Chara").GetComponent<MainCharacter>().SetEnding();
        Destroy(DoorPlace);
        Destroy(AnyMPlace);
    }
    public void ComppasActive()
    {
        cleanDi();
        DioPlace = Instantiate(CompasActiv, new Vector3(0f, 0f, 0.0f), transform.rotation);
        compasUsed = true;
    }
    public bool ComppasHasbeenUsed()
    {
        return compasUsed;
    }
    void cleanDi()
    {
        if (DioPlace != null) { Destroy(DioPlace); }
    }
}
