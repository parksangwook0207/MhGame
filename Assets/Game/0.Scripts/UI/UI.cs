using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour
{
    public static UI Instance;

    [SerializeField] private GameObject inputUI;

    void Awake()
    {
        Instance = this;
    }

    public void ShowInputUI(bool isActive)
    {
        inputUI.SetActive(isActive);
    }

}
