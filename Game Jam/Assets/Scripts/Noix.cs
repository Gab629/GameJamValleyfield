using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Noix : MonoBehaviour
{
    //public GameObject damageEffect;
    public float damageAmount;

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Ennemy") {
            other.GetComponent<Ennemy>().TakeDamage(damageAmount);
            Destroy(gameObject);
        }

    }
}
