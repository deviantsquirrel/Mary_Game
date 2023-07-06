using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controllthese : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject foodOntable;
    [SerializeField] GameObject seeNoevil;
    [SerializeField] GameObject hearNoevil;
    [SerializeField] GameObject speakNoevil;
    [SerializeField] GameObject hearevil;
    [SerializeField] GameObject seeevil;
    [SerializeField] GameObject speakevil;
    [SerializeField] GameObject pourwater;
    [SerializeField] GameObject crack;

    bool see = false;
    bool hear = false;
    bool say = false;
    bool food = false;

    private GameObject foodD;
    private GameObject See;
    private GameObject Say;
    private GameObject Hear;

    private GameObject Water;
    private GameObject Crack;



    bool used_cabinet = false;
    bool used_washer = false;
    bool used_basket = false;
    bool used_bed = false;
    bool used_homework = false;
    bool used_books = false;

    bool used_card = false;
    bool used_knife = false;
    bool used_food = false;
    bool used_stove = false;

    bool used_scI = false;
    bool used_scII = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void use_cabinet() { used_cabinet = true; }
    public void use_washer() { used_washer = true; }
    public void use_basket() { used_basket = true; }

    public void use_bed() { used_bed = true; }
    public void use_homework() { used_homework = true; }
    public void use_books() { used_books = true; }

    public void use_card() { used_card = true; }
    public void use_knife() { used_knife = true; }
    public void use_food() { used_food = true; }
    public void use_stove() { used_stove = true; }

    public void use_scI() { used_scI = true; }
    public void use_scII() { used_scII = true; }

    public bool iuse_cabinet() { return used_cabinet; }
    public bool iuse_washer() { return used_washer; }
    public bool iuse_basket() { return used_basket; }
    public bool iuse_bed() { return used_bed; }
    public bool iuse_homework() { return used_homework; }
    public bool iuse_books() { return used_books; }

    public bool iuse_card() { return used_card; }
    public bool iuse_knife() { return used_knife; }
    public bool iuse_food() { return used_food; }
    public bool iuse_stove() { return used_stove; }

    public bool iuse_scI() { return used_scI; }
    public bool iuse_scII() { return used_scII; }

    public void PourWater()
    {
        Water = Instantiate(pourwater, new Vector3(-1.452f, -0.453f, 0.0f), transform.rotation);
    }
    public void PlaceCrack ()
    {
        Crack = Instantiate(crack, new Vector3(-0.23f, -2.21f, 0.0f), transform.rotation);
    }
    public void killsee()
    {
        Destroy(See);
        See = Instantiate(seeevil, new Vector3(2.77f, 0.38f, 0.0f), transform.rotation);
        see = true;
    }
    public void killhear()
    {
        Destroy(Hear);
        Hear = Instantiate(hearevil, new Vector3(-0.77f, -0.56f, 0.0f), transform.rotation);
        hear = true;
    }
    public void killsay()
    {
        Destroy(Say);
        Say = Instantiate(speakevil, new Vector3(-2.62f, -0.42f, 0.0f), transform.rotation);
        say = true;
    }
    public void plaseSee()
    {
        if (see) { See = Instantiate(seeevil, new Vector3(2.77f, 0.38f, 0.0f), transform.rotation); }
        else { See = Instantiate(seeNoevil, new Vector3(2.77f, 0.38f, 0.0f), transform.rotation); }
    }
    public void plaseHear()
    {
        if (hear) { Hear = Instantiate(hearevil, new Vector3(-0.77f, -0.56f, 0.0f), transform.rotation); }
        else { Hear = Instantiate(hearNoevil, new Vector3(-0.77f, -0.56f, 0.0f), transform.rotation); }
    }
    public void plaseSay()
    {
        Debug.Log("speak");
        if (say) { Say = Instantiate(speakevil, new Vector3(-2.62f, -0.42f, 0.0f), transform.rotation); }
        else { Say = Instantiate(speakNoevil, new Vector3(-2.62f, -0.42f, 0.0f), transform.rotation); }
    }
    public void plaseFoody()
    {
        if (food) { foodD = Instantiate(foodOntable, new Vector3(-3.51f, -0.49f, 0.0f), transform.rotation); GameObject.FindWithTag("mannager").GetComponent<secLdialog>().plgoeat(); }
    }
    public void FirstplaseFoody()
    {
        food = true;
        plaseFoody();

    }
    public void FirstplaseSee()
    {
        see = true;
        Destroy(See);
        plaseSee();
    }
    public void FirstplaseSay()
    {
        say = true;
        Destroy(Say);
        plaseSay();
    }
    public void FirstplaseHear()
    {
        hear = true;
        Destroy(Hear);
        plaseHear();
    }
    public void Exittt() {
        if (foodD != null) {  Destroy(foodD);  }
        if (See != null) { Destroy(See); }
        if (Hear != null) { Destroy(Hear); }
        if (Say != null) { Destroy(Say); }
        if (Water != null) { Destroy(Water); }
        if (Crack != null) { Destroy(Crack); }
    }

}
