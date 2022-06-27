using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using MelonLoader;
using VRC.SDKBase;
using VRC.Core;
using System.Collections;
using Arctic.Wrappers;
namespace Arctic.settings.MonoBehaviours
{
    class Normalboom : MonoBehaviour
    {
        private static bool onetime = false;
        public Normalboom(IntPtr ptr) : base(ptr)
        {
        }

        void OnCollisionEnter(Collision col)
        {
            if (!col.gameObject.name.Contains("VRCPlayer[Local]") && onetime)
            {
                var items = UnityEngine.Object.FindObjectsOfType<VRC_Pickup>();
                for (var i = 0; i < items.Count; i++)
                {
                    Networking.SetOwner(Extentions.LocalPlayer.prop_VRCPlayerApi_0, items[i].gameObject);
                    items[i].gameObject.transform.position = gameObject.transform.position;
                }
                onetime = false;
                GameObject.Destroy(gameObject);
            }

        }

        void LateUpdate()
        {
            if (gameObject.GetComponent<VRC.SDK3.Components.VRCPickup>().currentPlayer != null)
            {
                onetime = true;
            }

        }





    }

}

