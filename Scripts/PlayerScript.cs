using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{

    public float JumpForce;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public Animator animator;
    float score;


    [SerializeField] private AudioClip JumpFrog;
    [SerializeField] bool isGrounded = false;
    [SerializeField] bool isAlive = true;

    Rigidbody2D rb;

    public Text ScoreTxt;

    private void Awake()
    {

        rb = GetComponent<Rigidbody2D>();
        score = 0;
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(isGrounded == true)
            {
                    animator.SetBool("isJumping", true);
                    rb.AddForce(Vector2.up * JumpForce);
                    isGrounded = false;
                SoundManager.instance.PlaySound(JumpFrog); //skok dzwiek

            }
        }
        if (rb.velocity.y < 0) 
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }

        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }



            if(isAlive)
            {
                score += Time.deltaTime * 4;
                ScoreTxt.text = "Punkty: " + score.ToString("0"); 
            }
    }



        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.CompareTag("ground"))
            {
                if(isGrounded == false)
                {
                    isGrounded = true;
                    animator.SetBool("isJumping", false);
                }
                
            }

            if(collision.gameObject.CompareTag("spike"))
            {
              isAlive = false;
            
            SceneManager.LoadScene("GameOver");
           

        }

        }


}