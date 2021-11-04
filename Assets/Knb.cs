using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Knb
{
   public static bool Play(Car me, Car enemy)
   {
      while (true)
      {
         
         var myHand = me.CuEFa();
         var enemyHand = enemy.CuEFa();
         Debug.Log($"KNB");
         switch (myHand)
         {
            case 0 when enemyHand == 1:
            case 1 when enemyHand == 2:
            case 2 when enemyHand == 0:
               return true;
            case 0 when enemyHand == 2:
            case 1 when enemyHand == 0:
            case 2 when enemyHand == 1:
               return false;
            default:
            {
               Debug.Log("REPLAY");
               continue;
            }
         }
         break;
      }
      
      
   }
}
