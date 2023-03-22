using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AtlastMision
{
    public class SpaceShip : Player
    {
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Asteroid"))
            {
                if (GameProcessor.Instance.gameData.playerCurrentHealth > 0)
                {
                    TakeDamage();
                }
                else
                {
                    GameProcessor.Instance.GameOver();
                }
            }
            if(other.CompareTag("Powerup")){
                other.GetComponent<PowerUp>().UsePowerUp();
            }
        }
        private void TakeDamage()
        {
            GameProcessor.Instance.gameData.playerCurrentHealth -= GameProcessor.Instance.gameData.asteroidDamage;
        }
    }
}
