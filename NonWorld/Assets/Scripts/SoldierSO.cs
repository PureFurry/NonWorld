using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "SoldierSO", menuName = "ScriptableObjects/SoldierSO", order = 0)]
public class SoldierSO : ScriptableObject {
    public string soldierName;
    public float soldierMoveSpeed;
    public float soldierReloadingSpeed;
    public float soldierRecoilStability;
    public MoraleState soldierMorale;
}
public enum MoraleState {
    GOOD,
    BAD,
    INSANE,
    MOTIVATED
}
