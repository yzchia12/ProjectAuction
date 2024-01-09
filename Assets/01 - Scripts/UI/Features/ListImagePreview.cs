using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

namespace ProjectBid.UI
{
    public class ListImagePreview : MonoBehaviour
    {
        [Header("UI")]
        public UnityEngine.UI.Image _previewImage;

        [Header("Button")]
        public Button _deleteButton;

        string _path;
        Texture2D _texture;
        byte[] _bytes;

        // Start is called before the first frame update
        void Start()
        {
            _deleteButton.onClick.AddListener(OnDeleteClick);
        }

        public void Initialize(string path, Texture2D texture = null, byte[] bytes = null)
        {
            _path = path;

            _texture = texture;

            _bytes = bytes;

            Sprite sprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);

            _previewImage.sprite = sprite;
        }

        void OnDeleteClick()
        {
            _previewImage.sprite = null;

            _path = null;

            _texture = null;

            _bytes = null;
        }

        public void Clear()
        {
            _previewImage.sprite = null;

            _path = null;

            _texture = null;

            _bytes = null;

            ListPanel.Instance.UpdateImagePreviewPosition();
        }

        public string GetPath()
        {
            return _path;
        }

        public Texture2D GetTexture()
        {
            return _texture;
        }

        public byte[] GetBytes()
        {
            return _bytes;
        }
    }
}