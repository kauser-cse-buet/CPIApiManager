using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CPIApiManager
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string currentMonthCpiValue = "";
                CPIApiManager cpiApiMan = new CPIApiManager();

                string cpiRequest = cpiApiMan.CreateRequest();
                Response cpiResponse = cpiApiMan.MakeRequest(cpiRequest);

                if (cpiResponse != null)
                {
                    if (cpiResponse.Results != null)
                    {
                        if (cpiResponse.Results.Series != null)
                        {
                            foreach (var item in  cpiResponse.Results.Series[0].Data)
                            {
                                if (item.Year == "2015" && item.PeriodName == "October")
                                {
                                    currentMonthCpiValue = item.Value;
                                }
                            }
                        }
                    }
                }

                Console.WriteLine("currentMonthCpiValue: " + currentMonthCpiValue);

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
