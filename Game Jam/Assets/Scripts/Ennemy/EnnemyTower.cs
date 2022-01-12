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

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        RotateEnemyRight();
    }

    // Update is called once per frame
    void Update() {
        if (isSeeingPlayer) {
             if (target.position.x > transform.position.x) {
                //vers la droite
                transform.rotation = Quaternion.Euler(0,0,0);

                slider.direction = Slider.Direction.RightToLeft;

            } else {
                //vers la gauche
                transform.rotation = Quaternion.Euler(0,180,0);

                slider.direction = Slider.Direction.LeftToRight;
            }
        }
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

        Invoke("RotateEnemyLeft", 2f);
    }

    private void RotateEnemyLeft() {
        transform.rotation =  Quaternion.Euler(0, 0, 0);
        slider.direction = Slider.Direction.LeftToRight;

        Invoke("RotateEnemyRight", 2f);
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

    private void OnTriggerExit(Collider other) {
        isSeeingPlayer = false;
        Debug.Log("joueur parti");
    }

}
