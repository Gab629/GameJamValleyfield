using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isPlaying = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeBool() {
        if (isPlaying) {
            isPlaying = false;
        } else if (!isPlaying) {
            isPlaying = true;
        }
    }
}
