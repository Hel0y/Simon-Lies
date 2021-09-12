using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{
    //movimentação
    float X, Z; 
    float velocidade = 8f;
    Vector3 direção;
    public CharacterController controller;
    //pulo
    [SerializeField]
    float JumpHeight = 1f;
    float groundDistance = 0.1f;
    public Transform groundCheck;
    bool IsGrounded, finished;
    public LayerMask groundMask, endMask;
    float gravity = -9.81f;
    Vector3 velocity;
    public bool nochão=false;


    void Update()
    {   
        IsGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (IsGrounded && velocity.y < 0 && !finished) {
        velocity.y = -2f;
        nochão = true;
        }else {
        nochão = false;
        }
      
        X = Input.GetAxis("Horizontal");
        Z = Input.GetAxis("Vertical");
        direção = transform.right * X + transform.forward * Z;
        controller.Move(direção * velocidade * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && IsGrounded){
            velocity.y = Mathf.Sqrt(JumpHeight * -2 * gravity);
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);  
       
    }
     private void OnTriggerEnter(Collider collision) {
            if (collision.tag == "end") {  
         Cursor.lockState =  CursorLockMode.None;
         SceneManager.LoadScene("vitoria");
            }}
    
}