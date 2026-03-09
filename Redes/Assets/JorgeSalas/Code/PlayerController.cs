using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    [SerializeField] private Vector2 moveInput;
    private Rigidbody rb;
    private bool isGrounded;
    
    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null) rb = gameObject.AddComponent<Rigidbody>();
        
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }
    
    public void Update()
    {
        Vector3 movement = new Vector3(moveInput.x, 0f, moveInput.y);
        transform.Translate(movement * (moveSpeed * Time.deltaTime), Space.World);
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }
    
    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
    
    public void OnJump(InputValue value)
    {
        if (isGrounded && value.isPressed) rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
