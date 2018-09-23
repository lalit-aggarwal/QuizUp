using QuizUp.Models;
using QuizUp.Services;
using QuizUp.Views;
using System;
using System.Threading.Tasks;

namespace QuizUp.ViewModels
{
    public class FacebookViewModel : ViewModelBase
    {
        public async Task SetFacebookUserProfileAsync(string accessToken)
        {
            await FacebookService.Instance.GetFacebookProfileAsync(accessToken);
            string username = FacebookService.Instance.FacebookProfile.FirstName + FacebookService.Instance.FacebookProfile.LastName;
            var user = UserService.Instance.UserRepository.GetUserByUserNameAsync(username).Result;
            if (user == null)
            {
                user = new User();
                user.ID = Guid.NewGuid().ToString();
                user.Name = FacebookService.Instance.FacebookProfile.Name;
                user.Username = FacebookService.Instance.FacebookProfile.FirstName + FacebookService.Instance.FacebookProfile.LastName;
                user.Password = FacebookService.Instance.FacebookProfile.Id;
                user.ProfileImage = FacebookService.Instance.FacebookProfile.Picture.Data.Url;
                user.QuizAttempts = 0;
                user.IsLoggedIn = true;
                await UserService.Instance.UserRepository.AddUserAsync(user);
            }
            else
            {
                user.IsLoggedIn = true;
                await UserService.Instance.UserRepository.UpdateUserAsync(user);
            }

            OpenMasterPage(new MasterHome());
        }
    }
}
