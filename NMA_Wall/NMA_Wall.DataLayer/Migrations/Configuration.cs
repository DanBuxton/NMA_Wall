namespace NMA_Wall.DataLayer.Migrations
{
    using BO;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(NMA_Wall.DataLayer.DataContext context)
        {
            //  This method will be called after migrating to the latest version.
            /*
#if DEBUG
            Message[] messagesFromDB = (new Respository()).MessageGetAll().ToArray();

            for (int i = 0; i < Message.Messages.Count; i++)
            {
                Message mess = Message.Messages[i];

                if (messagesFromDB.FirstOrDefault(m => (m.MessageBody == mess.MessageBody)
                && (m.Latitude == mess.Latitude) && (m.Longitude == mess.Longitude)) == null) // Id and DateAdded are unique to each instance
                    context.Messages.Add(mess);
            }
#endif
            */
        }
    }
}
