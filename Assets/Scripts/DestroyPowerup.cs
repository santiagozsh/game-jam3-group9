using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPowerup : MonoBehaviour
{
    [SerializeField] private float timeLifePowerUp = 7;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(PowerCountdownRoutine(timeLifePowerUp));
    }

    IEnumerator PowerCountdownRoutine(float timePowerUp)
    {
       yield return new WaitForSeconds(timePowerUp);
       Debug.Log("Destruye" + gameObject.name);
       Destroy(gameObject);
    }

}
