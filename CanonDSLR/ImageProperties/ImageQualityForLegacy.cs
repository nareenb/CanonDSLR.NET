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
    
    public enum ImageQualityForLegacy : uint
    {

	    LJ		    = 0x001f000f,	/* JPeg Large */
	    M1J		    = 0x051f000f,	/* JPeg Middle1 */
	    M2J		    = 0x061f000f,	/* JPeg Middle2 */
	    SJ		    = 0x021f000f,	/* JPeg Small */
	    LJF		    = 0x00130000,	/* JPeg Large Fine */
	    LJN		    = 0x00120000,	/* JPeg Large Normal */
	    MJF		    = 0x01130000,	/* JPeg Middle Fine */
	    MJN		    = 0x01120000,	/* JPeg Middle Normal */
	    SJF		    = 0x02130000,	/* JPeg Small Fine */
	    SJN		    = 0x02130000,	/* JPeg Small Normal */
                          
	    LR		    = 0x00240000,	/* RAW */
	    LRLJF		= 0x00240013,	/* RAW + JPeg Large Fine */
	    LRLJN		= 0x00240012,	/* RAW + JPeg Large Normal */
	    LRMJF		= 0x00240113,	/* RAW + JPeg Middle Fine */
	    LRMJN		= 0x00240112,	/* RAW + JPeg Middle Normal */
	    LRSJF		= 0x00240213,	/* RAW + JPeg Small Fine */
	    LRSJN		= 0x00240212,	/* RAW + JPeg Small Normal */
                          
	    LR2		    = 0x002f000f,	/* RAW */
	    LR2LJ		= 0x002f001f,	/* RAW + JPeg Large */
	    LR2M1J	    = 0x002f051f,	/* RAW + JPeg Middle1 */
	    LR2M2J	    = 0x002f061f,	/* RAW + JPeg Middle2 */
	    LR2SJ		= 0x002f021f,	/* RAW + JPeg Small */

	    Unknown     = 0xffffffff,

    }

}
