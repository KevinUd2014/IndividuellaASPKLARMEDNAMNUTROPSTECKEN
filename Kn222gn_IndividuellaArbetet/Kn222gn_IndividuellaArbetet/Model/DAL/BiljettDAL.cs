using Kn222gn_IndividuellaArbetet.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Kn222gn_IndividuellaArbetet.DAL
{
    public class BiljettDAL : DALBase
    {
        public IEnumerable<Biljett> GetBiljett()
        {

            using (SqlConnection conn = CreateConnection())
            {
            //    try
               // {
                    var biljett = new List<Biljett>(100);

                    SqlCommand cmd = new SqlCommand("appSchema.readBiljett", conn);  // denna är viktig att den är rätt!
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var biljettIDIndex = reader.GetOrdinal("BiljettID");
                            var PrisIndex = reader.GetOrdinal("Pris");
                            var AntalIndex = reader.GetOrdinal("Antal");
                            var RabattIndex = reader.GetOrdinal("Rabatt");
                            var BiljettTypIndex = reader.GetOrdinal("BiljettTyp");
                            var BesokarIDIndex = reader.GetOrdinal("BesökarID");

                            Besokare besokare = Model.Service.GetBesokare(reader.GetInt32(BesokarIDIndex));

                            biljett.Add(new Biljett
                            {
                                BiljettID = reader.GetInt32(biljettIDIndex),
                                Pris = reader.GetInt32(PrisIndex),
                                Antal = reader.GetInt32(AntalIndex),
                                Rabatt = reader.GetDecimal(RabattIndex),
                                BiljettTyp = reader.GetString(BiljettTypIndex),
                                BesokarID = reader.GetInt32(BesokarIDIndex),
                                Besokare = besokare

                            });
                        }

                        biljett.TrimExcess();
                        return biljett;
                    }
               // }
               /* catch
                {
                    throw new ApplicationException("Ett fel har uppståt med anslutningen mot databasen.-");
                }*/
            }
        }
        
        public Biljett GetBiljettById(int biljettId)  // hämtar kontakter! från servern
        {
            using (SqlConnection con = CreateConnection())
            {
                //try
               // {
                SqlCommand cmd = new SqlCommand("appSchema.GetSpecifikBiljett", con);  // denna är viktig att den är rätt!
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@BiljettID", SqlDbType.Int, 4).Value = biljettId;

                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        var biljettIDIndex = reader.GetOrdinal("BiljettID");
                        var PrisIndex = reader.GetOrdinal("Pris");
                        var AntalIndex = reader.GetOrdinal("Antal");
                        var RabattIndex = reader.GetOrdinal("Rabatt");
                        var BiljettTypIndex = reader.GetOrdinal("BiljettTyp");
                        var BesokarIDIndex = reader.GetOrdinal("BesökarID");

                        if (reader.Read())
                        {
                            Besokare besokare = Model.Service.GetBesokare(BesokarIDIndex);
                            return new Biljett
                            {
                                BiljettID = reader.GetInt32(biljettIDIndex),
                                Pris = reader.GetInt32(PrisIndex),
                                Antal = reader.GetInt32(AntalIndex),
                                Rabatt = reader.GetDecimal(RabattIndex),
                                BiljettTyp = reader.GetString(BiljettTypIndex),
                                BesokarID = reader.GetInt32(BesokarIDIndex),
                                Besokare = besokare
                            };
                        }

                        return null;
                    }
               // }
                //catch
               // {
                   // throw new ApplicationException("Ett fel har uppståt med anslutningen mot databasen._");
               // }
            }
        }


        public void CreateBiljett(Biljett biljett)  //lägger in den nya kontakten!
        {
            using (var con = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.createBiljett", con);  // denna är viktig att den är rätt!
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Pris", SqlDbType.Int, 10).Value = biljett.Pris;
                    cmd.Parameters.Add("@Antal", SqlDbType.Int, 10).Value = biljett.Antal;
                    cmd.Parameters.Add("@Rabatt", SqlDbType.Decimal, 10).Value = biljett.Rabatt;
                    cmd.Parameters.Add("@BiljettTyp", SqlDbType.NVarChar, 30).Value = biljett.BiljettTyp;
                    cmd.Parameters.Add("@BesökarID", SqlDbType.Int, 4).Value = biljett.BesokarID;//.Direction = ParameterDirection.Output;

                    cmd.Parameters.Add("@BiljettID", SqlDbType.Int, 5).Direction = ParameterDirection.Output;

                    con.Open();
                    cmd.ExecuteNonQuery();

                    

                    biljett.BiljettID = (int)cmd.Parameters["@BiljettID"].Value;
                
                }
                catch
                {
                    throw new ApplicationException("An error occured during the connection with the database.");
                }
            }
        }
        public void UpdateBiljett(Biljett biljett)//uppdaterar kontakten med de nya vrdena!
        {
            using (var con = CreateConnection())
            {
                try
                {
                    var cmd = new SqlCommand("appSchema.UpdateBiljett", con);
                    cmd.CommandType = CommandType.StoredProcedure;  // denna är viktig missade denna en gång och letade länge!
                    cmd.Parameters.Add("@BiljettID", SqlDbType.Int, 4).Value = biljett.BiljettID;
                    cmd.Parameters.Add("@Pris", SqlDbType.Int, 10).Value = biljett.Pris;
                    cmd.Parameters.Add("@Antal", SqlDbType.Int, 10).Value = biljett.Antal;
                    cmd.Parameters.Add("@Rabatt", SqlDbType.Decimal, 10).Value = biljett.Rabatt;
                    cmd.Parameters.Add("@BiljettTyp", SqlDbType.NVarChar, 30).Value = biljett.BiljettTyp;
                    cmd.Parameters.Add("@BesökarID", SqlDbType.Int, 4).Value = biljett.BesokarID; //.Direction = ParameterDirection.Output;

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    throw new ApplicationException("Ett fel har uppståt med anslutningen mot databasen.-_");
                }
            }
        }

        //public Biljett GetSpecifikBiljett(int BiljettID)
        //{
        //    using (SqlConnection conn = CreateConnection())
        //    {
        //        //try
        //        //{
        //            var cmd = new SqlCommand("AppSchema.GetSpecifikBiljett", conn);
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            cmd.Parameters.Add("@BiljettID", SqlDbType.Int, 4).Value = BiljettID;
        //            conn.Open();

        //            using (var reader = cmd.ExecuteReader())
        //            {
        //                if (reader.Read())
        //                {
        //                    var BiljettIDIndex = reader.GetOrdinal("BiljettID");
        //                    var PrisIndex = reader.GetOrdinal("Pris");
        //                    var AntalIndex = reader.GetOrdinal("Antal");
        //                    var RabattIndex = reader.GetOrdinal("Rabatt");
        //                    var BiljettTypIndex = reader.GetOrdinal("BiljettTyp");
        //                    var BesökarIDIndex = reader.GetOrdinal("BesökarID");

        //                    return new Biljett
        //                    {
        //                        BiljettID = reader.GetInt32(BiljettIDIndex),
        //                        Pris = reader.GetInt32(PrisIndex),
        //                        Antal = reader.GetInt32(AntalIndex),
        //                        Rabatt = reader.GetInt32(RabattIndex),
        //                        BiljettTyp = reader.GetString(BiljettTypIndex),
        //                        BesokarID = reader.GetInt32(BesökarIDIndex),
        //                    };
        //                }
        //            }
        //            return null;
        //        }
        //        //catch
        //        //{
        //        //    throw new ApplicationException("Något gick Fel i dataåtkomstlagret");
        //        //}
        //   // }
        //}


        public void DeleteBiljett(int biljetttId)  // denna ska ta bort kontakten!
        {
            using (var con = CreateConnection())// skapar en anslutning
            {
                //try// testear här 
                //{
                    SqlCommand cmd = new SqlCommand("appSchema.deleteBiljett", con);  // denna är viktig att den är rätt!
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@BiljettID", SqlDbType.Int, 4).Value = biljetttId;

                    con.Open();
                    cmd.ExecuteNonQuery();
                //}
                //catch //fångar här!
                //{
                //    throw new ApplicationException("An error occured during the connection with the database.");
                //}
            }
        }


    }
}