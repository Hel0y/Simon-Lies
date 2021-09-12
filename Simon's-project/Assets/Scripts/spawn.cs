using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
   
     [SerializeField] GameObject[] enemyPrefabs;

    [SerializeField] int enemiesPerWave, enemyInstantiated;
    [SerializeField] int[] enemiesPerWaveMultiply;
    [SerializeField]
    private float MaxDistance, R, MaxEnemy;
    public int activeEnemies, deadEnemies;
    RaycastHit hit;
    public GameObject inimigo;
    public LayerMask layerMask;
    private Vector3 origem;
    private Vector3 direcao;
    private WaitForSeconds tempoReg = new WaitForSeconds(2f);


    //timers
    [SerializeField] float timeBetweenSpawn, timeToStart;

    int enemyIndexArray;

    void Start() {
        InvokeRepeating("EnemySpawn", timeToStart, timeBetweenSpawn);
    }
    void Update()
    {
        origem = transform.position;
        if (activeEnemies == 0)
        {
        EnemySpawn();
        }
       if (Physics.SphereCast(origem, R, transform.position,out hit, MaxDistance, layerMask, QueryTriggerInteraction.UseGlobal))
        {
         Destroy(gameObject);    
        }
    }
    void EnemySpawn() {
       
            if (activeEnemies <= enemiesPerWave) {
                enemyIndexArray = Random.Range(0, enemyPrefabs.Length);

                var enemy = Instantiate(inimigo, transform.position, Quaternion.identity);
                activeEnemies++;
                enemyInstantiated++;
            }            
        
    }
     
    
}
