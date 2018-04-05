﻿using QC.Model;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace QC.DataAccess
{

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.Data.Entity.DbContext" />
    public partial class DataContext : DbContext
    {

        /// <summary>
        /// Gets or sets the courses.
        /// </summary>
        /// <value>
        /// The courses.
        /// </value>
        public virtual DbSet<User> Courses { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SchoolContext"/> class.
        /// </summary>
        public DataContext()
        {
            Configuration.ProxyCreationEnabled = false;

            Database.SetInitializer(new DataInitializer());
        }

        /// <summary>
        /// This method is called when the model for a derived context has been initialized, but
        /// before the model has been locked down and used to initialize the context.  The default
        /// implementation of this method does nothing, but it can be overridden in a derived class
        /// such that the model can be further configured before it is locked down.
        /// </summary>
        /// <param name="modelBuilder">The builder that defines the model for the context being created.</param>
        /// <remarks>
        /// Typically, this method is called only once when the first instance of a derived context
        /// is created.  The model for that context is then cached and is for all further instances of
        /// the context in the app domain.  This caching can be disabled by setting the ModelCaching
        /// property on the given ModelBuidler, but note that this can seriously degrade performance.
        /// More control over caching is provided through use of the DbModelBuilder and DbContextFactory
        /// classes directly.
        /// </remarks>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Handle cycles by not traversing relations
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            /*// Specify how the mapping between Students and Courses are handled
            modelBuilder.Entity<Student>()
                .HasMany(a => a.Courses)
                .WithMany(b => b.Students)
                .Map(m =>
                {
                    m.ToTable("StudentCourse");
                    m.MapLeftKey("StudentID");
                    m.MapRightKey("CourseID");
                });*/
        }
    }
}
 