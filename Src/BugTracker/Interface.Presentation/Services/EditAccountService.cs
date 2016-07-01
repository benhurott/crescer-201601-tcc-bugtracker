using BugTracker.Domain.Entity;
using BugTracker.Domain.Interface.Service;
using Interface.Presentation.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Interface.Presentation.Services
{
    public abstract class EditAcccountService
    {

        public static void EditUser(UserEditAccountViewModel model, IUserService userService)
        {
            var userFounded = userService.FindById(UserSessionService.LoggedUser.IDUser);

            String fileName = model.Image;

            if (model.File != null)
            {
                fileName = model.File.FileName;
            }

            if (model.NewPassword != null)
            {
                //TODO Encriptografar OldPassWord antes de Comparar
                if (userFounded.Password.Equals(model.OldPassword))
                {
                    var editedAccount = new User(model.Id.Value, model.Name, model.Email, model.NewPassword,
                                         fileName, Guid.NewGuid().ToString() + new Random().Next(100), null, true, true);

                    userService.Update(editedAccount);
                }

            }
            else
            {
                var editedAccount = new User(model.Id.Value, model.Name,
                                         model.Email, null,
                                         fileName, Guid.NewGuid().ToString() + new Random().Next(100), null, true, true);

                userService.Update(editedAccount);
            }



            UploadImageService.UploadUserImage(model.File);

        }

    }
}