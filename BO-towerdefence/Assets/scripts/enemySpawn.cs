using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public EnemyChecker enemycheck;
    public float starttijd;
    public float wavetussenTijd;
    private Waves waves;
    [SerializeField] int wave = 0;
    public Waves[] Waveslist;
    // Start is called before the first frame update
    void Start()
    {
        wave = 0;
    }

    // Update is called once per frame
    void Update()
    {
        starttijd -= Time.deltaTime;
        if (starttijd <= 0)
        {
            wavetussenTijd -= Time.deltaTime;
            if (wavetussenTijd <= 0 && wave < Waveslist.Length)
            {
                waves = Waveslist[wave];
                StartCoroutine(wavestart());
                wave++;
                starttijd = 5;
            }
        }
    }
        
    IEnumerator wavestart()
    {
        for (int i = 0; i < waves.waveEnemies.Length; i++)
        {
            for (int e = 0; e <= waves.waveAmounts[i]; e++)
            {
                Instantiate(waves.waveEnemies[i], transform.position, Quaternion.identity);
                yield return new WaitForSeconds(1f);
            }
            Debug.Log("part done");
        }
        Debug.Log("wave done");
    }
}

