using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnPoweup : MonoBehaviour
{
    
    public GameObject[] powerUps;
    private PlayerController playerController;
    private float startDelay = 10;
    private float repeatRate = 5;
    private float posPlayerX;
    private float posPlayerY;
    private int offsetX;
    private int offsetY;
    private int pos;

    // Start is called before the first frame update
    void Start()
    {       
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnPowerUp", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnPowerUp()
    {
        posPlayerX = playerController.transform.position.x;
        posPlayerY = playerController.transform.position.y;
        offsetX = Random.Range(2, 6);
        offsetY = Random.Range(0, 4);
        pos = Random.Range(0, powerUps.Length);
        Instantiate(powerUps[pos], new Vector2(posPlayerX + offsetX, posPlayerY + offsetY), powerUps[0].transform.rotation);
    }

    



}
