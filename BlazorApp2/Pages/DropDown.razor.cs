using BlazorApp2.Helpers.QlikSense.Connection;
using Microsoft.AspNetCore.Components;
using Qlik.Engine;
using Qlik.Sense.Client;
using RlvMailer;
using Syncfusion.Blazor.PivotView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Net.WebSockets;
using Qlik.Sense.Client;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.Localization.Internal;
using Radzen;

namespace BlazorApp2.Pages
{
    public partial class DropDown
    {
        [Inject]
        protected RlvMailerService RlvMailer { get; set; }
        public static string errMessage = "";
        protected override async System.Threading.Tasks.Task OnInitializedAsync()
        {
            try
            {

                await Load();
                //addNames();
            }
            catch (Exception e)
            {
                errMessage = e.Message;
                throw e;
            }


        }
        public class codedDecoded
        {
            public string coded
            {
                get;
                set;

            }
            public string decoded
            {
                get;set;
            }
        }
        //Data declaration:

        public int[] minutesArray = new int[] { };
        public int minutes = 1;
        public string hour = "12";
        public Months monthofTheYear = Months.January;
        public string[] hoursArray = new string[] { };
        public string[] hoursMinutes = new string[] { };
        public int[] simpleHours = new int[] {};
        public int[] days = new int[] { };
        public int day = 1;
        public string minuteFormat = "";
        public string dailyFormat = "";
        public string monthlyFormat = "";
        public string hourlyFormat = "";
        public string weeklyFormat = "";
        public string yearlyFormat = "";
        public int simpleHour = 1;
        public string complexMinutes = "00";
        public bool CheckBoxeveryday = true;
        public bool CheckBoxeveryweekday = false;
        public bool complexMonth = true;
        public bool complexMonth2 = false;
        public int[] months = new int[] { };
        public List<codedDecoded> forWeeklyCron = new List<codedDecoded>();
        public bool isDisabled1 = true;
        public bool isDisabled2 =false;
        public int month=1;
        [Inject]
        protected NotificationService NotificationService { get; set; }
        public string[] dayoftheWeek = new string[] {"Monday", "Tuesday","Wednesday", "Thursday", "Friday","Saturday","Sunday"};
        IEnumerable<string> multipleDays = new string[] {  };
        public Months[] monthsofTheYear = new Months[12] { Months.January,Months.February,Months.March,Months.April, Months.May, Months.June, Months.July, Months.August, Months.September,
                                            Months.October, Months.November, Months.December};

        protected async System.Threading.Tasks.Task Load()
        {


            
            try
            {
                int[] hoursminutes2 = new int[] { };
                int[] hoursArray2 = new int[] { };
                this.minutesArray = Enumerable.Range(1, 59).ToArray();
                hoursArray2= Enumerable.Range(00, 24).ToArray();
                hoursminutes2 = Enumerable.Range(00, 59).ToArray();
                this.days = Enumerable.Range(1, 31).ToArray();
                this.months = Enumerable.Range(1, 12).ToArray();
                this.simpleHours = Enumerable.Range(1, 24).ToArray();
                forWeeklyCron.Add(new codedDecoded() { coded = "MON", decoded = "Monday" });
                forWeeklyCron.Add(new codedDecoded() { coded = "TUE", decoded = "Tuesday" });
                forWeeklyCron.Add(new codedDecoded() { coded = "WED", decoded = "Wednesday" });
                forWeeklyCron.Add(new codedDecoded() { coded = "THU", decoded = "Thursday" });
                forWeeklyCron.Add(new codedDecoded() { coded = "FRI", decoded = "Friday" });
                forWeeklyCron.Add(new codedDecoded() { coded = "SAT", decoded = "Satruday" });
                forWeeklyCron.Add(new codedDecoded() { coded = "SUN", decoded = "Sunday" });
            
              this.hoursMinutes = hoursminutes2.Select(x => x.ToString()).ToArray();
                this.hoursArray= hoursArray2.Select(x => x.ToString()).ToArray();
                for (int i = 0; i < 9; i++)
                {
                    this.hoursMinutes[i] = string.Format("{0:00}", hoursminutes2[i]);
                    this.hoursArray[i]= string.Format("{0:00}", hoursArray2[i]);
                }

            }
            catch (SocketException e)
            {
                errMessage = e.Message;
                throw e;

            }
            catch (WebSocketException e)
            {
                errMessage = e.Message;
                throw e;
            }
            catch (HttpRequestException e)
            {
                errMessage = e.Message;
                throw e;
            }
            catch (Exception e)
            {
                errMessage = e.Message;
                throw e;
            }





        }

