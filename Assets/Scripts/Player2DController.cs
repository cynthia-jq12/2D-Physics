using UnityEngine;
using UnityEngine.InputSystem;

public class Player2DController : MonoBehaviour
{
    public float speed = 1.0f;
    
    private Rigidbody2D _rb;
    private float moveInputValue;

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
            moveInputValue = (Keyboard.current.dKey.isPressed ? 1 : 0) - (Keyboard.current.aKey.isPressed ? 1 : 0);
        }
        _rb.linearVelocity = new Vector2(moveInputValue * speed, _rb.linearVelocity.y);
    }
}
