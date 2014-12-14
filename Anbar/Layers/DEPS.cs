using System;
using System.Collections.Generic;
using System.Text;
namespace Anbar.BusinessLayer
{
	public class DEPS: BusinessObjectBase
	{

		#region InnerClass
		public enum DEPSFields
		{
			ID,
			TITLE,
			CHANNELID
		}
		#endregion

		#region Data Members

			int _iD;
			string _tITLE;
			int? _cHANNELID;

		#endregion

		#region Properties

		public int  ID
		{
			 get { return _iD; }
			 set
			 {
				 if (_iD != value)
				 {
					_iD = value;
					 PropertyHasChanged("ID");
				 }
			 }
		}

		public string  TITLE
		{
			 get { return _tITLE; }
			 set
			 {
				 if (_tITLE != value)
				 {
					_tITLE = value;
					 PropertyHasChanged("TITLE");
				 }
			 }
		}

		public int?  CHANNELID
		{
			 get { return _cHANNELID; }
			 set
			 {
				 if (_cHANNELID != value)
				 {
					_cHANNELID = value;
					 PropertyHasChanged("CHANNELID");
				 }
			 }
		}


		#endregion

		#region Validation

		internal override void AddValidationRules()
		{
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("ID", "ID"));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("TITLE", "TITLE",2147483647));
		}

		#endregion

	}
}
