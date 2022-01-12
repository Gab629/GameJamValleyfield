using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyors : MonoBehaviour
{

    // ============================== **
    // SOURCES DES TUTORIELS
    // ==============================
    // Video URL : https://www.youtube.com/watch?v=hC1QZ0h4oco (conveyor)
    // ============================== **

    private Rigidbody rbConveyor;
    private string tagConveyor;
    private float convSpeed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        rbConveyor = GetComponent<Rigidbody>();
        tagConveyor = gameObject.transform.tag;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Conveyor();
    }


    private void Conveyor(){
        if(tagConveyor == "convLeft")
        {
            Vector3 position = rbConveyor.position;
            rbConveyor.position += Vector3.right * convSpeed * Time.fixedDeltaTime;
            rbConveyor.MovePosition(position); 
        }
        else if(tagConveyor == "convRight")
        {
            Vector3 position = rbConveyor.position;
            rbConveyor.position += Vector3.left * convSpeed * Time.fixedDeltaTime;
            rbConveyor.MovePosition(position); 
        }
        
    } 
}