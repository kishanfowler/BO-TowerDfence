using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class AiController : MonoBehaviour
{
    public int movespeed;
    public int Health;
    public float Leeftijd = 0;
    public List<GameObject> enemychecker = new List<GameObject> { };
    private float startTime;
    public ShopSystem shopsystem;
    private int playerHealth = 150;
    public Slider PlayerSlider;
    public Slider HpSlider;


    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        walking();
        HpSlider.value = Health;
        Leeftijd = Time.time - startTime;
        if (Health <= 0)
        {
            EnemyDead();
        }
    }
    private void EnemyDead()
    {
        shopsystem.geld += Health;
        transform.position = new Vector3(500, 0, 500);
        Destroy(gameObject, 0.5f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "waypoint")
        {
            transform.rotation = collision.transform.rotation;
        }

        if (collision.transform.tag == "destroyer")
        {
            Destroy(gameObject);
            playerHealth -= Health;
            PlayerSlider.value = playerHealth;
        }
    }
    private void walking() =>  transform.position += transform.forward * Time.deltaTime *movespeed;
    
}
