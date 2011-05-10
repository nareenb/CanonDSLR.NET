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
using System.IO;
using System.Threading;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using com.aperis.CanonDSLR.CanonSDK;
using EOSControl.Helpers;

#endregion

namespace com.aperis.CanonDSLR
{

    /// <summary>
    /// http://subversion.assembla.com/svn/CanonEOSApp/Models/Camera.cs
    /// </summary>
    public class Camera : IDisposable
    {

        #region Properties

        #region Camera Settings Properties

        #region ProductName

        /// <summary>
        /// The product name of this camera.
        /// </summary>
        public String ProductName
        {

            get
            {
                
                String _ProductName;

                var _CanonSDKError = (CanonSDKError) EDSDK.EdsGetPropertyData(_CameraDevice, PropertyID.ProductName, 0, out _ProductName);

                if (_CanonSDKError != CanonSDKError.EDS_ERR_OK)
                    throw new GetProductNameException(_CanonSDKError);

                return _ProductName;

            }

        }

        #endregion

        #region BodyId

        /// <summary>
        /// The serial number of this camera.
        /// </summary>
        public UInt32 BodyId
        {

            get
            {

                UInt32 _BodyId;

                var _CanonSDKError = (CanonSDKError) EDSDK.EdsGetPropertyData(_CameraDevice, PropertyID.BodyId, 0, out _BodyId);

                if (_CanonSDKError != CanonSDKError.EDS_ERR_OK)
                    throw new GetBodyIdException(_CanonSDKError);

                return _BodyId;

            }

        }

        #endregion

        #region OwnerName

        /// <summary>
        /// The name of the camera owner.
        /// </summary>
        public String OwnerName
        {

            get
            {
                
                String _OwnerName;
                
                var _CanonSDKError = (CanonSDKError) EDSDK.EdsGetPropertyData(_CameraDevice, PropertyID.OwnerName, 0, out _OwnerName);
                
                if (_CanonSDKError != CanonSDKError.EDS_ERR_OK)
                    throw new GetOwnerNameException(_CanonSDKError);
                
                return _OwnerName;

            }

        }

        #endregion

        #region MakerName

        /// <summary>
        /// The name of the camera creator.
        /// </summary>
        public String MakerName
        {

            get
            {

                String _MakerName;

                var _CanonSDKError = (CanonSDKError) EDSDK.EdsGetPropertyData(_CameraDevice, PropertyID.MakerName, 0, out _MakerName);

                if (_CanonSDKError != CanonSDKError.EDS_ERR_OK)
                    throw new GetMakerNameException(_CanonSDKError);

                return _MakerName;

            }

        }

        #endregion

        #region CameraTime

        /// <summary>
        /// The current date and time of the camera.
        /// </summary>
        public DateTime CameraTime
        {

            get
            {

                Time _CameraTime;

                var _CanonSDKError = (CanonSDKError) EDSDK.EdsGetPropertyData(_CameraDevice, PropertyID.CameraTime, 0, out _CameraTime);

                if (_CanonSDKError != CanonSDKError.EDS_ERR_OK)
                    throw new GetCameraTimeException(_CanonSDKError);

                return new DateTime(_CameraTime.Year,
                                    _CameraTime.Month,
                                    _CameraTime.Day,
                                    _CameraTime.Hour,
                                    _CameraTime.Minute,
                                    _CameraTime.Second,
                                    _CameraTime.Milliseconds);

            }

        }

        #endregion

        #region FirmwareVersion

        /// <summary>
        /// The version of the camera firmware.
        /// </summary>
        public String FirmwareVersion
        {

            get
            {

                String _FirmwareVersion;

                var _CanonSDKError = (CanonSDKError) EDSDK.EdsGetPropertyData(_CameraDevice, PropertyID.CameraTime, 0, out _FirmwareVersion);

                if (_CanonSDKError != CanonSDKError.EDS_ERR_OK)
                    throw new GetFirmwareVersionException(_CanonSDKError);

                return _FirmwareVersion;

            }

        }

        #endregion

        #region BatteryLevel

        /// <summary>
        /// The charging level of the attached battery.
        /// </summary>
        public BatteryLevel BatteryLevel
        {

            get
            {

                BatteryLevel _BatteryLevel;

                var _CanonSDKError = (CanonSDKError) EDSDK.EdsGetPropertyData(_CameraDevice, PropertyID.BatteryLevel, 0, out _BatteryLevel);

                if (_CanonSDKError != CanonSDKError.EDS_ERR_OK)
                    throw new GetBatteryLevelException(_CanonSDKError);

                return _BatteryLevel;

            }

        }

        #endregion

        #region CFn(myCustomParameter)

        /// <summary>
        /// Gets a custom parameter
        /// </summary>
        public Object CFn<T>(Int32 myCustomParameter)
        {

            T _CFn;

            var _CanonSDKError = (CanonSDKError) EDSDK.EdsGetPropertyData<T>(_CameraDevice, PropertyID.CFn, myCustomParameter, out _CFn);

            if (_CanonSDKError != CanonSDKError.EDS_ERR_OK)
                throw new GetCFnException(myCustomParameter, _CanonSDKError);

            return _CFn;

        }

