﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registry_in_C_
{
    internal class Program
    {
        static void Main(string[] args)
        {


            // Specify the Registry key and path
            string keyPath = @"HKEY_LOCAL_MACHINE\SOFTWARE\YourSoftware";
            string valueName = "YourValueName";
            string valueData = "YourValueData";


            try
            {
                // Write the value to the Registry
                Registry.SetValue(keyPath , valueName , valueData , RegistryValueKind.String);


                Console.WriteLine($"Value {valueName} successfully written to the Registry.");
            }
            catch ( Exception ex )
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
