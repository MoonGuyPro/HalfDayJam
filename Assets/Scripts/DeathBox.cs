using UnityEngine;

public class DeathBox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player hit the obstacle! Game Over.");
            // Implement logic for losing the game (e.g., restart level, show game over screen, etc.)
            LoseGame();
        }
    }

    private void LoseGame()
    {
        // Placeholder for game-over logic
        Debug.Log("Game Over logic goes here.");
    }
}
