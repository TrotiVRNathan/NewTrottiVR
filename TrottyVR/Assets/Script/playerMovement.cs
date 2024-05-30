using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class playerMouvement : MonoBehaviour
{
    CharacterController characterController;
    [SerializeField] float movementSpeed;


    [SerializeField] GameObject CameraRig;
    Vector3 moveVector;
 
    private void Update()
    {
       Movement();
   
    }




    private void Start()
    {
        characterController=GetComponent<CharacterController>();
    }
    void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal")*movementSpeed*Time.deltaTime;
        float vertical= Input.GetAxis("Vertical")*movementSpeed*Time.deltaTime;
       


        moveVector=new Vector3(horizontal,0,vertical);
        characterController.Move(moveVector);




    }
   
}
