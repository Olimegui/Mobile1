using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;
using TMPro;
using DG.Tweening;

public class PlayerController : Singleton<PlayerController>
{
    //publics
    [Header("Lerp")]
    public Transform target;
    public float lerpSpeed = 1f;
    public GameObject endScreen;

    public float speed = 1f;

    public string tagToCheckEnemy = "Enemy";
    public string tagToCheckEndLine = "EndLine";

    [Header("TextMeshPro")]
    public TextMeshPro uiTextPowerUp;

    public bool invencible = false;

    [Header("Coin Setup")]
    public GameObject coinCollector;

    [Header("Animation")]
    public AnimatorManager animatorManager;

    [Header("VFX")]
    public ParticleSystem vfxDeath;

    [Header("Limits")]
    public float limit = 4;
    public Vector2 limitVector = new Vector2(-4, 4);

    [SerializeField] private BounceHelper _bounceHelper;

    //privates
    private bool _canRun;
    private bool canMove = true;
    private Vector3 _pos;
    private Transform _transform;
    private float _currentSpeed;
    private Vector3 _startPosition;
    private float _baseSpeedToAnimation = 7;

    private void Start()
    {
        _startPosition = transform.position;
        ResetSpeed();

        _transform = transform;

        GetComponent<Collider>().enabled = true; // Certifique-se de que o Collider est� habilitado
    }

    public void Bounce()
    {
        if(_bounceHelper != null) 
        
          _bounceHelper.Bounce();
    }


    void Update()
    {
        if (!canMove) return;

        if (!_canRun) return;

        _pos = target.position;
        _pos.y = _transform.position.y;
        _pos.z = _transform.position.z;

        if (_pos.x < limitVector.x) _pos.x = limitVector.x;
        else if (_pos.x > limitVector.y) _pos.x = limitVector.y;

        _transform.position = Vector3.Lerp(_transform.position, _pos, lerpSpeed * Time.deltaTime);
        transform.Translate(transform.forward * _currentSpeed * Time.deltaTime);
    }

    public void StopPlayer()
    {
        canMove = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == tagToCheckEnemy)
        {
            if (!invencible)
            {
                MoveBack();
                EndGame(AnimatorManager.AnimationType.DEAD);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == tagToCheckEndLine)
        {
            if (!invencible) EndGame();
        }
    }

    private void MoveBack()
    {
        transform.DOMoveZ(1f, .3f).SetRelative();
    }

    private void EndGame(AnimatorManager.AnimationType animationType = AnimatorManager.AnimationType.IDLE) 
    {
        _canRun = false;
        endScreen.SetActive(true);
        animatorManager.Play(animationType);
        if(vfxDeath != null) vfxDeath.Play();
    }

    public void StartToRun()
    {
        _canRun = true;
        animatorManager.Play(AnimatorManager.AnimationType.RUN,_currentSpeed / _baseSpeedToAnimation);
    }

    public void SetInvencible(bool b = true)
    {
        invencible = b;
    }

    #region POWER UPS
    public void SetPowerUpText(string s)
    {
        uiTextPowerUp.text = s;
    }
    public void PowerUpSpeedUp(float f)
    {
        _currentSpeed = f;
    }
    public void ResetSpeed()
    {
        _currentSpeed = speed;
    }

    public void ChangeHeight(float amount, float duration, float animationDuration, Ease ease)
    {
        /*var p = transform.position;
        p.y = _startPosition.y + amount;
        transform.position = p;*/

        transform.DOMoveY(_startPosition.y + amount, animationDuration).SetEase(ease);//.OnComplete(ResetHeight);a
        Invoke(nameof(ResetHeight), duration);
    }

    public void ResetHeight()
    {
        transform.DOMoveY(_startPosition.y, .1f);
    }

    public void ChangeCoinCollectorSize(float amount)
    {
        coinCollector.transform.localScale = Vector3.one * amount;

        #endregion
    }
}
