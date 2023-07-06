using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dothingss : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Explaininggg()
    {
        GameObject.FindWithTag("mannager").GetComponent<LastBitController>().Explain();
    }
    public void Say()
    {
        Debug.Log("hihi");
        GameObject.FindWithTag("mannager").GetComponent<sceneManager>().StartCheakersGame();
    }

    public void Tea()
    {
        
        GameObject.FindWithTag("mannager").GetComponent<LastBitController>().SayBey();
    }
    public void Asweer()
    {

        GameObject.FindWithTag("mannager").GetComponent<LastBitController>().AswerWWW();
        Debug.Log("www");
    }
    public void GranpaGo()
    {

        GameObject.FindWithTag("grandpa").GetComponent<grandPapa>().GoAway();
    }

    public void SetPlaerFree()
    {

        GameObject.FindWithTag("Chara").GetComponent<MainCharacter>().GetUp();
        GameObject.FindWithTag("mannager").GetComponent<LastBitController>().SamOver();
    }
    //public void hasBoth()
    //{
    //    if (GameObject.FindWithTag("mannager").GetComponent<lugge>().hasBothIsIt())
    //    {
    //        GameObject.FindWithTag("mannager").GetComponent<LastBitController>().FoundBoth();
    //    }
    //}
    public void Destri()
    {
        GameObject.FindWithTag("mannager").GetComponent<lugge>().DelFoundBoth();
        
    }
    public void Destriii()
    {
        GameObject.FindWithTag("mannager").GetComponent<LastBitController>().SamOver();
    }
    public void Diee()
    {
        GameObject.FindWithTag("oldLady").GetComponent<thirdGran>().DieNow();
        GameObject.FindWithTag("mannager").GetComponent<sceneManager>().Place_corpi();
    }
    public void Unlockdoor()
    {
        GameObject.FindWithTag("mannager").GetComponent<lugge>().GoldKeyPiece();
        GameObject.FindWithTag("insColider").GetComponent<insideroomControllers>().ExitisBack();
    }
    public void CompasUsed()
    {
        GameObject.FindWithTag("mannager").GetComponent<sceneManager>().ActivateEnding();
    }
    public void GirlGoHome()
    {
        GameObject.FindWithTag("girl").GetComponent<girlControll>().EnterHouse();
    }
    public void SetEverly()
    {
        GameObject.FindWithTag("mannager").GetComponent<RememberThings>().SetNameEverly();
        GirlLeave();
    }
    public void SetJohn()
    {
        GameObject.FindWithTag("mannager").GetComponent<RememberThings>().SetNameJohn();
        GirlLeave();
    }
    public void Setdinah()
    {
        GameObject.FindWithTag("mannager").GetComponent<RememberThings>().SetNameDinah();
        GirlLeave();
    }
    public void GirlLeave()
    {
       
        Debug.Log("leave");
        GameObject.FindWithTag("girl").GetComponent<girlControll>().GirlLeave();
    }
    public void fetfreezw()
    {
        GameObject.FindWithTag("mannager").GetComponent<lugge>().AddFrozenFood();
    }
    public void fetknife()
    {
        GameObject.FindWithTag("mannager").GetComponent<lugge>().AddKnife();
    }
    public void fetcard()
    {
        GameObject.FindWithTag("mannager").GetComponent<lugge>().CardsPiece();
    }
    public void fepaper()
    {
        GameObject.FindWithTag("mannager").GetComponent<lugge>().AddCodes();
    }
    public void KidGoHide()
    {
        GameObject.FindWithTag("boy").GetComponent<boyControll>().playHideAndSeek();
    }
    public void KidGoEat()
    {
        Debug.Log("eat");
        GameObject.FindWithTag("boy").GetComponent<boyControll>().GoEat();
    }
    public void KidGoBath()
    {
        KidGoUptairs();
        GameObject.FindWithTag("boy").GetComponent<boyControll>().wentBath();
    }
    public void KidGoBed()
    {
        KidGoUptairs();
        GameObject.FindWithTag("boy").GetComponent<boyControll>().WenttoBed();
    }
    public void KidGoStudy()
    {
        KidGoUptairs();
        GameObject.FindWithTag("boy").GetComponent<boyControll>().wenthomewo();
    }
    public void timetoStudy()
    {
        GameObject.FindWithTag("mannager").GetComponent<secLdialog>().studyTrue();
    }
    public void KidGoUptairs()
    {
        GameObject.FindWithTag("boy").GetComponent<boyControll>().GoUp();
    }
    public void StartMiniHomeWork()
    {
        GameObject.FindWithTag("mannager").GetComponent<sceneManager>().StartHomeworkGame();
    }
    public void booksred()
    {
        GameObject.FindWithTag("mannager").GetComponent<lugge>().CardsPiece();
        GameObject.FindWithTag("mannager").GetComponent<lugge>().AdddBible();
        GameObject.FindWithTag("mannager").GetComponent<lugge>().AddCodes();
    }
    public void fallasleep()
    {
        GameObject.FindWithTag("boy").GetComponent<boyControll>().fallasleep();
    }
    public void readytosleep()
    {
        GameObject.FindWithTag("mannager").GetComponent<secLdialog>().slepTrue();
    }
    public void alldonegirlcome()
    {
        //GameObject.FindWithTag("mannager").GetComponent<secLdialog>().slepTrue();
        GameObject.FindWithTag("mannager").GetComponent<lugge>().GoldKeyPiece();
        GameObject.FindWithTag("mannager").GetComponent<controllbasment>().CloseForever();
    }
    public void cardwasher() { GameObject.FindWithTag("mannager").GetComponent<controllthese>().use_washer(); }
    public void cardbasket() { GameObject.FindWithTag("mannager").GetComponent<controllthese>().use_basket(); }
    public void cardba() { GameObject.FindWithTag("mannager").GetComponent<controllthese>().use_card(); }
    public void addKey() { GameObject.FindWithTag("mannager").GetComponent<lugge>().GoldKeyPiece(); }
    public void syartRiddles() { GameObject.FindWithTag("Chara").GetComponent<MainCharacter>().StartingRiddles(); }
    public void leavebasiforever()
    {
        GameObject.FindWithTag("mannager").GetComponent<controllbasment>().CloseForever();
        GameObject.FindWithTag("mannager").GetComponent<controllbasment>().killing();
        GameObject.FindWithTag("mannager").GetComponent<sceneManager>().BlackscrR();
    }
    public void gokillma()
    {
        GameObject.FindWithTag("mannager").GetComponent<controllbasment>().CloseForever();
        GameObject.FindWithTag("girl").GetComponent<girlControll>().killnow();
    }
    public void pl_wrong()
    {
        GameObject.FindWithTag("mannager").GetComponent<secLdialog>().place_wrong();
    }
    public void pl_right()
    {
        GameObject.FindWithTag("mannager").GetComponent<secLdialog>().place_right();
    }
    public void pl_mom()
    {
        GameObject.FindWithTag("mannager").GetComponent<secLdialog>().place_mmom();
    }
    public void pl_you()
    {
        GameObject.FindWithTag("mannager").GetComponent<secLdialog>().place_you();
    }
    public void godiee()
    {
        GameObject.FindWithTag("mannager").GetComponent<controllbasment>().CloseForever();
        GameObject.FindWithTag("mannager").GetComponent<sceneManager>().createMaNorm();
        GameObject.FindWithTag("mo").GetComponent<maControll>().killnow();
    }
    public void ActivateHide() {
        GameObject.FindWithTag("mannager").GetComponent<secLdialog>().Boy_Nothere();
        GameObject.FindWithTag("boy").GetComponent<boyControll>().GoUp();
        GameObject.FindWithTag("mannager").GetComponent<hideANDseek>().HideAway();
        
    }
    public void FoundMe()
    {
        GameObject.FindWithTag("mannager").GetComponent<lugge>().Add_Pic();
        GameObject.FindWithTag("boy").GetComponent<boyControll>().GoAwayFromHide();
        GameObject.FindWithTag("mannager").GetComponent<hideANDseek>().boyfound();
    }
    public void ActivatePay()
    {
        GameObject.FindWithTag("mannager").GetComponent<secLdialog>().payying();
    }
    public void FinishBasi()
    {
        GameObject.FindWithTag("mannager").GetComponent<lugge>().GoldKeyPiece();
        GameObject.FindWithTag("boy").GetComponent<boyControll>().Dissapear();
    }
}
