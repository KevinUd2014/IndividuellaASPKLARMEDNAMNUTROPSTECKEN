using Kn222gn_IndividuellaArbetet.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Kn222gn_IndividuellaArbetet.DAL
{
    public class BesokareDAL : DALBase
    {
        public IEnumerable<Besokare> GetBesokare()
        {

            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    var besokare = new List<Besokare>(100);
                    var cmd = new SqlCommand("appSchema.ReadFromVisitor", conn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var besokarIDIndex = reader.GetOrdinal("BesökarID");
                            var fornamnIndex = reader.GetOrdinal("Förnamn");
                            var efterNamnIndex = reader.GetOrdinal("Efternamn");
                            var telefonNRIndex = reader.GetOrdinal("TelefonNR");
                            var kopIndex = reader.GetOrdinal("Köp");
                            int bokningIndex = reader.GetOrdinal("Bokning");
                            int bokningUpphorIndex = reader.GetOrdinal("BokningUpphör");
                            besokare.Add(new Besokare
                            {
                                BesokarID = reader.GetInt32(besokarIDIndex),
                                Fornamn = reader.GetString(fornamnIndex),
                                Efternamn = reader.GetString(efterNamnIndex),
                                TelefonNR = reader.GetString(telefonNRIndex),
                                Kop = reader.GetString(kopIndex),
                                Bokning = reader.GetDateTime(bokningIndex),
                                BokningUpphor = reader.GetDateTime(bokningUpphorIndex)
                            });
                        }

                        besokare.TrimExcess();
                        return besokare;
                    }
                }
                catch
                {
                    throw new ApplicationException("Ett fel har uppståt!");
                }
            }

        }
        public void CreateBesokare(Besokare besokare)  //lägger in den nya kontakten!
        {
            using (var con = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.createBesokare2", con);  // denna är viktig att den är rätt!
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Förnamn", SqlDbType.VarChar, 30).Value = besokare.Fornamn;
                    cmd.Parameters.Add("@Efternamn", SqlDbType.VarChar, 30).Value = besokare.Efternamn;
                    cmd.Parameters.Add("@TelefonNR", SqlDbType.VarChar, 10).Value = besokare.TelefonNR;
                    cmd.Parameters.Add("@Köp", SqlDbType.VarChar, 30).Value = besokare.Kop;
                    cmd.Parameters.Add("@Bokning", SqlDbType.SmallDateTime, 10).Value = besokare.Bokning;//.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@BokningUpphör", SqlDbType.SmallDateTime, 10).Value = besokare.BokningUpphor;

                    cmd.Parameters.Add("@BesökarID", SqlDbType.Int, 5).Direction = ParameterDirection.Output;

                    con.Open();
                    cmd.ExecuteNonQuery();

                    besokare.BesokarID = (int)cmd.Parameters["@BesökarID"].Value;
                   
                }
                catch
                {
                    throw new ApplicationException("Ett fel har uppståt med anslutningen mot databasen.,");
                }
            }
        }
        public void UpdateBesokare(Besokare besokare)//uppdaterar kontakten med de nya vrdena!
        {
            using (var con = CreateConnection())
            {
                try
                {
                var cmd = new SqlCommand("appSchema.UpdateBesokare", con);
                cmd.Parameters.Add("@Förnamn", SqlDbType.NVarChar, 30).Value = besokare.Fornamn;
                cmd.Parameters.Add("@Efternamn", SqlDbType.NVarChar, 30).Value = besokare.Efternamn;
                cmd.Parameters.Add("@TelefonNR", SqlDbType.NVarChar, 10).Value = besokare.TelefonNR;
                cmd.Parameters.Add("@Köp", SqlDbType.NVarChar, 30).Value = besokare.Kop;
                cmd.Parameters.Add("@Bokning", SqlDbType.Int, 10).Value = besokare.Bokning;//.Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@BokningUpphör", SqlDbType.Int, 10).Value = besokare.BokningUpphor;

                cmd.Parameters.Add("@BesökarID", SqlDbType.Int, 5).Direction = ParameterDirection.Output;

                con.Open();
                cmd.ExecuteNonQuery();

                besokare.BesokarID = (int)cmd.Parameters["@BesökarID"].Value;

            }
            catch
            {
                throw new ApplicationException("Ett fel har uppståt med anslutningen mot databasen.,,");
            }
           }
        }

        public Besokare GetSpecifikBesokare(int BesokareID)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    var cmd = new SqlCommand("AppSchema.GetSpecifikBesokare", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@BesökarID", SqlDbType.Int, 4).Value = BesokareID;
                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var BesokareIDIndex = reader.GetOrdinal("BesökarID");
                            var FnamnIndex = reader.GetOrdinal("Förnamn");
                            var EnamnIndex = reader.GetOrdinal("Efternamn");
                            var TelefonNRIndex = reader.GetOrdinal("TelefonNR");
                            var KopIndex = reader.GetOrdinal("Köp");
                            var BokningIndex = reader.GetOrdinal("Bokning");
                            var BokningUpphorIndex = reader.GetOrdinal("BokningUpphör");

                            return new Besokare
                            {
                                BesokarID = reader.GetInt32(BesokareIDIndex),
                                Fornamn = reader.GetString(FnamnIndex),
                                Efternamn = reader.GetString(EnamnIndex),
                                TelefonNR = reader.GetString(TelefonNRIndex),
                                Kop = reader.GetString(KopIndex),
                                Bokning = reader.GetDateTime(BokningIndex),
                                BokningUpphor = reader.GetDateTime(BokningUpphorIndex),

                            };
                        }
                    }
                    return null;
                }
                catch (Exception e)
                {
                    throw new ApplicationException("Något gick Fel i dataåtkomstlagret");
                }
            }
        }
    }
}