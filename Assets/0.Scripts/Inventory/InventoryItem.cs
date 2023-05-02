using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryItem : MonoBehaviour
{
    [SerializeField] private TMP_Text cntTxt;
    [SerializeField] private Image icon;
    [SerializeField] private TMP_Text nameTxt;

    public int Count { get; set; }
    public string ItemName { get; set; }

    ItemData iData;

    void Start()
    {
        Count = 0;
    }

    /// <summary>
    /// 데이터 변경
    /// </summary>
    /// <param name="data"></param>
    public void SetData(ItemData data, int count)
    {
        iData = data;
        SetCount(1, true);
        SetIcon();
        SetName();
    }
    /// <summary>
    /// 갯수 변경
    /// </summary>
    public void SetCount(int count, bool isAdd)
    {
        int temp = isAdd == true ? Count += count : Count -= count;
        cntTxt.text = Count.ToString();
    }

    /// <summary>
    /// 이미지 변경
    /// </summary>
    void SetIcon()
    {
        icon.enabled = true;
        icon.sprite = iData.Icon;
    }

    /// <summary>
    /// 이름 변경
    /// </summary>
    void SetName()
    {
        nameTxt.text = iData.Name;
        ItemName = iData.Name;
    }
}
