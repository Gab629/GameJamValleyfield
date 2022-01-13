using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Mouvements : MonoBehaviour
{

    // ============================== **
    // SOURCES DES TUTORIELS
    // ==============================
    // Video URL : https://www.youtube.com/watch?v=hC1QZ0h4oco (conveyor)
    // ============================== **


    // Variables pour les components du personnage
    private CharacterController controller;
    public PlayerInput playerInput;
    private Vector3 playerVelocity;
    private Rigidbody rbCharacter;
    private Animator animCharacter;
    

    // Variables pour la detection de sol/murs, la gravite et le statut du personnage
    private float gravityValue = -9f;
    private bool groundedPlayer;
    private int wallTouched = 0;
    private float isJumping;   
    private int multipleJump = 2;
    private bool jumpCancelled = false;
    private bool JumpBool = false;
    private int multipleJumpCounter = 0;
  

    //Variables pour toutes les forces et vitesses concernant le personnage
    private float jumpForce = 200f;
    private float doubleJumpForce = 250f;
    private float doubleJumpForceWall = 250f;
    private float wallSlideSpeed = -100f;
    private float fallingSpeed = 5f;
    private float playerSpeed = 3f;
    public Vector2 input;
    public Vector3 move;
    private int onConveyor = 0;
    private float onConveyorSpeed = 2f;


    //Variables pour le nouveau input system
    private InputSystem inputActions;


    //Variable pour le dash
    private float isDashing;
     private float dashSpeed = 2f;
    private bool dashBool;

    //Variable pour le gliding
    private float glidingSpeed = -100f;
    private float isGliding;


    //Variable pour les commandes inversés
    public bool invertedCommands = false;
    


    //------- Cette fonction est appelle avant le start -------//
    private void Awake()
    {
        //Va chercher le nouveau input system
        inputActions = new InputSystem();

        //Permet d'aller chercher les inputs des touches pour le mouvement
        inputActions.PlayerMovements.Movements.performed += MovementsCharacter;
         //Remet les valeur a 0 lorsqu'on relache la touche
        inputActions.PlayerMovements.Movements.canceled += MovementsCharacter;
        
        //Permet d'aller chercher les inputs des touches pour le saut
        inputActions.PlayerMovements.Jump.performed += JumpButton;
        //Remet les valeur a 0 lorsqu'on relache la touche
        inputActions.PlayerMovements.Jump.canceled += JumpButton;
        
        //Permet d'aller chercher les inputs des touches pour le dash
        inputActions.PlayerMovements.Dash.performed += DashCharacter;
        //Remet les valeur a 0 lorsqu'on relache la touche
        inputActions.PlayerMovements.Dash.canceled += DashCharacter;

        //Permet d'aller chercher les inputs des touches pour le glididng
        inputActions.PlayerMovements.Gliding.performed += GlidingCharacter;
        //Remet les valeur a 0 lorsqu'on relache la touche
        inputActions.PlayerMovements.Gliding.canceled += GlidingCharacter;

    }



    //------- Start is called before the first frame update -------//
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        controller = GetComponent<CharacterController>();
        rbCharacter = GetComponent<Rigidbody>();
        animCharacter = GetComponent<Animator>();

        
        // calculate the correct vertical position:
        float correctHeight = controller.center.y + controller.skinWidth;
        // set the controller center vector:
        controller.center = new Vector3(0, correctHeight, 0);
    }



    //------- Update is called once per frame -------//
    void Update()
    {   
        Movements();
        Gliding(); //COMP GLIDING
        Dash(); //COMP DASH
        WallSlide(); //COMP WALLSLIDE
    }



     //------- Cette fonction est appele une fois ou plusieurs fois par frame (meilleur pour la physique) -------//
    void FixedUpdate()
    {
        Jump();
        DoubleJump(); //COMP DOUBLE JUMP
        OnConveyor();

    }



    void OnCollisionEnter(Collision collision){
        if(collision.transform.tag == "convLeft")
        {
            onConveyor = -1;
            //playerSpeed = 0.1f;
        }
        else if(collision.transform.tag == "convRight")
        {
            onConveyor = 1;
            //playerSpeed = 0.1f;
        }
    }

    void OnCollisionExit(Collision collision){
        if(collision.transform.tag == "convLeft" || collision.transform.tag == "convRight")
        {
            onConveyor = 0;
            playerSpeed = 3f;
        }
    }

    private void OnConveyor(){
        if(onConveyor == -1)
        {
            playerVelocity.x -= onConveyorSpeed * Time.deltaTime;

            if(playerVelocity.x <= -onConveyorSpeed)
            {
                 playerVelocity.x = -onConveyorSpeed;
            }

        }
        else if(onConveyor == 1)
        {
            playerVelocity.x += onConveyorSpeed * Time.deltaTime;

            if(playerVelocity.x >= onConveyorSpeed)
            {
                 playerVelocity.x = onConveyorSpeed;
            }

        }
        else
        {
            playerVelocity.x = 0f;
        }
    }



    //------- Cette fonction detecte si le bouton Espace est enfonce -------//
    private void JumpButton(InputAction.CallbackContext context)
    {
        
        JumpBool = true;
        
        Invoke("LessJumpMultiple", 0.05f);
        Invoke("JumpButtonCanceled", 0.05f);
        
    }



    //------- Cette fonction reduit le nombre de multipleJump -------//
    private void LessJumpMultiple(){
        
        multipleJump --;
    }



    //------- Cette fonction est call sert à remettre les bools pour doubleJump -------//
    private void JumpButtonCanceled()
    {
        
        jumpCancelled = true;
        JumpBool = false;
    }



    //------- Cette fonction fait sauter le personnage -------//
    private void Jump()
    {

        if(JumpBool == true){
            animCharacter.SetBool("jump", true);
        }else{
            animCharacter.SetBool("jump", false);
        }

        //Si le joueur appuie sur espace et qu'il est au sol
        if (JumpBool == true && controller.isGrounded){
            //Il peut sauter
           playerVelocity.y += jumpForce * Time.deltaTime;  
        }
        //Si le joueur n'appuie pas sur espace et qu'il est au sol
        else if (JumpBool == false && controller.isGrounded)
        {
            //Sa vitesse en Y est remise a zero
            playerVelocity.y = 0f;
        }
        //Si le joueur n'appuie pas sur espace et qu'il n'est pas au sol
        else if(JumpBool == false && controller.isGrounded != true)
        {
            //Il tombe plus vite (sentiment de jump plus fluide)
             playerVelocity.y -= fallingSpeed * Time.deltaTime;
        }
 
    }



    //------- Cette fonction permet de faire un double saut -------//
    private void DoubleJump(){

        //Si le joueur appuie sur espace, si il lui reste des sauts et qu'il a deja relacher espace une fois
        if(JumpBool == true && multipleJump >= 0 && jumpCancelled && wallTouched <= 0){
            //Le joueur peut sauter a nouveau dans les airs
            playerVelocity.y += doubleJumpForce * Time.deltaTime;
            //Le saut est pris en compte dans une variable
            multipleJumpCounter ++;

        //Si le joueur appuie sur espace et si il a touche le mur
        }else if(wallTouched > 0 && JumpBool == true)
        {
            //Le joueur peut sauter a nouveau dans les airs
            playerVelocity.y += doubleJumpForceWall * Time.deltaTime;
            //On detecte qu'il a saute du mur
            wallTouched --;
        }

        //Si le compteur de saut est plus grand que 1
        if(multipleJumpCounter >= 1){
            //Le joueur ne peut pas sauter a nouveau
            jumpCancelled = false;
        }
        if(multipleJump >= 2){
            jumpCancelled = false;
        }
        if(multipleJump <= 0){
            multipleJump = 0;
        }
    }



