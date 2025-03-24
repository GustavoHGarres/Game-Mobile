using System.Collections;
using System.Collections.Generic;
using UnityEngine;

  public class PlayerController : MonoBehaviour

  
{
    //Publics
    [Header("Lerp")]
    public Transform target;
    public float lerpSpeed = 1f;

    static public float speed = 1f;
    public string tagToChecKEnemy = "Enemy";
    public string tagToChecKEndLine = "EndLine";

    static public bool invencible = false;

        

    public GameObject endScreen;

    //Privates
    private bool _canRun;
    private Vector3 _pos;
   // private float _currentSpeed;
   // private Vector3 _startPosition;

   // private void Start()    
   // {        
        //_startPosition = transform.position;        
       // ResetSpeed();    
   // }

      public PlayerController Invencible;
     
     
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
            if(!invencible) EndGame();
        }      
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == tagToChecKEndLine)
        {
             if(!invencible) EndGame();
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

   static public void SetInvencible() 
    {     
        invencible = true;
    }

    
   // protected virtual void SpawnObject()
   // {
        // var obj = Instantiate(prefab, transform);
   // }

    //#region POWER UPS

     //public void SetPowerUpText(string s)    
    // {        
        //uiTextPowerUp.text = s;    
    // } 

   //  public void PowerUpSpeedUp1(float f)   
   // {       
       // _currentSpeed = f;    
    // }  
     
    // public void ResetSpeed()   
   //  {       
    //    _currentSpeed = speed;   
    // }

   // #endregion 
}

