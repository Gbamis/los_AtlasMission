using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AtlastMision
{
    public class AsteroidManager : MonoBehaviour
    {
        private static AsteroidManager m_instance;
        public static AsteroidManager Instance
        {
            set
            {
                m_instance = value;
            }
            get
            {
                return m_instance;
            }
        }

        public GameObject asteroidPrefab;
        private float nextRate;
        private float difficultyNextRate;


        private void Awake()
        {
            Instance = this;
        }


        private void Update()
        {
            if (GameProcessor.Instance.isGameRunning)
            {
                if(Time.time > difficultyNextRate ){
                    //GameProcessor.Instance.gameData.difficulty +=1;
                    difficultyNextRate = Time.time + GameProcessor.Instance.gameData.difficultyProgressionRate;
                }
                if (Time.time > nextRate)
                {
                    Spawn();
                    nextRate = Time.time + GameProcessor.Instance.gameData.asteroidSpawnRate;
                }
            }

        }
        private void Spawn()
        {
            float spawnCount = GameProcessor.Instance.gameData.difficulty;
            for (int i = 0; i < spawnCount; i++)
            {
                GameObject clone = Instantiate(asteroidPrefab);
                clone.transform.parent = transform;
                Vector3 randPos = GameProcessor.Instance.player.transform.position;
                float range = GameProcessor.Instance.gameData.asteroidScreenSpawnRange;
                float x = Random.Range(-range, range);
                float z = Random.Range(-range, range);
                Vector3 pos = new Vector3(randPos.x + x, randPos.y, randPos.z + z);

                clone.transform.position = pos;
                clone.SetActive(true);
            }

        }
        public void SpawnHalf(Vector3 pos, Vector3 scale, int half)
        {
            GameObject clone = Instantiate(asteroidPrefab);
            clone.transform.parent = transform;
            clone.transform.localScale = scale;
            clone.transform.position = pos;
            clone.GetComponent<Asteroid>().halves = half;
            clone.SetActive(true);
            Debug.Log("spawed" + half);
        }
    }
}
