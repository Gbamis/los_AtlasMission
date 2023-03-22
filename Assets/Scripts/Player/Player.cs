using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace AtlastMision
{
    public abstract class Player : MonoBehaviour
    {
        [SerializeField] public List<Ability> abilities;

        private void Start()
        {
            abilities = GetComponentsInChildren<Ability>().ToList();
            foreach (Ability ab in abilities)
            {
                ab.OnStartAbility();
            }
        }

        private void Update()
        {
            if (GameProcessor.Instance.isGameRunning)
            {
                foreach (Ability ab in abilities)
                {
                    ab.OnUpdateRunAbility();
                }
            }
            bool input = (Input.GetKey(KeyCode.Space) || Input.GetAxis("Vertical")!=0 || Input.GetAxis("Horizontal")!=0 );

            if (input)
            {
                if (!GameProcessor.Instance.isGameRunning)
                {
                    GameProcessor.Instance.PlayGame();
                }

            }

        }
    }
}
