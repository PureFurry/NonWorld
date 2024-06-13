using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Shooting : MonoBehaviour
{
	[SerializeField]WeaponSO weaponSO;
	public Transform firePoint;

	[SerializeField]public GameObject bulletPrefab;
	[SerializeField]int currentMagazineSize;
	[SerializeField]float currentTimeBetweenShot;
	[SerializeField]bool canFire = true;

	public float bulletForce = 20f;
	private void Start() {
		SetWeaponData(weaponSO);
	}
	void Update()
	{
		currentTimeBetweenShot -= Time.deltaTime;
		if (currentTimeBetweenShot <= 0)
		{
			canFire = true;
		}
		switch (weaponSO.weaponShotType)
		{
			case WeaponShotType.AUTOMATIC:
			if (Input.GetButton("Fire1") && currentMagazineSize > 0 && canFire)
			{
			Shoot();
			}
			break;
			case WeaponShotType.SINGLE:
			if (Input.GetButtonDown("Fire1") && currentMagazineSize > 0 && canFire)
			{
			Shoot();
			}
			break;
			default:
			break;
		}
		
		if (Input.GetKeyDown(KeyCode.R))
		{
			ReloadMagazine();
		}
		
	}
	//Shoot Function
	void Shoot()
	{
		CameraFollow.Instance.Shake();
		//shot bullet count for tap
		for (int i = 0; i < weaponSO.weaponBulletPerTaps; i++)
		{
			GameObject bullet = Instantiate(bulletPrefab,firePoint.position, firePoint.rotation);
			Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
			rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
			currentMagazineSize--;
			ResetShotTime();
		}
	}
	void ResetShotTime(){
		canFire = false;
		currentTimeBetweenShot = weaponSO.weaponTimeBetweenShot;
	}
	//Set SO Data
	void SetWeaponData(WeaponSO _weaponData){
		currentMagazineSize = _weaponData.weaponMagazineSize;
		bulletPrefab = _weaponData.weaponBullet;
		GetComponent<SpriteRenderer>().sprite = _weaponData.weaponSprite;
		currentTimeBetweenShot = _weaponData.weaponTimeBetweenShot;
	}
	//Loading SO Data
	public void LoadGunData(WeaponSO _weaponData){
		weaponSO = _weaponData;
	}
	void ReloadMagazine(){
		currentMagazineSize = weaponSO.weaponMagazineSize;
	}
}
