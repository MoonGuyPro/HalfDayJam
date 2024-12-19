using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;   // Prefab przeciwnika
    public int spawnAfterPasses = 20; // Liczba przejœæ do spawnowania nowego przeciwnika
    public int maxEnemies = 3;       // Maksymalna liczba przeciwników

    private int passes = 0;           // Licznik przejœæ dolnego punktu
    private int currentEnemies = 0;  // Liczba aktywnych przeciwników

    void Start()
    {
        // Spawn pierwszego przeciwnika
        SpawnEnemy();
    }

    public void OnEnemyReachedEnd()
    {
        // Zwiêkszenie licznika przejœæ
        passes++;

        // Jeœli licznik osi¹gnie próg, spróbuj zespawnowaæ nowego przeciwnika
        if (passes >= spawnAfterPasses && currentEnemies < maxEnemies)
        {
            passes = 0; // Reset licznika
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        // Ustawienie pozycji dla nowego przeciwnika
        float randomX = Random.Range(-7f, 7f);
        Vector3 spawnPosition = new Vector3(randomX, 7f, 0);

        // Tworzenie przeciwnika
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

        // Zwiêkszenie liczby przeciwników
        currentEnemies++;
    }
}
