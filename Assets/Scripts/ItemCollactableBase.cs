using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class ItemCollactableBase : MonoBehaviour
{
    public string comparetag = "Player";
    public ParticleSystem particleSystem;
    public AudioSource audioSource;
    public float timeToHide = 3;
    public GameObject graphicItem;

    public PlayerController playerController; // BounceHelper

    
    public void Awake()
    {
        if (particleSystem != null) particleSystem.transform.SetParent(null);
    }
        
        private void OnTriggerEnter(Collider collision)
    {
        if(collision.transform.CompareTag(comparetag))
       {
         Collect();
       }
    }

   // protected virtual void Collect()
      public void Collect()
    {
        if (graphicItem != null) graphicItem.SetActive(false);
        Invoke("HideObject", timeToHide);
        OnCollect();
        playerController.Bounce(); //BounceHelper       
    }  

    private void HideObject()
    {
         gameObject.SetActive(false);
    }

    protected virtual void OnCollect()
    {
        if(particleSystem != null) particleSystem.Play();
        if (audioSource != null) audioSource.Play();
      

    }


  
}



