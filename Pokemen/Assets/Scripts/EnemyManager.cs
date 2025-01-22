using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject spritePrefab;
    public GameObject target; 
    public float spawnInterval = 2f;
    public float moveSpeed = 6f;
    public float spawnDistance = 2f;
    public int numberOfSpritesToSpawn = 5;
    public Camera mainCamera;
    public Player player;

    void Start()
    {
        StartCoroutine(SpawnSprites()); // Démarre la coroutine de spawn
    }

    // ReSharper disable Unity.PerformanceAnalysis
    // ReSharper disable Unity.PerformanceAnalysis
    IEnumerator SpawnSprites()
    {
        while (true)
        {
            // Attendre l'intervalle de spawn
            yield return new WaitForSeconds(spawnInterval);
            for (int i = 0; i < numberOfSpritesToSpawn; i++)
            {
                // Calculer une position de spawn en dehors du champ de vision de la caméra
                Vector3 spawnPosition = GetRandomSpawnPosition();
                GameObject newSprite = Instantiate(spritePrefab, spawnPosition, Quaternion.identity);

                // Déplacer le sprite vers la cible
                StartCoroutine(MoveTowardsTarget(newSprite));
            }
        }

        Vector3 GetRandomSpawnPosition()
        {
            float cameraHeight = 1f * mainCamera.orthographicSize;
            float cameraWidth = cameraHeight * mainCamera.aspect;
            
            float x, y;
            
            if (Random.value > 0.5f)
            {
                x = (Random.value > 0.5f) ? -cameraWidth / 2 - spawnDistance : cameraWidth / 2 + spawnDistance;
                y = Random.Range(-cameraHeight / 2, cameraHeight / 2); // Position Y aléatoire dans la vue de la caméra
            }
            else // 50% de chance de spawn en haut ou en bas
            {
                x = Random.Range(-cameraWidth / 2, cameraWidth / 2); // Position X aléatoire dans la vue de la caméra
                // Hors de la vue en haut ou en bas, en ajoutant la distance de spawn
                y = (Random.value > 0.5f) ? -cameraHeight / 2 - spawnDistance : cameraHeight / 2 + spawnDistance;
            }

            return new Vector3(x, y, 0f);
        }

        IEnumerator MoveTowardsTarget(GameObject sprite)
        {
            while (sprite != null)
            {
                // Déplacer le sprite vers la cible
                sprite.transform.position = Vector3.MoveTowards(sprite.transform.position, target.transform.position,
                    moveSpeed * Time.deltaTime);

                yield return null; // Attendre la prochaine frame
            }
        }
    }

}