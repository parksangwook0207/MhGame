using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttononoff : MonoBehaviour
{
    public bool state;
    public GameObject inui;

    private void Start()
    {
        state = true;
    }

    public void OnBtn()
    {
        inui.SetActive(true);
    }
    public void OffBtn()
    {
        inui.SetActive(false);
    }
}
