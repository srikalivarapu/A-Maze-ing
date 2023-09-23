using UnityEngine;

public class BallController : MonoBehaviour
{
    public float moveForce = 10.0f;

    private Rigidbody mRigidBody;

    void Start()
    {
        mRigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (mRigidBody != null)
        {
            float horizontalInput = Input.GetAxis("Horizontal");

            Vector3 moveDirection = new Vector3(horizontalInput, 0, 0);

            mRigidBody.AddForce(moveDirection * moveForce);
        }
    }
}