//------- Cette fonction permet de faire une glissade sur le mur -------//
    private void WallSlide(){
        
        //Sert a detecter la collision du rayon
        RaycastHit hit;
        //Cree un rayon invisible devant le personnage
        Physics.Raycast(transform.position, transform.forward, out hit, 0.30f);

        //Si le rayon est en train de toucher un mur
        if(hit.transform.tag == "Wall" && input.x != 0){

            //Le joueur descend plus lentement
            playerVelocity.y = wallSlideSpeed * Time.deltaTime;
            //On detecte que le joueur a touche le mur (pour un jump)
            wallTouched = 2;
        }
        
    }



    //------- Cette fonction detecte si le bouton droit de la souris est enfonce -------//
    private void GlidingCharacter(InputAction.CallbackContext context){
            isGliding = context.ReadValue<float>();
    }
    //------- Cette fonction permet de planer après avoir fait deux saut  -------//
    private void Gliding(){
        if(isGliding == 1 && controller.isGrounded != true && multipleJump <= 0){                
            playerVelocity.y = glidingSpeed * Time.deltaTime;
        }
        
    }


  
    //------- Cette fonction detecte si le bouton shift est enfonce -------//
    private void DashCharacter(InputAction.CallbackContext context){
        dashBool = true;
        Invoke("DashCharacterCanceled", 0.2f);
    }
    private void DashCharacterCanceled(){
        dashBool = false;
    }
    //------- Cette fonction permet au personnage de dasher -------//
    private void Dash(){

        if(dashBool == true && input.x != 0){
            animCharacter.SetBool("dash", true);
        }
        else
        {
            animCharacter.SetBool("dash", false);
        }

        if(dashBool == true && !invertedCommands)
        {
            move = new Vector3(input.x, 0, 0) * dashSpeed;
            controller.Move(move * Time.deltaTime * playerSpeed);
        }
        else if(dashBool == true && invertedCommands)
        {
            move = new Vector3(-input.x, 0, 0) * dashSpeed;
            controller.Move(move * Time.deltaTime * playerSpeed);
        }
    }


    //------- Cette fonction detecte si les boutons WASD sont enfonce -------//
    private void MovementsCharacter(InputAction.CallbackContext context)
    {
        input = context.ReadValue<Vector2>();
       
    }



