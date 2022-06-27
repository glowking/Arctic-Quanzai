using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MelonLoader;
using UnityEngine;
using Arctic.settings.MonoBehaviours;

namespace Arctic.settings.MonoBehaviours
{
    class Monobehaviours_corotines
    {
        public static IEnumerator waitfortimer()
        {
            yield return new WaitForSeconds(1f);
            touchstuff.cooldown = false;

        }
        public static IEnumerator waitfortimer1()
        {
            yield return new WaitForSeconds(1f);
            touchpickups.waitforcooldown = true;

        }
        public static IEnumerator waitfortimer22()
        {
            yield return new WaitForSeconds(1f);
            sitonpickups.waitforcooldown2 = true;

        }
        public static IEnumerator waitfortimer33()
        {
            yield return new WaitForSeconds(1f);
            Targettouch.waitforcooldown3 = true;

        }

        private static List<string> blist = new List<string>();
        public static IEnumerator runaftergrav(Rigidbody rigbod)
        {

            if (!blist.Contains(rigbod.gameObject.name) && rigbod.gameObject != null)
            {
                blist.Add(rigbod.gameObject.name);
                for (; ; )
                {
                    if (touchpickups.touchpickupstog == false)
                    {
                        blist.Clear();
                        yield break;
                    }
                    try
                    {
                        rigbod.AddForce(new Vector3(0, 0.14f, 0), ForceMode.Impulse);
                    }
                    catch
                    {

                    }

                    yield return null;
                }
            }

        }

        public static IEnumerator sitonobj(Collision cols)
        {
            for (; ; )
            {
                if (!sitonpickups.sitonobj)
                {
                    VRCPlayer.field_Internal_Static_VRCPlayer_0.gameObject.GetComponent<CharacterController>().enabled = true;
                    yield break;
                }

                else
                {
                    try
                    {
                        Arctic.Wrappers.Extentions.LocalPlayer.transform.position = cols.gameObject.transform.position + new Vector3(0, 0.1f, 0);
                        VRCPlayer.field_Internal_Static_VRCPlayer_0.gameObject.GetComponent<CharacterController>().enabled = false;
                    }
                    catch
                    {

                    }

                }



                yield return null;
            }

        }

    }
}
