using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class Player : MonoBehaviour
{
    private Vector2 inputDirection;
    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private float rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    private void Update()
    {

        inputDirection = Vector2.zero;
        if(Input.GetKey(KeyCode.W))
        {
            inputDirection.y += 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            inputDirection.y -= 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputDirection.x -= 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputDirection.x += 1;
            if (inputDirection.magnitude > 0)
            {
                var movementDirection = new Vector3(inputDirection.x, 0f, inputDirection.y).normalized;
                var targetPosition = transform.position + movementSpeed * movementDirection * Time.deltaTime;
                var targetLookRotation = Vector3.Slerp(transform.forward, movementDirection, Time.deltaTime * rotationSpeed);
                    transform.SetPositionAndRotation(targetPosition, Quaternion.LookRotation(targetLookRotation,Vector3.up));
            }
        }
    }
}
