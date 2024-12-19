using TMPro;
using UnityEngine;

public class GameControler : MonoBehaviour
{
    public TMP_Text scoreText;      // Referencja do komponentu Text, kt�ry wy�wietli wynik
    private float timeElapsed;  // Zmienna do przechowywania czasu od rozpocz�cia gry
    private bool isGameActive;  // Zmienna kontroluj�ca, czy gra jest aktywna (czy czas jest liczony)
    private int score;          // Wynik gry (punkty)
    public GameObject gameOverPanel;

    public void Lose ()
    {
        UpdateScoreText();
        isGameActive = false;
        Time.timeScale = 0;     // Zatrzymanie ca�ej gry (pauza)

        gameOverPanel.SetActive(true);  // Wy�wietlenie panelu "Game Over"
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
        // Je�li gra jest aktywna, licz czas
        if (isGameActive)
        {
            timeElapsed += Time.deltaTime;  // Dodawanie czasu do zmiennej
            score = Mathf.FloorToInt(timeElapsed);  // Przeliczanie na punkty (1 punkt na ka�d� sekund�)
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
