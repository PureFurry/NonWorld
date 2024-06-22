using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public GameObject hitEffect;
	[SerializeField]float bulletDamage;
	float modifyBulletDamage;

    public float ModifyBulletDamage { get => modifyBulletDamage; set => modifyBulletDamage = value; }

    private void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag("Enemy"))
		{
			GameObject effect = Instantiate(hitEffect,transform.position, Quaternion.identity);
			other.gameObject.GetComponent<Enemy>().TakeDamage(bulletDamage + ModifyBulletDamage);
			Destroy(effect,.5f);
			Destroy(this.gameObject);
		}
		if (other.gameObject.CompareTag("Walls"))
		{
			Destroy(this.gameObject);
		}
		
	}
	private void Start() {
		StartCoroutine(DestroyAfterFire());
	}
	IEnumerator DestroyAfterFire(){
		yield return new WaitForSeconds(2.5f);
		Destroy(this.gameObject);
	}
}
