using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerRay : MonoBehaviour
{
    Collider other;
    bool isPress = false;
    float pressTime = 0f;
    // Update is called once per frame
    void Update()
    {


        // 채집 가능
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!isPress)
            {
                isPress = true;
                pressTime = 0;
            }
        }

        if (Input.GetKeyUp(KeyCode.F))
        {
            isPress = false;
            pressTime = 0;
        }

        if (isPress)
        {
            if (UI.Instance.inputUI.activeInHierarchy)
            {
                pressTime += Time.deltaTime;
                UI.Instance.InputUIFillAmount(pressTime, 3f);

                
                if (pressTime > 1f)
                {
                    pressTime = 0;
                    // 게임 오브젝트 태그 접근
                    switch (other.gameObject.tag)
                    {

                        case "hunting":
                            Huting();
                            break;

                    }
                    isPress = false;
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "hunting":
                UI.Instance?.ShowInputUI(true);
                this.other = other;
                break;
            case "buildx":
                BuildX();
                break;
        }
    }

    void OnTriggerExit(Collider other)
    {
        UI.Instance?.ShowInputUI(false);
        this.other = null;
    }

    void Huting()
    {
        if (other.GetComponent<Tree>() != null)
        {
            // 트리가  null 이 아닐 때 트리를 숨긴다.
            other.GetComponent<Tree>().HideTree();
        }
        else if (other.GetComponent<Stick>() != null)
        {
            other.GetComponent<Stick>().Hide();
        }
        else if (other.GetComponent<Stone>() != null)
        {
            other.GetComponent<Stone>().Hide();
        }
        else if (other.GetComponent<Mushroom>() != null)
        {
            other.GetComponent<Mushroom>().Hide();
        }
        else if (other.GetComponent<FenceObj>() != null)
        {
            other.GetComponent<FenceObj>().Build();
        }
    }

    void BuildX()
    {
        if (other.GetComponent<FenceObj>() != null)
        {
            FenceObj fObj = other.GetComponent<FenceObj>();
            if (GameManager.inventory.DeleteItem(fObj.needItemName, fObj.needCount))
            {
                fObj.Build();
            }
           else
            {
                UI.Instance.ToastPopup($"{fObj.needItemName}{fObj.needCount}개가 필요합니다.");
            }
        }
    }
}
