using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events; 

public class Goal : MonoBehaviour {

    public UnityEvent onGoal;
    void OnTriggerEnter(Collider other)
    {
        //check if onGoal event exists
        if(onGoal != null)
        {
            //invoke event
            onGoal.Invoke();
        }
    }
		
	}

