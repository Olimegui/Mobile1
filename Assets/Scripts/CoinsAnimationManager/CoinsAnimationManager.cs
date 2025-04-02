using System.Collections;
using System.Linq;      
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;
using DG.Tweening;

public class CoinsAnimationManager : Singleton<CoinsAnimationManager>
{
    public List<ItemCollactableCoin> items;

    [Header("Animation")]
    public float scaleDuration = .2f;
    public float scaleTimeBetweenPieces = .1f;
    public Ease ease = Ease.OutBack;

    private void Start()
    {
        items = new List<ItemCollactableCoin>();
    }
 
    public void RegisterCoin(ItemCollactableCoin i)
    {
        if (!items.Contains(i))
        {

            items.Add(i);
            i.transform.localScale = Vector3.zero;
        }
        

    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            StartAnimation();
        }
    }

    public void StartAnimation()
    {
        StartCoroutine(ScalePiecesByTime());
    }
    IEnumerator ScalePiecesByTime()
    {
        foreach (var p in items)
        {
            p.transform.localScale = Vector3.zero;
        }

        Sort();

        yield return null;

        for (int i = 0; i < items.Count; i++)
        {
            items[i].transform.DOScale(1, scaleDuration).SetEase(ease);
            yield return new WaitForSeconds(scaleTimeBetweenPieces);

        }
    }
    
    private void Sort()
    {
        items = items.OrderBy(
            x => Vector3.Distance(this.transform.position, x.transform.position)).ToList();

    }
}
