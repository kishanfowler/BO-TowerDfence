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
    private float startTime;
    private GeldScript shopsystem;
    private int playerHealth = 150;
    private Slider PlayerSlider;
    public Slider HpSlider;
    bool alive = true;
    [SerializeField] private int waarde = 5;


    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        PlayerSlider = GameObject.Find("playerhealth").GetComponent<Slider>();
        shopsystem = GameObject.Find("geldText").GetComponent<GeldScript>();
    }

    // Update is called once per frame
    void Update()
    {
        walking();
        HpSlider.value = Health;
        Leeftijd = Time.time - startTime;
        if (Health <= 0 && alive)
        {
            EnemyDead();
        }
    }
    private void EnemyDead()
    {
        alive = false;
        transform.position = new Vector3(500, 0, 500);
        Destroy(gameObject, 0.5f);
        shopsystem.geld = shopsystem.geld + waarde;
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
