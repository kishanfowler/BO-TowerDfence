using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorenAI : MonoBehaviour
{
    public Transform target;
    public float tijdInterVal = 0.3f;
    public int Damage = 1;
    public bool valtAan = false;
    private Coroutine cr;
    public int prijs = 15;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, target.position) <= 6)
        {
            FaceTarget();
        }
    }

    void FaceTarget()
    {
        transform.LookAt(target);
        if (target != null) { 
           
            if (valtAan == false && target != null)
            {
                valtAan = true;
                cr = StartCoroutine(Attack(tijdInterVal));
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
                target.GetComponent<AiController>().Health -= Damage;
                if(target.GetComponent<AiController>().Health <= 0)
                {
                    StopCoroutine(cr);
                }

            }
        }
    }
}
