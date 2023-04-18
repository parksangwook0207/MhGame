using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    [SerializeField] private GameObject obj;
    [HideInInspector] public float resetTime = 2f;

    float delay = 0;
    bool isHide = false;

    // Update is called once per frame
    void Update()
    {
        if (!isHide)
            return;

        delay += Time.deltaTime;
        if (delay > resetTime)
        {
            delay = 0;
            Show();
        }
    }

    public void Hide()
    {
        if (!obj.activeInHierarchy)
            return;

        obj.SetActive(false);
        isHide = true;

        GameManager.inventory.AddItem((int)ItemType.Mushroom);
    }

    public void Show()
    {
        obj.SetActive(true);
        isHide = false;
    }
}
