using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Anbar.BusinessLayer.DataLayer;

namespace Anbar.BusinessLayer
{
    public class DEPSFactory
    {

        #region data Members

        DEPSSql _dataObject = null;

        #endregion

        #region Constructor

        public DEPSFactory()
        {
            _dataObject = new DEPSSql();
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Insert new DEPS
        /// </summary>
        /// <param name="businessObject">DEPS object</param>
        /// <returns>true for successfully saved</returns>
        public bool Insert(DEPS businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Insert(businessObject);

        }

        /// <summary>
        /// Update existing DEPS
        /// </summary>
        /// <param name="businessObject">DEPS object</param>
        /// <returns>true for successfully saved</returns>
        public bool Update(DEPS businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Update(businessObject);
        }

        /// <summary>
        /// get DEPS by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public DEPS GetByPrimaryKey(DEPSKeys keys)
        {
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all DEPSs
        /// </summary>
        /// <returns>list</returns>
        public List<DEPS> GetAll()
        {
            return _dataObject.SelectAll(); 
        }

        /// <summary>
        /// get list of DEPS by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public List<DEPS> GetAllBy(DEPS.DEPSFields fieldName, object value)
        {
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public bool Delete(DEPSKeys keys)
        {
            return _dataObject.Delete(keys); 
        }

        /// <summary>
        /// delete DEPS by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public bool Delete(DEPS.DEPSFields fieldName, object value)
        {
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
