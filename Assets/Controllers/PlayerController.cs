using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public int basketNumber;
    public float rightBoundary;
    public float leftBoundary;
    private float halfWidth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Orthographic camera boundaries
        float vertExtent = Camera.main.orthographicSize;
        float horzExtent = vertExtent * Screen.width / Screen.height;

        // Base world-space edges
        float camLeft = Camera.main.transform.position.x - horzExtent;
        float camRight = Camera.main.transform.position.x + horzExtent;

        // Sprite half-width
        if (GetComponent<SpriteRenderer>() != null)
            halfWidth = GetComponent<SpriteRenderer>().bounds.extents.x;
        else
            halfWidth = 0.5f; // default if no sprite renderer

        // Adjusted edges
        leftBoundary = camLeft + halfWidth;
        rightBoundary = camRight - halfWidth;
        //leftBoundary = -5 + halfWidth;
        //rightBoundary = 5 - halfWidth;
    }

    // Update is called once per frame
    void Update()
    {
        // Convert mouse screen position to world position
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Clamp mouse X to screen boundaries
        float clampedX = Mathf.Clamp(mouseWorld.x, leftBoundary, rightBoundary);

        // Update player position (keep current Y and Z)
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);

        //If a fruit hits the ground, delete a basket starting from number 3


        //if this is basket number 3, delete the basket and set basket number to 2


        //if this is basket number 2, delete the basket and set basket number to 1
        //if this is basket number 1, delete the basket and set basket number to 0

        if (basketNumber > GameController.Instance.lives)
        {
            gameObject.SetActive(false);
        }
        
    }
}
