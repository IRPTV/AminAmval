using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Anbar.BusinessLayer.DataLayer;

namespace Anbar.BusinessLayer
{
    public class EmployeesFactory
    {

        #region data Members

        EmployeesSql _dataObject = null;

        #endregion

        #region Constructor

        public EmployeesFactory()
        {
            _dataObject = new EmployeesSql();
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Insert new Employees
        /// </summary>
        /// <param name="businessObject">Employees object</param>
        /// <returns>true for successfully saved</returns>
        public bool Insert(Employees businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Insert(businessObject);

        }

        /// <summary>
        /// Update existing Employees
        /// </summary>
        /// <param name="businessObject">Employees object</param>
        /// <returns>true for successfully saved</returns>
        public bool Update(Employees businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Update(businessObject);
        }

        /// <summary>
        /// get Employees by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public Employees GetByPrimaryKey(EmployeesKeys keys)
        {
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all Employeess
        /// </summary>
        /// <returns>list</returns>
        public List<Employees> GetAll()
        {
            return _dataObject.SelectAll(); 
        }

        /// <summary>
        /// get list of Employees by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public List<Employees> GetAllBy(Employees.EmployeesFields fieldName, object value)
        {
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public bool Delete(EmployeesKeys keys)
        {
            return _dataObject.Delete(keys); 
        }

        /// <summary>
        /// delete Employees by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public bool Delete(Employees.EmployeesFields fieldName, object value)
        {
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
