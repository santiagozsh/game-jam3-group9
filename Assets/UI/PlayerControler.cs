using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    // Start is called before the first frame update+

    GameObject inventario_con;

    private bool inventoryVisible=false;

    
    void Start()
    {
        inventario_con=GameObject.FindGameObjectWithTag("inventario_con");
        inventario_con.SetActive(false);  
    }

    // Update is called once per frame
    void Update()
    {



        if(Input.GetKeyUp(KeyCode.Y))
        {
            if(!inventoryVisible)
            {
                inventoryVisible=true;
                inventario_con.SetActive(inventoryVisible);
                GameObject.FindGameObjectWithTag("GeneralEvent").GetComponent<InventoryControler>().showInventory();
            }else
            {
                inventoryVisible=false;
                inventario_con.SetActive(inventoryVisible);
            }

        }
    }
    
}
