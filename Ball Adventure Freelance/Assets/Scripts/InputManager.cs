using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    public static InputManager instance;
    public Inputs inputActions { private set; get; }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        inputActions = new Inputs();
        inputActions.Enable();
    }
}
