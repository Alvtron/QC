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
            //var kim = new Student() { Firstname = "Kim-Andre", Lastname = "Engebretsen" };
            //var math = new Course() { Title = "Math", Students = { kim, vegard, christoffer, thomas } };
           
            //context.Students.Add(kim);
            //context.Courses.Add(math);

            base.Seed(context);
        }
    }
}
