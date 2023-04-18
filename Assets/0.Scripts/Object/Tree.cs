using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] private GameObject tree;
    // ª�� ����
    [SerializeField] private GameObject btmTree;
    // ū ������ �����ϴ� �ð�
    [HideInInspector] public float resetTime = 2f;
    
    float delay = 0;
    bool isHide = false;

    public void HideTree()
    {
        if (!tree.activeInHierarchy)
            return;

        tree.SetActive(false);
        isHide = true;
        // enum �ڷ��� ��ȯ
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
        // ������ �ð��� ���� 
        delay += Time.deltaTime;      
        if (delay > resetTime)
        {          
            delay = 0;
            ShowTree();
        }
    }
}
