using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace BatLab.Kimberly.RandomizedBlockExperiment
{
    class Tactors
    {
        #region Tactor Methods
        private const string DDL_PATH = @"C:\Users\batla\Desktop\TDK\TDKAPI_1.0.6.0.x64\TDKAPI_1.0.6.0\libraries\Windows\TactorInterface.dll";

        [DllImport(DDL_PATH,
            CallingConvention = CallingConvention.Cdecl)]
        public static extern int Discover(int type);

        [DllImport(DDL_PATH,
            CallingConvention = CallingConvention.Cdecl)]
        public static extern int Connect(string name, int type, IntPtr _callback);

        [DllImport(DDL_PATH,
            CallingConvention = CallingConvention.Cdecl)]
        public static extern int InitializeTI();

        [DllImport(DDL_PATH,
            CallingConvention = CallingConvention.Cdecl)]
        public static extern int Pulse(int deviceID, int tacNum, int msDuration, int delay);

        [DllImport(DDL_PATH,
            CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetDiscoveredDeviceName(int index);

        [DllImport(DDL_PATH,
           CallingConvention = CallingConvention.Cdecl)]
        public static extern int ChangeGain(int deviceID, int tacNum, int gainval, int delay);

        [DllImport(DDL_PATH,
            CallingConvention = CallingConvention.Cdecl)]
        public static extern int CloseAll();
        #endregion


        public void setupTactors()
        {
            if (InitializeTI() == 0)
            {
                System.Diagnostics.Debug.WriteLine("TDK Initialized");
            }

            System.Diagnostics.Debug.WriteLine("Tactors: " + Discover(1));
            string name = Marshal.PtrToStringAnsi(GetDiscoveredDeviceName(0));
            System.Diagnostics.Debug.WriteLine("Name: " + name);


            if (Connect(name, 1, IntPtr.Zero) >= 0)
            {
                System.Diagnostics.Debug.WriteLine("Connected");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Not connected");
            }
        }

        public void pulseTactors()
        {
            //TODO: add parameter that accepts an enum of the tactor pattern
        }

    }


}
