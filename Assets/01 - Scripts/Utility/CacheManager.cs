using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace ProjectBid.Manager
{
    public class CacheManager : Manager<CacheManager>
    {
        public void SaveImageCache(byte[] image, string reference)
        {
            File.WriteAllBytes(Application.persistentDataPath + "/" + reference.Replace('/', '-'), image);
        }

        public Sprite GetImageCache(string reference)
        {            
            string path = Application.persistentDataPath + "/" + reference.Replace('/', '-');            

            if (File.Exists(path))
            {
                byte[] bytes = File.ReadAllBytes(path);

                Texture2D tex = new Texture2D(1, 1);
                tex.LoadImage(bytes);

                Sprite sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);

                return sprite;
            }

            return null;
        }

        public byte[] ReadBytesFromPath(string path)
        {
            return File.ReadAllBytes(path);
        }
    }
}