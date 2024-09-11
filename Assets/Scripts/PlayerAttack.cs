using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private bool canMultiple;
    private float attackSpeed = 1.0f;

    private float stateTimer = 0.0f;    

    public enum State
    { 
       None,
       Charge,
       AfterAttack
    }


}
