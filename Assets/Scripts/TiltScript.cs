using UnityEngine;

public class TiltScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject compass;

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

        if (compass != null)
        {
            compass.transform.position = lowPassValue;
            compass.transform.rotation = rotationValue;
        }

        rb.linearVelocity = new Vector3(rb.linearVelocityX, rb.linearVelocityY, 0);
        
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
