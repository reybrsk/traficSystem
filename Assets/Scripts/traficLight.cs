using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class traficLight : MonoBehaviour
{
   [HideInInspector]public Color color;
   private Car _targetCar;
   private float _t;
   public int secondWait = 3;

   private void Start()
   {
      color = Color.red;
   }

   private void Update()
   {
      _t += Time.deltaTime;
      if (_t > secondWait)
      {
         ChangeColor();
         _t = 0f;
            
      }
   }

   private void OnTriggerStay(Collider other)
   {
      if (other.gameObject.name == "Locator") 
      {
         _targetCar = other.gameObject.GetComponentInParent<Car>();
         if (color == Color.red && _targetCar.canMove)
         {
            _targetCar.canMove = false;
            Debug.Log("trafficLight - " + color);
            Debug.Log("target Car - " + _targetCar.gameObject.name);
         }

         if (color == Color.green && !_targetCar.canMove)
         {
            _targetCar.canMove = true;
            Debug.Log("You are WELLCOME, mr. President");
         }
      }
      
   }



   private void OnDrawGizmos()
   {
      Gizmos.color = color;
      Gizmos.DrawCube(transform.position, Vector3.one);
   }

   private void ChangeColor()
   {
      
      if (color == Color.green)
      {
         color = Color.red;
      }
      
      else color = Color.green;
   }


}
