using CommonLib.AppSettings;
using System.Runtime.Serialization;

namespace Project.Entity.Models
{
    /**
    * Replace OnConfiguring method in context class with code below after generating new models 
    **/
    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    if (!optionsBuilder.IsConfigured)
    //    {
    //        var configurationBuilder = new ConfigurationBuilder()
    //            .SetBasePath(Directory.GetCurrentDirectory())
    //            .AddJsonFile("appsettings.json")
    //            .Build();
    //        optionsBuilder.UseSqlServer(configurationBuilder.GetConnectionString("TemplateDatabase"));
    //    }
    //}

    public partial class Users
    {
        [DataMember]
        public string UserTypeName
        {
            get { return ((enUserTypes)UserTypeId).ToString(); }
        }
    }
}
