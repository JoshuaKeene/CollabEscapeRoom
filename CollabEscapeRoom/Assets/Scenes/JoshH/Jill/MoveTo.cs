using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class MoveTo : MonoBehaviour
{

    [SerializeField] Transform[] waypoints;

    int currentWaypoint = 0;

    private NavMeshAgent agent;

    public bool GameEnd;

   

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!GameEnd)
        {

            if (Vector3.Distance(transform.position, waypoints[currentWaypoint].transform.position) <= 5f)
            {
                currentWaypoint++;
                if (currentWaypoint == waypoints.Length-1)
                {
                    currentWaypoint = 0;
                }
            }
        }
        else
        {
            currentWaypoint = 4;
        }
       agent.SetDestination(waypoints[currentWaypoint].position);
    }
}