        public async Task generateMinuteCron(MouseEventArgs args)
        {
            if (minuteFormat != "")
                minuteFormat = "";
            var ce1 = CronExpression.EveryNMinutes(minutes);
            minuteFormat = ce1.ToString();
            try
            {

                var descriptCron = CronExpressionDescriptor.ExpressionDescriptor.GetDescription(ce1);

            }
            catch (Exception e)
            {
                NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Invalid cron expression");
               minuteFormat = "";
                throw;
            }
        }
        public async Task generatehourlyCron(MouseEventArgs args)
          {
            //   var cron=CronExpression.EveryHo

            var ce1 = CronExpression.EveryNHours(simpleHour);
            hourlyFormat = ce1.ToString();
          
            try
            {
                
                var descriptCron = CronExpressionDescriptor.ExpressionDescriptor.GetDescription(ce1);
               
            } catch(Exception e)
            {
                NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Invalid cron expression");
                hourlyFormat = "";
                throw;
            }
          
        }
       
        public async Task generatedailyCron(MouseEventArgs args)
        {
            if (dailyFormat != "")
                dailyFormat = "";
            if(CheckBoxeveryday==true)
            {
              
                var cron = CronExpression.EveryDayAt(Int32.Parse(hour), Int32.Parse(complexMinutes));
                dailyFormat = cron.ToString();
                try
                {

                    var descriptCron = CronExpressionDescriptor.ExpressionDescriptor.GetDescription(cron);

                }
                catch (Exception e)
                {
                    NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Invalid cron expression");
                    dailyFormat = "";
                    throw;
                }
            }
            if (CheckBoxeveryweekday == true)
            {

                var cron = CronExpression.EveryWeekDayAt(Int32.Parse(hour), Int32.Parse(complexMinutes));
               dailyFormat = cron.ToString();
                try
                {

                    var descriptCron = CronExpressionDescriptor.ExpressionDescriptor.GetDescription(cron);

                }
                catch (Exception e)
                {
                    NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Invalid cron expression");
                    dailyFormat = "";
                    throw;
                }
            }

        }

        public async Task generateweeklyCron(MouseEventArgs args)
        {
            if (weeklyFormat != "")
                weeklyFormat = "";

            if (multipleDays.Count() != 0)
            {
                var cron = CronExpression.EverySpecificWeekDayAt(Int32.Parse(hour), Int32.Parse(complexMinutes), multipleDays.ToArray());
                weeklyFormat = cron.ToString();
                try
                {

                    var descriptCron = CronExpressionDescriptor.ExpressionDescriptor.GetDescription(cron);

                }
                catch (Exception e)
                {
                    NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Invalid cron expression");
                    weeklyFormat = "";
                    throw;
                }
            }
          
            
        
        }

        public async Task generateadvancedmonthlyCron(MouseEventArgs args)
        {
            if (monthlyFormat != "")
                monthlyFormat = "";
            if(complexMonth==true)
            {
                var cron = CronExpression.EveryNMonth(day);
                monthlyFormat = cron;
                try
                {

                    var descriptCron = CronExpressionDescriptor.ExpressionDescriptor.GetDescription(cron);

                }
                catch (Exception e)
                {
                    NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Invalid cron expression");
                    monthlyFormat = "";
                    throw;
                }
            }
            else
            {
                var cron = CronExpression.EverySpecificDayEveryNMonthAt(day, month, Int32.Parse(hour), Int32.Parse(complexMinutes));
                monthlyFormat = cron;
                try
                {

                    var descriptCron = CronExpressionDescriptor.ExpressionDescriptor.GetDescription(cron);

                }
                catch (Exception e)
                {
                    NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Invalid cron expression");
                    monthlyFormat = "";
                    throw;
                }
            }
           

        }

        public async Task generateaYearlyCron(MouseEventArgs args)
        {
            var cron = CronExpression.EverySpecificDayOfMonthAt(monthofTheYear, 1, 12, 0);
            yearlyFormat = cron;
            try
            {

                var descriptCron = CronExpressionDescriptor.ExpressionDescriptor.GetDescription(cron);

            }
            catch (Exception e)
            {
                NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Invalid cron expression");
                yearlyFormat = "";
                throw;
            }

        }
    }
}
