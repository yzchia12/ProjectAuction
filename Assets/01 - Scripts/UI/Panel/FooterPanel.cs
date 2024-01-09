using System.Collections;
using System.Collections.Generic;
using ProjectBid.Manager;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectBid.UI
{
    public class FooterPanel : Panel<FooterPanel>
    {
        [Header("Buttons")]
        public Button _exploreButton;
        public Button _likesButton;
        public Button _listButton;
        public Button _activityButton;
        public Button _profileButton;

        // Start is called before the first frame update
        void Start()
        {
            _exploreButton.onClick.AddListener(() => UIManager.Instance.Show(Constants.Panels.Explore));
            _likesButton.onClick.AddListener(() => UIManager.Instance.Show(Constants.Panels.Likes));
            _listButton.onClick.AddListener(() => UIManager.Instance.Show(Constants.Panels.List));
            _activityButton.onClick.AddListener(() => UIManager.Instance.Show(Constants.Panels.Activity));
            _profileButton.onClick.AddListener(() => UIManager.Instance.Show(Constants.Panels.MyProfile));
        }
    }
}