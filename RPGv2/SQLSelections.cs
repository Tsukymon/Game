using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace RPGv2
{
    class SQLSelections
    {
        public static int PlayerMaxID = 0;
        public static int CurrentPlayerID = 0;
        public static int CurrentSelectedHeroIndex = 0;
        public static int SelectedCreatureIndex = 0;       


        public static List<Creature> LoadedCreatures = new List<Creature>();
        public static List<Player> LoadedPlayers = new List<Player>();
        public static List<Hero> LoadedDefaultHeroes = new List<Hero>();
        public static List<HiredHero> CurrentHiredHeroes = new List<HiredHero>();
        public static List<ExpCurve> ExpCurve = new List<ExpCurve>();
        public static List<Gear> LoadedGear = new List<Gear>();
        public static List<AvailableGear> AvailableGear = new List<AvailableGear>();

        
        


        
        

        public static void LoadCreatures()
        {
            var cs = "Host=localhost;Username=postgres;Password=12345;Database=postgres";
            var con = new NpgsqlConnection(cs);
            var LoadCreatures = $"SELECT * FROM public.\"Creature\"";
            var cmd = new NpgsqlCommand(LoadCreatures, con);
            con.Open();
            NpgsqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                LoadedCreatures.Add(new Creature(rdr.GetInt32(0), rdr.GetString(1), rdr.GetFloat(2), rdr.GetFloat(3), rdr.GetFloat(4), rdr.GetFloat(5), rdr.GetFloat(6), rdr.GetFloat(7), rdr.GetInt32(8)));
            }
            con.Close();
        }

        public static void LoadPlayers()
        {
            var cs = "Host=localhost;Username=postgres;Password=12345;Database=postgres";
            var con = new NpgsqlConnection(cs);
            var LoadPlayers = $"SELECT * FROM public.\"Player\"";
            var cmd = new NpgsqlCommand(LoadPlayers, con);
            con.Open();
            NpgsqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    LoadedPlayers.Add(new Player(rdr.GetInt32(0), rdr.GetString(1)));
                }
                con.Close();

                var GetPlayerMaxID = $"SELECT MAX(\"PlayerID\") FROM public.\"Player\"";
                var cmd2 = new NpgsqlCommand(GetPlayerMaxID, con);
                con.Open();
                PlayerMaxID = (Int32)cmd2.ExecuteScalar();
                con.Close();
            }
            else
            {
                
            }

            
        }

        public static void LoadDefaultHeroes()
        {
            var cs = "Host=localhost;Username=postgres;Password=12345;Database=postgres";
            var con = new NpgsqlConnection(cs);
            var LoadDefaultHeroes = $"SELECT * FROM public.\"Hero\"";
            var cmd = new NpgsqlCommand(LoadDefaultHeroes, con);
            con.Open();
            NpgsqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                LoadedDefaultHeroes.Add(new Hero(rdr.GetInt32(0), rdr.GetString(1), rdr.GetFloat(2), rdr.GetFloat(3), rdr.GetFloat(4), rdr.GetFloat(5), rdr.GetFloat(6), rdr.GetFloat(7), rdr.GetFloat(8), rdr.GetFloat(9), rdr.GetFloat(10), rdr.GetFloat(11), rdr.GetFloat(12), rdr.GetFloat(13), rdr.GetFloat(14), rdr.GetFloat(15)));
            }
            con.Close();

        }

        public static void AddNewPlayer(string name)
        {
            var cs = "Host=localhost;Username=postgres;Password=12345;Database=postgres";
            var con = new NpgsqlConnection(cs);
            var PlayerCreation = $"INSERT INTO public.\"Player\" VALUES({PlayerMaxID+1},'{name}')";
            var cmd = new NpgsqlCommand(PlayerCreation, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            LoadedPlayers.Add(new Player(PlayerMaxID+1, name));
            PlayerMaxID++;
            CurrentPlayerID = PlayerMaxID;

        }

        public static void SetCurrentPlayerID(string name)
        {
            var cs = "Host=localhost;Username=postgres;Password=12345;Database=postgres";
            var con = new NpgsqlConnection(cs);
            var SetCurrentPlayerID = $"SELECT \"PlayerID\" FROM public.\"Player\" WHERE \"Name\" = '{name}'";
            var cmd = new NpgsqlCommand(SetCurrentPlayerID, con);
            con.Open();
            CurrentPlayerID = (Int32)cmd.ExecuteScalar();
            con.Close();
        }

        public static void LoadHiredHeroes()
        {
            CurrentHiredHeroes.Clear();
            var cs = "Host=localhost;Username=postgres;Password=12345;Database=postgres";
            var con = new NpgsqlConnection(cs);
            var LoadHiredHeroes = $"SELECT * FROM public.\"HiredHeroes\" WHERE \"PlayerID\" = {CurrentPlayerID} ORDER BY \"ID\"";
            var cmd = new NpgsqlCommand(LoadHiredHeroes, con);
            con.Open();
            NpgsqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    CurrentHiredHeroes.Add(new HiredHero(rdr.GetInt32(0), rdr.GetString(1), rdr.GetFloat(2), rdr.GetFloat(3), rdr.GetFloat(4), rdr.GetFloat(5), rdr.GetFloat(6), rdr.GetFloat(7), rdr.GetFloat(8), rdr.GetInt32(9), rdr.GetInt32(10), rdr.GetInt32(11), rdr.GetInt32(12)));
                }               
            }
            else
            {
                CurrentHiredHeroes.Clear();
            }


        }

        public static void HireHero(int index)
        {
            var cs = "Host=localhost;Username=postgres;Password=12345;Database=postgres";
            var con = new NpgsqlConnection(cs);
            var HireHero = $"INSERT INTO public.\"HiredHeroes\" VALUES({GetHiredHeroesMaxIndex()+1}, '{LoadedDefaultHeroes[index].GetName()}', {LoadedDefaultHeroes[index].GetHp()}, {LoadedDefaultHeroes[index].GetAtk()}, {LoadedDefaultHeroes[index].GetMatk()}, {LoadedDefaultHeroes[index].GetAcc()}, {LoadedDefaultHeroes[index].GetCrit()}, {LoadedDefaultHeroes[index].GetDef()}, {LoadedDefaultHeroes[index].GetMdef()}, 1, {CurrentPlayerID}, 0, 10)";
            var cmd = new NpgsqlCommand(HireHero, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            CurrentHiredHeroes.Add(new HiredHero(GetHiredHeroesMaxIndex() + 1, LoadedDefaultHeroes[index].GetName(), LoadedDefaultHeroes[index].GetHp(), LoadedDefaultHeroes[index].GetAtk(), LoadedDefaultHeroes[index].GetMatk(), LoadedDefaultHeroes[index].GetAcc(), LoadedDefaultHeroes[index].GetCrit(), LoadedDefaultHeroes[index].GetDef(), LoadedDefaultHeroes[index].GetMdef(), 1, CurrentPlayerID, 0, 10));
            
        }

        public static int GetHiredHeroesMaxIndex()
        {
            int Index;
            var cs = "Host=localhost;Username=postgres;Password=12345;Database=postgres";
            var con = new NpgsqlConnection(cs);
            var GetHiredHeroesMaxIndex = $"SELECT MAX(\"ID\") FROM public.\"HiredHeroes\"";
            var cmd = new NpgsqlCommand(GetHiredHeroesMaxIndex, con);
            con.Open();

            object dbcheck = cmd.ExecuteScalar();
            if(dbcheck != DBNull.Value)
            {
                Index = Convert.ToInt32(dbcheck);
            }
            else
            {              
                Index = 0;
            }
            con.Close();
            return Index;
        }

        public static void GiveHeroExp(int index)
        {
            var cs = "Host=localhost;Username=postgres;Password=12345;Database=postgres";
            var con = new NpgsqlConnection(cs);
            var GiveHeroExp = $"UPDATE public.\"HiredHeroes\" SET \"Exp\" = {SQLSelections.CurrentHiredHeroes[index].GetExp()} WHERE \"ID\" = {SQLSelections.CurrentHiredHeroes[index].GetID()}";
            var cmd = new NpgsqlCommand(GiveHeroExp, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static void LoadExpCurve()
        {
            var cs = "Host=localhost;Username=postgres;Password=12345;Database=postgres";
            var con = new NpgsqlConnection(cs);
            var LoadExpCurve = $"SELECT * FROM public.\"XPCurve\"";
            var cmd = new NpgsqlCommand(LoadExpCurve, con);
            con.Open();

            NpgsqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                ExpCurve.Add(new ExpCurve(rdr.GetInt32(0), rdr.GetInt32(1)));
            }
            con.Close();
        }

        public static void UpdateLvl()
        {
            var cs = "Host=localhost;Username=postgres;Password=12345;Database=postgres";
            var con = new NpgsqlConnection(cs);
            var UpdateLvl = $"UPDATE public.\"HiredHeroes\" SET \"Lvl\" = {CurrentHiredHeroes[CurrentSelectedHeroIndex].GetLvl()} WHERE \"ID\" = {CurrentHiredHeroes[CurrentSelectedHeroIndex].GetID()}";
            var cmd = new NpgsqlCommand(UpdateLvl, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static void UpdateExpForNextLvl()
        {
            var cs = "Host=localhost;Username=postgres;Password=12345;Database=postgres";
            var con = new NpgsqlConnection(cs);
            var UpdateExpForNextLvl = $"UPDATE public.\"HiredHeroes\" SET \"ExpForNextLvl\" = {CurrentHiredHeroes[CurrentSelectedHeroIndex].GetExpForNextLvl()} WHERE \"ID\" = {CurrentHiredHeroes[CurrentSelectedHeroIndex].GetID()}";
            var cmd = new NpgsqlCommand(UpdateExpForNextLvl, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static void UpdateStatsForLvlUp()
        {          
            for(int i = 0; i < LoadedDefaultHeroes.Count(); i++)
            {
                if(CurrentHiredHeroes[CurrentSelectedHeroIndex].GetName() == LoadedDefaultHeroes[i].GetName())
                {
                    CurrentHiredHeroes[CurrentSelectedHeroIndex].SetHp(LoadedDefaultHeroes[i].GetHpPLvl());
                    CurrentHiredHeroes[CurrentSelectedHeroIndex].SetAtk(LoadedDefaultHeroes[i].GetAtkPLvl());
                    CurrentHiredHeroes[CurrentSelectedHeroIndex].SetMatk(LoadedDefaultHeroes[i].GetMatkPLvl());
                    CurrentHiredHeroes[CurrentSelectedHeroIndex].SetDef(LoadedDefaultHeroes[i].GetDefPLvl());
                    CurrentHiredHeroes[CurrentSelectedHeroIndex].SetMdef(LoadedDefaultHeroes[i].GetMdefPLvl());
                    CurrentHiredHeroes[CurrentSelectedHeroIndex].SetAcc(LoadedDefaultHeroes[i].GetAccPLvl());
                    CurrentHiredHeroes[CurrentSelectedHeroIndex].SetCrit(LoadedDefaultHeroes[i].GetCritPLvl());
                    
                }
            }


            var cs = "Host=localhost;Username=postgres;Password=12345;Database=postgres";
            var con = new NpgsqlConnection(cs);
            var UpdateStatsForLvlUp = $"UPDATE public.\"HiredHeroes\" SET \"Hp\" = {CurrentHiredHeroes[CurrentSelectedHeroIndex].GetHp().ToString().Replace(',','.')}, \"Atk\" = {CurrentHiredHeroes[CurrentSelectedHeroIndex].GetAtk().ToString().Replace(',', '.')}, \"Matk\" = {CurrentHiredHeroes[CurrentSelectedHeroIndex].GetMatk().ToString().Replace(',', '.')}, \"Def\" = {CurrentHiredHeroes[CurrentSelectedHeroIndex].GetDef().ToString().Replace(',', '.')}, \"Mdef\" = {CurrentHiredHeroes[CurrentSelectedHeroIndex].GetMdef().ToString().Replace(',', '.')}, \"Acc\" = {CurrentHiredHeroes[CurrentSelectedHeroIndex].GetAcc().ToString().Replace(',', '.')}, \"Crit\" = {CurrentHiredHeroes[CurrentSelectedHeroIndex].GetCrit().ToString().Replace(',', '.')} WHERE \"ID\" = {CurrentHiredHeroes[CurrentSelectedHeroIndex].GetID()}";
            var cmd = new NpgsqlCommand(UpdateStatsForLvlUp, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }

        public static void LoadGear()
        {
            var cs = "Host=localhost;Username=postgres;Password=12345;Database=postgres";
            var con = new NpgsqlConnection(cs);
            var LoadGear = $"SELECT * FROM public.\"Gear\"";
            var cmd = new NpgsqlCommand(LoadGear, con);
            con.Open();
            NpgsqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                LoadedGear.Add(new Gear(rdr.GetInt32(0), rdr.GetInt32(1), rdr.GetInt32(2), rdr.GetInt32(3), rdr.GetInt32(4), rdr.GetInt32(5), rdr.GetInt32(6), rdr.GetInt32(7), rdr.GetInt32(8), rdr.GetInt32(9), rdr.GetString(10)));
            }
            con.Close();
        }

        public static void LoadAvailableGear()
        {
            var cs = "Host=localhost;Username=postgres;Password=12345;Database=postgres";
            var con = new NpgsqlConnection(cs);
            var LoadAvailableGear = $"SELECT * FROM public.\"AvailableGear\" WHERE \"PlayerID\" = {SQLSelections.CurrentPlayerID}";
            var cmd = new NpgsqlCommand(LoadAvailableGear, con);
            con.Open();
            NpgsqlDataReader rdr = cmd.ExecuteReader();

            if(rdr.HasRows)
            {
                while (rdr.Read())
                {
                    AvailableGear.Add(new AvailableGear(rdr.GetInt32(0), rdr.GetInt32(1), rdr.GetInt32(2), rdr.GetInt32(3), rdr.GetInt32(4), rdr.GetInt32(5), rdr.GetInt32(6), rdr.GetInt32(7), rdr.GetInt32(8), rdr.GetInt32(9), rdr.GetString(10), rdr.GetInt32(11), rdr.GetBoolean(12), rdr.GetInt32(13), rdr.GetInt32(14)));
                }
            }
            else
            {
                AvailableGear.Clear();
            }

            
            con.Close();
        }

        public static void UpdateEquipedStatusTRUE(int index)
        {
            var cs = "Host=localhost;Username=postgres;Password=12345;Database=postgres";
            var con = new NpgsqlConnection(cs);
            var UpdateEquipedStatus = $"UPDATE public.\"AvailableGear\" SET \"Equiped\" = true, \"HeroID\" = {SQLSelections.CurrentSelectedHeroIndex} WHERE \"ID\" = {SQLSelections.AvailableGear[index].GetID()}";
            var cmd = new NpgsqlCommand(UpdateEquipedStatus, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static void UpdateEquipedStatusFALSE(int index)
        {
            var cs = "Host=localhost;Username=postgres;Password=12345;Database=postgres";
            var con = new NpgsqlConnection(cs);
            var UpdateEquipedStatus = $"UPDATE public.\"AvailableGear\" SET \"Equiped\" = false, \"HeroID\" = -1 WHERE \"ID\" = {SQLSelections.AvailableGear[index].GetID()}";
            var cmd = new NpgsqlCommand(UpdateEquipedStatus, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static void EquipAddStats(int index)
        {
            SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].SetHp(SQLSelections.AvailableGear[index].GetHp());
            SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].SetAtk(SQLSelections.AvailableGear[index].GetAtk());
            SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].SetMatk(SQLSelections.AvailableGear[index].GetMatk());
            SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].SetAcc(SQLSelections.AvailableGear[index].GetAcc());
            SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].SetCrit(SQLSelections.AvailableGear[index].GetCrit());
            SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].SetDef(SQLSelections.AvailableGear[index].GetDef());
            SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].SetMdef(SQLSelections.AvailableGear[index].GetMdef());

            var cs = "Host=localhost;Username=postgres;Password=12345;Database=postgres";
            var con = new NpgsqlConnection(cs);
            var EquipAddStats = $"UPDATE public.\"HiredHeroes\" SET \"Hp\" = {SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].GetHp().ToString().Replace(',', '.')}, \"Atk\" = {SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].GetAtk().ToString().Replace(',', '.')}, \"Matk\" = {SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].GetMatk().ToString().Replace(',', '.')}, \"Acc\" = {SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].GetAcc().ToString().Replace(',', '.')}, \"Crit\" = {SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].GetCrit().ToString().Replace(',', '.')}, \"Def\" = {SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].GetDef().ToString().Replace(',', '.')}, \"Mdef\" = {SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].GetMdef().ToString().Replace(',', '.')} WHERE \"ID\" = {SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].GetID()}";
            var cmd = new NpgsqlCommand(EquipAddStats, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }

        public static void EquipRemoveStats(int index)
        {
            SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].SetHp(SQLSelections.AvailableGear[index].GetHp()*-1);
            SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].SetAtk(SQLSelections.AvailableGear[index].GetAtk() * -1);
            SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].SetMatk(SQLSelections.AvailableGear[index].GetMatk() * -1);
            SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].SetAcc(SQLSelections.AvailableGear[index].GetAcc() * -1);
            SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].SetCrit(SQLSelections.AvailableGear[index].GetCrit() * -1);
            SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].SetDef(SQLSelections.AvailableGear[index].GetDef() * -1);
            SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].SetMdef(SQLSelections.AvailableGear[index].GetMdef() * -1);

            var cs = "Host=localhost;Username=postgres;Password=12345;Database=postgres";
            var con = new NpgsqlConnection(cs);
            var EquipRemoveStats = $"UPDATE public.\"HiredHeroes\" SET \"Hp\" = {SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].GetHp().ToString().Replace(',', '.')}, \"Atk\" = {SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].GetAtk().ToString().Replace(',', '.')}, \"Matk\" = {SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].GetMatk().ToString().Replace(',', '.')}, \"Acc\" = {SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].GetAcc().ToString().Replace(',', '.')}, \"Crit\" = {SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].GetCrit().ToString().Replace(',', '.')}, \"Def\" = {SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].GetDef().ToString().Replace(',', '.')}, \"Mdef\" = {SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].GetMdef().ToString().Replace(',', '.')} WHERE \"ID\" = {SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].GetID()}";
            var cmd = new NpgsqlCommand(EquipRemoveStats, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }
    }

    
    
}
