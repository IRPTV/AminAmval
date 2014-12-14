using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Anbar.BusinessLayer.DataLayer;

namespace Anbar.BusinessLayer
{
    public class OBJECTSFactory
    {

        #region data Members

        OBJECTSSql _dataObject = null;

        #endregion

        #region Constructor

        public OBJECTSFactory()
        {
            _dataObject = new OBJECTSSql();
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Insert new OBJECTS
        /// </summary>
        /// <param name="businessObject">OBJECTS object</param>
        /// <returns>true for successfully saved</returns>
        public bool Insert(OBJECTS businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Insert(businessObject);

        }

        /// <summary>
        /// Update existing OBJECTS
        /// </summary>
        /// <param name="businessObject">OBJECTS object</param>
        /// <returns>true for successfully saved</returns>
        public bool Update(OBJECTS businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Update(businessObject);
        }

        /// <summary>
        /// get OBJECTS by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public OBJECTS GetByPrimaryKey(OBJECTSKeys keys)
        {
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all OBJECTSs
        /// </summary>
        /// <returns>list</returns>
        public List<OBJECTS> GetAll()
        {
            return _dataObject.SelectAll(); 
        }

        /// <summary>
        /// get list of OBJECTS by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public List<OBJECTS> GetAllBy(OBJECTS.OBJECTSFields fieldName, object value)
        {
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public bool Delete(OBJECTSKeys keys)
        {
            return _dataObject.Delete(keys); 
        }

        /// <summary>
        /// delete OBJECTS by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public bool Delete(OBJECTS.OBJECTSFields fieldName, object value)
        {
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
