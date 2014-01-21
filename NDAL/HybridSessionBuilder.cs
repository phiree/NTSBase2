﻿using System.Web;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Automapping;
using NHibernate.Tool.hbm2ddl;
using NHibernate.Hql;
using NHibernate.Criterion.Lambda;

namespace NDAL
{
    public class HybridSessionBuilder
    {

        private static ISession _currentSession;
      //  private static ISessionFactory _sessionFactory;
        private Dictionary<string, IDictionary<string, string>> _databaseConfigStr;
        private string[] _databaseIds = { "ntsbase","ntsmart_asia"};
        private static IDictionary<string, ISessionFactory> allFactories=new Dictionary<string,ISessionFactory>();

        public HybridSessionBuilder()
        {
          //  _databaseConfigStr = new Dictionary<string, IDictionary<string, string>>();

            /*db1*/


           // allFactories = new Dictionary<string, ISessionFactory>();
        }
        public ISession GetSession()
        {
            return GetSession("ntsbase");
        }
        public ISession GetSession(string dbid)
        {
#if DEBUG
           HibernatingRhinos.Profiler.Appender.NHibernate.NHibernateProfiler.Initialize();
#endif
           ISessionFactory factory = getSessionFactory(dbid);
            ISession session = getExistingOrNewSession(factory);

            return session;
        }

        public Configuration GetConfiguration()
        {
            var configuration = new Configuration();
            configuration.Configure();
            return configuration;
        }

        
        private ISessionFactory getSessionFactory(string dbid)
        {
            ISessionFactory sessionFactory = null;
            if (allFactories.ContainsKey(dbid))
            {
                sessionFactory = allFactories[dbid];
            }
             
            if(sessionFactory==null)
            {
                sessionFactory=CreateOneFactory(dbid);
                allFactories.Add(dbid, sessionFactory); 
            }
            return sessionFactory;
        }

        private ISessionFactory CreateOneFactory(string dbId)
        {  ISessionFactory sessionFactory=null;
            //NHibernate.Cfg.Environment.Dialect;
               if(dbId=="ntsbase")
               {
           
              //  MyAutoMappingConfiguration mappingCfg = new MyAutoMappingConfiguration();
                MySQLConfiguration dataConfig = MySQLConfiguration.Standard
                    .ShowSql()
                    .ConnectionString(s => s.FromConnectionStringWithKey("conn"));

                sessionFactory = Fluently.Configure()                 
                .Database(dataConfig)
                .Mappings(
                    /*automampping can't work with override
                         m => m.AutoMappings.Add(AutoMap.AssemblyOf<NModel.Product>(mappingCfg)
                             .Conventions.Setup(c=>{
                                 c.Add<DefaultStringLengthConvention>();
                             })
                             .Override<NModel.Product>(map =>
                             {
                                 map.Map(x => x.NTSCode).Unique();
                                 map.Map(x => x.State).CustomType<int>();
                             })
                             //.Override<NModel.Supplier>(map =>
                             //{
                             //    map.Map(x => x.Code).Unique();
                             //})
                             )
                         )*/
                    m => m.FluentMappings.AddFromAssemblyOf<NModel.Mapping.ProductMap>())
                    .ExposeConfiguration(BuildSchema)
                    .BuildSessionFactory();
               }
               else if (dbId == "ntsmart_asia")
               {
                   //  MyAutoMappingConfiguration mappingCfg = new MyAutoMappingConfiguration();
                   MySQLConfiguration dataConfig2 = MySQLConfiguration.Standard
                       .ShowSql()
                       .ConnectionString(s => s.FromConnectionStringWithKey("conn_ntsmart_asia"));

                   sessionFactory = Fluently.Configure()
                    .Database(dataConfig2)
                    .BuildSessionFactory();
               }
               
               return sessionFactory;
        }

        private static void BuildSchema(Configuration config)
        {

            SchemaUpdate update = new SchemaUpdate(config);
            update.Execute(false, true);

        }
        private ISession getExistingOrNewSession(ISessionFactory factory)
        {
            if (HttpContext.Current != null)
            {
                ISession session = GetExistingWebSession();
                if (session == null)
                {
                    session = openSessionAndAddToContext(factory);
                }
                else if (!session.IsOpen)
                {
                    session = openSessionAndAddToContext(factory);
                }

                return session;
            }

            if (_currentSession == null)
            {
                _currentSession = factory.OpenSession();
            }
            else if (!_currentSession.IsOpen)
            {
                _currentSession = factory.OpenSession();
            }

            return _currentSession;
        }

        public ISession GetExistingWebSession()
        {
            return HttpContext.Current.Items[GetType().FullName] as ISession;
        }

        private ISession openSessionAndAddToContext(ISessionFactory factory)
        {
            ISession session = factory.OpenSession();
            HttpContext.Current.Items.Remove(GetType().FullName);
            HttpContext.Current.Items.Add(GetType().FullName, session);
            return session;
        }

        public static void ResetSession()
        {
            var builder = new HybridSessionBuilder();
            builder.GetSession().Dispose();
        }
    }
}