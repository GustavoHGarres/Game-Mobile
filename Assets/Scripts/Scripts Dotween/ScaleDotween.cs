
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ScaleDotween : MonoBehaviour
{

//public float duration;
//public Ease dotEase;
public float duration = .2f;
public float dotEase = 1.2f;
public Ease ease = Ease.OutBack;


    void Start()
    {
       // transform.DOScale(Vector3.zero, duration).SetEase(dotEase);
       transform.DOScale(dotEase, duration).SetEase(ease).SetLoops(2, LoopType.Yoyo);
    }

    
}
