using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorenAI : MonoBehaviour
{
    public Transform target; 
    public GameObject enemychecker;
    public float tijdInterVal = 0.3f;
    public int HandPower = 1;
    public List<GameObject> enemies = new List<GameObject>();
    public AiController aiController;
    public List<GameObject> waveMachines = new List<GameObject>();
    public bool valtAan = false;
    private Coroutine cr;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (target != null)
        {
            if (Vector3.Distance(transform.position, target.position) <= 6)
            {
                FaceTarget();
            }
        }
       
        
    }

    void FaceTarget()
    {
        transform.LookAt(target);
        if (target != null) { 
            if (transform.position.x - target.transform.position.x >= -8 && transform.position.x - target.transform.position.x <= 0 || transform.position.z - target.transform.position.z <= 8 && transform.position.z - target.transform.position.z >= 0)
            {
                if (valtAan == false && target != null)
                {
                    valtAan = true;
                    cr =StartCoroutine(Attack(tijdInterVal));
                }
            }

            if(target == null)
            {
                StopAllCoroutines();
            }
        }
        IEnumerator Attack(float TimeInterval)
        {
            yield return new WaitForSeconds(TimeInterval);
            valtAan = false;
            if (target != null)
            {
                target.GetComponent<AiController>().Health -= HandPower;
                if(target.GetComponent<AiController>().Health <= 0)
                {
                    StopCoroutine(cr);
                }

            }
        }
    }
}
