using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "itemData", menuName = "Scriptable/ItemData")]
public class ItemData : ScriptableObject
{
    [SerializeField] private string itemname;
    public string Name { get { return name; } }

    [SerializeField] private Sprite sprite;
    public Sprite Icon { get { return sprite; } }
}
