using System;
using System.Data.SqlClient;
using DevZa.Configuration;

namespace DevZa.Utilities
{
    public class SequenceHelper
    {
        private static string _connnectionstring = ZaConfigurationManager.ConnectionStrings.ConnectionStrings[ZaConfigurationManager.ZaAppConfig.DbConnection.ConnectionName].ConnectionString;

        public static int GetNextValByName(string seqName)
        {
            SequenceHelper sql = new SequenceHelper();
            return sql.GetNextIntIdFromSequenceByName(seqName);
        }

        public static int GetCurrValByName(string seqName)
        {
            SequenceHelper sql = new SequenceHelper();
            return sql.GetCurrentSeqValue(seqName);
        }

        public int GetCurrentSeqValue(string seqName)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(_connnectionstring))
                {
                    sqlConnection.Open();
                    SqlCommand sqlCmd = new SqlCommand("select Currval FROM [dbo].[AllSequences] where seqName='" + seqName + "'", sqlConnection);
                    object obj = sqlCmd.ExecuteScalar();
                    sqlConnection.Close();
                    return (int)obj;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int GetNextIntIdFromSequenceByName(string seqName)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(_connnectionstring))
                {
                    sqlConnection.Open();
                    SqlCommand sqlCmd = new SqlCommand("usp_GetNewSeqVal", sqlConnection);

                    SqlParameter inParm = new SqlParameter("@seqname", System.Data.SqlDbType.NVarChar);
                    inParm.Direction = System.Data.ParameterDirection.Input;
                    inParm.Value = seqName;

                    SqlParameter outParm = new SqlParameter("@NewSeqVal", System.Data.SqlDbType.Int);
                    outParm.Direction = System.Data.ParameterDirection.Output;

                    sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCmd.Parameters.Add(inParm);
                    sqlCmd.Parameters.Add(outParm);

                    sqlCmd.ExecuteNonQuery();
                    sqlConnection.Close();
                    return (int)outParm.Value;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
