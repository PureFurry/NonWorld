using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]private List<GameObject> enemyObjectPool;
    [SerializeField]float createRate,lastCreate;
    [SerializeField]bool canSpawnable;

    private void Awake() {
        
    }
    private void Start() {
        lastCreate = createRate;
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.P))
        {
            Debug.Log("Spawned");
            GameObject randomEnemy = enemyObjectPool[Random.Range(0, enemyObjectPool.Count)];
            EnemyCreate(randomEnemy);
        }
        if (canSpawnable)
        {
            TimeAfterCreate();
        }
        
    }
    public void TimeAfterCreate(){
        lastCreate -= Time.deltaTime;
        if (lastCreate <= 0)
        {
            GameObject randomEnemy = enemyObjectPool[Random.Range(0, enemyObjectPool.Count)];
            EnemyCreate(randomEnemy);
            lastCreate = createRate;
        }
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
}
