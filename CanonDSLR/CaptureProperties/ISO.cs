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
    /*-----------------------------------------------------------------------------
     ISO
    -----------------------------------------------------------------------------*/
    public enum ISO : uint 
    {
        [Description("AUTO")]                              AUTO = 0x00,
        [Description("6")]                                 ISO6 = 0x28,
        [Description("12")]                               ISO12 = 0x30,
        [Description("25")]                               ISO25 = 0x38,
        [Description("50")]                               ISO50 = 0x40,
        [Description("100")]                             ISO100 = 0x48,
        [Description("125")]                             ISO125 = 0x4b,
        [Description("160")]                             ISO160 = 0x4d,
        [Description("200")]                             ISO200 = 0x50,
        [Description("250")]                             ISO250 = 0x53,
        [Description("320")]                             ISO320 = 0x55,
        [Description("400")]                             ISO400 = 0x58,
        [Description("500")]                             ISO500 = 0x5b,
        [Description("640")]                             ISO640 = 0x5d,
        [Description("800")]                             ISO800 = 0x60,
        [Description("1000")]                           ISO1000 = 0x63,
        [Description("1250")]                           ISO1250 = 0x65,
        [Description("1600")]                           ISO1600 = 0x68,
        [Description("3200")]                           ISO3200 = 0x70,
        [Description("6400")]                           ISO6400 = 0x78,
        [Description("12800")]                         ISO12800 = 0x80,
        [Description("25600")]                         ISO25600 = 0x88,
        [Description("Not valid/no settings changes")]  Unknown = 0xffffffff
    }
}
