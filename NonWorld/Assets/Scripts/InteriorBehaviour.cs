using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class InteriorBehaviour : MonoBehaviour
{
    [SerializeField]ShadowCaster2D shadowCaster2D;
    [SerializeField]GameObject door;
    private void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            door.GetComponent<Animator>().SetBool("IsOpen", true);
            shadowCaster2D.enabled = false;
            Spawner.Instance.canSpawnable = false;
        }
            
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player"))
        {
            door.GetComponent<Animator>().SetBool("IsOpen", false);
            shadowCaster2D.enabled = true;
            Spawner.Instance.canSpawnable = true;
        }
    }
    
}
