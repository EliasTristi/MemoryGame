using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace Memory.Data
{
    public class ImageRepository : Singleton<ImageRepository>
    {
        string ImageURL = "http://localhost/MemoryAPI/api/Image";
        string ResetURL = "http://localhost/MemoryAPI/api/ResetGame";

        public void ProcessImageIDs(Action<List<int>> processIDs)
        {
            StartCoroutine(GetImageIDs(processIDs, "exam"));
        }

        private IEnumerator GetImageIDs(Action<List<int>> processIDs, string theme)
        {
            UnityWebRequest uwrids = UnityWebRequest.Get(ImageURL + "/ids/" + theme);
            yield return uwrids.SendWebRequest();
            if (uwrids.result != UnityWebRequest.Result.Success)
            {
                Debug.Log("ImageRepository.GetImageIds: " + uwrids.error);
            }
            else
            {
                string json = uwrids.downloadHandler.text;
                if (string.IsNullOrEmpty(json))
                {
                    Debug.LogError("ImageRepository.GetImageIds: Empty JSON response.");
                }
                else
                {
                    try
                    {
                        if (!json.TrimStart().StartsWith("{"))
                        {
                            json = "{\"ids\":" + json + "}";
                        }
                        IdList idList = JsonUtility.FromJson<IdList>(json);
                        List<int> imagedbids = idList.ids;
                        //Debug.Log(json + " " + idList.ids.Count);
                        //List<int> imagedbids = JsonConvert.DeserializeObject<List<int>>(json);
                        //foreach (int id in imagedbids)
                        //{
                        //    Debug.Log("Id: " + id);
                        //}
                        processIDs(imagedbids);
                    }
                    catch (JsonException ex)
                    {
                        Debug.LogError("ImageRepository.GetImageIds: JSON deserialization error - " + ex.Message);
                    }
                }
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

        public void AddReset(string playerName)
        {
            StartCoroutine(PostReset(playerName));
        }

        private IEnumerator PostReset(string playerName)
        {
            UnityWebRequest uwr = UnityWebRequest.PostWwwForm(ResetURL + "/" + playerName, "");
            yield return uwr.SendWebRequest();

            if (uwr.result != UnityWebRequest.Result.Success)
            {
                Debug.Log("ImageRepository.AddReset: " + uwr.error);
            }
            else
            {
                string response = uwr.downloadHandler.text;
                //int combinationId = int.Parse(response);
                Debug.Log("This is the reset: " + response + " " + playerName);
            }
        }
    }

    public class IdList
    {
        public List<int> ids;
    }
}