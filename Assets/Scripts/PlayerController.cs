using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float tilt;
    public Boundary boundary;

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); //Get the horizontal axis of the player
        float moveVertical = Input.GetAxis("Vertical"); //Get the vertical axis of the player

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        Rigidbody rigidbody = GetComponent<Rigidbody>(); //Get the rigidbody

        rigidbody.velocity = movement * speed;
        rigidbody.position = new Vector3(Mathf.Clamp(rigidbody.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rigidbody.position.z, boundary.zMin, boundary.zMax));
        rigidbody.rotation = Quaternion.Euler(0.0f, 0.0f, rigidbody.velocity.x * -tilt);
    }
}
