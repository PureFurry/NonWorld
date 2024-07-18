using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public WeaponSO weaponSO;
    private void Start() {
        GetComponent<SpriteRenderer>().sprite = weaponSO.weaponSprite;
    }

    public Weapon GetItem(){
        return this;
    }
    public void DestroySelf(){
        Destroy(this.gameObject);
    }
}
