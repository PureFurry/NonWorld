using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour,IMove,ITakeDamage
{
    [SerializeField] Entity entityData;
    [SerializeField]protected float health, currentHealth;
    // [SerializeField] LayerMask targetLayerMask;
    [SerializeField]protected float enemyMoveSpeed;
    GameObject targetPosition;
    [SerializeField]protected float damage;
    [SerializeField]protected int droppedLevelPoint;
    protected Rigidbody2D rb;


    //Enemy Follow Function
    public void Move(Vector3 inputVector)
    {
        Vector3 displacement = inputVector -transform.position;
	    displacement = displacement.normalized;

        rb.velocity = displacement * enemyMoveSpeed;
        

	    // if (Vector2.Distance (inputVector, transform.position) > 1.0f) {
		//     transform.position += (displacement * enemyMoveSpeed * Time.deltaTime);
                 
	    // }else{
        //        //do whatever the enemy has to do with the player
        // }
    }
    void RotatingToPlayer(){
        Vector2 lookDir = new Vector2(targetPosition.transform.position.x, targetPosition.transform.position.y) - rb.position;
		float angle = Mathf.Atan2(lookDir.y,lookDir.x) * Mathf.Rad2Deg - 90f;
		rb.rotation = angle;
    }


    protected void Awake() {
        currentHealth = entityData.entityHealth;
        enemyMoveSpeed = entityData.entitySpeed;
    }
    protected void Start() {
        rb = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    protected void Update()
    {
        SearchTarget();
    }
    void SearchTarget(){
        targetPosition = GameObject.FindGameObjectWithTag("Player");
        
        if (targetPosition != null)
        {
            Move(targetPosition.transform.position);
            RotatingToPlayer();
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
            GameManager.Instance.CurroptionCore += entityData.droppedCorrption;
            UIManager.Instance.UpdateCorruption(GameManager.Instance.CurroptionCore);
            CorruptionDrop(entityData.droppedCorrption,entityData.droppedCorruptionLevel);
            Destroy(this.gameObject);
        }
    }

    public void Move(Vector2 inputVector)
    {
        throw new System.NotImplementedException();
    }
    public virtual void FireProjectile(GameObject _fireobject,float _fireSpeed){

    }
    public virtual void Dash(Vector3 _dashDirection){
        rb.AddForce(_dashDirection,ForceMode2D.Force);

    }
    void CorruptionDrop(int _dropAmount,float _levelDropAmount){
        GameManager.Instance.CurroptionCore += _dropAmount;
        GameManager.Instance.IncreaseLevelPoint(_levelDropAmount);
    }
}
