using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Item {

    public enum ItemType {
        Weapon,
        Medkit,
        Ammo,
        CorruptionCore,
        Armor,
    }

    public ItemType itemType;
    public int amount;


    public Sprite GetSprite() {
        switch (itemType) {
        default:
        case ItemType.Weapon:        return ItemAssets.Instance.weaponSprite;
        case ItemType.Medkit: return ItemAssets.Instance.medkitSprite;
        case ItemType.Ammo:   return ItemAssets.Instance.ammoSprite;
        case ItemType.CorruptionCore:         return ItemAssets.Instance.corruptionCoreSprite;
        case ItemType.Armor:       return ItemAssets.Instance.armorSprite;
        }
    }

    public Color GetColor() {
        switch (itemType) {
        default:
        case ItemType.Weapon:        return new Color(1, 1, 1);
        case ItemType.Medkit: return new Color(1, 0, 0);
        case ItemType.Ammo:   return new Color(0, 0, 1);
        case ItemType.CorruptionCore:         return new Color(1, 1, 0);
        case ItemType.Armor:       return new Color(1, 0, 1);
        }
    }

    public bool IsStackable() {
        switch (itemType) {
        default:
        case ItemType.CorruptionCore:
        case ItemType.Medkit:
        case ItemType.Ammo:
            return true;
        case ItemType.Weapon:
        case ItemType.Armor:
            return false;
        }
    }

}
