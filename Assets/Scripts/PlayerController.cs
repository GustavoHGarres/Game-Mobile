using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

  public class PlayerController : MonoBehaviour

  
{
    //Publics
    [Header("Lerp")]
    public Transform target;
    public float lerpSpeed = 1f;

    static public float speed = 2f;
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

      [SerializeField] private BounceHelper _bounceHelper;  // DOTeween do Player 

      [Header("Animation")]
      public AnimatorManger animatorManager;
     
     
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
           MoveBack();
            if(!invencible) 
            {
            EndGame(AnimatorManger.AnimationType.DEAD);
            }
        }      
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == tagToChecKEndLine)
        {
             if(!invencible) EndGame();
        }
    }

    private void MoveBack()
   {
        transform.DOMoveZ(-1f, .3f).SetRelative();
   }

    private void EndGame(AnimatorManger.AnimationType animationType = AnimatorManger.AnimationType.IDLE)
    {
         _canRun = false;
         endScreen.SetActive(true);
         animatorManager.Play(animationType);
    }

    public void StartRun()
    {
        _canRun = true;
        animatorManager.Play(AnimatorManger.AnimationType.RUN);
        
    }

   static public void SetInvencible() 
    {     
        invencible = true;
    }



   // DOTeween do Player
   public void Bounce()
   {
    if(_bounceHelper != null)
    _bounceHelper.Bounce();
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

