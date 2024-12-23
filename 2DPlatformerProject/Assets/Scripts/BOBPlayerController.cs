using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class BOBPlayerController : MonoBehaviour
{
    [Header("Animation")]
    public Animator BOBanimator;
   
    [Header("Health")]
    public Slider healthSlider;
    public JORGEPlayerController JorgeScript;

    [Header("Main")]
    public float BOBmoveSpeed;
    public float BOBjumpForce;
    float BOBinputs;
    public Rigidbody2D BOBrb;
    public float BOBgroundDistance;
    public bool BOBisFacingRight;
    public LayerMask BOBlayerMask;

    RaycastHit2D BOBhit;

    Vector3 BOBstartPos;

    // Start is called before the first frame update
    void Start()
    {
        BOBstartPos = transform.position;
        BOBisFacingRight = true;
    }

    // Update is called once per frame
    void Update()
    {    
        BOBMovement();
        JorgeScript.Health();
        BOBMovementDirection();
        BOBPlayerAnimator();
    }

    void BOBMovement()
    {
        BOBinputs = Input.GetAxisRaw("Horizontal");
        BOBrb.velocity = new UnityEngine.Vector2(BOBinputs * BOBmoveSpeed, BOBrb.velocity.y);

        BOBhit = Physics2D.Raycast(transform.position, -transform.up, BOBgroundDistance, BOBlayerMask);
        Debug.DrawRay(transform.position, -transform.up * BOBgroundDistance, Color.yellow);

        if (BOBhit.collider)
        {
            if (Input.GetButtonDown("Jump"))
            {
                BOBrb.AddForce(transform.up * BOBjumpForce, ForceMode2D.Impulse);
            }
        }
    }

    // void Health()
    // {
    //  JorgeScript.healthSlider.value = JorgeScript.currentHealth;

    //  if (JorgeScript.currentHealth <= 0)
    //  {
    //      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    //  }

    // }

    void BOBMovementDirection()
    {
        if (BOBisFacingRight && BOBinputs < -.1f)
        {
            BOBFlip();
        }
        else if (!BOBisFacingRight && BOBinputs > .1f)
        {
            BOBFlip();
        }
    }  

    void BOBFlip()
    {
        BOBisFacingRight = !BOBisFacingRight;
        transform.Rotate(0f, 180f, 0f);
    } 

    void BOBPlayerAnimator()
    {
        BOBanimator.SetFloat("BOBSpeed", Mathf.Abs(BOBinputs));
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Hazard"))
        {
            JorgeScript.currentHealth--;
            transform.position = BOBstartPos;
        }
        if (other.gameObject.CompareTag("Exit"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            JorgeScript.currentHealth--;
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Health"))
        {
            JorgeScript.currentHealth++;
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("HealthTake"))
        {
            JorgeScript.currentHealth--;
            Destroy(other.gameObject);
        }
    }
}
