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

using System.ComponentModel;

#endregion

namespace com.aperis.CanonDSLR.CanonSDK
{

    /// <summary>
    /// The camera drive mode.
    /// </summary>
    public enum DriveMode : uint
    {
        
        /// <summary>
        /// Single-Frame Shooting
        /// </summary>
        [Description("Single-Frame Shooting")]
        SingleFrameShooting                 = 0x00,

        /// <summary>
        /// Continuous Shooting
        /// </summary>
        [Description("Continuous Shooting")]
        ContinuousShooting                  = 0x01,

        /// <summary>
        /// Video
        /// </summary>
        [Description("Video")]
        Video                               = 0x02,

        /// <summary>
        /// Not used
        /// </summary>
        [Description("Not used")]
        NotUsed                             = 0x03,


        /// <summary>
        /// High-Speed Continuous Shooting
        /// </summary>
        [Description("High-Speed Continuous Shooting")]
        HighSpeedContinuousShooting         = 0x04,

        /// <summary>
        /// Low-Speed Continuous Shooting
        /// </summary>
        [Description("Low-Speed Continuous Shooting")]
        LowSpeedContinuousShooting          = 0x05,

        /// <summary>
        /// Silent single shooting
        /// </summary>
        [Description("Silent single shooting")]
        SilentSingleShooting                = 0x06,


        /// <summary>
        /// 10-Sec Self-Timer plus continuous shots
        /// </summary>
        [Description("10-Sec Self-Timer plus continuous shots")]
        _10SecSelfTimerPlusContinuousShots  = 0x07,

        /// <summary>
        /// 10-Sec Self-Timer
        /// </summary>
        [Description("10-Sec Self-Timer")]
        _10SecSelfTimer                     = 0x10,

        /// <summary>
        /// 2-Sec Self-Timer
        /// </summary>
        [Description("2-Sec Self-Timer")]
        _2SecSelfTimer                      = 0x11

    }

}
