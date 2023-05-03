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
    /// 인벤토리 데이터 UI 셋팅
    /// </summary>
    private void Setting()
    {
        // 초반 인벤토리 백판 아이콘 셋팅
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
    /// 테스트용 : 아이템 추가 
    /// </summary>
    public void AddItem(int itemIdx)
    {
        // 인벤토리에 넘어가지 않게 예외처리
        if (lastIndex > (XCnt * YCnt) - 1)
            return;

        // 내가 들고 있는 아이템 인벤토리에 셋팅
        ItemData id = itemData[itemIdx];

        // 아이템을 새로 만들어야 할떄
        if (ItemAddCheck(id.Name) == true)
        {
            //invenItemList[lastIndex].SetData(id.C); 
            lastIndex++;

            // <size=50><b><color=#f0aa00> </color></b></size> html 코드 
            // id.Name = 아이템 이름
            UI.Instance.ToastPopup($"<size=50><b><color=#f0aa00>{id.Name}</color></b></size> 을(를) 추가되었습니다.");
        }
        else
        {
            int idx = ItemFindIndex(id.Name);
            int count = Random.Range(2, 6);
            invenItemList[idx].SetCount(count, true);

            UI.Instance.ToastPopup($"<color=#f0aa00>{id.Name}</color> 을(를) {count}개를 획득하였습니다.");
        }
    }

    /// <summary>
    /// 새로운 아이템인지 체크
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
    /// 몇번째 아이템이 들어있는지 확인후 번호 반환
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
    /// 인벤토리 화면을 보여줄때 실행되는 함수
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
    /// 인벤토리 화면을 끈다.
    /// </summary>
    public void OnHide()
    {
        invenObj.SetActive(false);
        GameManager.UIMode(false);
    }
}
