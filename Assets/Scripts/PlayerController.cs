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
    public int countPowerUp=0;
    [SerializeField] private int timePowerUp = 7;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //horizontalInput = Input.GetAxis("Horizontal");

        //transform.Translate(Vector2.right * horizontalInput * Time.deltaTime *20);

        //if (Input.GetKeyDown(KeyCode.Space) && isOnGround == true && !gameOver)
        //{

        //    playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        //    isOnGround = false;
        //    //playerAnim.SetTrigger("Jump_trig");
        //    //dirtParticle.Stop();
        //    //playerAudio.PlayOneShot(jumpSound, 1.0f);
        //}
    }


 
    private void OnTriggerEnter2D(Collider2D other)
    {        
        if (other.gameObject.CompareTag("PowerUp"))
        {
            countPowerUp++;
            powerUp = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerCountdownRoutine(timePowerUp));
        }
    }

    IEnumerator PowerCountdownRoutine(int timePowerUp)
    {
        yield return new WaitForSeconds(timePowerUp);
        powerUp = false;
    }
}
