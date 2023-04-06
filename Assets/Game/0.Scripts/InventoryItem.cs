using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class InventoryItem : MonoBehaviour
{
    [SerializeField] private TMP_Text cntTxt;
    [SerializeField] private Image icon;
    //[SerializeField] private TMP_Text nameTxt;

    public int Count { get; set; }
    public string ItemName { get; set; }

    ItemData iData;
    // Start is called before the first frame update
    void Start()
    {
        Count = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
    /// <summary>
    /// 데이터 변경
    /// </summary>
    /// <param name="data"></param>
    public void SetData(ItemData data)
    {
        iData = data;
        SetCount(1, true);
        SetIcon();
        //SetName();
    }
    /// <summary>
    /// 아이템 갯수 변경
    /// </summary>
    /// <param name="count"></param>
    /// <param name="isAdd"></param>
    public void SetCount(int count, bool isAdd)
    {
        int temp = isAdd == true ? Count += count : Count -= count;
        cntTxt.text = Count.ToString();
    }
    /// <summary>
    /// 아이템 이미지 변경
    /// </summary>
    void SetIcon()
    {
        icon.enabled = true;
        icon.sprite = iData.Icon;
    }
    /// <summary>
    /// 아이템 이름 변경
    /// </summary>
    /*void SetName()
    {
        nameTxt.text = iData.Name;
        ItemName = iData.Name;
    }
    */
   
}
