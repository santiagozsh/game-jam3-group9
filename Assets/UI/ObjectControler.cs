using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectControler : MonoBehaviour
{
    // Start is called before the first frame update

     [SerializeField] GameObject Object;
    public int Cant =1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.tag=="Player")
        {

            GameObject[] inventario=GameObject.FindGameObjectWithTag("GeneralEvent").GetComponent<InventoryControler>().getSlots();
             for(int i = 0 ;i < inventario.Length; i++ )
             {
                if(!inventario[i])
                {
                    GameObject.FindGameObjectWithTag("GeneralEvent").GetComponent<InventoryControler>().setSlot(Object,i,Cant);
                    Destroy(gameObject);

                }
             }

        }
    }


}