        #endregion

        #region SaveTo

        /// <summary>
        /// The device to store the taken pictures saved at.
        /// </summary>
        public SaveTo SaveTo
        {

            get
            {

                SaveTo _SaveTo;

                var _CanonSDKError = (CanonSDKError) EDSDK.EdsGetPropertyData(_CameraDevice, PropertyID.SaveTo, 0, out _SaveTo);

                if (_CanonSDKError != CanonSDKError.EDS_ERR_OK)
                    throw new GetSaveToException(_CanonSDKError);

                return _SaveTo;

            }

            set
            {

                var _CanonSDKError = SetProperty(PropertyID.SaveTo, 0, 4, (UInt32) value);

                if (_CanonSDKError != CanonSDKError.EDS_ERR_OK)
                    throw new SetSaveToException(_CanonSDKError);

            }

        }

        #endregion

        #region CurrentStorage

        /// <summary>
        /// The current storage media for the camera.
        /// </summary>
        public String CurrentStorage
        {

            get
            {

                String _CurrentStorage;

                var _CanonSDKError = (CanonSDKError) EDSDK.EdsGetPropertyData(_CameraDevice, PropertyID.CurrentStorage, 0, out _CurrentStorage);

                if (_CanonSDKError != CanonSDKError.EDS_ERR_OK)
                    throw new GetCurrentStorageException(_CanonSDKError);

                return _CurrentStorage;

            }

        }

        #endregion

        #region CurrentFolder

        /// <summary>
        /// The current folder for the camera.
        /// </summary>
        public String CurrentFolder
        {

            get
            {

                String _CurrentFolder;

                var _CanonSDKError = (CanonSDKError) EDSDK.EdsGetPropertyData(_CameraDevice, PropertyID.CurrentFolder, 0, out _CurrentFolder);

                if (_CanonSDKError != CanonSDKError.EDS_ERR_OK)
                    throw new GetCurrentFolderException(_CanonSDKError);

                return _CurrentFolder;

            }

        }

        #endregion

        //
        //MyMenu

        #region BatteryQuality

        /// <summary>
        /// The quality of the attached battery.
        /// </summary>
        /// <remarks>Does not work for my 7D!</remarks>
        public UInt32 BatteryQuality
        {

            get
            {

                UInt32 _BatteryQuality;

                var _CanonSDKError = (CanonSDKError) EDSDK.EdsGetPropertyData(_CameraDevice, PropertyID.BatteryQuality, 0, out _BatteryQuality);

                if (_CanonSDKError != CanonSDKError.EDS_ERR_OK)
                    throw new GetSaveToException(_CanonSDKError);

                return _BatteryQuality;

            }

        }

        #endregion

		//HDDirectoryStructure

        #region LensStatus

        /// <summary>
        /// The camera state of whether a lens is attached or not.
        /// </summary>
        public LensStatus LensStatus
        {

            get
            {

                LensStatus _LensStatus;

                var _CanonSDKError = (CanonSDKError) EDSDK.EdsGetPropertyData(_CameraDevice, PropertyID.LensStatus, 0, out _LensStatus);

                if (_CanonSDKError != CanonSDKError.EDS_ERR_OK)
                    throw new GetLensStatusException(_CanonSDKError);

                return _LensStatus;

            }

            set
            {

                var _CanonSDKError = SetProperty(PropertyID.SaveTo, 0, value);

                if (_CanonSDKError != CanonSDKError.EDS_ERR_OK)
                    throw new SetLensStatusException(_CanonSDKError);

            }

        }

        #endregion

        #endregion

        #region Image Properties
        #endregion

        #region Capture Properties

        #region AEMode

        /// <summary>
        /// The capture program.
        /// </summary>
        public AEMode AEMode
        {

            get
            {

                AEMode _AEMode;

                var _CanonSDKError = (CanonSDKError) EDSDK.EdsGetPropertyData(_CameraDevice, PropertyID.AEMode, 0, out _AEMode);

                if (_CanonSDKError != CanonSDKError.EDS_ERR_OK)
                    throw new GetAEModeException(_CanonSDKError);

                return _AEMode;

            }

            set
            {

                var _CanonSDKError = SetProperty(PropertyID.AEMode, 0, value);

                if (_CanonSDKError != CanonSDKError.EDS_ERR_OK)
                    throw new SetAEModeException(_CanonSDKError);

            }

        }

        #endregion

        #region AFMode

        /// <summary>
        /// The auto-focus settings.
        /// </summary>
        public AFMode AFMode
        {

            get
            {

                AFMode _AFMode;

                var _CanonSDKError = (CanonSDKError) EDSDK.EdsGetPropertyData(_CameraDevice, PropertyID.AFMode, 0, out _AFMode);

                if (_CanonSDKError != CanonSDKError.EDS_ERR_OK)
                    throw new GetAFModeException(_CanonSDKError);

                return _AFMode;

            }

            set
            {

                var _CanonSDKError = SetProperty(PropertyID.AFMode, 0, value);

                if (_CanonSDKError != CanonSDKError.EDS_ERR_OK)
                    throw new SetAFModeException(_CanonSDKError);

            }

        }

