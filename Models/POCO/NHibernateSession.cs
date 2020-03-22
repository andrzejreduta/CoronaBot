using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaBot.Models
{
    public class NHibernateSession
    {
        public static ISession OpenSession()
        {
            var configuration = new Configuration();

            // By default it uses hibernate.cfg.xml file from root Application folder 
            // to change default file or/and path see Cookbook 
            configuration.Configure();

            // Loading *.hbm.xml files from assembly
            // More options and info here: stackoverflow.com/questions/19163946/store-hbm-xml-in-folder-load-them-on-demand
            configuration.AddAssembly("CoronaBot");

            ISessionFactory sessionFactory = configuration.BuildSessionFactory();
            return sessionFactory.OpenSession();
        }
    }
}