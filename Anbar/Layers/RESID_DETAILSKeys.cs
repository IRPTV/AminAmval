using System;
using System.Collections.Generic;
using System.Text;
namespace Anbar.BusinessLayer
{
	public class RESID_DETAILSKeys
	{

		#region Data Members

		int _iD;

		#endregion

		#region Constructor

		public RESID_DETAILSKeys(int iD)
		{
			 _iD = iD; 
		}

		#endregion

		#region Properties

		public int  ID
		{
			 get { return _iD; }
		}

		#endregion

	}
}
