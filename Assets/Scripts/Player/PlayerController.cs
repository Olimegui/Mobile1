using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //publics
    [Header("Lerp")]
    public Transform target;
    public float lerpSpeed = 1f;

    public float speed = 1f;

    public string tagToCheckEnemy = "Enemy";
    public string tagToCheckEndLine = "EndLine";

    //privates
    private bool _canRun;
    private Vector3 _pos;
    private Transform _transform;

    public GameObject endScreen;

    void Start()
    {
        _transform = transform;

        GetComponent<Collider>().enabled = true; // Certifique-se de que o Collider est� habilitado
    }

    void Update()
    {
        if (!_canRun) return;

        _pos = target.position;
        _pos.y = _transform.position.y;
        _pos.z = _transform.position.z;

        _transform.position = Vector3.Lerp(_transform.position, _pos , lerpSpeed * Time.deltaTime);
        _transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == tagToCheckEnemy)
        {
            EndGame();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == tagToCheckEndLine)
        {
            EndGame();
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
}
