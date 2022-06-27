using UnityEngine;

namespace Arctic.Wrappers
{
    public class Resettransform
    {
        public static void reset(GameObject gameobject)
        {
            gameobject.transform.localPosition = new Vector3(0, 0, 0);
            gameobject.transform.localRotation = new Quaternion(0, 0, 0, 0);
            gameobject.transform.localScale = new Vector3(1, 1, 1);
        }

    }
}
