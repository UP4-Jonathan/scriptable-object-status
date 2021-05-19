using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleCharacter : MonoBehaviour
{
    [SerializeField] MoveCheckBuilder checkBuilder;
    public Dictionary<NameVariable,bool> moveChecks = new Dictionary<NameVariable, bool>();
    

    //used to simulate stunning/breaking a stun through a character skill
    [SerializeField] NameVariable stunVariable;

    private void Awake() 
    {
        foreach(MoveCheck check in checkBuilder.checks)
            moveChecks[check.nameVariable] = check.value;    
    }

    //simulates stun skill use
    public void OnStunInput()
    {
        moveChecks[stunVariable] = !moveChecks[stunVariable];
    }
}
