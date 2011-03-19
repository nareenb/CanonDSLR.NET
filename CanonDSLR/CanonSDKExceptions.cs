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

 using com.aperis.CanonDSLR.CanonSDK;
using System.Runtime.InteropServices;

#endregion

namespace com.aperis.CanonDSLR
{

    #region Generic CanonSDKException

    public class CanonSDKException : Exception
    {

        #region Properties

        public CanonSDKError CanonSDKError { get; protected set; }

        public String        Message       { get; set; }

        #endregion

        public CanonSDKException(CanonSDKError myCanonSDKError)
        {
            this.CanonSDKError = myCanonSDKError;
        }

    }

    #endregion


    #region Init-/TerminateSDK

    public class InitSDKException : CanonSDKException
    {
        public InitSDKException(CanonSDKError myCanonSDKError)
            : base(myCanonSDKError)
        { }
    }

    public class TerminateSDKException : CanonSDKException
    {
        public TerminateSDKException(CanonSDKError myCanonSDKError)
            : base(myCanonSDKError)
        { }
    }

    #endregion

    #region CameraList

    public class GetCameraListException : CanonSDKException
    {
        public GetCameraListException(CanonSDKError myCanonSDKError)
            : base(myCanonSDKError)
        { }
    }

    public class ReleaseCameraListException : CanonSDKException
    {
        public ReleaseCameraListException(CanonSDKError myCanonSDKError)
            : base(myCanonSDKError)
        { }
    }

    #endregion

    #region Camera

    public class GetCameraException : CanonSDKException
    {
        public GetCameraException(CanonSDKError myCanonSDKError)
            : base(myCanonSDKError)
        { }
    }

    public class ReleaseCameraException : CanonSDKException
    {
        public ReleaseCameraException(CanonSDKError myCanonSDKError)
            : base(myCanonSDKError)
        { }
    }

    #endregion


    #region Get-/SetPropertyException

    public class GetPropertyException : CanonSDKException
    {
        public GetPropertyException(CanonSDKError myCanonSDKError)
            : base(myCanonSDKError)
        { }
    }

    public class SetPropertyException : CanonSDKException
    {
        public SetPropertyException(CanonSDKError myCanonSDKError)
            : base(myCanonSDKError)
        { }
    }

    #endregion

    #region Get-/SetCameraSettingPropertyException

    public class GetCameraSettingPropertyException : GetPropertyException
    {
        public GetCameraSettingPropertyException(CanonSDKError myCanonSDKError)
            : base(myCanonSDKError)
        { }
    }

    public class SetCameraSettingPropertyException : SetPropertyException
    {
        public SetCameraSettingPropertyException(CanonSDKError myCanonSDKError)
            : base(myCanonSDKError)
        { }
    }

    // ----------------------------------------------------------------------

    public class GetProductNameException : GetCameraSettingPropertyException
    {
        public GetProductNameException(CanonSDKError myCanonSDKError)
            : base(myCanonSDKError)
        { }
    }

    public class GetBodyIdException : GetCameraSettingPropertyException
    {
        public GetBodyIdException(CanonSDKError myCanonSDKError)
            : base(myCanonSDKError)
        { }
    }

    public class GetOwnerNameException : GetCameraSettingPropertyException
    {
        public GetOwnerNameException(CanonSDKError myCanonSDKError)
            : base(myCanonSDKError)
        { }
    }

    public class GetMakerNameException : GetCameraSettingPropertyException
    {
        public GetMakerNameException(CanonSDKError myCanonSDKError)
            : base(myCanonSDKError)
        { }
    }

    public class GetCameraTimeException : GetCameraSettingPropertyException
    {
        public GetCameraTimeException(CanonSDKError myCanonSDKError)
            : base(myCanonSDKError)
        { }
    }

    public class GetFirmwareVersionException : GetCameraSettingPropertyException
    {
        public GetFirmwareVersionException(CanonSDKError myCanonSDKError)
            : base(myCanonSDKError)
        { }
    }

    public class GetBatteryLevelException : GetCameraSettingPropertyException
    {
        public GetBatteryLevelException(CanonSDKError myCanonSDKError)
            : base(myCanonSDKError)
        { }
    }

    public class GetCFnException : GetCameraSettingPropertyException
    {
        public GetCFnException(Int32 myCustomParameter, CanonSDKError myCanonSDKError)
            : base(myCanonSDKError)
        { }
    }

    public class GetSaveToException : GetCameraSettingPropertyException
    {
        public GetSaveToException(CanonSDKError myCanonSDKError)
            : base(myCanonSDKError)
        { }
    }

    public class SetSaveToException : SetCameraSettingPropertyException
    {
        public SetSaveToException(CanonSDKError myCanonSDKError)
            : base(myCanonSDKError)
        { }
    }

    public class GetCurrentStorageException : GetCameraSettingPropertyException
    {
        public GetCurrentStorageException(CanonSDKError myCanonSDKError)
            : base(myCanonSDKError)
        { }
    }

