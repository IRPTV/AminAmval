using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Anbar.BusinessLayer.DataLayer;

namespace Anbar.BusinessLayer
{
    public class CHANNELSFactory
    {

        #region data Members

        CHANNELSSql _dataObject = null;

        #endregion

        #region Constructor

        public CHANNELSFactory()
        {
            _dataObject = new CHANNELSSql();
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Insert new CHANNELS
        /// </summary>
        /// <param name="businessObject">CHANNELS object</param>
        /// <returns>true for successfully saved</returns>
        public bool Insert(CHANNELS businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Insert(businessObject);

        }

        /// <summary>
        /// Update existing CHANNELS
        /// </summary>
        /// <param name="businessObject">CHANNELS object</param>
        /// <returns>true for successfully saved</returns>
        public bool Update(CHANNELS businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Update(businessObject);
        }

        /// <summary>
        /// get CHANNELS by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public CHANNELS GetByPrimaryKey(CHANNELSKeys keys)
        {
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all CHANNELSs
        /// </summary>
        /// <returns>list</returns>
        public List<CHANNELS> GetAll()
        {
            return _dataObject.SelectAll(); 
        }

        /// <summary>
        /// get list of CHANNELS by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public List<CHANNELS> GetAllBy(CHANNELS.CHANNELSFields fieldName, object value)
        {
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public bool Delete(CHANNELSKeys keys)
        {
            return _dataObject.Delete(keys); 
        }

        /// <summary>
        /// delete CHANNELS by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public bool Delete(CHANNELS.CHANNELSFields fieldName, object value)
        {
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
