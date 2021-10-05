using System;
using System.Collections.Generic;
using UnityEngine;

public static class ServiceLocator 
{
    private static Dictionary<Type, object> _services = new Dictionary<Type, object>();

    public static void Register<T>(T services) where T : class
    {
        if (_services.ContainsKey(typeof(T)))
        {
            Debug.Log("This service already was registered.");
            return;
        }
        else
        {
            _services[typeof(T)] = services;
        }
    }

    public static void Unregister<T>() where T : class
    {
        if (_services.ContainsKey(typeof(T)))
        {
            _services.Remove(typeof(T));
        }
        else
        {
            Debug.Log("This service already was unregistered.");
            return;
        }
    }

    public static T Resolve<T>() where T : class
    {
        if (_services.ContainsKey(typeof(T)))
        {
            return (T)_services[typeof(T)];
        }
        else
        {
            Debug.Log($"Service with type {typeof(T)} did not was registered");
            return null;
        }
    }
}
