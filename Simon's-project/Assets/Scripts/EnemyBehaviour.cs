using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour{

    private Transform target;
    private NavMeshAgent agent;

    void Awake() {
    agent = GetComponent<NavMeshAgent>();
    target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    
    void Update() {
    agent.destination = target.position;
    }  
  }

