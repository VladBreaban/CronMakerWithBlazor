using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;

using RlvMailer.Models.RlvMailer;

namespace RlvMailer.Data
{
  public partial class RlvMailerContext : Microsoft.EntityFrameworkCore.DbContext
  {
    public RlvMailerContext(DbContextOptions<RlvMailerContext> options):base(options)
    {
    }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(local)\\SQLEXPRESS;Initial Catalog=RLV_QSMAILER;Persist Security Info=False;Integrated Security=true;MultipleActiveResultSets=True;Encrypt=false;TrustServerCertificate=true;Connection Timeout=30");
            }
        }
        public RlvMailerContext()
    {
    }

    partial void OnModelBuilding(ModelBuilder builder);

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<RlvMailer.Models.RlvMailer.Actiuni>().HasKey(table => new {
          table.id_app, table.data_actiune
        });
        builder.Entity<RlvMailer.Models.RlvMailer.QrtzBlobTrigger>().HasKey(table => new {
          table.SCHED_NAME, table.TRIGGER_NAME, table.TRIGGER_GROUP
        });
        builder.Entity<RlvMailer.Models.RlvMailer.QrtzCalendar>().HasKey(table => new {
          table.SCHED_NAME, table.CALENDAR_NAME
        });
        builder.Entity<RlvMailer.Models.RlvMailer.QrtzCronTrigger>().HasKey(table => new {
          table.SCHED_NAME, table.TRIGGER_NAME, table.TRIGGER_GROUP
        });
        builder.Entity<RlvMailer.Models.RlvMailer.QrtzFiredTrigger>().HasKey(table => new {
          table.SCHED_NAME, table.ENTRY_ID
        });
        builder.Entity<RlvMailer.Models.RlvMailer.QrtzJobDetail>().HasKey(table => new {
          table.SCHED_NAME, table.JOB_NAME, table.JOB_GROUP
        });
        builder.Entity<RlvMailer.Models.RlvMailer.QrtzLock>().HasKey(table => new {
          table.SCHED_NAME, table.LOCK_NAME
        });
        builder.Entity<RlvMailer.Models.RlvMailer.QrtzPausedTriggerGrp>().HasKey(table => new {
          table.SCHED_NAME, table.TRIGGER_GROUP
        });
        builder.Entity<RlvMailer.Models.RlvMailer.QrtzSchedulerState>().HasKey(table => new {
          table.SCHED_NAME, table.INSTANCE_NAME
        });
        builder.Entity<RlvMailer.Models.RlvMailer.QrtzSimpleTrigger>().HasKey(table => new {
          table.SCHED_NAME, table.TRIGGER_NAME, table.TRIGGER_GROUP
        });
        builder.Entity<RlvMailer.Models.RlvMailer.QrtzSimpropTrigger>().HasKey(table => new {
          table.SCHED_NAME, table.TRIGGER_NAME, table.TRIGGER_GROUP
        });
        builder.Entity<RlvMailer.Models.RlvMailer.QrtzTrigger>().HasKey(table => new {
          table.SCHED_NAME, table.TRIGGER_NAME, table.TRIGGER_GROUP
        });
        builder.Entity<RlvMailer.Models.RlvMailer.ExternalEmail>()
              .HasOne(i => i.Report)
              .WithMany(i => i.ExternalEmails)
              .HasForeignKey(i => i.report_id)
              .HasPrincipalKey(i => i.report_id);
        builder.Entity<RlvMailer.Models.RlvMailer.LogReport>()
              .HasOne(i => i.Report)
              .WithMany(i => i.LogReports)
              .HasForeignKey(i => i.report_id)
              .HasPrincipalKey(i => i.report_id);
        builder.Entity<RlvMailer.Models.RlvMailer.QrtzCronTrigger>()
              .HasOne(i => i.QrtzTrigger)
              .WithMany(i => i.QrtzCronTriggers)
              .HasForeignKey(i => new { i.SCHED_NAME, i.TRIGGER_NAME, i.TRIGGER_GROUP })
              .HasPrincipalKey(i => new { i.SCHED_NAME, i.TRIGGER_NAME, i.TRIGGER_GROUP });
        builder.Entity<RlvMailer.Models.RlvMailer.QrtzSimpleTrigger>()
              .HasOne(i => i.QrtzTrigger)
              .WithMany(i => i.QrtzSimpleTriggers)
              .HasForeignKey(i => new { i.SCHED_NAME, i.TRIGGER_NAME, i.TRIGGER_GROUP })
              .HasPrincipalKey(i => new { i.SCHED_NAME, i.TRIGGER_NAME, i.TRIGGER_GROUP });
        builder.Entity<RlvMailer.Models.RlvMailer.QrtzSimpropTrigger>()
              .HasOne(i => i.QrtzTrigger)
              .WithMany(i => i.QrtzSimpropTriggers)
              .HasForeignKey(i => new { i.SCHED_NAME, i.TRIGGER_NAME, i.TRIGGER_GROUP })
              .HasPrincipalKey(i => new { i.SCHED_NAME, i.TRIGGER_NAME, i.TRIGGER_GROUP });
        builder.Entity<RlvMailer.Models.RlvMailer.QrtzTrigger>()
              .HasOne(i => i.QrtzJobDetail)
              .WithMany(i => i.QrtzTriggers)
              .HasForeignKey(i => new { i.SCHED_NAME, i.JOB_NAME, i.JOB_GROUP })
              .HasPrincipalKey(i => new { i.SCHED_NAME, i.JOB_NAME, i.JOB_GROUP });
        builder.Entity<RlvMailer.Models.RlvMailer.QsVirtualProxy>()
              .HasOne(i => i.Q)
              .WithMany(i => i.QsVirtualProxies)
              .HasForeignKey(i => i.qs_id)
              .HasPrincipalKey(i => i.qs_id);
        builder.Entity<RlvMailer.Models.RlvMailer.QsVirtualProxy>()
              .HasOne(i => i.AuthMethod)
              .WithMany(i => i.QsVirtualProxies)
              .HasForeignKey(i => i.virtual_proxy_auth_method_id)
              .HasPrincipalKey(i => i.auth_method_id);
        builder.Entity<RlvMailer.Models.RlvMailer.Report>()
              .HasOne(i => i.Setting)
              .WithMany(i => i.Reports)
              .HasForeignKey(i => i.app_id)
              .HasPrincipalKey(i => i.app_id);
        builder.Entity<RlvMailer.Models.RlvMailer.Report>()
              .HasOne(i => i.Mail)
              .WithMany(i => i.Reports)
              .HasForeignKey(i => i.srv_mail_id)
              .HasPrincipalKey(i => i.srv_mail_id);
        builder.Entity<RlvMailer.Models.RlvMailer.Report>()
              .HasOne(i => i.Q)
              .WithMany(i => i.Reports)
              .HasForeignKey(i => i.qs_id)
              .HasPrincipalKey(i => i.qs_id);
        builder.Entity<RlvMailer.Models.RlvMailer.ReportLine>()
              .HasOne(i => i.Report)
              .WithMany(i => i.ReportLines)
              .HasForeignKey(i => i.report_id)
              .HasPrincipalKey(i => i.report_id);
        builder.Entity<RlvMailer.Models.RlvMailer.ReportLineImg>()
              .HasOne(i => i.ReportLine)
              .WithMany(i => i.ReportLineImgs)
              .HasForeignKey(i => i.report_line_id)
              .HasPrincipalKey(i => i.report_line_id);
        builder.Entity<RlvMailer.Models.RlvMailer.ReportLineText>()
              .HasOne(i => i.ReportLine)
              .WithMany(i => i.ReportLineTexts)
              .HasForeignKey(i => i.report_line_id)
              .HasPrincipalKey(i => i.report_line_id);
        builder.Entity<RlvMailer.Models.RlvMailer.ReportLineXl>()
              .HasOne(i => i.ReportLine)
              .WithMany(i => i.ReportLineXls)
              .HasForeignKey(i => i.report_line_id)
              .HasPrincipalKey(i => i.report_line_id);
        builder.Entity<RlvMailer.Models.RlvMailer.ReportSelection>()
              .HasOne(i => i.Report)
              .WithMany(i => i.ReportSelections)
              .HasForeignKey(i => i.report_id)
              .HasPrincipalKey(i => i.report_id);
        builder.Entity<RlvMailer.Models.RlvMailer.ReportSelectionsDate>()
              .HasOne(i => i.Report)
              .WithMany(i => i.ReportSelectionsDates)
              .HasForeignKey(i => i.report_id)
              .HasPrincipalKey(i => i.report_id);
        builder.Entity<RlvMailer.Models.RlvMailer.ReportSelectionsDateOverride>()
              .HasOne(i => i.Report)
              .WithMany(i => i.ReportSelectionsDateOverrides)
              .HasForeignKey(i => i.report_id)
              .HasPrincipalKey(i => i.report_id);
        builder.Entity<RlvMailer.Models.RlvMailer.ReportsExecCondition>()
              .HasOne(i => i.Report)
              .WithMany(i => i.ReportsExecConditions)
              .HasForeignKey(i => i.report_id)
              .HasPrincipalKey(i => i.report_id);
        builder.Entity<RlvMailer.Models.RlvMailer.Setting>()
              .HasOne(i => i.Country)
              .WithMany(i => i.Settings)
              .HasForeignKey(i => i.app_country_code)
              .HasPrincipalKey(i => i.code);
        builder.Entity<RlvMailer.Models.RlvMailer.Tag>()
              .HasOne(i => i.Report)
              .WithMany(i => i.Tags)
              .HasForeignKey(i => i.report_id)
              .HasPrincipalKey(i => i.report_id);


        builder.Entity<RlvMailer.Models.RlvMailer.Actiuni>()
              .Property(p => p.data_actiune)
              .HasColumnType("date");

        builder.Entity<RlvMailer.Models.RlvMailer.LogApp>()
              .Property(p => p.event_date)
              .HasColumnType("datetime");

        builder.Entity<RlvMailer.Models.RlvMailer.LogEvent>()
              .Property(p => p.TimeStamp)
              .HasColumnType("datetime");

        builder.Entity<RlvMailer.Models.RlvMailer.LogReport>()
              .Property(p => p.event_date)
              .HasColumnType("datetime");

        builder.Entity<RlvMailer.Models.RlvMailer.Mail>()
              .Property(p => p.srv_mail_last_date_ok)
              .HasColumnType("datetime");

        builder.Entity<RlvMailer.Models.RlvMailer.Q>()
              .Property(p => p.qs_last_date_ok)
              .HasColumnType("datetime");

        builder.Entity<RlvMailer.Models.RlvMailer.ReportSelectionsDate>()
              .Property(p => p.report_selections_date_value)
              .HasColumnType("date");

        builder.Entity<RlvMailer.Models.RlvMailer.Setting>()
              .Property(p => p.app_valid_up_to)
              .HasColumnType("date");

        builder.Entity<RlvMailer.Models.RlvMailer.Setting>()
              .Property(p => p.app_last_report_date)
              .HasColumnType("datetime");

        this.OnModelBuilding(builder);
    }


    public DbSet<RlvMailer.Models.RlvMailer.Actiuni> Actiunis
    {
      get;
      set;
    }

    public DbSet<RlvMailer.Models.RlvMailer.AuthMethod> AuthMethods
    {
      get;
      set;
    }

    public DbSet<RlvMailer.Models.RlvMailer.Country> Countries
    {
      get;
      set;
    }

    public DbSet<RlvMailer.Models.RlvMailer.ExternalEmail> ExternalEmails
    {
      get;
      set;
    }

    public DbSet<RlvMailer.Models.RlvMailer.LogApp> LogApps
    {
      get;
      set;
    }

    public DbSet<RlvMailer.Models.RlvMailer.LogEvent> LogEvents
    {
      get;
      set;
    }

    public DbSet<RlvMailer.Models.RlvMailer.LogReport> LogReports
    {
      get;
      set;
    }

    public DbSet<RlvMailer.Models.RlvMailer.Mail> Mails
    {
      get;
      set;
    }

    public DbSet<RlvMailer.Models.RlvMailer.Q> Qs
    {
      get;
      set;
    }

    public DbSet<RlvMailer.Models.RlvMailer.QrtzBlobTrigger> QrtzBlobTriggers
    {
      get;
      set;
    }

    public DbSet<RlvMailer.Models.RlvMailer.QrtzCalendar> QrtzCalendars
    {
      get;
      set;
    }

    public DbSet<RlvMailer.Models.RlvMailer.QrtzCronTrigger> QrtzCronTriggers
    {
      get;
      set;
    }

    public DbSet<RlvMailer.Models.RlvMailer.QrtzFiredTrigger> QrtzFiredTriggers
    {
      get;
      set;
    }

    public DbSet<RlvMailer.Models.RlvMailer.QrtzJobDetail> QrtzJobDetails
    {
      get;
      set;
    }

    public DbSet<RlvMailer.Models.RlvMailer.QrtzLock> QrtzLocks
    {
      get;
      set;
    }

    public DbSet<RlvMailer.Models.RlvMailer.QrtzPausedTriggerGrp> QrtzPausedTriggerGrps
    {
      get;
      set;
    }

    public DbSet<RlvMailer.Models.RlvMailer.QrtzSchedulerState> QrtzSchedulerStates
    {
      get;
      set;
    }

    public DbSet<RlvMailer.Models.RlvMailer.QrtzSimpleTrigger> QrtzSimpleTriggers
    {
      get;
      set;
    }

    public DbSet<RlvMailer.Models.RlvMailer.QrtzSimpropTrigger> QrtzSimpropTriggers
    {
      get;
      set;
    }

    public DbSet<RlvMailer.Models.RlvMailer.QrtzTrigger> QrtzTriggers
    {
      get;
      set;
    }

    public DbSet<RlvMailer.Models.RlvMailer.QsVirtualProxy> QsVirtualProxies
    {
      get;
      set;
    }

    public DbSet<RlvMailer.Models.RlvMailer.Report> Reports
    {
      get;
      set;
    }

    public DbSet<RlvMailer.Models.RlvMailer.ReportLine> ReportLines
    {
      get;
      set;
    }

    public DbSet<RlvMailer.Models.RlvMailer.ReportLineImg> ReportLineImgs
    {
      get;
      set;
    }

    public DbSet<RlvMailer.Models.RlvMailer.ReportLineText> ReportLineTexts
    {
      get;
      set;
    }

    public DbSet<RlvMailer.Models.RlvMailer.ReportLineXl> ReportLineXls
    {
      get;
      set;
    }

    public DbSet<RlvMailer.Models.RlvMailer.ReportSelection> ReportSelections
    {
      get;
      set;
    }

    public DbSet<RlvMailer.Models.RlvMailer.ReportSelectionsDate> ReportSelectionsDates
    {
      get;
      set;
    }

    public DbSet<RlvMailer.Models.RlvMailer.ReportSelectionsDateOverride> ReportSelectionsDateOverrides
    {
      get;
      set;
    }

    public DbSet<RlvMailer.Models.RlvMailer.ReportsExecCondition> ReportsExecConditions
    {
      get;
      set;
    }

    public DbSet<RlvMailer.Models.RlvMailer.Setting> Settings
    {
      get;
      set;
    }

    public DbSet<RlvMailer.Models.RlvMailer.Tag> Tags
    {
      get;
      set;
    }
  }
}
