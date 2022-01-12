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
/*     private Vector3 positionRight;
    private Vector3 positionLeftWhenFacingBack;
    private Vector3 positionRightWhenFacingBack; */

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
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(canTakeBox);

        positionLeft = new Vector3(gameObject.transform.position.x - 1, gameObject.transform.position.y, gameObject.transform.position.z);
        positionRight = new Vector3(gameObject.transform.position.x + 1, gameObject.transform.position.y, gameObject.transform.position.z);
        /* positionRight = new Vector3(gameObject.transform.position.x + 1, gameObject.transform.position.y, gameObject.transform.position.z);
        positionLeftWhenFacingBack = new Vector3(gameObject.transform.position.x - 1, gameObject.transform.position.y, gameObject.transform.position.z);
        positionRightWhenFacingBack = new Vector3(gameObject.transform.position.x + 1, gameObject.transform.position.y, gameObject.transform.position.z); */
    }

    private void CarryButton(InputAction.CallbackContext context){
        if (hasBox) {
            Invoke("PuttingDown", 0f);

        } else if (!hasBox && canTakeBox){
            Invoke("TakeBox", 0f);

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
