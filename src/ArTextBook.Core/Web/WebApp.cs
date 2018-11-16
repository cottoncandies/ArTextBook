using Scietec.Combine.Logging;
using Scietec.Combine.Utils;
using Alva.ArTextBook.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Alva.ArTextBook.Types;
using Scietec.Combine.Data;
using System.Reflection;
using Scietec.Combine.Inject;
using Npgsql;
using Scietec.Combine.Data.PgSql;
using Alva.ArTextBook.Kernel.Types;
using Scietec.Combine.Session;
using Alva.ArTextBook.Kernel.Services;
using Microsoft.AspNetCore.StaticFiles;
using Scietec.Combine.AspNetCore;

namespace Alva.ArTextBook.Web
{
    public class WebApp
    {
        #region Prop
        #region Private
        public const string SESSION_COOKIE_NAME = "XSESSIONID";
        public const int PasswordFailCount = 5;
        public static long AdminUserId { get; private set; } = 1;
        public static long AutomaticUserId { get; private set; } = 2;
        public static long AnonymousUserId { get; private set; } = 3;
        public static long AthenasRoleId { get; private set; } = 1;
        public static long ManagersRoleId { get; private set; } = 2;
        public static long AdministratorsRoleId { get; private set; } = 3;
        public static long UsersRoleId { get; private set; } = 4;
        #endregion

        #region Info
        public static string CopyRight
        {
            get
            {
                return "© 2018-" + DateTime.Now.Year + " ALVA System.";
            }
        }
        public static String AppTitle { get; private set; } = "AR教材编辑系统";
        #endregion

        #region Path
        public static String AppHome { get; private set; }        
        public static string LogPath { get; private set; }
        public static string ConfigPath { get; private set; }
        public static string DataPath { get; private set; }
        #endregion

        #region Logger
        public static ILogger SysLogger { get; private set; }
        public static ILogger AppLogger { get; private set; }
        #endregion

        #region DataBase
        public static DbType DbType { get; private set; }
        public static string DbHost { get; protected set; }
        public static int DbPort { get; protected set; }
        public static string DbName { get; protected set; }
        public static string DbUser { get; protected set; }
        public static string DbPwd { get; protected set; }
        #endregion

        #region Smtp
        public static string SmtpServer { get; private set; }
        public static int SmtpPort { get; private set; }
        public static string SmtpUser { get; private set; }
        public static string SmtpPwd { get; private set; }
        #endregion

        #region Modules
        public static PrivilegeCat AnonymPrivilege { get; private set; }
        public static HashSet<String> AnonymAuthMap { get; private set; }
        public static PrivilegeCat AllPrivilege { get; private set; }
        #endregion
        #endregion

        #region Func
        #region Init And Destroy
        public static void Init(Type appEntryType)
        {
            InitPaths(appEntryType);

            ReadConfig();

            InitLogger();

            InitCache();

            InitBeanManager(appEntryType);

            DatabaseInit();

            SessionInit();

            InitPrivilegeAndAuthMap();

            SysLogger.Info("System Started!");
        }        

        public static void Destroy()
        {
            SessionDestory();
            DatabaseDestroy();
            CacheDestroy();
            SysLogger.Info("System Destroyed!");
        }
       
        #endregion

        #region Config And Logger
        private static void InitPaths(Type appEntryType)
        {
            AppHome = Directory.GetParent(Assembly.GetAssembly(appEntryType).Location).FullName;
            LogPath = Path.Combine(AppHome, "Logs");
            ConfigPath = Path.Combine(AppHome, "Config");
            DataPath = Path.Combine(AppHome, "Data");
            Directory.CreateDirectory(DataPath);
        }

        private static void ReadConfig()
        {
            IniFile ini = new IniFile();
            ini.Load(Path.Combine(ConfigPath, "Config.ini"));
            DbType = ini.Read("database", "type", "pgsql") == "pgsql"
                ? DbType.PgSQL : DbType.Firebird;
            DbHost = ini.Read("database", "host", "127.0.0.1");
            DbPort = ini.Read("database", "port", 5432);
            DbName = ini.Read("database", "db", "wxBigScreen");
            DbUser = ini.Read("database", "user", "postgres");
            DbPwd = ini.Read("database", "pwd", "");

            SmtpServer = ini.Read("smtp", "server", "");
            SmtpPort = ini.Read("smtp", "port", 25);
            SmtpUser = ini.Read("smtp", "user", "");
            SmtpPwd = ini.Read("smtp", "pwd", "");
        }

