using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // Adjust the speed of the cube
    private bool gyroEnabled;
    private Gyroscope gyro;
    public float boundary;
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
        if (gyroEnabled)
        {
            // Use the gyroscope's rotation rate to calculate horizontal movement
            float horizontalInput = gyro.rotationRateUnbiased.y; // Gyroscope rotation rate
            Vector3 movement = new Vector3(horizontalInput * speed * Time.deltaTime, 0, 0);
            transform.Translate(movement);

            // Clamp position to keep the player in bounds
            Vector3 clampedPosition = transform.position;
            clampedPosition.x = Mathf.Clamp(clampedPosition.x, -boundary, boundary); // Adjust bounds as needed
            transform.position = clampedPosition;
        }
    }
}

