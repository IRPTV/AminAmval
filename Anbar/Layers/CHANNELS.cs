using System;
using System.Collections.Generic;
using System.Text;
namespace Anbar.BusinessLayer
{
	public class CHANNELS: BusinessObjectBase
	{

		#region InnerClass
		public enum CHANNELSFields
		{
			ID,
			TITLE,
			LOGOPATH
		}
		#endregion

		#region Data Members

			int _iD;
			string _tITLE;
			string _lOGOPATH;

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

		public string  LOGOPATH
		{
			 get { return _lOGOPATH; }
			 set
			 {
				 if (_lOGOPATH != value)
				 {
					_lOGOPATH = value;
					 PropertyHasChanged("LOGOPATH");
				 }
			 }
		}


		#endregion

		#region Validation

		internal override void AddValidationRules()
		{
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("ID", "ID"));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("TITLE", "TITLE",2147483647));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("LOGOPATH", "LOGOPATH",2147483647));
		}

		#endregion

	}
}
