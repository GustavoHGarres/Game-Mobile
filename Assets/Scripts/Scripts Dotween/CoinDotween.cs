using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

// Cresce e diminui em loop

public class CoinDotween : MonoBehaviour
{
    private Vector3 _originalScale;
    private Vector3 _scaleTo;

    void Start()
    {
        _originalScale = transform.localScale;
        _scaleTo = _originalScale * 2;

        transform.DOScale(_scaleTo, 2f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
       
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
