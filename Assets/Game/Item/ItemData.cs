using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 에셋에 메뉴 추가 해주는 것
[CreateAssetMenu(fileName = "itemData", menuName = "Scriptable/ItemData")]
public class ItemData : ScriptableObject
{
    [SerializeField] private string itemname;
    public string Name { get { return name; } }

    [SerializeField] private Sprite sprite;
    public Sprite Icon { get { return sprite; } }
}
