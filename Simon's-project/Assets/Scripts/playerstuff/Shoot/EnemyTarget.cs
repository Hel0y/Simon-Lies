using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTarget : MonoBehaviour
{
[SerializeField]
private float health = 20f;
[SerializeField]
ParticleSystem particula;
private spawn spw;
public spawn quantenemy;
public GameObject PU_tiro;

public void LevarDano(float quant){
health -= quant;
particula.Play();
if(health <= 0){
    Morte();
}
}
private void Awake() {
  spw = FindObjectOfType<spawn>();
  quantenemy = FindObjectOfType<spawn>();
  }
  
  void Morte(){
spw.activeEnemies --;
quantenemy.deadEnemies ++;
if (quantenemy.deadEnemies % 5 == 0)
{
  Instantiate(PU_tiro, transform.position, Quaternion.identity);
}
particula.Play();
Destroy(gameObject);    
  }
}
