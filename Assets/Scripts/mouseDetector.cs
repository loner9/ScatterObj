using UnityEngine;

public class mouseDetector : MonoBehaviour
{
    Camera mainCamera;
    [SerializeField] float detectionRadius = 2f;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        GameObject[] movers = GameObject.FindGameObjectsWithTag("Ball");
        bool shouldMoveNow = false;

        foreach (GameObject obj in movers)
        {
            float distance = Vector3.Distance(obj.transform.position, mousePosition);
            if (distance < detectionRadius)
            {
                shouldMoveNow = true;
                break;
            }
        }

        moveManager.shouldMove = shouldMoveNow;
    }
}
