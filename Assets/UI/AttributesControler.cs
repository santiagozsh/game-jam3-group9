using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributesControler : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]int cantidad;
    public void Setcantidad(int cantidad)
    {
        this.cantidad = cantidad;
    }
    public int  getCantidad()
    {
        return this.cantidad;
    }

    
}
