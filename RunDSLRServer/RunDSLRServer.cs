﻿/*
 * Copyright (c) 2011, Aperis GmbH <agplsources@aperis.com>
 * Autor: Achim 'ahzf' Friedland <code@ahzf.de>
 * This file is part of CanonDSLRServer
 *
 * Licensed under the Affero GPL license, Version 3.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.gnu.org/licenses/agpl.html
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

#region Usings

using System;
using System.Threading;

using Mono;
using Mono.CSharp;

using com.aperis.CanonDSLR;
using com.aperis.CanonDSLRServer;
using com.aperis.CanonDSLR.CanonSDK;

#endregion

namespace com.aperis.RunDSLRServer
{

    #region InteractiveBaseShell

    public class InteractiveBaseShell : InteractiveBase
    {

        static Boolean tab_at_start_completes;

        static InteractiveBaseShell()
        {
            tab_at_start_completes = false;
        }

        internal static Mono.Terminal.LineEditor Editor;

        public static bool TabAtStartCompletes
        {

            get
            {
                return tab_at_start_completes;
            }

            set
            {
                tab_at_start_completes = value;
                if (Editor != null)
                    Editor.TabAtStartCompletes = value;
            }

        }

        public static new string help
        {
            get
            {
                return InteractiveBase.help +
                    "  TabAtStartCompletes - Whether tab will complete even on emtpy lines\n";
            }
        }

    }

    #endregion

    public class Program
    {

        private static volatile Boolean _Quit;


        static void Main(String[] myArgs)
        {

            //var edsStateEventHandler = new EDSDK.EdsStateEventHandler(stateEventHandler);
            //err = EDSDK.EdsSetCameraStateEventHandler(_Camera, EDSDK.StateEvent_All, edsStateEventHandler, new IntPtr(0));

            //_Camera._ObjectEventHandler(123, IntPtr.Zero, IntPtr.Zero);



            ////uint _PropertyData2;
            ////var _GetPropAv = EDSDKLib.EDSDK.EdsGetPropertyData(_Camera.DevicePointer, (uint) EDSDK.PropertyID.PropID_Av, 0, out _PropertyData2);
            ////Console.WriteLine("GetPropAv: {0} => {1}", (_GetPropAv == 0) ? "ok" : "failed: " + _GetPropAv, _PropertyData2);

            ////var _GetPropTv = EDSDKLib.EDSDK.EdsGetPropertyData(_Camera .DevicePointer, (uint) EDSDK.PropertyID.PropID_Tv, 0, out _PropertyData2);
            ////Console.WriteLine("GetPropTv: {0} => {1}", (_GetPropTv == 0) ? "ok" : "failed: " + _GetPropTv, _PropertyData2);

            //var _SetProperty = EDSDKLib.EDSDK.EdsSetPropertyData(_Camera.DevicePointer, EDSDKLib.EDSDK.PropID_SaveTo, 0, 4, (uint)EDSDKLib.EDSDK.EdsSaveTo.Camera);
            //Console.WriteLine("SetProperty: {0}", (_SetProperty == 0) ? "ok" : "failed!");

            //var edsObjectEventHandler = new EDSDK.EdsObjectEventHandler(objectEventHandler);
            //var _SetObjectEventHandler = EDSDKLib.EDSDK.EdsSetObjectEventHandler(_Camera.DevicePointer, EDSDK.ObjectEvent_All, edsObjectEventHandler, IntPtr.Zero);
            //Console.WriteLine("SetObjectEventHandler: {0}", (_SetObjectEventHandler == 0) ? "ok" : "failed!");

            var workerThread = new Thread(CanonDSLRWrapper.NotificationHelper);
            workerThread.Start();

            var _CanonDSLRServer = new CanonDSLRServer.CanonDSLRServer();
            var _CanonDSLRWrapper = CanonDSLRWrapper.Instance;
            var _Camera = _CanonDSLRWrapper.GetCamera(0);
            _Camera.OpenSession();

            while (_Camera == null)
            {
                Thread.Sleep(1000);
                Console.WriteLine("Waiting for reference!");
            }

            Console.WriteLine();

            Console.WriteLine("ProductName : " + _Camera.ProductName);
            Console.WriteLine("BodyId : " + _Camera.BodyId);
            Console.WriteLine("OwnerName : " + _Camera.OwnerName);
            //Console.WriteLine("MakerName : "            + _Camera.MakerName);
            Console.WriteLine("CameraTime : " + _Camera.CameraTime);
            Console.WriteLine("FirmwareVersion : " + _Camera.FirmwareVersion);
            Console.WriteLine("BatteryLevel : " + _Camera.BatteryLevel);
            Console.WriteLine("SaveTo : " + _Camera.SaveTo);
            //Console.WriteLine("BatteryQuality : "       + _Camera.BatteryQuality);
            Console.WriteLine("CurrentStorage : " + _Camera.CurrentStorage);
            Console.WriteLine("CurrentFolder : " + _Camera.CurrentFolder);

            Console.WriteLine();

            Console.WriteLine("AEMode : " + _Camera.AEMode);
            Console.WriteLine("AFMode : " + _Camera.AFMode);
            Console.WriteLine("Av : " + _Camera.Av);
            Console.WriteLine("Tv : " + _Camera.Tv);
            Console.WriteLine("ISO : " + _Camera.ISO);
            Console.WriteLine("ExposureCompensation : " + _Camera.ExposureCompensation);
            //Console.WriteLine("ColorTemperature : "     + _Camera.ColorTemperature);
            Console.WriteLine("MeteringMode : " + _Camera.MeteringMode);
            Console.WriteLine("DriveMode : " + _Camera.DriveMode);

            Console.WriteLine("DeviceDescription : " + _Camera.DeviceDescription);

            Console.WriteLine();

            Console.WriteLine("Take a picture?");
            Console.ReadLine();

            //_Camera.TakePicture();
            Console.WriteLine("Taking picture!");
            _Camera.TakePicture(Tv.Tv1_125, Av.Av2_8, ISO.ISO1600);


            Console.WriteLine("Take a picture?");
            Console.ReadLine();
            _Camera.TakePicture(Tv.Tv1_250, Av.Av2_8, ISO.ISO3200);



            //#region CSharp Shell

            //var _Report = new Report(new ConsoleReportPrinter());
            //var _CLP    = new CommandLineParser(_Report);
            ////          cmd.UnknownOptionHandler += HandleExtraArguments;

            //var _Settings = _CLP.ParseArguments(myArgs);
            //if (_Settings == null || _Report.Errors > 0)
            //    throw new Exception("error!");

            //var _Evaluator = new Evaluator(_Settings, _Report)
            //{
            //    InteractiveBaseClass    = typeof(InteractiveBaseShell),
            //    DescribeTypeExpressions = true
            //};

            ////// Adding a assembly twice will lead to delayed errors...
            //_Evaluator.ReferenceAssembly(_Camera.GetType().Assembly);
            ////_Evaluator.ReferenceAssembly(typeof(VertexEdgePipeExtensions).Assembly);
            ////_Evaluator.ReferenceAssembly(typeof(InMemoryGraph).Assembly);
            ////_Evaluator.ReferenceAssembly(typeof(IPipe).Assembly);
            ////_Evaluator.ReferenceAssembly(typeof(TinkerGraphFactory).Assembly);

            //String[] _StartupFiles = { };

            //var a = new CSharpShell(_Evaluator).Run(_StartupFiles);

            //#endregion

            Console.WriteLine("done!");
            Console.ReadLine();

            Console.WriteLine("TerminateSDK: {0}", (EDSDK.TerminateSDK() == 0) ? "ok" : "failed!");

            _Camera.CloseSession();
            //   _CanonDSLRServer.CanonDSLRWrapper.Close();


        }

    }

}
