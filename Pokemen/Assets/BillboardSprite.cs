using UnityEngine;

public class BillboardSprite : MonoBehaviour
{
    private Camera mainCamera;

    void Start()
    {
        // Trouve la cam�ra principale si elle n'est pas assign�e
        if (mainCamera == null)
            mainCamera = Camera.main;
    }

    void Update()
    {
        // Fait en sorte que le sprite regarde toujours la cam�ra
        if (mainCamera != null)
        {
            // Calcule la direction entre le sprite et la cam�ra en utilisant les positions globales
            Vector3 lookAtDirection = mainCamera.transform.position - transform.position;

            // V�rifie si la direction n'est pas nulle
            if (lookAtDirection != Vector3.zero)
            {
                // Optionnel : pour garder le sprite droit sur l'axe Y
                lookAtDirection.y = 0;

                // Applique la rotation au sprite
                transform.rotation = Quaternion.LookRotation(lookAtDirection);
            }
        }
    }
}