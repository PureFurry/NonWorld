using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public void StopGame(){
        Time.timeScale = 0f;
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player"))
        {
            StopGame();
        }
    }

    
}
