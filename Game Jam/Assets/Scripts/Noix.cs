using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Noix : MonoBehaviour
{
    public float damageAmount;

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Ennemy") {
            Debug.Log("CONTACT");
            other.GetComponent<Ennemy>().TakeDamage(damageAmount);
            Destroy(gameObject);
        }

    }
}