    public class GetCurrentFolderException : GetCameraSettingPropertyException
    {
        public GetCurrentFolderException(CanonSDKError myCanonSDKError)
            : base(myCanonSDKError)
        { }
    }

    public class GetLensStatusException : GetCameraSettingPropertyException
    {
        public GetLensStatusException(CanonSDKError myCanonSDKError)
            : base(myCanonSDKError)
        { }
    }

    public class SetLensStatusException : GetCameraSettingPropertyException
    {
        public SetLensStatusException(CanonSDKError myCanonSDKError)
            : base(myCanonSDKError)
        { }
    }

    #endregion

    #region GetCapturePropertyException

    public class GetCapturePropertyException : GetPropertyException
    {
        public GetCapturePropertyException(CanonSDKError myCanonSDKError)
            : base(myCanonSDKError)
        { }
    }

    public class SetCapturePropertyException : SetPropertyException
    {
        public SetCapturePropertyException(CanonSDKError myCanonSDKError)
            : base(myCanonSDKError)
        { }
    }

    // -------------------------------------------------------------------

    public class GetAEModeException : GetCapturePropertyException
    {
        public GetAEModeException(CanonSDKError myCanonSDKError)
            : base(myCanonSDKError)
        { }
    }

    public class SetAEModeException : SetCapturePropertyException
    {
        public SetAEModeException(CanonSDKError myCanonSDKError)
            : base(myCanonSDKError)
        { }
    }

    public class GetAFModeException : GetCapturePropertyException
    {
        public GetAFModeException(CanonSDKError myCanonSDKError)
            : base(myCanonSDKError)
        { }
    }

    public class SetAFModeException : SetCapturePropertyException
    {
        public SetAFModeException(CanonSDKError myCanonSDKError)
            : base(myCanonSDKError)
        { }
    }

    public class GetExposureCompensationException : GetCapturePropertyException
    {
        public GetExposureCompensationException(CanonSDKError myCanonSDKError)
            : base(myCanonSDKError)
        { }
    }

    public class SetExposureCompensationException : SetCapturePropertyException
    {
        public SetExposureCompensationException(CanonSDKError myCanonSDKError)
            : base(myCanonSDKError)
        { }
    }

    public class GetWhiteBalanceException : GetCapturePropertyException
    {
        public GetWhiteBalanceException(CanonSDKError myCanonSDKError)
            : base(myCanonSDKError)
        { }
    }

    public class SetWhiteBalanceException : SetCapturePropertyException
    {
        public SetWhiteBalanceException(CanonSDKError myCanonSDKError)
            : base(myCanonSDKError)
        { }
    }

    public class GetColorTemperatureException : GetCapturePropertyException
    {
        public GetColorTemperatureException(CanonSDKError myCanonSDKError)
            : base(myCanonSDKError)
        { }
    }

    public class SetColorTemperatureException : SetCapturePropertyException
    {
        public SetColorTemperatureException(CanonSDKError myCanonSDKError)
            : base(myCanonSDKError)
        { }
    }

    public class GetMeteringModeException : GetCapturePropertyException
    {
        public GetMeteringModeException(CanonSDKError myCanonSDKError)
            : base(myCanonSDKError)
        { }
    }

    public class SetMeteringModeException : SetCapturePropertyException
    {
        public SetMeteringModeException(CanonSDKError myCanonSDKError)
            : base(myCanonSDKError)
        { }
    }

    public class GetTvException : GetCapturePropertyException
    {
        public GetTvException(CanonSDKError myCanonSDKError)
            : base(myCanonSDKError)
        { }
    }

    public class SetTvException : SetCapturePropertyException
    {
        public SetTvException(CanonSDKError myCanonSDKError)
            : base(myCanonSDKError)
        { }
    }

    public class GetAvException : GetCapturePropertyException
    {
        public GetAvException(CanonSDKError myCanonSDKError)
            : base(myCanonSDKError)
        { }
    }

    public class SetAvException : SetCapturePropertyException
    {
        public SetAvException(CanonSDKError myCanonSDKError)
            : base(myCanonSDKError)
        { }
    }

    public class GetISOException : GetCapturePropertyException
    {
        public GetISOException(CanonSDKError myCanonSDKError)
            : base(myCanonSDKError)
        { }
    }

    public class SetISOException : SetCapturePropertyException
    {
        public SetISOException(CanonSDKError myCanonSDKError)
            : base(myCanonSDKError)
        { }
    }

    public class GetDriveModeException : GetCapturePropertyException
    {
        public GetDriveModeException(CanonSDKError myCanonSDKError)
            : base(myCanonSDKError)
        { }
    }

    public class SetDriveModeException : SetCapturePropertyException
    {
        public SetDriveModeException(CanonSDKError myCanonSDKError)
            : base(myCanonSDKError)
        { }
    }

    // ----------------------------------------------------------------------

    #endregion



    

}
