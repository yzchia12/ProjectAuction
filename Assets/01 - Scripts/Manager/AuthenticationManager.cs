using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Firebase.Auth;
using Firebase.Extensions;
using Google;
using UnityEngine;

namespace ProjectBid.Manager
{
    public class AuthenticationManager : Manager<AuthenticationManager>
    {
        public Firebase.Auth.FirebaseUser User;

        private string verificationId;

        // Start is called before the first frame update
        void Start()
        {
            //Debug.Log(GoogleAuthProvider.GetCredential);
            
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void EmailLogin(string email, string password)
        {
            Firebase.Auth.FirebaseAuth auth = FirebaseManager.Instance.Auth;
            
            //User.UpdateUserProfileAsync()
            auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWithOnMainThread(task => {

                print(task.Exception.InnerExceptions[0]);


                if (task.IsCanceled)
                {
                    Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
                    return;
                }
                if (task.IsFaulted)
                {
                    Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                    return;
                }
                
                Events.OnLogin();

                FirebaseManager.Instance.User = task.Result.User;                
            });
        }

        public void EmailSignup(string email, string password, string username)
        {
            Firebase.Auth.FirebaseAuth auth = FirebaseManager.Instance.Auth;

            auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWithOnMainThread(task => {
                if (task.IsCanceled)
                {
                    Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
                    return;
                }
                if (task.IsFaulted)
                {
                    Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                    return;
                }

                // Firebase user has been created.
                Firebase.Auth.AuthResult result = task.Result;
                Debug.LogFormat("Firebase user created successfully: {0} ({1})",
                    result.User.DisplayName, result.User.UserId);

                FirebaseManager.Instance.User = task.Result.User;

                SetUsername(username);
            });
        }

        public void SetUsername(string username)
        {
            UserProfile profile = new UserProfile
            {
                DisplayName = username
            };

            FirebaseManager.Instance.User.UpdateUserProfileAsync(profile).ContinueWithOnMainThread(task =>
            {
                if (task.IsCanceled)
                {
                    Debug.LogError("SetUserProfile was canceled.");
                    return;
                }
                if (task.IsFaulted)
                {
                    Debug.LogError("SetUserProfile encountered an error: " + task.Exception);
                    return;
                }

                Debug.Log("Sucessfully Change Name");
            });
        }

        public void PhoneLogin(string phoneNumber)
        {
            PhoneAuthProvider provider = PhoneAuthProvider.GetInstance(FirebaseManager.Instance.Auth);
            
            provider.VerifyPhoneNumber(
              new Firebase.Auth.PhoneAuthOptions
              {
                  PhoneNumber = phoneNumber,
                  TimeoutInMilliseconds = 1000,
                  ForceResendingToken = null
              },
              verificationCompleted: (credential) => {
                  // Auto-sms-retrieval or instant validation has succeeded (Android only).
                  // There is no need to input the verification code.
                  // `credential` can be used instead of calling GetCredential().
                  FirebaseManager.Instance.Auth.SignInAndRetrieveDataWithCredentialAsync(credential).ContinueWithOnMainThread(task => {

                      if (task.IsFaulted)
                      {
                          Debug.LogError("SignInAndRetrieveDataWithCredentialAsync encountered an error: " +
                                          task.Exception);
                          return;
                      }

                      FirebaseManager.Instance.User = task.Result.User;

                      User = task.Result.User;

                      Events.OnLogin();

                  });
              },
              verificationFailed: (error) => {
                  // The verification code was not sent.
                  // `error` contains a human readable explanation of the problem.
              },
              codeSent: (id, token) => {
                  // Verification code was successfully sent via SMS.
                  // `id` contains the verification id that will need to passed in with
                  // the code from the user when calling GetCredential().
                  // `token` can be used if the user requests the code be sent again, to
                  // tie the two requests together.

                  verificationId = id;
              },              
              codeAutoRetrievalTimeOut: (id) => {
                  // Called when the auto-sms-retrieval has timed out, based on the given
                  // timeout parameter.
                  // `id` contains the verification id of the request that timed out.
            });
        }

        public void OTPVerification(string otp)
        {
            PhoneAuthProvider provider = PhoneAuthProvider.GetInstance(FirebaseManager.Instance.Auth);

            PhoneAuthCredential credential = provider.GetCredential(verificationId, otp);

            FirebaseManager.Instance.Auth.SignInAndRetrieveDataWithCredentialAsync(credential).ContinueWithOnMainThread(task => {

                if (task.IsFaulted)
                {
                    Debug.LogError("SignInAndRetrieveDataWithCredentialAsync encountered an error: " +
                                    task.Exception);
                    return;
                }

                FirebaseManager.Instance.User = task.Result.User;

                User = task.Result.User;

                Events.OnLogin();

            });
        }

        public void Logout()
        {
            FirebaseManager.Instance.Auth.SignOut();
        }
    }
}