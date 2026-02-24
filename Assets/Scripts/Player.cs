using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using TMPro;
using FMODUnity;

public class Player : MonoBehaviour
{
    StudioEventEmitter hitSound;
    DodgerAttributes playerAttributes = new DodgerAttributes(3, 8, 0);
    [SerializeField] private float moveSpeed;
    Rigidbody2D rb;
    [SerializeField] InputSystem inputSystem;
    [SerializeField] TextMeshProUGUI healthText;
    int health = 3;

         void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = playerAttributes.CurrentHealth();
        hitSound = GetComponent<StudioEventEmitter>();
    }

    // Update is called once per frame
    void Update()
    {
        int moveDirection = 0;

        Vector2 screenPos;

        if(inputSystem.IsPressing(out screenPos))
        {
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(new Vector3(screenPos.x, screenPos.y, 0f));

            if(touchPos.x < 0)
            {
                moveDirection = -1;
            }
            else
            {
                moveDirection = 1;
            }

            rb.linearVelocityX = moveDirection * moveSpeed;
        }

        Vector3 viewportPos = Camera.main.WorldToViewportPoint(rb.position);

        if((viewportPos.x <= 0f && moveDirection < 0)||(viewportPos.x >= 1f && moveDirection > 0))
        {
            moveDirection = 0;
        }
        rb.linearVelocityX = moveDirection * moveSpeed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {

            hitSound.Play();
            playerAttributes.SetHealth(playerAttributes.CurrentHealth() - 1);
            Destroy(collision.gameObject);
            healthText.text = playerAttributes.CurrentHealth().ToString();
            if (playerAttributes.CurrentHealth() <= 0)
            {
                 SceneManager.LoadScene(0);
            }
           
        }
    
    }

    void UpdateHealthText(int health)
    {
        healthText.text = health.ToString();
    }
    
}
