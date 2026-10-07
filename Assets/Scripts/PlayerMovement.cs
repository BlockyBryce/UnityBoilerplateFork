using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed=10;
    // Update is called once per frame
    public void Update()
    {
        var rb = FindAnyObjectByType<Rigidbody>();

        if (Input.GetKey(KeyCode.D))
        {
           rb.linearVelocity = (Vector3.right *  speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.linearVelocity = (Vector3.left * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.linearVelocity = (Vector3.down * speed);
        }
        if (Input.GetKey(KeyCode.W ) || Input.GetKey(KeyCode.Space))
        {
            rb.linearVelocity = (Vector3.up * speed);
        }

    }
}
