using System;
using System.Collections.Generic;
using System.Text;
namespace Anbar.BusinessLayer
{
	public class Employees: BusinessObjectBase
	{

		#region InnerClass
		public enum EmployeesFields
		{
			ID,
			PERSONALCODE,
			NAME,
			FAMILY,
			FATHER,
			PHONE,
			ADDRESS,
			DEP
		}
		#endregion

		#region Data Members

			int _iD;
			string _pERSONALCODE;
			string _nAME;
			string _fAMILY;
			string _fATHER;
			string _pHONE;
			string _aDDRESS;
			int? _dEP;

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

		public string  PERSONALCODE
		{
			 get { return _pERSONALCODE; }
			 set
			 {
				 if (_pERSONALCODE != value)
				 {
					_pERSONALCODE = value;
					 PropertyHasChanged("PERSONALCODE");
				 }
			 }
		}

		public string  NAME
		{
			 get { return _nAME; }
			 set
			 {
				 if (_nAME != value)
				 {
					_nAME = value;
					 PropertyHasChanged("NAME");
				 }
			 }
		}

		public string  FAMILY
		{
			 get { return _fAMILY; }
			 set
			 {
				 if (_fAMILY != value)
				 {
					_fAMILY = value;
					 PropertyHasChanged("FAMILY");
				 }
			 }
		}

		public string  FATHER
		{
			 get { return _fATHER; }
			 set
			 {
				 if (_fATHER != value)
				 {
					_fATHER = value;
					 PropertyHasChanged("FATHER");
				 }
			 }
		}

		public string  PHONE
		{
			 get { return _pHONE; }
			 set
			 {
				 if (_pHONE != value)
				 {
					_pHONE = value;
					 PropertyHasChanged("PHONE");
				 }
			 }
		}

		public string  ADDRESS
		{
			 get { return _aDDRESS; }
			 set
			 {
				 if (_aDDRESS != value)
				 {
					_aDDRESS = value;
					 PropertyHasChanged("ADDRESS");
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


		#endregion

		#region Validation

		internal override void AddValidationRules()
		{
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("ID", "ID"));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("PERSONALCODE", "PERSONALCODE",50));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("NAME", "NAME",50));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("FAMILY", "FAMILY",50));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("FATHER", "FATHER",50));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("PHONE", "PHONE",2147483647));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("ADDRESS", "ADDRESS",2147483647));
		}

		#endregion

	}
}
