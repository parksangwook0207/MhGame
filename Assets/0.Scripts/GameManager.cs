using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public enum ItemType
{
    Apple,
    Log,
    Mushroom,
    Stick,
    Stone
}

public class GameManager : MonoBehaviour
{
    public static CheckCamera checkCamera;
    public static MovementInput player;
    public static Inventory inventory;

    bool keyInvenOpen = false;

    void Awake()
    {
        checkCamera = FindObjectOfType<CheckCamera>();
        player = FindObjectOfType<MovementInput>();
        inventory = FindObjectOfType<Inventory>();
    }

    void Update()
    {
        // 인벤토리 키보드로 열겠금 하는 코드
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (keyInvenOpen == false)
                inventory.OnShow();
            else
                inventory.OnHide();

            keyInvenOpen = !keyInvenOpen;
        }
    }

    public static void UIMode(bool isOn)
    {
        checkCamera.FreeLookCam(isOn);
        player.isMove = !isOn;
    }
}
