/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE191_Integer_Underflow__Byte_rand_sub_01.cs
Label Definition File: CWE191_Integer_Underflow.label.xml
Template File: sources-sinks-01.tmpl.cs
*/
/*
* @description
* CWE: 191 Integer Underflow
* BadSource: rand Set data to result of rand()
* GoodSource: A hardcoded non-zero, non-min, non-max, even number
* Sinks: sub
*    GoodSink: Ensure there will not be an underflow before subtracting 1 from data
*    BadSink : Subtract 1 from data, which can cause an Underflow
* Flow Variant: 01 Baseline
*
* */

using TestCaseSupport;
using System;

using System.Web;

namespace testcases.CWE191_Integer_Underflow
{
class CWE191_Integer_Underflow__Byte_rand_sub_01 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        byte data;
        /* POTENTIAL FLAW: Use a random value */
        data = (byte)(new Random().Next(byte.MinValue, byte.MaxValue));
        /* POTENTIAL FLAW: if data == byte.MinValue, this will overflow */
        byte result = (byte)(data - 1);
        IO.WriteLine("result: " + result);
    }
#endif //omitbad
#if (!OMITGOOD)
    public override void Good()
    {
        GoodG2B();
        GoodB2G();
    }

    /* goodG2B() - use goodsource and badsink */
    private void GoodG2B()
    {
        byte data;
        /* FIX: Use a hardcoded number that won't cause underflow, overflow, divide by zero, or loss-of-precision issues */
        data = 2;
        /* POTENTIAL FLAW: if data == byte.MinValue, this will overflow */
        byte result = (byte)(data - 1);
        IO.WriteLine("result: " + result);
    }

    /* goodB2G() - use badsource and goodsink */
    private void GoodB2G()
    {
        byte data;
        /* POTENTIAL FLAW: Use a random value */
        data = (byte)(new Random().Next(byte.MinValue, byte.MaxValue));
        /* FIX: Add a check to prevent an overflow from occurring */
        if (data > byte.MinValue)
        {
            byte result = (byte)(data - 1);
            IO.WriteLine("result: " + result);
        }
        else
        {
            IO.WriteLine("data value is too small to perform subtraction.");
        }
    }
#endif //omitgood
}
}
