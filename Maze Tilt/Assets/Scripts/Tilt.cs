using UnityEngine;

public class Tilt : MonoBehaviour
{
    private float rotationAngle = 0.0f;
    public float rotationSpeed = 55.0f;
    public float maxRotationAngle = 10.0f;
    private Vector3 mazeCenter = new Vector3(0, 0, 0);
    private bool isRotating = false;
    private float targetRotationAngle = 0.0f;

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && !isRotating)
        {
            RotateMaze(-maxRotationAngle);
        }
        else if (Input.GetKey(KeyCode.RightArrow) && !isRotating)
        {
            RotateMaze(maxRotationAngle);
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            isRotating = false;
        }
    }

    private void RotateMaze(float angle)
    {
        targetRotationAngle += angle;
        isRotating = true;
    }

    private void FixedUpdate()
    {
        if (isRotating)
        {
            float step = rotationSpeed * Time.fixedDeltaTime;
            rotationAngle = Mathf.MoveTowardsAngle(rotationAngle, targetRotationAngle, step);

            Vector3 rotationAxis = rotationAngle < targetRotationAngle ? Vector3.forward : Vector3.back;

            transform.RotateAround(mazeCenter, rotationAxis, step);

            if (Mathf.Approximately(rotationAngle, targetRotationAngle))
            {
                isRotating = false;
            }
        }
    }
}
