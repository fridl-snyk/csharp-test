/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE190_Integer_Overflow__Long_console_readLine_add_71b.cs
Label Definition File: CWE190_Integer_Overflow.label.xml
Template File: sources-sinks-71b.tmpl.cs
*/
/*
 * @description
 * CWE: 190 Integer Overflow
 * BadSource: console_readLine Read data from the console using readLine
 * GoodSource: A hardcoded non-zero, non-min, non-max, even number
 * Sinks: add
 *    GoodSink: Ensure there will not be an overflow before adding 1 to data
 *    BadSink : Add 1 to data, which can cause an overflow
 * Flow Variant: 71 Data flow: data passed as an Object reference argument from one method to another in different classes in the same package
 *
 * */

using TestCaseSupport;

using System;

using System.Web;

namespace testcases.CWE190_Integer_Overflow
{
class CWE190_Integer_Overflow__Long_console_readLine_add_71b
{
#if (!OMITBAD)
    public static void BadSink(Object dataObject )
    {
        long data = (long)dataObject;
        /* POTENTIAL FLAW: if data == long.MaxValue, this will overflow */
        long result = (long)(data + 1);
        IO.WriteLine("result: " + result);
    }
#endif

#if (!OMITGOOD)
    /* goodG2B() - use goodsource and badsink */
    public static void GoodG2BSink(Object dataObject )
    {
        long data = (long)dataObject;
        /* POTENTIAL FLAW: if data == long.MaxValue, this will overflow */
        long result = (long)(data + 1);
        IO.WriteLine("result: " + result);
    }

    /* goodB2G() - use badsource and goodsink */
    public static void GoodB2GSink(Object dataObject )
    {
        long data = (long)dataObject;
        /* FIX: Add a check to prevent an overflow from occurring */
        if (data < long.MaxValue)
        {
            long result = (long)(data + 1);
            IO.WriteLine("result: " + result);
        }
        else
        {
            IO.WriteLine("data value is too large to perform addition.");
        }
    }
#endif
}
}
