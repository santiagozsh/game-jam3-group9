using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectControler : MonoBehaviour
{

    [SerializeField] GameObject Object;
    public int Cant = 1;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            GameObject[] inventario = GameObject.FindGameObjectWithTag("GeneralEvent").GetComponent<InventoryControler>().getSlots();
            for (int i = 0; i < inventario.Length; i++)
            {
                if (!inventario[i])
                {
                    GameObject.FindGameObjectWithTag("GeneralEvent").GetComponent<InventoryControler>().setSlot(Object, i, 0);
                    GameObject.FindGameObjectWithTag("GeneralEvent").GetComponent<InventoryControler>().showInventory();
                    Destroy(gameObject);
                }
            }

        }
    }


}
