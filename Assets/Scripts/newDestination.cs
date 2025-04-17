using UnityEngine;

public class newDestination : MonoBehaviour
{
    [SerializeField] float detectionRadius = 0.7f;
    public float boundaryPadding = 1f;
    Camera mainCamera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        float distance = Vector3.Distance(transform.position, mousePosition);

        if (distance < detectionRadius)
        {
            transform.position = GetRandomPositionInsideCameraView();
        }
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

    Vector2 ClampPositionToCameraView(Vector2 position)
    {
        
        float camHeight = mainCamera.orthographicSize;
        float camWidth = camHeight * mainCamera.aspect;

        float clampedX = Mathf.Clamp(position.x, 
            mainCamera.transform.position.x - camWidth + boundaryPadding, 
            mainCamera.transform.position.x + camWidth - boundaryPadding);
        
        float clampedY = Mathf.Clamp(position.y, 
            mainCamera.transform.position.y - camHeight + boundaryPadding, 
            mainCamera.transform.position.y + camHeight - boundaryPadding);

        return new Vector2(clampedX, clampedY);
    }
}
