using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;//

public class BoxManager : MonoBehaviour
{

    public PlayerInput playerInput;
    private InputSystem inputActions;


    public GameObject boxCarried;
    public GameObject boxNotCarried;

    public bool hasBox;
    private bool canTakeBox = false;

    private Vector3 positionLeft;
    private Vector3 positionRight;

    private float characterHealth;
    [SerializeField]private bool isCharacterDead;

    private GameObject GameManager;


    void Awake() {
        inputActions = new InputSystem();

        inputActions.PlayerMovements.Carry.performed += CarryButton;
        inputActions.PlayerMovements.Carry.canceled += CarryButton;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();

        hasBox = true;

        GameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        positionLeft = new Vector3(gameObject.transform.position.x - 1, gameObject.transform.position.y, gameObject.transform.position.z);
        positionRight = new Vector3(gameObject.transform.position.x + 1, gameObject.transform.position.y, gameObject.transform.position.z);

        if (gameObject.GetComponent<PlayerHealth>().hitNb >= 2 && hasBox) {
            PuttingDown();
            gameObject.GetComponent<PlayerHealth>().hitNb = 0;
        }
    }

    

    private void CarryButton(InputAction.CallbackContext context){
        if (GameManager.GetComponent<GameManager>().isPlaying) {
            if (hasBox) {
                PuttingDown();

            } else if (!hasBox && canTakeBox){
                TakeBox();

            }
        }
    }

    private void PuttingDown() {
        boxCarried.SetActive(false);
        hasBox = false;

        if (transform.rotation == Quaternion.Euler(0,270,0)) {
            Instantiate(boxNotCarried, positionLeft, gameObject.transform.rotation).SetActive(true);

        } else if (transform.rotation == Quaternion.Euler(0,90,0)) {
            Instantiate(boxNotCarried, positionRight, gameObject.transform.rotation).SetActive(true);
        }

    }

    private void TakeBox() {
        boxCarried.SetActive(true);
        hasBox = true;

        GameObject boxIndependant = GameObject.FindGameObjectWithTag("Box");
        Destroy(boxIndependant);
    }

    public void ResetBox(){
        
        boxCarried.SetActive(true);
        hasBox = true;

        GameObject boxIndependant = GameObject.FindGameObjectWithTag("Box");
        Destroy(boxIndependant);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Box") {
            canTakeBox = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "Box") {
            canTakeBox = false;
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
