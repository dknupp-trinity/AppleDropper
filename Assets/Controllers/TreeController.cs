using UnityEngine;

public class TreeController : MonoBehaviour
{
    //Movement
    public float speed = 5f;
    public float rightBoundary;
    public float leftBoundary;
    public int direction = 1; // 1 for right, -1 for left
    
    
    
    //Fruit Dropping
    public float dropInterval = 1f; // Time in seconds between drops
    private float dropTimer;
    
    public GameObject fruit1;
    public GameObject fruit2;
    public GameObject fruit3;
    public GameObject currentFruit;
    
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentFruit = fruit1;
        // Read initial drop interval from GameController if available so timer starts correctly
        if (GameController.Instance != null)
        {
            dropInterval = GameController.Instance.dropInterval;
        }

        // Initialize timer so first drop happens after dropInterval instead of immediately
        dropTimer = dropInterval;
        
        // Orthographic camera boundaries
        float vertExtent = Camera.main.orthographicSize;
        float horzExtent = vertExtent * Screen.width / Screen.height;

        // Base world-space edges
        float camLeft = Camera.main.transform.position.x - horzExtent;
        float camRight = Camera.main.transform.position.x + horzExtent;

        // Get sprite half-width in world units
        float halfWidth = GetComponent<SpriteRenderer>().bounds.extents.x;

        // Adjust edges so sprite never goes off-screen
        leftBoundary = camLeft + halfWidth;
        rightBoundary = camRight - halfWidth;
    }

    void Update()
    {
        // Move horizontally
        transform.Translate(Vector2.right * direction * speed * Time.deltaTime);

        // Flip direction if hitting edges
        if (transform.position.x >= rightBoundary)
            direction = -1;
        else if (transform.position.x <= leftBoundary)
            direction = 1;


        // Update settings from GameController if available
        if (GameController.Instance != null)
        {
            //set tree speed from the GameController
            speed = GameController.Instance.treeSpeed;

            //set drop interval from the GameController drop rate
            dropInterval = GameController.Instance.dropInterval;
        }

        //Timer stuff


        // Count down
        dropTimer -= Time.deltaTime;

        // When timer reaches zero, drop fruit
        if (dropTimer <= 0f)
        {
            DropItem();
            dropTimer = dropInterval; // Reset timer
        }
        
    }

    private void DropItem()
    {
        if (currentFruit != null)
        {
            Instantiate(currentFruit, transform.position, Quaternion.identity);
        }
    }
}
