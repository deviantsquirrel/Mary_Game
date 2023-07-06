using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bookcase : MonoBehaviour
{
    private GameObject manager;
    
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindWithTag("mannager");
        
    }

    public void Pirate()
    {
        Weights.Instance.ReadBook(1);
    }
    public void Solder()
    {
        Weights.Instance.ReadBook(3);
    }
    public void Scientist()
    {
        Weights.Instance.ReadBook(2);
    }
    public void PickAlbum()
    {
        manager.GetComponent<lugge>().AddAlbum();

    }
    public void GoldKeyPiece()
    {
        manager.GetComponent<lugge>().GoldKeyPiece();

    }
    public void AddNewspaper()
    {
        manager.GetComponent<lugge>().AddNewspaper();

    }
    
    public void CloakDelandAdd()
    {
        //manager.GetComponent<lugge>().AddNewspaper();

    }
    
}
