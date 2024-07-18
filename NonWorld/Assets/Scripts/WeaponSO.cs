using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



[CreateAssetMenu(fileName = "WeaponSO", menuName = "ScriptableObjects/WeaponSO", order = 1)]
public class WeaponSO : ScriptableObject
{
    public string weaponName;
    public Sprite weaponSprite;
    public GameObject weaponBullet;
    public float weaponRecoil;
    public float weaponStability;
    public float weaponTimeBetweenShot;
    public float weaponRange;
    public int weaponMagazineSize;
    public int weaponBulletLeft;
    public int weaponBulletShot;
    public int weaponBulletPerTaps;
    public WeaponShotType weaponShotType;
    public AudioClip fireSound;
    public AudioClip reloadSound;
}
public enum WeaponShotType{
    SINGLE,
    AUTOMATIC
}
