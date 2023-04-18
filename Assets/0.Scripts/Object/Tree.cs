using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] private GameObject tree;
    // 짧은 나무
    [SerializeField] private GameObject btmTree;
    // 큰 나무로 복귀하는 시간
    [HideInInspector] public float resetTime = 2f;
    
    float delay = 0;
    bool isHide = false;

    public void HideTree()
    {
        if (!tree.activeInHierarchy)
            return;

        tree.SetActive(false);
        isHide = true;
        // enum 자료형 변환
        GameManager.inventory.AddItem((int)ItemType.Log);
    }

    public void ShowTree()
    {
        tree.SetActive(true);
        isHide = false;
    }

    void Update()
    {
        if (!isHide)
            return;
        // 딜레이 시간을 증감 
        delay += Time.deltaTime;      
        if (delay > resetTime)
        {          
            delay = 0;
            ShowTree();
        }
    }
}
