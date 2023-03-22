using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AtlastMision
{
    public class BarrierBehaviour : MonoBehaviour
    {
        public void OnCollisionEnter(Collision other)
        {
            if (other.collider.CompareTag("Asteroid"))
            {
                gameObject.SetActive(false);
                other.gameObject.GetComponent<Asteroid>().CreateHalf();
                GameProcessor.Instance.PowerUpUsed();
            }
            
        }
    }
}
