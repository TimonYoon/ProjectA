using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager instance
    {
        get;
        private set;
    }
    
    

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        
    }
}
