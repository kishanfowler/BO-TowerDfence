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

        
        GameObject fastestEnemie = transform.GetComponent<EnemyChecker>().FastestEnemie;
        if (fastestEnemie == null)
        {
            fastestEnemie = transform.GetComponent<EnemyChecker>().FastestEnemie;
        }

        if (transform.position.x - fastestEnemie.transform.position.x >= -8 && transform.position.x - fastestEnemie.transform.position.x <= 0 || transform.position.z - fastestEnemie.transform.position.z <= 8 && transform.position.z - fastestEnemie.transform.position.z >= 0)
        {
            if (valtAan == false && fastestEnemie != null)
            {
                valtAan = true;
                StartCoroutine(Attack(tijdInterVal));
            }
        }
        IEnumerator Attack(float TimeInterval)
        {
            yield return new WaitForSeconds(TimeInterval);
            valtAan = false;
            GameObject fastestEnemie = transform.GetComponent<EnemyChecker>().FastestEnemie;
            fastestEnemie.GetComponent<AiController>().Health -= HandPower;
        }
    }
}
