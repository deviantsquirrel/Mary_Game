using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class compa : MonoBehaviour
{
    [SerializeField] GameObject arrow;
    bool hardir=true;
    public float rotationSpeed = 100f;
    public float maxRotationAngle = 350f;

    private float currentRotationAngle;
    private bool rotateClockwise = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!hardir)
        {
            if (rotateClockwise)
            {
                currentRotationAngle += rotationSpeed * Time.deltaTime;
                if (currentRotationAngle >= maxRotationAngle)
                {
                    currentRotationAngle = maxRotationAngle;
                    rotateClockwise = false;
                }
            }
            else
            {
                currentRotationAngle -= rotationSpeed * Time.deltaTime;
                if (currentRotationAngle <= -maxRotationAngle)
                {
                    currentRotationAngle = -maxRotationAngle;
                    rotateClockwise = true;
                }
            }

            // Apply the rotation to the object
            arrow.transform.rotation = Quaternion.Euler(0f, 0f, currentRotationAngle);
        }
        else
        {
            arrow.transform.rotation = Quaternion.Euler(0f, 0f, -90f);
        }
    }
    public void Falsedir() { hardir= false; }
    public void Truedir() { hardir= true; }
}
