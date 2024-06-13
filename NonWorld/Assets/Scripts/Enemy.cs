using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour,IMove,ITakeDamage
{
    [SerializeField]public GameObject[] enemyPool;
    [SerializeField] float health, currentHealth;
    // [SerializeField] LayerMask targetLayerMask;
    [SerializeField]private float enemyMoveSpeed;
    GameObject targetPosition;
    [SerializeField]private float damage;
    [SerializeField]private int droppedLevelPoint;
    bool lookingLeft = true;


    //Enemy Follow Function
    public void Move(Vector3 inputVector)
    {
        Vector3 displacement = inputVector -transform.position;
	    displacement = displacement.normalized;

	    if (Vector2.Distance (inputVector, transform.position) > 1.0f) {
		    transform.position += (displacement * enemyMoveSpeed * Time.deltaTime);
                 
	    }else{
               //do whatever the enemy has to do with the player
        }
    }


    private void Awake() {
        currentHealth = health;
    }


    // Update is called once per frame
    void Update()
    {
        SearchTarget();

        if (targetPosition.transform.position.x < this.transform.position.x && !lookingLeft)
        {
            Quaternion tempRotation = this.transform.localRotation;
            tempRotation.y = 0;
            this.transform.localRotation = tempRotation;
            lookingLeft = true;
        }
        if (targetPosition.transform.position.x > this.transform.position.x && lookingLeft)
        {
            Quaternion tempRotation = this.transform.localRotation;
            tempRotation.y = -180;
            this.transform.localRotation = tempRotation;
            lookingLeft = false;
        }
    }
    void SearchTarget(){
        targetPosition = GameObject.FindGameObjectWithTag("Player");
        
        if (targetPosition != null)
        {
            Move(targetPosition.transform.position);
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<ITakeDamage>().TakeDamage(damage);
        }
    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    


}
