using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeldScript : MonoBehaviour
{
    private TMPro.TextMeshProUGUI geldUI;
    public int geld;
    // Start is called before the first frame update
    void Start()
    {
        geldUI = GameObject.Find("geldText").GetComponent<TMPro.TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        geldUI.text = "geld:" + geld;
    }
}
