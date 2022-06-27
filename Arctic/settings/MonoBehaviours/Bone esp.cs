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
    class bonesp : MonoBehaviour
    {
        public static GameObject playervec3;
        public bonesp(IntPtr ptr) : base(ptr)
        {
        }
        private LineRenderer acl;
        private Animator anima;

        void Start()
        {
            var negmj = new GameObject();
            negmj.name = "espline";
            negmj.layer = 19;
            negmj.transform.parent = gameObject.transform;
            UnityEngine.Color overallcolor = UnityEngine.Color.white;
            acl = negmj.AddComponent<LineRenderer>();
            acl.startWidth = 0.001f;
            acl.endWidth = 0.001f;
            acl.positionCount = 19;
            acl.startColor = UnityEngine.Color.white;
            acl.endColor = UnityEngine.Color.white;
            acl.useWorldSpace = true;
            var materials = acl.material = new Material(Shader.Find("Standard"));
            materials.EnableKeyword("_EMISSION");
            materials.SetColor("_EmissionColor", overallcolor);
            InvokeRepeating("Updatelines", 0.0f, 0.025f);
            anima = this.GetComponent<VRCPlayer>().field_Internal_Animator_0;

        }

        void Updatelines()
        {
            if (anima == null)
                anima = this.GetComponent<VRCPlayer>().field_Internal_Animator_0;


            try
            {
                acl.SetPosition(0, anima.GetBoneTransform(HumanBodyBones.Head).transform.position);
                acl.SetPosition(1, anima.GetBoneTransform(HumanBodyBones.Neck).transform.position);
                acl.SetPosition(2, anima.GetBoneTransform(HumanBodyBones.Chest).transform.position);
                acl.SetPosition(3, anima.GetBoneTransform(HumanBodyBones.RightShoulder).transform.position);
                acl.SetPosition(4, anima.GetBoneTransform(HumanBodyBones.RightUpperArm).transform.position);
                acl.SetPosition(5, anima.GetBoneTransform(HumanBodyBones.RightLowerArm).transform.position);
                acl.SetPosition(6, anima.GetBoneTransform(HumanBodyBones.RightHand).transform.position);
                acl.SetPosition(7, anima.GetBoneTransform(HumanBodyBones.LeftShoulder).transform.position);
                acl.SetPosition(8, anima.GetBoneTransform(HumanBodyBones.LeftUpperArm).transform.position);
                acl.SetPosition(9, anima.GetBoneTransform(HumanBodyBones.LeftLowerArm).transform.position);
                acl.SetPosition(10, anima.GetBoneTransform(HumanBodyBones.LeftHand).transform.position);
                acl.SetPosition(11, anima.GetBoneTransform(HumanBodyBones.Spine).transform.position);
                acl.SetPosition(12, anima.GetBoneTransform(HumanBodyBones.Hips).transform.position);
                acl.SetPosition(13, anima.GetBoneTransform(HumanBodyBones.LeftUpperLeg).transform.position);
                acl.SetPosition(14, anima.GetBoneTransform(HumanBodyBones.LeftLowerLeg).transform.position);
                acl.SetPosition(15, anima.GetBoneTransform(HumanBodyBones.LeftFoot).transform.position);
                acl.SetPosition(16, anima.GetBoneTransform(HumanBodyBones.RightUpperLeg).transform.position);
                acl.SetPosition(17, anima.GetBoneTransform(HumanBodyBones.RightLowerLeg).transform.position);
                acl.SetPosition(18, anima.GetBoneTransform(HumanBodyBones.RightFoot).transform.position);
            }
            catch { }
               

          
          

        }



    }
}
