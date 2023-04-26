using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private Enemy[] enemies;
    [SerializeField] private Transform parent;

    int spawnMax = 10;
    int spawnCnt = 0;

    private void Start()
    {
        StartCoroutine("Spawn");
    }

    public IEnumerator Spawn()
    {
        for (int i = 0; i < spawnMax; i++)
        {
            Instantiate(enemies[0], parent);
            yield return new WaitForSeconds(3f);
        }
    }

}
