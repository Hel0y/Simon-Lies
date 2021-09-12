using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
  public float dano = 10f;
  public float alcance = 100f;
  public float recarga = 0.5f;
  private float normal;
  private float recargaUP = 0.2f;
  public float shoot = 0.3f;
  public bool isUpgraded;
 [SerializeField]
  ParticleSystem particula;

  public Camera RangeCam;
    private void Awake() {
        normal = recarga;
    }
    void Update()
    {
        if (isUpgraded){
          recarga = recargaUP;
        }
        else if(!isUpgraded){
            recarga = normal;
        }
        if(Input.GetButtonDown("Fire1") && Time.time > shoot){
            shoot = Time.time + recarga;
            Atirar();
        }
    }

    void Atirar(){
        particula.Play();
        RaycastHit hit;
        if(Physics.Raycast(RangeCam.transform.position, RangeCam.transform.forward, out hit, alcance)){
            EnemyTarget target = hit.transform.GetComponent<EnemyTarget>();
            if(target != null){
                target.LevarDano(dano);
            }
        }
    }
}
