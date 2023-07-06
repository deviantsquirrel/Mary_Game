using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TeaScriprt : MonoBehaviour
{
    private GameObject manager;
    [SerializeField] private TMP_Text textЕ;
    [SerializeField] private TMP_Text tone;
    [SerializeField] private TMP_Text two;
    [SerializeField] private TMP_Text three;
    [SerializeField] private TMP_Text four;
    int lang;
    void Start()
    {
        GameObject.FindWithTag("insColider").GetComponent<insideroomControllers>().DestriyTepu();
        manager = GameObject.FindWithTag("mannager");
        lang = manager.GetComponent<sceneManager>().retLanguage();
        if(lang==1)
        {
            textЕ.text = "Тут ёсць некалькі слоікаў.\r\nНешта не так з цэтлікамі.";
            tone.text = "НРОКАМА";
            two.text = "БУНІН";
            three.text = "ЛЕБАНОНАД";
            four.text = "ЛЫНАП";
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void PressChammomile()
    {
        manager.GetComponent<RememberThings>().SetTeaChamonile("Chamonile");
        FinishGame(3);
    }
    public void PressBelladonna()
    {
        manager.GetComponent<RememberThings>().SetTeaChamonile("Belladonna");
        FinishGame(1);
    }
    public void PressLupinus()
    {
        manager.GetComponent<RememberThings>().SetTeaChamonile("Lupinus");
        FinishGame(2);
    }
    public void PressArtemisia()
    {
        manager.GetComponent<RememberThings>().SetTeaChamonile("Artemisia");
        FinishGame(0);
    }

    public void FinishGame(int er)
    {
        manager.GetComponent<lugge>().AddTea(er);
        manager.GetComponent<sceneManager>().FinishMiniGame();
        GameObject.FindWithTag("Chara").GetComponent<MainCharacter>().SetFree();
    }
}
