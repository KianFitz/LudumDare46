using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float MaxCharge { get; set; }

    private float charge;
    public float Charge { 
        get { 
            return charge; 
        }
        set { 
            charge = value;
            if (charge <= 0) {
                onDeath();
            }
            else if (charge > MaxCharge) {
                charge = MaxCharge;
            }
        }
    }

    private Action onDeath;

    public void SubscribeToOnDeathCallback(Action callback) {
        onDeath += callback;
    }   
}
