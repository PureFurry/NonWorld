using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerStats : MonoBehaviour, ITakeDamage
{
    [SerializeField]float health,currentHealth, stamina, currentStamina,playerSpeed;

    bool firstDeathCheck;
    public float CurrentStamina { get => currentStamina; set => currentStamina = value; }
    public float Stamina { get => stamina; set => stamina = value; }
    public bool FirstDeathCheck { get => firstDeathCheck; set => firstDeathCheck = value; }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        UIManager.Instance.UpdateHealtBar(currentHealth,health);
        if (currentHealth <= 0)
        {
            // if (!firstDeathCheck)
            // {
            //     GameObject droppedCore = Instantiate(AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/CorruptedCore.prefab"),this.transform.position,Quaternion.identity);
            //     droppedCore.GetComponent<DroppedCorruptedCore>().storedCorruptepCore = GameManager.Instance.CurroptionCore;
            //     GameManager.Instance.CurroptionCore = 0;
            //     FirstDeathCheck = true;
            //     Destroy(this);   
            // }
            // if (firstDeathCheck)
            // {
            //     //Burası doldurulacakkk
            // }
            Time.timeScale = 0;
        }
    }

    private void Awake() {
        
        
    }
    void Start()
    {
        currentHealth = health;
        CurrentStamina = Stamina;
        UIManager.Instance.UpdateHealtBar(currentHealth,health);
        UIManager.Instance.UpdateStaminaBar(CurrentStamina,Stamina);
        GetComponent<PlayerMovement>().MoveSpeed = playerSpeed;
    }
    // Update is called once per frame
    public Vector3 GetPosition(){
        return this.transform.position;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        Item itemWorld = other.GetComponent<Item>();
        if (itemWorld != null){
            switch (itemWorld.ItemSO.itemType)
            {
                default:
                InventoryManager.Instance.inventory.AddItemToList(itemWorld.GetItem());
                itemWorld.DestroySelf();
                break;
                case ItemSO.ItemType.AMMOMAGAZINE:
                GetComponent<PlayerMovement>().weapon.GetComponent<Shooting>().CurrentMagazineAmount++;
                UIManager.Instance.UpdateMagazine(GetComponent<PlayerMovement>().weapon.GetComponent<Shooting>().CurrentMagazineAmount);
                itemWorld.DestroySelf();
                break;
            }
            
        }
        Weapon weapon = other.GetComponent<Weapon>();
        if (weapon != null)
        {
            if (Shooting.Instance != null)
            {
                Shooting.Instance.LoadGunData(weapon.weaponSO);
                weapon.DestroySelf();   
            }
        }
    }
}
