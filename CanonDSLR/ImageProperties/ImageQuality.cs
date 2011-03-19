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
    
    public enum ImageQuality : uint
    {

        #region JPeg Only

        /// <summary>
        /// JPeg Large
        /// </summary>
        [Description("JPeg Large")]                             LJ = 0x0010ff0f,

        /// <summary>
        /// JPeg Middle1
        /// </summary>
        [Description("JPeg Middle1")]                          M1J = 0x0510ff0f,

        /// <summary>
        /// JPeg Middle2
        /// </summary>
        [Description("JPeg Middle2")]                          M2J = 0x0610ff0f,

        /// <summary>
        /// JPeg Small
        /// </summary>
        [Description("JPeg Small")]                             SJ = 0x0210ff0f,

        /// <summary>
        /// JPeg Large Fine
        /// </summary>
        [Description("JPeg Large Fine")]                       LJF = 0x0013ff0f,

        /// <summary>
        /// JPeg Large Normal
        /// </summary>
        [Description("JPeg Large Normal")]                     LJN = 0x0012ff0f,

        /// <summary>
        /// JPeg Middle Fine
        /// </summary>
        [Description("JPeg Middle Fine")]                      MJF = 0x0113ff0f,

        /// <summary>
        /// JPeg Middle Normal
        /// </summary>
        [Description("JPeg Middle Normal")]                    MJN = 0x0112ff0f,


        /// <summary>
        /// JPeg Small Fine
        /// </summary>
        [Description("JPeg Small Fine")]                       SJF = 0x0213ff0f,

        /// <summary>
        /// JPeg Small Normal
        /// </summary>
        [Description("JPeg Small Normal")]                     SJN = 0x0213ff0f,

        /// <summary>
        /// JPeg Small1 Fine
        /// </summary>
        [Description("JPeg Small1 Fine")]                     S1JF = 0x0E13ff0f,

        /// <summary>
        /// JPeg Small1 Normal
        /// </summary>
        [Description("JPeg Small1 Normal")]                   S1JN = 0x0E12ff0f,

        /// <summary>
        /// JPeg Small2
        /// </summary>
        [Description("JPeg Small2")]                          S2JF = 0x0F13ff0f,

        /// <summary>
        /// JPeg Small3
        /// </summary>
        [Description("JPeg Small3")]                          S3JF = 0x1013ff0f,

        #endregion

        #region RAW + JPeg

        /// <summary>
        /// RAW
        /// </summary>
        [Description("RAW")]                                    LR = 0x0064ff0f,

        /// <summary>
        /// RAW + JPeg Large Fine
        /// </summary>
        [Description("RAW + JPeg Large Fine")]               LRLJF = 0x00640013,

        /// <summary>
        /// RAW + JPeg Large Normal
        /// </summary>
        [Description("RAW + JPeg Large Normal")]             LRLJN = 0x00640012,

        /// <summary>
        /// RAW + JPeg Middle Fine
        /// </summary>
        [Description("RAW + JPeg Middle Fine")]              LRMJF = 0x00640113,

        /// <summary>
        /// RAW + JPeg Middle Normal
        /// </summary>
        [Description("RAW + JPeg Middle Normal")]            LRMJN = 0x00640112,

        /// <summary>
        /// RAW + JPeg Small Fine
        /// </summary>
        [Description("RAW + JPeg Small Fine")]               LRSJF = 0x00640213,

        /// <summary>
        /// RAW + JPeg Small Normal
        /// </summary>
        [Description("RAW + JPeg Small Normal")]             LRSJN = 0x00640212,

        /// <summary>
        /// RAW + JPeg Small1 Fine
        /// </summary>
        [Description("RAW + JPeg Small1 Fine")]             LRS1JF = 0x00640E13,

        /// <summary>
        /// RAW + JPeg Small1 Normal
        /// </summary>
        [Description("RAW + JPeg Small1 Normal")]           LRS1JN = 0x00640E12,

        /// <summary>
        /// RAW + JPeg Small2
        /// </summary>
        [Description("RAW + JPeg Small2")]                  LRS2JF = 0x00640F13,

        /// <summary>
        /// RAW + JPeg Small3
        /// </summary>
        [Description("RAW + JPeg Small3")]                  LRS3JF = 0x00641013,


        /// <summary>
        /// RAW + JPeg Large
        /// </summary>
        [Description("RAW + JPeg Large")]                     LRLJ = 0x00640010,

        /// <summary>
        /// RAW + JPeg Middle1
        /// </summary>
        [Description("RAW + JPeg Middle1")]                  LRM1J = 0x00640510,

        /// <summary>
        /// RAW + JPeg Middle2
        /// </summary>
        [Description("RAW + JPeg Middle2")]                  LRM2J = 0x00640610,

        /// <summary>
        /// RAW + JPeg Small
        /// </summary>
        [Description("RAW + JPeg Small")]                     LRSJ = 0x00640210,

        #endregion

        #region MRAW(SRAW1) + JPeg

        /// <summary>
        /// MRAW(SRAW1)
        /// </summary>
        [Description("MRAW(SRAW1)")]                            MR = 0x0164ff0f,

        /// <summary>
        /// MRAW(SRAW1) + Jpeg Large Fine
        /// </summary>
        [Description("MRAW(SRAW1) + Jpeg Large Fine")]       MRLJF = 0x01640013,

        /// <summary>
        /// MRAW(SRAW1) + Jpeg Large Normal
        /// </summary>
        [Description("MRAW(SRAW1) + Jpeg Large Normal")]     MRLJN = 0x01640012,

        /// <summary>
        /// MRAW(SRAW1) + Jpeg Middle Fine
        /// </summary>
        [Description("MRAW(SRAW1) + Jpeg Middle Fine")]      MRMJF = 0x01640113,

        /// <summary>
        /// MRAW(SRAW1) + Jpeg Middle Normal
        /// </summary>
        [Description("MRAW(SRAW1) + Jpeg Middle Normal")]    MRMJN = 0x01640112,

        /// <summary>
        /// MRAW(SRAW1) + Jpeg Small Fine
        /// </summary>
        [Description("MRAW(SRAW1) + Jpeg Small Fine")]       MRSJF = 0x01640213,

        /// <summary>
        /// MRAW(SRAW1) + Jpeg Small Normal
        /// </summary>
        [Description("MRAW(SRAW1) + Jpeg Small Normal")]     MRSJN = 0x01640212,

        /// <summary>
        /// MRAW(SRAW1) + Jpeg Small1 Fine
        /// </summary>
        [Description("MRAW(SRAW1) + Jpeg Small1 Fine")]     MRS1JF = 0x01640E13,

        /// <summary>
        /// MRAW(SRAW1) + Jpeg Small1 Normal
        /// </summary>
        [Description("MRAW(SRAW1) + Jpeg Small1 Normal")]   MRS1JN = 0x01640E12,

        /// <summary>
        /// MRAW(SRAW1) + Jpeg Small2
        /// </summary>
        [Description("MRAW(SRAW1) + Jpeg Small2")]          MRS2JF = 0x01640F13,

        /// <summary>
        /// MRAW(SRAW1) + Jpeg Small3
        /// </summary>
        [Description("MRAW(SRAW1) + Jpeg Small3")]          MRS3JF = 0x01641013,


        /// <summary>
        /// MRAW(SRAW1) + Jpeg Large
        /// </summary>
        [Description("MRAW(SRAW1) + Jpeg Large")]             MRLJ = 0x01640010,

        /// <summary>
        /// MRAW(SRAW1) + Jpeg Middle1
        /// </summary>
        [Description("MRAW(SRAW1) + Jpeg Middle1")]          MRM1J = 0x01640510,

        /// <summary>
        /// MRAW(SRAW1) + Jpeg Middle2
        /// </summary>
        [Description("MRAW(SRAW1) + Jpeg Middle2")]          MRM2J = 0x01640610,

        /// <summary>
        /// MRAW(SRAW1) + Jpeg Small
        /// </summary>
        [Description("MRAW(SRAW1) + Jpeg Small")]             MRSJ = 0x01640210,

        #endregion

        #region SRAW(SRAW2) + JPeg

        /// <summary>
        /// SRAW(SRAW2)
        /// </summary>
        [Description("SRAW(SRAW2)")]                            SR = 0x0264ff0f,

        /// <summary>
        /// SRAW(SRAW2) + Jpeg Large Fine
        /// </summary>
        [Description("SRAW(SRAW2) + Jpeg Large Fine")]       SRLJF = 0x02640013,

        /// <summary>
        /// SRAW(SRAW2) + Jpeg Large Normal
        /// </summary>
        [Description("SRAW(SRAW2) + Jpeg Large Normal")]     SRLJN = 0x02640012,

        /// <summary>
        /// SRAW(SRAW2) + Jpeg Middle Fine
        /// </summary>
        [Description("SRAW(SRAW2) + Jpeg Middle Fine")]      SRMJF = 0x02640113,

        /// <summary>
        /// SRAW(SRAW2) + Jpeg Middle Normal
        /// </summary>
        [Description("SRAW(SRAW2) + Jpeg Middle Normal")]    SRMJN = 0x02640112,

        /// <summary>
        /// SRAW(SRAW2) + Jpeg Small Fine
        /// </summary>
        [Description("SRAW(SRAW2) + Jpeg Small Fine")]       SRSJF = 0x02640213,

        /// <summary>
        /// SRAW(SRAW2) + Jpeg Small Normal
        /// </summary>
        [Description("SRAW(SRAW2) + Jpeg Small Normal")]     SRSJN = 0x02640212,

        /// <summary>
        /// SRAW(SRAW2) + Jpeg Small1 Fine
        /// </summary>
        [Description("SRAW(SRAW2) + Jpeg Small1 Fine")]     SRS1JF = 0x02640E13,

        /// <summary>
        /// SRAW(SRAW2) + Jpeg Small1 Normal
        /// </summary>
        [Description("SRAW(SRAW2) + Jpeg Small1 Normal")]   SRS1JN = 0x02640E12,

        /// <summary>
        /// SRAW(SRAW2) + Jpeg Small2
        /// </summary>
        [Description("SRAW(SRAW2) + Jpeg Small2")]          SRS2JF = 0x02640F13,

        /// <summary>
        /// SRAW(SRAW2) + Jpeg Small3
        /// </summary>
        [Description("SRAW(SRAW2) + Jpeg Small3")]          SRS3JF = 0x02641013,


        /// <summary>
        /// SRAW(SRAW2) + Jpeg Large
        /// </summary>
        [Description("SRAW(SRAW2) + Jpeg Large")]             SRLJ = 0x02640010,

        /// <summary>
        /// SRAW(SRAW2) + Jpeg Middle1
        /// </summary>
        [Description("SRAW(SRAW2) + Jpeg Middle1")]          SRM1J = 0x02640510,

        /// <summary>
        /// SRAW(SRAW2) + Jpeg Middle2
        /// </summary>
        [Description("SRAW(SRAW2) + Jpeg Middle2")]          SRM2J = 0x02640610,

        /// <summary>
        /// SRAW(SRAW2) + Jpeg Small
        /// </summary>
        [Description("SRAW(SRAW2) + Jpeg Small")]             SRSJ = 0x02640210,

        #endregion

        #region Unknown

        /// <summary>
        /// Unknown
        /// </summary>
        [Description("Unknown ImageQuality")]              Unknown = 0xffffffff

        #endregion

    }

}
