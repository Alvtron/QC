using QC.Model;
using System.Data.Entity;

namespace QC.DataAccess
{
    /// <summary>
    /// Seeds the database in case the model has changed.
    /// </summary>
    /// <seealso cref="System.Data.Entity.DropCreateDatabaseIfModelChanges{QC.DataAccess.DataContext}" />
    public class DataInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        
        /// <summary>
        /// Seeds the database with specific set data.
        /// </summary>
        /// <param name="context">The context to seed.</param>
        protected override void Seed(DataContext context)
        {
            User alvtron = new User();
            alvtron.CreateNewUser("Alvtron", "thomas.angeland@gmail.com", "#Alvtron1");

            context.Users.Add(alvtron);

            base.Seed(context);
        }
    }
}
