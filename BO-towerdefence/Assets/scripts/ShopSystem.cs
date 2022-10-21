using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopSystem : MonoBehaviour
{
    public int geld;
    public bool Ispressed;
    public GameObject toren;
    private GameObject geselecteerdetoren;
    private Vector3 mousePos;
    private TMPro.TextMeshProUGUI geldUI;
    private GameObject tInstance;
    [SerializeField] private Camera MainCamera;
    [SerializeField] private LayerMask layerMask;
    private bool move = false;
    [SerializeField] private TorenAI torenai;
    private bool canbuy;
    public GameObject selectUI;
    [SerializeField] private GameObject range;

    void Start()
    {
        range = toren.transform.GetChild(0).gameObject;
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

        if (raycastHit.transform.CompareTag("toren"))
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                selecteren(raycastHit.transform.gameObject);
            }
            
        }

        if (Physics.Raycast(ray, out raycastHit, float.MaxValue, layerMask) && move == true)
        {
            tInstance.transform.position = raycastHit.point;
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                tInstance = null;
                verberg();
            }
        }

        

    }
    public void kopen()
    {
        if (torenai.prijs <= geld)
        {
            deselecteer();
            canbuy = true;
            geld -= torenai.prijs;
            if (canbuy)
            {
                tInstance = Instantiate(toren, mousePos, toren.transform.rotation);
                range.SetActive(true);
            }
            
            if (tInstance != null)
            {
                canbuy = false;
            }
        }
    }
    private void verberg()
    {
        selectUI.SetActive(false);
        range.SetActive(false);
    }
    private void selecteren(GameObject target)
    {
        if(geselecteerdetoren == target)
        {
            deselecteer();
            return;
        }
        geselecteerdetoren = target;
        tInstance = null;
        selectUI.SetActive(true);
        range.SetActive(true);
        selectUI.transform.position = geselecteerdetoren.transform.position;
        
    }
    public void deselecteer()
    {
        geselecteerdetoren = null;
        verberg();
    }

}
