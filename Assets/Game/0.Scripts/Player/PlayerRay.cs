using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rayPos = transform.position;
        rayPos.y += 0.3f;

        Ray ray = new Ray(rayPos, transform.forward);
        RaycastHit hit;
       
        Debug.DrawRay(transform.position, transform.forward * 1f, Color.red);

        UI.Instance?.ShowInputUI(false);

        if (Physics.Raycast(rayPos, transform.forward * 1f, out hit, 2f))
        {
            if (hit.collider.CompareTag("hunting"))
            {
                UI.Instance?.ShowInputUI(true);
                Debug.Log(hit.collider.name);
            }
            
        }

    }
}
