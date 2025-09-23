using UnityEngine;

public class FruitController : MonoBehaviour
{
    
    private int fruitTypeMultiplier = 1; // Default multiplier - Apple


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // mltiply gravity by the gravity multiplier from the GameController
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.gravityScale *= GameController.Instance.gravity;
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameController.Instance.score += 1 * fruitTypeMultiplier;
            Destroy(gameObject);
        }

        if (collision.CompareTag("Ground"))
        {
            Destroy(gameObject);
            GameController.Instance.lives -= 1;
        }
  }

  // Update is called once per frame
  void Update()
    {
        
    }
}
