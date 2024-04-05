using TMPro;
using UnityEngine;
//using UnityEngine.UI;

public class InventoryControler : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]GameObject[] slots;
    TextMeshProUGUI text;

    private int numeroSlotsMax=3;
    
    void Start()
    {
        slots=new GameObject[numeroSlotsMax];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public  GameObject[] getSlots()
    {
        return this.slots;
    }
    public void setSlot(GameObject slot,int pos,int cant)
    {
        bool exist= false;
        for(int i =0 ;i < slots.Length;i++)
        {
            if(slots[i] != null)
            {
                if(slots[i].tag==slot.tag)
                {
                    int already_Cant=slots[i].GetComponent<AttributesControler>().getCantidad();
                    this.slots[i].GetComponent<AttributesControler>().Setcantidad(already_Cant= cant);
                    exist=true;
                }
            }
        }
        if(!exist)
        {
            slot.GetComponent<AttributesControler>().Setcantidad(cant);
            this.slots[pos]=slot;
        }
    }
    public void showInventory()
    {
        Component[] inventario=GameObject.FindGameObjectWithTag("inventario").GetComponentsInChildren<Transform>();
        bool slotUsed=false;

        if(removerItems(inventario))
        {
            for(int i = 0 ;i < slots.Length; i++ )
            {
                if(slots[i] != null)
                {
                    slotUsed=false; 
                    for(int e=0;e < inventario.Length; e++)
                    {
                        GameObject child=inventario[e].gameObject;

                        if(child.tag=="slot" && child.transform.childCount<=1 && !slotUsed)
                        {
                            GameObject item=Instantiate(slots[i],child.transform.position,Quaternion.identity);
                            item.transform.SetParent(child.transform,false);
                            item.transform.localPosition=new Vector3 (0,0,0);
                            item.name=item.name.Replace("Clone","");
                            text=item.GetComponentInChildren<TextMeshProUGUI>();
                            int cant=4;
                            text.text=cant+"";

                            slotUsed=true;
                        }
                    }               
                }

            }
        }
    }
    public bool removerItems(Component[] inventario)
    {
        for (int e =1;e < inventario.Length;e++)
        {
            GameObject child=inventario[e].gameObject;
            if(child.tag=="slot" && child.transform.childCount>0)
            {
                for(int a = 0; a <= 0; a++)
                {
                    Destroy(child.transform.GetChild(a).transform.gameObject);
                }
            }
        }
        return true;
    }
}
