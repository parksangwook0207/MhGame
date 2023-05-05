using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    // 적 스폰 스크립트
    [SerializeField] private Enemy[] enemies;
    [SerializeField] private Transform parent;

    [SerializeField] private BoxCollider spawnBox;
    [SerializeField] private Sun sun;

    int spawnCnt = 0;
    int spawnMax = 10;

    bool isSpawn = false;

    private void Start()
    {
        
    }

    private void Update()
    {
        // 태양(라이트) 각도에 따라 생성
        float x = sun.transform.eulerAngles.x;
        if (!isSpawn &&( x > 55 && x < 60))
        {
            isSpawn = true;
            StartCoroutine("Spawn");
        }
    }

    public IEnumerator Spawn()
    {
        for (int i = 0; i < spawnMax; i++)
        {
            Enemy e = Instantiate(enemies[0], parent);
            e.transform.localPosition = RandomPosition();
            yield return new WaitForSeconds(2f);
        }
        isSpawn = false;
    }

    // 스폰포탈에서 스폰되는 위치가 랜덤으로 생성
    Vector3 RandomPosition()
    {
        Vector3 originPos = spawnBox.transform.localPosition;

        Bounds b = spawnBox.bounds;
        Vector2 size = new Vector2(b.size.x, b.size.z);

        size.x = Random.Range((size.x / 2) * -1, size.x / 2);
        size.y = Random.Range((size.y / 2) * -1, size.y / 2);

        return originPos + new Vector3(size.x,0f,size.y);

    }

}
