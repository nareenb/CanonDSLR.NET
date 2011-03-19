﻿/*
 * Copyright (c) 2011, Aperis GmbH <agplsources@aperis.com>
 * Autor: Achim 'ahzf' Friedland <code@ahzf.de>
 * This file is part of CanonDSLR
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
using System.Runtime.InteropServices;

using com.aperis.CanonDSLR.CanonSDK;

#endregion

namespace com.aperis.CanonDSLR
{

    /// <summary>
    /// A wrapper around the CanonSDK.
    /// </summary>
    public class CanonDSLRWrapper : IDisposable
    {

        #region Data

        private        readonly IntPtr  _CameraList;
        private                 Int32   _CameraCount;
        private static volatile Boolean _Quit;

        #endregion

        #region NotificationHelper and user32.dll mappings

        // user32.dll mappings

        #region MSG

        [StructLayout(LayoutKind.Sequential)]
        public struct MSG
        {
            public IntPtr hwnd;
            public UInt32 message;
            public IntPtr wParam;
            public IntPtr lParam;
            public UInt32 time;
            public POINT  pt;
        }

        #endregion

        #region POINT

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {

            public Int32 X;
            public Int32 Y;

            public POINT(Int32 x, Int32 y)
            {
                this.X = x;
                this.Y = y;
            }

        }

        #endregion

        #region PeekMessage(out lpMsg, hWnd, wMsgFilterMin, wMsgFilterMax, wRemoveMsg)

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        //public static extern bool PeekMessage(out MSG lpMsg, HandleRef hWnd, uint wMsgFilterMin, uint wMsgFilterMax, uint wRemoveMsg);
        public static extern Boolean PeekMessage(out MSG lpMsg, IntPtr hWnd, UInt32 wMsgFilterMin, UInt32 wMsgFilterMax, UInt32 wRemoveMsg);

        #endregion

        #region GetMessage(out lpMsg, hWnd, wMsgFilterMin, wMsgFilterMax)

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern Boolean GetMessage(out MSG lpMsg, IntPtr hWnd, UInt32 wMsgFilterMin, UInt32 wMsgFilterMax);

        #endregion

        #region DispatchMessage(ref lpmsg)

        [DllImport("user32.dll")]
        public static extern IntPtr DispatchMessage([In] ref MSG lpmsg);

        #endregion


        #region NotificationHelper()

        /// <summary>
        /// This method should be started in its own thread for delivering
        /// notifications from the CanonSDK to the application logic.
        /// </summary>
        [STAThread]
        public static void NotificationHelper()
        {

            MSG _MSG;

            while (!_Quit)
            {

                try
                {

                    // Use PeekMessage(...) to avoid blocking!
                    if (CanonDSLRWrapper.PeekMessage(out _MSG, IntPtr.Zero, 0, 0, 0))
                    {
                        CanonDSLRWrapper.GetMessage(out _MSG, new IntPtr(0), 0, 0);
                        CanonDSLRWrapper.DispatchMessage(ref _MSG);
                    }

                    Thread.Sleep(5);

                }

                catch (Exception)
                { }

            }

        }

        #endregion

        #endregion

        #region Singelton

        private static readonly CanonDSLRWrapper _CanonDSLRWrapper = new CanonDSLRWrapper();

        /// <summary>
        /// Get singelton instance of a CanonDSLRWrapper.
        /// </summary>
        public static CanonDSLRWrapper Instance
        {
            get
            {
                return _CanonDSLRWrapper;
            }
        }

        #endregion

        #region Constructor(s)

        #region CanonDSLRWrapper()

        private CanonDSLRWrapper()
        {

            _Quit = false;

            CanonSDKError _CanonSDKError;

            _CanonSDKError = (CanonSDKError) EDSDK.InitializeSDK();
            if (_CanonSDKError != CanonSDKError.EDS_ERR_OK)
                throw new InitSDKException(_CanonSDKError);

            _CanonSDKError = (CanonSDKError) EDSDK.EdsGetCameraList(out _CameraList);
            if (_CanonSDKError != CanonSDKError.EDS_ERR_OK)
                throw new GetCameraListException(_CanonSDKError);

            _CanonSDKError = (CanonSDKError) EDSDK.EdsGetChildCount(_CameraList, out _CameraCount);
            if (_CanonSDKError != CanonSDKError.EDS_ERR_OK)
                throw new GetCameraListException(_CanonSDKError);

        }

        #endregion

        #endregion


        #region GetCamera(myCameraId)

        /// <summary>
        /// Return the camera of the given id from the cameralist..
        /// </summary>
        /// <param name="myCameraId">The id of the camera within the cameralist.</param>
        /// <returns>A camera object.</returns>
        public Camera GetCamera(UInt32 myCameraId)
        {

            if (myCameraId > _CameraCount)
                throw new GetCameraException(CanonSDKError.EDS_ERR_DEVICE_NOT_FOUND)
                              { Message = "Invalid CameraId!" };

            IntPtr _CameraPtr;
            
            var _CanonSDKError = (CanonSDKError) EDSDK.EdsGetChildAtIndex(_CameraList, 0, out _CameraPtr);

            if (_CanonSDKError != CanonSDKError.EDS_ERR_OK)
                throw new GetCameraException(_CanonSDKError);

            return new Camera(_CameraPtr);

        }

        #endregion


        #region IDisposable Members

        /// <summary>
        /// Terminates the CanonSDK.
        /// </summary>
        public void Dispose()
        {

            _Quit = true;

            CanonSDKError _CanonSDKError;

            _CanonSDKError = EDSDK.Release(_CameraList);
            if (_CanonSDKError != CanonSDKError.EDS_ERR_OK)
                throw new ReleaseCameraListException(_CanonSDKError);

            _CanonSDKError = EDSDK.TerminateSDK();
            if (_CanonSDKError != CanonSDKError.EDS_ERR_OK)
                throw new TerminateSDKException(_CanonSDKError);

        }

        #endregion

    }

}
