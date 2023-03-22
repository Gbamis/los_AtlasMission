using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AtlastMision
{
    public abstract class Ability : MonoBehaviour
    {
        public virtual void OnStartAbility(){}
        public abstract void OnUpdateRunAbility();
    }
}
