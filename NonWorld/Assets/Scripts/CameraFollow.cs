using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public static CameraFollow Instance;
    private void Awake() {
        Instance = this;
    }
    public Transform target; // Takip edilecek nesnenin Transform bile�eni

    public float smoothSpeed = 0.125f; // Kamera takibinin yumu�akl���n� belirleyen fakt�r

    public Vector3 offset; // Kamera ve hedef aras�ndaki ba�lang�� mesafesi


    // How long the object should shake for.
	public float shakeDuration = 0f;
	
	// Amplitude of the shake. A larger value shakes the camera harder.
	public float shakeAmount = 0.7f;
	public float decreaseFactor = 1.0f;

    private void Start()
    {
        offset.z = -5;
    }
    void FixedUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
        else
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }
    private void Update() {
        
    }
    public void Shake(){
        if (shakeDuration > 0)
		{
			transform.localPosition = offset + Random.insideUnitSphere * shakeAmount;
			
			shakeDuration -= Time.deltaTime * decreaseFactor;
		}
		else
		{
			shakeDuration = 0f;
			transform.localPosition = offset;
		}
    }
}