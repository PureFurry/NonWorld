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
        Debug.Log(Mathf.InverseLerp(0f,health,currentHealth));
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
    void Update()
    {
        
    }
    public Vector3 GetPosition(){
        return this.transform.position;
    }
}
