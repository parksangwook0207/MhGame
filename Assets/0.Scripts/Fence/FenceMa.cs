using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FenceMa : MonoBehaviour
{
    [SerializeField] FenceObj[] fences;
    [SerializeField] public Mesh[] meshs;
    // Start is called before the first frame update
    void Start()
    {
        foreach (var fence in fences)
        {
            fence.Show();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
