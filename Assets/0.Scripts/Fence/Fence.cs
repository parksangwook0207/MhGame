using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fence : MonoBehaviour
{
    public int needUpgradeCount;
    public float HP { get; set; }
    private int level;
    private int maxHP;

    public int Level
    {
        get
        {
            return level;
        }
        set
        {
            Level = value;
            if (level != 0)
            {
                
                if (GameManager.inventory.DeleteItem("통나무", needUpgradeCount))
                {
                   // if (level < FenceMa.Instace.meshs.Length)
                    //GetComponent<MeshFilter>().mesh = FenceMa.Instance.meshs[level];
                    HP = HP + (maxHP * level);
                    needUpgradeCount = (level + 1) + (transform.parent.GetComponent<FenceObj>().needCount * level); 
                    UI.Instance.ToastPopup($"{level + 1}업그레이드 완료");
                }
                else
                {
                    UI.Instance.ToastPopup($"업그레이드가 최대치입니다.");
                }
            }
            else
            {
                UI.Instance.ToastPopup($"재료가 부족합니다.");
            }


        }

    }
    void Start()
    {
        maxHP = 10;
        Level = 0;
        needUpgradeCount = (level + 1) + (transform.parent.GetComponent<FenceObj>().needCount * level) ;
    }
    public void Hit(float dmg)
    {
        HP -= dmg;

        if (HP <= 0)
        {
            Hide();
            transform.parent.GetComponent<FenceObj>().Show();
        }
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        
        gameObject.SetActive(false);
    }
}
