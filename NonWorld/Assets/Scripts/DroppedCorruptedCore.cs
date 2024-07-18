using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedCorruptedCore : MonoBehaviour
{
    public int storedCorruptepCore;
    private void Awake() {
        DontDestroyOnLoad(this.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.CurroptionCore = storedCorruptepCore;
            Destroy(this.gameObject);
        }
    }
}
