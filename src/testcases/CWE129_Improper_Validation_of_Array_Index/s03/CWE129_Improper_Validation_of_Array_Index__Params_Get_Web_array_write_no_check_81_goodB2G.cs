/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE129_Improper_Validation_of_Array_Index__Params_Get_Web_array_write_no_check_81_goodB2G.cs
Label Definition File: CWE129_Improper_Validation_of_Array_Index.label.xml
Template File: sources-sinks-81_goodB2G.tmpl.cs
*/
/*
 * @description
 * CWE: 129 Improper Validation of Array Index
 * BadSource: Params_Get_Web Read data from a querystring using Params.Get()
 * GoodSource: A hardcoded non-zero, non-min, non-max, even number
 * Sinks: array_write_no_check
 *    GoodSink: Write to array after verifying index
 *    BadSink : Write to array without any verification of index
 * Flow Variant: 81 Data flow: data passed in a parameter to an abstract method
 *
 * */
#if (!OMITGOOD)

using TestCaseSupport;
using System;

using System.Web;

namespace testcases.CWE129_Improper_Validation_of_Array_Index
{
class CWE129_Improper_Validation_of_Array_Index__Params_Get_Web_array_write_no_check_81_goodB2G : CWE129_Improper_Validation_of_Array_Index__Params_Get_Web_array_write_no_check_81_base
{

    public override void Action(int data , HttpRequest req, HttpResponse resp)
    {
        /* Need to ensure that the array is of size > 3  and < 101 due to the GoodSource and the large_fixed BadSource */
        int[] array = { 0, 1, 2, 3, 4 };
        /* FIX: Verify index before writing to array at location data */
        if (data >= 0 && data < array.Length)
        {
            array[data] = 42;
        }
        else
        {
            IO.WriteLine("Array index out of bounds");
        }
    }
}
}
#endif
