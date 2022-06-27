using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using MelonLoader;
using System.Collections;
namespace Arctic.settings.MonoBehaviours
{
    class explode : MonoBehaviour
    {
        public static GameObject playervec3;
        public explode(IntPtr ptr) : base(ptr)
        {
        }

        void OnTriggerEnter(Collider col)
        {
            if (col.gameObject.name.Contains("VRCPlayer[Remote]"))
            {

                Exploits.Orbit.isexploding = true;
                playervec3 = col.gameObject;
            }

        }




    }
}
