using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputComponent : InputComponentBase
{
    // private Vector2 inputDirection;
    private PlayerActions playerActions;

    private void Awake()
    {
        playerActions = new PlayerActions();
        playerActions.PlayerInput.Enable();
    }

    // // Make the player move forward, back, left, right
    // private void Update()
    // {
    //     inputDirection = Vector2.zero;
    //     
    //     if (Input.GetKey(KeyCode.W))
    //     {
    //         inputDirection.y += 1;
    //         // Debug.Log("W");
    //     }
    //     if (Input.GetKey(KeyCode.S))
    //     {
    //         inputDirection.y -= 1;
    //         // Debug.Log("S");
    //     }
    //     if (Input.GetKey(KeyCode.A))
    //     {
    //         inputDirection.x -= 1;
    //         // Debug.Log("A");
    //     }
    //     if (Input.GetKey(KeyCode.D))
    //     {
    //         inputDirection.x += 1;
    //         // Debug.Log("D");
    //     }
    // }

    public override Vector2 GetInputDirection()
    {
        return playerActions.PlayerInput.Movement.ReadValue<Vector2>();
    }

    public override Vector2 GetInputDirectionNormalized()
    {
        return GetInputDirection().normalized;
    }
}
//abstract members can't be used directly
//we inherit from them and implement them

//public abstract class InputComponentBase : MonoBehaviour
//{
//    public abstract Vector2 GetInputDirection();
//    public abstract Vector2 GetInputDirectionNormalized();
//}

//public class PlayerInputComponent : InputComponentBase
//{
//    private PlayerActions playerActions;
//    public Animator animator;
//    //private Vector2 inputDirection;
//    private void Awake()
//    {
//        playerActions = new PlayerActions();
//        playerActions.PlayerInput.Enable();
//    }
//    // Start is called before the first frame update
//    void Start()
//    {
//        //rigidbody = gameObject.GetComponent<Rigidbody>();
//        animator = gameObject.GetComponent<Animator>();
//    }

//    // Update is called once per frame
//    public void Update()
//    {
//        /*inputDirection = Vector2.zero;
//        if (Input.GetKey(KeyCode.W))
//        {
//            //transform.position += new Vector3(1, 0, 0);
//            inputDirection.y += 1;
//        }
//        else if (Input.GetKey(KeyCode.S))
//        {
//            //transform.position -= new Vector3(1, 0, 0);
//            inputDirection.y -= 1;
//        }
//        else if (Input.GetKey(KeyCode.A))
//        {
//            //transform.position += new Vector3(0,0, 1);\
//            inputDirection.x -= 1;
//        }
//        else if (Input.GetKey(KeyCode.D))
//        {
//            //transform.position -= new Vector3(0, 0, 1);
//            inputDirection.x += 1;
//        }
//        //transform.position += new Vector3(inputDirection.x, 0, inputDirection.y);

//*/
//    }

//    public override Vector2 GetInputDirection()
//    {
//        return playerActions.PlayerInput.Movement.ReadValue<Vector2>();
//    }

//    public override Vector2 GetInputDirectionNormalized()
//    {
//        return GetInputDirection().normalized;
//    }

//  }

