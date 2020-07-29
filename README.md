# How to customize month cell selection in Xamarin.Forms Calendar (SfCalendar)

You can customize the month cell with a custom selection by using the [CellTemplate](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.SfCalendar.XForms~Syncfusion.SfCalendar.XForms.MonthViewSettings~CellTemplate.html?) property of [MonthViewSettings](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.SfCalendar.XForms~Syncfusion.SfCalendar.XForms.MonthViewSettings.html?) and [OnMonthCellLoaded](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.SfCalendar.XForms~Syncfusion.SfCalendar.XForms.SfCalendar~OnMonthCellLoaded_EV.html?) event of SfCalendar in Xamarin.Forms.

You can also refer the following article.

https://www.syncfusion.com/kb/11790/how-to-customize-month-cell-selection-in-xamarin-forms-calendar-sfcalendar

**STEP 1:** The **CellTemplate** is defined with the circle by Frame. The selection is handled by the **IsSelected** property from **ViewModel**.

``` xml
<calendar:SfCalendar x:Name="calendar"
                             SelectionMode="SingleSelection" 
                             DataSource="{Binding Appointments}">
            <calendar:SfCalendar.MonthViewSettings>
                        <calendar:MonthViewSettings CellGridOptions="None" 
                                                      BorderColor="Transparent"
                                                      DayLabelTextAlignment="Center"
                                                      DateSelectionColor="Transparent"
                                                      TodaySelectionBackgroundColor="Transparent"
                                                      TodayTextColor="Transparent">
                            <!-- Month Cell Template -->
                            <calendar:MonthViewSettings.CellTemplate>
                                <DataTemplate>
                                    <AbsoluteLayout BackgroundColor="Transparent" 
                                                    Margin="0" 
                                                    Padding="0">
                                        <Frame IsVisible="{Binding IsSelected}" 
                                               BackgroundColor="Transparent"
                                               BorderColor="DarkBlue"
                                               HasShadow="false" 
                                               AbsoluteLayout.LayoutBounds="0.5,0.5,30,30" 
                                               AbsoluteLayout.LayoutFlags="PositionProportional" 
                                               CornerRadius="15" 
                                               HeightRequest="30" 
                                               WidthRequest="30" 
                                               VerticalOptions="Center" 
                                               HorizontalOptions="Center">
                                        </Frame>
                                        <Label FontSize="13" 
                                               FontAttributes="None" 
                                               LineBreakMode="TailTruncation" 
                                               HorizontalTextAlignment="Center" 
                                               VerticalTextAlignment="Center" 
                                               AbsoluteLayout.LayoutBounds="0.5,0.5,1,1" 
                                               AbsoluteLayout.LayoutFlags="All" 
                                               Text="{Binding DayNumber}"
                                               TextColor="{Binding DateTextColor}"
                                               />
                                    </AbsoluteLayout>
                                </DataTemplate>
                            </calendar:MonthViewSettings.CellTemplate>
                        </calendar:MonthViewSettings>
                    </calendar:SfCalendar.MonthViewSettings>
            <calendar:SfCalendar.BindingContext>
                <local:ViewModel/>
            </calendar:SfCalendar.BindingContext>
</calendar:SfCalendar>
```

**STEP 2:** The [CellBindingContext](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.SfCalendar.XForms~Syncfusion.SfCalendar.XForms.MonthCell~CellBindingContext.html?) is updated in the **OnMenthCellLoaded** event based on the **SelectedDate**.

``` c#
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
```
**Output**

![MonthCellSelection](https://github.com/SyncfusionExamples/customize-month-cell-selection-calendar-xamarin/blob/master/ScreenShot/MonthCellSelection.png)
