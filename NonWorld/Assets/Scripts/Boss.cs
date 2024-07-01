using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class Boss : Enemy
{
    [SerializeField]PolygonCollider2D attackDetectArea;
    [SerializeField]Transform attackArea;
    [SerializeField]Vector3 attackOffset;
    [SerializeField]private LayerMask attackMask;
    [SerializeField]private float attackRange;

    private void Awake() {
        base.Awake();
    }
    private void Start() {
        base.Start();
        attackDetectArea = GetComponentInChildren<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
        if (rb.velocity.x > 0 || rb.velocity.y > 0 || rb.velocity.x < 0 || rb.velocity.y < 0) 
        {
           GetComponent<Animator>().SetBool("Run",true);
        }
        else{
            GetComponent<Animator>().SetBool("Run",false);
        }
        if (attackDetectArea.isTrigger)
        {
            rb.velocity = new Vector3(0, 0);
            Vector3 dashDirection = GameObject.FindGameObjectWithTag("Player").transform.position;
            GetComponent<Animator>().SetTrigger("Dash");
            Dash(dashDirection);
        }
    }
    public override void Dash(Vector3 _dashDirection)
    {
        base.Dash(_dashDirection);
        if (GetComponent<PolygonCollider2D>().composite)
        {
            GetComponent<PolygonCollider2D>().composite.gameObject.TryGetComponent<PlayerStats>(out PlayerStats player);
            player.TakeDamage(damage);
        }
    }
    public void Attack(){
        Vector3 pos = attackArea.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up *attackOffset.y;

        Collider2D collision = Physics2D.OverlapCircle(pos, attackRange);
        if (collision != null)
        {
            collision.GetComponent<PlayerStats>().TakeDamage(damage);
        }
    }
}
