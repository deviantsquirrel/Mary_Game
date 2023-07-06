using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class secLdialog : MonoBehaviour
{

    private GameObject DioPlace;
    [SerializeField] GameObject intro;
    [SerializeField] GameObject meetkid;
    [SerializeField] GameObject codes;
    [SerializeField] GameObject tasks;
    [SerializeField] GameObject Icard;
    [SerializeField] GameObject IIcard;
    [SerializeField] GameObject IIIcard;
    [SerializeField] GameObject IVcard;
    [SerializeField] GameObject Vcard;
    [SerializeField] GameObject VIcard;
    [SerializeField] GameObject goeat;
    [SerializeField] GameObject bibles;

   [SerializeField] GameObject timetodohomework;
    [SerializeField] GameObject godohomework;
    [SerializeField] GameObject godobath;
    [SerializeField] GameObject godosleep;
    [SerializeField] GameObject startHom;
    [SerializeField] GameObject placebook;
    [SerializeField] GameObject bedTimestory;
    [SerializeField] GameObject girllback;
    [SerializeField] GameObject finfkeypart;
    [SerializeField] GameObject spyy;
    [SerializeField] GameObject JohnSnow;
    [SerializeField] GameObject notJohnSnow;
    [SerializeField] GameObject wwrong;
    [SerializeField] GameObject rright;
    [SerializeField] GameObject mmom;
    [SerializeField] GameObject yyou;
    [SerializeField] GameObject foundMe;

    [SerializeField] GameObject nochoisehome;
    [SerializeField] GameObject nochoiseeat;
    [SerializeField] GameObject nochoisebath;
    [SerializeField] GameObject nochoisesleep;
    [SerializeField] GameObject payme;
    [SerializeField] GameObject compasec;
    bool timeTostudy = false;
    bool timeToBathe = false;
    bool timeToSleep = false;
    bool donehomew = false;
    bool eatt = false;
    bool alltasksdone = false;
    bool doneBath = false;
    bool boy_present = true;
    bool havechoise = true;
    bool girlTalked = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NoLongoChoise() { havechoise= false; }
    public void studyTrue() { timeTostudy = true; }
    public void studyFalse() { timeTostudy = false; }
    public void bathTrue() { timeToBathe = true; }
    public void bathFalse() { timeToBathe = false; }
    public void slepTrue() { timeToSleep = true; }
    public void slepFalse() { timeToSleep = false; }
    public void donehom() { donehomew = true; }
    public void donBath() { doneBath = true; }
    public void goeattt() { eatt = true; }
    public void goeatttFalse() { eatt = false; }
    public void doneall() { alltasksdone = true; }
    public bool isalldone() { return alltasksdone; }
    public void Boy_here() { boy_present = true; }
    public void Boy_Nothere() { boy_present = false; }
    public void stSomething()
    {
        Debug.Log(boy_present);
        if (timeTostudy&& boy_present) { goStudy(); }
        if (timeToBathe&& donehomew&& boy_present) { goBath(); }
        if (timeToSleep&& doneBath&& boy_present) { goSleep(); }
        if (alltasksdone&&!girlTalked) { girlCameBack(); GameObject.FindWithTag("girl").GetComponent<girlControll>().GirMove(0.33f, -0.76f); girlTalked = true; }

    }
    public void FirstDio()
    {
        DioPlace = Instantiate(intro, new Vector3(-5.91f, -3.35f, 0.0f), transform.rotation);
    }
    public void SecondDio()
    {
        Destroy(DioPlace);
        DioPlace = Instantiate(meetkid, new Vector3(-0.44f, -0.69f, 0.0f), transform.rotation);
    }
    public void Tascs()
    {
        Destroy(DioPlace);
        DioPlace = Instantiate(tasks, new Vector3(-0.44f, -0.69f, 0.0f), transform.rotation);
    }
    public void Placecodes()
    {
        Destroy(DioPlace);
        DioPlace = Instantiate(codes, new Vector3(-0.44f, -0.69f, 0.0f), transform.rotation);
    }
    public void plIcard()
    {
        Destroy(DioPlace);
        DioPlace = Instantiate(Icard, new Vector3(-0.44f, -0.69f, 0.0f), transform.rotation);
    }
    public void plIIcard()
    {
        Destroy(DioPlace);
        DioPlace = Instantiate(IIcard, new Vector3(-0.44f, -0.69f, 0.0f), transform.rotation);
    }
    public void plIIIcard()
    {
        Destroy(DioPlace);
        DioPlace = Instantiate(IIIcard, new Vector3(-0.44f, -0.69f, 0.0f), transform.rotation);
    }
    public void plIVcard()
    {
        Destroy(DioPlace);
        DioPlace = Instantiate(IVcard, new Vector3(-0.44f, -0.69f, 0.0f), transform.rotation);
    }
    public void plVcard()
    {
        Destroy(DioPlace);
        DioPlace = Instantiate(Vcard, new Vector3(-0.44f, -0.69f, 0.0f), transform.rotation);
    }
    public void plVIcard()
    {
        Destroy(DioPlace);
        DioPlace = Instantiate(VIcard, new Vector3(-0.44f, -0.69f, 0.0f), transform.rotation);
    }
    public void plgoeat()
    {
        if (eatt&& boy_present)
        {
            Destroy(DioPlace);
            if (havechoise) { DioPlace = Instantiate(goeat, new Vector3(1.44f, 1.83f, 0.0f), transform.rotation); }
            else { DioPlace = Instantiate(nochoiseeat, new Vector3(1.44f, 1.83f, 0.0f), transform.rotation); }
        }
    }
    public void homeworkFetch()
    {
        Destroy(DioPlace);
        DioPlace = Instantiate(timetodohomework, new Vector3(1.44f, -0.08f, 0.0f), transform.rotation);

    }
    public void goStudy()
    {
        Destroy(DioPlace);
        if (havechoise) { DioPlace = Instantiate(godohomework, new Vector3(1.44f, 1.83f, 0.0f), transform.rotation); }
        else { DioPlace = Instantiate(nochoisehome, new Vector3(1.44f, 1.83f, 0.0f), transform.rotation); }
        
    }
    public void StaryHomeW()
    {
        Destroy(DioPlace);
        DioPlace = Instantiate(startHom, new Vector3(1.44f, -0.08f, 0.0f), transform.rotation);
    }

    public void goBath()
    {
        Destroy(DioPlace);
        if (havechoise) { DioPlace = Instantiate(godobath, new Vector3(1.44f, 1.83f, 0.0f), transform.rotation); }
        else { DioPlace = Instantiate(nochoisebath, new Vector3(1.44f, 1.83f, 0.0f), transform.rotation); }
    }
    public void goSleep()
    {
        Destroy(DioPlace);
        if (havechoise) { DioPlace = Instantiate(godosleep, new Vector3(1.44f, 1.83f, 0.0f), transform.rotation); }
        else { DioPlace = Instantiate(nochoisesleep, new Vector3(1.44f, 1.83f, 0.0f), transform.rotation); }
    }
    public void readbible()
    {
        Destroy(DioPlace);
        DioPlace = Instantiate(bibles, new Vector3(-1.13f, -0.14f, 0.0f), transform.rotation);
    }
    public void placebible()
    {
        Destroy(DioPlace);
        DioPlace = Instantiate(placebook, new Vector3(1.8f, -0.93f, 0.0f), transform.rotation);
    }
    public void readstory()
    {
        Destroy(DioPlace);
        DioPlace = Instantiate(bedTimestory, new Vector3(2.06f, -0.97f, 0.0f), transform.rotation);
    }
    public void girlCameBack()
    {
        Destroy(DioPlace);
        DioPlace = Instantiate(girllback, new Vector3(-1.13f, -0.14f, 0.0f), transform.rotation);
    }
    public void tearBear()
    {
        Destroy(DioPlace);
        DioPlace = Instantiate(finfkeypart, new Vector3(0f, 0f, 0.0f), transform.rotation);
    }
    public void startshy()
    {
        //Destroy(DioPlace);
        Debug.Log("here");
        DioPlace = Instantiate(spyy, new Vector3(0f, 0f, 0.0f), transform.rotation);
    }
    public void place_John()
    {
        Destroy(DioPlace);
        DioPlace = Instantiate(JohnSnow, new Vector3(0f, 0f, 0.0f), transform.rotation);
    }
    public void place_notJohn()
    {
        Destroy(DioPlace);
        DioPlace = Instantiate(notJohnSnow, new Vector3(0f, 0f, 0.0f), transform.rotation);
    }
    public void place_wrong()
    {
        Destroy(DioPlace);
        DioPlace = Instantiate(wwrong, new Vector3(0f, 0f, 0.0f), transform.rotation);
    }
    public void place_right()
    {
        Destroy(DioPlace);
        DioPlace = Instantiate(rright, new Vector3(0f, 0f, 0.0f), transform.rotation);
    }
    public void place_you()
    {
        Destroy(DioPlace);
        DioPlace = Instantiate(yyou, new Vector3(0f, 0f, 0.0f), transform.rotation);
    }
    public void place_mmom()
    {
        Destroy(DioPlace);
        DioPlace = Instantiate(mmom, new Vector3(0f, 0f, 0.0f), transform.rotation);
    }
    public void Hide_Seek()
    {
        Destroy(DioPlace);
        DioPlace = Instantiate(foundMe, new Vector3(0f, 0f, 0.0f), transform.rotation);
        Boy_here();
    }
    public void payying()
    {
        Destroy(DioPlace);
        DioPlace = Instantiate(payme, new Vector3(0f, 0f, 0.0f), transform.rotation);
    }
    public void CompaUsedAg()
    {
        Destroy(DioPlace);
        DioPlace = Instantiate(compasec, new Vector3(0f, 0f, 0.0f), transform.rotation);
    }
}
