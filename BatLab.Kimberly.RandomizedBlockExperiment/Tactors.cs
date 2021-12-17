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
        public static extern int ChangeFreq(int deviceId, int tacNum, int freqVal, int delay);

        [DllImport(DDL_PATH,
            CallingConvention = CallingConvention.Cdecl)]
       public static extern int SendActionWait(int deviceID, int msDuration, int delay);


        [DllImport(DDL_PATH,
            CallingConvention = CallingConvention.Cdecl)]
        public static extern int CloseAll();
        #endregion

        public Tactors()
        {
            setupTactors();
        }

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
                for(int x = 1; x <= 20; x++)
                {
                    _ = ChangeFreq(0, x, 250, 0);
                    _ = ChangeGain(0, x, 128, 0);
                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Not connected");
            }
        }

        public void pulseTactors(int[] tactors, bool doubleSequence, bool isSimultaneous, bool isHeadway, bool isForwardCollision)
        {
            //TODO: add parameter that accepts tactor patterns

            //Block 1 or 3
            if (!doubleSequence)
            {
                if (isHeadway)
                {
                    if (isForwardCollision)
                    {
                        //maybe use a stopwatch here
                        //Start stopwatch and start pulsing, then wait until stop watch hits 5015 ms and play the next and so on
                        return;
                    }
                    else
                    {
                        for(int x = 0; x < tactors.Length; x++)
                        {
                            Pulse(0, tactors[x], 215, 2500 * x + 215);
                        }
                    }
                }

                if (!isSimultaneous)
                {
                    for (int x = 0; x < tactors.Length; x++)
                    {
                        Pulse(0, tactors[x], 215, 215 * x);
                    }
                    return;
                }
                else
                {
                    for (int x = 0; x < tactors.Length; x++)
                    {
                        Pulse(0, tactors[x], 215, 0);
                    }
                    return;
                }
                
            }
            else //Block 2 or 4
            {   
                List<int> tactorsList = new List<int>();
                tactorsList.AddRange(tactors);
                tactorsList.AddRange(tactors);
                if (isHeadway)
                {
                    if (isForwardCollision)
                    {
                        //maybe use stopwatch here
                        return;
                    }
                    else
                    {
                        for (int x = 0; x < tactorsList.Count; x++)
                        {
                            Pulse(0, tactorsList[x], 108, 1250 * x + 108);
                        }
                        return;

                    }
                }

                if (!isSimultaneous)
                {
                    for (int x = 0; x < tactorsList.Count; x++)
                    {
                        Pulse(0, tactorsList[x], 108, 108 * x);
                    }
                    return;
                }
                else
                {
                    for(int x = 0; x < tactors.Length; x++)
                    {
                        Pulse(0, tactors[x], 108, 0);
                    }
                    for (int x = 0; x < tactors.Length; x++)
                    {
                        Pulse(0, tactors[x], 108, 108);
                    }
                    return;
                }
                
            }


        }

    }


}
