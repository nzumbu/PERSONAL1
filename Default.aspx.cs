using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Services;




public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


    }
    [WebMethod]


    public static List<string> GetAutoCompleteData(string tFullName)
    {
        List<string> result = new List<string>();
        using (SqlConnection con = new SqlConnection("Data Source=USER-TOSH;Integrated Security=true;Initial Catalog=ETHERBASEINANDA"))
        {
            using (SqlCommand cmd = new SqlCommand("select FullName from PerOrgs where FullName LIKE '%'+@FullName+'%'", con))
            {
                con.Open();
                cmd.Parameters.AddWithValue("@FullName", tFullName);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    result.Add(dr["FullName"].ToString());
                }
                return result;
            }
        }
    }
}