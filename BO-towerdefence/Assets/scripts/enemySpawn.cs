using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public EnemyChecker enemycheck;
    public int i = 0;
    public float wavetussenTijd;
    public int WaveNeeded = 1;
    public List<GameObject> WaveInhoud = new List<GameObject>();

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
        float tijd = wavetussenTijd;
        yield return new WaitForSeconds(TimeInteraction);
        if (WaveNeeded == 1 && i < WaveInhoud.Count)
        {
            GameObject Enemy = Instantiate(WaveInhoud[i], transform.position, transform.rotation);
            i += 1;
            StartCoroutine(spawn(tijd));
        }
    }
}
