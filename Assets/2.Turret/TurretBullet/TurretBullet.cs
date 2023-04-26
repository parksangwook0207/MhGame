using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBullet : MonoBehaviour
{
    [HideInInspector] public float Dmg { get; set; }

    Turret turret;
    float disableTimer = 0;
    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * 10f);

        if (gameObject.activeInHierarchy)
        {
            disableTimer += Time.deltaTime;
            if (disableTimer > 3)
            {
                disableTimer = 0;
                Disable();  
            }
        }

    }

    public void SetTurret(Turret turret)
    {
        disableTimer = 0;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localPosition = Vector3.zero;
        
        gameObject.SetActive(true);
        if (this.turret == null)
            this.turret = turret;
    }

    public void Disable()
    {
        CancelInvoke("Disable");
        turret.BulletDisable(this);
        gameObject.SetActive(false);
    }




}
