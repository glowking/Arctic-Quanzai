using System;
using UnityEngine;


namespace Arctic.Apis.Desktopui.monobehaviours
{


    class Dragg : MonoBehaviour
    {
        public Dragg(IntPtr ptr) : base(ptr)
        {
        }

        private float startpozx;
        private float startpozy;
        private bool isheld = false;

        void Update()
        {
            if (isheld)
            {
                Vector3 mousepos;
                mousepos = Input.mousePosition;
                mousepos = GameObject.Find("Camera (eye)").gameObject.GetComponent<Camera>().ScreenToWorldPoint(mousepos);

                this.gameObject.transform.localPosition = new Vector3(mousepos.x - startpozx, mousepos.y - startpozy, 0);


            }
        }

        void OnMouseDown()
        {
            Style.Consoles.consolelogger("BBB");

            if (Input.GetMouseButton(0))
            {
                Style.Consoles.consolelogger("AAA");
                Vector3 mousepos;
                mousepos = Input.mousePosition;
                mousepos = GameObject.Find("Camera (eye)").gameObject.GetComponent<Camera>().ScreenToWorldPoint(mousepos);

                startpozx = mousepos.x - this.transform.localPosition.x;
                startpozx = mousepos.y - this.transform.localPosition.y;

                isheld = true;

            }
        }

        void OnMouseUp()
        {
            isheld = false;

        }



    }
}