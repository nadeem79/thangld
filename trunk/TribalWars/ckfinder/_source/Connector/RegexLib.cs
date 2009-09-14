/*
 * CKFinder
 * ========
 * http://www.ckfinder.com
 * Copyright (C) 2007-2008 Frederico Caldeira Knabben (FredCK.com)
 *
 * The software, this file and its contents are subject to the CKFinder
 * License. Please read the license.txt file before using, installing, copying,
 * modifying or distribute this file or part of its contents. The contents of
 * this file is part of the Source Code of CKFinder.
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CKFinder.Connector
{
	internal static class RegexLib
	{
		private static Regex _ConfigServerPlaceholders;

		public static Regex ConfigServerPlaceholders
		{
			get
			{
				if ( _ConfigServerPlaceholders == null )
					_ConfigServerPlaceholders = new Regex( @"%SERVER\(\s*([^)]+?)\s*\)%", RegexOptions.Singleline | RegexOptions.Compiled );
				return _ConfigServerPlaceholders;
			}
		}
	}
}
