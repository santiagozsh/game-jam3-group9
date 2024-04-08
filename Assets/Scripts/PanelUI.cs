using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelUI : MonoBehaviour
{

    private void OnEnable()
    {
        Invoke("turnOffPanel", 2f);
    }

    void turnOffPanel()
    {
        gameObject.SetActive(false);
    }
}
