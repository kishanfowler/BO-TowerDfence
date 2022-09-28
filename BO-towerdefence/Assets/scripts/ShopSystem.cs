using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopSystem : MonoBehaviour
{
    public int geld;
    public GameObject toren;
    public bool Ispressed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject.Find("geldText").GetComponent<TMPro.TextMeshProUGUI>().text = "geld : " + geld;
    }

    public void kopen()
    {
        Instantiate(toren);
        geld -= 1;
    }
}
