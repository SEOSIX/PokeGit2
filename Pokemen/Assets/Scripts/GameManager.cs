using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public int playerLevel = 1;
    public float gameTime = 0f;
    public Slider xpbarr;
    public GameObject ws;
    public Sprite newSprite1;
    public Sprite newSprite;
    public Sprite newSprite2;
    public SpriteRenderer sr;
    void start()
    {
        xpbarr.value = 0;
        sr = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        gameTime += Time.deltaTime;
        CheckEnemyEvolution();
        if (Input.GetKeyDown(KeyCode.Space))
        {
			xpbarr.value = xpbarr.maxValue;
        }

        if (xpbarr.value == xpbarr.maxValue)
        {
            playerLevel++;
            RewardPlayer();
        }
    }

    void RewardPlayer()
    {
        xpbarr.value = 0;
        StartCoroutine("anim1");
    }

    IEnumerator anim1()
    {
        ws.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        if (sr.sprite == newSprite)
        {
            xpbarr.maxValue = 300;
            sr.sprite = newSprite2;
        }
        if (sr.sprite == newSprite1)
        {
            xpbarr.maxValue = 200;
            sr.sprite = newSprite;
        }
        yield return new WaitForSeconds(1.5f);
        ws.SetActive(false);
    }
    
    void CheckEnemyEvolution()
    {
        if (gameTime > 120f) // Après 2 minutes, les ennemis évoluent
        {
            // Logique pour faire évoluer les ennemis
        }
    }
}