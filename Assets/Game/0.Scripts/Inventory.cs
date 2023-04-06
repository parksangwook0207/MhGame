using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{
    [SerializeField] private ItemData[] itemData;
    [SerializeField] private InventoryItem prefab;
    [SerializeField] private Transform parent;

    public int inX { get; set; }
    public int inY { get; set; }

    public bool IsStartSetting { get; set; }

    List<InventoryItem> invenItemList = new List<InventoryItem>();

    int lastIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        IsStartSetting = false;
        gameObject.SetActive(false);
        inX = 4;
        inY = 10;

        Inven();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            AddItem();
        }
    }


    public void Inven()
    {
        for (int y = 0; y < inY; y++)
        {
            for (int x = 0; x < inX; x++)
            {
                invenItemList.Add(Instantiate(prefab, parent));
            }
        }
    }

    // 테스트용 : 아이템 추가

    private void AddItem()
    {
        // 내가 들고 있는 아이템 인벤토리에 셋팅
        int itemIdx = Random.Range(0, itemData.Length);
        ItemData Id = itemData[itemIdx];

        if (ItemAddCheck(Id.name) == true)
        {
            invenItemList[lastIndex].SetData(Id);
        }
        else
        {
            int idx = ItemFindIndex(Id.Name);
            invenItemList[idx].SetCount(1, true);
        }

    }
    // 새로운 아이템인지 체크
    private bool ItemAddCheck(string name)
    {
        for (int i = 0; i < invenItemList.Count; i++)
        {
            if (invenItemList[i].ItemName == name)
            {
                return false;
            }
        }
        return true;
    }

    // 몇 번째 아이템이 들어있는 지 확인후 번호 반환

    private int ItemFindIndex(string name)
    {
        int index = 0;
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









}
