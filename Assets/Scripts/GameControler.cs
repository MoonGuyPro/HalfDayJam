using TMPro;
using UnityEngine;

public class GameControler : MonoBehaviour
{
    public TMP_Text scoreText;      // Referencja do komponentu Text, który wyœwietli wynik
    private float timeElapsed;  // Zmienna do przechowywania czasu od rozpoczêcia gry
    private bool isGameActive;  // Zmienna kontroluj¹ca, czy gra jest aktywna (czy czas jest liczony)
    private int score;          // Wynik gry (punkty)
    public GameObject gameOverPanel;

    public void Lose ()
    {
        UpdateScoreText();
        isGameActive = false;
        Time.timeScale = 0;     // Zatrzymanie ca³ej gry (pauza)

        gameOverPanel.SetActive(true);  // Wyœwietlenie panelu "Game Over"
    }

    void Start()
    {
        // Inicjalizacja zmiennych
        timeElapsed = 0f;
        score = 0;
        isGameActive = true;

        // Zaczynaj od zaktualizowanego wyniku
        
    }

    void Update()
    {
        // Jeœli gra jest aktywna, licz czas
        if (isGameActive)
        {
            timeElapsed += Time.deltaTime;  // Dodawanie czasu do zmiennej
            score = Mathf.FloorToInt(timeElapsed);  // Przeliczanie na punkty (1 punkt na ka¿d¹ sekundê)
        }
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Wynik: " + score.ToString();  // Ustawienie tekstu w komponencie UI
        }
    }

}
