using System.Collections.Generic;
using UnityEngine;

namespace ZionTools.FolderIcons
{
    [CreateAssetMenu(fileName = "NewFolderIcon", menuName = "ZionTools/FolderIcon")]
    public class FolderIconSO : ScriptableObject {

        public Texture2D icon;
        public List<string> folderNames;

        public void OnValidate() {
            IconDictionaryCreator.BuildDictionary();
        }
    }
}

