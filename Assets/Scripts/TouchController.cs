using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    public Vector2 pastPosition;
    public float velocity = 1f;
    public float forwardSpeed = 1f;
    public bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        pastPosition = Input.mousePosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (!canMove) return;

        if (Input.GetMouseButton(0))
        {
            //Debug.Log("mouse pressionado");
            //mousePosition AGORA - mousePosition passado
            Move(Input.mousePosition.x - pastPosition.x);
            pastPosition = Input.mousePosition;
        }
        transform.position += Vector3.forward * Time.deltaTime * forwardSpeed;
    }

    public void Move(float speed)
    {
        //Debug.Log("movendo" + speed);
        transform.position += Vector3.right * Time.deltaTime * speed * velocity;
    }
}
