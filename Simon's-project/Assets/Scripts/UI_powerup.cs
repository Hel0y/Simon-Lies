using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UI_powerup : MonoBehaviour
{
    public Image cgml;
    public Sprite[] cgml_img;
    public Dano_PU d;
    private WaitForSeconds tempoTroca = new WaitForSeconds(1f);
    private bool isRun = false;

    void Start()
    {
        d = FindObjectOfType<Dano_PU>();
    }

    void Update()
    {
        if (d.cogumelo)
        {
            cgml.enabled = true;
            if (!isRun)
            {
                StartCoroutine(rec_img());
            }   
            //d.cogumelo = false;
        }
        else 
        {
            cgml.enabled = false;
        }
      
    }

    private IEnumerator rec_img(){
        isRun = true;
        for (var n = 0; n <= 5; n++)
        {
            cgml.sprite = cgml_img[n];
                yield return tempoTroca;
        }
        isRun = false;
    }
}
