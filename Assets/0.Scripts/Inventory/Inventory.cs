using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private ItemData[] itemData;
    [SerializeField] private Transform parent;
    [SerializeField] private InventoryItem prefab;
    [SerializeField] private GameObject invenObj;
    
    List<InventoryItem> invenItemList = new List<InventoryItem>();
    int lastIndex = 0;

    public int YCnt { get; set; }
    public int XCnt { get; set; }
    public bool IsStartSetting { get; set; }

    void Start()
    {
        IsStartSetting = false;
        OnShow();
        OnHide();
    }

    /// <summary>
    /// �κ��丮 ������ UI ����
    /// </summary>
    private void Setting()
    {
        // �ʹ� �κ��丮 ���� ������ ����
        for (int y = 0; y < YCnt; y++)
        {
            for (int x = 0; x < XCnt; x++)
            {
                invenItemList.Add(Instantiate(prefab, parent));
            }
        }
        IsStartSetting = true;
    }

    /// <summary>
    /// �׽�Ʈ�� : ������ �߰� 
    /// </summary>
    public void AddItem(int itemIdx)
    {
        // �κ��丮�� �Ѿ�� �ʰ� ����ó��
        if (lastIndex > (XCnt * YCnt) - 1)
            return;

        // ���� ��� �ִ� ������ �κ��丮�� ����
        ItemData id = itemData[itemIdx];

        // �������� ���� ������ �ҋ�
        if (ItemAddCheck(id.Name) == true)
        {
            //invenItemList[lastIndex].SetData(id.C); 
            lastIndex++;

            // <size=50><b><color=#f0aa00> </color></b></size> html �ڵ� 
            // id.Name = ������ �̸�
            UI.Instance.ToastPopup($"<size=50><b><color=#f0aa00>{id.Name}</color></b></size> ��(��) �߰��Ǿ����ϴ�.");
        }
        else
        {
            int idx = ItemFindIndex(id.Name);
            int count = Random.Range(2, 6);
            invenItemList[idx].SetCount(count, true);

            UI.Instance.ToastPopup($"<color=#f0aa00>{id.Name}</color> ��(��) {count}���� ȹ���Ͽ����ϴ�.");
        }
    }

    /// <summary>
    /// ���ο� ���������� üũ
    /// </summary>
    private bool ItemAddCheck(string name)
    {
        for (int i = 0; i < invenItemList.Count; i++)
        {
            if(invenItemList[i].ItemName == name)
                return false;
        }
        return true;
    }

    /// <summary>
    /// ���° �������� ����ִ��� Ȯ���� ��ȣ ��ȯ
    /// </summary>
    private int ItemFindIndex(string name)
    {
        int index = -1;
        for (int i = 0; i < invenItemList.Count; i++)
        {
            if (invenItemList[i].ItemName == name)
            {
                index = i;
                break;
            }
        }
        return index;
    }

    public bool DeleteItem(string name, int count)
    {
        int idx = ItemFindIndex(name);

        if (idx != -1)
        {
            if (invenItemList[idx].Count >= count)
            {
                invenItemList[idx].SetCount(count,false);
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// �κ��丮 ȭ���� �����ٶ� ����Ǵ� �Լ�
    /// </summary>
    public void OnShow()
    {
        invenObj.SetActive(true);
        GameManager.UIMode(true);
        YCnt = 10;
        XCnt = 4;

        if(!IsStartSetting)
        {
            Setting();
        }
    }

    /// <summary>
    /// �κ��丮 ȭ���� ����.
    /// </summary>
    public void OnHide()
    {
        invenObj.SetActive(false);
        GameManager.UIMode(false);
    }
}
