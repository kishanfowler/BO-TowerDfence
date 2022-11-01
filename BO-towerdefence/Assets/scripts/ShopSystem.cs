using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopSystem : MonoBehaviour
{
    private int geld;
    public bool Ispressed;
    public GameObject toren;
    private GameObject geselecteerdetoren;
    private Vector3 mousePos;
    private GameObject tInstance;
    [SerializeField] private Camera MainCamera;
    [SerializeField] private LayerMask layerMask;
    private bool move = true;
    private TorenAI torenai;
    private bool canbuy;
    public GameObject selectUI;
    [SerializeField] private GameObject range;

    void Start()
    {
        torenai = toren.transform.GetChild(1).GetComponent<TorenAI>();
        selectUI = GameObject.Find("selectUI");
        geld = GameObject.Find("geldText").GetComponent<GeldScript>().geld;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = MainCamera.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, layerMask);
        
        if (raycastHit.transform.CompareTag("toren"))
        {
            Debug.Log(raycastHit.transform.name);
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                selecteren(raycastHit.transform.gameObject);
            }
            
        }

        if (Physics.Raycast(ray, out raycastHit, float.MaxValue, layerMask) && move == true && tInstance != null)
        {
            if(raycastHit.transform.gameObject.layer == 0 || raycastHit.transform.gameObject.layer == 3)
            {
                tInstance.transform.position = raycastHit.point;
            }
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                deselecteer();
                tInstance = null;
            }
        }

        

    }
    public void kopen()
    {
        if (torenai.prijs <= geld)
        {
            canbuy = true;
            geld -= torenai.prijs;
            if (canbuy)
            {
                tInstance = Instantiate(toren, mousePos, toren.transform.rotation);
                range = tInstance.transform.GetChild(0).gameObject;
                range.SetActive(true);
                Debug.Log("komt bij de range");
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
