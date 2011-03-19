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
    /// The camera's aperture value.
    /// </summary>
    public enum Av : uint
    {

        /// <summary>
        /// 1
        /// </summary>
        [Description("1")]
        Av1        = 0x08,

        /// <summary>
        /// 1.1
        /// </summary>
        [Description("1.1")]
        Av1_1      = 0x0b,

        /// <summary>
        /// 1.2
        /// </summary>
        [Description("1.2")]
        Av1_2      = 0x0c,

        /// <summary>
        /// 1.2 (1/3)
        /// </summary>
        [Description("1.2 (1/3)")]
        Av1_2_1_3  = 0x0d,

        /// <summary>
        /// 1.4
        /// </summary>
        [Description("1.4")]
        Av1_4      = 0x10,

        /// <summary>
        /// 1.6
        /// </summary>
        [Description("1.6")]
        Av1_6      = 0x13,

        /// <summary>
        /// 1.8
        /// </summary>
        [Description("1.8")]
        Av1_8      = 0x14,

        /// <summary>
        /// 1.8 (1/3)
        /// </summary>
        [Description("1.8 (1/3)")]
        Av1_8_1_3  = 0x15,

        /// <summary>
        /// 2
        /// </summary>
        [Description("2")]
        Av2        = 0x18,

        /// <summary>
        /// 2.2
        /// </summary>
        [Description("2.2")]
        Av2_2      = 0x1b,

        /// <summary>
        /// 2.5
        /// </summary>
        [Description("2.5")]
        Av2_5      = 0x1c,

        /// <summary>
        /// 2.5 (1/3)
        /// </summary>
        [Description("2.5 (1/3)")]
        Av2_5_1_3  = 0x1d,

        /// <summary>
        /// 2.8
        /// </summary>
        [Description("2.8")]
        Av2_8      = 0x20,

        /// <summary>
        /// 3.2
        /// </summary>
        [Description("3.2")]
        Av3_2      = 0x23,

        /// <summary>
        /// 3.5
        /// </summary>
        [Description("3.5")]
        Av3_5      = 0x24,

        /// <summary>
        /// 3.5 (1/3)
        /// </summary>
        [Description("3.5 (1/3)")]
        Av3_5_1_3  = 0x25,

        /// <summary>
        /// 4
        /// </summary>
        [Description("4")]
        Av4        = 0x28,

        /// <summary>
        /// 4.5
        /// </summary>
        [Description("4.5")]
        Av4_5_1    = 0x2b,

        /// <summary>
        /// 4.5
        /// </summary>
        [Description("4.5")]
        Av4_5_2    = 0x2c,

        /// <summary>
        /// 5.0
        /// </summary>
        [Description("5.0")]
        Av5_0      = 0x2d,

        /// <summary>
        /// 5.6
        /// </summary>
        [Description("5.6")]
        Av5_6      = 0x30,

        /// <summary>
        /// 6.3
        /// </summary>
        [Description("6.3")]
        Av6_3      = 0x33,

        /// <summary>
        /// 6.7
        /// </summary>
        [Description("6.7")]
        Av6_7      = 0x34,

        /// <summary>
        /// 7.1
        /// </summary>
        [Description("7.1")]
        Av7_1      = 0x35,

        /// <summary>
        /// 8
        /// </summary>
        [Description("8")]
        Av8        = 0x38,

        /// <summary>
        /// 9
        /// </summary>
        [Description("9")]
        Av9        = 0x3b,

        /// <summary>
        /// 9.5
        /// </summary>
        [Description("9.5")]
        Av9_5      = 0x3c,

        /// <summary>
        /// 10
        /// </summary>
        [Description("10")]
        Av10       = 0x3d,

        /// <summary>
        /// 11
        /// </summary>
        [Description("11")]
        Av11       = 0x40,

        /// <summary>
        /// 13 (1/3)
        /// </summary>
        [Description("13 (1/3)")]
        Av13_1_3   = 0x43,

        /// <summary>
        /// 13
        /// </summary>
        [Description("13")]
        Av13       = 0x44,

        /// <summary>
        /// 14
        /// </summary>
        [Description("14")]
        Av14       = 0x45,

        /// <summary>
        /// 16
        /// </summary>
        [Description("16")]
        Av16       = 0x48,

        /// <summary>
        /// 18
        /// </summary>
        [Description("18")]
        Av18       = 0x4b,

        /// <summary>
        /// 19
        /// </summary>
        [Description("19")]
        Av19       = 0x4c,

        /// <summary>
        /// 20
        /// </summary>
        [Description("20")]
        Av20       = 0x4d,

        /// <summary>
        /// 22
        /// </summary>
        [Description("22")]
        Av22       = 0x50,

        /// <summary>
        /// 25
        /// </summary>
        [Description("25")]
        Av25       = 0x53,

        /// <summary>
        /// 27
        /// </summary>
        [Description("27")]
        Av27       = 0x54,

        /// <summary>
        /// 29
        /// </summary>
        [Description("29")]
        Av29       = 0x55,

        /// <summary>
        /// 32
        /// </summary>
        [Description("32")]
        Av32       = 0x58,

        /// <summary>
        /// 36
        /// </summary>
        [Description("36")]
        Av36       = 0x5b,

        /// <summary>
        /// 38
        /// </summary>
        [Description("38")]
        Av38       = 0x5c,

        /// <summary>
        /// 40
        /// </summary>
        [Description("40")]
        Av40       = 0x5d,

        /// <summary>
        /// 45
        /// </summary>
        [Description("45")]
        Av45       = 0x60,

        /// <summary>
        /// 51
        /// </summary>
        [Description("51")]
        Av51       = 0x63,

        /// <summary>
        /// 54
        /// </summary>
        [Description("54")]
        Av54       = 0x64,

        /// <summary>
        /// 57
        /// </summary>
        [Description("57")]
        Av57       = 0x65,

        /// <summary>
        /// 64
        /// </summary>
        [Description("64")]
        Av64       = 0x68,

        /// <summary>
        /// 72
        /// </summary>
        [Description("72")]
        Av72       = 0x6b,

        /// <summary>
        /// 76
        /// </summary>
        [Description("76")]
        Av76       = 0x6c,

        /// <summary>
        /// 80
        /// </summary>
        [Description("80")]
        Av80       = 0x6d,

        /// <summary>
        /// 91
        /// </summary>
        [Description("91")]
        Av91       = 0x70,


        /// <summary>
        /// Unknown
        /// </summary>
        [Description("Unknown")]
        Unknown    = 0xffffffff

    }

}
