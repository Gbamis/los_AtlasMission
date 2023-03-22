using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AtlastMision
{
    public class IGroupInterfaces : MonoBehaviour
    {

    }
    public interface IWeapon
    {
        void Fire();
    }

    public interface IBarrier
    {
        void TakeCover();
    }
}
