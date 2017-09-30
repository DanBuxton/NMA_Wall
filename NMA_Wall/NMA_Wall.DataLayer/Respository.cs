using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NMA_Wall.BO.Extensions;

namespace NMA_Wall.DataLayer
{
    public class Respository : IDisposable
    {
        private DataContext DB = new DataContext();

        public void UserAdd(BO.User user)
        {
            DB.Users.Add(user);
            DB.SaveChanges();
        }

        public void UserRemove(BO.User user)
        {
            if (user != null && !user.IsSuperAdmin)
            {
                DB.Users.Remove(user);
                DB.SaveChanges();
            }
        }

        public BO.User UserGet(string username, string password)
        {
            password = password.ComputeHash();
            return DB.Users.FirstOrDefault(u =>
                u.Username == username
                &&
                u.Password == password);
        }

        public BO.User UserGet(Guid id)
        {
            return DB.Users.FirstOrDefault(u => u.Id == id);
        }

        // Required for Admin (UserAdmin.aspx)
        public string UserGetType(Guid id)
        {
            string result = "";

            // Code reuse
            BO.User user = UserGet(id);
            //BO.User user = DB.Users.FirstOrDefault(u => u.Id == id);

            if (user != null)
                if (user.IsSuperAdmin)
                    result = "Super Admin";
                else if (user.IsAdmin)
                    result = "Admin";
                else if (user.IsContribruter)
                    result = "Contributor";
                else
                    result = string.Empty;

            return result;
        }
        public string UserGetType(BO.User user)
        {
            string result = "";

            // Code reuse
            //BO.User user = DB.Users.FirstOrDefault(u => u.Id == id);

            if (user != null)
                if (user.IsSuperAdmin)
                    result = "Super Admin";
                else if (user.IsAdmin)
                    result = "Admin";
                else if (user.IsContribruter)
                    result = "Contributor";
                else
                    result = string.Empty;

            return result;
        }

        public bool UserDoesExist(string username, string password)
        {
            bool result = true;
            BO.User user = new BO.User();

            user = DB.Users.FirstOrDefault(u =>
            u.Username == username);

            if (user == null)
            {
                result = !result;
            }

            return result;
        }

        public IEnumerable<BO.User> UserGetAll()
        {
            return DB.Users;
        }

        public void MessageAdd(BO.Message message)
        {
            DB.Messages.Add(message);
            DB.SaveChanges();
        }

        public void MessageRemove(BO.Message message)
        {
            DB.Messages.Remove(message);
            DB.SaveChanges();
        }

        public BO.Message MessageGet(Guid id)
        {
            return DB.Messages.FirstOrDefault(m => m.Id == id);
        }

        public IEnumerable<BO.Message> MessageGetInRange(double latitude, double longitude, double distance)
        {
            // TODO This is a really bad way of doing things... need to rethink this in the future
            return DB.Messages.ToArray().Where(m => BO.GeoLocationHelper.Distance(latitude, longitude, m.Latitude, m.Longitude) < distance);
        }

        public IEnumerable<BO.Message> MessageGetAll()
        {
            return DB.Messages;
        }

        // Required for Comment Moderation
        public IEnumerable<BO.Message> MessageGetAllAwaitingModeration()
        {
            return DB.Messages.Where(m => m.IsAwaitingModeration);
        }

        public void ContentAdd(BO.Content content)
        {
            DB.Content.Add(content);
            DB.SaveChanges();
        }

        public void RemoveContent(BO.Content content)
        {
            DB.Content.Remove(content);
            DB.SaveChanges();
        }

        public IEnumerable<BO.Content> ContentGetInRange(double latitude, double longitude, double distance)
        {
            // TODO This is a really bad way of doing things... need to rethink this in the future
            return DB.Content.ToArray().Where(c => BO.GeoLocationHelper.Distance(latitude, longitude, c.Latitude, c.Longitude) < distance);
        }

        public void SaveChanges()
        {
            DB.SaveChanges();
        }

        public void Dispose()
        {
            if (DB != null)
            {
                DB.Dispose();
            }
        }
    }
}
