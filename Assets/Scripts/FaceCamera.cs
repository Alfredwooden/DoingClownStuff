using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float maxXRotation = 10f;

    void Start()
    {
        if (!mainCamera)
        {
            mainCamera = Camera.main;
        }
    }

    void Update()
    {
        if (mainCamera)
        {
            Vector3 direction = mainCamera.transform.position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);

            Vector3 targetEulerAngles = targetRotation.eulerAngles;
            targetEulerAngles.x = Mathf.Clamp(targetEulerAngles.x, -maxXRotation, maxXRotation);

            transform.rotation = Quaternion.Euler(targetEulerAngles);
        }
    }
}