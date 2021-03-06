using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //

public class EnnemyPatrol : MonoBehaviour
{
    // ============================== **
    // SOURCES DES TUTORIELS
    // ==============================
    // Video URL : https://www.youtube.com/watch?v=WluxMKsL1o4&ab_channel=GDTitans
    //             https://www.youtube.com/watch?v=1V0kkTUc5ns&ab_channel=DanCS 
    // ============================== **

    // Pour detecter l'etat de l'ennemi
    private string currentState = "Idle";
    private Transform target;

    // Valeurs pour le mouvement
    public float chaseRange = 5f;
    public float attackRange = 1.5f;
    public float speed = 3f;
    private bool isMovingRight = false;
    private bool isAttacking = false;

    //TODO: variable public pour l'Animator
    private Animator animator;


    // Canvas object
    public Slider slider;
    public GameObject attackCollider;

    private GameObject gameManager;

    // ============================== **
    // Methode Start()
    // ============================== **
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        gameManager = GameObject.Find("GameManager");
        animator = gameObject.GetComponent<Animator>();
    }

    // ============================== **
    // Methode Update()
    // ============================== **
    void Update()
    {
        if (gameManager.GetComponent<GameManager>().isPlaying) {
            CheckState(); 
        }
    }

    // ============================== **
    // Methode CheckState()
    // Met a jour l'etat d'action de l'ennemi.
    // ============================== **
    private void CheckState() {
        float distance = Vector3.Distance(transform.position, target.position);

        if (currentState == "Idle") {

            // Gere la direction de l'ennemi quand le joueur n'est pas detecte
            if (isMovingRight) {
                transform.Translate(transform.right * speed/2 * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0,180,0);

                slider.direction = Slider.Direction.RightToLeft;

            } else {
                transform.Translate(-transform.right * speed/2 * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0,0,0);

                slider.direction = Slider.Direction.LeftToRight;
            }

            //Changement d'etat vers la Chasse
            if (distance < chaseRange) {
                currentState = "Chase";
                animator.SetBool("rage", true);
            }

        } else if (currentState == "Chase") {

            //TODO: Animation de chasse

            if (target.position.x > transform.position.x) {
                //vers la droite
                transform.Translate(transform.right * speed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0,180,0);

                slider.direction = Slider.Direction.RightToLeft;

            } else {
                //vers la gauche
                transform.Translate(-transform.right * speed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0,0,0);

                slider.direction = Slider.Direction.LeftToRight;
            }

            //Changement d'etat vers l'attaque
            if (distance < attackRange) {
                currentState = "Attack";
                animator.SetTrigger("attaquer");
            }

            //Changement d'etat vers l'Idle
            if (distance > chaseRange) {
                currentState = "Idle";
                animator.SetBool("rage", false);
            }

        } else if (currentState == "Attack") {
            //TODO: Animation d'attaque

            if (!isAttacking) {
                Invoke("AttackEnable", 0.5f);
            }


            //Changement d'etat vers la Chasse
            if (distance > attackRange) {
                currentState = "Chase";
            }
        }
    }

    // ============================== **
    // Methode AttackEnable()
    // Active le collider pour frapper le joueur
    // ============================== **
    private void AttackEnable() {
        isAttacking = true;
        attackCollider.SetActive(true);
        Invoke("AttackDisable", 1f);

    }

    // ============================== **
    // Methode AttackDisable()
    // Desactive le collider pour frapper le joueur
    // ============================== **
    private void AttackDisable() {
        attackCollider.SetActive(false);
        isAttacking = false;      
    }

    // Detecte les checkpoint qui gere sa direction
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "MoveTowardsLeft") {
            isMovingRight = false;
        }

        if (other.tag == "MoveTowardsRight") {
            isMovingRight = true;
        }
    }
}
