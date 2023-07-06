using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RememberThings : MonoBehaviour
{
    private string CharacterName;
    public string characterName => CharacterName;

    private string Tea;
    public string tea => Tea;

    private bool SpiderPOison = false;
    private bool KeyStillInTheBush = true;

    private bool silverKeyFound = false;

    public void SetName(string name) { CharacterName = name; }
    public void SetNameCharlie() {
        if (GameObject.FindWithTag("mannager").GetComponent<sceneManager>().retLanguage()==0)
        {
            CharacterName = "Charlie";
            Debug.Log("eng");
            Debug.Log(GameObject.FindWithTag("mannager").GetComponent<sceneManager>().retLanguage());
        }
        else { CharacterName = "Чарлі"; }
    }
    public void SetNameAlexi()
    {
        if (GameObject.FindWithTag("mannager").GetComponent<sceneManager>().retLanguage() == 0)
        {
            CharacterName = "Alexi";
        }
        else { CharacterName = "Алексі"; }
    }
    public void SetNameAvery() {
        if (GameObject.FindWithTag("mannager").GetComponent<sceneManager>().retLanguage() == 0)
        {
            CharacterName = "Avery";
        }
        else { CharacterName = "Эйверы"; }
    }
    public void SetNameJohn()
    {
        if (GameObject.FindWithTag("mannager").GetComponent<sceneManager>().retLanguage() == 0)
        {
            CharacterName = "John";
        }
        else { CharacterName = "Джон"; }
    }
    public void SetNameDinah()
    {
        if (GameObject.FindWithTag("mannager").GetComponent<sceneManager>().retLanguage() == 0)
        {
            CharacterName = "Dinah";
        }
        else { CharacterName = "Дзіна"; }
    }
    public void SetNameEverly()
    {
        if (GameObject.FindWithTag("mannager").GetComponent<sceneManager>().retLanguage() == 0)
        {
            CharacterName = "Everly";
        }
        else { CharacterName = "Эверлі"; }
    }
    public string ReturnName() { return CharacterName; }

    public void SetTeaChamonile(string teaa) {  Tea = teaa;  Debug.Log(Tea); }

    public string ReturnTea() { return Tea; }

    public void FoundBushKey() {  KeyStillInTheBush = false; }
    public bool BushStillActive() { return KeyStillInTheBush; }

    public void PoisonedStatus(bool cureORbite)
    {
        SpiderPOison = cureORbite;
    }
    public bool ReturnPoisonedStatus()
    {
      
        return SpiderPOison;
    }
    public void SilverKeyFound()//искал ключ
    {
        silverKeyFound = true;
    }
    public bool GetStatusSilverKeyFound()//искал ключ
    {
        return silverKeyFound;
    }
}
