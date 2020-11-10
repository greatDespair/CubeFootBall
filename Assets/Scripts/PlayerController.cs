using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float sensivity;         //сенса
    private Vector3 mousePos;
    private float MyAngle = 0F;

    public float speed;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    void Update()
    {
        mousePos = Input.mousePosition;
    }

    void FixedUpdate()
    {
        MouseRotate();
        MovementLogic();
    }

    private void MovementLogic()            //Движение
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        transform.Translate(movement * speed);
    }

    private void MouseRotate()          //Крутить башкой
    {
        if (Input.GetMouseButton(0))
        {
            MyAngle = 0;
            MyAngle = sensivity * ((mousePos.x - (Screen.width / 2)) / Screen.width);

            transform.RotateAround(transform.position, transform.up, MyAngle);
        }
    }
}