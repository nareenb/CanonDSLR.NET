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

namespace com.aperis.CanonDSLR.CanonSDK
{

    public enum StateEvent : uint
    {

        /// <summary>
        /// Notifies all state events.
        /// </summary>
        All                     = 0x00000300,

        /// <summary>
        /// Indicates that a camera is no longer connected to a computer, 
        /// whether it was disconnected by unplugging a cord, opening
        /// the compact flash compartment, 
        /// turning the camera off, auto shut-off, or by other means. 
        /// </summary>
        Shutdown                = 0x00000301,

        /// <summary>
        /// Notifies of whether or not there are objects waiting to
        /// be transferred to a host computer. 
        /// This is useful when ensuring all shot images have been transferred 
        /// when the application is closed. 
        /// Notification of this event is not issued for type 1 protocol 
        /// standard cameras.
        /// </summary>
        JobStatusChanged        = 0x00000302,

        /// <summary>
        /// Notifies that the camera will shut down after a specific period. 
        /// Generated only if auto shut-off is set. 
        /// Exactly when notification is issued (that is, the number of
        /// seconds until shutdown) varies depending on the camera model. 
        /// To continue operation without having the camera shut down,
        /// use EdsSendCommand to extend the auto shut-off timer.
        /// The time in seconds until the camera shuts down is returned
        /// as the initial value.
        /// </summary>
        WillSoonShutDown        = 0x00000303,

        /// <summary>
        /// As the counterpart event to kEdsWillSoonShutDown,
        /// this event notifies of updates to the number of seconds until
        /// a camera shuts down.
        /// After the update, the period until shutdown is model-dependent.
        /// </summary>
        ShutDownTimerUpdate     = 0x00000304,

        /// <summary>
        /// Notifies that a requested release has failed, due to focus
        /// failure or similar factors.
        /// </summary>
        CaptureError            = 0x00000305,

        /// <summary>
        /// Notifies of internal SDK errors. 
        /// If this error event is received, the issuing device will probably
        /// not be able to continue working properly,
        /// so cancel the remote connection.
        /// </summary>
        InternalError           = 0x00000306,

        AfResult                = 0x00000309,

        BulbExposureTime        = 0x00000310

    }

}
