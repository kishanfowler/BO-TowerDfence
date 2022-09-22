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
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        Check();
    }
    public void Check()
    {
        if (FastestEnemie == null) { return; }
        else
        {
            FastestEnemie = enemies[0];
        }
        
        if (i >= enemies.Count || i <= enemies.Count)
        {
            i = 0;
        }

        if (enemies.Count == 0)
        {
            FastestEnemie = enemies[i];
        }

        if (enemies.Count > 1)
        {
            if (enemies[i].GetComponent<AiController>().Leeftijd > FastestEnemie.GetComponent<AiController>().Leeftijd)
            {
                FastestEnemie = enemies[0];
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            enemies.Add(other.gameObject);
            other.gameObject.GetComponent<AiController>().enemychecker.Add(gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            enemies.Remove(other.gameObject);
            other.gameObject.GetComponent<AiController>().enemychecker.Remove(gameObject);
            if (FastestEnemie == other.gameObject)
            {
                FastestEnemie = enemies[0];
            }
        }
    }

}