        #endregion

        #region ExposureCompensation

        /// <summary>
        /// The exposure compensation.
        /// </summary>
        public ExposureCompensation ExposureCompensation
        {

            get
            {

                ExposureCompensation _ExposureCompensation;

                var _CanonSDKError = (CanonSDKError) EDSDK.EdsGetPropertyData(_CameraDevice, PropertyID.ExposureCompensation, 0, out _ExposureCompensation);

                if (_CanonSDKError != CanonSDKError.EDS_ERR_OK)
                    throw new GetExposureCompensationException(_CanonSDKError);

                return _ExposureCompensation;

            }

            set
            {

                var _CanonSDKError = SetProperty(PropertyID.ExposureCompensation, 0, value);

                if (_CanonSDKError != CanonSDKError.EDS_ERR_OK)
                    throw new SetExposureCompensationException(_CanonSDKError);

            }

        }

        #endregion

        #region WhiteBalance

        /// <summary>
        /// The white balance.
        /// </summary>
        public WhiteBalance WhiteBalance
        {

            get
            {

                WhiteBalance _WhiteBalance;

                var _CanonSDKError = (CanonSDKError) EDSDK.EdsGetPropertyData(_CameraDevice, PropertyID.WhiteBalance, 0, out _WhiteBalance);

                if (_CanonSDKError != CanonSDKError.EDS_ERR_OK)
                    throw new GetWhiteBalanceException(_CanonSDKError);

                return _WhiteBalance;

            }

            set
            {

                var _CanonSDKError = SetProperty(PropertyID.WhiteBalance, 0, value);

                if (_CanonSDKError != CanonSDKError.EDS_ERR_OK)
                    throw new SetWhiteBalanceException(_CanonSDKError);

            }

        }

        #endregion

        #region ColorTemperature

        /// <summary>
        /// Indicates the color temperature setting value. (Units: Kelvin)
        /// Valid only when the white balance is set to 'Color Temperature'.
        /// </summary>
        public UInt32 ColorTemperature
        {

            get
            {

                UInt32 _ColorTemperature;

                var _CanonSDKError = (CanonSDKError) EDSDK.EdsGetPropertyData(_CameraDevice, PropertyID.ColorTemperature, 0, out _ColorTemperature);

                if (_CanonSDKError != CanonSDKError.EDS_ERR_OK)
                    throw new GetColorTemperatureException(_CanonSDKError);

                return _ColorTemperature;

            }

            set
            {

                var _CanonSDKError = SetProperty(PropertyID.ColorTemperature, 0, value);

                if (_CanonSDKError != CanonSDKError.EDS_ERR_OK)
                    throw new SetColorTemperatureException(_CanonSDKError);

            }

        }

        #endregion

        #region MeteringMode

        /// <summary>
        /// A list of all available metering modes.
        /// </summary>
        public IEnumerable<String> MeteringModeList
        {
            get
            {
                return EnumHelper.FillList(GetPropertyDescription(PropertyID.MeteringMode), typeof(ISO));
            }
        }

        /// <summary>
        /// A map of all available metering modes.
        /// </summary>
        public IEnumerable<KeyValuePair<String, String>> MeteringModeMap
        {
            get
            {
                return EnumHelper.FillMap(GetPropertyDescription(PropertyID.MeteringMode), typeof(ISO));
            }
        }

        /// <summary>
        /// The metering mode.
        /// </summary>
        public MeteringMode MeteringMode
        {

            get
            {

                MeteringMode _MeteringMode;

                var _CanonSDKError = (CanonSDKError) EDSDK.EdsGetPropertyData(_CameraDevice, PropertyID.MeteringMode, 0, out _MeteringMode);

                if (_CanonSDKError != CanonSDKError.EDS_ERR_OK)
                    throw new GetMeteringModeException(_CanonSDKError);

                return _MeteringMode;

            }

            set
            {

                var _CanonSDKError = SetProperty(PropertyID.MeteringMode, 0, value);

                if (_CanonSDKError != CanonSDKError.EDS_ERR_OK)
                    throw new SetMeteringModeException(_CanonSDKError);

            }

        }

        #endregion

        #region Tv

        /// <summary>
        /// A list of all available shutter speeds.
        /// </summary>
        public IEnumerable<String> TvList
        {
            get
            {
                return EnumHelper.FillList(GetPropertyDescription(PropertyID.Tv), typeof(Tv));
            }
        }

        /// <summary>
        /// A map of all available shutter speeds.
        /// </summary>
        public IEnumerable<KeyValuePair<String, String>> TvMap
        {
            get
            {
                return EnumHelper.FillMap(GetPropertyDescription(PropertyID.Tv), typeof(Tv));
            }
        }

