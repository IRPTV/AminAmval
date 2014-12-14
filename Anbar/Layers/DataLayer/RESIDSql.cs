using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Anbar.BusinessLayer.DataLayer
{
	/// <summary>
	/// Data access layer class for RESID
	/// </summary>
	class RESIDSql : DataLayerBase 
	{

        #region Constructor

		/// <summary>
		/// Class constructor
		/// </summary>
		public RESIDSql()
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
		public int Insert(RESID businessObject)
		{
			SqlCommand	sqlCommand = new SqlCommand();
			sqlCommand.CommandText = "dbo.[RESID_Insert]";
			sqlCommand.CommandType = CommandType.StoredProcedure;

			// Use connection object of base class
			sqlCommand.Connection = MainConnection;

			try
			{
                
				sqlCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ID));
				sqlCommand.Parameters.Add(new SqlParameter("@KIND", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.KIND));
				sqlCommand.Parameters.Add(new SqlParameter("@RESIDCODE", SqlDbType.NVarChar, 2147483647, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.RESIDCODE));
				sqlCommand.Parameters.Add(new SqlParameter("@EMPLOYEEID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.EMPLOYEEID));
				sqlCommand.Parameters.Add(new SqlParameter("@CHANNEL", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.CHANNEL));
				sqlCommand.Parameters.Add(new SqlParameter("@DEP", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DEP));
				sqlCommand.Parameters.Add(new SqlParameter("@REQNUMBER", SqlDbType.NVarChar, 2147483647, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.REQNUMBER));
				sqlCommand.Parameters.Add(new SqlParameter("@REQDATE", SqlDbType.NVarChar, 2147483647, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.REQDATE));
				sqlCommand.Parameters.Add(new SqlParameter("@BOSSID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.BOSSID));
				sqlCommand.Parameters.Add(new SqlParameter("@DATETIME", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DATETIME));
                sqlCommand.Parameters.Add(new SqlParameter("@ROOMNUMBER", SqlDbType.NVarChar, 2147483647, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ROOMNUMBER));

								
				MainConnection.Open();
				
				sqlCommand.ExecuteScalar();
                businessObject.ID = (int)sqlCommand.Parameters["@ID"].Value;

                return businessObject.ID;
			}
			catch(Exception ex)
			{				
				throw new Exception("RESID::Insert::Error occured.", ex);
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
        public bool Update(RESID businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[RESID_Update]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                
				sqlCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ID));
				sqlCommand.Parameters.Add(new SqlParameter("@KIND", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.KIND));
				sqlCommand.Parameters.Add(new SqlParameter("@RESIDCODE", SqlDbType.NVarChar, 2147483647, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.RESIDCODE));
				sqlCommand.Parameters.Add(new SqlParameter("@EMPLOYEEID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.EMPLOYEEID));
				sqlCommand.Parameters.Add(new SqlParameter("@CHANNEL", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.CHANNEL));
				sqlCommand.Parameters.Add(new SqlParameter("@DEP", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DEP));
				sqlCommand.Parameters.Add(new SqlParameter("@REQNUMBER", SqlDbType.NVarChar, 2147483647, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.REQNUMBER));
				sqlCommand.Parameters.Add(new SqlParameter("@REQDATE", SqlDbType.NVarChar, 2147483647, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.REQDATE));
				sqlCommand.Parameters.Add(new SqlParameter("@BOSSID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.BOSSID));
				sqlCommand.Parameters.Add(new SqlParameter("@DATETIME", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DATETIME));
                sqlCommand.Parameters.Add(new SqlParameter("@ROOMNUMBER", SqlDbType.NVarChar, 2147483647, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ROOMNUMBER));


                
                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("RESID::Update::Error occured.", ex);
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
        /// <returns>RESID business object</returns>
        public RESID SelectByPrimaryKey(RESIDKeys keys)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[RESID_SelectByPrimaryKey]";
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
                    RESID businessObject = new RESID();

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
                throw new Exception("RESID::SelectByPrimaryKey::Error occured.", ex);
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
        /// <returns>list of RESID</returns>
        public List<RESID> SelectAll()
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[RESID_SelectAll]";
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
                throw new Exception("RESID::SelectAll::Error occured.", ex);
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
        /// <returns>list of RESID</returns>
        public List<RESID> SelectByField(string fieldName, object value)
        {

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[RESID_SelectByField]";
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
                throw new Exception("RESID::SelectByField::Error occured.", ex);
            }
            finally
            {

                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }

        public List<RESID> SelectByCondition(string Condition)
        {

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "[dbo].[RESID_SelectByCondition]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {                
                sqlCommand.Parameters.Add(new SqlParameter("@Condition", Condition));

                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReader(dataReader);

            }
            catch (Exception ex)
            {
                throw new Exception("RESID::SelectByField::Error occured.", ex);
            }
            finally
            {

                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }

        /// <summary>
        /// Delete by primary key
        /// </summary>
        /// <param name="keys">primary keys</param>
        /// <returns>true for successfully deleted</returns>
        public bool Delete(RESIDKeys keys)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[RESID_DeleteByPrimaryKey]";
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
                throw new Exception("RESID::DeleteByKey::Error occured.", ex);
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
            sqlCommand.CommandText = "dbo.[RESID_DeleteByField]";
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
                throw new Exception("RESID::DeleteByField::Error occured.", ex);
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
        internal void PopulateBusinessObjectFromReader(RESID businessObject, IDataReader dataReader)
        {


				businessObject.ID = dataReader.GetInt32(dataReader.GetOrdinal(RESID.RESIDFields.ID.ToString()));

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(RESID.RESIDFields.KIND.ToString())))
				{
					businessObject.KIND = (byte?)dataReader.GetInt16(dataReader.GetOrdinal(RESID.RESIDFields.KIND.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(RESID.RESIDFields.RESIDCODE.ToString())))
				{
					businessObject.RESIDCODE = dataReader.GetString(dataReader.GetOrdinal(RESID.RESIDFields.RESIDCODE.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(RESID.RESIDFields.EMPLOYEEID.ToString())))
				{
					businessObject.EMPLOYEEID = dataReader.GetInt32(dataReader.GetOrdinal(RESID.RESIDFields.EMPLOYEEID.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(RESID.RESIDFields.CHANNEL.ToString())))
				{
					businessObject.CHANNEL = dataReader.GetInt32(dataReader.GetOrdinal(RESID.RESIDFields.CHANNEL.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(RESID.RESIDFields.DEP.ToString())))
				{
					businessObject.DEP = dataReader.GetInt32(dataReader.GetOrdinal(RESID.RESIDFields.DEP.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(RESID.RESIDFields.REQNUMBER.ToString())))
				{
					businessObject.REQNUMBER = dataReader.GetString(dataReader.GetOrdinal(RESID.RESIDFields.REQNUMBER.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(RESID.RESIDFields.REQDATE.ToString())))
				{
					businessObject.REQDATE = dataReader.GetString(dataReader.GetOrdinal(RESID.RESIDFields.REQDATE.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(RESID.RESIDFields.BOSSID.ToString())))
				{
					businessObject.BOSSID = dataReader.GetInt32(dataReader.GetOrdinal(RESID.RESIDFields.BOSSID.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(RESID.RESIDFields.DATETIME.ToString())))
				{
					businessObject.DATETIME = dataReader.GetDateTime(dataReader.GetOrdinal(RESID.RESIDFields.DATETIME.ToString()));
				}
                if (!dataReader.IsDBNull(dataReader.GetOrdinal(RESID.RESIDFields.ROOMNUMBER.ToString())))
                {
                    businessObject.ROOMNUMBER = dataReader.GetString(dataReader.GetOrdinal(RESID.RESIDFields.ROOMNUMBER.ToString()));
                }

        }

        /// <summary>
        /// Populate business objects from the data reader
        /// </summary>
        /// <param name="dataReader">data reader</param>
        /// <returns>list of RESID</returns>
        internal List<RESID> PopulateObjectsFromReader(IDataReader dataReader)
        {

            List<RESID> list = new List<RESID>();

            while (dataReader.Read())
            {
                RESID businessObject = new RESID();
                PopulateBusinessObjectFromReader(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;

        }

        #endregion

	}
}
