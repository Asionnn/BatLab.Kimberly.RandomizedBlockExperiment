using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

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

        public async Task pulseTactors(int[] tactors, bool doubleSequence, bool isSimultaneous, bool isHeadway, bool isForwardCollision)
        {
            //Block 1 or 3
            if (!doubleSequence)
            {
                if (isHeadway)
                {
                    if (isForwardCollision)
                    {
                        await ForwardCollisionBlock3(tactors);
                        return;
                    }
                    else
                    {
                        await HeadwayReductionBlock3(tactors);
                        return;
                    }
                }

                if (!isSimultaneous)
                {
                    await SequenceBlock1(tactors);
                    return;
                }
                else
                {
                    await SimultaneousBlock1(tactors);
                    return;
                }

            }
            else //Block 2 or 4
            {
                if (isHeadway)
                {
                    if (isForwardCollision)
                    {
                        await ForwardCollisionBlock4(tactors);
                        return;
                    }
                    else
                    {
                        await HeadwayReductionBlock4(tactors);
                        return;
                    }
                }

                if (!isSimultaneous)
                {
                    await SequenceBlock2(tactors);
                    return;
                }
                else
                {
                    await SimultaneousBlock2(tactors);
                    return;
                }
            }
        }

        public static async Task ForwardCollisionBlock3(int [] tactors)
        {
            Pulse(0, tactors[0], 215, 0);
            await Task.Delay(4800);

            Pulse(0, tactors[0], 215, 0);
            await Task.Delay(3440);

            Pulse(0, tactors[0], 215, 0);
            await Task.Delay(1200);
        }
        public static async Task ForwardCollisionBlock4(int [] tactors)
        {
            for (int x = 0; x < 2; x++)
            {
                Pulse(0, tactors[0], 108, 0);
                await Task.Delay(2400);

                Pulse(0, tactors[0], 108, 0);
                await Task.Delay(1720);

                Pulse(0, tactors[0], 108, 0);
                await Task.Delay(1800);
            }
        }
        public static async Task HeadwayReductionBlock3(int [] tactors)
        {
            Pulse(0, tactors[0], 215, 0);
            await Task.Delay(2500);

            Pulse(0, tactors[1], 215, 0);
            await Task.Delay(2500);

            Pulse(0, tactors[2], 215, 0);
            await Task.Delay(2500);

            Pulse(0, tactors[3], 215, 0);
            await Task.Delay(2500);

            Pulse(0, tactors[4], 215, 0);
            await Task.Delay(2500);
        }
        public static async Task HeadwayReductionBlock4(int [] tactors)
        {
            for (int x = 0; x < 2; x++)
            {
                Pulse(0, tactors[0], 108, 0);
                await Task.Delay(1250);

                Pulse(0, tactors[1], 108, 0);
                await Task.Delay(1250);

                Pulse(0, tactors[2], 108, 0);
                await Task.Delay(1250);

                Pulse(0, tactors[3], 108, 0);
                await Task.Delay(1250);

                Pulse(0, tactors[4], 108, 0);
                await Task.Delay(1250);
            }
        }
        public static async Task SequenceBlock1(int [] tactors)
        {
            Pulse(0, tactors[0], 215, 0);

            await Task.Delay(215);
            Pulse(0, tactors[1], 215, 0);

            await Task.Delay(215);
            Pulse(0, tactors[2], 215, 0);
        }
        public static async Task SimultaneousBlock1 (int [] tactors)
        {
            Pulse(0, tactors[0], 215, 0);
            Pulse(0, tactors[1], 215, 0);

            await Task.Delay(215);
            Pulse(0, tactors[0], 215, 0);
            Pulse(0, tactors[1], 215, 0);

            await Task.Delay(215);
            Pulse(0, tactors[0], 215, 0);
            Pulse(0, tactors[1], 215, 0);
        }
        public static async Task SequenceBlock2(int[] tactors)
        {
            for (int x = 0; x < 2; x++)
            {
                Pulse(0, tactors[0], 108, 0);

                await Task.Delay(108);
                Pulse(0, tactors[1], 108, 0);

                await Task.Delay(108);
                Pulse(0, tactors[2], 108, 0);
            }
        }
        public static async Task SimultaneousBlock2(int[] tactors)
        {
            for (int x = 0; x < 2; x++)
            {
                Pulse(0, tactors[0], 108, 0);
                Pulse(0, tactors[1], 108, 0);

                await Task.Delay(108);
                Pulse(0, tactors[0], 108, 0);
                Pulse(0, tactors[1], 108, 0);

                await Task.Delay(108);
                Pulse(0, tactors[0], 108, 0);
                Pulse(0, tactors[1], 108, 0);
            }
        }
    }
}
