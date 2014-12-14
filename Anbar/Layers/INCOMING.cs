using System;
using System.Collections.Generic;
using System.Text;
namespace Anbar.BusinessLayer
{
	public class INCOMING: BusinessObjectBase
	{

		#region InnerClass
		public enum INCOMINGFields
		{
			ID,
			AMVALCODE,
			OBJECTID,
			BRAND,
			SERIAL,
			MODEL,
			DATETIME,
			OWNER
		}
		#endregion

		#region Data Members

			int _iD;
			string _aMVALCODE;
			int? _oBJECTID;
			string _bRAND;
			string _sERIAL;
			string _mODEL;
			DateTime? _dATETIME;
			int? _oWNER;

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

		public string  AMVALCODE
		{
			 get { return _aMVALCODE; }
			 set
			 {
				 if (_aMVALCODE != value)
				 {
					_aMVALCODE = value;
					 PropertyHasChanged("AMVALCODE");
				 }
			 }
		}

		public int?  OBJECTID
		{
			 get { return _oBJECTID; }
			 set
			 {
				 if (_oBJECTID != value)
				 {
					_oBJECTID = value;
					 PropertyHasChanged("OBJECTID");
				 }
			 }
		}

		public string  BRAND
		{
			 get { return _bRAND; }
			 set
			 {
				 if (_bRAND != value)
				 {
					_bRAND = value;
					 PropertyHasChanged("BRAND");
				 }
			 }
		}

		public string  SERIAL
		{
			 get { return _sERIAL; }
			 set
			 {
				 if (_sERIAL != value)
				 {
					_sERIAL = value;
					 PropertyHasChanged("SERIAL");
				 }
			 }
		}

		public string  MODEL
		{
			 get { return _mODEL; }
			 set
			 {
				 if (_mODEL != value)
				 {
					_mODEL = value;
					 PropertyHasChanged("MODEL");
				 }
			 }
		}

		public DateTime?  DATETIME
		{
			 get { return _dATETIME; }
			 set
			 {
				 if (_dATETIME != value)
				 {
					_dATETIME = value;
					 PropertyHasChanged("DATETIME");
				 }
			 }
		}

		public int?  OWNER
		{
			 get { return _oWNER; }
			 set
			 {
				 if (_oWNER != value)
				 {
					_oWNER = value;
					 PropertyHasChanged("OWNER");
				 }
			 }
		}


		#endregion

		#region Validation

		internal override void AddValidationRules()
		{
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("ID", "ID"));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("AMVALCODE", "AMVALCODE",2147483647));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("BRAND", "BRAND",2147483647));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("SERIAL", "SERIAL",2147483647));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("MODEL", "MODEL",2147483647));
		}

		#endregion

	}
}
