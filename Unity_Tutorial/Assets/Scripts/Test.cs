using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;


public class Test : MonoBehaviour
{
    Rigidbody myRigid;
    [SerializeField] private float moveSpeed;

    NavMeshAgent agent;

    [SerializeField] private Transform[] tf_Destination;

    private Vector3[] wayPoints;
    

    private void Start()
    {
        myRigid = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();

        wayPoints = new Vector3[tf_Destination.Length + 1];

        for (int i = 0; i <tf_Destination.Length; i++)
        
            wayPoints[i] = tf_Destination[i].position;
         wayPoints[wayPoints.Length - 1] = transform.position;
        
    }
    private void Update()
    {
        Patrol();
       // if(Input.GetKey(KeyCode.W))
       // {
       //     agent.SetDestination(tf_Destination.position);
       // }
      
    }

    void Patrol()
    {
        for (int i = 0; i < wayPoints.Length; i++)
        {
            if (Vector3.Distance(transform.position, wayPoints[i]) <= 0.1f)
                agent.SetDestination(wayPoints[i + 1]);
            else
                agent.SetDestination(wayPoints[0]);
        }
    }
}
   
   
