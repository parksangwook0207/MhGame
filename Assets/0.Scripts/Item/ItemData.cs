using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable/ItemData")]
public class ItemData : ScriptableObject
{
    [SerializeField] private string itemName;
    public string Name { get { return itemName; } }

    [SerializeField] private Sprite sprite;
    public Sprite Icon { get { return sprite; } }

}
