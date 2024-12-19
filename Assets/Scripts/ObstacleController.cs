using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public bool isPlayerInCollision = false;
    public Transform player; // Assign the Player transform in the Inspector
    public float vibrationDistanceThreshold = 10f; // Maximum distance for vibration to occur
    private float vibrationTimer = 0f;

    private void Update()
    {
        if (isPlayerInCollision)
        {
            float distance = Vector3.Distance(player.position, transform.position)-1f;
            float vibrationInterval = Mathf.Lerp(0.1f, 1f, distance / vibrationDistanceThreshold);

            // Decrease timer and vibrate at intervals
            vibrationTimer -= Time.deltaTime;
            if (vibrationTimer <= 0f)
            {
                Handheld.Vibrate(); // Vibrate the phone
                vibrationTimer = vibrationInterval; // Reset timer based on the interval
            }

            Debug.Log($"Vibrating... Distance: {distance}, Interval: {vibrationInterval}");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInCollision = true;
            Debug.Log("Player entered trigger area.");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInCollision = false;
            Debug.Log("Player exited trigger area.");
        }
    }
}

