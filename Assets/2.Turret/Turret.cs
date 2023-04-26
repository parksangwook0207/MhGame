using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    enum State
    {
        idle,
        start,
        end
    }
    [SerializeField] private Transform parent;
    [SerializeField] private Transform tempParent;

    [SerializeField] List<TurretBullet> listTB = new List<TurretBullet>();
    public Queue<TurretBullet> qTb = new Queue<TurretBullet>();
    int level = 5;
    // Start is called before the first frame update
    void Start()
    {
        foreach (var item in listTB)
        {
            qTb.Enqueue(item);
        }
        //else
        //JsonData.Instance.tData.turret[level - 1].attdelay;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            level++;
            Debug.Log(level);
        }
    }

    void FireBullet()
    {
        TurretBullet b;
        if (qTb.Count != 0)
        {
            b = qTb.Dequeue();
        }
        else
        {
            b = Instantiate(tb, tempParent);
            qTb.Enqueue(b);
        }
        b.transform.SetParent(parent);
        b.Dmg = JsonData.Instance.tData.turret[level - 1].att;
        b.SetTurret(this);
    }

    public void BulletDisable(TurretBullet tb)
    {
        qTb.Enqueue(tb);
    }
    //Animator.SetTrigger("start");

    //Animator animator;
}
