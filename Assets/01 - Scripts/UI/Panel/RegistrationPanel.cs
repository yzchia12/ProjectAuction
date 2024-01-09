using System.Collections;
using System.Collections.Generic;
using ProjectBid.Manager;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectBid.UI
{
    public class RegistrationPanel : Panel<RegistrationPanel>
    {
        [Header("UI")]
        public TextMeshProUGUI _instructionText;

        [Header("Input Field")]
        public TMP_InputField _emailInputField;
        public TMP_InputField _passwordInputField;
        public TMP_InputField _confirmPasswordInputField;
        public TMP_InputField _usernameInputField;

        [Header("Button")]
        public Button _signupButton;

        // Start is called before the first frame update
        void Start()
        {
            _signupButton.onClick.AddListener(() => AuthenticationManager.Instance.EmailSignup(_emailInputField.text, _passwordInputField.text, _usernameInputField.text));
        }        
    }
}