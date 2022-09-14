using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class RandomMoveAgent : MonoBehaviour
{

    NavMeshAgent agent;
    Vector3 randomPosition;
    public float timeChange;
    public bool inCoroutine;
    private void Awake()
    {
        randomPosition = new Vector3(0, 0, 0);
    }
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        agent.SetDestination(randomPosition);


    }

    // Update is called once per frame
    void Update()
    {

        if(!inCoroutine)
            StartCoroutine(MoveAgent());

    }

    IEnumerator MoveAgent()
    {
        inCoroutine = true;
        yield return new WaitForSeconds(timeChange);
        GenerateRandomPosition();
        agent.SetDestination(randomPosition);
      ;
        inCoroutine = false;
        
        
       
    }


    void GenerateRandomPosition()
    {

        randomPosition.x = Random.Range(-9.5f, 9.5f);
        randomPosition.z = Random.Range(-6f, 6f);

    }
}