using System;
using System.Collections.Generic;
using System.Text;
namespace Anbar.BusinessLayer
{
	public class OBJECTS: BusinessObjectBase
	{

		#region InnerClass
		public enum OBJECTSFields
		{
			ID,
			TITLE,
			GROUPID,
			CODE
		}
		#endregion

		#region Data Members

			int _iD;
			string _tITLE;
			int? _gROUPID;
			string _cODE;

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

		public int?  GROUPID
		{
			 get { return _gROUPID; }
			 set
			 {
				 if (_gROUPID != value)
				 {
					_gROUPID = value;
					 PropertyHasChanged("GROUPID");
				 }
			 }
		}

		public string  CODE
		{
			 get { return _cODE; }
			 set
			 {
				 if (_cODE != value)
				 {
					_cODE = value;
					 PropertyHasChanged("CODE");
				 }
			 }
		}


		#endregion

		#region Validation

		internal override void AddValidationRules()
		{
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("ID", "ID"));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("TITLE", "TITLE",2147483647));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("CODE", "CODE",2147483647));
		}

		#endregion

	}
}
