using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;

namespace metronic.DAL
{
    public class CON_DAL : CON_DALBase
    {
        #region dbo.PR_Contact_SelectByContactNameMobile
        public DataTable dbo_PR_Contact_SelectByContactNameMobile(string conn, string? CountryName, string? StateName, string? CityName, string? Category, string? ContactName, string? ContactMobile)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(conn);
                DbCommand dbCmd = sqlDb.GetStoredProcCommand("dbo.PR_Contact_SelectByContactNameMobile");
                sqlDb.AddInParameter(dbCmd, "CountryName", SqlDbType.NVarChar, CountryName);
                sqlDb.AddInParameter(dbCmd, "StateName", SqlDbType.NVarChar, StateName);
                sqlDb.AddInParameter(dbCmd, "CityName", SqlDbType.NVarChar, CityName);
                sqlDb.AddInParameter(dbCmd, "Category", SqlDbType.NVarChar, Category);
                sqlDb.AddInParameter(dbCmd, "ContactName", SqlDbType.NVarChar, ContactName);
                sqlDb.AddInParameter(dbCmd, "ContactMobile", SqlDbType.NVarChar, ContactMobile);

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
