using System;
using UnityEngine;
using UnityEngine.UIElements;

public class Collision : MonoBehaviour
{
    public Sprite damageSprite;
    public Player player;
    public GameManager gm;

    public AudioSource BOY;
    public Sprite atckSprite2;
    
    public Animator animatorComponent;
    private void OnCollisionEnter(UnityEngine.Collision other)
    {
        if (other.gameObject.CompareTag("Joueur"))
        {
            BOY.Play();
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Joueur") &&  other.gameObject.GetComponent<GameManager>().sr.sprite !=  atckSprite2 )
        {
            other.gameObject.GetComponent<Player>().slider.GetComponent<Slider>().value -= 0.10f;
            other.gameObject.GetComponent<GameManager>().sr.sprite = damageSprite;
        }
    }
}
