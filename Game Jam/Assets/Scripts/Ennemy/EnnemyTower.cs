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

    // TEST
    private bool isSeeingPlayer = false;
    private bool playerLeft = false;

    public float attackRange = 6f;

    //
    private int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        RotateEnemyRight();
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

            } else {
                //vers la gauche
                transform.rotation = Quaternion.Euler(0,180,0);

                slider.direction = Slider.Direction.RightToLeft;
                Debug.Log("vers la gauche");
            }


            if (distance > attackRange) {
                isSeeingPlayer = false;
                Invoke("RotateEnemyLeft", 2f); 
                Debug.Log("joueur perdu");
            }
        }


    //
/*         while (i > 1) {
            RotateEnemyRight();
            Debug.Log(i);
            i = 0;
            Debug.Log(i);
        } */
    }


/*     void Update()
    {
        CheckState();
    }

    private void CheckState() {
        float distance = Vector3.Distance(transform.position, target.position);


    } */

    //TEST
    private void RotateEnemyRight() {
        transform.rotation =  Quaternion.Euler(0, 180, 0);
        slider.direction = Slider.Direction.RightToLeft;

/*         while (isSeeingPlayer) {
             if (target.position.x > transform.position.x) {
                //vers la droite
                transform.rotation = Quaternion.Euler(0,0,0);

                slider.direction = Slider.Direction.LeftToRight;
                Debug.Log("vers la droite");

            } else {
                //vers la gauche
                transform.rotation = Quaternion.Euler(0,180,0);

                slider.direction = Slider.Direction.RightToLeft;
                Debug.Log("vers la gauche");
            }
        } */

        if (!isSeeingPlayer) {
            Invoke("RotateEnemyLeft", 2f); 
        }

    }

    private void RotateEnemyLeft() {
        transform.rotation =  Quaternion.Euler(0, 0, 0);
        slider.direction = Slider.Direction.LeftToRight;

/*         while (isSeeingPlayer) {
             if (target.position.x > transform.position.x) {
                //vers la droite
                transform.rotation = Quaternion.Euler(0,0,0);

                slider.direction = Slider.Direction.LeftToRight;
                Debug.Log("vers la droite");

            } else {
                //vers la gauche
                transform.rotation = Quaternion.Euler(0,180,0);

                slider.direction = Slider.Direction.RightToLeft;
                Debug.Log("vers la gauche");
            }
        } */

        if (!isSeeingPlayer) {
            Invoke("RotateEnemyRight", 2f);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            isSeeingPlayer = true;
            Debug.Log("detecte le joueur");
        }

    }

/*     private void OnTriggerExit(Collider other) {
        if (other.tag == "Player") {
            isSeeingPlayer = false;
            Invoke("RotateEnemyRight", 2f);
            Debug.Log("joueur parti");
        }
    } */

/*     private void OnTriggerExit(Collider other) {
        isSeeingPlayer = false;

        Debug.Log("joueur parti");



        i++;
    } */

    private void PlayerState() {
/*         int i = 0;

        while (playerLeft) {
            Invoke("RotateEnemyRight", 2f);
            playerLeft = false;

            i++;
            Debug.Log("Index est : " + i);
        } */

        

    }

}
