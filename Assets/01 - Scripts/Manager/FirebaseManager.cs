using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using Firebase.Extensions;
using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;

namespace ProjectBid.Manager
{
    public class FirebaseManager : Manager<FirebaseManager>
    {
        public Firebase.Auth.FirebaseAuth Auth;
        public Firebase.Auth.FirebaseUser User;

        // Start is called before the first frame update
        void Start()
        {
            Auth = Firebase.Auth.FirebaseAuth.DefaultInstance;                     

            Auth.StateChanged += OnStateChanged;
            
            //Debug.Log(Auth.StateChanged );
        }

        void OnStateChanged(object sender, EventArgs eventArgs)
        {
            if (Auth.CurrentUser != User)
            {
                bool signedIn = User != Auth.CurrentUser && Auth.CurrentUser != null
                    && Auth.CurrentUser.IsValid();
                
                if (!signedIn && User != null)
                {
                    
                }

                User = Auth.CurrentUser;

                if (User != null)
                {
                    print(User.DisplayName);
                    Events.OnLogin();
                }
                else
                {                 
                    Events.OnLogout();
                }
            }
        }
    }
}