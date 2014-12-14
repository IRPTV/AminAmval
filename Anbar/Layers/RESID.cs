using System;
using System.Collections.Generic;
using System.Text;
namespace Anbar.BusinessLayer
{
	public class RESID: BusinessObjectBase
	{

		#region InnerClass
		public enum RESIDFields
		{
			ID,
			KIND,
			RESIDCODE,
			EMPLOYEEID,
			CHANNEL,
			DEP,
			REQNUMBER,
			REQDATE,
			BOSSID,
			DATETIME,
            ROOMNUMBER
		}
		#endregion

		#region Data Members

			int _iD;
			byte? _kIND;
			string _rESIDCODE;
			int? _eMPLOYEEID;
			int? _cHANNEL;
			int? _dEP;
			string _rEQNUMBER;
			string _rEQDATE;
			int? _bOSSID;
			DateTime? _dATETIME;
            string _ROOMNUMBER;

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

		public byte?  KIND
		{
			 get { return _kIND; }
			 set
			 {
				 if (_kIND != value)
				 {
					_kIND = value;
					 PropertyHasChanged("KIND");
				 }
			 }
		}

		public string  RESIDCODE
		{
			 get { return _rESIDCODE; }
			 set
			 {
				 if (_rESIDCODE != value)
				 {
					_rESIDCODE = value;
					 PropertyHasChanged("RESIDCODE");
				 }
			 }
		}
        public string ROOMNUMBER
		{
            get { return _ROOMNUMBER; }
			 set
			 {
                 if (_ROOMNUMBER != value)
				 {
                     _ROOMNUMBER = value;
                     PropertyHasChanged("ROOMNUMBER");
				 }
			 }
		}
        
		public int?  EMPLOYEEID
		{
			 get { return _eMPLOYEEID; }
			 set
			 {
				 if (_eMPLOYEEID != value)
				 {
					_eMPLOYEEID = value;
					 PropertyHasChanged("EMPLOYEEID");
				 }
			 }
		}

		public int?  CHANNEL
		{
			 get { return _cHANNEL; }
			 set
			 {
				 if (_cHANNEL != value)
				 {
					_cHANNEL = value;
					 PropertyHasChanged("CHANNEL");
				 }
			 }
		}

		public int?  DEP
		{
			 get { return _dEP; }
			 set
			 {
				 if (_dEP != value)
				 {
					_dEP = value;
					 PropertyHasChanged("DEP");
				 }
			 }
		}

		public string  REQNUMBER
		{
			 get { return _rEQNUMBER; }
			 set
			 {
				 if (_rEQNUMBER != value)
				 {
					_rEQNUMBER = value;
					 PropertyHasChanged("REQNUMBER");
				 }
			 }
		}

		public string  REQDATE
		{
			 get { return _rEQDATE; }
			 set
			 {
				 if (_rEQDATE != value)
				 {
					_rEQDATE = value;
					 PropertyHasChanged("REQDATE");
				 }
			 }
		}

		public int?  BOSSID
		{
			 get { return _bOSSID; }
			 set
			 {
				 if (_bOSSID != value)
				 {
					_bOSSID = value;
					 PropertyHasChanged("BOSSID");
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


		#endregion

		#region Validation

		internal override void AddValidationRules()
		{
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("ID", "ID"));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("RESIDCODE", "RESIDCODE",2147483647));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("REQNUMBER", "REQNUMBER",2147483647));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("REQDATE", "REQDATE",2147483647));
		}

		#endregion

	}
}
