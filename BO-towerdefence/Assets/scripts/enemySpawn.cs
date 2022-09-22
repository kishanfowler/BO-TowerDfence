using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public EnemyChecker enemycheck;
    public int i = 0;
    public int wavetussenTijd = 10;
    public int WaveNeeded = 1;
    public List<GameObject> WaveInhoud = new List<GameObject>();
    public List<GameObject> ingespawned = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawn(1));
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator spawn(float TimeInteraction)
    {
        int tijd = 1;
        if (WaveNeeded == 1)
        {
            i = 0;
            WaveNeeded++;
            tijd = wavetussenTijd;
        }

        yield return new WaitForSeconds(TimeInteraction);
        if (WaveNeeded == 1)
        {
            GameObject Enemy = Instantiate(WaveInhoud[i], transform.position, transform.rotation);
            i += 1;
        }

        if (WaveNeeded == 2)
        {
            WaveNeeded = 1;
            i = 0;
            StartCoroutine(spawn(wavetussenTijd));
        }

        if (WaveNeeded == 1)
        {
            StartCoroutine(spawn(tijd));
        }
    }
}
