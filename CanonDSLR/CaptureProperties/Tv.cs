/*
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
    /// The shutter speed.
    /// </summary>
    public enum Tv : uint
    {

        /// <summary>
        /// Blub
        /// </summary>
        [Description("Bulb")]
        Tv_Bulb    = 0x0c,

        /// <summary>
        /// 30 sec
        /// </summary>
        [Description("30 sec")]
        Tv30s      = 0x10,

        /// <summary>
        /// 25 sec
        /// </summary>
        [Description("25 sec")]
        Tv25s      = 0x13,

        /// <summary>
        /// 20 sec
        /// </summary>
        [Description("20 sec")]
        Tv20s      = 0x14,

        /// <summary>
        /// 20 1/3 sec
        /// </summary>
        [Description("20 1/3 sec")]
        Tv20_1_3s  = 0x15,

        /// <summary>
        /// 15 sec
        /// </summary>
        [Description("15 sec")]
        Tv15s      = 0x18,

        /// <summary>
        /// 13 sec
        /// </summary>
        [Description("13 sec")]
        Tv13s      = 0x1b,

        /// <summary>
        /// 10 sec
        /// </summary>
        [Description("10 sec")]
        Tv10s      = 0x1c,

        /// <summary>
        /// 10 1/3 sec
        /// </summary>
        [Description("10 1/3 sec")]
        Tv10_1_3s  = 0x1d,

        /// <summary>
        /// 8 sec
        /// </summary>
        [Description("8.0 sec")]
        Tv8s       = 0x20,

        /// <summary>
        /// 6 1/3 sec
        /// </summary>
        [Description("6.0 1/3 sec")]
        Tv6_1_3s   = 0x23,

        /// <summary>
        /// 6.0 sec
        /// </summary>
        [Description("6.0 sec")]
        Tv6s       = 0x24,

        /// <summary>
        /// 5.0 sec
        /// </summary>
        [Description("5.0 sec")]
        Tv5s       = 0x25,

        /// <summary>
        /// 4.0 sec
        /// </summary>
        [Description("4.0 sec")]
        Tv4s       = 0x28,

        /// <summary>
        /// 3.2 sec
        /// </summary>
        [Description("3.2 sec")]
        Tv3_2s     = 0x2b,

        /// <summary>
        /// 3.0 sec
        /// </summary>
        [Description("3.0 sec")]
        Tv3s       = 0x2c,

        /// <summary>
        /// 2.5 sec
        /// </summary>
        [Description("2.5 sec")]
        Tv2_5s     = 0x2d,

        /// <summary>
        /// 2.0 sec
        /// </summary>
        [Description("2.0 sec")]
        Tv2s       = 0x30,

        /// <summary>
        /// 1.6 sec
        /// </summary>
        [Description("1.6 sec")]
        Tv1_6s     = 0x33,

        /// <summary>
        /// 1.5 sec
        /// </summary>
        [Description("1.5 sec")]
        Tv1_5s     = 0x34,

        /// <summary>
        /// 1.3 sec
        /// </summary>
        [Description("1.3 sec")]
        Tv1_3s     = 0x35,

        /// <summary>
        /// 1.0 sec
        /// </summary>
        [Description("1.0 sec")]
        Tv1s       = 0x38,

        /// <summary>
        /// 0.8 sec
        /// </summary>
        [Description("0.8 sec")]
        Tv0_8s     = 0x3b,

        /// <summary>
        /// 0.7 sec
        /// </summary>
        [Description("0.7 sec")]
        Tv0_7s     = 0x3c,

        /// <summary>
        /// 0.6 sec
        /// </summary>
        [Description("0.6 sec")]
        Tv0_6s     = 0x3d,

        /// <summary>
        /// 0.5 sec
        /// </summary>
        [Description("0.5 sec")]
        Tv0_5s     = 0x40,

        /// <summary>
        /// 0.4 sec
        /// </summary>
        [Description("0.4 sec")]
        Tv0_4s     = 0x43,

        /// <summary>
        /// 0.3 sec
        /// </summary>
        [Description("0.3 sec")]
        Tv0_3s     = 0x44,

        /// <summary>
        /// 0.3 1/3 sec
        /// </summary>
        [Description("0.3 1/3 sec")]
        Tv0_3_1_3s = 0x45,

        /// <summary>
        /// 1/4 sec
        /// </summary>
        [Description("1/4 sec")]
        Tv1_4      = 0x48,

        /// <summary>
        /// 1/5 sec
        /// </summary>
        [Description("1/5 sec")]
        Tv1_5      = 0x4b,

        /// <summary>
        /// 1/6 sec
        /// </summary>
        [Description("1/6 sec")]
        Tv1_6      = 0x4c,

        /// <summary>
        /// 1/6 1/3 sec
        /// </summary>
        [Description("1/6 1/3 sec")]
        Tv1_6_1_3  = 0x4d,

        /// <summary>
        /// 1/8 sec
        /// </summary>
        [Description("1/8 sec")]
        Tv1_8      = 0x50,

        /// <summary>
        /// 1/10 1/3 sec
        /// </summary>
        [Description("1/10 1/3 sec")]
        Tv1_10_1_3 = 0x53,

        /// <summary>
        /// 1/10 sec
        /// </summary>
        [Description("1/10 sec")]
        Tv1_10     = 0x54,

        /// <summary>
        /// 1/13 sec
        /// </summary>
        [Description("1/13 sec")]
        Tv1_13     = 0x55,

        /// <summary>
        /// 1/15 sec
        /// </summary>
        [Description("1/15 sec")]
        Tv1_15     = 0x58,

        /// <summary>
        /// 1/20 1/3 sec
        /// </summary>
        [Description("1/20 1/3 sec")]
        Tv1_20_1_3 = 0x5b,

        /// <summary>
        /// 1/20 sec
        /// </summary>
        [Description("1/20 sec")]
        Tv1_20     = 0x5c,

        /// <summary>
        /// 1/25 sec
        /// </summary>
        [Description("1/25 sec")]
        Tv1_25     = 0x5d,

        /// <summary>
        /// 1/30 sec
        /// </summary>
        [Description("1/30 sec")]
        Tv1_30     = 0x60,

        /// <summary>
        /// 1/40 sec
        /// </summary>
        [Description("1/40 sec")]
        Tv1_40     = 0x63,

        /// <summary>
        /// 1/45 sec
        /// </summary>
        [Description("1/45 sec")]
        Tv1_45     = 0x64,

        /// <summary>
        /// 1/50 sec
        /// </summary>
        [Description("1/50 sec")]
        Tv1_50     = 0x65,

        /// <summary>
        /// 1/60 sec
        /// </summary>
        [Description("1/60 sec")]
        Tv1_60     = 0x68,

        /// <summary>
        /// 1/80 sec
        /// </summary>
        [Description("1/80 sec")]
        Tv1_80     = 0x6b,

        /// <summary>
        /// 1/90 sec
        /// </summary>
        [Description("1/90 sec")]
        Tv1_90     = 0x6c,

        /// <summary>
        /// 1/100 sec
        /// </summary>
        [Description("1/100 sec")]
        Tv1_100    = 0x6d,

        /// <summary>
        /// 1/125 sec
        /// </summary>
        [Description("1/125 sec")]
        Tv1_125    = 0x70,

        /// <summary>
        /// 1/160 sec
        /// </summary>
        [Description("1/160 sec")]
        Tv1_160    = 0x73,

        /// <summary>
        /// 1/180 sec
        /// </summary>
        [Description("1/180 sec")]
        Tv1_180    = 0x74,

        /// <summary>
        /// 1/200 sec
        /// </summary>
        [Description("1/200 sec")]
        Tv1_200    = 0x75,

        /// <summary>
        /// 1/250 sec
        /// </summary>
        [Description("1/250 sec")]
        Tv1_250    = 0x78,

        /// <summary>
        /// 1/320 sec
        /// </summary>
        [Description("1/320 sec")]
        Tv1_320    = 0x7b,

        /// <summary>
        /// 1/350 sec
        /// </summary>
        [Description("1/350 sec")]
        Tv1_350    = 0x7c,

        /// <summary>
        /// 1/400 sec
        /// </summary>
        [Description("1/400 sec")]
        Tv1_400    = 0x7d,

        /// <summary>
        /// 1/500 sec
        /// </summary>
        [Description("1/500 sec")]
        Tv1_500    = 0x80,

        /// <summary>
        /// 1/640 sec
        /// </summary>
        [Description("1/640 sec")]
        Tv1_640    = 0x83,

        /// <summary>
        /// 1/750 sec
        /// </summary>
        [Description("1/750 sec")]
        Tv1_750    = 0x84,

        /// <summary>
        /// 1/800 sec
        /// </summary>
        [Description("1/800 sec")]
        Tv1_800    = 0x85,

        /// <summary>
        /// 1/1000 sec
        /// </summary>
        [Description("1/1000 sec")]
        Tv1_1000   = 0x88,

        /// <summary>
        /// 1/1250 sec
        /// </summary>
        [Description("1/1250 sec")]
        Tv1_1250   = 0x8b,

        /// <summary>
        /// 1/1500 sec
        /// </summary>
        [Description("1/1500 sec")]
        Tv1_1500   = 0x8c,

        /// <summary>
        /// 1/1600 sec
        /// </summary>
        [Description("1/1600 sec")]
        Tv1_1600   = 0x8d,

        /// <summary>
        /// 1/2000 sec
        /// </summary>
        [Description("1/2000 sec")]
        Tv1_2000   = 0x90,

        /// <summary>
        /// 1/2500 sec
        /// </summary>
        [Description("1/2500 sec")]
        Tv1_2500   = 0x93,

        /// <summary>
        /// 1/3000 sec
        /// </summary>
        [Description("1/3000 sec")]
        Tv1_3000   = 0x94,

        /// <summary>
        /// 1/3200 sec
        /// </summary>
        [Description("1/3200 sec")]
        Tv1_3200   = 0x95,

        /// <summary>
        /// 1/4000 sec
        /// </summary>
        [Description("1/4000 sec")]
        Tv1_4000   = 0x98,

        /// <summary>
        /// 1/5000 sec
        /// </summary>
        [Description("1/5000 sec")]
        Tv1_5000   = 0x9b,

        /// <summary>
        /// 1/6000 sec
        /// </summary>
        [Description("1/6000 sec")]
        Tv1_6000   = 0x9c,

        /// <summary>
        /// 1/6400 sec
        /// </summary>
        [Description("1/6400 sec")]
        Tv1_6400   = 0x9d,

        /// <summary>
        /// 1/8000 sec
        /// </summary>
        [Description("1/8000 sec")]
        Tv1_8000   = 0xa0,


        /// <summary>
        /// Unknown
        /// </summary>
        [Description("Unknown")]
        Unknown   = 0xffffffff

    }

}
