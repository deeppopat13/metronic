using metronic.Areas.LOC_City.Models;
using metronic.Areas.LOC_ContactCategory.Models;
using metronic.Areas.LOC_Country.Models;
using metronic.Areas.LOC_State.Models;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

using System.Data;
using System.Data.Common;

namespace metronic.DAL
{
    public class LOC_DALBase
    {
        #region dbo.PR_LOC_State_SelectAll
        public DataTable dbo_PR_LOC_State_SelectAll(string conn)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(conn);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_LOC_State_SelectAll");
                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
        #region dbo.PR_LOC_Country_SelectAll
        public DataTable dbo_PR_LOC_Country_SelectAll(string conn)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(conn);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_LOC_Country_SelectAll");
                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
        #region dbo.PR_LOC_City_SelectAll
        public DataTable dbo_PR_LOC_City_SelectAll(string conn)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(conn);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_LOC_City_SelectAll");
                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
        #region dbo.PR_LOC_State_SelectByPK
        public DataTable dbo_PR_LOC_State_SelectByPK(string conn, int? StateID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(conn);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_LOC_State_SelectByPK");
                sqlDB.AddInParameter(dbCMD, "StateID", SqlDbType.Int, StateID);
                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
        #region dbo.PR_LOC_Country_SelectByPK
        public DataTable dbo_PR_LOC_Country_SelectByPK(string conn, int? CountryID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(conn);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_LOC_Country_SelectByPK");
                sqlDB.AddInParameter(dbCMD, "CountryID", SqlDbType.Int, CountryID);
                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
        #region dbo.PR_LOC_City_SelectByPK
        public DataTable dbo_PR_LOC_City_SelectByPK(string conn, int? CityID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(conn);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_LOC_City_SelectByPK");
                sqlDB.AddInParameter(dbCMD, "CityID", SqlDbType.Int, CityID);
                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
        #region dbo.PR_LOC_State_Insert
        public void dbo_PR_LOC_State_Insert(string conn, LOC_StateModel modelLOC_State)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(conn);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_LOC_State_Insert");
                sqlDB.AddInParameter(dbCMD, "CountryID", SqlDbType.Int, modelLOC_State.CountryID);
                sqlDB.AddInParameter(dbCMD, "StateName", SqlDbType.NVarChar, modelLOC_State.StateName);
                sqlDB.AddInParameter(dbCMD, "StateCode", SqlDbType.Int, modelLOC_State.StateCode);
                sqlDB.AddInParameter(dbCMD, "CreationDate", SqlDbType.Date, DBNull.Value);
                sqlDB.AddInParameter(dbCMD, "ModificationDate", SqlDbType.Date, DBNull.Value);

                sqlDB.ExecuteNonQuery(dbCMD);



            }
            catch (Exception ex)
            {
               
            }
        }
        #endregion
        #region dbo.PR_LOC_Country_Insert
        public void dbo_PR_LOC_Country_Insert(string conn, LOC_CountryModel modelLOC_Country)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(conn);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_LOC_Country_Insert");
                sqlDB.AddInParameter(dbCMD, "CountryName", SqlDbType.NVarChar, modelLOC_Country.CountryName);
                sqlDB.AddInParameter(dbCMD, "CountryCode", SqlDbType.Int, modelLOC_Country.CountryCode);
                sqlDB.AddInParameter(dbCMD, "CreationDate", SqlDbType.Date, DBNull.Value);
                sqlDB.AddInParameter(dbCMD, "ModificationDate", SqlDbType.Date, DBNull.Value);

                sqlDB.ExecuteNonQuery(dbCMD);



            }
            catch (Exception ex)
            {
                
            }
        }
        #endregion
        #region dbo.PR_LOC_City_Insert
        public void dbo_PR_LOC_City_Insert(string conn, LOC_CityModel modelLOC_City)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(conn);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_LOC_City_Insert");
                sqlDB.AddInParameter(dbCMD, "CountryID", SqlDbType.Int, modelLOC_City.CountryID);
                sqlDB.AddInParameter(dbCMD, "StateID", SqlDbType.Int, modelLOC_City.StateID);
                sqlDB.AddInParameter(dbCMD, "CityName", SqlDbType.NVarChar, modelLOC_City.CityName);
                sqlDB.AddInParameter(dbCMD, "CityCode", SqlDbType.Int, modelLOC_City.CityCode);
                sqlDB.AddInParameter(dbCMD, "CreationDate", SqlDbType.Date, DBNull.Value);
                sqlDB.AddInParameter(dbCMD, "ModificationDate", SqlDbType.Date, DBNull.Value);

