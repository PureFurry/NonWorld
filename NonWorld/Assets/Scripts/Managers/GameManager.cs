using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{



    public static GameManager Instance { get; private set;}
    [SerializeField]int curroptionCore;
    public int CurroptionCore { get => curroptionCore; set => curroptionCore = value; }

    private void Awake() {
        if (this.gameObject == null)
        {
            Instantiate(this.gameObject);
        }
        else{
            Instance = this;
        }
    }

    

    

}
