using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    public float speed = 1.0f;
    public Vector2 movement;
    public float jumpForce = 10000;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.right*movement.x+Vector3.forward*movement.y) * speed * Time.deltaTime;
    }
    private void OnMovement(InputValue value)
    {
        movement = value.Get<Vector2>();

    }
    private void OnJump(InputValue value)
    {
        //Пофиксить двойной прыжок
        Debug.Log("Jumped");
        rb.AddForce(0, jumpForce, 0);
    }
}
