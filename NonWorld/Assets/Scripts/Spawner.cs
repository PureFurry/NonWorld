using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner Instance { get; private set;}

    [SerializeField]private List<GameObject> enemyObjectPool;
    [SerializeField]GameObject bossObject;
    [SerializeField]float createRate,lastCreate;
    public int spawnAmount;
    [SerializeField]public bool canSpawnable;
    int counter;

    private void Awake() {
        Instance = this;
    }
    private void Start() {
        lastCreate = createRate;
    }
    void Update()
    {
        // if (Input.GetKeyUp(KeyCode.P))
        // {
        //     Debug.Log("Spawned");
        //     GameObject randomEnemy = enemyObjectPool[Random.Range(0, enemyObjectPool.Count)];
        //     EnemyCreate(randomEnemy);
        // }

        if (canSpawnable)
        {
            TimeAfterCreate();
        }
        
    }
    
    public void TimeAfterCreate(){
        
        while(counter < spawnAmount){
            lastCreate -= Time.deltaTime;
            if (lastCreate <= 0)
            {
                GameObject randomEnemy = enemyObjectPool[Random.Range(0, enemyObjectPool.Count)];
                EnemyCreate(randomEnemy);
                lastCreate = createRate;
                counter++;
            }
        }
    }
    void ResetCounter(){
        counter = 0;
    }
    public void EnemyCreate(GameObject _enemy){
            Instantiate(_enemy, RandomLocation(), Quaternion.identity);
    }
    public Vector3 RandomLocation(){
        Transform cameraPosition = GameObject.FindGameObjectWithTag("MainCamera").transform;
        float minDistance = 2;
        float distance;
        Vector2 randomArea = new Vector2(30,20);
        Vector3 randomPosition;
        do
        {
            randomPosition = new Vector3(Random.Range(-randomArea.x, randomArea.x), Random.Range(-randomArea.y, randomArea.y));
            distance = Vector2.Distance(randomPosition, cameraPosition.position);
        } while (distance < minDistance);
        return randomPosition;
    }
    public void AddEnemyToList(GameObject _addEnemy)
    {
        enemyObjectPool.Add(_addEnemy);
    }
    public void SpawnBoss(){
        Instantiate(bossObject, RandomLocation(), Quaternion.identity);
    }
}
