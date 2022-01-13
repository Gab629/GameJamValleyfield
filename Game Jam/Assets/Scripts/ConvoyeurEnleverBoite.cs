using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConvoyeurEnleverBoite : MonoBehaviour
{
    
    private GameObject boite;
    private Vector3 positionBoite;

    private Vector3 rotationBoite;

    private Quaternion rotation;

    void Start(){

        boite = GameObject.FindGameObjectWithTag("BoiteConvoyeur");

        positionBoite = boite.transform.position;
        rotationBoite = boite.transform.eulerAngles;
        
    }
    void Update() {
        boite = GameObject.FindGameObjectWithTag("BoiteConvoyeur");
    } 
     private void OnTriggerEnter(Collider other) {
        if (other.tag == "BoiteConvoyeur") {
            Destroy(other.gameObject);
            RespawnBoite();
        }        
    }

    private void RespawnBoite(){
        Instantiate(boite, positionBoite, rotation);
    }
}
