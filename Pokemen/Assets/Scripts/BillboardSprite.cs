using UnityEngine;

public class BillboardSprite : MonoBehaviour
{
    private Camera mainCamera;

    void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }

    void Update()
    {
        if (mainCamera != null)
        {

            Vector3 lookAtDirection = mainCamera.transform.position - transform.position;

            if (lookAtDirection != Vector3.zero)
            {
                lookAtDirection.x = 0;
                transform.rotation = Quaternion.LookRotation(lookAtDirection);
            }
        }
    }
}