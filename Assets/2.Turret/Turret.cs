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

    [SerializeField] Transform head;
    [SerializeField] Transform mount;

    [SerializeField] TurretBullet tb;
    [SerializeField] Transform tempParent;
    [SerializeField] Transform parent;

    [SerializeField] List<TurretBullet> listTB = new List<TurretBullet>();
    public Queue<TurretBullet> qTb = new Queue<TurretBullet>();

    Animator animator;
    State state = State.idle;
    int level = 1;

    private void Awake()
    {
        animator = GetComponent<Animator>();

        foreach (var item in listTB)
        {
            qTb.Enqueue(item);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Enemy e = FindEnemy();
        if (Input.GetKeyDown(KeyCode.F1))
        {
            level++;
            Debug.Log(level);
            CancelInvoke("FireBullet");
            InvokeRepeating("FireBullet", 1f, JsonData.Instance.tData.turret[level - 1].attdelay);
        }
        if (e == null)
        {
            if (state != State.end)
            {
                CancelInvoke("FireBullet");
                animator.SetTrigger("end");
                state = State.end;
            }
        }
        else
        {
            if (state != State.start)
            {
                animator.SetTrigger("start");
                state = State.start;

                CancelInvoke("FireBullet");
                InvokeRepeating("FireBullet", 2f, JsonData.Instance.tData.turret[level - 1].attdelay);
            }

            head.LookAt(e.transform);

            Vector3 vec = e.transform.position - mount.transform.position;
            Quaternion q = Quaternion.LookRotation(vec).normalized;
            q.z = q.x = 0;
            mount.transform.rotation = q;
        }
    }

    void FireBullet()
    {
        TurretBullet b;
        if (qTb.Count == 0)
        {
            b = Instantiate(tb, tempParent);
            qTb.Enqueue(b);
        }

        b = qTb.Dequeue();

        b.SetTurret(this);
        b.transform.SetParent(parent);
        b.Dmg = JsonData.Instance.tData.turret[level - 1].att;
    }

    public void BulletDisable(TurretBullet tb)
    {
        tb.transform.SetParent(tempParent);
        qTb.Enqueue(tb);
    }

    Enemy FindEnemy()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("enemy");

        float dis = float.MaxValue;
        Enemy e = null;
        foreach (var obj in objs)
        {
            float distance = Vector3.Distance(transform.position, obj.transform.position);
            if (dis > distance)
            {
                dis = distance;
                e = obj.GetComponent<Enemy>();
            }
        }

        if (e != null)
        {
            float distance = Vector3.Distance(transform.position, e.transform.position);
            if (distance < 25)
            {
                return e;
            }
        }
        return null;
    }
}
