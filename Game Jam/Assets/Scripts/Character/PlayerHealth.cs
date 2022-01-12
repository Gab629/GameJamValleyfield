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

    // Variable pour respawn
    private Vector3 positionCheckpoint;
    private Quaternion rotationCheckpoint;
    public GameObject character;

    private bool isImmune = false;
    public float immunityTime = 3f;
    private bool isDead = false;

    //TEST
    public int hitNb;

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
        RespawnCharacter();
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
            gameObject.SetActive(false);
            isDead = true;
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
            hitNb++;
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
    // Methode RespawnCharacter()
    // Fait revivre le joueur apres sa mort
    // ============================== **
    private void RespawnCharacter(){
        if(isDead == true){
            character.SetActive(true);
            character.transform.position = positionCheckpoint;
            isDead = false;
            health = 250f;
        }
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

        if(other.tag == "CheckPoint"){
           positionCheckpoint = other.transform.position;
           rotationCheckpoint = other.transform.rotation;
        }

        if(other.tag == "Spikes"){
            TakeDamage(other.gameObject.GetComponent<Noix>().damageAmount);
        }

    }
}
