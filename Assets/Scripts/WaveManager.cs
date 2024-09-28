using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer.Internal;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    int curWave = 1;

    Wave[] waves;

    float nextWave;

    public Transform player;
    public Transform spawnPoint;
    public List<EnemyAI> enemies = new List<EnemyAI>();

    public float winDelay;

    // Start is called before the first frame update
    void Start()
    {
        waves = GetComponentsInChildren<Wave>();
        nextWave = waves[0].InitializeWave();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextWave)
        {
            if (curWave < waves.Length)
            {
                nextWave = Time.time + waves[curWave].InitializeWave();
                curWave++;
            }
            else
            {
                if (enemies.Count == 0)
                {
                    //VICTORY
                    Invoke("VictoryScreen", winDelay);
                    this.enabled = false;
                }
            }
        }
    }

    public void VictoryScreen()
    {

    }
}