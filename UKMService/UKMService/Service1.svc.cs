using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.SqlClient;
using System.Data;


namespace UKMService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        SqlConnection con = new SqlConnection("Data Source=PANGLING-PC\\SQLEXPRESS;Initial Catalog=UKM;User ID=Gasai21;Password=g02121997p");
        string id;
        string idstudenukm;
                                  
        //ini bagian admin
        //ini bagian login
        public int doLoginAdmin(string username, string password) {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Account where Username = @username AND Password = @password AND Status= @status", con);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("@status", "Admin");

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                con.Close();
                return 1;
            }else{
                con.Close();
                return 0;
            }
            
        }

        //ini bagian captain
        public List<Account> GetCaptain(string Name) {
            List<Account> captain = new List<Account>();
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Account where Name like '%'+@Name+'%' AND Status=@status", con);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@status", "Captain");
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Account customerInfo = new Account();
                        customerInfo.Id = dt.Rows[i]["id"].ToString();
                        customerInfo.Nim = dt.Rows[i]["Nim"].ToString();
                        customerInfo.Name = dt.Rows[i]["Name"].ToString();
                        customerInfo.Gender = dt.Rows[i]["Gender"].ToString();
                        customerInfo.Address = dt.Rows[i]["Address"].ToString();
                        customerInfo.PhoneNumber = dt.Rows[i]["Phonenumber"].ToString();
                        customerInfo.Faculty = dt.Rows[i]["Faculty"].ToString();
                        customerInfo.Major = dt.Rows[i]["Major"].ToString();
                        customerInfo.Batch = dt.Rows[i]["Batch"].ToString();
                        customerInfo.Username = dt.Rows[i]["Username"].ToString();
                        customerInfo.Password = dt.Rows[i]["Password"].ToString();
                        customerInfo.Job = dt.Rows[i]["Status"].ToString();
                        captain.Add(customerInfo);
                    }
                }
                con.Close();
            }

            return captain;
        }

        public int doUpdateAdmin(Account acc)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("update Account set Nim=@nim, Name=@name, Gender=@gender, Address=@address, Phonenumber=@phone, Faculty=@faculty, Major=@major, Batch=@batch, Username=@username, Password=@Password where id=@id", con);
            cmd.Parameters.AddWithValue("@nim", acc.Nim);
            cmd.Parameters.AddWithValue("@name", acc.Name);
            cmd.Parameters.AddWithValue("@gender", acc.Gender);
            cmd.Parameters.AddWithValue("@address", acc.Address);
            cmd.Parameters.AddWithValue("@phone", acc.PhoneNumber);
            cmd.Parameters.AddWithValue("@faculty", acc.Faculty);
            cmd.Parameters.AddWithValue("@major", acc.Major);
            cmd.Parameters.AddWithValue("@batch", acc.Batch);
            cmd.Parameters.AddWithValue("@username", acc.Username);
            cmd.Parameters.AddWithValue("@password", acc.Password);
            cmd.Parameters.AddWithValue("@id", acc.Id);
            int result = cmd.ExecuteNonQuery();
            if (result == 1)
            {
                con.Close();
                return 1;
            }
            else
            {
                con.Close();
                return 0;
            }
        }

        public int doDeleteAdmin(string id) {
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from Account where id=@id", con);
            cmd.Parameters.AddWithValue("@id", id);
            int result = cmd.ExecuteNonQuery();
            if (result == 1)
            {
                con.Close();
                return 1;
            }
            else {
                con.Close();
                return 0;
            }
        }

        public string convertukm(string ukm)
        {
            string hasil ="";
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from UKM where Ukmname=@nama", con);
            cmd.Parameters.AddWithValue("@nama", ukm);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        hasil = dt.Rows[i]["id"].ToString();
                    }
                }
                con.Close();
            return hasil;
        }

        public int doInsertCaptainAdmin(Account acc, StudentUKM ukm) {
            con.Open();
            int hasil = 0;
            SqlCommand cmd = new SqlCommand("insert into Account(Nim, Name, Gender, Address, Phonenumber, Faculty, Major, Batch, Username, Password, Status) values(@nim, @name, @gender, @address, @phonenumber, @faculty, @major, @batch, @username, @password, @status)",con);
            cmd.Parameters.AddWithValue("@nim", acc.Nim);
            cmd.Parameters.AddWithValue("@name", acc.Name);
            cmd.Parameters.AddWithValue("@gender", acc.Gender);
            cmd.Parameters.AddWithValue("@address", acc.Address);
            cmd.Parameters.AddWithValue("@phonenumber", acc.PhoneNumber);
            cmd.Parameters.AddWithValue("@faculty", acc.Faculty);
            cmd.Parameters.AddWithValue("@major", acc.Major);
            cmd.Parameters.AddWithValue("@batch", acc.Batch);
            cmd.Parameters.AddWithValue("@username", acc.Username);
            cmd.Parameters.AddWithValue("@password", acc.Password);
            cmd.Parameters.AddWithValue("@status", "Captain");

            int result = cmd.ExecuteNonQuery();
            if(result == 1){
                SqlCommand cmd2 = new SqlCommand("insert into StudentUKM(id_ukm, Status) values(@idukm, @status)", con);
                cmd2.Parameters.AddWithValue("@idukm", ukm.Ukmid);
                cmd2.Parameters.AddWithValue("@status", "Active");

                int result2 = cmd2.ExecuteNonQuery();
                if (result2 == 1)
                {
                    SqlCommand cmd3 = new SqlCommand("select top 1 * from Account order by id desc", con);

                    SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
                    DataTable dt3 = new DataTable();
                    da3.Fill(dt3);

                    if (dt3.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt3.Rows.Count; i++)
                        {
                            id = dt3.Rows[i]["id"].ToString();
                        }

                        SqlCommand cmd4 = new SqlCommand("select top 1 * from StudentUKM order by id desc", con);
                        SqlDataAdapter da4 = new SqlDataAdapter(cmd4);
                        DataTable dt4 = new DataTable();
                        da4.Fill(dt4);

                        if (dt4.Rows.Count > 0)
                        {
                            for (int i = 0; i < dt4.Rows.Count; i++)
                            {
                                idstudenukm = dt4.Rows[i]["id"].ToString();
                            }

                            SqlCommand cmd5 = new SqlCommand("update StudentUKM set id_account = @id where id = @idd", con);
                            cmd5.Parameters.AddWithValue("@id", id);
                            cmd5.Parameters.AddWithValue("@idd", idstudenukm);
                            int result5 = cmd5.ExecuteNonQuery();
                            if (result5 > 0)
                            {
                                con.Close();
                                hasil = 1;
                            }
                            else
                            {
                                con.Close();
                                hasil = 0;
                            }
                        }
                        else {
                            hasil = 0;
                        }
                        
                    }
                }
                else {
                    hasil = 0;
                }
            }else{
                hasil =  0;
            }

            return hasil;
        }

        //ini bagian coach
        public int doInsertCoach(Coach acc) {
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Coach(Coachname, Coachgender, Coachaddress, Coachphonenumber) values(@name, @gender, @address, @phone)", con);
            cmd.Parameters.AddWithValue("@name", acc.Name);
            cmd.Parameters.AddWithValue("@gender", acc.Gender);
            cmd.Parameters.AddWithValue("@address", acc.Address);
            cmd.Parameters.AddWithValue("@phone", acc.Phone);

            int result = cmd.ExecuteNonQuery();
            if (result == 1){
                con.Close();
                return 1;
            }
            else {
                con.Close();
                return 0;
            }
        }

        public string convertcoach(string ukm) {
            string hasil = "";
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Coach where Coachname=@nama", con);
            cmd.Parameters.AddWithValue("@nama", ukm);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    hasil = dt.Rows[i]["id"].ToString();
                }
            }
            con.Close();
            return hasil;
        }

        public List<Coach> GetCoach(string Name) {
            List<Coach> coach = new List<Coach>();
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Coach where Coachname like '%'+@Name+'%'", con);
                cmd.Parameters.AddWithValue("@Name", Name);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Coach customerInfo = new Coach();
                        customerInfo.Id = dt.Rows[i]["id"].ToString();
                        customerInfo.Name = dt.Rows[i]["Coachname"].ToString();
                        customerInfo.Gender = dt.Rows[i]["Coachgender"].ToString();
                        customerInfo.Address = dt.Rows[i]["Coachaddress"].ToString();
                        customerInfo.Phone = dt.Rows[i]["Coachphonenumber"].ToString();
                        coach.Add(customerInfo);
                    }
                }
                con.Close();
            }

            return coach;
        }

        public int doDeleteCoach(string id) {
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from Coach where id=@id", con);
            cmd.Parameters.AddWithValue("@id", id);

            int result = cmd.ExecuteNonQuery();
            if (result == 1)
            {
                con.Close();
                return 1;
            }
            else
            {
                con.Close();
                return 0;
            }
        }

        public int doUpdateCoach(Coach acc) {
            con.Open();
            SqlCommand cmd = new SqlCommand("update Coach set Coachname=@name, Coachgender=@gender, Coachaddress=@address, Coachphonenumber=@phone where id=@id", con);
            cmd.Parameters.AddWithValue("@name", acc.Name);
            cmd.Parameters.AddWithValue("@gender", acc.Gender);
            cmd.Parameters.AddWithValue("@address", acc.Address);
            cmd.Parameters.AddWithValue("@phone", acc.Phone);
            cmd.Parameters.AddWithValue("@id", acc.Id);

            int result = cmd.ExecuteNonQuery();
            if (result == 1)
            {
                con.Close();
                return 1;
            }
            else
            {
                con.Close();
                return 0;
            }
        }

        //ini bagian UKM
        public int doDeleteUKM(string id) {
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from UKM where id=@id", con);
            cmd.Parameters.AddWithValue("@id", id);

            int result = cmd.ExecuteNonQuery();
            if (result == 1)
            {
                con.Close();
                return 1;
            }
            else
            {
                con.Close();
                return 0;
            }
        }

        public List<cUkm> GetUKM(string Name) {
            List<cUkm> ukm = new List<cUkm>();
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from UKM where Ukmname like '%'+@Name+'%'", con);
                cmd.Parameters.AddWithValue("@Name", Name);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        cUkm customerInfo = new cUkm();
                        customerInfo.Id = dt.Rows[i]["id"].ToString();
                        customerInfo.Ukmname = dt.Rows[i]["Ukmname"].ToString();
                        customerInfo.Desc = dt.Rows[i]["Description"].ToString();
                        customerInfo.Idcoach = dt.Rows[i]["id_coach"].ToString();
                        ukm.Add(customerInfo);
                    }
                }
                con.Close();
            }

            return ukm;
        }

        public int doInsertUKM(cUkm acc) {
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into UKM(Ukmname, Description, id_coach) values(@ukm, @desc, @idcoach)", con);
            cmd.Parameters.AddWithValue("@ukm", acc.Ukmname);
            cmd.Parameters.AddWithValue("@desc", acc.Desc);
            cmd.Parameters.AddWithValue("@idcoach", acc.Idcoach);

            int result = cmd.ExecuteNonQuery();
            if (result == 1)
            {
                con.Close();
                return 1;
            }
            else
            {
                con.Close();
                return 0;
            }
       }

        public int doUpdateUKM(cUkm acc) {
            con.Open();
            SqlCommand cmd = new SqlCommand("update UKM set Ukmname=@name, Description=@desc, id_coach=@coach where id=@id", con);
            cmd.Parameters.AddWithValue("@name", acc.Ukmname);
            cmd.Parameters.AddWithValue("@desc", acc.Desc);
            cmd.Parameters.AddWithValue("@coach", acc.Idcoach);
            cmd.Parameters.AddWithValue("@id", acc.Id);

            int result = cmd.ExecuteNonQuery();
            if (result == 1)
            {
                con.Close();
                return 1;
            }
            else
            {
                con.Close();
                return 0;
            }
        }

        //bagian place
        public int doDeletePlace(string id) {
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from Place where id=@id", con);
            cmd.Parameters.AddWithValue("@id", id);

            int result = cmd.ExecuteNonQuery();
            if (result == 1)
            {
                con.Close();
                return 1;
            }
            else
            {
                con.Close();
                return 0;
            }
       }

        public string convertplace(string place) {
            string hasil = "";
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Place where Placename=@nama", con);
            cmd.Parameters.AddWithValue("@nama", place);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    hasil = dt.Rows[i]["id"].ToString();
                }
            }
            con.Close();
            return hasil;
        }

        public string convertidplace(string place)
        {
            string hasil = "";
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Place where id=@nama", con);
            cmd.Parameters.AddWithValue("@nama", place);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    hasil = dt.Rows[i]["Placename"].ToString();
                }
            }
            con.Close();
            return hasil;
        }

       public int doUpdatePlace(Place acc) {
           con.Open();
           SqlCommand cmd = new SqlCommand("update Place set Placename=@name where id=@id", con);
           cmd.Parameters.AddWithValue("@name", acc.Name);
           cmd.Parameters.AddWithValue("@id", acc.Id);

           int result = cmd.ExecuteNonQuery();
           if (result == 1)
           {
               con.Close();
               return 1;
           }
           else
           {
               con.Close();
               return 0;
           }
       }

       public List<Place> GetPlace(string Name) {
           List<Place> place = new List<Place>();
           {
               con.Open();
               SqlCommand cmd = new SqlCommand("select * from Place where Placename like '%'+@Name+'%'", con);
               cmd.Parameters.AddWithValue("@Name", Name);
               SqlDataAdapter da = new SqlDataAdapter(cmd);
               DataTable dt = new DataTable();
               da.Fill(dt);
               if (dt.Rows.Count > 0)
               {
                   for (int i = 0; i < dt.Rows.Count; i++)
                   {
                       Place customerInfo = new Place();
                       customerInfo.Id = dt.Rows[i]["id"].ToString();
                       customerInfo.Name = dt.Rows[i]["Placename"].ToString();
                       place.Add(customerInfo);
                   }
               }
               con.Close();
           }

           return place;
       }

       public int doInsertPlace(Place acc) {
           con.Open();
           SqlCommand cmd = new SqlCommand("insert into Place(Placename) values(@name)", con);
           cmd.Parameters.AddWithValue("@name", acc.Name);

           int result = cmd.ExecuteNonQuery();
           if (result == 1)
           {
               con.Close();
               return 1;
           }
           else
           {
               con.Close();
               return 0;
           }
       }

       //ini bagian schedule
       public int doDeleteSchedule(string id) {
           con.Open();
           SqlCommand cmd = new SqlCommand("delete from Schedule where id=@id", con);
           cmd.Parameters.AddWithValue("@id", id);

           int result = cmd.ExecuteNonQuery();
           if (result == 1)
           {
               con.Close();
               return 1;
           }
           else
           {
               con.Close();
               return 0;
           }
       }

       public int doUpdateSchedule(Schedule acc) {
           con.Open();
           SqlCommand cmd = new SqlCommand("update Schedule set Day=@day, Starttime=@start, Endtime=@end, id_place=@place where id=@id", con);
           cmd.Parameters.AddWithValue("@day", acc.Day);
           cmd.Parameters.AddWithValue("@start", acc.Starttime);
           cmd.Parameters.AddWithValue("@end", acc.Endtime);
           cmd.Parameters.AddWithValue("@place", acc.Idplace);
           cmd.Parameters.AddWithValue("@id", acc.Id);

           int result = cmd.ExecuteNonQuery();
           if (result == 1)
           {
               con.Close();
               return 1;
           }
           else
           {
               con.Close();
               return 0;
           }
       }

       public List<Schedule> GetSchedule(string Name) {
           List<Schedule> place = new List<Schedule>();
           {
               con.Open();
               SqlCommand cmd = new SqlCommand("select * from Schedule where Day like '%'+@Name+'%'", con);
               cmd.Parameters.AddWithValue("@Name", Name);
               SqlDataAdapter da = new SqlDataAdapter(cmd);
               DataTable dt = new DataTable();
               da.Fill(dt);
               if (dt.Rows.Count > 0)
               {
                   for (int i = 0; i < dt.Rows.Count; i++)
                   {
                       Schedule customerInfo = new Schedule();
                       customerInfo.Id = dt.Rows[i]["id"].ToString();
                       customerInfo.Day = dt.Rows[i]["Day"].ToString();
                       customerInfo.Starttime = dt.Rows[i]["Starttime"].ToString();
                       customerInfo.Endtime = dt.Rows[i]["Endtime"].ToString();
                       customerInfo.Idplace = dt.Rows[i]["id_place"].ToString();
                       place.Add(customerInfo);
                   }
               }
               con.Close();
           }

           return place;
       }

       public int doInsertSchedule(Schedule acc) {
           con.Open();
           SqlCommand cmd = new SqlCommand("select * from Schedule where Day = @day AND Starttime = @start AND Endtime= @end AND id_place=@place", con);
           cmd.Parameters.AddWithValue("@day", acc.Day);
           cmd.Parameters.AddWithValue("@start", acc.Starttime);
           cmd.Parameters.AddWithValue("@end", acc.Endtime);
           cmd.Parameters.AddWithValue("@place", acc.Idplace);

           SqlDataAdapter da = new SqlDataAdapter(cmd);
           DataTable dt = new DataTable();
           da.Fill(dt);
           if (dt.Rows.Count > 0)
           {
               con.Close();
               return 2;
           }
           else
           {
               SqlCommand cmd2 = new SqlCommand("insert into Schedule(Day, Starttime, Endtime, id_place) values(@day, @start, @end, @place)", con);
               cmd2.Parameters.AddWithValue("@day", acc.Day);
               cmd2.Parameters.AddWithValue("@start", acc.Starttime);
               cmd2.Parameters.AddWithValue("@end", acc.Endtime);
               cmd2.Parameters.AddWithValue("@place", acc.Idplace);

               int result = cmd2.ExecuteNonQuery();
               if (result == 1)
               {
                   con.Close();
                   return 1;
               }
               else
               {
                   con.Close();
                   return 0;
               }    
           }
           
       }

       public List<Account> doLoginUser(string username, string password) {
           List<Account> place = new List<Account>();
           {
               con.Open();
               SqlCommand cmd = new SqlCommand("select * from Account where Username=@username AND Password=@password", con);
               cmd.Parameters.AddWithValue("@username", username);
               cmd.Parameters.AddWithValue("@password", password);
               SqlDataAdapter da = new SqlDataAdapter(cmd);
               DataTable dt = new DataTable();
               da.Fill(dt);
               if (dt.Rows.Count > 0)
               {
                   for (int i = 0; i < dt.Rows.Count; i++)
                   {
                       Account customerInfo = new Account();
                       customerInfo.Id = dt.Rows[i]["id"].ToString();
                       customerInfo.Name = dt.Rows[i]["Name"].ToString();
                       customerInfo.Nim = dt.Rows[i]["Nim"].ToString();
                       customerInfo.Job = dt.Rows[i]["Status"].ToString();
                       place.Add(customerInfo);
                   }
               }
               con.Close();
           }

           return place;
       }

       public int doInsertUsers(Account acc) {
           con.Open();
           SqlCommand cmd = new SqlCommand("insert into Account(Nim, Name, Gender, Address, Phonenumber, Faculty, Major, Batch, Username, Password, Status) values(@nim, @name, @gender, @address, @phone, @faculty, @major, @batch, @username, @password, @status)", con);
           cmd.Parameters.AddWithValue("@nim", acc.Nim);
           cmd.Parameters.AddWithValue("@name", acc.Name);
           cmd.Parameters.AddWithValue("@gender", acc.Gender);
           cmd.Parameters.AddWithValue("@address", acc.Address);
           cmd.Parameters.AddWithValue("@phone", acc.PhoneNumber);
           cmd.Parameters.AddWithValue("@faculty", acc.Faculty);
           cmd.Parameters.AddWithValue("@major", acc.Major);
           cmd.Parameters.AddWithValue("@batch", acc.Batch);
           cmd.Parameters.AddWithValue("@username", acc.Username);
           cmd.Parameters.AddWithValue("@password", acc.Password);
           cmd.Parameters.AddWithValue("@status", "Users");

           int result = cmd.ExecuteNonQuery();
           if (result == 1)
           {
               con.Close();
               return 1;
           }
           else
           {
               con.Close();
               return 0;
           }
       }

       public int doInsertScheduleUKM(UKMSchedule acc) {
           con.Open();
           SqlCommand cmd = new SqlCommand("select * from UKMSchedule where id_schedule = @schedule", con);
           cmd.Parameters.AddWithValue("@schedule", acc.IdSchedule);

           SqlDataAdapter da = new SqlDataAdapter(cmd);
           DataTable dt = new DataTable();
           da.Fill(dt);
           if (dt.Rows.Count > 0)
           {
               con.Close();
               return 2;
           }
           else
           {
               SqlCommand cmd2 = new SqlCommand("insert into UKMSchedule(id_ukm, id_schedule) values(@ukm, @schedule)", con);
               cmd2.Parameters.AddWithValue("@ukm", acc.IdUkm);
               cmd2.Parameters.AddWithValue("@schedule", acc.IdSchedule);

               int result = cmd2.ExecuteNonQuery();
               if (result == 1)
               {
                   con.Close();
                   return 1;
               }
               else
               {
                   con.Close();
                   return 0;
               }
           }
       }

       public int doInsertCaptainSchedule(UKMSchedule acc)
       {
           con.Open();
           SqlCommand cmd = new SqlCommand("select * from UKMSchedule where id_schedule = @schedule", con);
           cmd.Parameters.AddWithValue("@schedule", acc.IdSchedule);

           SqlDataAdapter da = new SqlDataAdapter(cmd);
           DataTable dt = new DataTable();
           da.Fill(dt);
           if (dt.Rows.Count > 0)
           {
               con.Close();
               return 2;
           }
           else
           {
               SqlCommand cmd2 = new SqlCommand("insert into UKMSchedule(id_ukm, id_schedule) values(@ukm, @schedule)", con);
               cmd2.Parameters.AddWithValue("@ukm", acc.IdUkm);
               cmd2.Parameters.AddWithValue("@schedule", acc.IdSchedule);

               int result = cmd2.ExecuteNonQuery();
               if (result == 1)
               {
                   con.Close();
                   return 1;
               }
               else
               {
                   con.Close();
                   return 0;
               }
           }
       }

        //convert id akun jadi id ukm
       public string convertidakun(string ukm) {
           string hasil = "";
           con.Open();
           SqlCommand cmd = new SqlCommand("select * from StudentUKM where id_account=@id", con);
           cmd.Parameters.AddWithValue("@id", ukm);
           SqlDataAdapter da = new SqlDataAdapter(cmd);
           DataTable dt = new DataTable();
           da.Fill(dt);
           if (dt.Rows.Count > 0)
           {
               for (int i = 0; i < dt.Rows.Count; i++)
               {
                   hasil = dt.Rows[i]["id_ukm"].ToString();
               }
           }
           con.Close();
           return hasil;
       }

        //schedule untuk captain
       public List<CustomSchedule> GetScheduleCaptain(string Name) {
           List<CustomSchedule> schedule = new List<CustomSchedule>();
           {
               con.Open();
               SqlCommand cmd = new SqlCommand("select c.id,b.Day,b.Starttime,b.Endtime,a.Ukmname,d.Placename from UKM a, Schedule b, UKMSchedule c, Place d where c.id_ukm = a.id and c.id_schedule=b.id and b.id_place=d.id and a.id=@ids", con);
               cmd.Parameters.AddWithValue("@ids", Name);
               SqlDataAdapter da = new SqlDataAdapter(cmd);
               DataTable dt = new DataTable();
               da.Fill(dt);
               if (dt.Rows.Count > 0)
               {
                   for (int i = 0; i < dt.Rows.Count; i++)
                   {
                       CustomSchedule customerInfo = new CustomSchedule();
                       customerInfo.Id = dt.Rows[i]["id"].ToString();
                       customerInfo.Day = dt.Rows[i]["Day"].ToString();
                       customerInfo.Starttime = dt.Rows[i]["Starttime"].ToString();
                       customerInfo.Endtime = dt.Rows[i]["Endtime"].ToString();
                       customerInfo.Ukmname = dt.Rows[i]["Ukmname"].ToString();
                       customerInfo.Place = dt.Rows[i]["Placename"].ToString();
                       schedule.Add(customerInfo);
                   }
               }
               con.Close();
           }

           return schedule;
       }

       public int doDeleteScheduleCaptain(string id) {
           con.Open();
           SqlCommand cmd = new SqlCommand("delete from UKMSchedule where id=@id", con);
           cmd.Parameters.AddWithValue("@id", id);

           int result = cmd.ExecuteNonQuery();
           if (result == 1)
           {
               con.Close();
               return 1;
           }
           else
           {
               con.Close();
               return 0;
           }
       }

        //mengambil data schedule user
       public List<CustomSchedule> GetScheduleUser()
       {
           List<CustomSchedule> schedule = new List<CustomSchedule>();
           {
               con.Open();
               SqlCommand cmd = new SqlCommand("select c.id,b.Day,b.Starttime,b.Endtime,a.Ukmname,d.Placename from UKM a, Schedule b, UKMSchedule c, Place d where c.id_ukm = a.id and c.id_schedule=b.id and b.id_place=d.id", con);
               SqlDataAdapter da = new SqlDataAdapter(cmd);
               DataTable dt = new DataTable();
               da.Fill(dt);
               if (dt.Rows.Count > 0)
               {
                   for (int i = 0; i < dt.Rows.Count; i++)
                   {
                       CustomSchedule customerInfo = new CustomSchedule();
                       customerInfo.Id = dt.Rows[i]["id"].ToString();
                       customerInfo.Day = dt.Rows[i]["Day"].ToString();
                       customerInfo.Starttime = dt.Rows[i]["Starttime"].ToString();
                       customerInfo.Endtime = dt.Rows[i]["Endtime"].ToString();
                       customerInfo.Ukmname = dt.Rows[i]["Ukmname"].ToString();
                       customerInfo.Place = dt.Rows[i]["Placename"].ToString();
                       schedule.Add(customerInfo);
                   }
               }
               con.Close();
           }

           return schedule;
       }

       public int doInsertDaftarUKM(StudentUKM acc) {
           con.Open();
           SqlCommand cmd = new SqlCommand("insert into StudentUKM(id_account, id_ukm, Status) values(@account, @ukm, @status)", con);
           cmd.Parameters.AddWithValue("@account", acc.IdAccount);
           cmd.Parameters.AddWithValue("@ukm", acc.Ukmid);
           cmd.Parameters.AddWithValue("@status", "Pending");

           int result = cmd.ExecuteNonQuery();
           if (result == 1)
           {
               con.Close();
               return 1;
           }
           else
           {
               con.Close();
               return 0;
           }
       }

       public List<Account> GetAllUser(string name) {
           List<Account> captain = new List<Account>();
           {
               con.Open();
               SqlCommand cmd = new SqlCommand("select b.id,a.Name, a.Nim, a.Faculty, a.Major, a.Batch, b.Status from Account a, StudentUKM b where a.id = b.id_account and a.Status=@status and b.id_ukm=@ukm", con);
               cmd.Parameters.AddWithValue("@ukm", name);
               cmd.Parameters.AddWithValue("@status", "Users");
               SqlDataAdapter da = new SqlDataAdapter(cmd);
               DataTable dt = new DataTable();
               da.Fill(dt);
               if (dt.Rows.Count > 0)
               {
                   for (int i = 0; i < dt.Rows.Count; i++)
                   {
                       Account customerInfo = new Account();
                       customerInfo.Id = dt.Rows[i]["id"].ToString();
                       customerInfo.Nim = dt.Rows[i]["Nim"].ToString();
                       customerInfo.Name = dt.Rows[i]["Name"].ToString();
                       customerInfo.Faculty = dt.Rows[i]["Faculty"].ToString();
                       customerInfo.Major = dt.Rows[i]["Major"].ToString();
                       customerInfo.Batch = dt.Rows[i]["Batch"].ToString();
                       customerInfo.Job = dt.Rows[i]["Status"].ToString();
                       captain.Add(customerInfo);
                   }
               }
               con.Close();
           }

           return captain;
       }

       public int doUpdateStatusUser(string acc, string status) {
           con.Open();
           SqlCommand cmd = new SqlCommand("update StudentUKM set Status=@status where id=@id", con);
           cmd.Parameters.AddWithValue("@status", acc);
           cmd.Parameters.AddWithValue("@id", acc);

           int result = cmd.ExecuteNonQuery();
           if (result == 1)
           {
               con.Close();
               return 1;
           }
           else
           {
               con.Close();
               return 0;
           }
       }

        public int doInsertTimeline(Timeline acc){
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Timeline(id_ukm, pesan) values(@ukm, @pesan)", con);
            cmd.Parameters.AddWithValue("@ukm", acc.IdUkm);
            cmd.Parameters.AddWithValue("@pesan", acc.Pesan);

            int result = cmd.ExecuteNonQuery();
            if (result == 1)
            {
                con.Close();
                return 1;
            }
            else
            {
                con.Close();
                return 0;
            }
        }

        public int doDEleteTimeline(string id) {
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from Timeline where id=@id", con);
            cmd.Parameters.AddWithValue("@id", id);

            int result = cmd.ExecuteNonQuery();
            if (result == 1)
            {
                con.Close();
                return 1;
            }
            else
            {
                con.Close();
                return 0;
            }
        }

        public List<Timeline> GetTimelineCaptain(string Name) {
            List<Timeline> timeline = new List<Timeline>();
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select a.id,b.Ukmname,a.pesan from Timeline a, UKM b where a.id_ukm = b.id and b.id=@id", con);
                cmd.Parameters.AddWithValue("@id", Name);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Timeline customerInfo = new Timeline();
                        customerInfo.Id = dt.Rows[i]["id"].ToString();
                        customerInfo.IdUkm = dt.Rows[i]["Ukmname"].ToString();
                        customerInfo.Pesan = dt.Rows[i]["Pesan"].ToString();
                        timeline.Add(customerInfo);
                    }
                }
                con.Close();
            }

            return timeline;
        }

        //public List<StudentUKM> GetListUKMUsers(string Name) { 
        
        //}

    }
}
