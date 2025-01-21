using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;
public class Player : MonoBehaviour
{
    public float moveSpeed = 5f; 
    private Rigidbody rb;
    
    private SpriteRenderer sr;
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");   

        Vector3 movement = new Vector3(moveX, 0, moveZ).normalized;
        rb.MovePosition(transform.position + movement * moveSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("FlipTrue");
            sr.flipX = true;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("FlipFalse");
            sr.flipX = false;
        }
    }
}
