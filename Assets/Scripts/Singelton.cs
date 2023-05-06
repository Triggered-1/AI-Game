using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    public static T Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null) Instance = (T)this;
        else throw new System.Exception($"There already exists " + $"a singleton in this scene of type: {GetType()}");

    }
}