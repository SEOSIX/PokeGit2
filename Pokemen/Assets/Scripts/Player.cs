using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;
public class Player : MonoBehaviour
{
    private SpriteRenderer sr;
        
    public float moveSpeed = 5f; // Vitesse de d�placement du personnage

    private Rigidbody rb;

    public Sprite dammageSprite;

    public Animator animatorComponent;
    public GameObject slider;
    public GameManager gm;
    public EnemyManager em;
    void Start()
    {
        // R�cup�re le composant Rigidbody attach� au GameObject
        rb = GetComponent<Rigidbody>();
        sr = GetComponent<SpriteRenderer>();
        animatorComponent = GetComponent<Animator>();
    }

    void Update()
    {
        // R�cup�re les entr�es du joueur (fl�ches directionnelles ou touches ZQSD/AWSD)
        float moveX = Input.GetAxisRaw("Horizontal"); // -1 pour gauche, 1 pour droite
        float moveZ = Input.GetAxisRaw("Vertical");   // -1 pour bas, 1 pour haut

        // Normalise le vecteur de d�placement pour �viter les d�placements plus rapides en diagonale
        Vector3 movement = new Vector3(moveX, 0, moveZ).normalized;

        // Applique le mouvement au Rigidbody
        rb.linearVelocity = movement * moveSpeed;
        
        if (Input.GetKey(KeyCode.A))
        {
            sr.flipX = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            sr.flipX = false;
        }

        checkForVelocity();
        attack1();
    }

    public void checkForVelocity()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");
        if(moveX != 0 || moveZ != 0)
        {
            animatorComponent.SetBool("IsWalking?", true);
        }
        else
        { 
            animatorComponent.SetBool("IsWalking?", false);
        }
    }

    public void attack1()
    {
        if (Input.GetMouseButton(0))
        {
            StartCoroutine("attack");
        }
    }

    IEnumerator attack()
    {
        animatorComponent.SetBool("seb1a", true);
        yield return new WaitForSeconds(0.5f);
        animatorComponent.SetBool("seb1a", false);
    } 
}