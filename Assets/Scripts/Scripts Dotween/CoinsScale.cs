using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

// Cresce e diminui em loop

public class CoinsScale: MonoBehaviour
{
    private Vector3 _originalScale;
    private Vector3 _scaleTo;
    public float Duration;
    public float Delay;
    public float ScaleBigger;

    void Start()
    {
        _originalScale = transform.localScale;
        _scaleTo = _originalScale * ScaleBigger;

        CoinScale();
       
        
    }

    private void CoinScale()

    {
          //transform.DOScale(_scaleTo, 2f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
            transform.DOScale(_scaleTo, Duration).SetEase(Ease.InOutSine).OnComplete(() =>
            {
                transform.DOScale(_originalScale, Duration).SetEase(Ease.OutBounce).SetDelay(Delay).OnComplete(CoinScale);
            });
    }
}
