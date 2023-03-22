using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AtlastMision
{
    public class Asteroid : MonoBehaviour
    {

        private Rigidbody rb;
        public int halves;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void OnEnable()
        {
            Vector3 playerPos = GameProcessor.Instance.player.position;
            Vector3 pos = transform.position;
            Vector3 dir = playerPos - pos;
            rb.AddForce(dir * GameProcessor.Instance.gameData.asteroidSpeed);

            Destroy(gameObject, GameProcessor.Instance.gameData.asteroidLife);
        }
        public void CreateHalf()
        {
            Vector3 scale = transform.localScale;
            Vector3 halfScale = scale / 2;
            if (halves < GameProcessor.Instance.gameData.asteroidHalfLife)
            {
                transform.localScale = halfScale;
                halves += 1;
                AsteroidManager.Instance.SpawnHalf(transform.position, halfScale, halves);
            }
            else
            {
                Destroy(gameObject);
                GameProcessor.Instance.gameData.count += 1;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Projectile"))
            {
                CreateHalf();
            }
        }
    }
}
