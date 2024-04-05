using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private Rigidbody2D playerRb;
    
    public bool isOnGround = true;
    public bool gameOver = false;
    public float jumpForce;
    public bool powerUp;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector2.right * horizontalInput * Time.deltaTime *20);

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround == true && !gameOver)
        {

            playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isOnGround = false;
            //playerAnim.SetTrigger("Jump_trig");
            //dirtParticle.Stop();
            //playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }

  

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        else if (collision.gameObject.CompareTag("PowerUp"))
        {
            powerUp = true;
            Destroy(collision.gameObject);
            StartCoroutine(PowerCountdownRoutine());
        }
    }

    IEnumerator PowerCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        powerUp = false;
    }





}
