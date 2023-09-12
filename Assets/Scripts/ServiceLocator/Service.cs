using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Service<T> where T : UnityEngine.Object
{
    public static T Instance { get; private set; }

    public static void Register(T instance)
    {
        Instance = instance;    
    }
}   
