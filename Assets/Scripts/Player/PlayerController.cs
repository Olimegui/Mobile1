using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;
using TMPro;

public class PlayerController : Singleton<PlayerController>
{
    //publics
    [Header("Lerp")]
    public Transform target;
    public float lerpSpeed = 1f;

    public float speed = 1f;

    public string tagToCheckEnemy = "Enemy";
    public string tagToCheckEndLine = "EndLine";

    public bool invencible = false;

    //privates
    private bool _canRun;
    private Vector3 _pos;
    private Transform _transform;
    private float _currentSpeed;
    private Vector3 _startPosition;

    private void Start()
    {
        _startPosition = transform.position;
        ResetSpeed();

        _transform = transform;

        GetComponent<Collider>().enabled = true; // Certifique-se de que o Collider está habilitado
    }

    public GameObject endScreen;

  
    void Update()
    {
        if (!_canRun) return;

        _pos = target.position;
        _pos.y = _transform.position.y;
        _pos.z = _transform.position.z;

        _transform.position = Vector3.Lerp(_transform.position, _pos , lerpSpeed * Time.deltaTime);
        transform.Translate(transform.forward * _currentSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == tagToCheckEnemy)
        {
            if(!invencible) EndGame();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == tagToCheckEndLine)
        {
            if (!invencible) EndGame();
        }
    }

    private void EndGame()
    {
        _canRun = false;
        endScreen.SetActive(true);
    }

    public void StartToRun()
    {
        _canRun = true; 
    }

    public void SetInvencible(bool b = true)
    {
        invencible = b;
    }

    #region POWER UPS
    public void SetPowerUpText(string s)
    {
       // uiTextPowerUp.text = s;
    }
    public void PowerUpSpeedUp(float f)
    {
        _currentSpeed = f;
    }
    public void ResetSpeed()
    {
        _currentSpeed = speed;
    }
    #endregion
}
