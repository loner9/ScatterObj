using UnityEngine;

public class spawner : MonoBehaviour
{
    public float boundaryPadding = 1f;
    Camera mainCamera;
    public GameObject objectToSpawn;
    public int amountToSpawn = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = Camera.main;
        for (int i = 0; i < amountToSpawn; i++)
        {
            Vector2 spawnPosition = GetRandomPositionInsideCameraView();
            Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector2 GetRandomPositionInsideCameraView()
    {
        float camHeight = mainCamera.orthographicSize;
        float camWidth = camHeight * mainCamera.aspect;

        float minX = mainCamera.transform.position.x - camWidth + boundaryPadding;
        float maxX = mainCamera.transform.position.x + camWidth - boundaryPadding;
        float minY = mainCamera.transform.position.y - camHeight + boundaryPadding;
        float maxY = mainCamera.transform.position.y + camHeight - boundaryPadding;

        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        return new Vector2(randomX, randomY);
    }
}
