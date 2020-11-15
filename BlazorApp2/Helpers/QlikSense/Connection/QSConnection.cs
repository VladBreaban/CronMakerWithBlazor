using BlazorApp2.Pages;
using Microsoft.EntityFrameworkCore;
using Qlik.Engine;
using Qlik.Sense.Client;
using RlvMailer.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using static BlazorApp2.Pages.DropDown;

namespace BlazorApp2.Helpers.QlikSense.Connection
{
    public interface IQSConnection
    {
        Task<ILocation> GetLocation();
    }
    class QSConnections : IQSConnection
    {
        private ILocation _location { get; set; }
        public QSConnections()
        {
            var _location = GetLocation().Result;
        }
        public async Task<ILocation> GetLocation()
        {
            try
            {
                using var ctx = new RlvMailerContext();
                ctx.Qs.Load();
                var qs_settings = ctx.Qs.FirstOrDefault();
                ILocation location = Location.FromUri(qs_settings.qs_servr_uri);
                string domain = qs_settings.qs_domain;
                string user = qs_settings.qs_user;
                SecureString securepass = new NetworkCredential("", qs_settings.qs_certificate_password).SecurePassword;
                var x509 = new X509Certificate2(File.ReadAllBytes(qs_settings.qs_certificate_path), securepass);
                var certificateCollection = new X509Certificate2Collection(x509);
                await location.AsDirectConnectionAsync(qs_settings.qs_domain, user, certificateValidation: false, certificateCollection: certificateCollection);
                return location;
            }
            catch (Exception ex)
            {
                //Log.Fatal(ex.Message);
                throw ex;
            }
        }
        public async Task<IHub> GetHubAsync()
        {
            //Log.Information("{Source} - Attempting QS engine connection...", Source.Service);
            try
            {
                var hub = _location.Hub();
                return hub;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<IEnumerable<ISheet>> GetSheetsAsync(string appId)
        {
            string id = appId;
            QSConnections qsConn = new QSConnections();
            var location = await qsConn.GetLocation();
            IAppIdentifier appIdentifier = location.AppWithId(appId);
            try
            {
                IApp app = location.App(appIdentifier, session: Session.Random);
                var sheets = app.GetSheets();
                return sheets;


            }
            catch (NullReferenceException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }


        }



        public async Task<Dictionary<string, string>> GetAppsIdentifiersAsync()
        {

            Dictionary<string, string> appsList = new Dictionary<string, string>();

            QSConnections qsConn = new QSConnections();
            var location = await qsConn.GetLocation();
            var apps = await location.GetAppIdentifiersAsync();

            foreach (var app in apps)
            {


                try
                {
                    if (!appsList.ContainsValue(app.AppName)) //doesn't add if its already there
                    {
                        appsList.Add(app.AppId, app.AppName);
                    }

                }
                catch (MethodInvocationException e)
                {
                    DropDown.errMessage = e.Message;
                    throw e;
                }
                catch (TimeoutException e)
                {
                    DropDown.errMessage = e.Message;
                    throw e;
                }
                catch (SocketException e)
                {
                    DropDown.errMessage = e.Message;
                    throw e;

                }
                catch (WebSocketException e)
                {
                    DropDown.errMessage = e.Message;
                    throw e;
                }
                catch (HttpRequestException e)
                {
                    DropDown.errMessage = e.Message;
                    throw e;
                }

            }

            return appsList;

        }
    }
}
