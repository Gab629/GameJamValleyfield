using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThrowObject : MonoBehaviour
{

    //Variable pour les game objects des noix
    public GameObject imageNut;
    public GameObject nut;
    public GameObject nutFixed;
    


    //Variable pour toute les detection de la recharge de noix ou du lancer
    private bool nutLoaded = false;
    private float isThrowing = 0;



    //Variables pour la noix fixe (celle que l'on ramasse)
    private Vector3 nutFixedPosition;
    private Quaternion nutFixedRotation;



    //Variables pour les directions de lancer du personnage
    private float currentValue;
    private float previousValue;
    private Vector2 throwDirection;



    //Variables pour le nouveau input system
    private InputSystem inputActions;
    



    //------- Cette fonction est appelle avant le start -------//
    private void Awake()
    {
        //Va chercher le nouveau input system
        inputActions = new InputSystem();


        inputActions.ThrowNut.Throw.performed += ThrowNutButton;
        inputActions.ThrowNut.Throw.canceled += ThrowNutButton;

        inputActions.ThrowNut.Direction.performed += ThrowDirection;
        inputActions.ThrowNut.Direction.canceled += ThrowDirection;
       
    }


    //------- Cette fonction detecte la direction dont le joueur se deplace -------//
    private void ThrowDirection(InputAction.CallbackContext context)
    {
        throwDirection = context.ReadValue<Vector2>();
    }



    //------- Cette fonction detecte si le joueur clique sur la souris (pour lancer la noix) -------//
    private void ThrowNutButton(InputAction.CallbackContext context)
    {
        isThrowing = context.ReadValue<float>();
    }



    //------- Cette fonction est appele une fois par frame -------//
    void Update()
    {
        ThrowNut();
        NutDetection();
        
    }



    //------- Cette fonction est appele une fois ou plusieurs fois par frame (meilleur pour la physique) -------//
    void FixedUpdate(){
        KeepLastDirection();
    }



    //------- Cette fonction sert a garder la derniere direction choisie par le joueur -------//
    private void KeepLastDirection(){
        currentValue = throwDirection.x;

        if(currentValue == -1f)
        {
            previousValue = -1f;
        }
        else if(currentValue == 1)
        {
            previousValue = 1f;
        }
    }



    //------- Cette fonction detecte si il y a une collision avec un objet trigger -------//
    void OnTriggerEnter(Collider collision)
    {
        if(collision.transform.tag == "Nut"){
            Destroy(collision.gameObject);
            imageNut.SetActive(true);
            nutLoaded = true;
        }
    }



    //------- Cette fonction sert a lancer une noix dans la direction visee par le joueur -------//
    private void ThrowNut(){

        if(nutLoaded == true && isThrowing == 1)
        {
            nutLoaded = false;

            Vector3 positionNutLeft = new Vector3(gameObject.transform.position.x - 1, gameObject.transform.position.y, gameObject.transform.position.z);
            Vector3 positionNutRight = new Vector3(gameObject.transform.position.x + 1, gameObject.transform.position.y, gameObject.transform.position.z);
            Vector3 positionNutLeftWhenFacingBack = new Vector3(gameObject.transform.position.x - 1, gameObject.transform.position.y, gameObject.transform.position.z);
            Vector3 positionNutRightWhenFacingBack = new Vector3(gameObject.transform.position.x + 1, gameObject.transform.position.y, gameObject.transform.position.z);
            
            if(previousValue == 1 && throwDirection.x == 1){
                Instantiate(nut, positionNutRight, gameObject.transform.rotation).GetComponent<Rigidbody>().AddForce(transform.forward * 1000f);
                Invoke("DestroyNut", 2f);
                imageNut.SetActive(false);
            }
            else if(previousValue == -1 && throwDirection.x == -1)
            {
                Instantiate(nut, positionNutLeft, gameObject.transform.rotation).GetComponent<Rigidbody>().AddForce(transform.forward * 1000f); 
                Invoke("DestroyNut", 2f);
                imageNut.SetActive(false);
            }
            else if(previousValue == -1 && throwDirection.x == 0)
            {
                Instantiate(nut, positionNutLeftWhenFacingBack, gameObject.transform.rotation).GetComponent<Rigidbody>().AddForce((transform.right * -1) * 1000f); 
                Invoke("DestroyNut", 2f);
                imageNut.SetActive(false);
            }
            if(previousValue == 1 && throwDirection.x == 0)
            {
                Instantiate(nut, positionNutRightWhenFacingBack, gameObject.transform.rotation).GetComponent<Rigidbody>().AddForce(transform.right * 1000f);
                Invoke("DestroyNut", 2f);
                imageNut.SetActive(false);
            }
            
        }  
    }



    //------- Cette fonction sert a detruire la noix lance apres un certain temps -------//
    private void DestroyNut(){
        GameObject nutInstantiate = GameObject.FindGameObjectWithTag("NutThrowed");
        Destroy(nutInstantiate);
    }



    //------- Cette fonction sert a detecter lorsqu'un joueur recupere une noix pour la faire reaparaitre -------//
    private void NutDetection(){
        RaycastHit hit;
        Physics.Raycast(transform.position, transform.forward, out hit, 0.7f);

        if(hit.transform.tag == "Nut"){
           nutLoaded = true;
           nutFixedPosition = hit.transform.position; 
           nutFixedRotation = hit.transform.rotation; 
           Invoke("RespawnNut", 3.5f);
        }
    }

    

    //------- Cette fonction sert a faire reaparaitre la noix prise par le joueur -------//
    private void RespawnNut(){
        Instantiate(nutFixed, nutFixedPosition, nutFixedRotation);
    }
    


 //------- Cette fonction active l'input system -------//
    private void OnEnable()
    {
        inputActions.Enable();
    }

    //------- Cette fonction d�sactive l'input system -------//
    private void OnDisable()
    {
        inputActions.Disable();
    }




}