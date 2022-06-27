using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using MelonLoader;
using System.Collections;
using Arctic.Wrappers;
namespace Arctic.settings.MonoBehaviours
{
    class Targettouch : MonoBehaviour
    {
        public static bool waitforcooldown3 = true;


        public Targettouch(IntPtr ptr) : base(ptr)
        {
        }

        void OnTriggerEnter(Collider col)
        {

            if (col.name.Contains("VRCPlayer[Remote]") && waitforcooldown3)
            {
                waitforcooldown3 = false;
                Target.targetuser(col.GetComponent<VRC.Player>().field_Private_APIUser_0.id);
                MelonCoroutines.Start(Monobehaviours_corotines.waitfortimer33());

            }

        }





    }
}
