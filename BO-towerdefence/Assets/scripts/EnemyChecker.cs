using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChecker : MonoBehaviour
{
    public List<GameObject> enemies = new List<GameObject>();
    private TorenAI ai;
    // Start is called before the first frame update
    void Start()
    {
        ai = transform.GetComponent<TorenAI>();
    }
    // Update is called once per frame
    void Update()
    {
        ai.target = enemies[0].transform;
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("enemy collision with trigger");
        if (other.gameObject.tag == "Enemy")
        {

            enemies.Add(other.gameObject);

            Debug.Log("enemies" + enemies);
            ai.target = enemies[0].transform;
        }

      

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            enemies.Remove(other.gameObject);
        }
    }

}