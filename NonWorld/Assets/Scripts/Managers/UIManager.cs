using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text corruptionPointText;
    [SerializeField] private TMP_Text ammoText;
    [SerializeField] private TMP_Text magazineText;
    [SerializeField] private Scrollbar healthBar;
    [SerializeField] private Scrollbar staminaBar;
    [SerializeField] private Scrollbar corruptionLevelBar;

    public static UIManager Instance { get; private set;}
    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);    
        }
    }
    public void UpdateCorruption(int _corruptionAmount){
        corruptionPointText.text = _corruptionAmount.ToString();
    }
    public void UpdateHealtBar(float _currentHealth,float _health){
        //InverseLerp ile min ve maks değerlerin 0 ila 1 arasına döndürüyor. Slider veya scrollbar için ideal
        healthBar.size = Mathf.InverseLerp(0,_health,_currentHealth);
    }
    public void UpdateStaminaBar(float _currentStamina,float _stamina){
        staminaBar.size = Mathf.InverseLerp(0,_stamina,_currentStamina);
    }
    public void UpdateCorruptionLevelBar(float _currentCorrutionLevel,float _corruptionLevel){
        corruptionLevelBar.size = Mathf.InverseLerp(0,_corruptionLevel,_currentCorrutionLevel);
    }
    public void UpdateAmmo(int _ammo){
        ammoText.text = _ammo.ToString();
    }
    public void UpdateMagazine(int _magazine){
        magazineText.text = _magazine.ToString();
    }
}
