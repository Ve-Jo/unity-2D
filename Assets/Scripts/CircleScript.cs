using UnityEngine;

public class CircleScript : MonoBehaviour
{
    public static int score = 0;
    public static int health = 3;

    [SerializeField]
    private float forceFactor = 400f;

    private Rigidbody2D rb2d;

    [SerializeField]
    private PauseScript pauseCanvas;

    void Start()
    {
        rb2d = this.GetComponent<Rigidbody2D>();
        score = 0;
        health = 3;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            rb2d.AddForce(forceFactor * Time.timeScale * Vector2.up);
        }    
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Fault"))
        {
            if (pauseCanvas != null)
            {
                health--;
                GameObject tubeRoot = other.transform.parent.gameObject;
                
                if (health <= 0)
                {
                    pauseCanvas.ShowMessage("Game Over!\nNo hearts left!", tubeRoot, true);
                }
                else
                {
                    pauseCanvas.ShowMessage($"Ouch! {health} hearts left", tubeRoot, false);
                }
            }
            else
            {
                Debug.Log("Game Over");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Tube"))
        {
            score += 1;
        }
    }
}
