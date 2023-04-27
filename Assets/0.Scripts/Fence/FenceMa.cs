using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FenceMa : MonoBehaviour
{
    [SerializeField] Fence[] fences;
    // Start is called before the first frame update
    void Start()
    {
        foreach (var fence in fences)
        {
            fence.Hide();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
