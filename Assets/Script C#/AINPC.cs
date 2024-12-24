using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AINPC : MonoBehaviour
{
    public NavMeshAgent NPC1;
    public Transform player;
    void Start()
    {
        if (NPC1 == null)
        {
            NPC1 = GetComponent<NavMeshAgent>();
        }
        //NPC1 = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        if (player != null)
        {
            NPC1.SetDestination(player.position);
        }
        //NPC1.transform.position = player.position;
    }
}
