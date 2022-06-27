using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using MelonLoader;
using System.Collections;
using VRC.SDKBase;
using VRC.Udon;
using VRC.Udon.Common.Interfaces;


namespace Arctic.settings.MonoBehaviours
{
    class touchstuff : MonoBehaviour
    {
        public static bool cooldown = false;
        public static string actionforontap;
        public touchstuff(IntPtr ptr) : base(ptr)
        {
        }
        void Start()
        {

        }
        void OnTriggerEnter(Collider col)
        {

            if (col.name.Contains("VRCPlayer[Remote]") && actionforontap != string.Empty)
            {
                if (!cooldown)
                {
                    cooldown = true;
                    try
                    {
                        Style.Consoles.consolelogger(col.gameObject.GetComponent<VRC.Player>().field_Private_APIUser_0.displayName + " - " + actionforontap);
                        var user = col.gameObject.GetComponent<VRCPlayer>();
                        if (RoomManager.field_Internal_Static_ApiWorld_0.id == Arctic.Wrappers.Extentions.murder)
                        {
                            var getphoton = user.GetComponent<VRCPlayer>()._player;

                            var Nodes = GameObject.Find("Player Nodes");
                            foreach (var obj in Nodes.GetComponentsInChildren<UdonBehaviour>())
                            {
                                Networking.SetOwner(getphoton.field_Private_VRCPlayerApi_0, obj.gameObject);
                                obj.SendCustomNetworkEvent(NetworkEventTarget.Owner, actionforontap);
                            }
                        }
                    }
                    catch
                    {

                    }
                    MelonCoroutines.Start(Monobehaviours_corotines.waitfortimer());
                }



            }
        }



    }
}
