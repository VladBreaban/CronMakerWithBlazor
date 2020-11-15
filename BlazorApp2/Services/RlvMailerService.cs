using Radzen;
using System;
using System.Web;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Data;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components;
using RlvMailer.Data;

namespace RlvMailer
{
    public partial class RlvMailerService
    {
        private readonly RlvMailerContext context;
        private readonly NavigationManager navigationManager;

        public RlvMailerService(RlvMailerContext context, NavigationManager navigationManager)
        {
            this.context = context;
            this.navigationManager = navigationManager;
        }

        public async Task ExportActiunisToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/rlvmailer/actiunis/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')") : $"export/rlvmailer/actiunis/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')", true);
        }

        public async Task ExportActiunisToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/rlvmailer/actiunis/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')") : $"export/rlvmailer/actiunis/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')", true);
        }

        partial void OnActiunisRead(ref IQueryable<Models.RlvMailer.Actiuni> items);

        public async Task<IQueryable<Models.RlvMailer.Actiuni>> GetActiunis(Query query = null)
        {
            var items = context.Actiunis.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    items = items.Where(query.Filter);
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnActiunisRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnActiuniCreated(Models.RlvMailer.Actiuni item);

        public async Task<Models.RlvMailer.Actiuni> CreateActiuni(Models.RlvMailer.Actiuni actiuni)
        {
            OnActiuniCreated(actiuni);

            context.Actiunis.Add(actiuni);
            context.SaveChanges();

            return actiuni;
        }
        public async Task ExportAuthMethodsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/rlvmailer/authmethods/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')") : $"export/rlvmailer/authmethods/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')", true);
        }

        public async Task ExportAuthMethodsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/rlvmailer/authmethods/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')") : $"export/rlvmailer/authmethods/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')", true);
        }

        partial void OnAuthMethodsRead(ref IQueryable<Models.RlvMailer.AuthMethod> items);

        public async Task<IQueryable<Models.RlvMailer.AuthMethod>> GetAuthMethods(Query query = null)
        {
            var items = context.AuthMethods.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    items = items.Where(query.Filter);
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnAuthMethodsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAuthMethodCreated(Models.RlvMailer.AuthMethod item);

        public async Task<Models.RlvMailer.AuthMethod> CreateAuthMethod(Models.RlvMailer.AuthMethod authMethod)
        {
            OnAuthMethodCreated(authMethod);

            context.AuthMethods.Add(authMethod);
            context.SaveChanges();

            return authMethod;
        }
        public async Task ExportCountriesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/rlvmailer/countries/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')") : $"export/rlvmailer/countries/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')", true);
        }

        public async Task ExportCountriesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/rlvmailer/countries/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')") : $"export/rlvmailer/countries/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')", true);
        }

        partial void OnCountriesRead(ref IQueryable<Models.RlvMailer.Country> items);

        public async Task<IQueryable<Models.RlvMailer.Country>> GetCountries(Query query = null)
        {
            var items = context.Countries.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    items = items.Where(query.Filter);
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnCountriesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnCountryCreated(Models.RlvMailer.Country item);

        public async Task<Models.RlvMailer.Country> CreateCountry(Models.RlvMailer.Country country)
        {
            OnCountryCreated(country);

            context.Countries.Add(country);
            context.SaveChanges();

            return country;
        }
        public async Task ExportExternalEmailsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/rlvmailer/externalemails/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')") : $"export/rlvmailer/externalemails/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')", true);
        }

        public async Task ExportExternalEmailsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/rlvmailer/externalemails/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')") : $"export/rlvmailer/externalemails/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')", true);
        }

        partial void OnExternalEmailsRead(ref IQueryable<Models.RlvMailer.ExternalEmail> items);

        public async Task<IQueryable<Models.RlvMailer.ExternalEmail>> GetExternalEmails(Query query = null)
        {
            var items = context.ExternalEmails.AsQueryable();

            items = items.Include(i => i.Report);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    items = items.Where(query.Filter);
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnExternalEmailsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnExternalEmailCreated(Models.RlvMailer.ExternalEmail item);

        public async Task<Models.RlvMailer.ExternalEmail> CreateExternalEmail(Models.RlvMailer.ExternalEmail externalEmail)
        {
            OnExternalEmailCreated(externalEmail);

            context.ExternalEmails.Add(externalEmail);
            context.SaveChanges();

            return externalEmail;
        }
        public async Task ExportLogAppsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/rlvmailer/logapps/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')") : $"export/rlvmailer/logapps/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')", true);
        }

        public async Task ExportLogAppsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/rlvmailer/logapps/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')") : $"export/rlvmailer/logapps/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')", true);
        }

        partial void OnLogAppsRead(ref IQueryable<Models.RlvMailer.LogApp> items);

        public async Task<IQueryable<Models.RlvMailer.LogApp>> GetLogApps(Query query = null)
        {
            var items = context.LogApps.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    items = items.Where(query.Filter);
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnLogAppsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnLogAppCreated(Models.RlvMailer.LogApp item);

        public async Task<Models.RlvMailer.LogApp> CreateLogApp(Models.RlvMailer.LogApp logApp)
        {
            OnLogAppCreated(logApp);

            context.LogApps.Add(logApp);
            context.SaveChanges();

            return logApp;
        }
        public async Task ExportLogEventsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/rlvmailer/logevents/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')") : $"export/rlvmailer/logevents/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')", true);
        }

        public async Task ExportLogEventsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/rlvmailer/logevents/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')") : $"export/rlvmailer/logevents/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')", true);
        }

        partial void OnLogEventsRead(ref IQueryable<Models.RlvMailer.LogEvent> items);

        public async Task<IQueryable<Models.RlvMailer.LogEvent>> GetLogEvents(Query query = null)
        {
            var items = context.LogEvents.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    items = items.Where(query.Filter);
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnLogEventsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnLogEventCreated(Models.RlvMailer.LogEvent item);

        public async Task<Models.RlvMailer.LogEvent> CreateLogEvent(Models.RlvMailer.LogEvent logEvent)
        {
            OnLogEventCreated(logEvent);

            context.LogEvents.Add(logEvent);
            context.SaveChanges();

            return logEvent;
        }
        public async Task ExportLogReportsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/rlvmailer/logreports/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')") : $"export/rlvmailer/logreports/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')", true);
        }

        public async Task ExportLogReportsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/rlvmailer/logreports/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')") : $"export/rlvmailer/logreports/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')", true);
        }

        partial void OnLogReportsRead(ref IQueryable<Models.RlvMailer.LogReport> items);

        public async Task<IQueryable<Models.RlvMailer.LogReport>> GetLogReports(Query query = null)
        {
            var items = context.LogReports.AsQueryable();

            items = items.Include(i => i.Report);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    items = items.Where(query.Filter);
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnLogReportsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnLogReportCreated(Models.RlvMailer.LogReport item);

        public async Task<Models.RlvMailer.LogReport> CreateLogReport(Models.RlvMailer.LogReport logReport)
        {
            OnLogReportCreated(logReport);

            context.LogReports.Add(logReport);
            context.SaveChanges();

            return logReport;
        }
        public async Task ExportMailsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/rlvmailer/mails/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')") : $"export/rlvmailer/mails/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')", true);
        }

        public async Task ExportMailsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/rlvmailer/mails/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')") : $"export/rlvmailer/mails/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')", true);
        }

        partial void OnMailsRead(ref IQueryable<Models.RlvMailer.Mail> items);

        public async Task<IQueryable<Models.RlvMailer.Mail>> GetMails(Query query = null)
        {
            var items = context.Mails.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    items = items.Where(query.Filter);
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnMailsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnMailCreated(Models.RlvMailer.Mail item);

        public async Task<Models.RlvMailer.Mail> CreateMail(Models.RlvMailer.Mail mail)
        {
            OnMailCreated(mail);

            context.Mails.Add(mail);
            context.SaveChanges();

            return mail;
        }
        public async Task ExportQsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/rlvmailer/qs/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')") : $"export/rlvmailer/qs/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')", true);
        }

        public async Task ExportQsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/rlvmailer/qs/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')") : $"export/rlvmailer/qs/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')", true);
        }

        partial void OnQsRead(ref IQueryable<Models.RlvMailer.Q> items);

        public async Task<IQueryable<Models.RlvMailer.Q>> GetQs(Query query = null)
        {
            var items = context.Qs.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    items = items.Where(query.Filter);
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnQsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnQCreated(Models.RlvMailer.Q item);

        public async Task<Models.RlvMailer.Q> CreateQ(Models.RlvMailer.Q q)
        {
            OnQCreated(q);

            context.Qs.Add(q);
            context.SaveChanges();

            return q;
        }
        public async Task ExportQrtzBlobTriggersToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/rlvmailer/qrtzblobtriggers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')") : $"export/rlvmailer/qrtzblobtriggers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')", true);
        }

        public async Task ExportQrtzBlobTriggersToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/rlvmailer/qrtzblobtriggers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')") : $"export/rlvmailer/qrtzblobtriggers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')", true);
        }

        partial void OnQrtzBlobTriggersRead(ref IQueryable<Models.RlvMailer.QrtzBlobTrigger> items);

        public async Task<IQueryable<Models.RlvMailer.QrtzBlobTrigger>> GetQrtzBlobTriggers(Query query = null)
        {
            var items = context.QrtzBlobTriggers.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    items = items.Where(query.Filter);
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnQrtzBlobTriggersRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnQrtzBlobTriggerCreated(Models.RlvMailer.QrtzBlobTrigger item);

        public async Task<Models.RlvMailer.QrtzBlobTrigger> CreateQrtzBlobTrigger(Models.RlvMailer.QrtzBlobTrigger qrtzBlobTrigger)
        {
            OnQrtzBlobTriggerCreated(qrtzBlobTrigger);

            context.QrtzBlobTriggers.Add(qrtzBlobTrigger);
            context.SaveChanges();

            return qrtzBlobTrigger;
        }
        public async Task ExportQrtzCalendarsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/rlvmailer/qrtzcalendars/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')") : $"export/rlvmailer/qrtzcalendars/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')", true);
        }

        public async Task ExportQrtzCalendarsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/rlvmailer/qrtzcalendars/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')") : $"export/rlvmailer/qrtzcalendars/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')", true);
        }

        partial void OnQrtzCalendarsRead(ref IQueryable<Models.RlvMailer.QrtzCalendar> items);

        public async Task<IQueryable<Models.RlvMailer.QrtzCalendar>> GetQrtzCalendars(Query query = null)
        {
            var items = context.QrtzCalendars.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    items = items.Where(query.Filter);
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnQrtzCalendarsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnQrtzCalendarCreated(Models.RlvMailer.QrtzCalendar item);

        public async Task<Models.RlvMailer.QrtzCalendar> CreateQrtzCalendar(Models.RlvMailer.QrtzCalendar qrtzCalendar)
        {
            OnQrtzCalendarCreated(qrtzCalendar);

            context.QrtzCalendars.Add(qrtzCalendar);
            context.SaveChanges();

            return qrtzCalendar;
        }
        public async Task ExportQrtzCronTriggersToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/rlvmailer/qrtzcrontriggers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')") : $"export/rlvmailer/qrtzcrontriggers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')", true);
        }

        public async Task ExportQrtzCronTriggersToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/rlvmailer/qrtzcrontriggers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')") : $"export/rlvmailer/qrtzcrontriggers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')", true);
        }

        partial void OnQrtzCronTriggersRead(ref IQueryable<Models.RlvMailer.QrtzCronTrigger> items);

        public async Task<IQueryable<Models.RlvMailer.QrtzCronTrigger>> GetQrtzCronTriggers(Query query = null)
        {
            var items = context.QrtzCronTriggers.AsQueryable();

            items = items.Include(i => i.QrtzTrigger);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    items = items.Where(query.Filter);
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnQrtzCronTriggersRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnQrtzCronTriggerCreated(Models.RlvMailer.QrtzCronTrigger item);

        public async Task<Models.RlvMailer.QrtzCronTrigger> CreateQrtzCronTrigger(Models.RlvMailer.QrtzCronTrigger qrtzCronTrigger)
        {
            OnQrtzCronTriggerCreated(qrtzCronTrigger);

            context.QrtzCronTriggers.Add(qrtzCronTrigger);
            context.SaveChanges();

            return qrtzCronTrigger;
        }
        public async Task ExportQrtzFiredTriggersToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/rlvmailer/qrtzfiredtriggers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')") : $"export/rlvmailer/qrtzfiredtriggers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')", true);
        }

        public async Task ExportQrtzFiredTriggersToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/rlvmailer/qrtzfiredtriggers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')") : $"export/rlvmailer/qrtzfiredtriggers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')", true);
        }

        partial void OnQrtzFiredTriggersRead(ref IQueryable<Models.RlvMailer.QrtzFiredTrigger> items);

        public async Task<IQueryable<Models.RlvMailer.QrtzFiredTrigger>> GetQrtzFiredTriggers(Query query = null)
        {
            var items = context.QrtzFiredTriggers.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    items = items.Where(query.Filter);
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnQrtzFiredTriggersRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnQrtzFiredTriggerCreated(Models.RlvMailer.QrtzFiredTrigger item);

        public async Task<Models.RlvMailer.QrtzFiredTrigger> CreateQrtzFiredTrigger(Models.RlvMailer.QrtzFiredTrigger qrtzFiredTrigger)
        {
            OnQrtzFiredTriggerCreated(qrtzFiredTrigger);

            context.QrtzFiredTriggers.Add(qrtzFiredTrigger);
            context.SaveChanges();

            return qrtzFiredTrigger;
        }
        public async Task ExportQrtzJobDetailsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/rlvmailer/qrtzjobdetails/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')") : $"export/rlvmailer/qrtzjobdetails/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')", true);
        }

        public async Task ExportQrtzJobDetailsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/rlvmailer/qrtzjobdetails/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')") : $"export/rlvmailer/qrtzjobdetails/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')", true);
        }

        partial void OnQrtzJobDetailsRead(ref IQueryable<Models.RlvMailer.QrtzJobDetail> items);

        public async Task<IQueryable<Models.RlvMailer.QrtzJobDetail>> GetQrtzJobDetails(Query query = null)
        {
            var items = context.QrtzJobDetails.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    items = items.Where(query.Filter);
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnQrtzJobDetailsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnQrtzJobDetailCreated(Models.RlvMailer.QrtzJobDetail item);

        public async Task<Models.RlvMailer.QrtzJobDetail> CreateQrtzJobDetail(Models.RlvMailer.QrtzJobDetail qrtzJobDetail)
        {
            OnQrtzJobDetailCreated(qrtzJobDetail);

            context.QrtzJobDetails.Add(qrtzJobDetail);
            context.SaveChanges();

            return qrtzJobDetail;
        }
        public async Task ExportQrtzLocksToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/rlvmailer/qrtzlocks/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')") : $"export/rlvmailer/qrtzlocks/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')", true);
        }

        public async Task ExportQrtzLocksToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/rlvmailer/qrtzlocks/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')") : $"export/rlvmailer/qrtzlocks/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')", true);
        }

        partial void OnQrtzLocksRead(ref IQueryable<Models.RlvMailer.QrtzLock> items);

        public async Task<IQueryable<Models.RlvMailer.QrtzLock>> GetQrtzLocks(Query query = null)
        {
            var items = context.QrtzLocks.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    items = items.Where(query.Filter);
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnQrtzLocksRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnQrtzLockCreated(Models.RlvMailer.QrtzLock item);

        public async Task<Models.RlvMailer.QrtzLock> CreateQrtzLock(Models.RlvMailer.QrtzLock qrtzLock)
        {
            OnQrtzLockCreated(qrtzLock);

            context.QrtzLocks.Add(qrtzLock);
            context.SaveChanges();

            return qrtzLock;
        }
        public async Task ExportQrtzPausedTriggerGrpsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/rlvmailer/qrtzpausedtriggergrps/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')") : $"export/rlvmailer/qrtzpausedtriggergrps/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')", true);
        }

        public async Task ExportQrtzPausedTriggerGrpsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/rlvmailer/qrtzpausedtriggergrps/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')") : $"export/rlvmailer/qrtzpausedtriggergrps/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')", true);
        }

        partial void OnQrtzPausedTriggerGrpsRead(ref IQueryable<Models.RlvMailer.QrtzPausedTriggerGrp> items);

        public async Task<IQueryable<Models.RlvMailer.QrtzPausedTriggerGrp>> GetQrtzPausedTriggerGrps(Query query = null)
        {
            var items = context.QrtzPausedTriggerGrps.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    items = items.Where(query.Filter);
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnQrtzPausedTriggerGrpsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnQrtzPausedTriggerGrpCreated(Models.RlvMailer.QrtzPausedTriggerGrp item);

        public async Task<Models.RlvMailer.QrtzPausedTriggerGrp> CreateQrtzPausedTriggerGrp(Models.RlvMailer.QrtzPausedTriggerGrp qrtzPausedTriggerGrp)
        {
            OnQrtzPausedTriggerGrpCreated(qrtzPausedTriggerGrp);

            context.QrtzPausedTriggerGrps.Add(qrtzPausedTriggerGrp);
            context.SaveChanges();

            return qrtzPausedTriggerGrp;
        }
        public async Task ExportQrtzSchedulerStatesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/rlvmailer/qrtzschedulerstates/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')") : $"export/rlvmailer/qrtzschedulerstates/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')", true);
        }

        public async Task ExportQrtzSchedulerStatesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/rlvmailer/qrtzschedulerstates/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')") : $"export/rlvmailer/qrtzschedulerstates/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')", true);
        }

        partial void OnQrtzSchedulerStatesRead(ref IQueryable<Models.RlvMailer.QrtzSchedulerState> items);

        public async Task<IQueryable<Models.RlvMailer.QrtzSchedulerState>> GetQrtzSchedulerStates(Query query = null)
        {
            var items = context.QrtzSchedulerStates.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    items = items.Where(query.Filter);
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnQrtzSchedulerStatesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnQrtzSchedulerStateCreated(Models.RlvMailer.QrtzSchedulerState item);

        public async Task<Models.RlvMailer.QrtzSchedulerState> CreateQrtzSchedulerState(Models.RlvMailer.QrtzSchedulerState qrtzSchedulerState)
        {
            OnQrtzSchedulerStateCreated(qrtzSchedulerState);

            context.QrtzSchedulerStates.Add(qrtzSchedulerState);
            context.SaveChanges();

            return qrtzSchedulerState;
        }
        public async Task ExportQrtzSimpleTriggersToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/rlvmailer/qrtzsimpletriggers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')") : $"export/rlvmailer/qrtzsimpletriggers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')", true);
        }

        public async Task ExportQrtzSimpleTriggersToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/rlvmailer/qrtzsimpletriggers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')") : $"export/rlvmailer/qrtzsimpletriggers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')", true);
        }

        partial void OnQrtzSimpleTriggersRead(ref IQueryable<Models.RlvMailer.QrtzSimpleTrigger> items);

        public async Task<IQueryable<Models.RlvMailer.QrtzSimpleTrigger>> GetQrtzSimpleTriggers(Query query = null)
        {
            var items = context.QrtzSimpleTriggers.AsQueryable();

            items = items.Include(i => i.QrtzTrigger);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    items = items.Where(query.Filter);
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnQrtzSimpleTriggersRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnQrtzSimpleTriggerCreated(Models.RlvMailer.QrtzSimpleTrigger item);

        public async Task<Models.RlvMailer.QrtzSimpleTrigger> CreateQrtzSimpleTrigger(Models.RlvMailer.QrtzSimpleTrigger qrtzSimpleTrigger)
        {
            OnQrtzSimpleTriggerCreated(qrtzSimpleTrigger);

            context.QrtzSimpleTriggers.Add(qrtzSimpleTrigger);
            context.SaveChanges();

            return qrtzSimpleTrigger;
        }
        public async Task ExportQrtzSimpropTriggersToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/rlvmailer/qrtzsimproptriggers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')") : $"export/rlvmailer/qrtzsimproptriggers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')", true);
        }

        public async Task ExportQrtzSimpropTriggersToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/rlvmailer/qrtzsimproptriggers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')") : $"export/rlvmailer/qrtzsimproptriggers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')", true);
        }

        partial void OnQrtzSimpropTriggersRead(ref IQueryable<Models.RlvMailer.QrtzSimpropTrigger> items);

        public async Task<IQueryable<Models.RlvMailer.QrtzSimpropTrigger>> GetQrtzSimpropTriggers(Query query = null)
        {
            var items = context.QrtzSimpropTriggers.AsQueryable();

            items = items.Include(i => i.QrtzTrigger);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    items = items.Where(query.Filter);
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnQrtzSimpropTriggersRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnQrtzSimpropTriggerCreated(Models.RlvMailer.QrtzSimpropTrigger item);

        public async Task<Models.RlvMailer.QrtzSimpropTrigger> CreateQrtzSimpropTrigger(Models.RlvMailer.QrtzSimpropTrigger qrtzSimpropTrigger)
        {
            OnQrtzSimpropTriggerCreated(qrtzSimpropTrigger);

            context.QrtzSimpropTriggers.Add(qrtzSimpropTrigger);
            context.SaveChanges();

            return qrtzSimpropTrigger;
        }
        public async Task ExportQrtzTriggersToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/rlvmailer/qrtztriggers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')") : $"export/rlvmailer/qrtztriggers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')", true);
        }

        public async Task ExportQrtzTriggersToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/rlvmailer/qrtztriggers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')") : $"export/rlvmailer/qrtztriggers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')", true);
        }

        partial void OnQrtzTriggersRead(ref IQueryable<Models.RlvMailer.QrtzTrigger> items);

        public async Task<IQueryable<Models.RlvMailer.QrtzTrigger>> GetQrtzTriggers(Query query = null)
        {
            var items = context.QrtzTriggers.AsQueryable();

            items = items.Include(i => i.QrtzJobDetail);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    items = items.Where(query.Filter);
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnQrtzTriggersRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnQrtzTriggerCreated(Models.RlvMailer.QrtzTrigger item);

        public async Task<Models.RlvMailer.QrtzTrigger> CreateQrtzTrigger(Models.RlvMailer.QrtzTrigger qrtzTrigger)
        {
            OnQrtzTriggerCreated(qrtzTrigger);

            context.QrtzTriggers.Add(qrtzTrigger);
            context.SaveChanges();

            return qrtzTrigger;
        }
        public async Task ExportQsVirtualProxiesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/rlvmailer/qsvirtualproxies/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')") : $"export/rlvmailer/qsvirtualproxies/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')", true);
        }

        public async Task ExportQsVirtualProxiesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/rlvmailer/qsvirtualproxies/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')") : $"export/rlvmailer/qsvirtualproxies/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')", true);
        }

        partial void OnQsVirtualProxiesRead(ref IQueryable<Models.RlvMailer.QsVirtualProxy> items);

        public async Task<IQueryable<Models.RlvMailer.QsVirtualProxy>> GetQsVirtualProxies(Query query = null)
        {
            var items = context.QsVirtualProxies.AsQueryable();

            items = items.Include(i => i.Q);

            items = items.Include(i => i.AuthMethod);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    items = items.Where(query.Filter);
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnQsVirtualProxiesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnQsVirtualProxyCreated(Models.RlvMailer.QsVirtualProxy item);

        public async Task<Models.RlvMailer.QsVirtualProxy> CreateQsVirtualProxy(Models.RlvMailer.QsVirtualProxy qsVirtualProxy)
        {
            OnQsVirtualProxyCreated(qsVirtualProxy);

            context.QsVirtualProxies.Add(qsVirtualProxy);
            context.SaveChanges();

            return qsVirtualProxy;
        }
        public async Task ExportReportsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/rlvmailer/reports/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')") : $"export/rlvmailer/reports/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')", true);
        }

        public async Task ExportReportsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/rlvmailer/reports/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')") : $"export/rlvmailer/reports/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')", true);
        }

        partial void OnReportsRead(ref IQueryable<Models.RlvMailer.Report> items);

        public async Task<IQueryable<Models.RlvMailer.Report>> GetReports(Query query = null)
        {
            var items = context.Reports.AsQueryable();

            items = items.Include(i => i.Setting);

            items = items.Include(i => i.Mail);

            items = items.Include(i => i.Q);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    items = items.Where(query.Filter);
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnReportsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnReportCreated(Models.RlvMailer.Report item);

        public async Task<Models.RlvMailer.Report> CreateReport(Models.RlvMailer.Report report)
        {
            OnReportCreated(report);

            context.Reports.Add(report);
            context.SaveChanges();

            return report;
        }
        public async Task ExportReportLinesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/rlvmailer/reportlines/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')") : $"export/rlvmailer/reportlines/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')", true);
        }

        public async Task ExportReportLinesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/rlvmailer/reportlines/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')") : $"export/rlvmailer/reportlines/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')", true);
        }

        partial void OnReportLinesRead(ref IQueryable<Models.RlvMailer.ReportLine> items);

        public async Task<IQueryable<Models.RlvMailer.ReportLine>> GetReportLines(Query query = null)
        {
            var items = context.ReportLines.AsQueryable();

            items = items.Include(i => i.Report);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    items = items.Where(query.Filter);
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnReportLinesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnReportLineCreated(Models.RlvMailer.ReportLine item);

        public async Task<Models.RlvMailer.ReportLine> CreateReportLine(Models.RlvMailer.ReportLine reportLine)
        {
            OnReportLineCreated(reportLine);

            context.ReportLines.Add(reportLine);
            context.SaveChanges();

            return reportLine;
        }
        public async Task ExportReportLineImgsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/rlvmailer/reportlineimgs/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')") : $"export/rlvmailer/reportlineimgs/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')", true);
        }

        public async Task ExportReportLineImgsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/rlvmailer/reportlineimgs/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')") : $"export/rlvmailer/reportlineimgs/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')", true);
        }

        partial void OnReportLineImgsRead(ref IQueryable<Models.RlvMailer.ReportLineImg> items);

        public async Task<IQueryable<Models.RlvMailer.ReportLineImg>> GetReportLineImgs(Query query = null)
        {
            var items = context.ReportLineImgs.AsQueryable();

            items = items.Include(i => i.ReportLine);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    items = items.Where(query.Filter);
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnReportLineImgsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnReportLineImgCreated(Models.RlvMailer.ReportLineImg item);

        public async Task<Models.RlvMailer.ReportLineImg> CreateReportLineImg(Models.RlvMailer.ReportLineImg reportLineImg)
        {
            OnReportLineImgCreated(reportLineImg);

            context.ReportLineImgs.Add(reportLineImg);
            context.SaveChanges();

            return reportLineImg;
        }
        public async Task ExportReportLineTextsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/rlvmailer/reportlinetexts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')") : $"export/rlvmailer/reportlinetexts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')", true);
        }

        public async Task ExportReportLineTextsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/rlvmailer/reportlinetexts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')") : $"export/rlvmailer/reportlinetexts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')", true);
        }

        partial void OnReportLineTextsRead(ref IQueryable<Models.RlvMailer.ReportLineText> items);

        public async Task<IQueryable<Models.RlvMailer.ReportLineText>> GetReportLineTexts(Query query = null)
        {
            var items = context.ReportLineTexts.AsQueryable();

            items = items.Include(i => i.ReportLine);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    items = items.Where(query.Filter);
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnReportLineTextsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnReportLineTextCreated(Models.RlvMailer.ReportLineText item);

        public async Task<Models.RlvMailer.ReportLineText> CreateReportLineText(Models.RlvMailer.ReportLineText reportLineText)
        {
            OnReportLineTextCreated(reportLineText);

            context.ReportLineTexts.Add(reportLineText);
            context.SaveChanges();

            return reportLineText;
        }
        public async Task ExportReportLineXlsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/rlvmailer/reportlinexls/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')") : $"export/rlvmailer/reportlinexls/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')", true);
        }

        public async Task ExportReportLineXlsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/rlvmailer/reportlinexls/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')") : $"export/rlvmailer/reportlinexls/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')", true);
        }

        partial void OnReportLineXlsRead(ref IQueryable<Models.RlvMailer.ReportLineXl> items);

        public async Task<IQueryable<Models.RlvMailer.ReportLineXl>> GetReportLineXls(Query query = null)
        {
            var items = context.ReportLineXls.AsQueryable();

            items = items.Include(i => i.ReportLine);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    items = items.Where(query.Filter);
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnReportLineXlsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnReportLineXlCreated(Models.RlvMailer.ReportLineXl item);

        public async Task<Models.RlvMailer.ReportLineXl> CreateReportLineXl(Models.RlvMailer.ReportLineXl reportLineXl)
        {
            OnReportLineXlCreated(reportLineXl);

            context.ReportLineXls.Add(reportLineXl);
            context.SaveChanges();

            return reportLineXl;
        }
        public async Task ExportReportSelectionsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/rlvmailer/reportselections/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')") : $"export/rlvmailer/reportselections/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')", true);
        }

        public async Task ExportReportSelectionsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/rlvmailer/reportselections/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')") : $"export/rlvmailer/reportselections/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')", true);
        }

        partial void OnReportSelectionsRead(ref IQueryable<Models.RlvMailer.ReportSelection> items);

        public async Task<IQueryable<Models.RlvMailer.ReportSelection>> GetReportSelections(Query query = null)
        {
            var items = context.ReportSelections.AsQueryable();

            items = items.Include(i => i.Report);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    items = items.Where(query.Filter);
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnReportSelectionsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnReportSelectionCreated(Models.RlvMailer.ReportSelection item);

        public async Task<Models.RlvMailer.ReportSelection> CreateReportSelection(Models.RlvMailer.ReportSelection reportSelection)
        {
            OnReportSelectionCreated(reportSelection);

            context.ReportSelections.Add(reportSelection);
            context.SaveChanges();

            return reportSelection;
        }
        public async Task ExportReportSelectionsDatesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/rlvmailer/reportselectionsdates/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')") : $"export/rlvmailer/reportselectionsdates/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')", true);
        }

        public async Task ExportReportSelectionsDatesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/rlvmailer/reportselectionsdates/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')") : $"export/rlvmailer/reportselectionsdates/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')", true);
        }

        partial void OnReportSelectionsDatesRead(ref IQueryable<Models.RlvMailer.ReportSelectionsDate> items);

        public async Task<IQueryable<Models.RlvMailer.ReportSelectionsDate>> GetReportSelectionsDates(Query query = null)
        {
            var items = context.ReportSelectionsDates.AsQueryable();

            items = items.Include(i => i.Report);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    items = items.Where(query.Filter);
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnReportSelectionsDatesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnReportSelectionsDateCreated(Models.RlvMailer.ReportSelectionsDate item);

        public async Task<Models.RlvMailer.ReportSelectionsDate> CreateReportSelectionsDate(Models.RlvMailer.ReportSelectionsDate reportSelectionsDate)
        {
            OnReportSelectionsDateCreated(reportSelectionsDate);

            context.ReportSelectionsDates.Add(reportSelectionsDate);
            context.SaveChanges();

            return reportSelectionsDate;
        }
        public async Task ExportReportSelectionsDateOverridesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/rlvmailer/reportselectionsdateoverrides/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')") : $"export/rlvmailer/reportselectionsdateoverrides/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')", true);
        }

        public async Task ExportReportSelectionsDateOverridesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/rlvmailer/reportselectionsdateoverrides/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')") : $"export/rlvmailer/reportselectionsdateoverrides/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')", true);
        }

        partial void OnReportSelectionsDateOverridesRead(ref IQueryable<Models.RlvMailer.ReportSelectionsDateOverride> items);

        public async Task<IQueryable<Models.RlvMailer.ReportSelectionsDateOverride>> GetReportSelectionsDateOverrides(Query query = null)
        {
            var items = context.ReportSelectionsDateOverrides.AsQueryable();

            items = items.Include(i => i.Report);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    items = items.Where(query.Filter);
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnReportSelectionsDateOverridesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnReportSelectionsDateOverrideCreated(Models.RlvMailer.ReportSelectionsDateOverride item);

        public async Task<Models.RlvMailer.ReportSelectionsDateOverride> CreateReportSelectionsDateOverride(Models.RlvMailer.ReportSelectionsDateOverride reportSelectionsDateOverride)
        {
            OnReportSelectionsDateOverrideCreated(reportSelectionsDateOverride);

            context.ReportSelectionsDateOverrides.Add(reportSelectionsDateOverride);
            context.SaveChanges();

            return reportSelectionsDateOverride;
        }
        public async Task ExportReportsExecConditionsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/rlvmailer/reportsexecconditions/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')") : $"export/rlvmailer/reportsexecconditions/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')", true);
        }

        public async Task ExportReportsExecConditionsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/rlvmailer/reportsexecconditions/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')") : $"export/rlvmailer/reportsexecconditions/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')", true);
        }

        partial void OnReportsExecConditionsRead(ref IQueryable<Models.RlvMailer.ReportsExecCondition> items);

        public async Task<IQueryable<Models.RlvMailer.ReportsExecCondition>> GetReportsExecConditions(Query query = null)
        {
            var items = context.ReportsExecConditions.AsQueryable();

            items = items.Include(i => i.Report);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    items = items.Where(query.Filter);
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnReportsExecConditionsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnReportsExecConditionCreated(Models.RlvMailer.ReportsExecCondition item);

        public async Task<Models.RlvMailer.ReportsExecCondition> CreateReportsExecCondition(Models.RlvMailer.ReportsExecCondition reportsExecCondition)
        {
            OnReportsExecConditionCreated(reportsExecCondition);

            context.ReportsExecConditions.Add(reportsExecCondition);
            context.SaveChanges();

            return reportsExecCondition;
        }
        public async Task ExportSettingsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/rlvmailer/settings/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')") : $"export/rlvmailer/settings/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')", true);
        }

        public async Task ExportSettingsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/rlvmailer/settings/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')") : $"export/rlvmailer/settings/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')", true);
        }

        partial void OnSettingsRead(ref IQueryable<Models.RlvMailer.Setting> items);

        public async Task<IQueryable<Models.RlvMailer.Setting>> GetSettings(Query query = null)
        {
            var items = context.Settings.AsQueryable();

            items = items.Include(i => i.Country);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    items = items.Where(query.Filter);
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnSettingsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnSettingCreated(Models.RlvMailer.Setting item);

        public async Task<Models.RlvMailer.Setting> CreateSetting(Models.RlvMailer.Setting setting)
        {
            OnSettingCreated(setting);

            context.Settings.Add(setting);
            context.SaveChanges();

            return setting;
        }
        public async Task ExportTagsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/rlvmailer/tags/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')") : $"export/rlvmailer/tags/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')", true);
        }

        public async Task ExportTagsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/rlvmailer/tags/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')") : $"export/rlvmailer/tags/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')", true);
        }

        partial void OnTagsRead(ref IQueryable<Models.RlvMailer.Tag> items);

        public async Task<IQueryable<Models.RlvMailer.Tag>> GetTags(Query query = null)
        {
            var items = context.Tags.AsQueryable();

            items = items.Include(i => i.Report);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    items = items.Where(query.Filter);
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnTagsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTagCreated(Models.RlvMailer.Tag item);

        public async Task<Models.RlvMailer.Tag> CreateTag(Models.RlvMailer.Tag tag)
        {
            OnTagCreated(tag);

            context.Tags.Add(tag);
            context.SaveChanges();

            return tag;
        }

        partial void OnActiuniDeleted(Models.RlvMailer.Actiuni item);

        public async Task<Models.RlvMailer.Actiuni> DeleteActiuni(int? idApp, DateTime? dataActiune)
        {
            var item = context.Actiunis
                              .Where(i => i.id_app == idApp && i.data_actiune == dataActiune)
                              .FirstOrDefault();

            if (item == null)
            {
               throw new Exception("Item no longer available");
            }

            OnActiuniDeleted(item);

            context.Actiunis.Remove(item);

            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                context.Entry(item).State = EntityState.Unchanged;
                throw ex;
            }

            return item;
        }

        partial void OnActiuniGet(Models.RlvMailer.Actiuni item);

        public async Task<Models.RlvMailer.Actiuni> GetActiuniByIdAppAndDataActiune(int? idApp, DateTime? dataActiune)
        {
            var items = context.Actiunis
                              .AsNoTracking()
                              .Where(i => i.id_app == idApp && i.data_actiune == dataActiune);

            var item = items.FirstOrDefault();

            OnActiuniGet(item);

            return await Task.FromResult(item);
        }

        public async Task<Models.RlvMailer.Actiuni> CancelActiuniChanges(Models.RlvMailer.Actiuni item)
        {
            var entity = context.Entry(item);
            entity.CurrentValues.SetValues(entity.OriginalValues);
            entity.State = EntityState.Unchanged;

            return item;
        }

        partial void OnActiuniUpdated(Models.RlvMailer.Actiuni item);

        public async Task<Models.RlvMailer.Actiuni> UpdateActiuni(int? idApp, DateTime? dataActiune, Models.RlvMailer.Actiuni actiuni)
        {
            OnActiuniUpdated(actiuni);

            var item = context.Actiunis
                              .Where(i => i.id_app == idApp && i.data_actiune == dataActiune)
                              .FirstOrDefault();
            if (item == null)
            {
               throw new Exception("Item no longer available");
            }
            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(actiuni);
            entry.State = EntityState.Modified;
            context.SaveChanges();

            return actiuni;
        }

        partial void OnAuthMethodDeleted(Models.RlvMailer.AuthMethod item);

        public async Task<Models.RlvMailer.AuthMethod> DeleteAuthMethod(int? authMethodId)
        {
            var item = context.AuthMethods
                              .Where(i => i.auth_method_id == authMethodId)
                              .Include(i => i.QsVirtualProxies)
                              .FirstOrDefault();

            if (item == null)
            {
               throw new Exception("Item no longer available");
            }

            OnAuthMethodDeleted(item);

            context.AuthMethods.Remove(item);

            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                context.Entry(item).State = EntityState.Unchanged;
                throw ex;
            }

            return item;
        }

        partial void OnAuthMethodGet(Models.RlvMailer.AuthMethod item);

        public async Task<Models.RlvMailer.AuthMethod> GetAuthMethodByauthMethodId(int? authMethodId)
        {
            var items = context.AuthMethods
                              .AsNoTracking()
                              .Where(i => i.auth_method_id == authMethodId);

            var item = items.FirstOrDefault();

            OnAuthMethodGet(item);

            return await Task.FromResult(item);
        }

        public async Task<Models.RlvMailer.AuthMethod> CancelAuthMethodChanges(Models.RlvMailer.AuthMethod item)
        {
            var entity = context.Entry(item);
            entity.CurrentValues.SetValues(entity.OriginalValues);
            entity.State = EntityState.Unchanged;

            return item;
        }

        partial void OnAuthMethodUpdated(Models.RlvMailer.AuthMethod item);

        public async Task<Models.RlvMailer.AuthMethod> UpdateAuthMethod(int? authMethodId, Models.RlvMailer.AuthMethod authMethod)
        {
            OnAuthMethodUpdated(authMethod);

            var item = context.AuthMethods
                              .Where(i => i.auth_method_id == authMethodId)
                              .FirstOrDefault();
            if (item == null)
            {
               throw new Exception("Item no longer available");
            }
            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(authMethod);
            entry.State = EntityState.Modified;
            context.SaveChanges();

            return authMethod;
        }

        partial void OnCountryDeleted(Models.RlvMailer.Country item);

        public async Task<Models.RlvMailer.Country> DeleteCountry(int? code)
        {
            var item = context.Countries
                              .Where(i => i.code == code)
                              .Include(i => i.Settings)
                              .FirstOrDefault();

            if (item == null)
            {
               throw new Exception("Item no longer available");
            }

            OnCountryDeleted(item);

            context.Countries.Remove(item);

            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                context.Entry(item).State = EntityState.Unchanged;
                throw ex;
            }

            return item;
        }

        partial void OnCountryGet(Models.RlvMailer.Country item);

        public async Task<Models.RlvMailer.Country> GetCountryBycode(int? code)
        {
            var items = context.Countries
                              .AsNoTracking()
                              .Where(i => i.code == code);

            var item = items.FirstOrDefault();

            OnCountryGet(item);

            return await Task.FromResult(item);
        }

        public async Task<Models.RlvMailer.Country> CancelCountryChanges(Models.RlvMailer.Country item)
        {
            var entity = context.Entry(item);
            entity.CurrentValues.SetValues(entity.OriginalValues);
            entity.State = EntityState.Unchanged;

            return item;
        }

        partial void OnCountryUpdated(Models.RlvMailer.Country item);

        public async Task<Models.RlvMailer.Country> UpdateCountry(int? code, Models.RlvMailer.Country country)
        {
            OnCountryUpdated(country);

            var item = context.Countries
                              .Where(i => i.code == code)
                              .FirstOrDefault();
            if (item == null)
            {
               throw new Exception("Item no longer available");
            }
            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(country);
            entry.State = EntityState.Modified;
            context.SaveChanges();

            return country;
        }

        partial void OnExternalEmailDeleted(Models.RlvMailer.ExternalEmail item);

        public async Task<Models.RlvMailer.ExternalEmail> DeleteExternalEmail(int? externalEmailId)
        {
            var item = context.ExternalEmails
                              .Where(i => i.external_email_id == externalEmailId)
                              .FirstOrDefault();

            if (item == null)
            {
               throw new Exception("Item no longer available");
            }

            OnExternalEmailDeleted(item);

            context.ExternalEmails.Remove(item);

            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                context.Entry(item).State = EntityState.Unchanged;
                throw ex;
            }

            return item;
        }

        partial void OnExternalEmailGet(Models.RlvMailer.ExternalEmail item);

        public async Task<Models.RlvMailer.ExternalEmail> GetExternalEmailByexternalEmailId(int? externalEmailId)
        {
            var items = context.ExternalEmails
                              .AsNoTracking()
                              .Where(i => i.external_email_id == externalEmailId);

            items = items.Include(i => i.Report);

            var item = items.FirstOrDefault();

            OnExternalEmailGet(item);

            return await Task.FromResult(item);
        }

        public async Task<Models.RlvMailer.ExternalEmail> CancelExternalEmailChanges(Models.RlvMailer.ExternalEmail item)
        {
            var entity = context.Entry(item);
            entity.CurrentValues.SetValues(entity.OriginalValues);
            entity.State = EntityState.Unchanged;

            return item;
        }

        partial void OnExternalEmailUpdated(Models.RlvMailer.ExternalEmail item);

        public async Task<Models.RlvMailer.ExternalEmail> UpdateExternalEmail(int? externalEmailId, Models.RlvMailer.ExternalEmail externalEmail)
        {
            OnExternalEmailUpdated(externalEmail);

            var item = context.ExternalEmails
                              .Where(i => i.external_email_id == externalEmailId)
                              .FirstOrDefault();
            if (item == null)
            {
               throw new Exception("Item no longer available");
            }
            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(externalEmail);
            entry.State = EntityState.Modified;
            context.SaveChanges();

            return externalEmail;
        }

        partial void OnLogAppDeleted(Models.RlvMailer.LogApp item);

        public async Task<Models.RlvMailer.LogApp> DeleteLogApp(int? id)
        {
            var item = context.LogApps
                              .Where(i => i.id == id)
                              .FirstOrDefault();

            if (item == null)
            {
               throw new Exception("Item no longer available");
            }

            OnLogAppDeleted(item);

            context.LogApps.Remove(item);

            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                context.Entry(item).State = EntityState.Unchanged;
                throw ex;
            }

            return item;
        }

        partial void OnLogAppGet(Models.RlvMailer.LogApp item);

        public async Task<Models.RlvMailer.LogApp> GetLogAppByid(int? id)
        {
            var items = context.LogApps
                              .AsNoTracking()
                              .Where(i => i.id == id);

            var item = items.FirstOrDefault();

            OnLogAppGet(item);

            return await Task.FromResult(item);
        }

        public async Task<Models.RlvMailer.LogApp> CancelLogAppChanges(Models.RlvMailer.LogApp item)
        {
            var entity = context.Entry(item);
            entity.CurrentValues.SetValues(entity.OriginalValues);
            entity.State = EntityState.Unchanged;

            return item;
        }

        partial void OnLogAppUpdated(Models.RlvMailer.LogApp item);

        public async Task<Models.RlvMailer.LogApp> UpdateLogApp(int? id, Models.RlvMailer.LogApp logApp)
        {
            OnLogAppUpdated(logApp);

            var item = context.LogApps
                              .Where(i => i.id == id)
                              .FirstOrDefault();
            if (item == null)
            {
               throw new Exception("Item no longer available");
            }
            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(logApp);
            entry.State = EntityState.Modified;
            context.SaveChanges();

            return logApp;
        }

        partial void OnLogEventDeleted(Models.RlvMailer.LogEvent item);

        public async Task<Models.RlvMailer.LogEvent> DeleteLogEvent(int? id)
        {
            var item = context.LogEvents
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (item == null)
            {
               throw new Exception("Item no longer available");
            }

            OnLogEventDeleted(item);

            context.LogEvents.Remove(item);

            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                context.Entry(item).State = EntityState.Unchanged;
                throw ex;
            }

            return item;
        }

        partial void OnLogEventGet(Models.RlvMailer.LogEvent item);

        public async Task<Models.RlvMailer.LogEvent> GetLogEventById(int? id)
        {
            var items = context.LogEvents
                              .AsNoTracking()
                              .Where(i => i.Id == id);

            var item = items.FirstOrDefault();

            OnLogEventGet(item);

            return await Task.FromResult(item);
        }

        public async Task<Models.RlvMailer.LogEvent> CancelLogEventChanges(Models.RlvMailer.LogEvent item)
        {
            var entity = context.Entry(item);
            entity.CurrentValues.SetValues(entity.OriginalValues);
            entity.State = EntityState.Unchanged;

            return item;
        }

        partial void OnLogEventUpdated(Models.RlvMailer.LogEvent item);

        public async Task<Models.RlvMailer.LogEvent> UpdateLogEvent(int? id, Models.RlvMailer.LogEvent logEvent)
        {
            OnLogEventUpdated(logEvent);

            var item = context.LogEvents
                              .Where(i => i.Id == id)
                              .FirstOrDefault();
            if (item == null)
            {
               throw new Exception("Item no longer available");
            }
            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(logEvent);
            entry.State = EntityState.Modified;
            context.SaveChanges();

            return logEvent;
        }

        partial void OnLogReportDeleted(Models.RlvMailer.LogReport item);

        public async Task<Models.RlvMailer.LogReport> DeleteLogReport(int? id)
        {
            var item = context.LogReports
                              .Where(i => i.id == id)
                              .FirstOrDefault();

            if (item == null)
            {
               throw new Exception("Item no longer available");
            }

            OnLogReportDeleted(item);

            context.LogReports.Remove(item);

            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                context.Entry(item).State = EntityState.Unchanged;
                throw ex;
            }

            return item;
        }

        partial void OnLogReportGet(Models.RlvMailer.LogReport item);

        public async Task<Models.RlvMailer.LogReport> GetLogReportByid(int? id)
        {
            var items = context.LogReports
                              .AsNoTracking()
                              .Where(i => i.id == id);

            items = items.Include(i => i.Report);

            var item = items.FirstOrDefault();

            OnLogReportGet(item);

            return await Task.FromResult(item);
        }

        public async Task<Models.RlvMailer.LogReport> CancelLogReportChanges(Models.RlvMailer.LogReport item)
        {
            var entity = context.Entry(item);
            entity.CurrentValues.SetValues(entity.OriginalValues);
            entity.State = EntityState.Unchanged;

            return item;
        }

        partial void OnLogReportUpdated(Models.RlvMailer.LogReport item);

        public async Task<Models.RlvMailer.LogReport> UpdateLogReport(int? id, Models.RlvMailer.LogReport logReport)
        {
            OnLogReportUpdated(logReport);

            var item = context.LogReports
                              .Where(i => i.id == id)
                              .FirstOrDefault();
            if (item == null)
            {
               throw new Exception("Item no longer available");
            }
            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(logReport);
            entry.State = EntityState.Modified;
            context.SaveChanges();

            return logReport;
        }

        partial void OnMailDeleted(Models.RlvMailer.Mail item);

        public async Task<Models.RlvMailer.Mail> DeleteMail(int? srvMailId)
        {
            var item = context.Mails
                              .Where(i => i.srv_mail_id == srvMailId)
                              .Include(i => i.Reports)
                              .FirstOrDefault();

            if (item == null)
            {
               throw new Exception("Item no longer available");
            }

            OnMailDeleted(item);

            context.Mails.Remove(item);

            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                context.Entry(item).State = EntityState.Unchanged;
                throw ex;
            }

            return item;
        }

        partial void OnMailGet(Models.RlvMailer.Mail item);

        public async Task<Models.RlvMailer.Mail> GetMailBysrvMailId(int? srvMailId)
        {
            var items = context.Mails
                              .AsNoTracking()
                              .Where(i => i.srv_mail_id == srvMailId);

            var item = items.FirstOrDefault();

            OnMailGet(item);

            return await Task.FromResult(item);
        }

        public async Task<Models.RlvMailer.Mail> CancelMailChanges(Models.RlvMailer.Mail item)
        {
            var entity = context.Entry(item);
            entity.CurrentValues.SetValues(entity.OriginalValues);
            entity.State = EntityState.Unchanged;

            return item;
        }

        partial void OnMailUpdated(Models.RlvMailer.Mail item);

        public async Task<Models.RlvMailer.Mail> UpdateMail(int? srvMailId, Models.RlvMailer.Mail mail)
        {
            OnMailUpdated(mail);

            var item = context.Mails
                              .Where(i => i.srv_mail_id == srvMailId)
                              .FirstOrDefault();
            if (item == null)
            {
               throw new Exception("Item no longer available");
            }
            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(mail);
            entry.State = EntityState.Modified;
            context.SaveChanges();

            return mail;
        }

        partial void OnQDeleted(Models.RlvMailer.Q item);

        public async Task<Models.RlvMailer.Q> DeleteQ(int? qsId)
        {
            var item = context.Qs
                              .Where(i => i.qs_id == qsId)
                              .Include(i => i.Reports)
                              .Include(i => i.QsVirtualProxies)
                              .FirstOrDefault();

            if (item == null)
            {
               throw new Exception("Item no longer available");
            }

            OnQDeleted(item);

            context.Qs.Remove(item);

            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                context.Entry(item).State = EntityState.Unchanged;
                throw ex;
            }

            return item;
        }

        partial void OnQGet(Models.RlvMailer.Q item);

        public async Task<Models.RlvMailer.Q> GetQByqsId(int? qsId)
        {
            var items = context.Qs
                              .AsNoTracking()
                              .Where(i => i.qs_id == qsId);

            var item = items.FirstOrDefault();

            OnQGet(item);

            return await Task.FromResult(item);
        }

        public async Task<Models.RlvMailer.Q> CancelQChanges(Models.RlvMailer.Q item)
        {
            var entity = context.Entry(item);
            entity.CurrentValues.SetValues(entity.OriginalValues);
            entity.State = EntityState.Unchanged;

            return item;
        }

        partial void OnQUpdated(Models.RlvMailer.Q item);

        public async Task<Models.RlvMailer.Q> UpdateQ(int? qsId, Models.RlvMailer.Q q)
        {
            OnQUpdated(q);

            var item = context.Qs
                              .Where(i => i.qs_id == qsId)
                              .FirstOrDefault();
            if (item == null)
            {
               throw new Exception("Item no longer available");
            }
            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(q);
            entry.State = EntityState.Modified;
            context.SaveChanges();

            return q;
        }

        partial void OnQrtzBlobTriggerDeleted(Models.RlvMailer.QrtzBlobTrigger item);

        public async Task<Models.RlvMailer.QrtzBlobTrigger> DeleteQrtzBlobTrigger(string schedName, string triggerName, string triggerGroup)
        {
            var item = context.QrtzBlobTriggers
                              .Where(i => i.SCHED_NAME == schedName && i.TRIGGER_NAME == triggerName && i.TRIGGER_GROUP == triggerGroup)
                              .FirstOrDefault();

            if (item == null)
            {
               throw new Exception("Item no longer available");
            }

            OnQrtzBlobTriggerDeleted(item);

            context.QrtzBlobTriggers.Remove(item);

            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                context.Entry(item).State = EntityState.Unchanged;
                throw ex;
            }

            return item;
        }

        partial void OnQrtzBlobTriggerGet(Models.RlvMailer.QrtzBlobTrigger item);

        public async Task<Models.RlvMailer.QrtzBlobTrigger> GetQrtzBlobTriggerBySchedNameAndTriggerNameAndTriggerGroup(string schedName, string triggerName, string triggerGroup)
        {
            var items = context.QrtzBlobTriggers
                              .AsNoTracking()
                              .Where(i => i.SCHED_NAME == schedName && i.TRIGGER_NAME == triggerName && i.TRIGGER_GROUP == triggerGroup);

            var item = items.FirstOrDefault();

            OnQrtzBlobTriggerGet(item);

            return await Task.FromResult(item);
        }

        public async Task<Models.RlvMailer.QrtzBlobTrigger> CancelQrtzBlobTriggerChanges(Models.RlvMailer.QrtzBlobTrigger item)
        {
            var entity = context.Entry(item);
            entity.CurrentValues.SetValues(entity.OriginalValues);
            entity.State = EntityState.Unchanged;

            return item;
        }

        partial void OnQrtzBlobTriggerUpdated(Models.RlvMailer.QrtzBlobTrigger item);

        public async Task<Models.RlvMailer.QrtzBlobTrigger> UpdateQrtzBlobTrigger(string schedName, string triggerName, string triggerGroup, Models.RlvMailer.QrtzBlobTrigger qrtzBlobTrigger)
        {
            OnQrtzBlobTriggerUpdated(qrtzBlobTrigger);

            var item = context.QrtzBlobTriggers
                              .Where(i => i.SCHED_NAME == schedName && i.TRIGGER_NAME == triggerName && i.TRIGGER_GROUP == triggerGroup)
                              .FirstOrDefault();
            if (item == null)
            {
               throw new Exception("Item no longer available");
            }
            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(qrtzBlobTrigger);
            entry.State = EntityState.Modified;
            context.SaveChanges();

            return qrtzBlobTrigger;
        }

        partial void OnQrtzCalendarDeleted(Models.RlvMailer.QrtzCalendar item);

        public async Task<Models.RlvMailer.QrtzCalendar> DeleteQrtzCalendar(string schedName, string calendarName)
        {
            var item = context.QrtzCalendars
                              .Where(i => i.SCHED_NAME == schedName && i.CALENDAR_NAME == calendarName)
                              .FirstOrDefault();

            if (item == null)
            {
               throw new Exception("Item no longer available");
            }

            OnQrtzCalendarDeleted(item);

            context.QrtzCalendars.Remove(item);

            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                context.Entry(item).State = EntityState.Unchanged;
                throw ex;
            }

            return item;
        }

        partial void OnQrtzCalendarGet(Models.RlvMailer.QrtzCalendar item);

        public async Task<Models.RlvMailer.QrtzCalendar> GetQrtzCalendarBySchedNameAndCalendarName(string schedName, string calendarName)
        {
            var items = context.QrtzCalendars
                              .AsNoTracking()
                              .Where(i => i.SCHED_NAME == schedName && i.CALENDAR_NAME == calendarName);

            var item = items.FirstOrDefault();

            OnQrtzCalendarGet(item);

            return await Task.FromResult(item);
        }

        public async Task<Models.RlvMailer.QrtzCalendar> CancelQrtzCalendarChanges(Models.RlvMailer.QrtzCalendar item)
        {
            var entity = context.Entry(item);
            entity.CurrentValues.SetValues(entity.OriginalValues);
            entity.State = EntityState.Unchanged;

            return item;
        }

        partial void OnQrtzCalendarUpdated(Models.RlvMailer.QrtzCalendar item);

        public async Task<Models.RlvMailer.QrtzCalendar> UpdateQrtzCalendar(string schedName, string calendarName, Models.RlvMailer.QrtzCalendar qrtzCalendar)
        {
            OnQrtzCalendarUpdated(qrtzCalendar);

            var item = context.QrtzCalendars
                              .Where(i => i.SCHED_NAME == schedName && i.CALENDAR_NAME == calendarName)
                              .FirstOrDefault();
            if (item == null)
            {
               throw new Exception("Item no longer available");
            }
            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(qrtzCalendar);
            entry.State = EntityState.Modified;
            context.SaveChanges();

            return qrtzCalendar;
        }

        partial void OnQrtzCronTriggerDeleted(Models.RlvMailer.QrtzCronTrigger item);

        public async Task<Models.RlvMailer.QrtzCronTrigger> DeleteQrtzCronTrigger(string schedName, string triggerName, string triggerGroup)
        {
            var item = context.QrtzCronTriggers
                              .Where(i => i.SCHED_NAME == schedName && i.TRIGGER_NAME == triggerName && i.TRIGGER_GROUP == triggerGroup)
                              .FirstOrDefault();

            if (item == null)
            {
               throw new Exception("Item no longer available");
            }

            OnQrtzCronTriggerDeleted(item);

            context.QrtzCronTriggers.Remove(item);

            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                context.Entry(item).State = EntityState.Unchanged;
                throw ex;
            }

            return item;
        }

        partial void OnQrtzCronTriggerGet(Models.RlvMailer.QrtzCronTrigger item);

        public async Task<Models.RlvMailer.QrtzCronTrigger> GetQrtzCronTriggerBySchedNameAndTriggerNameAndTriggerGroup(string schedName, string triggerName, string triggerGroup)
        {
            var items = context.QrtzCronTriggers
                              .AsNoTracking()
                              .Where(i => i.SCHED_NAME == schedName && i.TRIGGER_NAME == triggerName && i.TRIGGER_GROUP == triggerGroup);

            items = items.Include(i => i.QrtzTrigger);

            var item = items.FirstOrDefault();

            OnQrtzCronTriggerGet(item);

            return await Task.FromResult(item);
        }

        public async Task<Models.RlvMailer.QrtzCronTrigger> CancelQrtzCronTriggerChanges(Models.RlvMailer.QrtzCronTrigger item)
        {
            var entity = context.Entry(item);
            entity.CurrentValues.SetValues(entity.OriginalValues);
            entity.State = EntityState.Unchanged;

            return item;
        }

        partial void OnQrtzCronTriggerUpdated(Models.RlvMailer.QrtzCronTrigger item);

        public async Task<Models.RlvMailer.QrtzCronTrigger> UpdateQrtzCronTrigger(string schedName, string triggerName, string triggerGroup, Models.RlvMailer.QrtzCronTrigger qrtzCronTrigger)
        {
            OnQrtzCronTriggerUpdated(qrtzCronTrigger);

            var item = context.QrtzCronTriggers
                              .Where(i => i.SCHED_NAME == schedName && i.TRIGGER_NAME == triggerName && i.TRIGGER_GROUP == triggerGroup)
                              .FirstOrDefault();
            if (item == null)
            {
               throw new Exception("Item no longer available");
            }
            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(qrtzCronTrigger);
            entry.State = EntityState.Modified;
            context.SaveChanges();

            return qrtzCronTrigger;
        }

        partial void OnQrtzFiredTriggerDeleted(Models.RlvMailer.QrtzFiredTrigger item);

        public async Task<Models.RlvMailer.QrtzFiredTrigger> DeleteQrtzFiredTrigger(string schedName, string entryId)
        {
            var item = context.QrtzFiredTriggers
                              .Where(i => i.SCHED_NAME == schedName && i.ENTRY_ID == entryId)
                              .FirstOrDefault();

            if (item == null)
            {
               throw new Exception("Item no longer available");
            }

            OnQrtzFiredTriggerDeleted(item);

            context.QrtzFiredTriggers.Remove(item);

            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                context.Entry(item).State = EntityState.Unchanged;
                throw ex;
            }

            return item;
        }

        partial void OnQrtzFiredTriggerGet(Models.RlvMailer.QrtzFiredTrigger item);

        public async Task<Models.RlvMailer.QrtzFiredTrigger> GetQrtzFiredTriggerBySchedNameAndEntryId(string schedName, string entryId)
        {
            var items = context.QrtzFiredTriggers
                              .AsNoTracking()
                              .Where(i => i.SCHED_NAME == schedName && i.ENTRY_ID == entryId);

            var item = items.FirstOrDefault();

            OnQrtzFiredTriggerGet(item);

            return await Task.FromResult(item);
        }

        public async Task<Models.RlvMailer.QrtzFiredTrigger> CancelQrtzFiredTriggerChanges(Models.RlvMailer.QrtzFiredTrigger item)
        {
            var entity = context.Entry(item);
            entity.CurrentValues.SetValues(entity.OriginalValues);
            entity.State = EntityState.Unchanged;

            return item;
        }

        partial void OnQrtzFiredTriggerUpdated(Models.RlvMailer.QrtzFiredTrigger item);

        public async Task<Models.RlvMailer.QrtzFiredTrigger> UpdateQrtzFiredTrigger(string schedName, string entryId, Models.RlvMailer.QrtzFiredTrigger qrtzFiredTrigger)
        {
            OnQrtzFiredTriggerUpdated(qrtzFiredTrigger);

            var item = context.QrtzFiredTriggers
                              .Where(i => i.SCHED_NAME == schedName && i.ENTRY_ID == entryId)
                              .FirstOrDefault();
            if (item == null)
            {
               throw new Exception("Item no longer available");
            }
            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(qrtzFiredTrigger);
            entry.State = EntityState.Modified;
            context.SaveChanges();

            return qrtzFiredTrigger;
        }

        partial void OnQrtzJobDetailDeleted(Models.RlvMailer.QrtzJobDetail item);

        public async Task<Models.RlvMailer.QrtzJobDetail> DeleteQrtzJobDetail(string schedName, string jobName, string jobGroup)
        {
            var item = context.QrtzJobDetails
                              .Where(i => i.SCHED_NAME == schedName && i.JOB_NAME == jobName && i.JOB_GROUP == jobGroup)
                              .Include(i => i.QrtzTriggers)
                              .FirstOrDefault();

            if (item == null)
            {
               throw new Exception("Item no longer available");
            }

            OnQrtzJobDetailDeleted(item);

            context.QrtzJobDetails.Remove(item);

            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                context.Entry(item).State = EntityState.Unchanged;
                throw ex;
            }

            return item;
        }

        partial void OnQrtzJobDetailGet(Models.RlvMailer.QrtzJobDetail item);

        public async Task<Models.RlvMailer.QrtzJobDetail> GetQrtzJobDetailBySchedNameAndJobNameAndJobGroup(string schedName, string jobName, string jobGroup)
        {
            var items = context.QrtzJobDetails
                              .AsNoTracking()
                              .Where(i => i.SCHED_NAME == schedName && i.JOB_NAME == jobName && i.JOB_GROUP == jobGroup);

            var item = items.FirstOrDefault();

            OnQrtzJobDetailGet(item);

            return await Task.FromResult(item);
        }

        public async Task<Models.RlvMailer.QrtzJobDetail> CancelQrtzJobDetailChanges(Models.RlvMailer.QrtzJobDetail item)
        {
            var entity = context.Entry(item);
            entity.CurrentValues.SetValues(entity.OriginalValues);
            entity.State = EntityState.Unchanged;

            return item;
        }

        partial void OnQrtzJobDetailUpdated(Models.RlvMailer.QrtzJobDetail item);

        public async Task<Models.RlvMailer.QrtzJobDetail> UpdateQrtzJobDetail(string schedName, string jobName, string jobGroup, Models.RlvMailer.QrtzJobDetail qrtzJobDetail)
        {
            OnQrtzJobDetailUpdated(qrtzJobDetail);

            var item = context.QrtzJobDetails
                              .Where(i => i.SCHED_NAME == schedName && i.JOB_NAME == jobName && i.JOB_GROUP == jobGroup)
                              .FirstOrDefault();
            if (item == null)
            {
               throw new Exception("Item no longer available");
            }
            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(qrtzJobDetail);
            entry.State = EntityState.Modified;
            context.SaveChanges();

            return qrtzJobDetail;
        }

        partial void OnQrtzLockDeleted(Models.RlvMailer.QrtzLock item);

        public async Task<Models.RlvMailer.QrtzLock> DeleteQrtzLock(string schedName, string lockName)
        {
            var item = context.QrtzLocks
                              .Where(i => i.SCHED_NAME == schedName && i.LOCK_NAME == lockName)
                              .FirstOrDefault();

            if (item == null)
            {
               throw new Exception("Item no longer available");
            }

            OnQrtzLockDeleted(item);

            context.QrtzLocks.Remove(item);

            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                context.Entry(item).State = EntityState.Unchanged;
                throw ex;
            }

            return item;
        }

        partial void OnQrtzLockGet(Models.RlvMailer.QrtzLock item);

        public async Task<Models.RlvMailer.QrtzLock> GetQrtzLockBySchedNameAndLockName(string schedName, string lockName)
        {
            var items = context.QrtzLocks
                              .AsNoTracking()
                              .Where(i => i.SCHED_NAME == schedName && i.LOCK_NAME == lockName);

            var item = items.FirstOrDefault();

            OnQrtzLockGet(item);

            return await Task.FromResult(item);
        }

        public async Task<Models.RlvMailer.QrtzLock> CancelQrtzLockChanges(Models.RlvMailer.QrtzLock item)
        {
            var entity = context.Entry(item);
            entity.CurrentValues.SetValues(entity.OriginalValues);
            entity.State = EntityState.Unchanged;

            return item;
        }

        partial void OnQrtzLockUpdated(Models.RlvMailer.QrtzLock item);

        public async Task<Models.RlvMailer.QrtzLock> UpdateQrtzLock(string schedName, string lockName, Models.RlvMailer.QrtzLock qrtzLock)
        {
            OnQrtzLockUpdated(qrtzLock);

            var item = context.QrtzLocks
                              .Where(i => i.SCHED_NAME == schedName && i.LOCK_NAME == lockName)
                              .FirstOrDefault();
            if (item == null)
            {
               throw new Exception("Item no longer available");
            }
            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(qrtzLock);
            entry.State = EntityState.Modified;
            context.SaveChanges();

            return qrtzLock;
        }

        partial void OnQrtzPausedTriggerGrpDeleted(Models.RlvMailer.QrtzPausedTriggerGrp item);

        public async Task<Models.RlvMailer.QrtzPausedTriggerGrp> DeleteQrtzPausedTriggerGrp(string schedName, string triggerGroup)
        {
            var item = context.QrtzPausedTriggerGrps
                              .Where(i => i.SCHED_NAME == schedName && i.TRIGGER_GROUP == triggerGroup)
                              .FirstOrDefault();

            if (item == null)
            {
               throw new Exception("Item no longer available");
            }

            OnQrtzPausedTriggerGrpDeleted(item);

            context.QrtzPausedTriggerGrps.Remove(item);

            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                context.Entry(item).State = EntityState.Unchanged;
                throw ex;
            }

            return item;
        }

        partial void OnQrtzPausedTriggerGrpGet(Models.RlvMailer.QrtzPausedTriggerGrp item);

        public async Task<Models.RlvMailer.QrtzPausedTriggerGrp> GetQrtzPausedTriggerGrpBySchedNameAndTriggerGroup(string schedName, string triggerGroup)
        {
            var items = context.QrtzPausedTriggerGrps
                              .AsNoTracking()
                              .Where(i => i.SCHED_NAME == schedName && i.TRIGGER_GROUP == triggerGroup);

            var item = items.FirstOrDefault();

            OnQrtzPausedTriggerGrpGet(item);

            return await Task.FromResult(item);
        }

        public async Task<Models.RlvMailer.QrtzPausedTriggerGrp> CancelQrtzPausedTriggerGrpChanges(Models.RlvMailer.QrtzPausedTriggerGrp item)
        {
            var entity = context.Entry(item);
            entity.CurrentValues.SetValues(entity.OriginalValues);
            entity.State = EntityState.Unchanged;

            return item;
        }

        partial void OnQrtzPausedTriggerGrpUpdated(Models.RlvMailer.QrtzPausedTriggerGrp item);

        public async Task<Models.RlvMailer.QrtzPausedTriggerGrp> UpdateQrtzPausedTriggerGrp(string schedName, string triggerGroup, Models.RlvMailer.QrtzPausedTriggerGrp qrtzPausedTriggerGrp)
        {
            OnQrtzPausedTriggerGrpUpdated(qrtzPausedTriggerGrp);

            var item = context.QrtzPausedTriggerGrps
                              .Where(i => i.SCHED_NAME == schedName && i.TRIGGER_GROUP == triggerGroup)
                              .FirstOrDefault();
            if (item == null)
            {
               throw new Exception("Item no longer available");
            }
            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(qrtzPausedTriggerGrp);
            entry.State = EntityState.Modified;
            context.SaveChanges();

            return qrtzPausedTriggerGrp;
        }

        partial void OnQrtzSchedulerStateDeleted(Models.RlvMailer.QrtzSchedulerState item);

        public async Task<Models.RlvMailer.QrtzSchedulerState> DeleteQrtzSchedulerState(string schedName, string instanceName)
        {
            var item = context.QrtzSchedulerStates
                              .Where(i => i.SCHED_NAME == schedName && i.INSTANCE_NAME == instanceName)
                              .FirstOrDefault();

            if (item == null)
            {
               throw new Exception("Item no longer available");
            }

            OnQrtzSchedulerStateDeleted(item);

            context.QrtzSchedulerStates.Remove(item);

            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                context.Entry(item).State = EntityState.Unchanged;
                throw ex;
            }

            return item;
        }

        partial void OnQrtzSchedulerStateGet(Models.RlvMailer.QrtzSchedulerState item);

        public async Task<Models.RlvMailer.QrtzSchedulerState> GetQrtzSchedulerStateBySchedNameAndInstanceName(string schedName, string instanceName)
        {
            var items = context.QrtzSchedulerStates
                              .AsNoTracking()
                              .Where(i => i.SCHED_NAME == schedName && i.INSTANCE_NAME == instanceName);

            var item = items.FirstOrDefault();

            OnQrtzSchedulerStateGet(item);

            return await Task.FromResult(item);
        }

        public async Task<Models.RlvMailer.QrtzSchedulerState> CancelQrtzSchedulerStateChanges(Models.RlvMailer.QrtzSchedulerState item)
        {
            var entity = context.Entry(item);
            entity.CurrentValues.SetValues(entity.OriginalValues);
            entity.State = EntityState.Unchanged;

            return item;
        }

        partial void OnQrtzSchedulerStateUpdated(Models.RlvMailer.QrtzSchedulerState item);

        public async Task<Models.RlvMailer.QrtzSchedulerState> UpdateQrtzSchedulerState(string schedName, string instanceName, Models.RlvMailer.QrtzSchedulerState qrtzSchedulerState)
        {
            OnQrtzSchedulerStateUpdated(qrtzSchedulerState);

            var item = context.QrtzSchedulerStates
                              .Where(i => i.SCHED_NAME == schedName && i.INSTANCE_NAME == instanceName)
                              .FirstOrDefault();
            if (item == null)
            {
               throw new Exception("Item no longer available");
            }
            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(qrtzSchedulerState);
            entry.State = EntityState.Modified;
            context.SaveChanges();

            return qrtzSchedulerState;
        }

        partial void OnQrtzSimpleTriggerDeleted(Models.RlvMailer.QrtzSimpleTrigger item);

        public async Task<Models.RlvMailer.QrtzSimpleTrigger> DeleteQrtzSimpleTrigger(string schedName, string triggerName, string triggerGroup)
        {
            var item = context.QrtzSimpleTriggers
                              .Where(i => i.SCHED_NAME == schedName && i.TRIGGER_NAME == triggerName && i.TRIGGER_GROUP == triggerGroup)
                              .FirstOrDefault();

            if (item == null)
            {
               throw new Exception("Item no longer available");
            }

            OnQrtzSimpleTriggerDeleted(item);

            context.QrtzSimpleTriggers.Remove(item);

            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                context.Entry(item).State = EntityState.Unchanged;
                throw ex;
            }

            return item;
        }

        partial void OnQrtzSimpleTriggerGet(Models.RlvMailer.QrtzSimpleTrigger item);

        public async Task<Models.RlvMailer.QrtzSimpleTrigger> GetQrtzSimpleTriggerBySchedNameAndTriggerNameAndTriggerGroup(string schedName, string triggerName, string triggerGroup)
        {
            var items = context.QrtzSimpleTriggers
                              .AsNoTracking()
                              .Where(i => i.SCHED_NAME == schedName && i.TRIGGER_NAME == triggerName && i.TRIGGER_GROUP == triggerGroup);

            items = items.Include(i => i.QrtzTrigger);

            var item = items.FirstOrDefault();

            OnQrtzSimpleTriggerGet(item);

            return await Task.FromResult(item);
        }

        public async Task<Models.RlvMailer.QrtzSimpleTrigger> CancelQrtzSimpleTriggerChanges(Models.RlvMailer.QrtzSimpleTrigger item)
        {
            var entity = context.Entry(item);
            entity.CurrentValues.SetValues(entity.OriginalValues);
            entity.State = EntityState.Unchanged;

            return item;
        }

        partial void OnQrtzSimpleTriggerUpdated(Models.RlvMailer.QrtzSimpleTrigger item);

        public async Task<Models.RlvMailer.QrtzSimpleTrigger> UpdateQrtzSimpleTrigger(string schedName, string triggerName, string triggerGroup, Models.RlvMailer.QrtzSimpleTrigger qrtzSimpleTrigger)
        {
            OnQrtzSimpleTriggerUpdated(qrtzSimpleTrigger);

            var item = context.QrtzSimpleTriggers
                              .Where(i => i.SCHED_NAME == schedName && i.TRIGGER_NAME == triggerName && i.TRIGGER_GROUP == triggerGroup)
                              .FirstOrDefault();
            if (item == null)
            {
               throw new Exception("Item no longer available");
            }
            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(qrtzSimpleTrigger);
            entry.State = EntityState.Modified;
            context.SaveChanges();

            return qrtzSimpleTrigger;
        }

        partial void OnQrtzSimpropTriggerDeleted(Models.RlvMailer.QrtzSimpropTrigger item);

        public async Task<Models.RlvMailer.QrtzSimpropTrigger> DeleteQrtzSimpropTrigger(string schedName, string triggerName, string triggerGroup)
        {
            var item = context.QrtzSimpropTriggers
                              .Where(i => i.SCHED_NAME == schedName && i.TRIGGER_NAME == triggerName && i.TRIGGER_GROUP == triggerGroup)
                              .FirstOrDefault();

            if (item == null)
            {
               throw new Exception("Item no longer available");
            }

            OnQrtzSimpropTriggerDeleted(item);

            context.QrtzSimpropTriggers.Remove(item);

            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                context.Entry(item).State = EntityState.Unchanged;
                throw ex;
            }

            return item;
        }

        partial void OnQrtzSimpropTriggerGet(Models.RlvMailer.QrtzSimpropTrigger item);

        public async Task<Models.RlvMailer.QrtzSimpropTrigger> GetQrtzSimpropTriggerBySchedNameAndTriggerNameAndTriggerGroup(string schedName, string triggerName, string triggerGroup)
        {
            var items = context.QrtzSimpropTriggers
                              .AsNoTracking()
                              .Where(i => i.SCHED_NAME == schedName && i.TRIGGER_NAME == triggerName && i.TRIGGER_GROUP == triggerGroup);

            items = items.Include(i => i.QrtzTrigger);

            var item = items.FirstOrDefault();

            OnQrtzSimpropTriggerGet(item);

            return await Task.FromResult(item);
        }

        public async Task<Models.RlvMailer.QrtzSimpropTrigger> CancelQrtzSimpropTriggerChanges(Models.RlvMailer.QrtzSimpropTrigger item)
        {
            var entity = context.Entry(item);
            entity.CurrentValues.SetValues(entity.OriginalValues);
            entity.State = EntityState.Unchanged;

            return item;
        }

        partial void OnQrtzSimpropTriggerUpdated(Models.RlvMailer.QrtzSimpropTrigger item);

        public async Task<Models.RlvMailer.QrtzSimpropTrigger> UpdateQrtzSimpropTrigger(string schedName, string triggerName, string triggerGroup, Models.RlvMailer.QrtzSimpropTrigger qrtzSimpropTrigger)
        {
            OnQrtzSimpropTriggerUpdated(qrtzSimpropTrigger);

            var item = context.QrtzSimpropTriggers
                              .Where(i => i.SCHED_NAME == schedName && i.TRIGGER_NAME == triggerName && i.TRIGGER_GROUP == triggerGroup)
                              .FirstOrDefault();
            if (item == null)
            {
               throw new Exception("Item no longer available");
            }
            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(qrtzSimpropTrigger);
            entry.State = EntityState.Modified;
            context.SaveChanges();

            return qrtzSimpropTrigger;
        }

        partial void OnQrtzTriggerDeleted(Models.RlvMailer.QrtzTrigger item);

        public async Task<Models.RlvMailer.QrtzTrigger> DeleteQrtzTrigger(string schedName, string triggerName, string triggerGroup)
        {
            var item = context.QrtzTriggers
                              .Where(i => i.SCHED_NAME == schedName && i.TRIGGER_NAME == triggerName && i.TRIGGER_GROUP == triggerGroup)
                              .Include(i => i.QrtzCronTriggers)
                              .Include(i => i.QrtzSimpleTriggers)
                              .Include(i => i.QrtzSimpropTriggers)
                              .FirstOrDefault();

            if (item == null)
            {
               throw new Exception("Item no longer available");
            }

            OnQrtzTriggerDeleted(item);

            context.QrtzTriggers.Remove(item);

            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                context.Entry(item).State = EntityState.Unchanged;
                throw ex;
            }

            return item;
        }

        partial void OnQrtzTriggerGet(Models.RlvMailer.QrtzTrigger item);

        public async Task<Models.RlvMailer.QrtzTrigger> GetQrtzTriggerBySchedNameAndTriggerNameAndTriggerGroup(string schedName, string triggerName, string triggerGroup)
        {
            var items = context.QrtzTriggers
                              .AsNoTracking()
                              .Where(i => i.SCHED_NAME == schedName && i.TRIGGER_NAME == triggerName && i.TRIGGER_GROUP == triggerGroup);

            items = items.Include(i => i.QrtzJobDetail);

            var item = items.FirstOrDefault();

            OnQrtzTriggerGet(item);

            return await Task.FromResult(item);
        }

        public async Task<Models.RlvMailer.QrtzTrigger> CancelQrtzTriggerChanges(Models.RlvMailer.QrtzTrigger item)
        {
            var entity = context.Entry(item);
            entity.CurrentValues.SetValues(entity.OriginalValues);
            entity.State = EntityState.Unchanged;

            return item;
        }

        partial void OnQrtzTriggerUpdated(Models.RlvMailer.QrtzTrigger item);

        public async Task<Models.RlvMailer.QrtzTrigger> UpdateQrtzTrigger(string schedName, string triggerName, string triggerGroup, Models.RlvMailer.QrtzTrigger qrtzTrigger)
        {
            OnQrtzTriggerUpdated(qrtzTrigger);

            var item = context.QrtzTriggers
                              .Where(i => i.SCHED_NAME == schedName && i.TRIGGER_NAME == triggerName && i.TRIGGER_GROUP == triggerGroup)
                              .FirstOrDefault();
            if (item == null)
            {
               throw new Exception("Item no longer available");
            }
            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(qrtzTrigger);
            entry.State = EntityState.Modified;
            context.SaveChanges();

            return qrtzTrigger;
        }

        partial void OnQsVirtualProxyDeleted(Models.RlvMailer.QsVirtualProxy item);

        public async Task<Models.RlvMailer.QsVirtualProxy> DeleteQsVirtualProxy(int? id)
        {
            var item = context.QsVirtualProxies
                              .Where(i => i.id == id)
                              .FirstOrDefault();

            if (item == null)
            {
               throw new Exception("Item no longer available");
            }

            OnQsVirtualProxyDeleted(item);

            context.QsVirtualProxies.Remove(item);

            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                context.Entry(item).State = EntityState.Unchanged;
                throw ex;
            }

            return item;
        }

        partial void OnQsVirtualProxyGet(Models.RlvMailer.QsVirtualProxy item);

        public async Task<Models.RlvMailer.QsVirtualProxy> GetQsVirtualProxyByid(int? id)
        {
            var items = context.QsVirtualProxies
                              .AsNoTracking()
                              .Where(i => i.id == id);

            items = items.Include(i => i.Q);

            items = items.Include(i => i.AuthMethod);

            var item = items.FirstOrDefault();

            OnQsVirtualProxyGet(item);

            return await Task.FromResult(item);
        }

        public async Task<Models.RlvMailer.QsVirtualProxy> CancelQsVirtualProxyChanges(Models.RlvMailer.QsVirtualProxy item)
        {
            var entity = context.Entry(item);
            entity.CurrentValues.SetValues(entity.OriginalValues);
            entity.State = EntityState.Unchanged;

            return item;
        }

        partial void OnQsVirtualProxyUpdated(Models.RlvMailer.QsVirtualProxy item);

        public async Task<Models.RlvMailer.QsVirtualProxy> UpdateQsVirtualProxy(int? id, Models.RlvMailer.QsVirtualProxy qsVirtualProxy)
        {
            OnQsVirtualProxyUpdated(qsVirtualProxy);

            var item = context.QsVirtualProxies
                              .Where(i => i.id == id)
                              .FirstOrDefault();
            if (item == null)
            {
               throw new Exception("Item no longer available");
            }
            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(qsVirtualProxy);
            entry.State = EntityState.Modified;
            context.SaveChanges();

            return qsVirtualProxy;
        }

        partial void OnReportDeleted(Models.RlvMailer.Report item);

        public async Task<Models.RlvMailer.Report> DeleteReport(int? reportId)
        {
            var item = context.Reports
                              .Where(i => i.report_id == reportId)
                              .Include(i => i.ExternalEmails)
                              .Include(i => i.ReportSelections)
                              .Include(i => i.ReportLines)
                              .Include(i => i.LogReports)
                              .Include(i => i.Tags)
                              .Include(i => i.ReportSelectionsDates)
                              .Include(i => i.ReportSelectionsDateOverrides)
                              .Include(i => i.ReportsExecConditions)
                              .FirstOrDefault();

            if (item == null)
            {
               throw new Exception("Item no longer available");
            }

            OnReportDeleted(item);

            context.Reports.Remove(item);

            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                context.Entry(item).State = EntityState.Unchanged;
                throw ex;
            }

            return item;
        }

        partial void OnReportGet(Models.RlvMailer.Report item);

        public async Task<Models.RlvMailer.Report> GetReportByreportId(int? reportId)
        {
            var items = context.Reports
                              .AsNoTracking()
                              .Where(i => i.report_id == reportId);

            items = items.Include(i => i.Setting);

            items = items.Include(i => i.Mail);

            items = items.Include(i => i.Q);

            var item = items.FirstOrDefault();

            OnReportGet(item);

            return await Task.FromResult(item);
        }

        public async Task<Models.RlvMailer.Report> CancelReportChanges(Models.RlvMailer.Report item)
        {
            var entity = context.Entry(item);
            entity.CurrentValues.SetValues(entity.OriginalValues);
            entity.State = EntityState.Unchanged;

            return item;
        }

        partial void OnReportUpdated(Models.RlvMailer.Report item);

        public async Task<Models.RlvMailer.Report> UpdateReport(int? reportId, Models.RlvMailer.Report report)
        {
            OnReportUpdated(report);

            var item = context.Reports
                              .Where(i => i.report_id == reportId)
                              .FirstOrDefault();
            if (item == null)
            {
               throw new Exception("Item no longer available");
            }
            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(report);
            entry.State = EntityState.Modified;
            context.SaveChanges();

            return report;
        }

        partial void OnReportLineDeleted(Models.RlvMailer.ReportLine item);

        public async Task<Models.RlvMailer.ReportLine> DeleteReportLine(int? reportLineId)
        {
            var item = context.ReportLines
                              .Where(i => i.report_line_id == reportLineId)
                              .Include(i => i.ReportLineImgs)
                              .Include(i => i.ReportLineTexts)
                              .Include(i => i.ReportLineXls)
                              .FirstOrDefault();

            if (item == null)
            {
               throw new Exception("Item no longer available");
            }

            OnReportLineDeleted(item);

            context.ReportLines.Remove(item);

            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                context.Entry(item).State = EntityState.Unchanged;
                throw ex;
            }

            return item;
        }

        partial void OnReportLineGet(Models.RlvMailer.ReportLine item);

        public async Task<Models.RlvMailer.ReportLine> GetReportLineByreportLineId(int? reportLineId)
        {
            var items = context.ReportLines
                              .AsNoTracking()
                              .Where(i => i.report_line_id == reportLineId);

            items = items.Include(i => i.Report);

            var item = items.FirstOrDefault();

            OnReportLineGet(item);

            return await Task.FromResult(item);
        }

        public async Task<Models.RlvMailer.ReportLine> CancelReportLineChanges(Models.RlvMailer.ReportLine item)
        {
            var entity = context.Entry(item);
            entity.CurrentValues.SetValues(entity.OriginalValues);
            entity.State = EntityState.Unchanged;

            return item;
        }

        partial void OnReportLineUpdated(Models.RlvMailer.ReportLine item);

        public async Task<Models.RlvMailer.ReportLine> UpdateReportLine(int? reportLineId, Models.RlvMailer.ReportLine reportLine)
        {
            OnReportLineUpdated(reportLine);

            var item = context.ReportLines
                              .Where(i => i.report_line_id == reportLineId)
                              .FirstOrDefault();
            if (item == null)
            {
               throw new Exception("Item no longer available");
            }
            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(reportLine);
            entry.State = EntityState.Modified;
            context.SaveChanges();

            return reportLine;
        }

        partial void OnReportLineImgDeleted(Models.RlvMailer.ReportLineImg item);

        public async Task<Models.RlvMailer.ReportLineImg> DeleteReportLineImg(int? reportLineImgId)
        {
            var item = context.ReportLineImgs
                              .Where(i => i.report_line_img_id == reportLineImgId)
                              .FirstOrDefault();

            if (item == null)
            {
               throw new Exception("Item no longer available");
            }

            OnReportLineImgDeleted(item);

            context.ReportLineImgs.Remove(item);

            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                context.Entry(item).State = EntityState.Unchanged;
                throw ex;
            }

            return item;
        }

        partial void OnReportLineImgGet(Models.RlvMailer.ReportLineImg item);

        public async Task<Models.RlvMailer.ReportLineImg> GetReportLineImgByreportLineImgId(int? reportLineImgId)
        {
            var items = context.ReportLineImgs
                              .AsNoTracking()
                              .Where(i => i.report_line_img_id == reportLineImgId);

            items = items.Include(i => i.ReportLine);

            var item = items.FirstOrDefault();

            OnReportLineImgGet(item);

            return await Task.FromResult(item);
        }

        public async Task<Models.RlvMailer.ReportLineImg> CancelReportLineImgChanges(Models.RlvMailer.ReportLineImg item)
        {
            var entity = context.Entry(item);
            entity.CurrentValues.SetValues(entity.OriginalValues);
            entity.State = EntityState.Unchanged;

            return item;
        }

        partial void OnReportLineImgUpdated(Models.RlvMailer.ReportLineImg item);

        public async Task<Models.RlvMailer.ReportLineImg> UpdateReportLineImg(int? reportLineImgId, Models.RlvMailer.ReportLineImg reportLineImg)
        {
            OnReportLineImgUpdated(reportLineImg);

            var item = context.ReportLineImgs
                              .Where(i => i.report_line_img_id == reportLineImgId)
                              .FirstOrDefault();
            if (item == null)
            {
               throw new Exception("Item no longer available");
            }
            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(reportLineImg);
            entry.State = EntityState.Modified;
            context.SaveChanges();

            return reportLineImg;
        }

        partial void OnReportLineTextDeleted(Models.RlvMailer.ReportLineText item);

        public async Task<Models.RlvMailer.ReportLineText> DeleteReportLineText(int? reportLineTextId)
        {
            var item = context.ReportLineTexts
                              .Where(i => i.report_line_text_id == reportLineTextId)
                              .FirstOrDefault();

            if (item == null)
            {
               throw new Exception("Item no longer available");
            }

            OnReportLineTextDeleted(item);

            context.ReportLineTexts.Remove(item);

            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                context.Entry(item).State = EntityState.Unchanged;
                throw ex;
            }

            return item;
        }

        partial void OnReportLineTextGet(Models.RlvMailer.ReportLineText item);

        public async Task<Models.RlvMailer.ReportLineText> GetReportLineTextByreportLineTextId(int? reportLineTextId)
        {
            var items = context.ReportLineTexts
                              .AsNoTracking()
                              .Where(i => i.report_line_text_id == reportLineTextId);

            items = items.Include(i => i.ReportLine);

            var item = items.FirstOrDefault();

            OnReportLineTextGet(item);

            return await Task.FromResult(item);
        }

        public async Task<Models.RlvMailer.ReportLineText> CancelReportLineTextChanges(Models.RlvMailer.ReportLineText item)
        {
            var entity = context.Entry(item);
            entity.CurrentValues.SetValues(entity.OriginalValues);
            entity.State = EntityState.Unchanged;

            return item;
        }

        partial void OnReportLineTextUpdated(Models.RlvMailer.ReportLineText item);

        public async Task<Models.RlvMailer.ReportLineText> UpdateReportLineText(int? reportLineTextId, Models.RlvMailer.ReportLineText reportLineText)
        {
            OnReportLineTextUpdated(reportLineText);

            var item = context.ReportLineTexts
                              .Where(i => i.report_line_text_id == reportLineTextId)
                              .FirstOrDefault();
            if (item == null)
            {
               throw new Exception("Item no longer available");
            }
            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(reportLineText);
            entry.State = EntityState.Modified;
            context.SaveChanges();

            return reportLineText;
        }

        partial void OnReportLineXlDeleted(Models.RlvMailer.ReportLineXl item);

        public async Task<Models.RlvMailer.ReportLineXl> DeleteReportLineXl(int? reportLineXlsId)
        {
            var item = context.ReportLineXls
                              .Where(i => i.report_line_xls_id == reportLineXlsId)
                              .FirstOrDefault();

            if (item == null)
            {
               throw new Exception("Item no longer available");
            }

            OnReportLineXlDeleted(item);

            context.ReportLineXls.Remove(item);

            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                context.Entry(item).State = EntityState.Unchanged;
                throw ex;
            }

            return item;
        }

        partial void OnReportLineXlGet(Models.RlvMailer.ReportLineXl item);

        public async Task<Models.RlvMailer.ReportLineXl> GetReportLineXlByreportLineXlsId(int? reportLineXlsId)
        {
            var items = context.ReportLineXls
                              .AsNoTracking()
                              .Where(i => i.report_line_xls_id == reportLineXlsId);

            items = items.Include(i => i.ReportLine);

            var item = items.FirstOrDefault();

            OnReportLineXlGet(item);

            return await Task.FromResult(item);
        }

        public async Task<Models.RlvMailer.ReportLineXl> CancelReportLineXlChanges(Models.RlvMailer.ReportLineXl item)
        {
            var entity = context.Entry(item);
            entity.CurrentValues.SetValues(entity.OriginalValues);
            entity.State = EntityState.Unchanged;

            return item;
        }

        partial void OnReportLineXlUpdated(Models.RlvMailer.ReportLineXl item);

        public async Task<Models.RlvMailer.ReportLineXl> UpdateReportLineXl(int? reportLineXlsId, Models.RlvMailer.ReportLineXl reportLineXl)
        {
            OnReportLineXlUpdated(reportLineXl);

            var item = context.ReportLineXls
                              .Where(i => i.report_line_xls_id == reportLineXlsId)
                              .FirstOrDefault();
            if (item == null)
            {
               throw new Exception("Item no longer available");
            }
            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(reportLineXl);
            entry.State = EntityState.Modified;
            context.SaveChanges();

            return reportLineXl;
        }

        partial void OnReportSelectionDeleted(Models.RlvMailer.ReportSelection item);

        public async Task<Models.RlvMailer.ReportSelection> DeleteReportSelection(int? reportSelectionsId)
        {
            var item = context.ReportSelections
                              .Where(i => i.report_selections_id == reportSelectionsId)
                              .FirstOrDefault();

            if (item == null)
            {
               throw new Exception("Item no longer available");
            }

            OnReportSelectionDeleted(item);

            context.ReportSelections.Remove(item);

            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                context.Entry(item).State = EntityState.Unchanged;
                throw ex;
            }

            return item;
        }

        partial void OnReportSelectionGet(Models.RlvMailer.ReportSelection item);

        public async Task<Models.RlvMailer.ReportSelection> GetReportSelectionByreportSelectionsId(int? reportSelectionsId)
        {
            var items = context.ReportSelections
                              .AsNoTracking()
                              .Where(i => i.report_selections_id == reportSelectionsId);

            items = items.Include(i => i.Report);

            var item = items.FirstOrDefault();

            OnReportSelectionGet(item);

            return await Task.FromResult(item);
        }

        public async Task<Models.RlvMailer.ReportSelection> CancelReportSelectionChanges(Models.RlvMailer.ReportSelection item)
        {
            var entity = context.Entry(item);
            entity.CurrentValues.SetValues(entity.OriginalValues);
            entity.State = EntityState.Unchanged;

            return item;
        }

        partial void OnReportSelectionUpdated(Models.RlvMailer.ReportSelection item);

        public async Task<Models.RlvMailer.ReportSelection> UpdateReportSelection(int? reportSelectionsId, Models.RlvMailer.ReportSelection reportSelection)
        {
            OnReportSelectionUpdated(reportSelection);

            var item = context.ReportSelections
                              .Where(i => i.report_selections_id == reportSelectionsId)
                              .FirstOrDefault();
            if (item == null)
            {
               throw new Exception("Item no longer available");
            }
            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(reportSelection);
            entry.State = EntityState.Modified;
            context.SaveChanges();

            return reportSelection;
        }

        partial void OnReportSelectionsDateDeleted(Models.RlvMailer.ReportSelectionsDate item);

        public async Task<Models.RlvMailer.ReportSelectionsDate> DeleteReportSelectionsDate(int? reportSelectionsDateId)
        {
            var item = context.ReportSelectionsDates
                              .Where(i => i.report_selections_date_id == reportSelectionsDateId)
                              .FirstOrDefault();

            if (item == null)
            {
               throw new Exception("Item no longer available");
            }

            OnReportSelectionsDateDeleted(item);

            context.ReportSelectionsDates.Remove(item);

            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                context.Entry(item).State = EntityState.Unchanged;
                throw ex;
            }

            return item;
        }

        partial void OnReportSelectionsDateGet(Models.RlvMailer.ReportSelectionsDate item);

        public async Task<Models.RlvMailer.ReportSelectionsDate> GetReportSelectionsDateByreportSelectionsDateId(int? reportSelectionsDateId)
        {
            var items = context.ReportSelectionsDates
                              .AsNoTracking()
                              .Where(i => i.report_selections_date_id == reportSelectionsDateId);

            items = items.Include(i => i.Report);

            var item = items.FirstOrDefault();

            OnReportSelectionsDateGet(item);

            return await Task.FromResult(item);
        }

        public async Task<Models.RlvMailer.ReportSelectionsDate> CancelReportSelectionsDateChanges(Models.RlvMailer.ReportSelectionsDate item)
        {
            var entity = context.Entry(item);
            entity.CurrentValues.SetValues(entity.OriginalValues);
            entity.State = EntityState.Unchanged;

            return item;
        }

        partial void OnReportSelectionsDateUpdated(Models.RlvMailer.ReportSelectionsDate item);

        public async Task<Models.RlvMailer.ReportSelectionsDate> UpdateReportSelectionsDate(int? reportSelectionsDateId, Models.RlvMailer.ReportSelectionsDate reportSelectionsDate)
        {
            OnReportSelectionsDateUpdated(reportSelectionsDate);

            var item = context.ReportSelectionsDates
                              .Where(i => i.report_selections_date_id == reportSelectionsDateId)
                              .FirstOrDefault();
            if (item == null)
            {
               throw new Exception("Item no longer available");
            }
            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(reportSelectionsDate);
            entry.State = EntityState.Modified;
            context.SaveChanges();

            return reportSelectionsDate;
        }

        partial void OnReportSelectionsDateOverrideDeleted(Models.RlvMailer.ReportSelectionsDateOverride item);

        public async Task<Models.RlvMailer.ReportSelectionsDateOverride> DeleteReportSelectionsDateOverride(int? reportSelectionsDateOverrideId)
        {
            var item = context.ReportSelectionsDateOverrides
                              .Where(i => i.report_selections_date_override_id == reportSelectionsDateOverrideId)
                              .FirstOrDefault();

            if (item == null)
            {
               throw new Exception("Item no longer available");
            }

            OnReportSelectionsDateOverrideDeleted(item);

            context.ReportSelectionsDateOverrides.Remove(item);

            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                context.Entry(item).State = EntityState.Unchanged;
                throw ex;
            }

            return item;
        }

        partial void OnReportSelectionsDateOverrideGet(Models.RlvMailer.ReportSelectionsDateOverride item);

        public async Task<Models.RlvMailer.ReportSelectionsDateOverride> GetReportSelectionsDateOverrideByreportSelectionsDateOverrideId(int? reportSelectionsDateOverrideId)
        {
            var items = context.ReportSelectionsDateOverrides
                              .AsNoTracking()
                              .Where(i => i.report_selections_date_override_id == reportSelectionsDateOverrideId);

            items = items.Include(i => i.Report);

            var item = items.FirstOrDefault();

            OnReportSelectionsDateOverrideGet(item);

            return await Task.FromResult(item);
        }

        public async Task<Models.RlvMailer.ReportSelectionsDateOverride> CancelReportSelectionsDateOverrideChanges(Models.RlvMailer.ReportSelectionsDateOverride item)
        {
            var entity = context.Entry(item);
            entity.CurrentValues.SetValues(entity.OriginalValues);
            entity.State = EntityState.Unchanged;

            return item;
        }

        partial void OnReportSelectionsDateOverrideUpdated(Models.RlvMailer.ReportSelectionsDateOverride item);

        public async Task<Models.RlvMailer.ReportSelectionsDateOverride> UpdateReportSelectionsDateOverride(int? reportSelectionsDateOverrideId, Models.RlvMailer.ReportSelectionsDateOverride reportSelectionsDateOverride)
        {
            OnReportSelectionsDateOverrideUpdated(reportSelectionsDateOverride);

            var item = context.ReportSelectionsDateOverrides
                              .Where(i => i.report_selections_date_override_id == reportSelectionsDateOverrideId)
                              .FirstOrDefault();
            if (item == null)
            {
               throw new Exception("Item no longer available");
            }
            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(reportSelectionsDateOverride);
            entry.State = EntityState.Modified;
            context.SaveChanges();

            return reportSelectionsDateOverride;
        }

        partial void OnReportsExecConditionDeleted(Models.RlvMailer.ReportsExecCondition item);

        public async Task<Models.RlvMailer.ReportsExecCondition> DeleteReportsExecCondition(int? reportExecConditionId)
        {
            var item = context.ReportsExecConditions
                              .Where(i => i.report_exec_condition_id == reportExecConditionId)
                              .FirstOrDefault();

            if (item == null)
            {
               throw new Exception("Item no longer available");
            }

            OnReportsExecConditionDeleted(item);

            context.ReportsExecConditions.Remove(item);

            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                context.Entry(item).State = EntityState.Unchanged;
                throw ex;
            }

            return item;
        }

        partial void OnReportsExecConditionGet(Models.RlvMailer.ReportsExecCondition item);

        public async Task<Models.RlvMailer.ReportsExecCondition> GetReportsExecConditionByreportExecConditionId(int? reportExecConditionId)
        {
            var items = context.ReportsExecConditions
                              .AsNoTracking()
                              .Where(i => i.report_exec_condition_id == reportExecConditionId);

            items = items.Include(i => i.Report);

            var item = items.FirstOrDefault();

            OnReportsExecConditionGet(item);

            return await Task.FromResult(item);
        }

        public async Task<Models.RlvMailer.ReportsExecCondition> CancelReportsExecConditionChanges(Models.RlvMailer.ReportsExecCondition item)
        {
            var entity = context.Entry(item);
            entity.CurrentValues.SetValues(entity.OriginalValues);
            entity.State = EntityState.Unchanged;

            return item;
        }

        partial void OnReportsExecConditionUpdated(Models.RlvMailer.ReportsExecCondition item);

        public async Task<Models.RlvMailer.ReportsExecCondition> UpdateReportsExecCondition(int? reportExecConditionId, Models.RlvMailer.ReportsExecCondition reportsExecCondition)
        {
            OnReportsExecConditionUpdated(reportsExecCondition);

            var item = context.ReportsExecConditions
                              .Where(i => i.report_exec_condition_id == reportExecConditionId)
                              .FirstOrDefault();
            if (item == null)
            {
               throw new Exception("Item no longer available");
            }
            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(reportsExecCondition);
            entry.State = EntityState.Modified;
            context.SaveChanges();

            return reportsExecCondition;
        }

        partial void OnSettingDeleted(Models.RlvMailer.Setting item);

        public async Task<Models.RlvMailer.Setting> DeleteSetting(int? appId)
        {
            var item = context.Settings
                              .Where(i => i.app_id == appId)
                              .Include(i => i.Reports)
                              .FirstOrDefault();

            if (item == null)
            {
               throw new Exception("Item no longer available");
            }

            OnSettingDeleted(item);

            context.Settings.Remove(item);

            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                context.Entry(item).State = EntityState.Unchanged;
                throw ex;
            }

            return item;
        }

        partial void OnSettingGet(Models.RlvMailer.Setting item);

        public async Task<Models.RlvMailer.Setting> GetSettingByappId(int? appId)
        {
            var items = context.Settings
                              .AsNoTracking()
                              .Where(i => i.app_id == appId);

            items = items.Include(i => i.Country);

            var item = items.FirstOrDefault();

            OnSettingGet(item);

            return await Task.FromResult(item);
        }

        public async Task<Models.RlvMailer.Setting> CancelSettingChanges(Models.RlvMailer.Setting item)
        {
            var entity = context.Entry(item);
            entity.CurrentValues.SetValues(entity.OriginalValues);
            entity.State = EntityState.Unchanged;

            return item;
        }

        partial void OnSettingUpdated(Models.RlvMailer.Setting item);

        public async Task<Models.RlvMailer.Setting> UpdateSetting(int? appId, Models.RlvMailer.Setting setting)
        {
            OnSettingUpdated(setting);

            var item = context.Settings
                              .Where(i => i.app_id == appId)
                              .FirstOrDefault();
            if (item == null)
            {
               throw new Exception("Item no longer available");
            }
            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(setting);
            entry.State = EntityState.Modified;
            context.SaveChanges();

            return setting;
        }

        partial void OnTagDeleted(Models.RlvMailer.Tag item);

        public async Task<Models.RlvMailer.Tag> DeleteTag(int? tagId)
        {
            var item = context.Tags
                              .Where(i => i.tag_id == tagId)
                              .FirstOrDefault();

            if (item == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTagDeleted(item);

            context.Tags.Remove(item);

            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                context.Entry(item).State = EntityState.Unchanged;
                throw ex;
            }

            return item;
        }

        partial void OnTagGet(Models.RlvMailer.Tag item);

        public async Task<Models.RlvMailer.Tag> GetTagBytagId(int? tagId)
        {
            var items = context.Tags
                              .AsNoTracking()
                              .Where(i => i.tag_id == tagId);

            items = items.Include(i => i.Report);

            var item = items.FirstOrDefault();

            OnTagGet(item);

            return await Task.FromResult(item);
        }

        public async Task<Models.RlvMailer.Tag> CancelTagChanges(Models.RlvMailer.Tag item)
        {
            var entity = context.Entry(item);
            entity.CurrentValues.SetValues(entity.OriginalValues);
            entity.State = EntityState.Unchanged;

            return item;
        }

        partial void OnTagUpdated(Models.RlvMailer.Tag item);

        public async Task<Models.RlvMailer.Tag> UpdateTag(int? tagId, Models.RlvMailer.Tag tag)
        {
            OnTagUpdated(tag);

            var item = context.Tags
                              .Where(i => i.tag_id == tagId)
                              .FirstOrDefault();
            if (item == null)
            {
               throw new Exception("Item no longer available");
            }
            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(tag);
            entry.State = EntityState.Modified;
            context.SaveChanges();

            return tag;
        }
    }
}
