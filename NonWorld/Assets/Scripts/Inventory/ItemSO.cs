using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item", order = 3)]
public class ItemSO : ScriptableObject {
    public string itemName;
    public ItemType itemType;
    public bool isStackable;
    public Sprite itemSprite;
    public int dropAmount;



    public enum ItemType
    {
        CORUUPTIONCORE,
        AMMOMAGAZINE,
        WEAPON
    }
}

