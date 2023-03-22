using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AtlastMision
{
    [CreateAssetMenu(fileName ="Game Data", menuName = "AtlasMission/GameData")]
    public class GameData : ScriptableObject
    {
        [Header("Player Configurations")]
        public float playerSpeed;
        public float playerRotationSpeed;
        public float playerCurrentHealth;
        public float playerTotalHealth;
        public int count;
        public Vector3 cameraOffset;

        [Header("Projectile Configurations")]
        public float projectileRange;
        public float projectileSpeed;
        public float projectilePool;

        [Header("Asteroid Configuration")]
        public float asteroidScreenSpawnRange;
        public float asteroidSpawnRate;
        public float asteroidSpeed;
        [Range(0,5)] public float asteroidLife;
        public int asteroidHalfLife;
        public float asteroidDamage;

        [Header("Powerup configuration")]
        public float powerUpSpawnRate;
        public float powerupSpawnDistanceToPlayer;
        public float powerupMaxSpawn;
        public List<PowerUpCollectible> powerUpCollectibles;

        [Header("Difficulty")]
        [Range(1,10)] public int difficulty;
        [Range(3,20)]public float difficultyProgressionRate;

        public void ResetValues(){
            count = 0;
            playerCurrentHealth = playerTotalHealth;
            difficulty = 1;
        }
    }
}
