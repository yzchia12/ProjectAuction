using System.Collections;
using System.Collections.Generic;
using ProjectBid.Manager;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectBid.UI
{
    public class ListPanel : Panel<ListPanel>
    {
        [Header("UI")]
        public List<ListImagePreview> _imagePreviews;

        [Header("Input Field")]
        public TMP_InputField _nameInputField;

        [Header("Button")]
        public Button _uploadImageButton;
        public Button _listButton;

        // Start is called before the first frame update
        void Start()
        {
            _listButton.onClick.AddListener(ListAuction);
            _uploadImageButton.onClick.AddListener(UploadImage);
        }

        // Update is called once per frame
        void Update()
        {

        }

        void UploadImage()
        {            
            NativeGallery.GetImagesFromGallery(OnImagesSelected);
        }

        public void UpdateImagePreviewPosition()
        {
            for (int i = 0; i < _imagePreviews.Count; i++)
            {
                if(_imagePreviews.Count == i + 1)
                {
                    break;
                }

                if (_imagePreviews[i].GetBytes() != null)
                {
                    continue;                    
                }

                bool isAssigned = false;

                for (int p = i + 1; p < _imagePreviews.Count; p++)
                {
                    if (_imagePreviews[p].GetBytes() != null && !isAssigned)
                    {
                        string path = _imagePreviews[p].GetPath();
                        byte[] bytes = _imagePreviews[p].GetBytes();
                        Texture2D texture = _imagePreviews[p].GetTexture();

                        _imagePreviews[i].Initialize(path, texture, bytes);

                        isAssigned = true;
                    }
                    
                }
            }
        }

        void OnImagesSelected(string[] paths)
        {
            for (int i = 0; i < paths.Length; i++)
            {                
                byte[] bytes = CacheManager.Instance.ReadBytesFromPath(paths[i]);

                Texture2D texture = new Texture2D(1, 1);
                texture.LoadImage(bytes);
                texture.Apply();

                _imagePreviews[i].Initialize(paths[i], texture, bytes);
            }
        }

        void ListAuction()
        {

        }
    }
}