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
        #region RayCast Simple
        /*
        Vector3 rayPos = transform.position;
        rayPos.y += 0.3f;

        //Ray ray = new Ray(rayPos, transform.forward * 1f);
        RaycastHit hit;

        Debug.DrawRay(rayPos, transform.forward * 1f, Color.red);

        UI.Instance?.ShowInputUI(false);

        if (Physics.Raycast(rayPos, transform.forward, out hit, 2f))
        {
            if (hit.collider.CompareTag("hunting"))
            {
                UI.Instance?.ShowInputUI(true);
                Debug.Log(hit.transform.name);
            }
        }
        */
        #endregion

        // ä�� ����
        if (Input.GetKeyDown(KeyCode.F))
        {
            if(!isPress)
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

        if(isPress)
        {
            if (UI.Instance.inputUI.activeInHierarchy)
            {
                pressTime += Time.deltaTime;
                UI.Instance.InputUIFillAmount(pressTime, 3f);
                if (pressTime > 3f)
                {
                    pressTime = 0;
                    // ���� ������Ʈ �±� ����
                    switch (other.gameObject.tag)
                    {

                        case "hunting":
                            
                            if (other.GetComponent<Tree>() != null)
                            {
                                // Ʈ����  null �� �ƴ� �� Ʈ���� �����.
                                other.GetComponent<Tree>().HideTree();
                            }
                            else if(other.GetComponent<Stick>() != null)
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
        }
    }

    void OnTriggerExit(Collider other)
    {
        UI.Instance?.ShowInputUI(false);
        this.other = null;
    }
}
