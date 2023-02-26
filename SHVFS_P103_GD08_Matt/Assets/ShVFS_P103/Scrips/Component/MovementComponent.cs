using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MovementComponent : MonoBehaviour
{
    public InputComponentBase InputComponent;
    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private float rotationSpeed;
    [SerializeField]
    private float playerWidth;
    [SerializeField]
    private float playerHeight;
    private float movementDistance => movementSpeed * Time.deltaTime;

    private void Update()
    {
        if (!(InputComponent.GetInputDirectionNormalized().magnitude > 0f)) return;

        var movementDirection = new Vector3(InputComponent.GetInputDirectionNormalized().x, 0f, InputComponent.GetInputDirectionNormalized().y);
        var targetLookRotation = Vector3.Slerp(transform.forward, movementDirection, Time.deltaTime * rotationSpeed);
        transform.rotation = Quaternion.LookRotation(targetLookRotation, Vector3.up);

        if (TryMove(movementDirection)) return;

        if (TryMove(new Vector3(movementDirection.x, 0f, 0f).normalized)) return;

        TryMove(new Vector3(0f, 0f, movementDirection.z).normalized);
    }

    private bool TryMove(Vector3 direction)
    {
        var hits = Physics.CapsuleCastAll(transform.position, transform.position + Vector3.up * playerHeight, playerWidth, direction, movementDistance);

        // Limit nesting, it makes it hard to follow what's going on
        if (hits.Length >= 1)
        {
            if (!hits.All(hit => hit.transform.GetComponent<StructureComponent>() == null)) return false;

            Move(direction);
            return true;
        }

        Move(direction);
        return true;
    }

    private void Move(Vector3 direction)
    {
        var targetPosition = transform.position + movementSpeed * direction * Time.deltaTime;
        transform.position = targetPosition;
    }
    /*[SerializeField]
    //private PlayerInputComponent playerInputComponet;*/
    //[SerializeField]
    //public InputComponentBase InputComponent;
    //[SerializeField]
    //private float movementSpeed = 5;
    //[SerializeField]
    //private float rotateSpeed;
    //[SerializeField]
    //private float playerWidth;
    //[SerializeField]
    //private float playerHeight;

    //private float movementDistance => movementSpeed * Time.deltaTime;

    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //private void Update()
    //{
    //   /* Vector2 inputDirection = GetComponent<PlayerInputComponent>().GetInputDirection();
    //    if (inputDirection.magnitude > 0)
    //    {

    //        var movementDirection = new Vector3(inputDirection.x, 0f, inputDirection.y).normalized;
    //        var targetPosition = transform.position + movementSpeed * movementDirection * Time.deltaTime;
    //        var targetLookRotation = Vector3.Slerp(transform.forward, movementDirection, Time.deltaTime * rotateSpeed);
    //        transform.SetPositionAndRotation(targetPosition, Quaternion.LookRotation(targetLookRotation, Vector3.up));

    //    }*/
    //    if (!(InputComponent.GetInputDirectionNormalized().magnitude > 0f)) return;
    //    var movementDirection = new Vector3(InputComponent.GetInputDirectionNormalized().x,0f,InputComponent.GetInputDirectionNormalized().y); 
    //    var targetLookRotation = Vector3.Slerp(transform.forward, movementDirection, Time.deltaTime * rotateSpeed);
    //    transform.rotation = Quaternion.LookRotation(targetLookRotation, Vector3.up);
    //    var canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight,playerWidth,movementDirection, movementDistance);

    // /*   if (canMove)
    //    {
    //        var targetPosition = transform.position + movementSpeed * movementDirection * Time.deltaTime;
    //        transform.position = targetPosition;
    //        return;
    //    }*/

    //    if (TryMove(movementDirection)) return;

    //    if(TryMove(new Vector3(movementDirection.x,0f,0f).normalized)) return;

    //    TryMove(new Vector3(0f,0f,movementDirection.z).normalized);

    //    /*var movementDirectionX = new Vector3(movementDirection.x, 0f, 0f).normalized;
    //    bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerWidth, movementDirectionX, movementDistance);
    //    if (canMove)
    //    {
    //        var targetPositions = transform.position + movementSpeed * movementDirectionX * Time.deltaTime;
    //        transform.position = targetPositions;
    //        return;

    //    }
    //    var movementDirectionZ = new Vector3(0f, 0f, movementDirection.z).normalized;
    //    canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerWidth, movementDirectionZ, movementDistance);

    //    if (canMove)
    //    {
    //        var targetPosition = transform.position + movementSpeed * movementDirectionZ * Time.deltaTime;
    //        transform.position = targetPosition;
    //    }*/

    //}
    //private bool TryMove(Vector3 direction)
    //{
    //    var canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerWidth, direction, movementDistance);

    //    if (canMove)
    //    {
    //        var targetPosition = transform.position + movementSpeed * direction * Time.deltaTime;
    //        transform.position = targetPosition;
    //        return true;
    //    }
    //    return false;
    //}

}