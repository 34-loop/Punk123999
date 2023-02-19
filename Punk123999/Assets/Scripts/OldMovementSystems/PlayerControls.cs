using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    public Transform camTransform;
    Rigidbody rb;
    [Header("Parameters")]
    public float turnSmoothTime = 0.1f;
    public float turnSmoothVelocity;
    public float speed = 1.0f;
    public Vector2 movement;
    public Vector3 moveDir;
    public float jumpForce = 200;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Поворот с учетом того куда смотрит камера
        float targetAngle = Mathf.Atan2(movement.x, movement.y) * Mathf.Rad2Deg + camTransform.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        transform.rotation = Quaternion.Euler(0, angle, 0);

        moveDir = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;

        transform.position = transform.position + moveDir * speed * Time.deltaTime;
    }
    private void OnMovement(InputValue value)
    {
        movement = value.Get<Vector2>();

    }
    private void OnJump(InputValue value)
    {
        //Пофиксить двойной прыжок
        rb.AddForce(0, jumpForce, 0);
    }
}
