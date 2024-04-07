using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectControler : MonoBehaviour
{
    [SerializeField] GameObject Object;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameObject[] inventario = GameObject.FindGameObjectWithTag("GeneralEvent").GetComponent<InventoryControler>().GetSlots();
            for (int i = 0; i < inventario.Length; i++)
            {
                if (!inventario[i])
                {
                    GameObject.FindGameObjectWithTag("GeneralEvent").GetComponent<InventoryControler>().SetSlot(Object);
                    GameObject.FindGameObjectWithTag("GeneralEvent").GetComponent<InventoryControler>().showInventory();
                    Destroy(gameObject);
                    return;
                }
            }
        }
    }
}
