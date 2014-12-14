using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Anbar.BusinessLayer.DataLayer
{
	/// <summary>
	/// Data access layer class for INCOMING
	/// </summary>
	class INCOMINGSql : DataLayerBase 
	{

        #region Constructor

		/// <summary>
		/// Class constructor
		/// </summary>
		public INCOMINGSql()
		{
			// Nothing for now.
		}

        #endregion

        #region Public Methods

        /// <summary>
        /// insert new row in the table
        /// </summary>
		/// <param name="businessObject">business object</param>
		/// <returns>true of successfully insert</returns>
		public bool Insert(INCOMING businessObject)
		{
			SqlCommand	sqlCommand = new SqlCommand();
			sqlCommand.CommandText = "dbo.[INCOMING_Insert]";
			sqlCommand.CommandType = CommandType.StoredProcedure;

			// Use connection object of base class
			sqlCommand.Connection = MainConnection;

			try
			{
                
				sqlCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ID));
				sqlCommand.Parameters.Add(new SqlParameter("@AMVALCODE", SqlDbType.NVarChar, 2147483647, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.AMVALCODE));
				sqlCommand.Parameters.Add(new SqlParameter("@OBJECTID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.OBJECTID));
				sqlCommand.Parameters.Add(new SqlParameter("@BRAND", SqlDbType.NVarChar, 2147483647, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.BRAND));
				sqlCommand.Parameters.Add(new SqlParameter("@SERIAL", SqlDbType.NVarChar, 2147483647, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.SERIAL));
				sqlCommand.Parameters.Add(new SqlParameter("@MODEL", SqlDbType.NVarChar, 2147483647, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.MODEL));
				sqlCommand.Parameters.Add(new SqlParameter("@DATETIME", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DATETIME));
				sqlCommand.Parameters.Add(new SqlParameter("@OWNER", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.OWNER));

								
				MainConnection.Open();
				
				sqlCommand.ExecuteNonQuery();
                businessObject.ID = (int)sqlCommand.Parameters["@ID"].Value;

				return true;
			}
			catch(Exception ex)
			{				
				throw new Exception("INCOMING::Insert::Error occured.", ex);
			}
			finally
			{			
				MainConnection.Close();
				sqlCommand.Dispose();
			}
		}

         /// <summary>
        /// update row in the table
        /// </summary>
        /// <param name="businessObject">business object</param>
        /// <returns>true for successfully updated</returns>
        public bool Update(INCOMING businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[INCOMING_Update]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                
				sqlCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ID));
				sqlCommand.Parameters.Add(new SqlParameter("@AMVALCODE", SqlDbType.NVarChar, 2147483647, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.AMVALCODE));
				sqlCommand.Parameters.Add(new SqlParameter("@OBJECTID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.OBJECTID));
				sqlCommand.Parameters.Add(new SqlParameter("@BRAND", SqlDbType.NVarChar, 2147483647, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.BRAND));
				sqlCommand.Parameters.Add(new SqlParameter("@SERIAL", SqlDbType.NVarChar, 2147483647, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.SERIAL));
				sqlCommand.Parameters.Add(new SqlParameter("@MODEL", SqlDbType.NVarChar, 2147483647, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.MODEL));
				sqlCommand.Parameters.Add(new SqlParameter("@DATETIME", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DATETIME));
				sqlCommand.Parameters.Add(new SqlParameter("@OWNER", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.OWNER));

                
                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("INCOMING::Update::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }

        /// <summary>
        /// Select by primary key
        /// </summary>
        /// <param name="keys">primary keys</param>
        /// <returns>INCOMING business object</returns>
        public INCOMING SelectByPrimaryKey(INCOMINGKeys keys)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[INCOMING_SelectByPrimaryKey]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

				sqlCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, keys.ID));

                
                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();

                if (dataReader.Read())
                {
                    INCOMING businessObject = new INCOMING();

                    PopulateBusinessObjectFromReader(businessObject, dataReader);

                    return businessObject;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("INCOMING::SelectByPrimaryKey::Error occured.", ex);
            }
            finally
            {             
                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }

        /// <summary>
        /// Select all rescords
        /// </summary>
        /// <returns>list of INCOMING</returns>
        public List<INCOMING> SelectAll()
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[INCOMING_SelectAll]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                
                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReader(dataReader);

            }
            catch (Exception ex)
            {                
                throw new Exception("INCOMING::SelectAll::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }

        /// <summary>
        /// Select records by field
        /// </summary>
        /// <param name="fieldName">name of field</param>
        /// <param name="value">value of field</param>
        /// <returns>list of INCOMING</returns>
        public List<INCOMING> SelectByField(string fieldName, object value)
        {

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[INCOMING_SelectByField]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

                sqlCommand.Parameters.Add(new SqlParameter("@FieldName", fieldName));
                sqlCommand.Parameters.Add(new SqlParameter("@Value", value));

                MainConnection.Open();
                
                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReader(dataReader);

            }
            catch (Exception ex)
            {
                throw new Exception("INCOMING::SelectByField::Error occured.", ex);
            }
            finally
            {

                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }
        public List<INCOMING> SelectByCondition(string Condition)
        {

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "SELECT * FROM [dbo].[INCOMING] "+Condition;
            sqlCommand.CommandType = CommandType.Text;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            //try
            //{

               // sqlCommand.Parameters.Add(new SqlParameter("@Condition", Condition));


                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReader(dataReader);

            //}
            //catch (Exception ex)
            //{
            //    throw new Exception("INCOMING::SelectByField::Error occured.", ex);
            //}
            //finally
            //{

                MainConnection.Close();
                sqlCommand.Dispose();
            //}

        }

        /// <summary>
        /// Delete by primary key
        /// </summary>
        /// <param name="keys">primary keys</param>
        /// <returns>true for successfully deleted</returns>
        public bool Delete(INCOMINGKeys keys)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[INCOMING_DeleteByPrimaryKey]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

				sqlCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, keys.ID));


                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("INCOMING::DeleteByKey::Error occured.", ex);
            }
            finally
            {                
                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }

        /// <summary>
        /// Delete records by field
        /// </summary>
        /// <param name="fieldName">name of field</param>
        /// <param name="value">value of field</param>
        /// <returns>true for successfully deleted</returns>
        public bool DeleteByField(string fieldName, object value)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[INCOMING_DeleteByField]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

                sqlCommand.Parameters.Add(new SqlParameter("@FieldName", fieldName));
                sqlCommand.Parameters.Add(new SqlParameter("@Value", value));
                
                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();

                return true;

            }
            catch (Exception ex)
            {                
                throw new Exception("INCOMING::DeleteByField::Error occured.", ex);
            }
            finally
            {             
                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Populate business object from data reader
        /// </summary>
        /// <param name="businessObject">business object</param>
        /// <param name="dataReader">data reader</param>
        internal void PopulateBusinessObjectFromReader(INCOMING businessObject, IDataReader dataReader)
        {


				businessObject.ID = dataReader.GetInt32(dataReader.GetOrdinal(INCOMING.INCOMINGFields.ID.ToString()));

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(INCOMING.INCOMINGFields.AMVALCODE.ToString())))
				{
					businessObject.AMVALCODE = dataReader.GetString(dataReader.GetOrdinal(INCOMING.INCOMINGFields.AMVALCODE.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(INCOMING.INCOMINGFields.OBJECTID.ToString())))
				{
					businessObject.OBJECTID = dataReader.GetInt32(dataReader.GetOrdinal(INCOMING.INCOMINGFields.OBJECTID.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(INCOMING.INCOMINGFields.BRAND.ToString())))
				{
					businessObject.BRAND = dataReader.GetString(dataReader.GetOrdinal(INCOMING.INCOMINGFields.BRAND.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(INCOMING.INCOMINGFields.SERIAL.ToString())))
				{
					businessObject.SERIAL = dataReader.GetString(dataReader.GetOrdinal(INCOMING.INCOMINGFields.SERIAL.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(INCOMING.INCOMINGFields.MODEL.ToString())))
				{
					businessObject.MODEL = dataReader.GetString(dataReader.GetOrdinal(INCOMING.INCOMINGFields.MODEL.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(INCOMING.INCOMINGFields.DATETIME.ToString())))
				{
					businessObject.DATETIME = dataReader.GetDateTime(dataReader.GetOrdinal(INCOMING.INCOMINGFields.DATETIME.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(INCOMING.INCOMINGFields.OWNER.ToString())))
				{
					businessObject.OWNER = dataReader.GetInt32(dataReader.GetOrdinal(INCOMING.INCOMINGFields.OWNER.ToString()));
				}


        }

        /// <summary>
        /// Populate business objects from the data reader
        /// </summary>
        /// <param name="dataReader">data reader</param>
        /// <returns>list of INCOMING</returns>
        internal List<INCOMING> PopulateObjectsFromReader(IDataReader dataReader)
        {

            List<INCOMING> list = new List<INCOMING>();

            while (dataReader.Read())
            {
                INCOMING businessObject = new INCOMING();
                PopulateBusinessObjectFromReader(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;

        }

        #endregion

	}
}
