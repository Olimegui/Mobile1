using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BounceHelper : MonoBehaviour
{
    [Header("Animation")]
    public float scaleDuration = .2f;
    public float scaleTimeBetweenPieces = .1f;
    public Ease ease = Ease.OutBack;
    public Vector3 scaleBounce = new Vector3(1f, 1f, 1f);

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Bounce();
        }
    }

    public void Bounce()
    {
        transform.DOScale(scaleBounce, scaleDuration)
            .SetEase(ease)
            .SetLoops(2, LoopType.Yoyo);
    }
}
