using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;   // Prefab przeciwnika
    public int spawnAfterPasses = 20; // Liczba przej�� do spawnowania nowego przeciwnika
    public int maxEnemies = 3;       // Maksymalna liczba przeciwnik�w

    private int passes = 0;           // Licznik przej�� dolnego punktu
    private int currentEnemies = 0;  // Liczba aktywnych przeciwnik�w

    void Start()
    {
        // Spawn pierwszego przeciwnika
        SpawnEnemy();
    }

    public void OnEnemyReachedEnd()
    {
        // Zwi�kszenie licznika przej��
        passes++;

        // Je�li licznik osi�gnie pr�g, spr�buj zespawnowa� nowego przeciwnika
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

        // Zwi�kszenie liczby przeciwnik�w
        currentEnemies++;
    }
}
