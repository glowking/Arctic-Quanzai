using System;
using UnityEngine;
namespace Arctic.Apis.Buttons.Bigui
{
    class Outlinebutton
    {
        public static GameObject Button(float x, float y, string Text, GameObject parent, Action action)
        {
            var toinstanciate = GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/Avatar/Change Button");
            var instanciated = GameObject.Instantiate(toinstanciate, parent.transform);
            instanciated.transform.localPosition = new Vector3(x * 10, y * 10, 1);
            instanciated.transform.Find("Label").GetComponent<UnityEngine.UI.Text>().text = Text;
            var button = instanciated.GetComponent<UnityEngine.UI.Button>();
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(new Action(() => action.Invoke()));
            button.interactable = true;

            return instanciated.gameObject;
        }
    }
}
