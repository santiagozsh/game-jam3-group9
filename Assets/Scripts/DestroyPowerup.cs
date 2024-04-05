using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPowerup : MonoBehaviour
{
    [SerializeField] private float timeLifePowerUp = 15;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        StartCoroutine(PowerCountdownRoutine(timeLifePowerUp));

        
    }

    IEnumerator PowerCountdownRoutine(float timePowerUp)
    {
       yield return new WaitForSeconds(timePowerUp);
       Debug.Log("Destruye" + gameObject.name);
       Destroy(gameObject);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {

        //if (collision.gameObject.CompareTag("Ground"))
        //{
        //    isOnGround = true;
        //}
        if (other.gameObject.layer==LayerMask.NameToLayer("Ground"))
        {
      
            Destroy(gameObject);
            
        }
    }

}
