using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //

public class Ennemy : MonoBehaviour
{
    // Valeurs de vie
    public float health;
    public float maxHealth = 100f;

    // Canvas object
    public GameObject healthBarUI;
    public Slider slider;

    //TODO: variable public pour l'Animator
    private Animator animator;


    // ============================== **
    // Methode Start()
    // ============================== **
    void Start()
    {
        health = maxHealth;
        slider.value = CalculateHealth();
        animator = gameObject.GetComponent<Animator>();
    }

    // ============================== **
    // Methode Update()
    // ============================== **
    void Update()
    {
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

        // Detruit le gameObject s'il n'a plus de vie
        if (health <= 0)
        {
            animator.SetTrigger("die");
            Invoke("KillEnnemy", 6.0f);
        }
    }


    private void KillEnnemy()
    {
        Destroy(gameObject);
    }
}
