using UnityEngine;
using UnityEngine.Rendering;

public class DeathBox : MonoBehaviour
{
    private GameControler m_GameControler;
    private void Start()
    {
        m_GameControler = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControler>();
    }

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
        m_GameControler.Lose();
    }
}
