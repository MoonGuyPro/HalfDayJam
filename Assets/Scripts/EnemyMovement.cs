using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2f;          // Pr�dko�� ruchu
    public float speedIncrease = 0.5f; // Wzrost pr�dko�ci po teleportacji
    public float minX = -7f;         // Minimalny X
    public float maxX = 7f;          // Maksymalny X
    public float startY = 7f;        // Pocz�tkowy Y
    public float endY = -5.5f;       // Ko�cowy Y

    private EnemySpawner spawner;

    void Start()
    {
        // Referencja do spawnera
        spawner = FindObjectOfType<EnemySpawner>();

        // Ustaw pocz�tkow� pozycj� przeciwnika
        transform.position = new Vector3(GetRandomX(), startY, 0);
    }

    void Update()
    {
        // Poruszanie przeciwnika w d�
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        // Sprawdzenie, czy przeciwnik osi�gn�� ko�cowy punkt
        if (transform.position.y <= endY)
        {
            // Teleportowanie przeciwnika
            transform.position = new Vector3(GetRandomX(), startY, 0);

            // Zwi�kszenie pr�dko�ci
            speed += speedIncrease;

            // Powiadom spawner o przej�ciu
            spawner.OnEnemyReachedEnd();
        }
    }

    private float GetRandomX()
    {
        return Random.Range(minX, maxX);
    }
}
