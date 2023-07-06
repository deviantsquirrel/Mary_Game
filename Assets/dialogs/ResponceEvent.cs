using System;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class ResponceEvent 
{
    [HideInInspector] public string name;
    [SerializeField] private UnityEvent onPickedResponse;

    public UnityEvent OnPickedResponse => onPickedResponse;
}
