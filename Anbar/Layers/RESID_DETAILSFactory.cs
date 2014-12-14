using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Anbar.BusinessLayer.DataLayer;

namespace Anbar.BusinessLayer
{
    public class RESID_DETAILSFactory
    {

        #region data Members

        RESID_DETAILSSql _dataObject = null;

        #endregion

        #region Constructor

        public RESID_DETAILSFactory()
        {
            _dataObject = new RESID_DETAILSSql();
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Insert new RESID_DETAILS
        /// </summary>
        /// <param name="businessObject">RESID_DETAILS object</param>
        /// <returns>true for successfully saved</returns>
        public bool Insert(RESID_DETAILS businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Insert(businessObject);

        }

        /// <summary>
        /// Update existing RESID_DETAILS
        /// </summary>
        /// <param name="businessObject">RESID_DETAILS object</param>
        /// <returns>true for successfully saved</returns>
        public bool Update(RESID_DETAILS businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Update(businessObject);
        }

        /// <summary>
        /// get RESID_DETAILS by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public RESID_DETAILS GetByPrimaryKey(RESID_DETAILSKeys keys)
        {
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all RESID_DETAILSs
        /// </summary>
        /// <returns>list</returns>
        public List<RESID_DETAILS> GetAll()
        {
            return _dataObject.SelectAll(); 
        }

        /// <summary>
        /// get list of RESID_DETAILS by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public List<RESID_DETAILS> GetAllBy(RESID_DETAILS.RESID_DETAILSFields fieldName, object value)
        {
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public bool Delete(RESID_DETAILSKeys keys)
        {
            return _dataObject.Delete(keys); 
        }

        /// <summary>
        /// delete RESID_DETAILS by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public bool Delete(RESID_DETAILS.RESID_DETAILSFields fieldName, object value)
        {
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
