using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //

public class PlayerHealth : MonoBehaviour
{
    // Valeurs de vie
    public float health;
    public float maxHealth = 100f;

    // Canvas object
    public GameObject healthBarUI;
    public Slider slider;

    //TEST
    private bool isImmune = false;
    public float immunityTime = 3f;

    //TODO: variable public pour l'Animator


    // ============================== **
    // Methode Start()
    // ============================== **
    void Start()
    {
        health = maxHealth;
        slider.value = CalculateHealth();
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
    private void TakeDamage(float damage) {

        if (!isImmune) {
            health -= damage;
            isImmune = true;
            Invoke("DisableImmunity", immunityTime);
        }

    }

    // ============================== **
    // Methode DisableImmunity()
    // Enleve l'immunite du joueur apres un delai
    // ============================== **
    private void DisableImmunity() {
        isImmune = false;
    }

    // ============================== **
    // Methode DisableInvertedCommands()
    // Enleve l'immunite du joueur apres un delai
    // ============================== **
    private void DisableInvertedCommands() {
        gameObject.GetComponent<Mouvements>().invertedCommands = false;
    }

    // ============================== **
    // Methode OnTriggerEnter()
    // Detecte les obstacles causant des degats
    // ============================== **
    private void OnTriggerEnter(Collider other) {

        if (other.tag == "WaterThrowed") {
            TakeDamage(other.gameObject.GetComponent<Noix>().damageAmount);

            if (!gameObject.GetComponent<Mouvements>().invertedCommands) {
                gameObject.GetComponent<Mouvements>().invertedCommands = true;
                Invoke("DisableInvertedCommands", immunityTime);
            }

            Destroy(other.gameObject);
        }

        if (other.tag == "EnnemyPunch") {
            TakeDamage(other.gameObject.GetComponent<Noix>().damageAmount);
        }

    }
}
