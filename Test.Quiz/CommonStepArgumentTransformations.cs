using Domain.Quiz.QuizSession;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Quiz
{
    [Binding]
    public class CommonStepArgumentTransformations
    {
        [StepArgumentTransformation(@"^Today$")]
        public DateTime TodayToDateTime()
        {
            return DateTime.Today;
        }

        [StepArgumentTransformation(@"^Yesterday$")]
        public DateTime YesterdayToDateTime()
        {
            return DateTime.Today.AddDays(-1);
        }

        [StepArgumentTransformation(@"in (\d+) days at (\d{2}):(\d{2})")]
        public DateTime InDaysToDateTime(int days, int hour, int minute)
        {
            var date = DateTime.Today.AddDays(days);
            return new DateTime(date.Year, date.Month, date.Day, hour, minute, 0);
        }


        [StepArgumentTransformation(@"(\d{2}).(\d{2}).(\d{4})")]
        [StepArgumentTransformation(@"(\d{2})-(\d{2})-(\d{4})")]
        [StepArgumentTransformation(@"(\d{2})/(\d{2})/(\d{4})")]
        public DateTime DotToDateTime(int day, int month, int year)
        {
            return new DateTime(year, month, day);
        }





    }
}
