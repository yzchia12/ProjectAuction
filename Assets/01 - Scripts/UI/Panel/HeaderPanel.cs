using System.Collections;
using System.Collections.Generic;
using ProjectBid.Manager;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectBid.UI
{
    public class HeaderPanel : Panel<HeaderPanel>
    {
        [Header("Buttons")]
        public Button _chatButton;
        public Button _auctionButton;

        // Start is called before the first frame update
        void Start()
        {
            _chatButton.onClick.AddListener(() => UIManager.Instance.Show(Constants.Panels.ChatList));
            _auctionButton.onClick.AddListener(() => UIManager.Instance.Show(Constants.Panels.Auction));
        }     
    }
}