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
    class sitonpickups : MonoBehaviour
    {
        public static bool sitonobj = true;

        public static bool waitforcooldown2 = true;
        public static Collision collisionobj;

        public sitonpickups(IntPtr ptr) : base(ptr)
        {
        }

        void OnCollisionEnter(Collision col)
        {
            if (sitonobj && waitforcooldown2 == true && col.gameObject.GetComponent<VRC.SDKBase.VRC_Pickup>() == true)
            {
                waitforcooldown2 = false;
                collisionobj = col;
                MelonCoroutines.Start(Monobehaviours_corotines.sitonobj(collisionobj));
                MelonCoroutines.Start(Monobehaviours_corotines.waitfortimer22());
            }

        }





    }
}
