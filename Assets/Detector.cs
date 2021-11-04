using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{

    [SerializeField] private GameObject targetLocator;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Locator") 
        {
            if (other.gameObject == targetLocator) return;
            
            var targetCar = gameObject.GetComponentInParent<Car>();
            var otherCar = other.gameObject.GetComponentInParent<Car>();

            if (otherCar.isPlayWithThisCar == targetCar) return;

            if (Vector3.Distance(transform.forward, other.transform.forward) <
                Vector3.Distance(-transform.forward, other.transform.forward))
            {
                bool isWin = Knb.Play(targetCar, otherCar);
           
                Debug.Log( "KNB RESULT IS " + isWin);
                Debug.Log(targetCar.gameObject.name);

                if (isWin)
                {
                    otherCar.YouLose(targetCar);
                    targetCar.isPlayWithThisCar = otherCar;
                }
                else
                {
                    targetCar.YouLose(otherCar);
                    otherCar.isPlayWithThisCar = targetCar;
                }
            }
            else
            {
                otherCar.YouLose(targetCar);
                targetCar.isPlayWithThisCar = otherCar;
            }
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Locator") 
        {
            other.GetComponentInParent<Car>().YouCanMove();
            Debug.Log("Thanks " + other.transform.parent.name + "for Wait");
        }
    }
}

