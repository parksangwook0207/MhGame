using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        data.spd = 1f;
        data.atkDelay = 2f;
        data.state = State.Idle;
        data.target = FindObjectOfType<PlayerKeyEvent>().transform;
        data.animator = GetComponent<Animator>();
    }


}
