/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE398_Code_Quality__empty_case_14.cs
Label Definition File: CWE398_Code_Quality.label.xml
Template File: point-flaw-14.tmpl.cs
*/
/*
* @description
* CWE: 398 One of the 7 Pernicious Kingdoms - Code Quality
* Sinks: empty_case
*    GoodSink: Case statement contains code
*    BadSink : An empty case statement has no effect
* Flow Variant: 14 Control flow: if(IO.staticFive==5) and if(IO.staticFive!=5)
*
* */

using TestCaseSupport;
using System;

namespace testcases.CWE398_Code_Quality
{
class CWE398_Code_Quality__empty_case_14 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        if (IO.staticFive == 5)
        {
            int x = (new Random()).Next();
            switch (x)
            {
                /* FLAW: An empty case statement has no effect */
            case 0:
                break;
            default:
                IO.WriteLine("Inside the default statement");
                break;
            }
            IO.WriteLine("Hello from Bad()");
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    /* Good1() changes IO.staticFive==5 to IO.staticFive!=5 */
    private void Good1()
    {
        if (IO.staticFive != 5)
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run */
            IO.WriteLine("Benign, fixed string");
        }
        else
        {
            int x = (new Random()).Next();
            switch (x)
            {
                /* FIX: Do not include an empty case statement */
            case 0:
                IO.WriteLine("Inside the case statement");
                break;
            default:
                IO.WriteLine("Inside the default statement");
                break;
            }
            IO.WriteLine("Hello from Good()");
        }
    }

    /* Good2() reverses the bodies in the if statement */
    private void Good2()
    {
        if (IO.staticFive == 5)
        {
            int x = (new Random()).Next();
            switch (x)
            {
                /* FIX: Do not include an empty case statement */
            case 0:
                IO.WriteLine("Inside the case statement");
                break;
            default:
                IO.WriteLine("Inside the default statement");
                break;
            }
            IO.WriteLine("Hello from Good()");
        }
    }

    public override void Good()
    {
        Good1();
        Good2();
    }
#endif //omitgood
}
}
