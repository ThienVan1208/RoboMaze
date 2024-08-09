using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class ghost : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    NavMeshAgent navMeshAgent;
    Navigation nav;
    public bool notMove;
    void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player");
        navMeshAgent = GetComponent<NavMeshAgent>();
        setDestination();
    }

    // Update is called once per frame
    void Update()
    {
        
        setDestination();
    }
    public void setDestination()
    {
        if (navMeshAgent != null)
        {
            if (!notMove)
            {
                Vector3 direct = player.transform.position;
                navMeshAgent.SetDestination(direct);
            }
            else
            {
                navMeshAgent.ResetPath(); 
                navMeshAgent.velocity = Vector3.zero; 
            }
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.ActiveOverPanel();
            //Debug.Log(GetComponent<Collider>().gameObject.name);
        }
    }
}
