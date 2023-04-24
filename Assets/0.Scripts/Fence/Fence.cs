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
}
