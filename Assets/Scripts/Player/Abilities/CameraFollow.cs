using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AtlastMision
{
    public class CameraFollow :Ability
    {
        public Transform camera;
        public override void OnUpdateRunAbility()
        {
            TrackSelf();
        }

        private void TrackSelf(){
            Vector3 self = transform.position;
            Vector3 cam = camera.position;

            camera.position = self + GameProcessor.Instance.gameData.cameraOffset;
        }
    }

}