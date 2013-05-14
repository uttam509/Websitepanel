﻿using System;
using System.Configuration.Install;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text.RegularExpressions;
using Microsoft.Deployment.WindowsInstaller;

namespace WebsitePanel.SchedulerServiceInstaller
{
    public class CustomActions
    {
        [CustomAction]
        public static ActionResult CheckConnection(Session session)
        {
            string testConnectionString = session["AUTHENTICATIONTYPE"].Equals("Windows Authentication") ? GetConnectionString(session["SERVERNAME"], "master") : GetConnectionString(session["SERVERNAME"], "master", session["LOGIN"], session["PASSWORD"]);

            if (CheckConnection(testConnectionString))
            {
                session["CORRECTCONNECTION"] = "1";
                session["CONNECTIONSTRING"] = session["AUTHENTICATIONTYPE"].Equals("Windows Authentication") ? GetConnectionString(session["SERVERNAME"], session["DATABASENAME"]) : GetConnectionString(session["SERVERNAME"], session["DATABASENAME"], session["LOGIN"], session["PASSWORD"]);
            }
            else
            {
                session["CORRECTCONNECTION"] = "0";
            }

            return ActionResult.Success;
        }

        [CustomAction]
        public static ActionResult FinalizeInstall(Session session)
        {
            ChangeConnectionString(session["CONNECTIONSTRING"], session["INSTALLFOLDER"]);
            InstallService(session["INSTALLFOLDER"]);

            return ActionResult.Success;
        }

        private static void InstallService(string installFolder)
        {
            try
            {
                if (!ServiceController.GetServices().Any(s => s.DisplayName.Equals("WebsitePanel Scheduler", StringComparison.CurrentCultureIgnoreCase)))
                {
                    ManagedInstallerClass.InstallHelper(new[] {"/i", Path.Combine(installFolder, "WebsitePanel.SchedulerService.exe")});
                }

                StartService("WebsitePanel Scheduler");
            }
            catch (Exception)
            {
            }
        }

        private static void ChangeConnectionString(string connectionString, string installFolder)
        {
            string content;
            string path = Path.Combine(installFolder, "WebsitePanel.SchedulerService.exe.config");

            using (var reader = new StreamReader(path))
            {
                content = reader.ReadToEnd();
            }

            var re = new Regex("\\$\\{" + "installer.connectionstring" + "\\}+", RegexOptions.IgnoreCase);
            content = re.Replace(content, connectionString);

            using (var writer = new StreamWriter(path))
            {
                writer.Write(content);
            }
        }

        private static void StartService(string serviceName)
        {
            var sc = new ServiceController(serviceName);

            if (sc.Status == ServiceControllerStatus.Stopped)
            {
                sc.Start();
                sc.WaitForStatus(ServiceControllerStatus.Running);
            }
        }

        private static string GetConnectionString(string serverName, string databaseName)
        {
            return string.Format("Server={0};database={1};Trusted_Connection=true;", serverName, databaseName);
        }

        private static string GetConnectionString(string serverName, string databaseName, string login, string password)
        {
            return string.Format("Server={0};database={1};uid={2};password={3};", serverName, databaseName, login, password);
        }

        private static bool CheckConnection(string connectionString)
        {
            var connection = new SqlConnection(connectionString);
            bool result = true;

            try
            {
                connection.Open();
            }
            catch (Exception)
            {
                result = false;
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return result;
        }
    }
}