using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIAgent : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Transform finishT;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //float dis = Vector3.Distance(transform.position, finishT.position);
        //if(dis > 3)
          agent.SetDestination(finishT.position);
    }
}
