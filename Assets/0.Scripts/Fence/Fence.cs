using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fence : MonoBehaviour
{
    public float HP { get; set; }

    public void Hit(float dmg)
    {
        HP -= dmg;

        if (HP <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    public void Show()
    {
        GetComponent<MeshCollider>().enabled = true;
        GetComponent<MeshRenderer>().enabled = true;
    }

    public void Hide()
    {
        GetComponent<MeshCollider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
        transform.GetChild(0).gameObject.SetActive(true);
    }
}
