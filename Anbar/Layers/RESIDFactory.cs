using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Anbar.BusinessLayer.DataLayer;

namespace Anbar.BusinessLayer
{
    public class RESIDFactory
    {

        #region data Members

        RESIDSql _dataObject = null;

        #endregion

        #region Constructor

        public RESIDFactory()
        {
            _dataObject = new RESIDSql();
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Insert new RESID
        /// </summary>
        /// <param name="businessObject">RESID object</param>
        /// <returns>true for successfully saved</returns>
        public int Insert(RESID businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Insert(businessObject);

        }

        /// <summary>
        /// Update existing RESID
        /// </summary>
        /// <param name="businessObject">RESID object</param>
        /// <returns>true for successfully saved</returns>
        public bool Update(RESID businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Update(businessObject);
        }

        /// <summary>
        /// get RESID by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public RESID GetByPrimaryKey(RESIDKeys keys)
        {
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all RESIDs
        /// </summary>
        /// <returns>list</returns>
        public List<RESID> GetAll()
        {
            return _dataObject.SelectAll(); 
        }

        /// <summary>
        /// get list of RESID by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public List<RESID> GetAllBy(RESID.RESIDFields fieldName, object value)
        {
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public bool Delete(RESIDKeys keys)
        {
            return _dataObject.Delete(keys); 
        }

        /// <summary>
        /// delete RESID by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public bool Delete(RESID.RESIDFields fieldName, object value)
        {
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
