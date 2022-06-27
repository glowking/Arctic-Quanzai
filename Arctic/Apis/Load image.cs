using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace Arctic.Apis
{
    public class image
    {
        public static IEnumerator loadtexture2d(Texture2D Instance, string url)
        {
            UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
            yield return www.SendWebRequest();

            Instance = DownloadHandlerTexture.GetContent(www);
        }

        public static IEnumerator LoadSpriteBetter(Image Instance, string url)
        {

            var www = UnityWebRequestTexture.GetTexture(url);
            _ = www.downloadHandler;
            var asyncOperation = www.SendWebRequest();
            Func<bool> func = () => asyncOperation.isDone;
            yield return new WaitUntil(func);
            if (www.isHttpError || www.isNetworkError)
            {
                Debug.Log("Error2 : " + www.error);
                yield break;
            }

            var content = DownloadHandlerTexture.GetContent(www);
            var sprite2 = Instance.sprite = Sprite.CreateSprite(content,
                new Rect(0f, 0f, content.width, content.height), new Vector2(0f, 0f), 100000f, 1000u,
                SpriteMeshType.FullRect, Vector4.zero, false);
            Instance.color = Color.white;
            if (sprite2 != null) Instance.sprite = sprite2;
        }

        public static IEnumerator LoadSpriteBettervrchat(Image Instance, string url)
        {

            var www = UnityWebRequestTexture.GetTexture(url);
            _ = www.downloadHandler;
            var asyncOperation = www.SendWebRequest();
            Func<bool> func = () => asyncOperation.isDone;
            yield return new WaitUntil(func);
            if (www.isHttpError || www.isNetworkError)
            {
                Debug.Log("Error3 : " + www.error);
                yield break;
            }

            var content = DownloadHandlerTexture.GetContent(www);
            content.name = content.name + ".png";
            var sprite2 = Instance.sprite = Sprite.CreateSprite(content,
                new Rect(0f, 0f, content.width, content.height), new Vector2(0f, 0f), 100000f, 1000u,
                SpriteMeshType.FullRect, Vector4.zero, false);
            Instance.color = Color.white;
            if (sprite2 != null) Instance.sprite = sprite2;
        }


        public static IEnumerator loadspriterest(Image Instance, string url)
        {

            var www = UnityWebRequestTexture.GetTexture(url);
            _ = www.downloadHandler;
            var asyncOperation = www.SendWebRequest();
            Func<bool> func = () => asyncOperation.isDone;
            yield return new WaitUntil(func);
            if (www.isHttpError || www.isNetworkError)
            {
                Style.Consoles.consolelogger("Error4 : " + www.error);

                yield break;
            }

            var content = DownloadHandlerTexture.GetContent(www);
            var sprite2 = Instance.sprite = Sprite.CreateSprite(content,
                new Rect(0f, 0f, content.width, content.height), new Vector2(0f, 0f), 100000f, 1000u,
                SpriteMeshType.FullRect, Vector4.zero, false);

            if (sprite2 != null) Instance.sprite = sprite2;
        }

        public static IEnumerator loadspriterest2(Image Instance, string url)
        {

            var www = UnityWebRequestTexture.GetTexture(url);
            _ = www.downloadHandler;
            var asyncOperation = www.SendWebRequest();
            Func<bool> func = () => asyncOperation.isDone;
            yield return new WaitUntil(func);
            if (www.isHttpError || www.isNetworkError)
            {
                Style.Consoles.consolelogger("Error4 : " + www.error);

                yield break;
            }

            var content = DownloadHandlerTexture.GetContent(www);
            var sprite2 = Instance.sprite = Sprite.CreateSprite(content,
                new Rect(0f, 0f, content.width, content.height), new Vector2(0f, 0f), 1f, 1000u,
                SpriteMeshType.FullRect, Vector4.zero, false);
            sprite2.border.Set(256f, 0f, 256f, 0);
            if (sprite2 != null) Instance.sprite = sprite2;
        }


        public static IEnumerator loadImageThreeSlice(ImageThreeSlice Instance, string url)
        {

            var www = UnityWebRequestTexture.GetTexture(url);
            _ = www.downloadHandler;
            var asyncOperation = www.SendWebRequest();
            Func<bool> func = () => asyncOperation.isDone;
            yield return new WaitUntil(func);
            if (www.isHttpError || www.isNetworkError)
            {
                Style.Consoles.consolelogger("Error6 : " + www.error);
                yield break;
            }

            var content = DownloadHandlerTexture.GetContent(www);
            var sprite2 = Instance._sprite = Sprite.CreateSprite(content,
                new Rect(0f, 0f, content.width, content.height), new Vector2(0f, 0f), 100000f, 1000u,
                SpriteMeshType.FullRect, new Vector4(255, 0, 255, 0), false);
            if (sprite2 != null) Instance._sprite = sprite2;
        }


        public static IEnumerator loadtexture(UnityEngine.Texture Instance, string url)
        {


            UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
            yield return www.SendWebRequest();
            if (www.isHttpError || www.isNetworkError)
            {
                Style.Consoles.consolelogger("Error6 : " + www.error);
                yield break;
            }
            Instance = ((DownloadHandlerTexture)www.downloadHandler).texture;
        }






    }
}