                sqlDB.ExecuteNonQuery(dbCMD);




            }
            catch (Exception ex)
            {

            }
        }
        #endregion
        #region dbo.PR_LOC_Country_UpdateByPK
        public void dbo_PR_LOC_Country_UpdateByPK(string conn, LOC_CountryModel modelLOC_Country)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(conn);
                DbCommand dbCmd = sqlDb.GetStoredProcCommand("dbo.PR_LOC_Country_UpdateByPK");
                sqlDb.AddInParameter(dbCmd, "CountryID", SqlDbType.Int, modelLOC_Country.CountryID);
                sqlDb.AddInParameter(dbCmd, "CountryName", SqlDbType.NVarChar, modelLOC_Country.CountryName);
                sqlDb.AddInParameter(dbCmd, "CountryCode", SqlDbType.Int, modelLOC_Country.CountryCode);
                sqlDb.AddInParameter(dbCmd, "ModificationDate", SqlDbType.Date, DBNull.Value);

                sqlDb.ExecuteNonQuery(dbCmd);
            }
            catch (Exception ex) { }
        }
        #endregion
        #region dbo.PR_LOC_State_UpdateByPK
        public void dbo_PR_LOC_State_UpdateByPK(string conn, LOC_StateModel modelLOC_State)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(conn);
                DbCommand dbCmd = sqlDb.GetStoredProcCommand("dbo.PR_LOC_State_UpdateByPK");
                sqlDb.AddInParameter(dbCmd, "CountryID", SqlDbType.Int, modelLOC_State.CountryID);
                sqlDb.AddInParameter(dbCmd, "StateID", SqlDbType.Int, modelLOC_State.StateID);
                sqlDb.AddInParameter(dbCmd, "StateName", SqlDbType.NVarChar, modelLOC_State.StateName);
                sqlDb.AddInParameter(dbCmd, "StateCode", SqlDbType.Int, modelLOC_State.StateCode);
                sqlDb.AddInParameter(dbCmd, "ModificationDate", SqlDbType.Date, DBNull.Value);

                sqlDb.ExecuteNonQuery(dbCmd);
            }
            catch (Exception ex) { }
        }
        #endregion

        #region dbo.PR_LOC_City_UpdateByPK
        public void dbo_PR_LOC_City_UpdateByPK(string conn, LOC_CityModel modelLOC_City)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(conn);
                DbCommand dbCmd = sqlDb.GetStoredProcCommand("dbo.PR_LOC_City_UpdateByPK");
                sqlDb.AddInParameter(dbCmd, "CountryID", SqlDbType.Int, modelLOC_City.CountryID);
                sqlDb.AddInParameter(dbCmd, "StateID", SqlDbType.Int, modelLOC_City.StateID);
                sqlDb.AddInParameter(dbCmd, "CityID", SqlDbType.Int, modelLOC_City.CityID);
                sqlDb.AddInParameter(dbCmd, "CityName", SqlDbType.NVarChar, modelLOC_City.CityName);
                sqlDb.AddInParameter(dbCmd, "CityCode", SqlDbType.Int, modelLOC_City.CityCode);
                sqlDb.AddInParameter(dbCmd, "ModificationDate", SqlDbType.Date, DBNull.Value);

                sqlDb.ExecuteNonQuery(dbCmd);
            }
            catch (Exception ex) { }

        }
        #endregion
        #region dbo.PR_LOC_Country_DeleteByPK
        public void dbo_PR_LOC_Country_DeleteByPK(string conn, int CountryID)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(conn);
                DbCommand dbCmd = sqlDb.GetStoredProcCommand("dbo.PR_LOC_Country_DeleteByPK");
                sqlDb.AddInParameter(dbCmd, "CountryID", SqlDbType.Int, CountryID);
                sqlDb.ExecuteNonQuery(dbCmd);
            }
            catch (Exception ex)
            {
            }
        }
        #endregion
        #region dbo.PR_LOC_State_DeleteByPK
        public void dbo_PR_LOC_State_DeleteByPK(string conn, int StateID)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(conn);
                DbCommand dbCmd = sqlDb.GetStoredProcCommand("dbo.PR_LOC_State_DeleteByPK");
                sqlDb.AddInParameter(dbCmd, "StateID", SqlDbType.Int, StateID);
                sqlDb.ExecuteNonQuery(dbCmd);
            }
            catch (Exception ex) { }
        }
        #endregion

        #region dbo.PR_LOC_City_DeleteByPK
        public void dbo_PR_LOC_City_DeleteByPK(String conn, int CityID)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(conn);
                DbCommand dbCmd = sqlDb.GetStoredProcCommand("dbo.PR_LOC_City_DeleteByPK");
                sqlDb.AddInParameter(dbCmd, "CityID", SqlDbType.Int, CityID);
                sqlDb.ExecuteNonQuery(dbCmd);
            }
            catch (Exception ex) { }
        }
        #endregion
        #region dbo.PR_ContactCategory_SelectAll
        public DataTable dbo_PR_LOC_ContactCategory_SelectAll(string conn)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(conn);
                DbCommand dbCmd = sqlDb.GetStoredProcCommand("dbo.PR_LOC_ContactCategory_SelectAll");

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDb.ExecuteReader(dbCmd))
                {
                    dt.Load(dr);
                }

                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
        #region dbo.PR_LOC_ContactCategory_SelectByPK
        public DataTable dbo_PR_LOC_ContactCategory_SelectByPK(string conn, int? CategoryID)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(conn);
                DbCommand dbCmd = sqlDb.GetStoredProcCommand("dbo.PR_LOC_ContactCategory_SelectByPK");
                sqlDb.AddInParameter(dbCmd, "CategoryID", SqlDbType.Int, CategoryID);

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDb.ExecuteReader(dbCmd))
                {
                    dt.Load(dr);
                }

                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
        #region dbo.PR_LOC_ContactCategory_Insert
        public void dbo_PR_LOC_ContactCategory_Insert(string conn, LOC_ContactCategoryModel modelLOC_ContactCategory)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(conn);
                DbCommand dbCmd = sqlDb.GetStoredProcCommand("dbo.PR_LOC_ContactCategory_Insert");
                sqlDb.AddInParameter(dbCmd, "Category", SqlDbType.NVarChar, modelLOC_ContactCategory.Category);
                sqlDb.AddInParameter(dbCmd, "CreationDate", SqlDbType.Date, DBNull.Value);
                sqlDb.AddInParameter(dbCmd, "ModificationDate", SqlDbType.Date, DBNull.Value);

                sqlDb.ExecuteNonQuery(dbCmd);
            }
            catch (Exception ex) { }
        }
        #endregion
        #region dbo.PR_LOC_ContactCategory_UpdateByPK
        public void dbo_PR_LOC_ContactCategory_UpdateByPK(string conn, LOC_ContactCategoryModel modelLOC_ContactCategory)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(conn);
                DbCommand dbCmd = sqlDb.GetStoredProcCommand("dbo.PR_LOC_ContactCategory_UpdateByPK");
                sqlDb.AddInParameter(dbCmd, "CategoryID", SqlDbType.Int, modelLOC_ContactCategory.CategoryID);
                sqlDb.AddInParameter(dbCmd, "Category", SqlDbType.NVarChar, modelLOC_ContactCategory.Category);
                sqlDb.AddInParameter(dbCmd, "ModificationDate", SqlDbType.Date, DBNull.Value);

                sqlDb.ExecuteNonQuery(dbCmd);
            }
            catch (Exception ex) { }
        }
        #endregion
        #region dbo.PR_LOC_ContactCategory_DeleteByPK
        public void dbo_PR_LOC_ContactCategory_DeleteByPK(string conn, int CategoryID)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(conn);
                DbCommand dbCmd = sqlDb.GetStoredProcCommand("dbo.PR_LOC_ContactCategory_DeleteByPK");
                sqlDb.AddInParameter(dbCmd, "CategoryID", SqlDbType.Int, CategoryID);
                sqlDb.ExecuteNonQuery(dbCmd);
            }
            catch (Exception ex) { }
        }
        #endregion
    }
}
