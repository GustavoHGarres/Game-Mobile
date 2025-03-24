using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invencible : MonoBehaviour
{  
    //public bool invencible = false;
     
    public void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.tag == "Player")
        {
           
                PlayerController.SetInvencible();
                Destroy(gameObject);
        }
    }
   
}


