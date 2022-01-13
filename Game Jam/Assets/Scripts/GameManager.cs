using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isPlaying = false;

    public void gameStatus() {
        if (isPlaying) {
            isPlaying = false;
        } else if (!isPlaying) {
            isPlaying = true;
        }
    }
}
