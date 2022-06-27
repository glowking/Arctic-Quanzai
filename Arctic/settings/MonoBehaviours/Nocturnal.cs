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
  
    public class TargetedPlayer : MonoBehaviour
    {
        public VRC.Player targetuser;

        public TargetedPlayer(IntPtr ptr) : base(ptr)
        {
        }

    }
}
