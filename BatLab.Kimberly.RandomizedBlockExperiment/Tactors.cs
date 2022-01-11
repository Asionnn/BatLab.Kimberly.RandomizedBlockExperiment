using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace BatLab.Kimberly.RandomizedBlockExperiment
{
    public class Tactors
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

        private Stopwatch stopWatch = new Stopwatch();
        public Tactors()
        {
            setupTactors();
        }

        public void setupTactors()
        {
            if (InitializeTI() == 0)
            {
                Debug.WriteLine("TDK Initialized");
            }

            Debug.WriteLine("Tactors: " + Discover(1));
            string name = Marshal.PtrToStringAnsi(GetDiscoveredDeviceName(0));
            Debug.WriteLine("Name: " + name);


            if (Connect(name, 1, IntPtr.Zero) >= 0)
            {
                Debug.WriteLine("Connected");
                for(int x = 1; x <= 20; x++)
                {
                    _ = ChangeFreq(0, x, 250, 0);
                    _ = ChangeGain(0, x, 128, 0);
                }
            }
            else
            {
                Debug.WriteLine("Not connected");
            }
        }

        public void pulseTactors(int[] tactors, bool doubleSequence, bool isSimultaneous, bool isHeadway, bool isForwardCollision)
        {
            //Block 1 or 3
            if (!doubleSequence)
            {
                if (isHeadway)
                {
                    if (isForwardCollision)
                    {                        
                        var trialDone = false;
                        var timesPulsed = 0;
                        stopWatch.Start();
                        Pulse(0, tactors[0], 215, 0);
                        timesPulsed++;
                        while (!trialDone)
                        {
                            TimeSpan timeSpan = stopWatch.Elapsed;

                            if (timesPulsed == 3)
                            {
                                trialDone = true;
                            }

                            switch (timeSpan.TotalMilliseconds)
                            {
                                case 5015:
                                    Pulse(0, tactors[1], 215, 0);
                                    timesPulsed++;
                                    break;
                                case 8670:
                                    Pulse(0, tactors[2], 215, 0);
                                    timesPulsed++;
                                    break;
                            }
                        }
                        stopWatch.Stop();
                        stopWatch.Reset();
                        return;
                    }
                    else
                    {
                        var trialDone = false;
                        var timesPulsed = 0;
                        stopWatch.Start();
                        Pulse(0, tactors[0], 215, 0);
                        timesPulsed++;
                        while (!trialDone)
                        {
                            TimeSpan timeSpan = stopWatch.Elapsed;

                            if (timesPulsed == 5)
                            {
                                trialDone = true;
                            }

                            switch (timeSpan.TotalMilliseconds)
                            {
                                case 2500:
                                    Pulse(0, tactors[1], 215, 0);
                                    timesPulsed++;
                                    break;
                                case 5000:
                                    Pulse(0, tactors[2], 215, 0);
                                    timesPulsed++;
                                    break;
                                case 7500:
                                    Pulse(0, tactors[3], 215, 0);
                                    timesPulsed++;
                                    break;
                                case 10000:
                                    Pulse(0, tactors[4], 215, 0);
                                    timesPulsed++;
                                    break;
                            }
                        }
                        stopWatch.Stop();
                        stopWatch.Reset();
                        return;
                    }
                }

                if (!isSimultaneous)
                {
                    var timesPulsed = 0;
                    var trialDone = false;
                    stopWatch.Reset();
                    stopWatch.Start();

                    Pulse(0, tactors[0], 215, 0);
                    timesPulsed++;

                    while (!trialDone)
                    {
                       
                        TimeSpan timeSpan = stopWatch.Elapsed;

                        switch (timeSpan.TotalMilliseconds)
                        {
                            case 215:
                                Pulse(0, tactors[1], 215, 0);
                                timesPulsed++;
                                break;
                            case 430:
                                Pulse(0, tactors[2], 215, 0);
                                timesPulsed++;
                                break;
                        }
                        if (timesPulsed == tactors.Length)
                        {
                            trialDone = true;
                        }
                    }

                    stopWatch.Stop();
                    stopWatch.Reset();
                    return;
           
                }
                else
                {
                    var timesPulsed = 0;
                    var trialDone = false;
                    stopWatch.Reset();
                    stopWatch.Start();

                    Pulse(0, tactors[0], 215, 0);
                    Pulse(0, tactors[1], 215, 0);
                    timesPulsed++;

                    while (!trialDone)
                    {

                        TimeSpan timeSpan = stopWatch.Elapsed;

                        switch (timeSpan.TotalMilliseconds)
                        {
                            case 215:
                                Pulse(0, tactors[0], 215, 0);
                                Pulse(0, tactors[1], 215, 0);
                                timesPulsed++;
                                break;
                            case 430:
                                Pulse(0, tactors[0], 215, 0);
                                Pulse(0, tactors[1], 215, 0);
                                timesPulsed++;
                                break;
                        }
                        if (timesPulsed == tactors.Length)
                        {
                            trialDone = true;
                        }
                    }

                    stopWatch.Stop();
                    stopWatch.Reset();
                    return;
                }
                
            }
            else //Block 2 or 4
            {
                if (isHeadway)
                {
                    if (isForwardCollision)
                    {
                        bool trialDone = false;
                        int timesPulsed = 0;
                        stopWatch.Start();
                        Pulse(0, 3, 108, 0);
                        timesPulsed++;
                        while (!trialDone)
                        {
                            TimeSpan timeSpan = stopWatch.Elapsed;

                            if(timesPulsed == 6)
                            {
                                trialDone = true;
                            }
                            switch (timeSpan.TotalMilliseconds)
                            {
                                case 2400:
                                    Pulse(0, 3, 108, 0);
                                    timesPulsed++;
                                    break;
                                case 4120:
                                    Pulse(0, 3, 108, 0);
                                    timesPulsed++;
                                    break;
                                case 4720:
                                    stopWatch.Reset();
                                    Pulse(0, 3, 108, 0);
                                    timesPulsed++;
                                    break;
                            }
                        }
                        stopWatch.Stop();
                        stopWatch.Reset();
                        return;
                    }
                    else
                    {
                        var trialDone = false;
                        var timesPulsed = 0;
                        stopWatch.Start();
                        Pulse(0, tactors[0], 108, 0);
                        timesPulsed++;
                        while (!trialDone)
                        {
                            TimeSpan timeSpan = stopWatch.Elapsed;

                            if (timesPulsed == 10)
                            {
                                trialDone = true;
                            }

                            switch (timeSpan.TotalMilliseconds)
                            {
                                case 1250:
                                    Pulse(0, tactors[1], 108, 0);
                                    timesPulsed++;
                                    break;
                                case 2500:
                                    Pulse(0, tactors[2], 108, 0);
                                    timesPulsed++;
                                    break;
                                case 3750:
                                    Pulse(0, tactors[3], 108, 0);
                                    timesPulsed++;
                                    break;
                                case 5000:
                                    Pulse(0, tactors[4], 108, 0);
                                    timesPulsed++;
                                    break;
                                case 6250:
                                    stopWatch.Reset();
                                    Pulse(0, tactors[0], 108, 0);
                                    timesPulsed++;
                                    break;
                            }
                        }
                        stopWatch.Stop();
                        stopWatch.Reset();
                        return;
                    }
                }

                if (!isSimultaneous)
                {
                    var timesPulsed = 0;
                    var trialDone = false;
                    stopWatch.Reset();
                    stopWatch.Start();

                    Pulse(0, tactors[0], 108, 0);
                    timesPulsed++;

                    while (!trialDone)
                    {

                        TimeSpan timeSpan = stopWatch.Elapsed;

                        switch (timeSpan.TotalMilliseconds)
                        {
                            case 108:
                                Pulse(0, tactors[1], 108, 0);
                                timesPulsed++;
                                break;
                            case 216:
                                Pulse(0, tactors[2], 108, 0);
                                timesPulsed++;
                                break;
                            case 324:
                                Pulse(0, tactors[0], 108, 9);
                                timesPulsed++;
                                stopWatch.Reset();
                                break;
                        }
                        if (timesPulsed == tactors.Length * 2)
                        {
                            trialDone = true;
                        }
                    }

                    stopWatch.Stop();
                    stopWatch.Reset();
                    return;

                }
                else
                {
                    var timesPulsed = 0;
                    var trialDone = false;
                    stopWatch.Reset();
                    stopWatch.Start();

                    Pulse(0, tactors[0], 108, 0);
                    Pulse(0, tactors[1], 108, 0);
                    timesPulsed++;

                    while (!trialDone)
                    {

                        TimeSpan timeSpan = stopWatch.Elapsed;

                        switch (timeSpan.TotalMilliseconds)
                        {
                            case 108:
                                Pulse(0, tactors[0], 108, 0);
                                Pulse(0, tactors[1], 108, 0);
                                timesPulsed++;
                                break;
                            case 216:
                                Pulse(0, tactors[0], 108, 0);
                                Pulse(0, tactors[1], 108, 0);
                                timesPulsed++;
                                break;
                            case 324:
                                Pulse(0, tactors[0], 108, 0);
                                Pulse(0, tactors[1], 108, 0);
                                timesPulsed++;
                                stopWatch.Reset();
                                break;
                        }
                        if (timesPulsed == tactors.Length * 2)
                        {
                            trialDone = true;
                        }
                    }

                    stopWatch.Stop();
                    stopWatch.Reset();
                    return;
                }
                
            }

        }
    }

}
