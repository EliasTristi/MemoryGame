using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace Memory.Data
{
    public class ImageRepository : Singleton<ImageRepository>
    {
        string ImageURL = "http://localhost/MemoryAPI/api/Image";

        public void ProcessImageIDs(Action<List<int>> processIDs)
        {
            StartCoroutine(GetImageIDs(processIDs));
        }

        private IEnumerator GetImageIDs(Action<List<int>> processIDs)
        {
            UnityWebRequest uwrIDs = UnityWebRequest.Get(ImageURL + "/ids");
            yield return uwrIDs.SendWebRequest();

            if (uwrIDs.result != UnityWebRequest.Result.Success)
            {
                Debug.Log("IMG REPO IDS: " + uwrIDs.error);
            }
            else
            {
                string json = uwrIDs.downloadHandler.text;
                List<int> imageDBIDs = JsonConvert.DeserializeObject<List<int>>(json);
                processIDs(imageDBIDs);
            }
        }

        public void GetProcessTexture(int memoryCardID, Action<Texture2D> loadImage)
        {
            StartCoroutine(GetTextures(memoryCardID, loadImage));
        }

        private IEnumerator GetTextures(int memoryCardID, Action<Texture2D> loadImage)
        {
            UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(ImageURL + "/" + memoryCardID);
            yield return uwr.SendWebRequest();
            if (uwr.result != UnityWebRequest.Result.Success)
            {
                Debug.Log("IMG REPO PROCESS MATERIALS: " + uwr.error);
            }
            else
            {
                Texture2D texture = DownloadHandlerTexture.GetContent(uwr);
                loadImage(texture);
            }
        }
    }
}