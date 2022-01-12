using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Mouvements : MonoBehaviour
{
    // Variables pour les components du personnage
    private CharacterController controller;
    public PlayerInput playerInput;
    private Vector3 playerVelocity;
    private Rigidbody rbCharacter;
    

    // Variables pour la detection de sol, la gravite et le statut de jump du personnage
    private float gravityValue = -9f;
    private bool groundedPlayer;
    private float isJumping;   
    [SerializeField] private int multipleJump = 2;
    [SerializeField] private bool jumpCancelled = false;

    private int multipleJumpCounter = 0;

    [SerializeField] private bool JumpBool = false;
  

    //Variables pour toutes les forces et vitesses concernant le personnage
    private float jumpForce = 300f;
    private float doubleJumpForce = 250f;

    private float fallingSpeed = 5f;
    private float playerSpeed = 3f;
    public Vector2 input;
    public Vector3 move;
    


    //Variables pour le nouveau input system
    private InputSystem inputActions;


    //Variable pour le dash
    [SerializeField] private float isDashing;

     private float dashSpeed = 5f;

    [SerializeField] private bool dashBool;
    //------- Cette fonction est appelle avant le start -------//
    private void Awake()
    {
        //Va chercher le nouveau input system
        inputActions = new InputSystem();

        //Permet d'aller chercher les inputs des touches pour le mouvement
        inputActions.PlayerMovements.Movements.performed += MovementsCharacter;
        
        inputActions.PlayerMovements.Movements.canceled += MovementsCharacter;
        //Permet d'aller chercher les inputs des touches pour le saut
        inputActions.PlayerMovements.Jump.performed += JumpButton;
        //Remet les valeur a 0 lorsqu'on relache la touche
        inputActions.PlayerMovements.Jump.canceled += JumpButton;

        //Appelle la fonction JumpButtonCancelled lorsqu'on relache espace
        // inputActions.PlayerMovements.Jump.canceled += JumpButtonCanceled; 
        
        //Permet d'aller chercher les inputs des touches pour le saut
        inputActions.PlayerMovements.Dash.performed += DashCharacter;
        //Remet les valeur a 0 lorsqu'on relache la touche
        inputActions.PlayerMovements.Dash.canceled += DashCharacter;
    }



    //------- Start is called before the first frame update -------//
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        controller = GetComponent<CharacterController>();
        rbCharacter = GetComponent<Rigidbody>();
    }



    //------- Update is called once per frame -------//
    void Update()
    {   
        Movements();
        Dash(); //COMP DASH
        
    }



     //------- Cette fonction est appele une fois ou plusieurs fois par frame (meilleur pour la physique) -------//
    void FixedUpdate()
    {
        Jump();
        
        DoubleJump(); //COMP DOUBLE JUMP

    }


    
    //------- Cette fonction detecte si le bouton Espace est enfonce -------//
    private void JumpButton(InputAction.CallbackContext context)
    {
        
        // isJumping = context.ReadValue<float>();
        JumpBool = true;
        
        Invoke("LessJumpMultiple", 0.05f);
        Invoke("JumpButtonCanceled", 0.5f);
        
    }
    private void LessJumpMultiple(){
        
        multipleJump --;
    }
    //------- Cette fonction detecte si le bouton Espace est relache -------//
    private void JumpButtonCanceled()
    {
        
        jumpCancelled = true;
        JumpBool = false;
    }

    //------- Cette fonction fait sauter le personnage -------//
    private void Jump()
    {
        if (JumpBool == true && controller.isGrounded){
           playerVelocity.y += jumpForce * Time.deltaTime;
        }
        else if (JumpBool == false && controller.isGrounded)
        {
            playerVelocity.y = 0f;
        }
        else if(JumpBool == false && controller.isGrounded != true)
        {
             playerVelocity.y -= fallingSpeed * Time.deltaTime;
        }
 
    }

    //------- Cette fonction permet de faire un double saut -------//
    private void DoubleJump(){

        //Si le joueur appuie sur espace, si il lui reste des sauts et qu'il a deja relacher espace une fois
        if(JumpBool == true && multipleJump >= 0 && jumpCancelled == true){
            //Le joueur peut sauter a nouveau dans les airs
            playerVelocity.y += doubleJumpForce * Time.deltaTime;
            //Le saut est pris en compte dans une variable
            multipleJumpCounter ++;
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


    //------- Cette fonction detecte si le bouton E est enfonce -------//
    private void DashCharacter(InputAction.CallbackContext context){
        dashBool = true;
        Invoke("DashCharacterCanceled", 0.2f);
    }
    private void DashCharacterCanceled(){
        dashBool = false;
    }
    //------- Cette fonction permet au personnage de dasher -------//
    private void Dash(){
        if(dashBool == true){
             move = new Vector3(input.x, 0, input.y) * dashSpeed;
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
        //Verifie si le joueur touche le sol
        groundedPlayer = controller.isGrounded;

        //Si le joueur touche le sol, on reset ses sauts
        if(controller.isGrounded){
            multipleJump = 2;
            multipleJumpCounter = 0;
        } 
        
        //Bouge le joueur dans une direction choisie plus bas
        gameObject.transform.forward = move;
        //Met les inputs choisis dans la variable move (boutons enfonces)
        move = new Vector3(input.x, 0, input.y);
        //Bouge le joueur dans la direction definie par le move
        controller.Move(move * Time.deltaTime * playerSpeed);

        //Permet au joueur detre affecte par la gravite
        playerVelocity.y += gravityValue * Time.deltaTime;
        //Permet au joueur detre affecte par sa velocite
        controller.Move(playerVelocity * Time.deltaTime);  
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
