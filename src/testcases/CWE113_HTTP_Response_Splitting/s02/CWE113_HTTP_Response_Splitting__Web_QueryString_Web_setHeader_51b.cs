/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE113_HTTP_Response_Splitting__Web_QueryString_Web_setHeader_51b.cs
Label Definition File: CWE113_HTTP_Response_Splitting__Web.label.xml
Template File: sources-sinks-51b.tmpl.cs
*/
/*
 * @description
 * CWE: 113 HTTP Response Splitting
 * BadSource: QueryString_Web Parse id param out of the URL query string (without using getParameter())
 * GoodSource: A hardcoded string
 * Sinks: setHeader
 *    GoodSink: URLEncode input
 *    BadSink : querystring to AddHeader()
 * Flow Variant: 51 Data flow: data passed as an argument from one function to another in different classes in the same package
 *
 * */

using TestCaseSupport;
using System;

using System.Web;
using System.Text;

namespace testcases.CWE113_HTTP_Response_Splitting
{
class CWE113_HTTP_Response_Splitting__Web_QueryString_Web_setHeader_51b
{
#if (!OMITBAD)
    public static void BadSink(string data , HttpRequest req, HttpResponse resp)
    {
        if (data != null)
        {
            /* POTENTIAL FLAW: Input not verified before inclusion in header */
            resp.AddHeader("Location", "/author.jsp?lang=" + data);
        }
    }
#endif

#if (!OMITGOOD)
    /* goodG2B() - use goodsource and badsink */
    public static void GoodG2BSink(string data , HttpRequest req, HttpResponse resp)
    {
        if (data != null)
        {
            /* POTENTIAL FLAW: Input not verified before inclusion in header */
            resp.AddHeader("Location", "/author.jsp?lang=" + data);
        }
    }

    /* goodB2G() - use badsource and goodsink */
    public static void GoodB2GSink(string data , HttpRequest req, HttpResponse resp)
    {
        if (data != null)
        {
            /* FIX: use URLEncoder.encode to hex-encode non-alphanumerics */
            data = HttpUtility.UrlEncode(data, Encoding.UTF8);
            resp.AddHeader("Location", "/author.jsp?lang=" + data);
        }
    }
#endif
}
}
