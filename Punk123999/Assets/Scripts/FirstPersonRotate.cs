using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FirstPersonRotate : MonoBehaviour
{
    public Vector2 mouseDelta;
    public float camYOffset = 4;
    public float radius = 4;
    public float sensitivity = 0.2f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 parentPosition = gameObject.transform.parent.position;
        transform.position = new Vector3(parentPosition.x, parentPosition.y + camYOffset, parentPosition.z);
        transform.eulerAngles = transform.eulerAngles - new Vector3(mouseDelta.y * sensitivity, mouseDelta.x * -1 * sensitivity, 0);

    }

    void OnCameraLookUp(InputValue value)
    {
        mouseDelta = value.Get<Vector2>();
    }
}
