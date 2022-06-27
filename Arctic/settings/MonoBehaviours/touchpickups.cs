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
    class touchpickups : MonoBehaviour
    {
        public static bool waitforcooldown = true;
        public static bool touchpickupstog = false;
        public touchpickups(IntPtr ptr) : base(ptr)
        {
        }

        void OnCollisionEnter(Collision col)
        {
            try
            {
                if (col.gameObject.GetComponent<VRC.SDKBase.VRC_Pickup>() == true && waitforcooldown)
                {
                    waitforcooldown = false;
                    MelonCoroutines.Start(Monobehaviours_corotines.runaftergrav(col.gameObject.GetComponent<Rigidbody>()));
                    MelonCoroutines.Start(Monobehaviours_corotines.waitfortimer1());
                }
            }
            catch
            {
                Style.Consoles.consolelogger("Failed");
            }

        }





    }
}
