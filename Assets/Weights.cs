using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weights : MonoBehaviour
{
    public static Weights Instance { get; private set; }
    // Start is called before the first frame update
    private int Smart = 0;
    private int Dexterous = 0;
    private int Curious = 0;
    private int Obidient = 0;
    private int Violent = 0;
    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
    }

    public void ReadBook(int num)
    {
        if (num == 1)
        {
            Dexterous += 5;
            Curious += 5;
            Violent += 5;
            Obidient -= 5;
            Debug.Log(Dexterous + "Dexterous" + Curious + "Curious");
        }else if(num == 2)
        {
            Smart += 5;
            Curious += 5;
            Dexterous -= 5;

        }else if(num == 3)
        {
            Obidient += 5;
            Violent += 5;
            Smart -= 5;
        }
    }
    public void AddDexterity(int aa)
    {
        Dexterous += aa;
    }
   
}
