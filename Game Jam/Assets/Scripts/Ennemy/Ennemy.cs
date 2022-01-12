using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //

public class Ennemy : MonoBehaviour
{
    // Video URL : https://www.youtube.com/watch?v=WluxMKsL1o4&ab_channel=GDTitans
    //             https://www.youtube.com/watch?v=1V0kkTUc5ns&ab_channel=DanCS 

    private string currentState = "Idle";
    private Transform target;

    public float chaseRange = 5f;
    public float attackRange = 1.5f;
    public float speed = 3f;

    // Valeurs de vie
    public float health;
    public float maxHealth = 100f;

    // Canvas object
    public GameObject healthBarUI;
    public Slider slider;

    //TODO - Animator


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;

        //
        health = maxHealth;
        slider.value = CalculateHealth();
    }

    // Update is called once per frame
    void Update()
    {
        CheckState();
        CheckHealth();
    }

    private void CheckHealth() {
        slider.value =  CalculateHealth();

        // Montre le slider si l'ennemi reçoit des dégats
        if (health < maxHealth) {
            healthBarUI.SetActive(true);
        }

        // Détruit le gameObject s'il n'a plus de vie
        if (health <= 0) {
            Destroy(gameObject);
        }

        // La vie ne peut dépasser le maximum de vie
        if (health > maxHealth) {
            health = maxHealth;
        }
    }

    float CalculateHealth() {
        return health / maxHealth;
    }

    //
    public void TakeDamage(float damage) {
        health -= damage;
    }
    //

    private void CheckState() {
        float distance = Vector3.Distance(transform.position, target.position);

        if (currentState == "Idle") {

            if (distance < chaseRange) {
                currentState = "Chase";
            }

        } else if (currentState == "Chase") {

            //TODO - Animation de chasse

            if (target.position.x > transform.position.x) {
                //move right
                transform.Translate(transform.right * speed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0,180,0);

            } else {
                //move left
                transform.Translate(-transform.right * speed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0,0,0);
            }

            if (distance < attackRange) {
                currentState = "Attack";
            }

            if (distance > chaseRange) {
                currentState = "Idle";
            }

        } else if (currentState == "Attack") {
            //TODO - Animation d'attaque
            Debug.Log("Ennemi attaque");


            //Changement de State
            if (distance > attackRange) {
                currentState = "Chase";
            }
        }
    }
}
