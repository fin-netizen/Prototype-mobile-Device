using UnityEngine;

public class TiltScript : MonoBehaviour
{
    public Rigidbody2D rb;

    public float speed = 5;

    public float AccelerometerUpdateInterval = 1.0f / 100.0f;
    public float LowPassKernelWidthInSeconds = 0.001f;
    public Vector3 lowPassValue = Vector3.zero;
    public Quaternion rotationValue = Quaternion.identity;

    private void Start()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }
    }

    private void Update()
    {

        CalculateLowPass();
        CalculateRotation();

        transform.rotation = rotationValue;

        //rb.linearVelocity = new Vector3(rb.linearVelocityX, rb.linearVelocityY, 0);

        print("xyv=" + Input.acceleration.x + "  " +  Input.acceleration.y);


        rb.linearVelocityX = Input.acceleration.x * speed;
        rb.linearVelocityY = Input.acceleration.y * speed;


    }

    void CalculateLowPass()
    {
        float LowPassFilterFactor = AccelerometerUpdateInterval / LowPassKernelWidthInSeconds;
        lowPassValue = Vector3.Lerp(lowPassValue, Input.acceleration, LowPassFilterFactor);
    }

    void CalculateRotation()
    {
        float tiltAngle = Mathf.Atan2(Input.acceleration.x, Input.acceleration.y) * Mathf.Rad2Deg;

        Quaternion targetRotation = Quaternion.Euler(0, 0, -tiltAngle);
        float RotateFactor = AccelerometerUpdateInterval / LowPassKernelWidthInSeconds;

        rotationValue = Quaternion.Slerp(rotationValue, targetRotation, RotateFactor);
    }
}
