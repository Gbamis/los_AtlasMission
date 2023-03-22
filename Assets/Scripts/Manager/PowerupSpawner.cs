using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AtlastMision
{
    public class PowerupSpawner : MonoBehaviour
    {
        private static PowerupSpawner m_instance;
        public static PowerupSpawner Instance
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

        public PowerUp powerUpPrefab;
        private float nextRate;

        private void Awake()
        {
            Instance = this;
        }

        private void Update()
        {
            float level = GameProcessor.Instance.gameData.powerUpSpawnRate;
            if (Time.time > nextRate && GameProcessor.Instance.isGameRunning)
            {
                SpawnPowerUp();
                nextRate = Time.time + level;
            }
        }

        private void SpawnPowerUp()
        {
            float range = GameProcessor.Instance.gameData.powerupSpawnDistanceToPlayer;
            float x = Random.Range(-range, range);
            float z = Random.Range(-range, range);
            Vector3 randPos = GameProcessor.Instance.player.transform.position;
            Vector3 pos = new Vector3(randPos.x + x, randPos.y, randPos.z + z);
            int randIndex = Random.Range(0,GameProcessor.Instance.gameData.powerUpCollectibles.Count);
            PowerUpCollectible collectible = GameProcessor.Instance.gameData.powerUpCollectibles[randIndex];

            if (transform.childCount == GameProcessor.Instance.gameData.powerupMaxSpawn)
            {
                foreach (Transform child in transform)
                {
                    if (!child.gameObject.activeSelf)
                    {
                        child.gameObject.SetActive(true);
                        child.position = pos;
                        child.GetComponent<PowerUp>().Spawned(collectible);
                        break;
                    }
                }
            }
            else
            {
                GameObject clone = Instantiate(powerUpPrefab.gameObject);
                clone.transform.parent = transform;
                clone.transform.position = pos;
                clone.GetComponent<PowerUp>().Spawned(collectible);
            }

        }
    }
}
