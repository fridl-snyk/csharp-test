/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE94_Improper_Control_of_Generation_of_Code__Database_16.cs
Label Definition File: CWE94_Improper_Control_of_Generation_of_Code.label.xml
Template File: sources-sinks-16.tmpl.cs
*/
/*
* @description
* CWE: 94 Improper Control of Generation of Code
* BadSource: Database Read data from a database
* GoodSource: Set data to an integer represented as a string
* Sinks:
*    GoodSink: Validate user input prior to compiling
*    BadSink : Compile sourceCode containing unvalidated user input
* Flow Variant: 16 Control flow: while(true)
*
* */

using TestCaseSupport;
using System;

using System.Reflection;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.Text;
using System.Web;

using System.Data.SqlClient;

namespace testcases.CWE94_Improper_Control_of_Generation_of_Code
{
class CWE94_Improper_Control_of_Generation_of_Code__Database_16 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        string data;
        while (true)
        {
            data = ""; /* Initialize data */
            /* Read data from a database */
            {
                try
                {
                    /* setup the connection */
                    using (SqlConnection connection = IO.GetDBConnection())
                    {
                        connection.Open();
                        /* prepare and execute a (hardcoded) query */
                        using (SqlCommand command = new SqlCommand(null, connection))
                        {
                            command.CommandText = "select name from users where id=0";
                            command.Prepare();
                            using (SqlDataReader dr = command.ExecuteReader())
                            {
                                /* POTENTIAL FLAW: Read data from a database query SqlDataReader */
                                data = dr.GetString(1);
                            }
                        }
                    }
                }
                catch (SqlException exceptSql)
                {
                    IO.Logger.Log(NLog.LogLevel.Warn, exceptSql, "Error with SQL statement");
                }
            }
            break;
        }
        while (true)
        {
            StringBuilder sourceCode = new StringBuilder("");
            sourceCode.Append("public class Calculator \n{\n");
            sourceCode.Append("\tpublic int Sum()\n\t{\n");
            sourceCode.Append("\t\treturn (10 + " + data.ToString() + ");\n");
            sourceCode.Append("\t}\n");
            sourceCode.Append("}\n");
            /* POTENTIAL FLAW: Compile sourceCode containing unvalidated user input */
            CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");
            CompilerParameters cp = new CompilerParameters();
            CompilerResults cr = provider.CompileAssemblyFromSource(cp, sourceCode.ToString());
            Assembly a = cr.CompiledAssembly;
            object calculator = a.CreateInstance("Calculator");
            Type calculatorType = calculator.GetType();
            MethodInfo mi = calculatorType.GetMethod("Sum");
            int s = (int)mi.Invoke(calculator, new object[] {});
            IO.WriteLine("Result: " + s.ToString());
            break;
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    /* goodG2B() - use goodsource and badsink */
    private void GoodG2B()
    {
        string data;
        while (true)
        {
            /* FIX: Set data to an integer represented as a string */
            data = "10";
            break;
        }
        while (true)
        {
            StringBuilder sourceCode = new StringBuilder("");
            sourceCode.Append("public class Calculator \n{\n");
            sourceCode.Append("\tpublic int Sum()\n\t{\n");
            sourceCode.Append("\t\treturn (10 + " + data.ToString() + ");\n");
            sourceCode.Append("\t}\n");
            sourceCode.Append("}\n");
            /* POTENTIAL FLAW: Compile sourceCode containing unvalidated user input */
            CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");
            CompilerParameters cp = new CompilerParameters();
            CompilerResults cr = provider.CompileAssemblyFromSource(cp, sourceCode.ToString());
            Assembly a = cr.CompiledAssembly;
            object calculator = a.CreateInstance("Calculator");
            Type calculatorType = calculator.GetType();
            MethodInfo mi = calculatorType.GetMethod("Sum");
            int s = (int)mi.Invoke(calculator, new object[] {});
            IO.WriteLine("Result: " + s.ToString());
            break;
        }
    }

    /* goodB2G() - use badsource and goodsink */
    private void GoodB2G()
    {
        string data;
        while (true)
        {
            data = ""; /* Initialize data */
            /* Read data from a database */
            {
                try
                {
                    /* setup the connection */
                    using (SqlConnection connection = IO.GetDBConnection())
                    {
                        connection.Open();
                        /* prepare and execute a (hardcoded) query */
                        using (SqlCommand command = new SqlCommand(null, connection))
                        {
                            command.CommandText = "select name from users where id=0";
                            command.Prepare();
                            using (SqlDataReader dr = command.ExecuteReader())
                            {
                                /* POTENTIAL FLAW: Read data from a database query SqlDataReader */
                                data = dr.GetString(1);
                            }
                        }
                    }
                }
                catch (SqlException exceptSql)
                {
                    IO.Logger.Log(NLog.LogLevel.Warn, exceptSql, "Error with SQL statement");
                }
            }
            break;
        }
        while (true)
        {
            int? parsedNum = null;
            /* FIX: Validate user input prior to compiling */
            try
            {
                parsedNum = int.Parse(data);
            }
            catch (FormatException exceptNumberFormat)
            {
                IO.Logger.Log(NLog.LogLevel.Warn, exceptNumberFormat, "Number format exception parsing number.");
            }
            if (parsedNum != null)
            {
                StringBuilder sourceCode = new StringBuilder("");
                sourceCode.Append("public class Calculator \n{\n");
                sourceCode.Append("\tpublic int Sum()\n\t{\n");
                sourceCode.Append("\t\treturn (10 + " + data.ToString() + ");\n");
                sourceCode.Append("\t}\n");
                sourceCode.Append("}\n");
                CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");
                CompilerParameters cp = new CompilerParameters();
                CompilerResults cr = provider.CompileAssemblyFromSource(cp, sourceCode.ToString());
                Assembly a = cr.CompiledAssembly;
                object calculator = a.CreateInstance("Calculator");
                Type calculatorType = calculator.GetType();
                MethodInfo mi = calculatorType.GetMethod("Sum");
                int s = (int)mi.Invoke(calculator, new object[] {});
                IO.WriteLine("Result: " + s.ToString());
            }
            break;
        }
    }

    public override void Good()
    {
        GoodG2B();
        GoodB2G();
    }
#endif //omitgood
}
}
