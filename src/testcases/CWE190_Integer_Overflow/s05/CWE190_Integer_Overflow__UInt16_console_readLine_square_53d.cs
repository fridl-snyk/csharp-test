/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE190_Integer_Overflow__UInt16_console_readLine_square_53d.cs
Label Definition File: CWE190_Integer_Overflow.label.xml
Template File: sources-sinks-53d.tmpl.cs
*/
/*
 * @description
 * CWE: 190 Integer Overflow
 * BadSource: console_readLine Read data from the console using readLine
 * GoodSource: A hardcoded non-zero, non-min, non-max, even number
 * Sinks: square
 *    GoodSink: Ensure there will not be an overflow before squaring data
 *    BadSink : Square data, which can lead to overflow
 * Flow Variant: 53 Data flow: data passed as an argument from one method through two others to a fourth; all four functions are in different classes in the same package
 *
 * */

using TestCaseSupport;
using System;

using System.Web;

namespace testcases.CWE190_Integer_Overflow
{
class CWE190_Integer_Overflow__UInt16_console_readLine_square_53d
{
#if (!OMITBAD)
    public static void BadSink(ushort data )
    {
        /* POTENTIAL FLAW: if (data*data) > ushort.MaxValue, this will overflow */
        ushort result = (ushort)(data * data);
        IO.WriteLine("result: " + result);
    }
#endif

#if (!OMITGOOD)
    /* goodG2B() - use goodsource and badsink */
    public static void GoodG2BSink(ushort data )
    {
        /* POTENTIAL FLAW: if (data*data) > ushort.MaxValue, this will overflow */
        ushort result = (ushort)(data * data);
        IO.WriteLine("result: " + result);
    }

    /* goodB2G() - use badsource and goodsink */
    public static void GoodB2GSink(ushort data )
    {
        /* FIX: Add a check to prevent an overflow from occurring */
        if (Math.Abs((long)data) <= (long)Math.Sqrt(ushort.MaxValue))
        {
            ushort result = (ushort)(data * data);
            IO.WriteLine("result: " + result);
        }
        else
        {
            IO.WriteLine("data value is too large to perform squaring.");
        }
    }
#endif
}
}
