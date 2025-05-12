using UnityEngine;

public class plate_script : MonoBehaviour
{
    [SerializeField] private float h_speed;
    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = new Vector2(h_speed, rb.linearVelocity.y);
        if (transform.position.x < -15)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            
            
            Destroy(gameObject);
        }
    }

}
