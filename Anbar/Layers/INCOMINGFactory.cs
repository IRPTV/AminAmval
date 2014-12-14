using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Anbar.BusinessLayer.DataLayer;

namespace Anbar.BusinessLayer
{
    public class INCOMINGFactory
    {

        #region data Members

        INCOMINGSql _dataObject = null;

        #endregion

        #region Constructor

        public INCOMINGFactory()
        {
            _dataObject = new INCOMINGSql();
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Insert new INCOMING
        /// </summary>
        /// <param name="businessObject">INCOMING object</param>
        /// <returns>true for successfully saved</returns>
        public bool Insert(INCOMING businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Insert(businessObject);

        }

        /// <summary>
        /// Update existing INCOMING
        /// </summary>
        /// <param name="businessObject">INCOMING object</param>
        /// <returns>true for successfully saved</returns>
        public bool Update(INCOMING businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Update(businessObject);
        }

        /// <summary>
        /// get INCOMING by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public INCOMING GetByPrimaryKey(INCOMINGKeys keys)
        {
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all INCOMINGs
        /// </summary>
        /// <returns>list</returns>
        public List<INCOMING> GetAll()
        {
            return _dataObject.SelectAll(); 
        }

        /// <summary>
        /// get list of INCOMING by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public List<INCOMING> GetAllBy(INCOMING.INCOMINGFields fieldName, object value)
        {
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public bool Delete(INCOMINGKeys keys)
        {
            return _dataObject.Delete(keys); 
        }

        /// <summary>
        /// delete INCOMING by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public bool Delete(INCOMING.INCOMINGFields fieldName, object value)
        {
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
