using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;
namespace metronic.DAL
{
    public class LOC_DAL : LOC_DALBase
    {
        #region dbo.PR_LOC_Country_SelectByCountryNameCode
        public DataTable dbo_PR_LOC_Country_SelectByCountryNameCode(string conn, int? CountryCode, string? CountryName)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(conn);
                DbCommand dbCmd = sqlDb.GetStoredProcCommand("dbo.PR_LOC_Country_SelectByCountryNameCode");
                sqlDb.AddInParameter(dbCmd, "CountryCode", SqlDbType.Int, CountryCode);
                sqlDb.AddInParameter(dbCmd, "CountryName", SqlDbType.NVarChar, CountryName);

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
        #region dbo.PR_LOC_State_SelectByStateNameCode
        public DataTable dbo_PR_LOC_State_SelectByStateNameCode(string conn, string? CountryName, string? StateName, string? StateCode)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(conn);
                DbCommand dbCmd = sqlDb.GetStoredProcCommand("dbo.PR_LOC_State_SelectByStateNameCode");
                sqlDb.AddInParameter(dbCmd, "CountryName", SqlDbType.NVarChar, CountryName);
                sqlDb.AddInParameter(dbCmd, "StateName", SqlDbType.NVarChar, StateName);
                sqlDb.AddInParameter(dbCmd, "StateCode", SqlDbType.NVarChar, StateCode);

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
        #region dbo.PR_LOC_City_SelectByCityNameCode
        public DataTable dbo_PR_LOC_City_SelectByCityNameCode(string conn, string? CountryName, string? StateName, string? CityName, int? CityCode)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(conn);
                DbCommand dbCmd = sqlDb.GetStoredProcCommand("dbo.PR_LOC_City_SelectByCityNameCode");
                sqlDb.AddInParameter(dbCmd, "CountryName", SqlDbType.NVarChar, CountryName);
                sqlDb.AddInParameter(dbCmd, "StateName", SqlDbType.NVarChar, StateName);
                sqlDb.AddInParameter(dbCmd, "CityName", SqlDbType.NVarChar, CityName);
                sqlDb.AddInParameter(dbCmd, "CityCode", SqlDbType.Int, CityCode);

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
        #region dbo.PR_LOC_Country_SelectForDropDown
        public DataTable dbo_PR_LOC_Country_SelectForDropDown(string conn)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(conn);
                DbCommand dbCmd = sqlDb.GetStoredProcCommand("dbo.PR_LOC_Country_SelectForDropDown");

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
        #region dbo.PR_LOC_State_SelectForDropDown
        public DataTable dbo_PR_LOC_State_SelectForDropDown(string conn)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(conn);
                DbCommand dbCmd = sqlDb.GetStoredProcCommand("dbo.PR_LOC_State_SelectForDropDown");

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
        #region dbo.PR_LOC_City_SelectForDropDown
        public DataTable dbo_PR_LOC_City_SelectForDropDown(string conn)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(conn);
                DbCommand dbCmd = sqlDb.GetStoredProcCommand("dbo.PR_LOC_City_SelectForDropDown");

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
        #region dbo.PR_LOC_State_SelectDropDownByCountryID
        public DataTable dbo_PR_LOC_State_SelectDropDownByCountryID(string conn, int? CountryID)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(conn);
                DbCommand dbCmd = sqlDb.GetStoredProcCommand("dbo.PR_LOC_State_SelectDropDownByCountryID");
                sqlDb.AddInParameter(dbCmd, "CountryID", SqlDbType.Int, CountryID);

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
        #region dbo.PR_LOC_City_SelectDropDownByStateID
        public DataTable dbo_PR_LOC_City_SelectDropDownByStateID(string conn, int StateID)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(conn);
                DbCommand dbCmd = sqlDb.GetStoredProcCommand("dbo.PR_LOC_City_SelectDropDownByStateID");
                sqlDb.AddInParameter(dbCmd, "StateID", SqlDbType.Int, StateID);

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
        #region dbo.PR_LOC_ContactCategory_SelectForDropDown
        public DataTable dbo_PR_LOC_ContactCategory_SelectForDropDown(string conn)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(conn);
                DbCommand dbCmd = sqlDb.GetStoredProcCommand("dbo.PR_LOC_ContactCategory_SelectForDropDown");

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
    }
}
