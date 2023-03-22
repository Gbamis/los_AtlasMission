using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AtlastMision
{
    public class MovementAbility : Ability
    {
        private float forward;
        private float rotate;

        public override void OnUpdateRunAbility()
        {  
            forward = Input.GetAxis("Vertical");
            rotate = Input.GetAxis("Horizontal");

            Move();
            Rotate();
        }
        private void Move(){
            transform.Translate(Vector3.forward * forward * GameProcessor.Instance.gameData.playerSpeed * Time.deltaTime);
        }
        private void Rotate(){
            transform.Rotate(transform.up * rotate * GameProcessor.Instance.gameData.playerRotationSpeed * Time.deltaTime);
        }
    }
}
