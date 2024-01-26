using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed;
    public Vector3 offset;

    private void Start()
    {
        smoothSpeed = 0.95f;
        offset = new Vector3(0f, 18f, -18f);
    }


    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed*Time.deltaTime);
        transform.position = smoothedPosition;

        //transform.LookAt(target);
    }
}