        /// <summary>
        /// The shutter speed.
        /// </summary>
        public Tv Tv
        {

            get
            {

                Tv _Tv;

                var _CanonSDKError = (CanonSDKError) EDSDK.EdsGetPropertyData(_CameraDevice, PropertyID.Tv, 0, out _Tv);

                if (_CanonSDKError != CanonSDKError.EDS_ERR_OK)
                    throw new GetTvException(_CanonSDKError);

                return _Tv;

            }

            set
            {

                var _CanonSDKError = SetProperty(PropertyID.Tv, 0, value);

                if (_CanonSDKError != CanonSDKError.EDS_ERR_OK)
                    throw new SetTvException(_CanonSDKError);

            }

        }

        #endregion

        #region Av

        /// <summary>
        /// A list of all available aperture values.
        /// </summary>
        public IEnumerable<String> AvList
        {
            get
            {
                return EnumHelper.FillList(GetPropertyDescription(PropertyID.Av), typeof(Av));
            }
        }

        /// <summary>
        /// A map of all available aperture values.
        /// </summary>
        public IEnumerable<KeyValuePair<String, String>> AvMap
        {
            get
            {
                return EnumHelper.FillMap(GetPropertyDescription(PropertyID.Av), typeof(Av));
            }
        }

        /// <summary>
        /// The camera's aperture value.
        /// </summary>
        public Av Av
        {

            get
            {

                Av _Av;

                var _CanonSDKError = (CanonSDKError) EDSDK.EdsGetPropertyData(_CameraDevice, PropertyID.Av, 0, out _Av);

                if (_CanonSDKError != CanonSDKError.EDS_ERR_OK)
                    throw new GetAvException(_CanonSDKError);

                return _Av;

            }

            set
            {

                var _CanonSDKError = SetProperty(PropertyID.Av, 0, value);

                if (_CanonSDKError != CanonSDKError.EDS_ERR_OK)
                    throw new SetAvException(_CanonSDKError);

            }

        }

        #endregion

        #region ISO

        /// <summary>
        /// A list of all available ISO sensitivities.
        /// </summary>
        public IEnumerable<String> ISOList
        {
            get
            {
                return EnumHelper.FillList(GetPropertyDescription(PropertyID.ISO), typeof(ISO));
            }
        }

        /// <summary>
        /// A map of all available ISO sensitivities.
        /// </summary>
        public IEnumerable<KeyValuePair<String, String>> ISOMap
        {
            get
            {
                return EnumHelper.FillMap(GetPropertyDescription(PropertyID.ISO), typeof(ISO));
            }
        }

        /// <summary>
        /// ISO sensitivity.
        /// </summary>
        public ISO ISO
        {

            get
            {

                ISO _ISO;

                var _CanonSDKError = (CanonSDKError) EDSDK.EdsGetPropertyData(_CameraDevice, PropertyID.ISO, 0, out _ISO);

                if (_CanonSDKError != CanonSDKError.EDS_ERR_OK)
                    throw new GetISOException(_CanonSDKError);

                return _ISO;

            }

            set
            {

                var _CanonSDKError = SetProperty(PropertyID.ISO, 0, value);

                if (_CanonSDKError != CanonSDKError.EDS_ERR_OK)
                    throw new SetISOException(_CanonSDKError);

            }

        }

        #endregion

        #region DriveMode

        /// <summary>
        /// The drive mode.
        /// </summary>
        public DriveMode DriveMode
        {

            get
            {

                DriveMode _DriveMode;

                var _CanonSDKError = (CanonSDKError) EDSDK.EdsGetPropertyData(_CameraDevice, PropertyID.DriveMode, 0, out _DriveMode);

                if (_CanonSDKError != CanonSDKError.EDS_ERR_OK)
                    throw new GetDriveModeException(_CanonSDKError);

                return _DriveMode;

            }

            set
            {

                var _CanonSDKError = SetProperty(PropertyID.DriveMode, 0, value);

                if (_CanonSDKError != CanonSDKError.EDS_ERR_OK)
                    throw new SetDriveModeException(_CanonSDKError);

            }

        }

        #endregion
        

        #endregion

        

        
        #region ImageQuality

        public IEnumerable<String> ImageQualityList
        {
            get
            {
                return EnumHelper.FillList(GetPropertyDescription(PropertyID.MeteringMode), typeof(ImageQuality));
            }
        }

        public IEnumerable<KeyValuePair<String, String>> ImageQualityMap
        {
            get
            {
                return EnumHelper.FillMap(GetPropertyDescription(PropertyID.MeteringMode), typeof(ImageQuality));
            }
        }

        public ImageQuality ImageQuality
        {
            get
            {
                return GetPropertyData<ImageQuality>(PropertyID.ImageQuality);
            }
        }

        #endregion


        #region DeviceDescription

        public String DeviceDescription
        {
            get
            {
                DeviceInfo _EdsDeviceInfo;
                EDSDK.EdsGetDeviceInfo(_CameraDevice, out _EdsDeviceInfo);
                return _EdsDeviceInfo.DeviceDescription;
            }
        }

        #endregion

        #region DevicePort

