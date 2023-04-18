using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour
{
    public static UI Instance;

    public GameObject inputUI;
    [SerializeField] private RectTransform toastPopup;

    void Awake()
    {
        Instance = this;
    }

    public void ShowInputUI(bool isActive)
    {
        inputUI.GetComponent<Image>().fillAmount = 1f;
        inputUI.SetActive(isActive);
    }

    public void InputUIFillAmount(float min, float max)
    {
        inputUI.GetComponent<Image>().fillAmount = min/ max;
    }

    public void ToastPopup(string ment)
    {
        toastPopup.GetChild(0).GetComponent<TMP_Text>().text = ment;
        // 코르틴 : Toast함수 호출실행?
        StopCoroutine("Toast");
        StartCoroutine("Toast");
    }

    IEnumerator Toast()
    {
        toastPopup.anchoredPosition = new Vector2(0, 10);
        while (true)
        {
            if (toastPopup.anchoredPosition.y > -100)
                toastPopup.anchoredPosition += Vector2.down * 10f;
            else
                break;
            yield return new WaitForSeconds(0.01f);
        }

        yield return new WaitForSeconds(3f);

        while (true)
        {
            if (toastPopup.anchoredPosition.y <= 10)
                toastPopup.anchoredPosition += Vector2.up * 10f;
            else
                break;
            yield return new WaitForSeconds(0.01f);
        }
    }

}
