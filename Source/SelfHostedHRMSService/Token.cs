using EntityInterfaces;
using IOCFactory;
using NHibernate;
using ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHostedHRMSService
{
    public static class Token
    {
        private static IHibernateDAL _DAL = DALSession.GetDAL();

        public static IUser GenerateSessionToken(IUser userInfo)
        {
            userInfo.UserToken = Tokenizer.Hash.Get(userInfo.EmployeeInformation.FirstName + userInfo.EmployeeInformation.LastName + DateTime.Now.ToString("MMddyyyyhhmmss"), Tokenizer.HashType.MD5, ASCIIEncoding.UTF8);
            userInfo.TokenExpiryDate = DateTime.Now.AddHours(30); //Token will expire in 1 month. In prep for differnt authentication approach where in the token will be sent via email and will be used as a login.

            _DAL.SaveRecord<IUser>(userInfo);

            return userInfo;
        }

        public static void ClearSessionToken(IUser userInfo)
        {
            userInfo.UserToken = null;
            userInfo.TokenExpiryDate = null;

            _DAL.SaveRecord<IUser>(userInfo);
        }

        public static bool ValidateSessionToken(string token)
        {
            var tokenCredentials = ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(token));

            var userToken = (from user in _DAL.GetRecords<IUser>()
                             where user.UserToken == tokenCredentials
                             && user.TokenExpiryDate > DateTime.Now
                             select user.UserToken).FirstOrDefault();
            if (!string.IsNullOrEmpty(userToken))
            {
                return true;
            }

            return false;

        }
    }
}
