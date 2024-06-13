using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public GameObject hitEffect;
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Enemy"))
		{
			GameObject effect = Instantiate(hitEffect,transform.position, Quaternion.identity);
			Destroy(effect,.5f);
			Destroy(this.gameObject);
		}
		if (collision.gameObject.CompareTag("Walls"))
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
