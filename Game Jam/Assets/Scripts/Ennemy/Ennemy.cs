using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //

public class Ennemy : MonoBehaviour
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

    // Valeurs de vie
    public float health;
    public float maxHealth = 100f;

    // Canvas object
    public GameObject healthBarUI;
    public Slider slider;

    //TODO: variable public pour l'Animator


    // ============================== **
    // Methode Start()
    // ============================== **
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;

        health = maxHealth;
        slider.value = CalculateHealth();
    }

    // ============================== **
    // Methode Update()
    // ============================== **
    void Update()
    {
        CheckState();
        CheckHealth();
    }


    // ============================== **
    // Methode CheckHealth()
    // Verifie la vie restante de l'ennemi
    // ============================== **
    private void CheckHealth() {
        slider.value =  CalculateHealth();

        // Montre le slider si l'ennemi recoit des degats
        if (health < maxHealth) {
            healthBarUI.SetActive(true);
        }

        // Detruit le gameObject s'il n'a plus de vie
        if (health <= 0) {
            Destroy(gameObject);
        }

        // La vie ne peut depasser le maximum de vie
        if (health > maxHealth) {
            health = maxHealth;
        }
    }

    // ============================== **
    // Methode CalculateHealth()
    // Calcule le quotient de vie de l'ennemi
    // ============================== **
    float CalculateHealth() {
        return health / maxHealth;
    }

    // ============================== **
    // Methode TakeDamage()
    // Appele par le script Noix. Diminue la vie de l'ennemi.
    // ============================== **
    public void TakeDamage(float damage) {
        health -= damage;
    }

    // ============================== **
    // Methode CheckState()
    // Met a jour l'etat d'action de l'ennemi.
    // ============================== **
    private void CheckState() {
        float distance = Vector3.Distance(transform.position, target.position);

        if (currentState == "Idle") {

            //Changement d'etat vers la Chasse
            if (distance < chaseRange) {
                currentState = "Chase";
            }

        } else if (currentState == "Chase") {

            //TODO: Animation de chasse

            if (target.position.x > transform.position.x) {
                //vers la droite
                transform.Translate(transform.right * speed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0,180,0);

                slider.direction = Slider.Direction.LeftToRight;

            } else {
                //vers la gauche
                transform.Translate(-transform.right * speed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0,0,0);

                slider.direction = Slider.Direction.RightToLeft;
            }

            //Changement d'etat vers l'attaque
            if (distance < attackRange) {
                currentState = "Attack";
            }

            //Changement d'etat vers l'Idle
            if (distance > chaseRange) {
                currentState = "Idle";
            }

        } else if (currentState == "Attack") {
            //TODO: Animation d'attaque
            Debug.Log("Ennemi attaque");


            //Changement d'etat vers la Chasse
            if (distance > attackRange) {
                currentState = "Chase";
            }
        }
    }
}
