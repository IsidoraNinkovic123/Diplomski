using Common.Database;
using Common.Interfaces.Providers;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DAL.Providers
{
    public class DnevniIzvestajProvider : IDnevniIzvestajProvider
    {
        public string NajprodavanijeJelo(DateTime d)
        {
            string rezultat = "";
            using (SqlConnection sqlConnection1 = new SqlConnection("data source=.\\SQLEXPRESS;initial catalog=DIPLOMSKI;integrated security=True; MultipleActiveResultSets=True;"))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    Int32 rowsAffected;

                    cmd.CommandText = "NajprodavanijeJelo";
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter nazNajprodavanijeg;
                    SqlParameter kolNajprodavanijeg;
                    SqlParameter datum;

                    datum = new SqlParameter("@datum", SqlDbType.DateTime);
                    datum.SqlValue = d;
                    cmd.Parameters.Add(datum);

                    nazNajprodavanijeg = new SqlParameter("@nazNajprodavanijeg", SqlDbType.VarChar, 100);
                    nazNajprodavanijeg.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(nazNajprodavanijeg);

                    kolNajprodavanijeg = new SqlParameter("@kolNajprodavanijeg", SqlDbType.Int);
                    kolNajprodavanijeg.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(kolNajprodavanijeg);

                    cmd.Connection = sqlConnection1;

                    sqlConnection1.Open();

                    rowsAffected = cmd.ExecuteNonQuery();
                    rezultat = String.Format("Najprodavanije jelo: {0}.Ukupno je prodato {1} komada jela {0} navedenog dana.", cmd.Parameters["@nazNajprodavanijeg"].Value, cmd.Parameters["@kolNajprodavanijeg"].Value.ToString());
                }

                sqlConnection1.Close();
            }

            return rezultat;
        }


        public string Promet(DateTime d)
        {
            string rezultat = "";
            using (SqlConnection sqlConnection1 = new SqlConnection("data source=.\\SQLEXPRESS;initial catalog=DIPLOMSKI;integrated security=True; MultipleActiveResultSets=True;"))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    Int32 rowsAffected;

                    cmd.CommandText = "Promet";
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter promet;
                    SqlParameter datum;

                    datum = new SqlParameter("@datum", SqlDbType.DateTime);
                    datum.SqlValue = d;
                    cmd.Parameters.Add(datum);

                    promet = new SqlParameter("@promet", SqlDbType.Decimal);
                    promet.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(promet);

                    cmd.Connection = sqlConnection1;

                    sqlConnection1.Open();

                    rowsAffected = cmd.ExecuteNonQuery();
                    rezultat = String.Format("Dnevni promet: {0} RSD.", cmd.Parameters["@promet"].Value.ToString());
                }

                sqlConnection1.Close();
            }

            return rezultat;
        }

        public string BrojPorudzbina(DateTime d)
        {
            string rezultat = "";
            using (var db = new Entities())
            {
                string komanda = string.Format("select [dbo].[BrojPorudzbina]('{0}-{1}-{2}')", d.Year, d.Month, d.Day);
                rezultat = String.Format("Ukupan broj izdatih porudžbina: {0}.", db.Database.SqlQuery<int>(komanda).ToList()[0].ToString());
            }

            return rezultat;
        }
    }
}
