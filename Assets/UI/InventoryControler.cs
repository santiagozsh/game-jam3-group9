using TMPro;
using UnityEngine;

public class InventoryControler : MonoBehaviour
{
    [SerializeField] GameObject[] slots;
    TextMeshProUGUI text;

    private int numeroSlotsMax = 4;

    void Start()
    {
        slots = new GameObject[numeroSlotsMax];
    }

    public GameObject[] GetSlots()
    {
        return this.slots;
    }

    public void SetSlot(GameObject slot)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i] == null)
            {
                this.slots[i] = slot;
                return;
            }
        }
    }


    public void showInventory()
    {
        Component[] inventario = GameObject.FindGameObjectWithTag("inventario").GetComponentsInChildren<Transform>();

        if (removerItems(inventario))
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i] != null)
                {
                    for (int e = 0; e < inventario.Length; e++)
                    {
                        GameObject child = inventario[e].gameObject;

                        if (child.tag == "slot" && child.transform.childCount <= 1)
                        {
                            GameObject item = Instantiate(slots[i], child.transform.position, Quaternion.identity);
                            item.transform.SetParent(child.transform, false);
                            item.transform.localPosition = new Vector3(0, 0, 0);
                            item.name = item.name.Replace("Clone", "");
                            break;
                        }
                    }
                }
            }
        }
    }

    public bool removerItems(Component[] inventario)
    {
        for (int e = 1; e < inventario.Length; e++)
        {
            GameObject child = inventario[e].gameObject;
            if (child.tag == "slot" && child.transform.childCount > 0)
            {
                for (int a = 0; a <= 0; a++)
                {
                    Destroy(child.transform.GetChild(a).transform.gameObject);
                }
            }
        }
        return true;
    }
}
