using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.right * Time.deltaTime * 1f);

        if (transform.rotation.x < 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0f, -30f, 0));
        }
    }

}
