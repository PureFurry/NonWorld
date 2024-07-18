using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set;}
    public Inventory inventory;
    private void Awake() {
        inventory = new Inventory();
    }
    // Start is called before the first frame update
    void Start()
    {
        if (Instance != null){
            Instance = this;
        }
        DontDestroyOnLoad(this.gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
