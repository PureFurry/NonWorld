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


    Vector3 desiredPosition;
    Vector3 smoothedPosition;

    private void Start()
    {
        offset.z = -5;
    }
    void FixedUpdate()
    {
        if (target != null)
        {
            
            transform.position = SetCamPosition();
        }
        else
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }
    private void Update() {
        
    }
    public IEnumerator Shake(float duration, float magnitude)
    {
        /* you can set the originalPos to transform.localPosition of the camera in that instance. */
        Vector3 originalPos = smoothedPosition;

        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            float xOffset = Random.Range(-0.5f,0.5f) * magnitude;
            float yOffset = Random.Range(-0.5f,0.5f) * magnitude;

            transform.localPosition = new Vector3(target.position.x + xOffset,target.position.y + yOffset, SetCamPosition().z);

            elapsedTime += Time.deltaTime;

            // wait one frame
            yield return null;
        }

        transform.localPosition = smoothedPosition;
    }
    Vector3 SetCamPosition(){
            desiredPosition = target.position + offset;
            smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            return smoothedPosition;
    }
}