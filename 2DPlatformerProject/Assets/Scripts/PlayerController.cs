using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class JORGEPlayerController : MonoBehaviour
{
    [Header("Shooting")]
    public Transform shootingPoint;
    public GameObject bullet;
    bool isFacingRight;

    [Header("Health")]
    public Slider healthSlider;
    public int maxHealth;
    public int currentHealth;
    public GameObject Bob;
    bool BobDead;

    [Header("Animation")]
    public Animator animator;
    public bool IsRangedAttack;

    [Header("Main")]
    public float moveSpeed;
    public float jumpForce;
    float inputs;
    public Rigidbody2D rb;
    public float groundDistance;
    public LayerMask layerMask;
    bool canClimb;

    RaycastHit2D hit;

    Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        startPos = transform.position;

        healthSlider.maxValue = maxHealth;

        isFacingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        Movement();
        Ladder();
        Health();
        Shoot();
        MovementDirection();
        PlayerAnimator();
        Reset();
    }

    void Movement()
    {
        inputs = Input.GetAxisRaw("Horizontal");
        rb.velocity = new UnityEngine.Vector2(inputs * moveSpeed, rb.velocity.y);

        hit = Physics2D.Raycast(transform.position, -transform.up, groundDistance, layerMask);
        Debug.DrawRay(transform.position, -transform.up * groundDistance, Color.yellow);
    }

    void Reset()
    {
        if (BobDead == true)
        {
            Bob.transform.GetChild(0).transform.position = startPos;
            BobDead = false;
        }
    }

    void Ladder()
    {
        if (canClimb == true)
        {
            if (Input.GetKeyDown(KeyCode.V))
            {
                transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime * moveSpeed);
            }
        }
    }

    void Health()
    {
        healthSlider.value = currentHealth;

        if (currentHealth <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Instantiate(bullet, shootingPoint.position, shootingPoint.rotation);
        }
    }

    void MovementDirection()
    {
        if (isFacingRight && inputs < -.1f)
        {
            Flip();
        }
        else if (!isFacingRight && inputs > .1f)
        {
            Flip();
        }
    }  

    void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    } 

    void PlayerAnimator()
    {
        animator.SetFloat("Speed", Mathf.Abs(inputs));
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Hazard"))
        {
            currentHealth--;
            transform.position = startPos;
            BobDead = true;
        }
        if (other.gameObject.CompareTag("Exit"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            currentHealth--;
            BobDead = true;
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Ladder"))
        {
            canClimb = true;
        }
    }
}
