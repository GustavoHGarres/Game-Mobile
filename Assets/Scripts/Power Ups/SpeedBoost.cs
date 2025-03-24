using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{

   public float multipler =  1.5f;
   
   private void OnTriggerEnter(Collider other)
   {
     if (other.gameObject.tag == "Player")
    {
        PlayerController.speed *= multipler;
        Destroy(gameObject);
    }
   }
}
