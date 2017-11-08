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
