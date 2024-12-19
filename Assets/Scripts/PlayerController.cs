using UnityEngine;
using TMPro;
public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // Adjust the movement speed
    public float boundary = 5f; // Boundary for horizontal movement
    private bool gyroEnabled;
    private Gyroscope gyro;

    public TMP_Text rotationRateTMP; // Assign in the Inspector
    public TMP_Text attitudeTMP;     // Assign in the Inspector
    public TMP_Text gravityTMP;      // Assign in the Inspector

    void Start()
    {
        // Enable the gyroscope if supported
        gyroEnabled = SystemInfo.supportsGyroscope;
        if (gyroEnabled)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
        }
        else
        {
            Debug.LogError("Gyroscope not supported on this device.");
        }
    }

    void Update()
    {
        // Display gyroscope data
        if (gyroEnabled)
        {
            rotationRateTMP.text = $"Rotation Rate: {gyro.rotationRateUnbiased:F2}";
            attitudeTMP.text = $"Attitude: {gyro.attitude.eulerAngles:F2}";
            gravityTMP.text = $"Gravity: {gyro.gravity:F2}";

            // Use the gravity.x to interpolate position between boundaries
            float normalizedGravityX = Mathf.InverseLerp(-1f, 1f, gyro.gravity.x); // Normalize gravity.x to range 0-1
            float targetX = Mathf.Lerp(-boundary, boundary, normalizedGravityX);  // Map normalized value to boundaries
            Vector3 targetPosition = new Vector3(targetX, transform.position.y, transform.position.z);

            // Smoothly move the cube to the target position
            transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
        }
        else
        {
            rotationRateTMP.text = "Gyroscope not supported.";
            attitudeTMP.text = "";
            gravityTMP.text = "";
        }
    }
}
