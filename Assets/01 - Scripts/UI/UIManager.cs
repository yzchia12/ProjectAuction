using System.Collections;
using System.Collections.Generic;
using ProjectBid.UI;
using UnityEngine;

namespace ProjectBid.Manager
{
    public class UIManager : Manager<UIManager>
    {
        // Start is called before the first frame update
        void Start()
        {
            Events.OnLogin += OnLogin;
            Events.OnLogout += OnLogout;

            Show(Constants.Panels.Login);
        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnLogin()
        {
            Show(Constants.Panels.Explore);
        }

        void OnLogout()
        {
            Show(Constants.Panels.Login);
        }

        public void ShowMessagePanel(bool isShow, string message, bool showLoadingIcon)
        {
            MessagePanel.Instance.Show(isShow, message, showLoadingIcon);
        }

        public void Show(Constants.Panels panel, string userId = "")
        {
            //Hide Panel First
            switch (panel)
            {
                case Constants.Panels.Login:
                    CloseAllPanel();
                    break;
                case Constants.Panels.OTP:
                case Constants.Panels.Congratulations:
                case Constants.Panels.Registration:
                    break;
                case Constants.Panels.Activity:
                case Constants.Panels.Explore:
                case Constants.Panels.Likes:
                case Constants.Panels.MyProfile:
                    CloseAllPanelButHeaderAndFooter();
                    break;
                default:
                    CloseAllPanel();
                    break;
            }

            switch (panel)
            {
                case Constants.Panels.Activity:
                    ActivityPanel.Instance.Show(true);
                    break;
                case Constants.Panels.Auction:
                    AuctionPanel.Instance.Show(true);
                    break;
                case Constants.Panels.Chat:
                    ChatPanel.Instance.Show(true);
                    break;
                case Constants.Panels.ChatList:
                    ChatListPanel.Instance.Show(true);
                    break;                    
                case Constants.Panels.Explore:
                    ExplorePanel.Instance.Show(true);
                    break;
                case Constants.Panels.Likes:
                    LikesPanel.Instance.Show(true);
                    break;
                case Constants.Panels.List:
                    ListPanel.Instance.Show(true);
                    break;
                case Constants.Panels.ListingDetails:
                    ListingDetailsPanel.Instance.Show(true);
                    break;
                case Constants.Panels.Login:
                    LoginPanel.Instance.Show(true);
                    break;                    
                case Constants.Panels.MyProfile:
                    ProfilePanel.Instance.Show(true, Constants.Panels.MyProfile, userId);
                    break;
                case Constants.Panels.Profile:
                    ProfilePanel.Instance.Show(true, Constants.Panels.Profile, userId);
                    break;
                case Constants.Panels.Registration:
                    RegistrationPanel.Instance.Show(true);
                    break;
                case Constants.Panels.Congratulations:
                    break;
                case Constants.Panels.OTP:
                    break;
                default:
                    break;
            }
        }

        void CloseAllPanel()
        {
            LoginPanel.Instance.Show(false);
            ActivityPanel.Instance.Show(false);
            AuctionPanel.Instance.Show(false);
            ChatListPanel.Instance.Show(false);
            ExplorePanel.Instance.Show(false);
            FooterPanel.Instance.Show(false);
            HeaderPanel.Instance.Show(false);
            LikesPanel.Instance.Show(false);
            ListingDetailsPanel.Instance.Show(false);
            ListPanel.Instance.Show(false);
            LoginPanel.Instance.Show(false);
            ProfilePanel.Instance.Show(false);
        }

        void CloseAllPanelButHeaderAndFooter()
        {
            LoginPanel.Instance.Show(false);
            ActivityPanel.Instance.Show(false);
            AuctionPanel.Instance.Show(false);
            ChatListPanel.Instance.Show(false);
            ExplorePanel.Instance.Show(false);
            LikesPanel.Instance.Show(false);
            ListingDetailsPanel.Instance.Show(false);
            ListPanel.Instance.Show(false);
            LoginPanel.Instance.Show(false);
            ProfilePanel.Instance.Show(false);

            FooterPanel.Instance.Show(true);
            HeaderPanel.Instance.Show(true);
        }
    }
}