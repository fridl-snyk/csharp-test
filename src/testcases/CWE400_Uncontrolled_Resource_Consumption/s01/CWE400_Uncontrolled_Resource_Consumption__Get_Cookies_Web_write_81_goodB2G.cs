/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE400_Uncontrolled_Resource_Consumption__Get_Cookies_Web_write_81_goodB2G.cs
Label Definition File: CWE400_Uncontrolled_Resource_Consumption.label.xml
Template File: sources-sinks-81_goodB2G.tmpl.cs
*/
/*
 * @description
 * CWE: 400 Uncontrolled Resource Consumption
 * BadSource: Get_Cookies_Web Read count from the first cookie using Cookies
 * GoodSource: A hardcoded non-zero, non-min, non-max, even number
 * Sinks: write
 *    GoodSink: Write to a file count number of times, but first validate count
 *    BadSink : Write to a file count number of times
 * Flow Variant: 81 Data flow: data passed in a parameter to an abstract method
 *
 * */
#if (!OMITGOOD)

using TestCaseSupport;
using System;

using System.IO;

using System.Web;

namespace testcases.CWE400_Uncontrolled_Resource_Consumption
{
class CWE400_Uncontrolled_Resource_Consumption__Get_Cookies_Web_write_81_goodB2G : CWE400_Uncontrolled_Resource_Consumption__Get_Cookies_Web_write_81_base
{

    public override void Action(int count , HttpRequest req, HttpResponse resp)
    {
        /* FIX: Validate count before using it as the for loop variant to write to a file */
        if (count > 0 && count <= 20)
        {
            int i;
            using (StreamWriter file = new StreamWriter(@"badSink.txt"))
            {
                /* POTENTIAL FLAW: Do not validate count before using it as the for loop variant to write to a file */
                for (i = 0; i < count; i++)
                {
                    try
                    {
                        file.Write("Hello");
                    }
                    catch (IOException exceptIO)
                    {
                        IO.Logger.Log(NLog.LogLevel.Warn, "Error with stream writing", exceptIO);
                    }
                }
                /* Close stream reading objects */
                try
                {
                    if (file != null)
                    {
                        file.Close();
                    }
                }
                catch (IOException exceptIO)
                {
                    IO.Logger.Log(NLog.LogLevel.Warn, "Error closing Stream Writer", exceptIO);
                }
            }
        }
    }
}
}
#endif
