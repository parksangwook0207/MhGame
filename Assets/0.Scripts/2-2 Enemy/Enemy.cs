using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected enum State
    {
        Idle,
        walk,
        Atk,
        Die,
    }

    protected struct Data
    {
        public float spd;
        public float atkDelay;
        public State state;
        public Transform target;
        public Animator animator;
    }

    protected Data data = new Data();

    float attackTimer = 0f;

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void Move()
    {
        transform.LookAt(data.target);
        float dis = Vector3.Distance(transform.position, data.target.position);
        if (dis < 3)
        {
            attackTimer += Time.deltaTime;
            if (attackTimer > data.atkDelay)
            {
                attackTimer = 0f;

                int rand = Random.Range(1, 3);
                data.animator.SetTrigger($"Attack{rand}");
                if (data.target.GetComponent<Fence>())
                {
                    data.target.GetComponent<Fence>().Hit(10);
                }
                // 데미지 제공
                Invoke("FindTarget", 0.5f);
            }

            data.animator.SetBool("Idle", true);
            data.animator.SetBool("WalkForward", false);

        }

        else if (dis < 6)
        {
            data.animator.SetBool("Run Forward", false);
            data.animator.SetBool("WalkForward", true);
            transform.Translate(Vector3.forward * Time.deltaTime * data.spd * 6);
        }


        else
        {
            data.animator.SetBool("Idle", false);
            data.animator.SetBool("Run Forward", true);
            transform.Translate(Vector3.forward * Time.deltaTime * data.spd * 3);
        }
    }

    private void FindTarget()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("build");

        float dis = float.MaxValue;
        GameObject obj = null;
        foreach (var target in objs)
        {
            float distance = Vector3.Distance(transform.position, target.transform.position);
            if (dis > distance)
            {
                dis = distance;
                obj = target;
            }
        }

        data.target = obj.transform;
    }
}
