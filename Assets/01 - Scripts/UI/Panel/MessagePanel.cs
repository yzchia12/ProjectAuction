using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectBid.UI
{
    public class MessagePanel : Panel<MessagePanel>
    {
        [Header("UI")]
        public Image _loadingIcon;
        public TextMeshProUGUI _messageText;

        [Header("Button")]
        public Button _okButton;

        // Start is called before the first frame update
        void Start()
        {
            _okButton.onClick.AddListener(() => Show(false));
        }

        // Update is called once per frame
        void Update()
        {
            _loadingIcon.transform.Rotate(new Vector3(0, 0, 1));
        }

        public void Show(bool isShow, string message, bool showLoadingIcon)
        {
            Show(isShow);

            _messageText.text = message;

            _loadingIcon.gameObject.SetActive(showLoadingIcon);

            _okButton.gameObject.SetActive(!showLoadingIcon);
        }
    }
}