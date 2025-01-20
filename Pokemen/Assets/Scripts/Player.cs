using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f; 
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");   

        Vector3 movement = new Vector3(moveX, 0, moveZ).normalized;
        rb.MovePosition(transform.position + movement * moveSpeed * Time.deltaTime);
    }
}
