using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //

public class EnnemyTower : MonoBehaviour
{

    // Pour detecter l'etat de l'ennemi
    private string currentState = "Idle";
    private Transform target;

    // Canvas object
    public Slider slider;

    private bool isSeeingPlayer = false;
    private bool playerLeft = false;

    public float attackRange = 6f;

    //TEST
    public GameObject waterDrop;

    private bool isThrowing = false;

    private Vector3 waterFixedPosition;
    private Quaternion waterFixedRotation;

/*     private float currentValue;
    private float previousValue; */
    private Vector2 throwDirection;
    //


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        RotateEnemyRight();
        AttackDetector();
    }

    // Update is called once per frame
    void Update() {
        float distance = Vector3.Distance(transform.position, target.position);

        if (isSeeingPlayer) {
             if (target.position.x > transform.position.x) {
                //vers la droite
                transform.rotation = Quaternion.Euler(0,0,0);

                slider.direction = Slider.Direction.LeftToRight;
                Debug.Log("vers la droite");

                //TEST
                throwDirection = new Vector2(1,0);

            } else {
                //vers la gauche
                transform.rotation = Quaternion.Euler(0,180,0);

                slider.direction = Slider.Direction.RightToLeft;
                Debug.Log("vers la gauche");

                //TEST
                throwDirection = new Vector2(-1,0);
            }


            if (distance > attackRange) {
                isSeeingPlayer = false;
                Invoke("RotateEnemyLeft", 2f); 
                Debug.Log("joueur perdu");

            }

            if (isThrowing) {
                Attack();

                isThrowing = false;
            }
        }

    }

    private void RotateEnemyRight() {
        transform.rotation =  Quaternion.Euler(0, 180, 0);
        slider.direction = Slider.Direction.RightToLeft;

        if (!isSeeingPlayer) {
            Invoke("RotateEnemyLeft", 2f); 
        }

    }

    private void RotateEnemyLeft() {
        transform.rotation =  Quaternion.Euler(0, 0, 0);
        slider.direction = Slider.Direction.LeftToRight;

        if (!isSeeingPlayer) {
            Invoke("RotateEnemyRight", 2f);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            isSeeingPlayer = true;
            //AttackDetector();
            Debug.Log("detecte le joueur");
        }

    }


    //TEST
    private void AttackDetector() {
        isThrowing = true;

        Invoke("AttackDetector", 1f);
    }

    private void Attack() {
        Vector3 positionWaterLeft = new Vector3(gameObject.transform.position.x - 1, gameObject.transform.position.y, gameObject.transform.position.z);
        Vector3 positionWaterRight = new Vector3(gameObject.transform.position.x + 1, gameObject.transform.position.y, gameObject.transform.position.z);
            
        if(throwDirection.x == 1){
            Instantiate(waterDrop, positionWaterRight, gameObject.transform.rotation).GetComponent<Rigidbody>().AddForce(transform.right * 1000f);
            Invoke("DestroyWaterDrop", 1f);
        }
        else if(throwDirection.x == -1)
        {
            Instantiate(waterDrop, positionWaterLeft, gameObject.transform.rotation).GetComponent<Rigidbody>().AddForce(new Vector3(-1,0,0) * 1000f); 
            Invoke("DestroyWaterDrop", 1f);
        }

    }

    private void DestroyWaterDrop() {
        GameObject waterDropInstantiate = GameObject.FindGameObjectWithTag("WaterThrowed");
        Destroy(waterDropInstantiate);
    }


}