//------- Cette fonction fait bouger le personnage -------//
    private void Movements(){

        if(input.x != 0){
            animCharacter.SetBool("peutCourir", true);
        }else{
            animCharacter.SetBool("peutCourir", false);
        }

        //Verifie si le joueur touche le sol
        groundedPlayer = controller.isGrounded;

        //Si le joueur touche le sol, on reset ses sauts
        if(controller.isGrounded){
            multipleJump = 2;
            multipleJumpCounter = 0;
            wallTouched = 0;
        } 
        
        if(!invertedCommands){
            //Rotationne le personnage dans la direction voulu
            if(input.x >= 1){
                transform.eulerAngles = new Vector3(0.0f, 90f, 0.0f);
            }else if(input.x <= -1){
                transform.eulerAngles = new Vector3(0.0f, 270f, 0.0f);
            }
            //Met les inputs choisis dans la variable move (boutons enfonces)
            move = new Vector3(input.x, 0, 0);
            //Bouge le joueur dans la direction definie par le move
            controller.Move(move * Time.deltaTime * playerSpeed);

            //Permet au joueur detre affecte par la gravite
            playerVelocity.y += gravityValue * Time.deltaTime;
            //Permet au joueur detre affecte par sa velocite
            controller.Move(playerVelocity * Time.deltaTime);    
        }else{
            //Rotationne le personnage dans la direction voulu
            if(input.x >= 1){
                transform.eulerAngles = new Vector3(0.0f, 90f, 0.0f);
            }else if(input.x <= -1){
                transform.eulerAngles = new Vector3(0.0f, 270f, 0.0f);
            }
            //Met les inputs choisis dans la variable move (boutons enfonces)
            move = new Vector3(-input.x, 0, 0);
            //Bouge le joueur dans la direction definie par le move
            controller.Move(move * Time.deltaTime * playerSpeed);

            //Permet au joueur d'etre affecte par la gravite
            playerVelocity.y += gravityValue * Time.deltaTime;
            //Permet au joueur d'etre affecte par sa velocite
            controller.Move(playerVelocity * Time.deltaTime);    
        }
        
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