        private static void InitLogger()
        {
            Directory.CreateDirectory(LogPath);
            LogIniConfig.LoadConfig();
            SysLogger = LogManager.GetLogger("sys");
            AppLogger = LogManager.GetLogger("app");            
        }

        private static void InitBeanManager(Type appEntryType)
        {
            SimpleBeanContext context = new SimpleBeanContext();
            //context.AutoScan(Assembly.GetEntryAssembly());
            context.AutoScan(Assembly.GetAssembly(appEntryType));
            context.AutoScan(Assembly.GetAssembly(typeof(WebApp)));
            BeanManager.Init(context);
        }
        #endregion

        #region Cache
        private static void InitCache()
        {
            CacheUtils.Init();
        }
        private static void CacheDestroy()
        {
            CacheUtils.Destory();
        }
        #endregion
        
        #region Database

        private static void DatabaseInit()
        {
            //SqliteConnectionStringBuilder scb = new SqliteConnectionStringBuilder();
            //scb.DataSource = AppConfig.DbFile;
            ////scb.Mode = SqliteOpenMode.ReadWriteCreate;
            //scb.Mode = SqliteOpenMode.ReadWrite;
            ////配置数据库名
            //optionsBuilder.UseSqlite(scb.ConnectionString);

            //FbConnectionStringBuilder scb = new FbConnectionStringBuilder();
            //scb.Charset = "UTF8";
            //scb.Dialect = 3;
            //scb.Port = 3050;
            //scb.Pooling = true;
            //scb.Password = "masterkey";
            //scb.ServerType = FbServerType.Default;
            //scb.UserID = "sysdba";
            //scb.DataSource = "127.0.0.1";
            //scb.Database = AppConfig.DbFile;
            //optionsBuilder.UseFirebird(scb.ConnectionString);

            NpgsqlConnectionStringBuilder scb = new NpgsqlConnectionStringBuilder();
            scb.Host = WebApp.DbHost;
            scb.Port = WebApp.DbPort;
            scb.Database = WebApp.DbName;
            scb.Encoding = "utf-8";
            scb.Username = WebApp.DbUser;
            scb.Password = WebApp.DbPwd;
            scb.Pooling = true;

            DbSessionManager.Init(new PostgreSqlSessionFactory(scb));
        }
        private static void DatabaseDestroy()
        {
            DbSessionManager.Destory();
        }
        #endregion

        #region Session
        private static void SessionInit()
        {
            SessionSettings.CookieName = SESSION_COOKIE_NAME;
            SessionSettings.HeaderEnable = true;
            SessionSettings.HeaderName = SESSION_COOKIE_NAME;
            SessionSettings.CookieEnable = true;
            SessionManager.Init(new MemorySessionFactory());
        }

        private static void SessionDestory()
        {
            SessionManager.Destory();
        }
        #endregion

        #region InitPrivilegeAndAuthMap
        private static void InitPrivilegeAndAuthMap()
        {
            ModuleService ms = BeanManager.GetInstance<ModuleService>();
            AnonymPrivilege = ms.GetAnonymPrivileges();
            AnonymAuthMap = ms.GetAnonymAuthMap();
            AllPrivilege = ms.GetAllPrivileges(false);
        }
        #endregion

        #endregion

        #region SendMail
        public static void SendMail(string toMail, string subj, string bodys)
        {
            var t = MailUtil.SendMailAsync(SmtpServer, SmtpPort, false, SmtpUser,
                 SmtpPwd, AppTitle, SmtpUser, toMail, subj, bodys);
            t.Wait();
        }

        public static Properties GetMimeConfig()
        {
            Properties p = new Properties();
            string f = Path.Combine(ConfigPath, "mime.conf");
            if (File.Exists(f))
            {
                p.Load(f);
            }
            return p;
        }

        public static FileExtensionContentTypeProvider GetContentTypeProvider()
        {
            var provider = new FileExtensionContentTypeProvider();
            var p = WebApp.GetMimeConfig();
            var k = p.GetPropertyNames();
            while (k.MoveNext())
            {
                provider.Mappings[k.Current] = p[k.Current];
            }
            return provider;
        }
        #endregion
    }
}
