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
        if (gameTime > 120f) // Après 2 minutes, les ennemis évoluent
        {
            // Logique pour faire évoluer les ennemis
        }
    }

    public void LevelUpPlayer()
    {
        playerLevel++;
        RewardPlayer();
    }

    void RewardPlayer()
    {
        // Logique pour donner un Pokéhumain ou améliorer un existant
    }
}