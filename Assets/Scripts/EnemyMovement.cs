using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2f;          // Prêdkoœæ ruchu
    public float speedIncrease = 0.5f; // Wzrost prêdkoœci po teleportacji
    public float minX = -7f;         // Minimalny X
    public float maxX = 7f;          // Maksymalny X
    public float startY = 7f;        // Pocz¹tkowy Y
    public float endY = -5.5f;       // Koñcowy Y

    private EnemySpawner spawner;

    void Start()
    {
        // Referencja do spawnera
        spawner = FindObjectOfType<EnemySpawner>();

        // Ustaw pocz¹tkow¹ pozycjê przeciwnika
        transform.position = new Vector3(GetRandomX(), startY, 0);
    }

    void Update()
    {
        // Poruszanie przeciwnika w dó³
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        // Sprawdzenie, czy przeciwnik osi¹gn¹³ koñcowy punkt
        if (transform.position.y <= endY)
        {
            // Teleportowanie przeciwnika
            transform.position = new Vector3(GetRandomX(), startY, 0);

            // Zwiêkszenie prêdkoœci
            speed += speedIncrease;

            // Powiadom spawner o przejœciu
            spawner.OnEnemyReachedEnd();
        }
    }

    private float GetRandomX()
    {
        return Random.Range(minX, maxX);
    }
}
