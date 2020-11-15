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
        public int hour = 12;
        public int[] hoursArray = new int[] { };
        public int[] hoursMinutes = new int[] { };
        public int[] simpleHours = new int[] {};
        public int[] days = new int[] { };
        public int day = 1;
        public string minuteFormat = "";
        public string dailyFormat = "";
        public string monthlyFormat = "";
        public string hourlyFormat = "";
        public string weeklyFormat = "";
        public int simpleHour = 1;
        public int complexMinutes = 00;
        public bool CheckBoxeveryday = true;
        public bool CheckBoxeveryweekday = false;
        public bool complexMonth = true;
        public bool complexMonth2 = false;
        public int[] months = new int[] { };
        public List<codedDecoded> forWeeklyCron = new List<codedDecoded>();
        public bool isDisabled1 = true;
        public bool isDisabled2 =false;
        public int month=1;
        public string[] dayoftheWeek = new string[] {"Monday", "Tuesday","Wednesday", "Thursday", "Friday","Saturday","Sunday"};
        IEnumerable<string> multipleDays = new string[] {  };
        protected async System.Threading.Tasks.Task Load()
        {


            //addSheets();
            try
            {

                this.minutesArray = Enumerable.Range(1, 59).ToArray();
                this.hoursArray= Enumerable.Range(00, 24).ToArray();
                this.hoursMinutes = Enumerable.Range(00, 59).ToArray();
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
        }
        public async Task generatehourlyCron(MouseEventArgs args)
          {
            //   var cron=CronExpression.EveryHo

            var ce1 = CronExpression.EveryNHours(simpleHour);
            hourlyFormat = ce1.ToString();
        }
       
        public async Task generatedailyCron(MouseEventArgs args)
        {
            if (dailyFormat != "")
                dailyFormat = "";
            if(CheckBoxeveryday==true)
            {
              
                var cron = CronExpression.EveryDayAt(hour,complexMinutes);
                dailyFormat = cron.ToString();
            }
            if (CheckBoxeveryweekday == true)
            {

                var cron = CronExpression.EveryWeekDayAt(hour, complexMinutes);
               dailyFormat = cron.ToString();
            }

        }

        public async Task generateweeklyCron(MouseEventArgs args)
        {
            if (weeklyFormat != "")
                weeklyFormat = "";
            if(complexMonth==true)
            {
                var cron = CronExpression.EveryNWeek(day);
                weeklyFormat = cron.ToString();
            }
            else
            {
                var cron = CronExpression.EverySpecificWeekDayAt(hour, complexMinutes, multipleDays.ToArray());
                weeklyFormat = cron.ToString();
            }
        
        }

        public async Task generateadvancedmonthlyCron(MouseEventArgs args)
        {
            if (monthlyFormat != "")
                monthlyFormat = "";
            var cron = CronExpression.EverySpecificDayEveryNMonthAt(day, month, hour, complexMinutes);
            monthlyFormat = cron;

        }
    }
}
