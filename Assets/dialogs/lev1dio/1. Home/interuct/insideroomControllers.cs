using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class insideroomControllers : MonoBehaviour
{
    private GameObject manager;
    [SerializeField] private GameObject Water;
    private GameObject water;
    private bool WaterRunning = false;
    [SerializeField] private GameObject CupsPlace;
    [SerializeField] private GameObject TeaPlace;
    [SerializeField] private GameObject Cloak;
    private GameObject cupsPlace;
    private GameObject teaPlace;
    private GameObject cloak;

    [SerializeField] private GameObject Basket;
    private GameObject basket;
    [SerializeField] private GameObject Veg;
    [SerializeField] private GameObject Kettle;
    private GameObject kettle;
    [SerializeField] private GameObject Atthedoor;
    private GameObject atthedoor;
    [SerializeField] private GameObject MeetOld;
    private GameObject meetOld;

    [SerializeField] private GameObject Exitt;
    private GameObject exitt;

    [SerializeField] private GameObject Table;
    private GameObject table;
    [SerializeField] private GameObject Stove;
    private GameObject stove;
    [SerializeField] private GameObject Chair;
    private GameObject chair;

    [SerializeField] private GameObject CupsPl;
    private GameObject cupsPl;

    [SerializeField] private GameObject Kettle_Obj;
    private GameObject kettle_Obj;
    private bool boils=false;
    private bool cupsONtable = false;
    private Animator animator;
    private bool teaready = false;
    private bool teaQuestComp = false;
    [SerializeField] private GameObject SalatB;
    private GameObject salatB;
    private bool Grannahere = false;

    void Start()
    {
        manager = GameObject.FindWithTag("mannager");
        cloak = Instantiate(Cloak, new Vector3(-3.48f, -0.93f, 0.0f), transform.rotation);
        basket = Instantiate(Basket, new Vector3(2.42f, 1.77f, 0.0f), transform.rotation, transform);
        exitt = Instantiate(Exitt, new Vector3(-0.16f, -3.49f, 0.0f), transform.rotation, transform);
        Kettle.SetActive(false);
        Stove.SetActive(false);
        Table.SetActive(false);
        Chair.SetActive(false);

    }

    public void TeaQuestInter()
    {
        cupsPlace = Instantiate(CupsPlace, new Vector3(-0.339999f, 0.97f, 0.0f), transform.rotation);
        teaPlace = Instantiate(TeaPlace, new Vector3(-0.72f, -0.75f, 0.0f), transform.rotation);
        Kettle.SetActive(true);
        Stove.SetActive(true);
        Table.SetActive(true);
        Chair.SetActive(true);

        //kettle = Instantiate(Kettle, new Vector3(3.09f, 0.71f, 0.0f), transform.rotation);
        //stove = Instantiate(Stove, new Vector3(0.55f, 0.86f, 0.0f), transform.rotation);
        //table = Instantiate(Table, new Vector3(2.28f, -0.24f, 0.0f), transform.rotation);
        //chair = Instantiate(Chair, new Vector3(0.95f, -1.23f, 0.0f), transform.rotation);

    }
    public void FillKettle()
    {
        kettle_Obj = Instantiate(Kettle_Obj, new Vector3(1.753f, 1.533f, 0.0f), transform.rotation);
        Destroy(kettle_Obj, 2f);
    }
    public void StoveKettle()
    {
        kettle_Obj = Instantiate(Kettle_Obj, new Vector3(0.81f, 1.73f, 0.0f), transform.rotation);
        animator = kettle_Obj.GetComponent<Animator>();
        StartCoroutine(Waw(4f));
        manager.GetComponent<LastBitController>().PlateMus();
        //Destroy(kettle_Obj, 2f);
    }

    public void KettleBack() { Destroy(kettle_Obj); manager.GetComponent<LastBitController>().Del_BoilMus(); }
    public void PlaceCups(){
        cupsPl = Instantiate(CupsPl, new Vector3(4.55f, 0.0f, 0.0f), transform.rotation);
        cupsONtable = true;
        manager.GetComponent<LastBitController>().PlateMus();
    }
    public void RemoveCups()
    {
        cupsONtable = false;
        Destroy(cupsPl);
    }
    public bool CupsOn() { 
        if(cupsONtable&& teaready)
        {return true; }
        else { return false; }
         }
    IEnumerator Waw(float ss)
    {
        yield return new WaitForSeconds(ss);
        animator.SetBool("boil", true);
        boils = true;
        manager.GetComponent<LastBitController>().BoilMus();
    }
    public bool retBoil()
    {
        return boils;
    }
    public void AddTeaa() { teaready = true; }
    public bool IsAddTeaa() { return teaready; }
    public void CompleteTeaQ() { teaQuestComp = true; }
    public bool IsCompleteTeaQ() { Debug.Log(teaQuestComp); return teaQuestComp; }
    public void KettleFound()
    {
        manager.GetComponent<lugge>().AddKattle();
    }
    public void CupFound()
    {
        manager.GetComponent<lugge>().AddCup();
    }
    public void WaterInteruction()
    {
        if(!WaterRunning) {
            water = Instantiate(Water, new Vector3(1.768001f, 1.609f, 0.0f), transform.rotation);
            WaterRunning = true;
            manager.GetComponent<LastBitController>().SinkMus();
        }
        else
        {
            Destroy(water);
            WaterRunning = false;
            manager.GetComponent<LastBitController>().Del_SinkMus();
        }
    }
    public void DestriyCuppy() { Destroy(cupsPlace); }
    public void DestriyTepu() { Destroy(teaPlace); }
    public void PlaceSatalB()
    {
        salatB = Instantiate(SalatB, new Vector3(1.94f, 0.0f, 0.0f), transform.rotation);
    }

    public void Turntime()
    {
        manager.GetComponent<sceneManager>().TurnTime();
        if (Grannahere)
        {
            GameObject.FindWithTag("oldLady").GetComponent<thirdGran>().SleepyyNow();
        }
    }
    public void DeleteCloak()
    {
        Destroy(cloak);
        Debug.Log("Deleted");
        cloak = Instantiate(Cloak, new Vector3(-3.48f, -0.93f, 0.0f), transform.rotation);
    }
    public void ReinstalCloak()
    {
        cloak = Instantiate(Cloak, new Vector3(-3.48f, -0.93f, 0.0f), transform.rotation);
    }
    public void PlaceVeg()
    {
        Destroy(basket);
        basket = Instantiate(Veg, new Vector3(2.42f, 1.77f, 0.0f), transform.rotation);
        atthedoor = Instantiate(Atthedoor, new Vector3(3.08f, 1.2f, 0.0f), transform.rotation);
        meetOld = Instantiate(MeetOld, new Vector3(0.78f, -3.1f, 0.0f), transform.rotation);
        exitt.SetActive(false);
    }
    public void delVeg()
    {
        Destroy(basket);
    }
    public void SetGranhere()
    {
        Grannahere = true;
    }
    public void ExitisBack()
    {
        exitt.SetActive(true);
    }
    public void HideUs()
    {
        if(water!=null)
        {
            water.SetActive(false);
        }
        salatB.SetActive(false);
    }
    public void CleanUP()
    {
        if (atthedoor != null) { Destroy(atthedoor); }
        if (water != null) { Destroy(water); }
        if (salatB != null) { Destroy(salatB); }
    }
}
