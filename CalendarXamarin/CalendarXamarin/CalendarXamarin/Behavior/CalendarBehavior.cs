using Syncfusion.SfCalendar.XForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace CalendarXamarin.Behavior
{
    class CalendarBehavior : Behavior<ContentPage>
    {
        SfCalendar calendar;
        protected override void OnAttachedTo(ContentPage bindable)
        {
            base.OnAttachedTo(bindable);
            calendar = bindable.FindByName<SfCalendar>("calendar");
            this.WireEvents();
        }

        private void WireEvents()
        {
            this.calendar.OnMonthCellLoaded += Calendar_OnMonthCellLoaded;
        }

        private void Calendar_OnMonthCellLoaded(object sender, MonthCellLoadedEventArgs e)
        {
            var model = new ViewModel();
            model.DayNumber = e.Date.Day.ToString();

            if (Convert.ToDateTime(calendar.SelectedDate).Day == e.Date.Day && Convert.ToDateTime(calendar.SelectedDate).Month == e.Date.Month && Convert.ToDateTime(calendar.SelectedDate).Year == e.Date.Year)
            {
                model.IsSelected = true;
            }

            e.CellBindingContext = model;
        }

        private void UnWireEvents()
        {
            this.calendar.OnMonthCellLoaded += Calendar_OnMonthCellLoaded;
        }

        protected override void OnDetachingFrom(ContentPage bindable)
        {
            base.OnDetachingFrom(bindable);
            this.UnWireEvents();
        }
    }
}
