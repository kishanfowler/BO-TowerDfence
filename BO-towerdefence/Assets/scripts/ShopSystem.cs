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
    private bool move = false;
    private TorenAI torenai;
    private bool canbuy;

    void Start()
    {
        torenai = GameObject.Find("GameObject").GetComponent<TorenAI>();
        geldUI = GameObject.Find("geldText").GetComponent<TMPro.TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        geldUI.text = "geld:" + geld;
        Ray ray = MainCamera.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, layerMask);

        if (raycastHit.transform.gameObject.layer == 0)
        {
            move = true;
        }

        if (Physics.Raycast(ray,out raycastHit, float.MaxValue, layerMask) && move == true) 
        {
            tInstance.transform.position = raycastHit.point;
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            tInstance = null;
        }

    }

    public void kopen()
    {
        if (torenai.prijs <= geld)
        {
            canbuy = true;
            geld -= torenai.prijs;
            if (canbuy){

                tInstance = Instantiate(toren, mousePos, toren.transform.rotation);
            }
            if(tInstance != null)
            {
                canbuy = false;
            }
        }
    }
}
