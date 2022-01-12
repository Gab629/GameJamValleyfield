using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Noix : MonoBehaviour
{
    //public GameObject damageEffect;
    public float damageAmount;

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Ennemy") {
            Debug.Log("CONTACT");
            other.GetComponent<Ennemy>().TakeDamage(damageAmount);
            Destroy(gameObject);
        }

    }

/*     private void OnCollisionEnter(Collision col) {
        if (col.gameObject.tag == "Ennemy") {
            col.gameObject.GetComponent<Ennemy>().TakeDamage(damageAmount);
            Destroy(gameObject);
        }

    } */
}
