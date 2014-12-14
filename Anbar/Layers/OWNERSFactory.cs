using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Anbar.BusinessLayer.DataLayer;

namespace Anbar.BusinessLayer
{
    public class OWNERSFactory
    {

        #region data Members

        OWNERSSql _dataObject = null;

        #endregion

        #region Constructor

        public OWNERSFactory()
        {
            _dataObject = new OWNERSSql();
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Insert new OWNERS
        /// </summary>
        /// <param name="businessObject">OWNERS object</param>
        /// <returns>true for successfully saved</returns>
        public bool Insert(OWNERS businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Insert(businessObject);

        }

        /// <summary>
        /// Update existing OWNERS
        /// </summary>
        /// <param name="businessObject">OWNERS object</param>
        /// <returns>true for successfully saved</returns>
        public bool Update(OWNERS businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Update(businessObject);
        }

        /// <summary>
        /// get OWNERS by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public OWNERS GetByPrimaryKey(OWNERSKeys keys)
        {
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all OWNERSs
        /// </summary>
        /// <returns>list</returns>
        public List<OWNERS> GetAll()
        {
            return _dataObject.SelectAll(); 
        }

        /// <summary>
        /// get list of OWNERS by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public List<OWNERS> GetAllBy(OWNERS.OWNERSFields fieldName, object value)
        {
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public bool Delete(OWNERSKeys keys)
        {
            return _dataObject.Delete(keys); 
        }

        /// <summary>
        /// delete OWNERS by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public bool Delete(OWNERS.OWNERSFields fieldName, object value)
        {
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
