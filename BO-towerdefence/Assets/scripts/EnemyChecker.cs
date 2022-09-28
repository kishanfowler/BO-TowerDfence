using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChecker : MonoBehaviour
{
    public List<GameObject> enemies = new List<GameObject>();
    public int i = 0;
    public GameObject FastestEnemie;
    public AiController aiController;

    private TorenAI ai;
    // Start is called before the first frame update
    void Start()
    {
        ai = transform.GetComponent<TorenAI>();
    }
    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("enemy collision with trigger");
        if (other.gameObject.tag == "Enemy")
        {

            enemies.Add(other.gameObject);

            Debug.Log("enemies" + enemies);
            ai.target = enemies[0].transform;
            other.gameObject.GetComponent<AiController>().enemychecker.Add(gameObject);
        }

      

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            enemies.Remove(other.gameObject);
            other.gameObject.GetComponent<AiController>().enemychecker.Remove(gameObject);
            /*
            if (FastestEnemie == other.gameObject)
            {
                FastestEnemie = enemies[0];
            }
            */
        }
    }

}