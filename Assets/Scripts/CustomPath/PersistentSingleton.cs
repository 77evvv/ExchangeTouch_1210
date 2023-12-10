using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentSingleton<T> : MonoBehaviour where T :Component
{
    public static T Instance { get;private set; }
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this as T;
        }
        else if (Instance != this)
        {
            Destroy((gameObject));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
