using System.Collections;
using System.Collections.Generic;
using ProjectBid.Manager;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectBid.UI
{
    public class ProfilePanel : Panel<ProfilePanel>
    {
        [Header("UI")]
        public TextMeshProUGUI _nameText;
        public GameObject _listingSection;
        public GameObject _reviewSection;
        public GameObject _aboutSection;

        [Header("Button")]
        public Button _listingButton;
        public Button _reviewButton;
        public Button _aboutButton;

        // Start is called before the first frame update
        void Start()
        {
            _listingButton.onClick.AddListener(OnListingButtonClick);
            _reviewButton.onClick.AddListener(OnReviewButtonClick);
            _aboutButton.onClick.AddListener(OnAboutButtonClick);
        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnListingButtonClick()
        {
            ShowSection(Constants.ProfileSection.Listing);
        }

        void OnReviewButtonClick()
        {
            ShowSection(Constants.ProfileSection.Review);
        }

        void OnAboutButtonClick()
        {
            ShowSection(Constants.ProfileSection.About);
        }

        void ShowSection(Constants.ProfileSection section)
        {
            switch (section)
            {
                case Constants.ProfileSection.Listing:

                    _listingSection.SetActive(true);
                    _reviewSection.SetActive(false);
                    _aboutSection.SetActive(false);

                    break;
                case Constants.ProfileSection.Review:

                    _listingSection.SetActive(false);
                    _reviewSection.SetActive(true);
                    _aboutSection.SetActive(false);

                    break;
                case Constants.ProfileSection.About:

                    _listingSection.SetActive(false);
                    _reviewSection.SetActive(false);
                    _aboutSection.SetActive(true);

                    break;
            }
        }

        public void Show(bool isShow, Constants.Panels type, string userId)
        {
            base.Show(isShow);

            if(type == Constants.Panels.MyProfile)
            {
                _nameText.text = FirebaseManager.Instance.User.DisplayName;
            }
            else
            {

            }

            ShowSection(Constants.ProfileSection.Listing);
        }
    }
}