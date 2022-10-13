/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE134_Externally_Controlled_Format_String__Environment_console_interpolation_54e.cs
Label Definition File: CWE134_Externally_Controlled_Format_String.label.xml
Template File: sources-sinks-54e.tmpl.cs
*/
/*
 * @description
 * CWE: 134 Externally Controlled Format String
 * BadSource: Environment Read data from an environment variable
 * GoodSource: A hardcoded string
 * Sinks: console_interpolation
 *    GoodSink: console write with interpolation
 *    BadSink : console write formatted without validation
 * Flow Variant: 54 Data flow: data passed as an argument from one method through three others to a fifth; all five functions are in different classes in the same package
 *
 * */

using TestCaseSupport;
using System;

namespace testcases.CWE134_Externally_Controlled_Format_String
{
class CWE134_Externally_Controlled_Format_String__Environment_console_interpolation_54e
{
#if (!OMITBAD)
    public static void BadSink(string data )
    {
        if (data != null)
        {
            /* POTENTIAL FLAW: uncontrolled string formatting */
            Console.Write(string.Format(data));
        }
    }
#endif

#if (!OMITGOOD)
    /* goodG2B() - use goodsource and badsink */
    public static void GoodG2BSink(string data )
    {
        if (data != null)
        {
            /* POTENTIAL FLAW: uncontrolled string formatting */
            Console.Write(string.Format(data));
        }
    }

    /* goodB2G() - use badsource and goodsink */
    public static void GoodB2GSink(string data )
    {
        if (data != null)
        {
            /* FIX: explicitly defined string formatting by using interpolation */
            Console.Write("{0}{1}", data, Environment.NewLine);
        }
    }
#endif
}
}
