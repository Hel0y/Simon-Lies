using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dano_PU : MonoBehaviour
{
    public int Maxhealth = 20;
    public int currenthealth;
    private WaitForSeconds tempoReg = new WaitForSeconds(0.5f);
    public Coroutine reg;
    public BarraVida barravida;
    public ShootingScript shootS;
    public bool cogumelo;

    void Start()
    {
        shootS = FindObjectOfType<ShootingScript>();
         gameObject.SetActive(true);
        currenthealth = Maxhealth ;
        barravida.SetMaxHealth(Maxhealth);
    }
    void Update(){
        if(currenthealth <= 0){
        gameObject.SetActive(false);
        Cursor.lockState =  CursorLockMode.None;
        SceneManager.LoadScene("GameOver");
        }      
    }
    IEnumerator PowerUp(){
        shootS.isUpgraded = true;
        cogumelo = true;
        yield return new WaitForSeconds(6f);
         cogumelo = false;
        shootS.isUpgraded = false;
    }
    private void OnTriggerStay(Collider collision) {
            if (collision.tag == "powerUp") {  
                StartCoroutine(PowerUp());         
                Destroy(collision.gameObject);
            }
    }
    void OnTriggerEnter(Collider collision) {
     if (collision.gameObject.tag == "Enemy") {         
            currenthealth -= 5;
            barravida.SetHealth(currenthealth);

           if (reg != null)
           {
               StopCoroutine(reg);
           } 
          reg = StartCoroutine(recarregar());
        }
    }

        private IEnumerator recarregar(){
            yield return new WaitForSeconds(5);

            while(currenthealth < Maxhealth){
                currenthealth += Maxhealth / 20;
                 barravida.SetHealth(currenthealth);

                yield return tempoReg;
            }
            reg = null;
        }
}
