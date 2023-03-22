using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AtlastMision
{

    public class ProjectilePool : MonoBehaviour
    {
        private static ProjectilePool m_instance;
        public static ProjectilePool Instance
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

        [SerializeField] private GameObject bulletPrefab;

        private void Awake()
        {
            Instance = this;

        }
        private void Start()
        {
            //CreatePool();
        }

        private void CreatePool()
        {
            for (int i = 0; i < GameProcessor.Instance.gameData.projectilePool; i++)
            {
                GameObject clone = Instantiate(bulletPrefab);
                clone.transform.parent = transform;
                clone.SetActive(false);
            }
        }

        public List<GameObject> GetProjectile(int count)
        {
            List<GameObject> projectiles = new List<GameObject>();
            foreach (Transform bullet in transform)
            {
                if (!bullet.gameObject.activeSelf)
                {
                    projectiles.Add(bullet.gameObject);
                }
                if(projectiles.Count ==count){
                    break;
                }
            }

            return projectiles;
        }
        public List<GameObject> GetProjectile(GameObject prefab,int count)
        {
            List<GameObject> projectiles = new List<GameObject>();
            for(int i=0; i < count; i++){
                GameObject clone = Instantiate(prefab);
                projectiles.Add(clone);
            }

            return projectiles;
        }
        public void ReturnProjectile(Projectile projectile)
        {
            projectile.gameObject.SetActive(false);
        }
    }
}
