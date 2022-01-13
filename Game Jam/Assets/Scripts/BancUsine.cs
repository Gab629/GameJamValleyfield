using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BancUsine : MonoBehaviour
{
    private GameObject Banc;
    private Animator animBanc;

    void Start(){
        Banc = GameObject.Find("banc_2");
        animBanc = Banc.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "NutThrowed") {
            animBanc.SetBool("peutTomber", true);
        }        
    }
}
