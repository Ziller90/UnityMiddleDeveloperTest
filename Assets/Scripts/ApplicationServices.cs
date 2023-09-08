using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[DefaultExecutionOrder(ExecutionOrder)]
public class ApplicationServices : MonoBehaviour
{
    [SerializeField] GameObject[] serviceObjects;

    public const int ExecutionOrder = -500;

    Type serviceType = typeof(Service<>);
    string instancePropertyName = nameof(Service<UnityEngine.Object>.Instance);
    string registerMethodName = nameof(Service<UnityEngine.Object>.Register);

    private void Awake() {
        foreach(var serviceObject in serviceObjects)
            RegisterService(serviceObject.GetComponent<MonoBehaviour>());
    }

    void RegisterService(MonoBehaviour service) {
        var newGenericType = serviceType.MakeGenericType(service.GetType());
        newGenericType.GetMethod(registerMethodName).Invoke(null, new[] { service });
    }
}
