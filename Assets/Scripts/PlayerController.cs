using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    //Publics
    [Header("Lerp")]
    public Transform target;
    public float lerpSpeed = 1f;

    public float speed = 1f;
    public string tagToChecKEnemy = "Enemy";
    public string tagToChecKEndLine = "EndLine";

    public GameObject endScreen;

    //Privates
    private bool _canRun;
    private Vector3 _pos;

   
       
      void Update()
    {
        if(!_canRun) return;
        _pos = target.position;
        _pos.y = transform.position.y;
        _pos.z = transform.position.z;

        transform.position = Vector3.Lerp(transform.position, _pos, lerpSpeed * Time.deltaTime);
        transform.Translate(transform.forward * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == tagToChecKEnemy)
        {
            EndGame();
        }      
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == tagToChecKEndLine)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
         _canRun = false;
         endScreen.SetActive(true);
    }

     public void StartRun()
    {
        _canRun = true;
    }
}
