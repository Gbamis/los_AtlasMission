using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AtlastMision
{
    [CreateAssetMenu(fileName = "BlasterWeapon", menuName = "AtlasMission/PowerUp/Weapon/Blaster")]
    public class BlasterPU : PowerUpCollectible, IWeapon
    {
        public int burstAmount;
        public float burstAngle;
        [SerializeField] private GameObject sceneObject;
        public float projectileRange;
        public float firingRate;
        private float nextRate;
        public float firingDuration;
        private float firingDurationRate;

        public override void Spawned()
        {
            nextRate = 0;
        }
        public override void Use()
        {
            Transform nuzz = GameProcessor.Instance.nuzzle;
            Fire();
            Dsiable();
        }

        private void Dsiable()
        {
            firingDurationRate +=Time.deltaTime;
            if(firingDurationRate > firingDuration){
                firingDurationRate = 0;
                GameProcessor.Instance.PowerUpUsed();
            }
        }

        public void Fire()
        {
            if (Time.time > nextRate)
            {
                nextRate = firingRate + Time.time;
                Transform nuzzle = GameProcessor.Instance.nuzzle;
                List<GameObject> projectiles = ProjectilePool.Instance.GetProjectile(sceneObject,burstAmount);
                float lastAngle = -burstAngle;
                foreach (GameObject projectile in projectiles)
                {
                    projectile.transform.position = nuzzle.position;
                    Vector3 rot = GameProcessor.Instance.player.rotation.eulerAngles;
                    rot.y += lastAngle;
                    projectile.transform.rotation = Quaternion.Euler(rot);
                    projectile.SetActive(true);
                    projectile.GetComponent<Projectile>().Fire(projectile.transform.forward, projectileRange);
                    lastAngle += burstAngle;

                     Destroy(projectile,projectileRange);
                }

            }
        }

    }

}