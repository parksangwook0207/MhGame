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
            Hide();
            transform.parent.GetComponent<FenceObj>().Show();
        }
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        
        gameObject.SetActive(false);
    }
}
