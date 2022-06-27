using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using MelonLoader;
using System.Collections;
using VRC;
using Arctic.Wrappers;

namespace Arctic.settings.MonoBehaviours
{
    class Lineupdator : MonoBehaviour
    {
        public static int RENDERVALUE = 4;
        public Lineupdator(IntPtr ptr) : base(ptr)
        {
        }
     

        void Start()
        {
            

        }

        void Updatelines()
        {
            if (!nconfig.pointlines) return;

          




        }



    }
}
