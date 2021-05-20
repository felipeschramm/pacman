using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class scriptNPC : MonoBehaviour
{
    private NavMeshAgent agente;
    public GameObject PC;
    public GameObject[] waypoints = new GameObject[4];
    private int index = 0;
    public float maxDist;
    public int maxDistAlvo;

    // Start is called before the first frame update
    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        proximo();
    }

    private void proximo()
    {
        agente.SetDestination(waypoints[index++].transform.position);
        if (index >= waypoints.Length)
            index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, PC.transform.position) < maxDistAlvo)
        {
            agente.SetDestination(PC.transform.position);
        }
        else
        {
            if (Vector3.Distance(transform.position, agente.destination) < maxDist)
                proximo();
        }
        
    }
}
