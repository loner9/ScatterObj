using UnityEngine;

public class moveTo : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;
    Camera mainCamera;
    [SerializeField] float detectionRadius = 2f;
    [SerializeField] float speed = 5f;
    GameObject targetObject;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
        spriteRenderer = GetComponent<SpriteRenderer>();
        targetObject = GameObject.FindGameObjectWithTag("Player");
        speed = Random.Range(0.5f, 4.5f);
        AssignRandomColor();
    }

    // Update is called once per frame
    void Update()
    {
        if (moveManager.shouldMove)
        {
            moveToDest();
        }
    }

    public void moveToDest(){
        rb.MovePosition(Vector3.MoveTowards(transform.position, targetObject.transform.position, Time.deltaTime * speed));
    }

    void OnDrawGizmosSelected()
    {
        // Visualize detection radius
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }

    void AssignRandomColor()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = new Color(
                Random.Range(0f, 1f),
                Random.Range(0f, 1f),
                Random.Range(0f, 1f),
                1f
            );
        }
    }
}
