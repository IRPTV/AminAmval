using System;
using System.Collections.Generic;
using System.Text;
namespace Anbar.BusinessLayer
{
	public class RESID_DETAILS: BusinessObjectBase
	{

		#region InnerClass
		public enum RESID_DETAILSFields
		{
			ID,
			RESIDID,
			INCOMINGID,
			ACTIVE
		}
		#endregion

		#region Data Members

			int _iD;
			int? _rESIDID;
			int? _iNCOMINGID;
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

		public int?  RESIDID
		{
			 get { return _rESIDID; }
			 set
			 {
				 if (_rESIDID != value)
				 {
					_rESIDID = value;
					 PropertyHasChanged("RESIDID");
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
