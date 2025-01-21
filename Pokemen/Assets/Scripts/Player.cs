using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;
public class Player : MonoBehaviour
{
    private SpriteRenderer sr;
        
    public float moveSpeed = 5f; // Vitesse de d�placement du personnage

    private Rigidbody rb;

    void Start()
    {
        // R�cup�re le composant Rigidbody attach� au GameObject
        rb = GetComponent<Rigidbody>();
        sr = GetComponent<SpriteRenderer>();
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
            Debug.Log("FlipTrue");
            sr.flipX = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("FlipFalse");
            sr.flipX = false;
        }
    }
    
}
