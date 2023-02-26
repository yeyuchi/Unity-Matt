using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//abstract members can't be used directly
//we inherit from them and implement them

public abstract class InputComponentBase : MonoBehaviour
{
    public abstract Vector2 GetInputDirection();
    public abstract Vector2 GetInputDirectionNormalized();
}




