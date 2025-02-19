using DotaCup.API.Data;
using DotaCup.API.Models.Entities;
using DotaCup.API.Models.Requests;
using Microsoft.AspNetCore.Identity;

namespace DotaCup.API.Extensions;

public static class CreateUserFromSocialLoginExtension
{
    /// <summary>
    /// Creates user from social login
    /// </summary>
    /// <param name="userManager">the usermanager</param>
    /// <param name="context">the context</param>
    /// <param name="model">the model</param>
    /// <returns>System.Threading.Tasks.Task&lt;User&gt;</returns>

    public static async Task<ApplicationUser> CreateUserFromSocialLogin(this UserManager<ApplicationUser> userManager, ApplicationContext context, CreateUserFromSocialLogin model)
    {
        //CHECKS IF THE USER HAS NOT ALREADY BEEN LINKED TO AN IDENTITY PROVIDER
        var user = await userManager.FindByLoginAsync("Google", model.LoginProviderSubject);

        if (user is not null)
            return user; //USER ALREADY EXISTS.

        user = await userManager.FindByEmailAsync(model.Email);

        if (user is null)
        {
            user = new ApplicationUser
            {
                Email = model.Email,
                UserName = model.Email,
            };

            await userManager.CreateAsync(user);

            //EMAIL IS CONFIRMED; IT IS COMING FROM AN IDENTITY PROVIDER
            user.EmailConfirmed = true;

            await userManager.UpdateAsync(user);
            await context.SaveChangesAsync();
        }

        UserLoginInfo userLoginInfo = null;
        userLoginInfo = new UserLoginInfo("Google", model.LoginProviderSubject, "Google".ToUpper());

        //ADDS THE USER TO AN IDENTITY PROVIDER
        var result = await userManager.AddLoginAsync(user, userLoginInfo);

        if (result.Succeeded)
            return user;

        else
            return null;
    }
}