        public String DevicePort
        {
            get
            {
                DeviceInfo deviceInfo;
                EDSDK.EdsGetDeviceInfo(_CameraDevice, out deviceInfo);
                return deviceInfo.PortName;
            }
        }

        #endregion

        #region DevicePointer

        private readonly IntPtr _CameraDevice;

        public IntPtr DevicePointer
        {
            get
            {
                return _CameraDevice;
            }
        }

        #endregion

        #region SessionOpened

        public Boolean SessionOpened { get; private set; }

        #endregion

        #endregion

        #region Construtor(s)

        #region Camera(myCameraDevice)

        internal Camera(IntPtr myCameraDevice)
        {

            _CameraDevice = myCameraDevice;

            // Register ObjectEventHandler
            _ObjectEventHandler = new EDSDK.EdsObjectEventHandler(objectEventHandler);
            var m_ptrObjectEventHandler = Marshal.GetFunctionPointerForDelegate(_ObjectEventHandler);
            var _CanonSDKError = (CanonSDKError) EDSDK.EdsSetObjectEventHandler(_CameraDevice, ObjectEvent.All, _ObjectEventHandler, new IntPtr(0));
            if (_CanonSDKError != CanonSDKError.EDS_ERR_OK)
                Console.WriteLine("Error registering object event handler!");

            SessionOpened = false;

        }

        #endregion

        #endregion


        #region Camera Sessions

        #region OpenSession()

        public CanonSDKError OpenSession()
        {

            CanonSDKError _CanonSDKError;


            // Register StateEventHandler
            _StateEventHandler = new EDSDK.EdsStateEventHandler(stateEventHandler);
            _CanonSDKError = (CanonSDKError) EDSDK.EdsSetCameraStateEventHandler(_CameraDevice, StateEvent.All, _StateEventHandler, new IntPtr(0));
            if (_CanonSDKError != CanonSDKError.EDS_ERR_OK)
            {
                Console.WriteLine("Error registering state event handler!");
                return _CanonSDKError;
            }


            // Open Camera Session
            _CanonSDKError = (CanonSDKError) EDSDK.EdsOpenSession(_CameraDevice);
            if (_CanonSDKError != CanonSDKError.EDS_ERR_OK)
            {
                Console.WriteLine("Error opening the camera session!");
                return _CanonSDKError;
            }


            // Register PropertyEventHandler
            _PropertyEventHandler = new EDSDK.EdsPropertyEventHandler(HandlePropertyEvent);
            _CanonSDKError = (CanonSDKError) EDSDK.EdsSetPropertyEventHandler(_CameraDevice, PropertyEvent.All, _PropertyEventHandler, new IntPtr(0));
            if (_CanonSDKError != CanonSDKError.EDS_ERR_OK)
            {
                Console.WriteLine("Error registering property event handler!");
                return _CanonSDKError;
            }

            //_ProgressCallbackHandler = new EDSDK.EdsProgressCallback(progressCallbackHandler);
            //_CanonSDKError = (CanonSDKError) EDSDK.EdsSetProgressCallback(_CameraDevice, _ProgressCallbackHandler, ProgressOption.Periodically, IntPtr.Zero);
            //if (_CanonSDKError != CanonSDKError.EDS_ERR_OK)
            //    Console.WriteLine("Error registering progress callback handler!");

            SessionOpened = true;

            return _CanonSDKError;

        }

        #endregion

        #region CloseSession()

        public void CloseSession()
        {

            CanonSDKError _Error;

            _Error = (CanonSDKError) EDSDK.EdsCloseSession(_CameraDevice);
            if (_Error != CanonSDKError.EDS_ERR_OK)
                Console.WriteLine("Error closing the camera session!");

            //foreach (var volume in Volumes)
            //    volume.Dispose();

            _Error = (CanonSDKError) EDSDK.Release(_CameraDevice);
            if (_Error != CanonSDKError.EDS_ERR_OK)
                Console.WriteLine("Error releasing the camera pointer!");

            SessionOpened = false;

        }

        #endregion


        #region SaveToHost()

        public CanonSDKError SaveToHost()
        {

       //     var saveTo = SaveTo.Host;
       //     _CanonSDKError = (CanonSDKError) EDSDK.EdsSetPropertyData(_CameraDevice, PropertyID.SaveTo, 0, 4, (uint)saveTo);
            this.SaveTo = SaveTo.Host;
//            Console.WriteLine("SetProperty[SaveTo] : " + _CanonSDKError);

            var capacity = new Capacity();
            capacity.NumberOfFreeClusters = 0x7FFFFFFF;
            capacity.BytesPerSector = 0x1000;
            capacity.Reset = 1;

            return (CanonSDKError) EDSDK.EdsSetCapacity(_CameraDevice, capacity);

                //int volumeCount;
                //CameraAPI.EdsGetChildCount(_cameraRef, out volumeCount);

                //for (int i = 0; i < volumeCount; i++)
                //{
                //    IntPtr volumeRef;
                //    CameraAPI.EdsGetChildAtIndex(_cameraRef, i, out volumeRef);
                //    _volumes.Add(new Volume(volumeRef));
                //}

        }

