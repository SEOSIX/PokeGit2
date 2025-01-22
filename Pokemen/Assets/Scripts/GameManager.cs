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

    public Player player;
    
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
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");
        ws.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        
        player.animatorComponent.enabled = false;
        if (sr.sprite == newSprite)
        {
            xpbarr.maxValue = 300;
            sr.sprite = newSprite2;
        }
        if (sr.sprite == newSprite1)
        {
            if(moveX != 0 || moveZ != 0)
            {
                player.animatorComponent.SetBool("seb2walk", true);
            }
            else
            {
                player.animatorComponent.SetBool("seb2walk", false);
            }
            xpbarr.maxValue = 200;
            sr.sprite = newSprite;
        }
        
        player.animatorComponent.enabled = true;
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