using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set;}
    [SerializeField]int corruptionCore;
    int corruptionLevelCounter;
    float curruptionLevel,currentCorruptionLevel;
    public int CurroptionCore { get => corruptionCore; set => corruptionCore = value; }

    private void Awake() {
        DontDestroyOnLoad(this);
        if (this.gameObject == null)
        {
            Instantiate(this.gameObject);
            Instance = this;
        }
        else{
            Instance = this;
        }
        currentCorruptionLevel = 0;
        corruptionLevelCounter = 1;
    }
    public void IncreaseLevelPoint(float _increaseAmount){
        currentCorruptionLevel += _increaseAmount;
        UIManager.Instance.UpdateCorruptionLevelBar(currentCorruptionLevel, curruptionLevel);
    }
    public void CorruptionLevelManager(){
        if (currentCorruptionLevel >= curruptionLevel)
        {
            currentCorruptionLevel = 0;
            float upgradeLevelPerc = curruptionLevel * (2/100);
            curruptionLevel += Mathf.RoundToInt(upgradeLevelPerc);
            corruptionLevelCounter++;
        }
        if (corruptionLevelCounter == 10)
        {
            Spawner.Instance.SpawnBoss();
        }
    }

    

    

}
