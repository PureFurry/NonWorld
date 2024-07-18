
using System.Collections;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class Shooting : MonoBehaviour
{
	#region Singleton
    public static Shooting Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType(typeof(Shooting)) as Shooting;

            return instance;
        }
        set
        {
            instance = value;
        }
    }
    private static Shooting instance;
    #endregion

	
	[SerializeField]WeaponSO weaponSO;
	public Transform firePoint;

	[SerializeField]public GameObject bulletPrefab;
	[SerializeField]int currentMagazineSize,currentMagazineAmount;
	[SerializeField]float currentTimeBetweenShot;
	[SerializeField]public bool canFire = true,canReload = true;
	public float bulletForce = 20f;

    public int CurrentMagazineAmount { get => currentMagazineAmount; set => currentMagazineAmount = value; }

    private void Awake() {
		SetWeaponData(weaponSO);
		if (instance == null)
		{
			instance = this;
		}
	}

	private void Start() {
		UIManager.Instance.UpdateAmmo(currentMagazineSize);
		UIManager.Instance.UpdateMagazine(CurrentMagazineAmount);
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
			if (Input.GetButton("Fire1") && currentMagazineSize > 0 && canFire && currentTimeBetweenShot <= 0)
			{
			Shoot();
			}
			break;
			case WeaponShotType.SINGLE:
			if (Input.GetButtonDown("Fire1") && currentMagazineSize > 0 && canFire && currentTimeBetweenShot <= 0)
			{
			Shoot();
			}
			break;
			default:
			break;
		}
		
		if (Input.GetKeyDown(KeyCode.R) && canFire && canReload && CurrentMagazineAmount > 0)
		{
			StartCoroutine(ReloadMagazine());			
			// GetComponentInParent<Animator>().ResetTrigger("Shoot");
		}		
	}
	//Shoot Function
	void Shoot()
	{
		GetComponentInParent<PlayerMovement>().CanMove = false;
		//ateş ettiğinde ekranın sallanması
		StartCoroutine(CameraFollow.Instance.Shake(0.1f,0.1f));
		//shot bullet count for tap
		for (int i = 0; i < weaponSO.weaponBulletPerTaps; i++)
		{
			StartCoroutine(Firesound());
			GameObject bullet = Instantiate(bulletPrefab,firePoint.position, firePoint.rotation);
			Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
			rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
			currentMagazineSize--;
			UIManager.Instance.UpdateAmmo(currentMagazineSize);
			ResetShotTime();
		}
		GetComponentInParent<PlayerMovement>().CanMove = true;
	}
	void ResetShotTime(){
		canFire = false;
		currentTimeBetweenShot = weaponSO.weaponTimeBetweenShot;
	}
	//Set SO Data
	public void SetWeaponData(WeaponSO _weaponData){
		currentMagazineSize = _weaponData.weaponMagazineSize;
		bulletPrefab = _weaponData.weaponBullet;
		GetComponent<SpriteRenderer>().sprite = _weaponData.weaponSprite;
		currentTimeBetweenShot = _weaponData.weaponTimeBetweenShot;
		GetComponent<AudioSource>().clip = _weaponData.fireSound;
	}
	//Loading SO Data
	public void LoadGunData(WeaponSO _weaponData){
		weaponSO = _weaponData;
		SetWeaponData(_weaponData);
	}
	IEnumerator ReloadMagazine(){
		canFire = false;
		canReload = false;
		GetComponentInParent<PlayerMovement>().CanMove=false;
		currentMagazineSize = weaponSO.weaponMagazineSize;
		CurrentMagazineAmount--;
		UIManager.Instance.UpdateAmmo(currentMagazineSize);
		UIManager.Instance.UpdateMagazine(CurrentMagazineAmount);
		GetComponentInParent<Animator>().SetTrigger("Reload");
		StartCoroutine(ReloadSound());	
		yield return new WaitForSeconds(GetComponentInParent<Animator>().GetCurrentAnimatorStateInfo(0).length + GetComponentInParent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime);
	}
	IEnumerator Firesound(){
		GetComponent<AudioSource>().Play();
			yield return new WaitForSeconds(GetComponent<AudioSource>().clip.length);
	}
	IEnumerator ReloadSound(){
		GetComponent<AudioSource>().clip = weaponSO.reloadSound;
		GetComponent<AudioSource>().Play();
		yield return new WaitForSeconds(GetComponent<AudioSource>().clip.length);
		GetComponent<AudioSource>().clip = weaponSO.fireSound;
	}
	void LoadMagazineAmount(int _increaseAmount){
		CurrentMagazineAmount += _increaseAmount;
	}

}
