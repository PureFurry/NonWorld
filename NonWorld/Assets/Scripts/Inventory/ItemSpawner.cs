using System.Collections;
using System.Collections.Generic;
using CodeMonkey;
using UnityEditor;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public static ItemSpawner Instance { get; private set; }
    GameObject spawnPrefab;
    [SerializeField]ItemSO createdItem;
    [SerializeField]WeaponSO createdWeapon;
    [SerializeField]int dropAmount;
    [SerializeField]SpawnType spawnType;
    private void Awake() {
        switch (spawnType) {
            case SpawnType.WEAPON:
            spawnPrefab = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Weapon.prefab", typeof(GameObject)) as GameObject;
            WeaponSpawn();
            break;
            case SpawnType.ITEM:
            spawnPrefab = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Item.prefab", typeof(GameObject)) as GameObject;
            SpawnItem();
            break;
        }
        Destroy(this.gameObject);
        
        
    }
    public void SpawnItem(){
        switch (createdItem.itemType)
        {
            default:
            case ItemSO.ItemType.CORUUPTIONCORE:
            createdItem.dropAmount = this.dropAmount;
            spawnPrefab.GetComponent<Item>().ItemSO = createdItem;
            Instantiate(spawnPrefab, this.transform.position, Quaternion.identity);
            break;
            case ItemSO.ItemType.AMMOMAGAZINE:
            createdItem.dropAmount = this.dropAmount;
            spawnPrefab.GetComponent<Item>().ItemSO = createdItem;
            Instantiate(spawnPrefab, this.transform.position, Quaternion.identity);
            break;
        }
    }
    public void WeaponSpawn(){
        spawnPrefab.GetComponent<Weapon>().weaponSO = createdWeapon;
        Instantiate(spawnPrefab, this.transform.position, Quaternion.identity);
    }
    enum SpawnType
    {
        WEAPON,
        ITEM    
    }
    
    
}