        #endregion

        #endregion

        #region (private) getCapturedItem

        private static String getCapturedItem(IntPtr myDirectoryItem)
        {

            var err = CanonSDKError.EDS_ERR_OK;
            IntPtr stream = IntPtr.Zero;

            DirectoryItemInfo _DirectoryItemInfo;
            err = (CanonSDKError) EDSDK.EdsGetDirectoryItemInfo(myDirectoryItem, out _DirectoryItemInfo);
            if (err != CanonSDKError.EDS_ERR_OK)
                throw new Exception("Unable to get captured item info!");

            Console.WriteLine(" File: " + _DirectoryItemInfo.FileName.ToString() + ", Size: " + _DirectoryItemInfo.Size.ToString());


            // Fill the stream with the resulting image
            if (err == CanonSDKError.EDS_ERR_OK)
                err = (CanonSDKError) EDSDK.EdsCreateMemoryStream((uint)_DirectoryItemInfo.Size, out stream);

            // Create a file stream for receiving image.
            if (err == CanonSDKError.EDS_ERR_OK)
                err = (CanonSDKError) EDSDK.EdsCreateMemoryStream(_DirectoryItemInfo.Size, out stream);

            // Fill the stream with the resulting image
            if (err == CanonSDKError.EDS_ERR_OK)
                err = (CanonSDKError) EDSDK.EdsDownload(myDirectoryItem, _DirectoryItemInfo.Size, stream);

            //EDSDKLib.EDSDK.EdsGetPointer(stream, out pointerToBytes);


            if (err == CanonSDKError.EDS_ERR_OK)
            {

                byte[] buffer = new byte[(int)_DirectoryItemInfo.Size];

                GCHandle gcHandle = GCHandle.Alloc(buffer, GCHandleType.Pinned);

                IntPtr address = gcHandle.AddrOfPinnedObject();

                IntPtr streamPtr = IntPtr.Zero;

                err = (CanonSDKError) EDSDK.EdsGetPointer(stream, out streamPtr);

                if (err != CanonSDKError.EDS_ERR_OK)
                {
                    //throw new CameraDownloadException("Unable to get resultant image.", err);
                }

                try
                {

                    Marshal.Copy(streamPtr, buffer, 0, (int)_DirectoryItemInfo.Size);

                    try
                    {
                        var _FileStream = new FileStream("c:\\Users\\ahzf\\Desktop\\Wolken\\" + _DirectoryItemInfo.FileName.ToString(), FileMode.Create, FileAccess.ReadWrite);
                        var _BinaryWriter = new BinaryWriter(_FileStream);
                        _BinaryWriter.Write(buffer);
                        _BinaryWriter.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }
                catch (AccessViolationException ave)
                {

                    //throw new CameraDownloadException("Error copying unmanaged stream to managed byte[].", ave);
                    Console.WriteLine("Error!");
                }
                finally
                {
                    gcHandle.Free();
                    EDSDK.Release(stream);
                    EDSDK.Release(streamPtr);
                }
            }
            else
            {
                //throw new CameraDownloadException("Unable to get resultant image.", err);
                Console.WriteLine("Errro ");
            }

            return null;

        }

        #endregion

        #region Event Handling

        #region Delegates

        private EDSDK.EdsStateEventHandler _StateEventHandler;
        private readonly EDSDK.EdsObjectEventHandler _ObjectEventHandler;
        private EDSDK.EdsPropertyEventHandler _PropertyEventHandler;
        //        private readonly EDSDK.EdsProgressCallback      _ProgressCallbackHandler;

        #endregion

        #region (private) stateEventHandler

        private uint stateEventHandler(uint inEvent, uint inParameter, IntPtr inContext)
        {

            var _inEvent = (StateEvent) inEvent;

            Console.WriteLine("StateEventHandler called!");

            switch (_inEvent)
            {

                case StateEvent.JobStatusChanged:
                    Console.WriteLine(String.Format("There are objects waiting to be transferred. Job status {0}", inParameter));
                    break;

                case StateEvent.ShutDownTimerUpdate:
                    if (inParameter != 0)
                        Console.WriteLine(String.Format("shutdown timer update: {0}", inParameter));
                    break;

                case StateEvent.WillSoonShutDown:
                    Console.WriteLine("Camera irá desligar em alguns segundos...");
                    break;

                case StateEvent.Shutdown:
                    Console.WriteLine("Desligando a camera....");
                    //if (cameraOpened)
                    //{
                    //    err = EDSDK.EdsCloseSession(cameraDev);
                    //    if (err != EDSDK.EDS_ERR_OK)
                    //    throw new Exception(String.Format("EdsCloseSession: " + err.ToString()));
                    //    Debug.WriteLine("Successfully closed sesssion");
                    //    cameraOpened = false;
                    //    //lblStatusMessage.Text = "camera closed";
                    //}
                    //if (isSDKLoaded)
                    //{
                    //    EDSDK.EdsTerminateSDK();
                    //    isSDKLoaded = false;
                    //}
                    break;

                default:
                    Console.WriteLine(String.Format("StateEventHandler: event {0}, parameter {1}", inEvent, inParameter));
                    break;

            }

            return 0;

        }

        #endregion

        #region (private) objectEventHandler

        private uint objectEventHandler(uint inEvent, IntPtr inRef, IntPtr inContext)
        {

            var _inEvent = (ObjectEvent) inEvent;

            Console.WriteLine("ObjectEventHandler called!");

            switch (_inEvent)
            {

                case ObjectEvent.VolumeInfoChanged:
                    Console.WriteLine("VolumeInfo changed");
                    VolumeInfo volumeInfo;
                    var err = (CanonSDKError) EDSDK.EdsGetVolumeInfo(inRef, out volumeInfo);
                    if (err == CanonSDKError.EDS_ERR_OK)
                    {
                        Console.WriteLine("StorageType : " + volumeInfo.StorageType.ToString());
                        Console.WriteLine("MaxCapacity : " + volumeInfo.MaxCapacity.ToString());
                    }
                    break;

                case ObjectEvent.DirItemCreated:
                    Console.WriteLine("DirItemCreated");
                    String x = getCapturedItem(inRef);
                    break;

                case ObjectEvent.DirItemRemoved:
                    Console.WriteLine("DirItemRemoved");
                    break;

                case ObjectEvent.DirItemRequestTransfer:
                    Console.WriteLine("DirItemRequestTransfer");
                    String y = getCapturedItem(inRef);
                    break;

                default:
                    Console.WriteLine(String.Format("ObjectEventHandler: event {0}", (ObjectEvent) inEvent));
                    break;

            }

            return 0;

        }

        #endregion

        #region (private) HandlePropertyEvent

        private UInt32 HandlePropertyEvent(UInt32 myEvent, UInt32 myPropertyID, UInt32 myParam, IntPtr myContext)
        {

            var _PropertyID = (PropertyID) myPropertyID;

            Console.WriteLine("Property '{0}' changed: {1}, {2}", _PropertyID, myEvent, myParam);

            return 0;

        }

        #endregion

        #region (private) progressCallbackHandler

        private uint progressCallbackHandler(uint inPercent, IntPtr inContext, ref bool outCancel)
        {
            Console.WriteLine("ProgressEventHandler called!");
            //invokeProgressEvent(new ProgressEventArgs((int)inPercent));
            Console.WriteLine(String.Format("progress: {0}%", inPercent));
            return 0;
        }

        #endregion

        #endregion
        
        
        #region Get-/Set Camera Properties

        #region GetPropertyData<T>(myPropertyID)

        public T GetPropertyData<T>(PropertyID myPropertyID)
        {

            T _PropertyData;
            var _CanonSDKError = (CanonSDKError) EDSDK.EdsGetPropertyData<T>(_CameraDevice, myPropertyID, 0, out _PropertyData);

            if (_CanonSDKError != CanonSDKError.EDS_ERR_OK)
            {
                Console.WriteLine("Error getting property data!");
                return default(T);
            }

            return _PropertyData;

        }

        #endregion

        #region GetPropertyDescription(myPropertyID)

        public PropertyDescription GetPropertyDescription(PropertyID myPropertyID)
        {

            var _PropertyDesc  = new PropertyDescription();
            var _CanonSDKError = EDSDK.EdsGetPropertyDesc(_CameraDevice, myPropertyID, out _PropertyDesc);

            if (_CanonSDKError != CanonSDKError.EDS_ERR_OK)
            {
                Console.WriteLine("Error getting property data!");
                return new PropertyDescription();
            }

            return _PropertyDesc;

        }

        #endregion

        #region SetProperty(myPropertyID, myParameter, myPropertyData)

        public CanonSDKError SetProperty(PropertyID myPropertyID, Int32 myParameter, Object myPropertyData)
        {

            Int32  _Size;
            Object _PropertyData;
            var    _Type = myPropertyData.GetType();

            // Change an enum to its underlying type as PInvokes do not like enums!
            if (_Type.IsEnum)
            {
                _Size         = Marshal.SizeOf(Enum.GetUnderlyingType(_Type));
                _PropertyData = Convert.ChangeType(myPropertyData, Enum.GetUnderlyingType(_Type));
            }

            else
            {
                _Size         = Marshal.SizeOf(_Type);
                _PropertyData = myPropertyData;
            }

            return EDSDK.EdsSetPropertyData(_CameraDevice, myPropertyID, myParameter, _Size, _PropertyData);

        }

        #endregion

        #region SetProperty(myPropertyID, myParameter, myPropertySize, myPropertyData)

        public CanonSDKError SetProperty(PropertyID myPropertyID, Int32 myParameter, Int32 myPropertySize, Object myPropertyData)
        {
            return EDSDK.EdsSetPropertyData(_CameraDevice, myPropertyID, myParameter, myPropertySize, myPropertyData);
        }

        #endregion

        #endregion

        #region Camera Actions

        #region TakePicture()

        public CanonSDKError TakePicture()
        {

            //var err1 = EDSDK.EdsSendStatusCommand(_CameraDevice, (uint) CameraState.UILock, 0);

            var _Error = (CanonSDKError) EDSDK.EdsSendCommand(_CameraDevice, CameraCommand.TakePicture, 0);
            if (_Error != CanonSDKError.EDS_ERR_OK)
                Console.WriteLine("Error taking photo! " + _Error);

            //var err2 = EDSDK.EdsSendStatusCommand(_CameraDevice, (uint) CameraState.UIUnLock, 0);

            return _Error;

        }

        #endregion

        #region TakePicture(myTv, myAv)

        public CanonSDKError TakePicture(Tv myTv, Av myAv, ISO myISO)
        {

            var err1 = EDSDK.EdsSendStatusCommand(_CameraDevice, (uint)CameraState.UILock, 0);

            this.Tv  = myTv;
            this.Av  = myAv;
            this.ISO = myISO;

            var _Error = (CanonSDKError) EDSDK.EdsSendCommand(_CameraDevice, CameraCommand.TakePicture, 0);
            if (_Error != CanonSDKError.EDS_ERR_OK)
                Console.WriteLine("Error taking photo! " + _Error);

            var err2 = EDSDK.EdsSendStatusCommand(_CameraDevice, (uint)CameraState.UIUnLock, 0);

            return _Error;

        }

        #endregion


        #region PressShutterButton

        /// <summary>
        /// Press the shutter button.
        /// </summary>
        /// <param name="myShutterButton">The state of the shutton button.</param>
        /// <returns>Any of the sdk errors.</returns>
        public CanonSDKError PressShutterButton(ShutterButton myShutterButton)
        {
            return (CanonSDKError) EDSDK.EdsSendStatusCommand(_CameraDevice, Convert.ToUInt32(myShutterButton), 0);
        }

        #endregion

        #region ExtendShutdownTimer()

        /// <summary>
        /// Extend the time remaining until the camera shuts down.
        /// </summary>
        /// <returns>Any of the sdk errors.</returns>
        public CanonSDKError ExtendShutdownTimer()
        {
            return (CanonSDKError) EDSDK.EdsSendCommand(_CameraDevice, CameraCommand.ExtendShutDownTimer, 0);
        }

        #endregion

        #region BulbStart()

        /// <summary>
        /// Open the camera shutter.
        /// </summary>
        /// <returns>Any of the sdk errors.</returns>
        public CanonSDKError BulbStart()
        {

            CanonSDKError _CanonSDKError;

            _CanonSDKError = (CanonSDKError) EDSDK.EdsSendStatusCommand(_CameraDevice, Convert.ToUInt32(CameraState.UILock), 0);
            if (_CanonSDKError != CanonSDKError.EDS_ERR_OK)
                return _CanonSDKError;

            _CanonSDKError = (CanonSDKError) EDSDK.EdsSendCommand(_CameraDevice, CameraCommand.BulbStart, 0);
            if (_CanonSDKError != CanonSDKError.EDS_ERR_OK)
                return _CanonSDKError;

            return (CanonSDKError) EDSDK.EdsSendStatusCommand(_CameraDevice, Convert.ToUInt32(CameraState.UILock), 0);

        }

        #endregion

        #region BulbEnd()

        /// <summary>
        /// Close the camera shutter.
        /// </summary>
        /// <returns>Any of the sdk errors.</returns>
        public CanonSDKError BulbEnd()
        {

            CanonSDKError _CanonSDKError;

            _CanonSDKError = (CanonSDKError) EDSDK.EdsSendStatusCommand(_CameraDevice, Convert.ToUInt32(CameraState.UILock), 0);
            if (_CanonSDKError != CanonSDKError.EDS_ERR_OK)
                return _CanonSDKError;

            _CanonSDKError = (CanonSDKError) EDSDK.EdsSendCommand(_CameraDevice, CameraCommand.BulbEnd, 0);
            if (_CanonSDKError != CanonSDKError.EDS_ERR_OK)
                return _CanonSDKError;

            return (CanonSDKError) EDSDK.EdsSendStatusCommand(_CameraDevice, Convert.ToUInt32(CameraState.UILock), 0);

        }

        #endregion

        #region Blub(myDuration)

        /// <summary>
        /// Take a complete bulb shot for the duration specified.
        /// </summary>
        /// <param name="myDuration">Duration, in milliseconds, of the bulb shot.</param>
        /// <returns>Any of the sdk errors.</returns>
        public CanonSDKError Bulb(UInt32 myDuration)
        {

            CanonSDKError _CanonSDKError;

            _CanonSDKError = BulbStart();
            if (_CanonSDKError != CanonSDKError.EDS_ERR_OK)
                return _CanonSDKError;

            Thread.Sleep(Convert.ToInt32(myDuration));

            return BulbEnd();

        }

        #endregion



        #endregion


        #region IDisposable Members

        public void Dispose()
        {
            CloseSession();
        }

        #endregion

    }

}
