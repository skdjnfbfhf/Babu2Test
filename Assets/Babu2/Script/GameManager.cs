using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Babu2Test
{
    public class GameManager : MonoBehaviour
    {
        public GameObject[] Enemys;
        public Vector3 spawnValue;
        public int enemyCount;

        public float spawnWait;
        public float startWait;
        public float waveWait;

        public float itemPer = new float[3];

        public List<GameObject> listEnemys = new List<GameObject>();

        public int CreateItem()
        {
            int per = Random.Range(0, 100);

            if (per < itemPer[2])
            {
                return -1;
            }
            else if (per < itemPer[1])
            {
                return 2;
            }
            else if (per < itemPer[0])
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        private void Start()
        {
            StartCoroutine(SpawnWaves());
        }

        IEnumerator SpawnEnemy()
        {
            yield return new WaitForSeconds(startWait);
            while (true)
            {
                GameObject enemy = Enemys[Random.Range(0, Enemeys.Length)];
                Vector3 spawnPosition = new Vector3(
                    Random.Range(-spwanValue.x, spawnValue.x),
                    spawnValue.y, spawnValue.z);
                listEnemys.Add(Instantiate(enemy, spawnPositon, enemy, transform.roatation));
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }


    }
}
