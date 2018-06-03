using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace UKMService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        //untuk admin

        //bagian login
        [OperationContract]
        int doLoginAdmin(string username, string password);

        //bagian captain
        [OperationContract]
        int doDeleteAdmin(string id);

        [OperationContract]
        int doUpdateAdmin(Account acc);

        [OperationContract]
        string convertukm(string ukm);

        [OperationContract]
        List<Account> GetCaptain(string Name);

        [OperationContract]
        int doInsertCaptainAdmin(Account acc, StudentUKM ukm);

        //bagian coach
        [OperationContract]
        int doDeleteCoach(string id);

        [OperationContract]
        int doUpdateCoach(Coach acc);

        [OperationContract]
        string convertcoach(string ukm);

        [OperationContract]
        List<Coach> GetCoach(string Name);

        [OperationContract]
        int doInsertCoach(Coach acc);

        //bagian UKM
        [OperationContract]
        int doDeleteUKM(string id);

        [OperationContract]
        int doUpdateUKM(cUkm acc);

        [OperationContract]
        List<cUkm> GetUKM(string Name);

        [OperationContract]
        int doInsertUKM(cUkm acc);

        //bagian place
        [OperationContract]
        int doDeletePlace(string id);

        [OperationContract]
        int doUpdatePlace(Place acc);

        [OperationContract]
        string convertplace(string place);

        [OperationContract]
        string convertidplace(string place);

        [OperationContract]
        List<Place> GetPlace(string Name);

        [OperationContract]
        int doInsertPlace(Place acc);

        //bagian schedule
        [OperationContract]
        int doDeleteSchedule(string id);

        [OperationContract]
        int doUpdateSchedule(Schedule acc);

        [OperationContract]
        List<Schedule> GetSchedule(string Name);

        [OperationContract]
        int doInsertSchedule(Schedule acc);

        //bagian user
        //bagian login
        [OperationContract]
        List<Account> doLoginUser(string username, string password);

        //bagian mahasiswa

        //bagian regis
        [OperationContract]
        int doInsertUsers(Account acc);

        //captain menambah schedule
        [OperationContract]
        int doInsertScheduleUKM(UKMSchedule acc);

        //mengambil idukm dari akun
        [OperationContract]
        string convertidakun(string ukm);

        //mengambil data schedule buat captain
        [OperationContract]
        List<CustomSchedule> GetScheduleCaptain(string Name);

        //captain mendelete schedule
        [OperationContract]
        int doDeleteScheduleCaptain(string id);

        //mengambil data schedule untuk user
        [OperationContract]
        List<CustomSchedule> GetScheduleUser();

        //user mendaftar UKM
        [OperationContract]
        int doInsertDaftarUKM(StudentUKM acc);

        //captain view user
        [OperationContract]
        List<Account> GetAllUser(string name);

        //ubah status
        [OperationContract]
        int doUpdateStatusUser(string acc, string status);

        //untuk timeline

        //menambah timeline
        [OperationContract]
        int doInsertTimeline(Timeline acc);

        //menghapus timeline
        [OperationContract]
        int doDEleteTimeline(string id);

        //melihat timeline
        [OperationContract]
        List<Timeline> GetTimelineCaptain(string Name);

        //list ukm yg diikuti
        [OperationContract]
        List<StudentUKM> GetListUKMUsers(string Name);
        
    }

    [DataContract]
    public class Timeline {
        string id = string.Empty;
        string idUkm = string.Empty;
        string pesan = string.Empty;

        [DataMember]
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        [DataMember]
        public string IdUkm
        {
            get { return idUkm; }
            set { idUkm = value; }
        }

        [DataMember]
        public string Pesan
        {
            get { return pesan; }
            set { pesan = value; }
        }
    }

    [DataContract]
    public class CustomSchedule {
        string id = string.Empty;
        string day = string.Empty;
        string starttime = string.Empty;
        string endtime = string.Empty;
        string ukmname = string.Empty;
        string place = string.Empty;

        [DataMember]
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        [DataMember]
        public string Day
        {
            get { return day; }
            set { day = value; }
        }

        [DataMember]
        public string Starttime
        {
            get { return starttime; }
            set { starttime = value; }
        }

        [DataMember]
        public string Endtime
        {
            get { return endtime; }
            set { endtime = value; }
        }

        [DataMember]
        public string Ukmname
        {
            get { return ukmname; }
            set { ukmname = value; }
        }

        [DataMember]
        public string Place
        {
            get { return place; }
            set { place = value; }
        }
    }

    [DataContract]
    public class UKMSchedule {
        string id = string.Empty;
        string idUkm = string.Empty;
        string idSchedule = string.Empty;

        [DataMember]
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        [DataMember]
        public string IdUkm
        {
            get { return idUkm; }
            set { idUkm = value; }
        }

        [DataMember]
        public string IdSchedule
        {
            get { return idSchedule; }
            set { idSchedule = value; }
        }
    }

    [DataContract]
    public class Schedule {
        string id = string.Empty;
        string day = string.Empty;
        string starttime = string.Empty;
        string endtime = string.Empty;
        string idplace = string.Empty;

        [DataMember]
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        [DataMember]
        public string Day
        {
            get { return day; }
            set { day = value; }
        }

        [DataMember]
        public string Starttime
        {
            get { return starttime; }
            set { starttime = value; }
        }

        [DataMember]
        public string Endtime
        {
            get { return endtime; }
            set { endtime = value; }
        }

        [DataMember]
        public string Idplace
        {
            get { return idplace; }
            set { idplace = value; }
        }
        
    }

    [DataContract]
    public class Place {
        string id = string.Empty;
        string name = string.Empty;

        [DataMember]
        public string Id {
            get { return id; }
            set { id = value; }
        }

        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
    [DataContract]
    public class cUkm {
        string ukmname = string.Empty;
        string desc = string.Empty;
        string idcoach = string.Empty;
        string id = string.Empty;

        [DataMember]
        public string Ukmname {
            get { return ukmname; }
            set { ukmname = value; }
        }

        [DataMember]
        public string Desc
        {
            get { return desc; }
            set { desc = value; }
        }

        [DataMember]
        public string Idcoach
        {
            get { return idcoach; }
            set { idcoach = value; }
        }

        [DataMember]
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
    }

    [DataContract]
    public class Coach {
        string id = string.Empty;
        string name = string.Empty;
        string gender = string.Empty;
        string address = string.Empty;
        string phone = string.Empty;

        [DataMember]
        public string Id {
            get { return id; }
            set{ id=value; }
        }

        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [DataMember]
        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        [DataMember]
        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        [DataMember]
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
    }

    [DataContract]
    public class StudentUKM {
        string id = string.Empty; 
        string idAccount = string.Empty;
        string ukmid = string.Empty;
        string status = string.Empty;

        [DataMember]
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        [DataMember]
        public string IdAccount
        {
            get { return idAccount; }
            set { idAccount = value; }
        }

        [DataMember]
        public string Ukmid
        {
            get { return ukmid; }
            set { ukmid = value; }
        }

        [DataMember]
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
    }

    [DataContract]
    public class Account {
        string id = string.Empty;
        string nim = string.Empty;
        string name = string.Empty;
        string gender = string.Empty;
        string address = string.Empty;
        string phoneNumber = string.Empty;
        string faculty = string.Empty;
        string major = string.Empty;
        string batch = string.Empty;
        string username = string.Empty;
        string password = string.Empty;
        string job = string.Empty;

        [DataMember]
        public string Id {
            get { return id; }
            set { id = value; }
        }

        [DataMember]
        public string Nim
        {
            get { return nim; }
            set { nim = value; }
        }

        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [DataMember]
        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        [DataMember]
        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        [DataMember]
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        [DataMember]
        public string Faculty
        {
            get { return faculty; }
            set { faculty = value; }
        }

        [DataMember]
        public string Major
        {
            get { return major; }
            set { major = value; }
        }

        [DataMember]
        public string Batch
        {
            get { return batch; }
            set { batch = value; }
        }

        [DataMember]
        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        [DataMember]
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        [DataMember]
        public string Job
        {
            get { return job; }
            set { job = value; }
        }
    }
    
}
