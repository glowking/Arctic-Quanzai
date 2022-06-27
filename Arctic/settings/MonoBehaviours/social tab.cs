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
    class Social : MonoBehaviour
    {
        public static GameObject playervec3;
        public Social(IntPtr ptr) : base(ptr)
        {
        }

        void OnEnable()
        {
            this.transform.Find("Vertical Scroll View/Viewport/Content/OnlineFriends/Button/TitleText").gameObject.GetComponent<UnityEngine.UI.Text>().text = $"Online Friends - [{Style.Uichanges.friendsonline}]";
            this.transform.Find("Vertical Scroll View/Viewport/Content/InRoom/Button/TitleText").gameObject.GetComponent<UnityEngine.UI.Text>().text = $"In Room - [{RoomManager.field_Internal_Static_ApiWorld_0.name}] - [{Style.Uichanges.playerinlobby}] ";

        }

    }
}
