using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controllbasment : MonoBehaviour
{
    int phase = 0;
    bool Doorlocked = true;
    bool canGOin = true;
    int insideroundCounter = 0;
    bool rightpass = true;
    int dir;

    [SerializeField] AudioClip spappear;
    [SerializeField] AudioClip laught;
    [SerializeField] AudioClip scream;
    [SerializeField] AudioSource audioSource;

    [SerializeField] AudioClip basisounf;
    [SerializeField] AudioClip riddlesound;
    [SerializeField] AudioSource audioSourceAmbi;

    [SerializeField] AudioClip stab;
    [SerializeField] AudioClip fall;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CloseForever() { canGOin = false; }           
    public bool canIgo() { return canGOin; }
    public void startmus() { audioSourceAmbi.PlayOneShot(basisounf); }
    public void playRiddlemus() { audioSourceAmbi.PlayOneShot(riddlesound); }
    public bool doorlocked() { return Doorlocked; }
    public void unlockdoor() { Doorlocked = true; }
    public void doorIsOpenNow() { Doorlocked = false; }
    public void Choseroomtoload(int di) //3-up 2 right 1 down 4 ledt
    {
        dir = di;
        insideroundCounter++;
        if (insideroundCounter == 5)
        {
            Debug.Log("basi");
            gameObject.GetComponent<sceneManager>().LoadPreCenter();
            GameObject.FindWithTag("Chara").GetComponent<MainCharacter>().MoveAway(-0.13f, -1.88f);
            insideroundCounter = 0;
            
            if (rightpass&&dir==1)
            {
                
                StartCoroutine(riddle());
                gameObject.GetComponent<sceneManager>().CreateShynks();
                //music
                Debug.Log("here");
                
            }
            else
            {
                rightpass = true;
                audioSourceAmbi.Stop();
                gameObject.GetComponent<sceneManager>().CreateArlekin();
                audioSource.PlayOneShot(spappear);

                StartCoroutine(blinkis());
            }
            
        }
        else
        {
            if (cheakheart()) { gameObject.GetComponent<sceneManager>().LoadHeart(); Debug.Log(rightpass); }
            else if (cheakRomb()) { gameObject.GetComponent<sceneManager>().LoadDiamond(); Debug.Log(rightpass); }
            else if (cheakThref()) { gameObject.GetComponent<sceneManager>().LoadCloves(); Debug.Log(rightpass); }
            else if (cheakUpsiheart()) { gameObject.GetComponent<sceneManager>().LoadPickes(); Debug.Log(rightpass); }
        }
    }
    public bool cheakheart()
    {
        if (dir == 3 && insideroundCounter == 1) { rightpass = false; return true; }
        else if (insideroundCounter == 2 && dir == 4) { return true; }  
        else if(insideroundCounter==3 && dir == 1) { rightpass = false; return true; }
        else if (insideroundCounter == 4 && dir == 2) { return true; }
        else { return false; }
    }
    public bool cheakRomb()
    {
        if (dir == 4 && insideroundCounter == 1) { rightpass = false; return true; }
        else if (insideroundCounter == 2 && dir == 1) { rightpass = false; return true; }
        else if (insideroundCounter == 3 && dir == 2) { return true; }
        else if (insideroundCounter == 4 && dir == 3) { rightpass = false; return true; }
        else { return false; }
    }
    public bool cheakThref()
    {
        if (dir == 2 && insideroundCounter == 1) { return true; }
        else if (insideroundCounter == 2 && dir == 3) { rightpass = false; return true; }
        else if (insideroundCounter == 3 && dir == 4) { rightpass = false; return true; }
        else if (insideroundCounter == 4 && dir == 1) { rightpass = false; return true; }
        else { return false; }
    }
    public bool cheakUpsiheart()
    {
        if (dir == 1 && insideroundCounter == 1) { rightpass = false; return true; }
        else if (insideroundCounter == 2 && dir == 2) { rightpass = false; return true; }
        else if (insideroundCounter == 3 && dir == 3) { rightpass = false; return true; }
        else if (insideroundCounter == 4 && dir == 4) { rightpass = false; return true; }
        else { return false; }
    }
    private IEnumerator blinkis()
    {
        yield return new WaitForSeconds(1.5f);
        audioSource.PlayOneShot(laught);
        Debug.Log("here");
        gameObject.GetComponent<sceneManager>().Blinking();
        yield return new WaitForSeconds(4f);
        audioSource.PlayOneShot(scream);
        yield return new WaitForSeconds(3f);
        gameObject.GetComponent<sceneManager>().del_Arli();
        gameObject.GetComponent<sceneManager>().del_blacky();
        gameObject.GetComponent<sceneManager>().LoadInsideSecondHouse();
        //kill arli kill blacl living room 
    }
    private IEnumerator riddle()
    {
        Debug.Log("here");
        yield return new WaitForSeconds(2f);
        Debug.Log("here");
        //audioSourceAmbi.Stop();
        gameObject.GetComponent<secLdialog>().startshy();
        
    }
    public void deathbycrack()
    {
        StartCoroutine(ExitRoom());
    }
    private IEnumerator ExitRoom()
    {
        yield return new WaitForSeconds(2f);
        gameObject.GetComponent<sceneManager>().del_Shy();
        gameObject.GetComponent<sceneManager>().LoadInsideSecondHouse();
    }
    public void killing()
    {
        audioSource.PlayOneShot(stab);
        StartCoroutine(Killl());
    }
    private IEnumerator Killl()
    {
        yield return new WaitForSeconds(1f);
        audioSource.PlayOneShot(fall);
    }
    
}

