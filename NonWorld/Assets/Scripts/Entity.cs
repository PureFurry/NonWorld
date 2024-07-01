using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Entity", menuName = "Entity", order = 0)]
public class Entity : ScriptableObject {
    public string entityName;
    public float entityHealth;
    public float entitySpeed;
    public float entityDamage;
    public int droppedCorrption;
    public float droppedCorruptionLevel;
    
}

