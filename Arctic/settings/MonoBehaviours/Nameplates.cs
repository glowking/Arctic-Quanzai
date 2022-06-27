using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using MelonLoader;
using VRC.Core;
using System.Collections;


namespace Arctic.settings.MonoBehaviours
{
    public class Nameplates : MonoBehaviour
    {
        public Nameplates(IntPtr ptr) : base(ptr)
        {

        }
        private static VRC.Player vrcpl;

        void Start()
        {
            var getvrcplayer = GetComponent<VRCPlayer>();
            var gmj = GetComponent<VRC.Player>();
            vrcpl = GetComponent<VRC.Player>();
            string rank = "";
            Color colr = Color.white;
            Wrappers.check_ranks.gettrsutrank(gmj.field_Private_APIUser_0, ref rank, ref colr);

            GameObject Plates = new GameObject();
            Plates.name = "Platesmanager";
            Plates.AddComponent<UnityEngine.UI.GridLayoutGroup>();
            var txticon = getvrcplayer.field_Public_PlayerNameplate_0.field_Public_GameObject_5.transform;
            Plates.transform.parent = getvrcplayer.field_Public_PlayerNameplate_0.field_Public_GameObject_3.transform;
            Plates.transform.localPosition = new Vector3(0, 105, 0);
            Plates.transform.localScale = new Vector3(1, 1, 1);
            Plates.transform.rotation = new Quaternion(0, 0, 0, 0);
            Plates.GetComponent<RectTransform>().sizeDelta = new Vector2(100, 150);
            var vert = Plates.GetComponent<UnityEngine.UI.GridLayoutGroup>();
            vert.constraint = UnityEngine.UI.GridLayoutGroup.Constraint.FixedColumnCount;
            vert.constraintCount = 1;
            vert.childAlignment = TextAnchor.LowerCenter;
            vert.cellSize = new Vector2(100, 30);
        
            var newobj = new GameObject();
            newobj.transform.parent = txticon.parent.Find("Main").transform.Find("Platesmanager").transform;
            newobj.transform.localPosition = Vector3.zero;
            newobj.transform.localScale = Vector3.one;
            newobj.transform.rotation = new Quaternion(0, 0, 0, 0);
            newobj.name = "Platemanagertext";
            newobj.AddComponent<UnityEngine.UI.LayoutElement>();
           var Mainicon = GameObject.Instantiate(txticon, txticon.parent.Find("Main").transform.Find("Platesmanager/Platemanagertext").transform);
            Mainicon.gameObject.SetActive(true);
            GameObject.Destroy(Mainicon.transform.Find("Trust Icon").gameObject);
            GameObject.Destroy(Mainicon.transform.Find("Trust Text").gameObject);
            GameObject.Destroy(Mainicon.transform.Find("Performance Icon").gameObject);
            var text1 = Mainicon.transform.Find("Performance Text").gameObject.GetComponent<TMPro.TextMeshProUGUI>();
            Mainicon.name = "Userperfplate";
            text1.color = Color.white;
            text1.text = $"Ping-Loading Fps-Loading";

            if (!nconfig.Nameplates)
            {
                Mainicon.gameObject.SetActive(false);
            }
            foreach (var getuser in Main.load.userlist)
            {

                if (getuser.Id == vrcpl.field_Private_APIUser_0.id && getuser.Trustrank != 0)
                {
                    var getplate = getvrcplayer.field_Public_PlayerNameplate_0.field_Public_GameObject_3.transform.Find("Platesmanager/Platemanagertext");
                    var platedup = GameObject.Instantiate(getplate, getplate.parent);
                    var platetext = platedup.transform.Find("Userperfplate/Performance Text").gameObject.GetComponent<TMPro.TextMeshProUGUI>();
                    var icong = platedup.transform.Find("Userperfplate/Trust Icon").gameObject;
                    var img = icong.GetComponent<UnityEngine.UI.Image>();
                    img.enabled = true;
                    icong.GetComponent<UnityEngine.UI.LayoutElement>().enabled = true;
                    platedup.name = "ClTrustRank";
                    platedup.gameObject.SetActive(settings.nconfig.customnameplates);
                    MelonCoroutines.Start(Apis.image.LoadSpriteBetter(img, "https://api.glowking.net/cl/AC-logo.jpg"));
                    //
                    switch (true)
                    {

                        case true when getuser.Trustrank == 4:
                            platetext.text = "Arctic | DEV";
                            platetext.color = Color.cyan;
                            break;
                        case true when getuser.Trustrank == 3:
                            platetext.text = "Arctic | Admin";
                            platetext.color = Color.green;
                            break;
                        case true when getuser.Trustrank == 2:
                            platetext.text = "Arctic | Staff";
                            platetext.color = Color.yellow;
                            break;
                        case true when getuser.Trustrank == 1:
                            platetext.text = "Arctic | VIP";
                            platetext.color = Color.magenta;
                            break;


                    }
                }

                if (getuser.Id == vrcpl.field_Private_APIUser_0.id && getuser.CustomTag != null)
                {
                    var getplate = getvrcplayer.field_Public_PlayerNameplate_0.field_Public_GameObject_3.transform.Find("Platesmanager/Platemanagertext");
                    var platedup = GameObject.Instantiate(getplate, getplate.parent);
                    var platetext = platedup.transform.Find("Userperfplate/Performance Text").gameObject.GetComponent<TMPro.TextMeshProUGUI>();
                    platedup.gameObject.name = "CustomTag";
                    platetext.text = getuser.CustomTag;
                    var icong = platedup.transform.Find("Userperfplate/Trust Icon").gameObject;
                    var img = icong.GetComponent<UnityEngine.UI.Image>();
                    img.enabled = true;
                    icong.GetComponent<UnityEngine.UI.LayoutElement>().enabled = true;
                    platedup.name = "ClTrustRank";
                    MelonCoroutines.Start(Apis.image.LoadSpriteBetter(img, "https://api.glowking.net/cl/AC-logo.jpg"));
                    platedup.gameObject.SetActive(settings.nconfig.customnameplates);

                }
            }

            if (this.gameObject != VRC.SDKBase.Networking.LocalPlayer.gameObject)
            {
                gmj.transform.Find("SelectRegion").GetComponent<MeshRenderer>().material.color = colr;
            }

            if (!settings.nconfig.NamePlatesuichange) return;
         
            var imagethree = gmj._vrcplayer.field_Public_PlayerNameplate_0.field_Public_Graphic_1.gameObject.GetComponent<ImageThreeSlice>();

            imagethree.color = colr;

            foreach (var img in imagethree.transform.parent.Find("Platesmanager").transform.GetComponentsInChildren<ImageThreeSlice>(true))
            {
                img.color = colr;
            }
            imagethree.transform.parent.parent.transform.Find("Quick Stats").GetComponent<ImageThreeSlice>().color = colr;
            imagethree.transform.parent.parent.transform.Find("Icon/Background").GetComponent<UnityEngine.UI.Image>().color = colr;



        }

    }
}
