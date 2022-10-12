using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public EnemyChecker enemycheck;
    public int starttijd;
    public float wavetussenTijd;
    public List<GameObject> WaveInhoud = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        spawn(wavetussenTijd);
    }

    void spawn(float tijd)
    {
        for (int i = 0; i < WaveInhoud.Count;)
        {
            tijd -= Time.deltaTime;
            if(tijd == 0)
            {
                GameObject Enemy = Instantiate(WaveInhoud[i], transform.position, transform.rotation);
                i++;
            }
            
        }
    }
}
