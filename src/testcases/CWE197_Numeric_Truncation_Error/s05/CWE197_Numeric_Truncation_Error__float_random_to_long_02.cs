/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE197_Numeric_Truncation_Error__float_random_to_long_02.cs
Label Definition File: CWE197_Numeric_Truncation_Error__float.label.xml
Template File: sources-sink-02.tmpl.cs
*/
/*
* @description
* CWE: 197 Numeric Truncation Error
* BadSource: random Set data to a random value
* GoodSource: A hardcoded non-zero, non-min, non-max, even number
* BadSink: to_long Convert data to a long
* Flow Variant: 02 Control flow: if(true) and if(false)
*
* */

using TestCaseSupport;
using System;

namespace testcases.CWE197_Numeric_Truncation_Error
{

class CWE197_Numeric_Truncation_Error__float_random_to_long_02 : AbstractTestCase
{
#if (!OMITBAD)
    /* uses badsource and badsink */
    public override void Bad()
    {
        float data;
        if (true)
        {
            /* FLAW: Set data to a random value */
            data = (float)(float.MaxValue * 2.0 * (new Random().NextDouble()-0.5));
        }
        else
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run
             * but ensure data is inititialized before the Sink to avoid compiler errors */
            data = 0.0f;
        }
        {
            /* POTENTIAL FLAW: Convert data to a long, possibly causing a truncation error */
            IO.WriteLine((long)data);
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    /* goodG2B1() - use goodsource and badsink by changing true to false */
    private void GoodG2B1()
    {
        float data;
        if (false)
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run
             * but ensure data is inititialized before the Sink to avoid compiler errors */
            data = 0.0f;
        }
        else
        {
            /* FIX: Use a hardcoded number that won't cause underflow, overflow, divide by zero, or loss-of-precision issues */
            data = 2;
        }
        {
            /* POTENTIAL FLAW: Convert data to a long, possibly causing a truncation error */
            IO.WriteLine((long)data);
        }
    }

    /* GoodG2B2() - use goodsource and badsink by reversing statements in if */
    private void GoodG2B2()
    {
        float data;
        if (true)
        {
            /* FIX: Use a hardcoded number that won't cause underflow, overflow, divide by zero, or loss-of-precision issues */
            data = 2;
        }
        else
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run
             * but ensure data is inititialized before the Sink to avoid compiler errors */
            data = 0.0f;
        }
        {
            /* POTENTIAL FLAW: Convert data to a long, possibly causing a truncation error */
            IO.WriteLine((long)data);
        }
    }

    public override void Good()
    {
        GoodG2B1();
        GoodG2B2();
    }
#endif //omitgood
}
}
