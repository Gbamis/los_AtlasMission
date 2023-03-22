using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AtlastMision
{
    public class PowerupAbility : Ability
    {
        public PowerUpCollectible currentPowerUp;
        private PowerUpCollectible baseWeapon;

        public override void OnStartAbility(){
            currentPowerUp.Spawned();
            GameProcessor.Instance.OnPowerUpUsed +=PowerUpUsed;
            baseWeapon = currentPowerUp;
        }

        public override void OnUpdateRunAbility()
        {
            currentPowerUp.Use(); 
        }

        private void PowerUpUsed(){
            currentPowerUp = baseWeapon;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Powerup"))
            {
                PowerUp powerUp = other.GetComponent<PowerUp>();
                powerUp.UsePowerUp();
                currentPowerUp.Despawned();
                currentPowerUp = powerUp.powerUpCollectible;
            }
        }
    }
}
