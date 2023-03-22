using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AtlastMision
{
    [CreateAssetMenu(fileName = "Barrier", menuName = "AtlasMission/PowerUp/Barrier")]
    public class BarrierPU : PowerUpCollectible, IBarrier
    {
        public float usageTime;
        public GameObject sceneObject;
        public GameObject prefab;
        private bool spawned;


        public override void Spawned()
        {
            if (sceneObject == null)
            {
                sceneObject = Instantiate(prefab);
                sceneObject.SetActive(false);
                sceneObject.AddComponent<BarrierBehaviour>();
                spawned = true;
            }
        }
        public override void Despawned()
        {
            if (sceneObject != null)
            {
                sceneObject.SetActive(false);
            }
        }
        public override void Use()
        {
            TakeCover();
            sceneObject.SetActive(true);
            sceneObject.transform.position = GameProcessor.Instance.player.position;
        }

        public void TakeCover()
        {
            sceneObject.SetActive(true);
        }
    }
}
