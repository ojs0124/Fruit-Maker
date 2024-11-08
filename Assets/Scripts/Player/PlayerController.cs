using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Vector2 moveInput = Vector2.zero;

    private void FixedUpdate()
    {
        ApplyMove();
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    public void OnDrop()
    {

    }

    private void ApplyMove()
    {
        transform.position += new Vector3(moveInput.x, 0, 0) * 0.1f;
        if(transform.position.x < -4)
        {
            transform.position = new Vector3(-4, transform.position.y, 0);
        }
        else if(transform.position.x > 4)
        {
            transform.position = new Vector3(4, transform.position.y, 0);
        }
    }
}
