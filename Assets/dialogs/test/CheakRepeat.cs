using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheakRepeat : MonoBehaviour
{
    private int sas = 90;
    private bool CurCondition = false;
    private bool KeyFound = false;
    private bool SilverKeyFound = false;
    //private bool Bitten = false;
    [SerializeField] private ResponceEvent evenT;
    private GameObject manager;
    private bool vegFound = false;
    // Start is called before the first frame update

    // false - продолжаем

    void Start()
    {
        manager = GameObject.FindWithTag("mannager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool CheakCondition()
    {
        return CurCondition;
    }
    public void ChangeCondition()
    {
        sas = 0;
        Debug.Log("sas is "+sas);
    }
    public void InteractedWithBush(bool res)
    {
        KeyFound = true;
        //Bitten = res;
        //Debug.Log("Bitten " + Bitten);
    }
    public void AssisgnInteractedWithBush()//искал ключ
    {
        CurCondition = KeyFound;
    }
    //public void SilverKeyFound()//искал ключ
    //{
    //    SilverKeyFound = true;
    //}
    public void AssignSilverKeyFound()//искал ключ
    {
        SilverKeyFound = manager.GetComponent<RememberThings>().GetStatusSilverKeyFound();
        CurCondition = SilverKeyFound;
    }
    //public void AssisgnBitten()//покусали ли
    //{
    //    CurCondition = Bitten;
    //}
    public void AssignSas()
    {
        if (sas == 90)
        {
            CurCondition = false;
        }
        else { CurCondition = true; }
        Debug.Log("CurCondition is " + CurCondition);
    }
    public void Nonono()
    {
        CurCondition = false;
    }
    public ResponceEvent ReturnEvent()
    {
        return evenT;
    }
    //public void VeggiIsFounf()
    //{
    //    vegFound = true;
    //}
    public void ArethereVeg()
    {
        if (GameObject.FindWithTag("mannager").GetComponent<lugge>().hasVeg()) { vegFound = true; }
        CurCondition = vegFound;
    }
}
