using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //

public class EnnemyTower : MonoBehaviour
{

    // Pour detecter le joueur
    private Transform target;
    
    private bool isSeeingPlayer = false;
    private bool playerLeft = false;

    public float attackRange = 6f;

    // Pour la vie
    public Slider slider;

    //Pour l'attaque
    public GameObject waterDrop;

    private bool isThrowing = false;
    public float throwingSpeed = 2f;

    private Vector3 waterFixedPosition;
    private Quaternion waterFixedRotation;

    private Vector2 throwDirection;


    // ============================== **
    // Methode Start()
    // ============================== **
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        RotateEnemyRight();
        AttackDetector();
    }

    // ============================== **
    // Methode Update()
    // ============================== **
    void Update() {
        float distance = Vector3.Distance(transform.position, target.position);

        if (isSeeingPlayer) {
             if (target.position.x > transform.position.x) {
                // vers la droite
                transform.rotation = Quaternion.Euler(0,0,0);
                slider.direction = Slider.Direction.LeftToRight;
                throwDirection = new Vector2(1,0);

            } else {
                // vers la gauche
                transform.rotation = Quaternion.Euler(0,180,0);
                slider.direction = Slider.Direction.RightToLeft;
                throwDirection = new Vector2(-1,0);
            }

            // Detecte si le joueur est sortie du champ de vision
            if (distance > attackRange) {
                isSeeingPlayer = false;
                Invoke("RotateEnemyLeft", 2f); 
                Debug.Log("joueur perdu");

            }

            // Determine si le gameObject peut attaquer
            if (isThrowing) {
                Attack();
                isThrowing = false;
            }
        }

    }

    // ============================== **
    // Methode RotateEnemyRight()
    // Tourne le gameObject vers la droite
    // Mode Idle
    // ============================== **
    private void RotateEnemyRight() {
        transform.rotation =  Quaternion.Euler(0, 180, 0);
        slider.direction = Slider.Direction.RightToLeft;

        if (!isSeeingPlayer) {
            Invoke("RotateEnemyLeft", 2f); 
        }

    }

    // ============================== **
    // Methode RotateEnemyLeft()
    // Tourne le gameObject vers la gauche
    // Mode Idle
    // ============================== **
    private void RotateEnemyLeft() {
        transform.rotation =  Quaternion.Euler(0, 0, 0);
        slider.direction = Slider.Direction.LeftToRight;

        if (!isSeeingPlayer) {
            Invoke("RotateEnemyRight", 2f);
        }
    }

    // ============================== **
    // Methode OnTriggerEnter()
    // Detecte le joueur
    // ============================== **
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            isSeeingPlayer = true;
        }

    }


    // ============================== **
    // Methode AttackDetector()
    // Invoke l'attaque du gameObject
    // ============================== **
    private void AttackDetector() {
        isThrowing = true;

        Invoke("AttackDetector", throwingSpeed);
    }

    // ============================== **
    // Methode Attack()
    // Attaque du GameObject
    // ============================== **
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

    // ============================== **
    // Methode DestroyWaterDrop()
    // Detruit les waterDrop
    // ============================== **
    private void DestroyWaterDrop() {
        GameObject waterDropInstantiate = GameObject.FindGameObjectWithTag("WaterThrowed");
        Destroy(waterDropInstantiate);
    }


}
