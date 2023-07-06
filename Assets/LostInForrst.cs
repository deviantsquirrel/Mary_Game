using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LostInForrst : MonoBehaviour
{
    private int step;
    private bool RightDirection;
    private bool GoAhead;

    void Start()
    {
        step = 0;
        RightDirection = true;
        GoAhead = false;
    }   

    public void CheakDirection(int direction)
    {
        if(step==6) { step= 0; RightDirection = true; }
        if (step == 0 && direction!=1) { RightDirection = false; }
        if (step == 1 && direction!=3) { RightDirection = false; }
        if (step == 2 && direction != 2) { RightDirection = false; }
        if (step == 3 && direction != 3) { RightDirection = false; }
        if (step == 4 && direction != 4) { RightDirection = false; }
        if (step == 5 && RightDirection == true && direction == 1) {
            GoAhead = true;
        }
        Debug.Log(RightDirection);
        Debug.Log(GoAhead);
        step++;
    }

    public bool FullCycle()
    {
        return (step == 6) ? true : false;
    }

    public bool AllRihgt()
    {
        return GoAhead;
    }
}