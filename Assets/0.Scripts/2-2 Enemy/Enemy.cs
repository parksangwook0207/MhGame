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
        public State state;
        public Transform target;
        public Animator animator;
    }

    protected Data data = new Data();

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void Move()
    {
        float dis = Vector3.Distance(transform.position, data.target.position);
        if (dis < 3)
        {
            data.animator.SetBool("Run Forward", false);
            data.animator.SetBool("Walk Forward", false);
        }

        else if (dis < 6)
        {
            data.animator.SetBool("Run Forward", false);
            data.animator.SetBool("Walk Forward", true);
            transform.Translate(Vector3.forward * Time.deltaTime * data.spd * 6);
        }


        else
        {
            data.animator.SetBool("Run Forward", true);
            transform.Translate(Vector3.forward * Time.deltaTime * data.spd * 3);
        }
        
        
    }
}
