using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AreaDetection : MonoBehaviour
{
    public bool follow;

    public NavMeshAgent agent;
    public Transform player;
    public GameObject lightsPolice;

    private void Start()
    {

        follow = false;
        lightsPolice.SetActive(false);
    }

    void Update()
    {
        if (follow == true)
        {
            agent.SetDestination(player.position);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Equals("Player"))
        {
            follow = true;
            lightsPolice.SetActive(true);

        }
    }
}
