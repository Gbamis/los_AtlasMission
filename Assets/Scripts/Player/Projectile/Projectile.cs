using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AtlastMision
{
    [RequireComponent(typeof(Rigidbody))]
    public class Projectile : MonoBehaviour
    {
        private Rigidbody rb;

        private void Awake(){
            rb = GetComponent<Rigidbody>();
        }

        private void OnEnable(){
            
        }
        private IEnumerator Disable(float range)
        {
            yield return new WaitForSeconds(range);
            ProjectilePool.Instance.ReturnProjectile(this);
            rb.velocity = Vector3.zero;
        }
        public void Fire(Vector3 dir, float range){
            rb.AddForce(dir * GameProcessor.Instance.gameData.projectileSpeed);
            StartCoroutine(Disable(range));
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Projectile"))
            {
                ProjectilePool.Instance.ReturnProjectile(this);
            }
        }
    }
}
