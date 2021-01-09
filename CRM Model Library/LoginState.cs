using System;
using System.Collections.Generic;
using System.Text;

namespace CRM_Model_Library
{
    public class LoginState
    {
        public bool IsLoggedIn { get; set; }
        public UserModel User { get; set; }
        public event Action OnChange;

        public void SetLogin(bool login, UserModel user)
        {
            IsLoggedIn = login;
            User = user;
            NotifyStateChanged();
        }

        private void NotifyStateChanged()
        {
            OnChange?.Invoke();
        }
    }
}
