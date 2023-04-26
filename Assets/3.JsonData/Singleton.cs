using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance { get; private set; }

    void Awake() => Instance = FindObjectOfType(typeof(T)) as T; 
    

}
