/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE90_LDAP_Injection__Environment_10.cs
Label Definition File: CWE90_LDAP_Injection.label.xml
Template File: sources-sink-10.tmpl.cs
*/
/*
* @description
* CWE: 90 LDAP Injection
* BadSource: Environment Read data from an environment variable
* GoodSource: A hardcoded string
* BadSink:  data concatenated into LDAP search, which could result in LDAP Injection
* Flow Variant: 10 Control flow: if(IO.staticTrue) and if(IO.staticFalse)
*
* */

using TestCaseSupport;
using System;

using System.DirectoryServices;

using System.Web;

namespace testcases.CWE90_LDAP_Injection
{

class CWE90_LDAP_Injection__Environment_10 : AbstractTestCase
{
#if (!OMITBAD)
    /* uses badsource and badsink */
    public override void Bad()
    {
        string data;
        if (IO.staticTrue)
        {
            /* get environment variable ADD */
            /* POTENTIAL FLAW: Read data from an environment variable */
            data = Environment.GetEnvironmentVariable("ADD");
        }
        else
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run
             * but ensure data is inititialized before the Sink to avoid compiler errors */
            data = null;
        }
        using (DirectoryEntry de = new DirectoryEntry())
        {
            /* POTENTIAL FLAW: data concatenated into LDAP search, which could result in LDAP Injection */
            using (DirectorySearcher search = new DirectorySearcher(de))
            {
                search.Filter = "(&(objectClass=user)(employeename=" + data + "))";
                search.PropertiesToLoad.Add("mail");
                search.PropertiesToLoad.Add("telephonenumber");
                SearchResult sresult = search.FindOne();
            }
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    /* goodG2B1() - use goodsource and badsink by changing IO.staticTrue to IO.staticFalse */
    private void GoodG2B1()
    {
        string data;
        if (IO.staticFalse)
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run
             * but ensure data is inititialized before the Sink to avoid compiler errors */
            data = null;
        }
        else
        {
            /* FIX: Use a hardcoded string */
            data = "foo";
        }
        using (DirectoryEntry de = new DirectoryEntry())
        {
            /* POTENTIAL FLAW: data concatenated into LDAP search, which could result in LDAP Injection */
            using (DirectorySearcher search = new DirectorySearcher(de))
            {
                search.Filter = "(&(objectClass=user)(employeename=" + data + "))";
                search.PropertiesToLoad.Add("mail");
                search.PropertiesToLoad.Add("telephonenumber");
                SearchResult sresult = search.FindOne();
            }
        }
    }

    /* GoodG2B2() - use goodsource and badsink by reversing statements in if */
    private void GoodG2B2()
    {
        string data;
        if (IO.staticTrue)
        {
            /* FIX: Use a hardcoded string */
            data = "foo";
        }
        else
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run
             * but ensure data is inititialized before the Sink to avoid compiler errors */
            data = null;
        }
        using (DirectoryEntry de = new DirectoryEntry())
        {
            /* POTENTIAL FLAW: data concatenated into LDAP search, which could result in LDAP Injection */
            using (DirectorySearcher search = new DirectorySearcher(de))
            {
                search.Filter = "(&(objectClass=user)(employeename=" + data + "))";
                search.PropertiesToLoad.Add("mail");
                search.PropertiesToLoad.Add("telephonenumber");
                SearchResult sresult = search.FindOne();
            }
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
