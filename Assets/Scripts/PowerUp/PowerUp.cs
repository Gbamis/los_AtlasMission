using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AtlastMision
{
    public class PowerUp : MonoBehaviour
    {
        public SpriteRenderer iconUI;
        public PowerUpCollectible powerUpCollectible;

        public void Spawned(PowerUpCollectible collectible){
            powerUpCollectible = collectible;
            iconUI.sprite = collectible.icon;
            gameObject.SetActive(true);
            powerUpCollectible.Spawned();
        }

        public void UsePowerUp(){
            powerUpCollectible.ApplyEffect();
            powerUpCollectible.Use();
            gameObject.SetActive(false);
        }
    }

    public class PowerUpCollectible : ScriptableObject
    {
        public Sprite icon;
        public GameObject vfx;

        public virtual void Spawned(){}
        public virtual void ApplyEffect(){}
        public virtual void Use(){}
        public virtual void Despawned(){}
    }
}
