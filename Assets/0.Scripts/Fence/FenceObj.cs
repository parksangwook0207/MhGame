using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceObj : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Build()
    {
        transform.parent.GetComponent<Fence>().Show();
        gameObject.SetActive(false);
    }
}
