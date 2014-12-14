using System;
using System.Collections.Generic;
using System.Text;
namespace Anbar.BusinessLayer
{
	public class OWNERS: BusinessObjectBase
	{

		#region InnerClass
		public enum OWNERSFields
		{
			ID,
			INCOMINGID,
			EMPLOYEEID,
			DATETIME_DELIVER,
			DATETIME_CANCEL,
			ACTIVE
		}
		#endregion

		#region Data Members

			int _iD;
			int? _iNCOMINGID;
			int? _eMPLOYEEID;
			DateTime? _dATETIME_DELIVER;
			DateTime? _dATETIME_CANCEL;
			bool? _aCTIVE;

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

		public int?  INCOMINGID
		{
			 get { return _iNCOMINGID; }
			 set
			 {
				 if (_iNCOMINGID != value)
				 {
					_iNCOMINGID = value;
					 PropertyHasChanged("INCOMINGID");
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

		public DateTime?  DATETIME_DELIVER
		{
			 get { return _dATETIME_DELIVER; }
			 set
			 {
				 if (_dATETIME_DELIVER != value)
				 {
					_dATETIME_DELIVER = value;
					 PropertyHasChanged("DATETIME_DELIVER");
				 }
			 }
		}

		public DateTime?  DATETIME_CANCEL
		{
			 get { return _dATETIME_CANCEL; }
			 set
			 {
				 if (_dATETIME_CANCEL != value)
				 {
					_dATETIME_CANCEL = value;
					 PropertyHasChanged("DATETIME_CANCEL");
				 }
			 }
		}

		public bool?  ACTIVE
		{
			 get { return _aCTIVE; }
			 set
			 {
				 if (_aCTIVE != value)
				 {
					_aCTIVE = value;
					 PropertyHasChanged("ACTIVE");
				 }
			 }
		}


		#endregion

		#region Validation

		internal override void AddValidationRules()
		{
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("ID", "ID"));
		}

		#endregion

	}
}
