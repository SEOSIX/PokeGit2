using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartScene()
    {
        SceneManager.LoadScene("Jeu");
    }

    public void OpenCredits()
    {
        Debug.Log("oui");
    }

    public void CloseCredits()
    {
        Debug.Log("non");
    }

}
