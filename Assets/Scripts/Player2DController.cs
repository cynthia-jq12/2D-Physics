using UnityEngine;
using UnityEngine.InputSystem;

public class Player2DController : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpForce = 450;
    
    private Rigidbody2D _rb;
    private float moveInputValue;
    private bool _isGrounded;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     _rb = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current != null)
        {
            moveInputValue = (Keyboard.current.dKey.isPressed ? 1 : 0) - (Keyboard.current.aKey.isPressed ? 1 : 0); // กด A or D เพื่อเดิน
        }
        _rb.linearVelocity = new Vector2(moveInputValue * speed, _rb.linearVelocity.y);// ใส่เเรงแกน Y คงแรงแกน X

        if (Keyboard.current.spaceKey.wasPressedThisFrame && _isGrounded) // กด space bar พร้อมติดพื้น
        {
            _rb.AddForce(new Vector2(_rb.linearVelocity.x, jumpForce)); // ใส่เเรงแกน Y คงแรงแกน X
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Groud"))
        {
            _isGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        _isGrounded = false;
    }
}
