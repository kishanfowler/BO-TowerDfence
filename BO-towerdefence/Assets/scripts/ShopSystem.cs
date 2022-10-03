using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopSystem : MonoBehaviour
{
    public int geld;
    public GameObject toren;
    public bool Ispressed;
    public Vector3 mousePos;
    private TMPro.TextMeshProUGUI geldUI;
    private GameObject tInstance;
    [SerializeField] private Camera MainCamera;
    [SerializeField] private LayerMask layerMask;

    void Start()
    {
       geldUI = GameObject.Find("geldText").GetComponent<TMPro.TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        geldUI.text = "geld : " + geld;
        Ray ray = MainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray,out RaycastHit raycastHit, float.MaxValue, layerMask)) 
        {
            tInstance.transform.position = raycastHit.point;
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            //tInstance.transform.position =
            tInstance = null;
        }

    }

    public void kopen()
    {
        tInstance = Instantiate(toren, mousePos, toren.transform.rotation);
        geld -= 1;
    }
}
