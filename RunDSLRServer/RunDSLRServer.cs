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

        public static Boolean TabAtStartCompletes
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

            //var workerThread = new Thread(CanonDSLRWrapper.NotificationHelper);
            //workerThread.Start();

            var _CanonDSLRServer = new CanonDSLRServer.CanonDSLRServer();

            //Console.WriteLine("Press any key to terminate!");
            //Console.ReadLine();

            //Console.WriteLine("CanonSDK terminated: {0}", (EDSDK.TerminateSDK() == 0) ? "ok" : "failed!");

            //Environment.Exit(0);

            // ------------------------------------------------------------------------

            #region Get properties

            var _CanonDSLRWrapper = CanonDSLRWrapper.Instance;
            var _Camera           = _CanonDSLRWrapper.GetCamera(0);
            _Camera.OpenSession();
            //_Camera.SaveToHost();

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
            //Console.WriteLine("CameraTime : " + _Camera.CameraTime);
            //Console.WriteLine("FirmwareVersion : " + _Camera.FirmwareVersion);
            //Console.WriteLine("BatteryLevel : " + _Camera.BatteryLevel);
            //Console.WriteLine("SaveTo : " + _Camera.SaveTo);
            ////Console.WriteLine("BatteryQuality : "       + _Camera.BatteryQuality);
            //Console.WriteLine("CurrentStorage : " + _Camera.CurrentStorage);
            //Console.WriteLine("CurrentFolder : " + _Camera.CurrentFolder);

            //Console.WriteLine();

            //Console.WriteLine("AEMode : " + _Camera.AEMode);
            //Console.WriteLine("AFMode : " + _Camera.AFMode);
            //Console.WriteLine("Av : " + _Camera.Av);
            //Console.WriteLine("Tv : " + _Camera.Tv);
            //Console.WriteLine("ISO : " + _Camera.ISO);
            //Console.WriteLine("ExposureCompensation : " + _Camera.ExposureCompensation);
            ////Console.WriteLine("ColorTemperature : "     + _Camera.ColorTemperature);
            //Console.WriteLine("MeteringMode : " + _Camera.MeteringMode);
            //Console.WriteLine("DriveMode : " + _Camera.DriveMode);

            //Console.WriteLine("DeviceDescription : " + _Camera.DeviceDescription);

            //Console.WriteLine();

            #endregion

            #region Taking a picture

            //Console.ReadLine();
            while (true)
            {
                Console.WriteLine("Taking a picture...");
                _Camera.TakePicture();
                //Tv.Tv1_250, Av.Av2_8, ISO.ISO3200);
                Thread.Sleep(10000);
            }

            #endregion

            #region CSharp Shell

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

            #endregion

            //_Camera.CloseSession();
            //_CanonDSLRServer.CanonDSLRWrapper.Close();

        }

    }

}
