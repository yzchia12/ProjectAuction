using System.Collections;
using System.Collections.Generic;
using ProjectBid.Manager;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectBid.UI
{
    public class LoginPanel : Panel<LoginPanel>
    {
        [Header("UI")]
        public GameObject _otpSection;

        [Header("InputField")]
        public TMP_InputField _emailInputField;
        public TMP_InputField _passwordInputField;
        public TMP_InputField _otpInputField;

        [Header("Button")]
        public Button _loginButton;
        public Button _signUpButton;
        public Button _googleLoginButton;
        public Button _otpConfirmButton;

        // Start is called before the first frame update
        void Start()
        {
            _loginButton.onClick.AddListener(OnLoginButtonClick);
            _otpConfirmButton.onClick.AddListener(OnOTPConfirmButtonClick);
            _signUpButton.onClick.AddListener(() => UIManager.Instance.Show(Constants.Panels.Registration));
        }        

        void OnLoginButtonClick()
        {
            AuthenticationManager.Instance.EmailLogin(_emailInputField.text, _passwordInputField.text);            
        }

        void OnOTPConfirmButtonClick()
        {
            AuthenticationManager.Instance.OTPVerification(_otpInputField.text);
        }
    }
}