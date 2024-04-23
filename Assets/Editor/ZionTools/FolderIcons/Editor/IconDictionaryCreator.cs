using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
namespace ZionTools.FolderIcons
{
    public class IconDictionaryCreator : AssetPostprocessor
    {
        private const string _assetsPathDefaultIcons = "Editor/ZionTools/FolderIcons/Icons";
        private const string _assetsPathSOIcons = "Editor/ZionTools/FolderIcons/SOIcons";
        internal static Dictionary<string, Texture> _iconDictionary;

        private static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
        {
            if (!ContainsIconAsset(importedAssets) &&
                !ContainsIconAsset(deletedAssets) &&
                !ContainsIconAsset(movedAssets) &&
                !ContainsIconAsset(movedFromAssetPaths))

            {
                return;
            }

            BuildDictionary();
        }

        private static bool ContainsIconAsset(string[] assets)
        {
            foreach (string str in assets)
            {

                if (ReplaceSeparatorChar(Path.GetDirectoryName(str)) == "Assets/" + _assetsPathDefaultIcons || ReplaceSeparatorChar(Path.GetDirectoryName(str)) == "Assets/" + _assetsPathSOIcons)
                {
                    return true;
                }
            }
            return false;
        }

        private static string ReplaceSeparatorChar(string path)
        {
            return path.Replace("\\", "/");
        }

        internal static void BuildDictionary()
        {
            var dictionary = new Dictionary<string, Texture>();

            var dirDefaultIcons = new DirectoryInfo(Application.dataPath + "/" + _assetsPathDefaultIcons);
            FileInfo[] info = dirDefaultIcons.GetFiles("*.png");
            foreach(FileInfo f in info)
            {
                var texture = (Texture)AssetDatabase.LoadAssetAtPath($"Assets/Editor/ZionTools/FolderIcons/Icons/{f.Name}", typeof(Texture2D));
                dictionary.Add(Path.GetFileNameWithoutExtension(f.Name),texture);
            }
            var dirSOIcons = new DirectoryInfo(Application.dataPath + "/" + _assetsPathSOIcons);
            FileInfo[] infoSO = dirSOIcons.GetFiles("*.asset");
            foreach (FileInfo f in infoSO) 
            {
                var folderIconSO = (FolderIconSO)AssetDatabase.LoadAssetAtPath($"Assets/Editor/ZionTools/FolderIcons/SOIcons/{f.Name}", typeof(FolderIconSO));

                if (folderIconSO != null) 
                {
                    var texture = (Texture)folderIconSO.icon;

                    foreach (string folderName in folderIconSO.folderNames) 
                    {
                        if (folderName != null) 
                        {
                            dictionary.TryAdd(folderName, texture);
                        }
                    }
                }
            }
            
            _iconDictionary = dictionary;
        }
    }
}
