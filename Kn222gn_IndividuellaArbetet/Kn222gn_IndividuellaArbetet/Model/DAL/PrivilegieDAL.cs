using Kn222gn_IndividuellaArbetet.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Kn222gn_IndividuellaArbetet.DAL
{
    public class PrivilegieDAL:DALBase
    {
        public IEnumerable<Privilegie> GetPrivilegie()
        {

            using (var con = CreateConnection())
            {                
                try
                {
                var privilegie = new List<Privilegie>(100);
                var cmd = new SqlCommand("appSchema.readPrivilegie", con);

                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();


                    using (var reader = cmd.ExecuteReader())
                    {
                        
                        var PrivilegieIDIndex = reader.GetOrdinal("PrivilegieID");
                        var PrivilegieTypIndex = reader.GetOrdinal("PrivilegieTyp");
                        var biljettIDIndex = reader.GetOrdinal("BiljettID");

                        while (reader.Read())
                        {
                            privilegie.Add(new Privilegie
                            {
                                PrivilegieID = reader.GetInt32(PrivilegieIDIndex),
                                PrivilegieTyp = reader.GetString(PrivilegieTypIndex),
                                BiljettID = reader.GetInt32(biljettIDIndex)

                            });
                        }

                        privilegie.TrimExcess();
                        return privilegie;
                    }
                }
                catch
                {
                    throw new ApplicationException("Ett fel har uppståt!");
                }
            }
        }
        public Privilegie GetPrivilegieId(int privilegieId)  // hämtar kontakter! från servern
        {
            using (var con = CreateConnection())
            {
                try
                {
                    var cmd = new SqlCommand("appSchema.readPrivilegie", con);  // hämtar från tabellen från databasen!
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@PrivilegieID", SqlDbType.Int, 4).Value = privilegieId;

                    con.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        var PrivilegieIDIndex = reader.GetOrdinal("PrivilegieID");
                        var PrivilegieypIndex = reader.GetOrdinal("PrivilegieTyp");
                        var biljettIDIndex = reader.GetOrdinal("biljettID");

                        if (reader.Read())
                        {
                            return new Privilegie
                            {
                                PrivilegieID = reader.GetInt32(PrivilegieIDIndex),
                                PrivilegieTyp = reader.GetString(PrivilegieypIndex),
                                BiljettID = reader.GetInt32(biljettIDIndex)
                            };
                        }

                        return null;
                    }
                }
                catch
                {
                    throw new ApplicationException("Ett fel har uppståt med anslutningen mot databasen..");
                }
            }
        }
        //public IEnumerable<Biljett> GetBiljettsPageWise(int maximumRows, int startRowIndex, out int totalRowCount)
        //{
        //    using (var con = CreateConnection())
        //    {
        //        try
        //        {
        //            var biljett = new List<Biljett>(100);
        //            var cmd = new SqlCommand("Person.uspGetContactsPageWise", con);
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            cmd.Parameters.Add("@PageIndex", SqlDbType.Int, 4).Value = startRowIndex / maximumRows + 1;
        //            cmd.Parameters.Add("@PageSize", SqlDbType.Int, 4).Value = maximumRows;
        //            cmd.Parameters.Add("@RecordCount", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

        //            con.Open();

        //            using (var reader = cmd.ExecuteReader())
        //            {
        //                var biljettIDIndex = reader.GetOrdinal("BesökarID");
        //                var PrisIndex = reader.GetOrdinal("Förnamn");
        //                var AntalIndex = reader.GetOrdinal("Efternamn");
        //                var RabattIndex = reader.GetOrdinal("TelefonNR");
        //                var BiljettTypIndex = reader.GetOrdinal("Köp");
        //                var BesokarIDIndex = reader.GetOrdinal("Bokning");

        //                while (reader.Read())
        //                {
        //                    biljett.Add(new Biljett
        //                    {
        //                        BiljettID = reader.GetInt32(biljettIDIndex),
        //                        Pris = reader.GetInt32(PrisIndex),
        //                        Antal = reader.GetInt32(AntalIndex),
        //                        Rabatt = reader.GetInt32(RabattIndex),
        //                        BiljettTyp = reader.GetString(BiljettTypIndex),
        //                        BesokarID = reader.GetInt32(BesokarIDIndex)
        //                    });
        //                }
        //            }

        //            totalRowCount = (int)cmd.Parameters["@RecordCount"].Value;
        //            biljett.TrimExcess();
        //            return biljett;
        //        }
        //        catch
        //        {
        //            throw new ApplicationException("An error occured during the connection with the database.");
        //        }
        //    }
        //}
        public void InsertPrivilegie(Privilegie privilegie)  //lägger in den nya kontakten!
        {
            using (var con = CreateConnection())
            {
                try
                {
                    var cmd = new SqlCommand("appSchema.createPrivilegie", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@PrivilegieTyp", SqlDbType.NVarChar, 30).Value = privilegie.PrivilegieTyp;
                    cmd.Parameters.Add("@BiljettID", SqlDbType.Int, 10).Value = privilegie.BiljettID;

                    cmd.Parameters.Add("@PrivilegieID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;  // vet inte om denna är rätt!

                    con.Open();
                    cmd.ExecuteNonQuery();

                    privilegie.BiljettID = (int)cmd.Parameters["@PrivilegieID"].Value;
                }
                catch
                {
                    throw new ApplicationException("Ett fel har uppståt med anslutningen mot databasen...");
                }
            }
        }
        public void UpdatePrivilegie(Privilegie privilegie)//uppdaterar kontakten med de nya vrdena!
        {
            using (var con = CreateConnection())
            {
                try
                {
                    var cmd = new SqlCommand("appSchema.UpdatePrivilegieNEW", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PrivilegieID", SqlDbType.Int, 4).Value = privilegie.PrivilegieID;
                    cmd.Parameters.Add("@PrivilegieTyp", SqlDbType.NVarChar, 30).Value = privilegie.PrivilegieTyp;
                    cmd.Parameters.Add("@BiljettID", SqlDbType.Int, 10).Value = privilegie.BiljettID;

                    con.Open();
                    cmd.ExecuteNonQuery();

                }
                catch
                {
                    throw new ApplicationException("Ett fel har uppståt med anslutningen mot databasen.....");
                }
            }
        }

        public Privilegie GetSpecifikPrivilegie(int PrivilegieID)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    var cmd = new SqlCommand("AppSchema.GetSpecifikPrivilegie", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PrivilegieID", SqlDbType.Int, 4).Value = PrivilegieID;
                   // cmd.Parameters.Add("@PrivilegieID", SqlDbType.Int, 4).Value = PrivilegieID;

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var PrivilegieIDIndex = reader.GetOrdinal("PrivilegieID");
                            var PrivilegieTypIndex = reader.GetOrdinal("PrivilegieTyp");
                            var BiljettIDIndex = reader.GetOrdinal("BiljettID");

                            return new Privilegie
                            {
                                PrivilegieID = reader.GetInt32(PrivilegieIDIndex),
                                PrivilegieTyp = reader.GetString(PrivilegieTypIndex),
                                BiljettID = reader.GetInt32(BiljettIDIndex),
                            };
                        }
                    }
                    return null;
                }
                catch
                {
                    throw new ApplicationException("Något gick Fel i dataåtkomstlagret");
                }
            }
        }
        public void DeletePrivilegie(int privilegieId)  // denna ska ta bort kontakten!
        {
            using (var con = CreateConnection())// skapar en anslutning
            {
                try// testear här 
                {
                    var cmd = new SqlCommand("appSchema.DeletePrivilegie", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@PrivilegieID", SqlDbType.Int, 4).Value = privilegieId;

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                catch //fångar här!
                {
                    throw new ApplicationException("Ett fel har uppståt med anslutningen mot databasen.......");
                }
            }
        }
    }
}