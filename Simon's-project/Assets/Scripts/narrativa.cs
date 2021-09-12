using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class narrativa : MonoBehaviour
{
    public float natX;
     public Image nat1;
    public Image nat2;
    public Image nat3;
    void Start()
    {
        natX = 1f;
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump")){
            natX += 1;
            if(natX == 2){
                nat1.enabled = false;
            }
            else if (natX == 3){
                nat2.enabled = false;
            }
            else if (natX > 3){
                SceneManager.LoadScene("Game-part1-Scene");
            }
        }
    }
}
