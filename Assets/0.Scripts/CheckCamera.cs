using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCamera : MonoBehaviour
{
    [SerializeField] private GameObject freeLookCam;

    public void FreeLookCam(bool isOn)
    {
        freeLookCam.SetActive(!isOn);
    }
}
