using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int playerLevel = 1;
    public float gameTime = 0f;

    void Update()
    {
        gameTime += Time.deltaTime;
        CheckEnemyEvolution();
    }

    void CheckEnemyEvolution()
    {
        if (gameTime > 120f) // Apr�s 2 minutes, les ennemis �voluent
        {
            // Logique pour faire �voluer les ennemis
        }
    }

    public void LevelUpPlayer()
    {
        playerLevel++;
        RewardPlayer();
    }

    void RewardPlayer()
    {
        // Logique pour donner un Pok�humain ou am�liorer un existant
    }
}