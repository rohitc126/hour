using BusinessLayer;
using BusinessLayer.DAL;
using BusinessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace eSGBIZ.Controllers
{
    public class HRMReadingController : BaseController
    {
        //
        // GET: /HRMReading/

        [Authorize]
        public ActionResult HourMeterHRMReadings()
        {
            ViewBag.Title = "Hour Meter HRM Readings";

            return View();
        }


        [Authorize]
        public ActionResult HourMeterHRMReadings_Entry(Nullable<DateTime> attDate)
        {
            ViewBag.Header = "Hour Meter HRM Readings Report";
            HourMeterReport MeterReport = new HourMeterReport();

            SelectDate _selectDate = new DAL_Common().GetSelect_Date(emp.Comp_Code, emp.BranchCode, "PRODUCTION_DATE");
            MeterReport.PRODUCTION_DATE = _selectDate.SELECT_DATE;
            MeterReport.hdnShiftTime = _selectDate.SHIFT_TIME;

            DateTime dt = attDate ?? DateTime.Now;
            MeterReport.PRODUCTION_DATE = dt.ToString("dd/MM/yyyy");

            return View(MeterReport);
        }

        public ActionResult _HourMeterHRMReadings_Dtl(string Shift_Code, string PRODUCTION_DATE)
        {

            List<HourMeterReport_Dtl> dtl = new DAL_HOUR_METER_HMR_READING().GET_HOUR_METER_READING_DTLS(emp.Comp_Code, emp.BranchCode, Shift_Code, PRODUCTION_DATE);
            HourMeterReport MeterReport = new HourMeterReport();
            MeterReport.HourMeterDtl_List = dtl;
            return PartialView("_HourMeterHRMReadings_Dtl", MeterReport);

        }

    //    [HttpPost]
    //    [SubmitButtonSelector(Name = "Save")]
    //    [ActionName("HourMeterHRMReadings_Entry")]
    //    public ActionResult HOUR_METER_HMR_READING_ENTRY_SAVE(HourMeterReport MeterReport)
    //    {
    //        ViewBag.Header = "Hour Meter Reading";

    //        var errors = ModelState.Where(x => x.Value.Errors.Count > 0).Select(x => new { x.Key, x.Value.Errors }).ToArray();

    //        if (ModelState.IsValid)
    //        {
    //            try
    //            {

    //                string result = new DAL_HOUR_METER_HMR_READING().INSERT_HOUR_METER_HMR_READING(emp.Comp_Code, emp.BranchCode, emp.Employee_Code, MeterReport);

    //                if (result == "")
    //                {
    //                    //string[] _date = MeterReport.PRODUCTION_DATE.Split('/');
    //                    //DateTime PRODUCTION_DATE = new DateTime(Convert.ToInt32(_date[2]), Convert.ToInt32(_date[1]), Convert.ToInt32(_date[0]));

    //                    Success(string.Format("<b>Hour Meter Reading inserted successfully.</b>"), true);
    //                    return RedirectToAction("HourMeterHRMReadings_Entry", "HRMReading");
    //                }
    //                else
    //                {
    //                    Danger(string.Format("<b>Error:</b>" + result), true);
    //                }
    //            }
    //            catch (Exception ex)
    //            {
    //                Danger(string.Format("<b>Error:</b>" + ex.Message), true);
    //            }
    //        }
    //        else
    //        {
    //            Danger(string.Format("<b>Error:102 :</b>" + string.Join("; ", ModelState.Values.SelectMany(z => z.Errors).Select(z => z.ErrorMessage))), true);
    //        }



    //        return View(MeterReport);
    //    }

    //}

        [HttpPost]
        [SubmitButtonSelector(Name = "Save")]
        [ActionName("HourMeterHRMReadings_Entry")]
        public ActionResult HOUR_METER_HMR_READING_ENTRY_SAVE(HourMeterReport MeterReport)
        {
            ViewBag.Header = "Hour Meter Reading";

            var errors = ModelState.Where(x => x.Value.Errors.Count > 0).Select(x => new { x.Key, x.Value.Errors }).ToArray();

            if (ModelState.IsValid)
            {
                try
                {

                    string result = new DAL_HOUR_METER_HMR_READING().INSERT_HOUR_METER_HMR_READING(emp.Comp_Code, emp.BranchCode, emp.Employee_Code, MeterReport);

                    if (result == "")
                    {
                        //string[] _date = MeterReport.PRODUCTION_DATE.Split('/');
                        //DateTime PRODUCTION_DATE = new DateTime(Convert.ToInt32(_date[2]), Convert.ToInt32(_date[1]), Convert.ToInt32(_date[0]));

                        Success(string.Format("<b>Hour Meter Reading inserted successfully.</b>"), true);
                        return RedirectToAction("HourMeterHRMReadings_Entry", "HRMReading");
                    }
                    else
                    {
                        Danger(string.Format("<b>Error:</b>" + result), true);
                    }
                }
                catch (Exception ex)
                {
                    Danger(string.Format("<b>Error:</b>" + ex.Message), true);
                }
            }
            else
            {
                Danger(string.Format("<b>Error:102 :</b>" + string.Join("; ", ModelState.Values.SelectMany(z => z.Errors).Select(z => z.ErrorMessage))), true);
            }



            return View(MeterReport);
        }

    }
    

        // [HttpPost]
        // [SubmitButtonSelector(Name = "Lock")]
        // [ActionName("HourMeterHRMReadings_Entry")]
        //public ActionResult HourMeterHRMReadings_Entry_Lock(HourMeterReport MeterReport)
        //{
        //    var errors = ModelState.Where(x => x.Value.Errors.Count > 0).Select(x => new { x.Key, x.Value.Errors }).ToArray();

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {

        //            decimal HMR_ID = MeterReport.HourMeterDtl_List[0].HMR_ID;
        //            string result = new DAL_HOUR_METER_HMR_READING().UPDATE_HOUR_METER_READING_LOCK(emp.Employee_Code, HMR_ID);

        //            if (result == "")
        //            {
        //               VIEW_HMR_METER_READING _METERREADING = new DAL_HOUR_METER_HMR_READING().GET_METER_READING(HMR_ID);
                    

        //                string _subject = "HOUR HMR METER READING " + _METERREADING.PRODUCTION_DATE;
                  

        //                StringBuilder sb = new StringBuilder();
        //                for (int i = 0; i < _METERREADING.READING_LISTREADING_LIST.Count(); i++)
        //                {

        //                    sb.Append("<td style='text-align:center'>" + Convert.ToString(_METERREADING.DAILY_REPORT_LIST[i].PM_NAME) + "</td>");
        //                    sb.Append("<td style='text-align:center'>" + Convert.ToString(_METERREADING.DAILY_REPORT_LIST[i].OPENING) + "</td>");
        //                    sb.Append("<td style='text-align:center'>" + Convert.ToString(_METERREADING.DAILY_REPORT_LIST[i].PRODUCTION) + "</td>");
        //                    sb.Append("<td style='text-align:center'>" + Convert.ToString(_METERREADING.DAILY_REPORT_LIST[i].DISPATCH) + "</td>");
        //                    sb.Append("<td style='text-align:center'>" + Convert.ToString(_METERREADING.DAILY_REPORT_LIST[i].CLOSING) + "</td>"); 
        //                    sb.Append("</tr>");
        //                }
                    
                         
        //                Success(string.Format("<b>Plant operation daily run sheet locked successfully.</b>"), true);
        //                return RedirectToAction("StockDailyReport_Entry", "PlantOperation");
        //            }
        //            else
        //            {
        //                Danger(string.Format("<b>Error:</b>" + result), true);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            Danger(string.Format("<b>Error:</b>" + ex.Message), true);
        //        }
        //    }
        //    else
        //    {
        //        Danger(string.Format("<b>Error:102 :</b>" + string.Join("; ", ModelState.Values.SelectMany(z => z.Errors).Select(z => z.ErrorMessage))), true);
        //    }

        //    return View(MeterReport);
        //}
    

       
}
