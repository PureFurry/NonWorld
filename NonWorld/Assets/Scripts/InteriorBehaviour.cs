using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteriorBehaviour : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {}
            Spawner.Instance.canSpawnable = false;
        }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player"))
        {
            Spawner.Instance.canSpawnable = true;
        }
    }
    
}
