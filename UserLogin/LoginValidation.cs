using System;
namespace UserLogin
{
    public class LoginValidation
    {
        static public UserRoles currentUserRole
        { get; private set; }

        static public string currentUserName
        { get; set; }

        private string _userName;

        private string _password;

        private string _errorMessage;

        public delegate void ActionOnError(string errorMsg);

        private ActionOnError _actionOnError;

        public LoginValidation()
        {
        }

        public LoginValidation(string UserName, string Password, ActionOnError actionOnError)
        {
            this._userName = UserName;
            this._password = Password;
            this._actionOnError = actionOnError;
        }

        public bool ValidateUserInput(ref User user)
        {
            if (_userName.Equals(String.Empty) ||
                _password.Equals(String.Empty)||
                _userName.Length < 5 ||
                _password.Length < 5)
            {
                _errorMessage = "Input data is not valid";
                _actionOnError(_errorMessage);
                return false;
            }

            user = UserData.IsUserPassCorrect(_userName, _password);

            if(user == null)
            {
                currentUserRole = UserRoles.ANONYMOUS;
                _errorMessage = "User isn't found";
                _actionOnError(_errorMessage);
                return false;
            }
            currentUserRole = (UserRoles)user.Role;
            currentUserName = _userName;

            return true;
        }
    }
}
