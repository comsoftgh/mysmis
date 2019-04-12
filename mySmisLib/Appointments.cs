using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace mySmisLib
{
    public class Appointments
    {
        public int ID { get; set; }
        public int Type { get; set; }
        public int AllDay { get; set; }
        public string Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public int Label { get; set; }
        public int ResourceId { get; set; }
        public string ResourceIds { get; set; }
        public string ReminderInfo { get; set; }
        public string ResourceInfo { get; set; }
        public string CustomField1 { get; set; }
        

        public Appointments(){}
    }

    public class AppointmentsService
    {
        public bool AddAppointments(Appointments fp, string userID)
        {
            bool result = false;
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            string sqlInsert = "INSERT INTO `feesbatches`(`feecateid`, `batchid`, `feevalue`, `createdate`, `modifydate`,bgroup) VALUES (@feecateid,@batchid,@feevalue,@createdate,@modifydate,@bgroup)";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sqlInsert, con);
            cmd.Parameters.AddWithValue("@feecateid", fp.Type);
            
            if (cmd.ExecuteNonQuery() > 0)
            {
                result = true;
            }
            con.Close();
            return result;
        }
        public bool AddAppointmentsList(string fpList, string userID)
        {
            bool result = false;
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            string sqlInsert = string.Format("INSERT INTO `feesbatches`(`feecateid`, `batchid`, `feevalue`, `createdate`, `modifydate`,bgroup) VALUES {0} ", fpList);
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sqlInsert, con);
            //cmd.Parameters.AddWithValue("@feecateid", fp.FeeCateId);
            //cmd.Parameters.AddWithValue("@batchid", fp.BatchId);
            //cmd.Parameters.AddWithValue("@feevalue", fp.Feevalue);
            //cmd.Parameters.AddWithValue("@createdate", fp.DateCreted);
            //cmd.Parameters.AddWithValue("@modifydate", fp.LastModified);
            if (cmd.ExecuteNonQuery() > 0)
            {
                result = true;
            }
            con.Close();
            return result;
        }
        public bool UpdateAppointments(Appointments fp, string userID)
        {
            bool result = false;
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            string sqlInsert = "UPDATE `feesbatches` SET `feecateid`=@feecateid,`batchid`=@batchid,`feevalue`=@feevalue,`modifydate`=@modifydate bgroup =@bgroup WHERE id = @id";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sqlInsert, con);
            cmd.Parameters.AddWithValue("@feecateid", fp.Type);
            

            if (cmd.ExecuteNonQuery() > 0)
            {
                result = true;
            }
            con.Close();
            return result;
        }
        public bool DeleteAppointments(int fp, string userID)
        {
            bool result = false;
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            string sqlInsert = "DELETE FROM `feesbatches` WHERE id = @id";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sqlInsert, con);
            cmd.Parameters.AddWithValue("@id", fp);
            if (cmd.ExecuteNonQuery() > 0)
            {
                result = true;
            }
            con.Close();
            return result;
        }
        public List<Appointments> GetAllAppointments(string applyto, string userID)
        {
            List<Appointments> retVal = new List<Appointments>();
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            string sqlInsert = "SELECT feescategory.title,feescategory.description,feescategory.applyto,feescategory.id,IFNULL(feesbatches.batchid,0),IFNULL(feesbatches.feevalue, 0),IFNULL(feesbatches.createdate, '0001-01-01 00:00:00'),IFNULL(feesbatches.modifydate, '0001-01-01 00:00:00'),IFNULL(feesbatches.bgroup,''),IFNULL(feesbatches.id, 0) AS feesbid,IFNULL(feesbatches.feecateid,0) AS feecateid,IFNULL(studentcoursesschedule.schdTitle,'') AS schdTitle FROM feescategory LEFT OUTER JOIN feesbatches ON feescategory.id = feesbatches.feecateid LEFT OUTER JOIN studentcoursesschedule ON feesbatches.batchid = studentcoursesschedule.id WHERE feescategory.active = 1 AND feescategory.applyto = @applyto";
            MySqlDataReader dr = null;
            MySqlCommand cmd;
            con.Open();
            cmd = new MySqlCommand(sqlInsert, con);
            cmd.Parameters.AddWithValue("@applyto", applyto);
            dr = cmd.ExecuteReader();

            while (dr.Read()) //iterate through the records in the result dataset
            {
                Appointments Mod = new Appointments();
                
                retVal.Add(Mod);
            }


            con.Close();

            return retVal;
        }
        public List<Appointments> GetAllAppointmentsByBatchid(int batchId, string userID)
        {
            List<Appointments> retVal = new List<Appointments>();
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            string sqlInsert = "SELECT feesbatches.id,feesbatches.feecateid,feesbatches.batchid,feesbatches.feevalue,feesbatches.createdate,feesbatches.modifydate,feesbatches.bgroup,feescategory.title,feescategory.applyto,studentcoursesschedule.schdTitle FROM feesbatches INNER JOIN feescategory ON feesbatches.feecateid = feescategory.id INNER JOIN studentcoursesschedule ON feesbatches.batchid = studentcoursesschedule.id WHERE feesbatches.batchid = @batchId";
            MySqlDataReader dr = null;
            MySqlCommand cmd;
            con.Open();
            cmd = new MySqlCommand(sqlInsert, con);
            cmd.Parameters.AddWithValue("@batchid", batchId);
            dr = cmd.ExecuteReader();

            while (dr.Read()) //iterate through the records in the result dataset
            {
                Appointments Mod = new Appointments();
                Mod.ID = dr.GetInt32(0);
                Mod.Type = dr.GetInt32(1);
               
                Mod.ResourceIds = dr.GetString(9);
                retVal.Add(Mod);
            }


            con.Close();

            return retVal;
        }
    }


    //public class Appointments : BindingList<Appointments>
    //{
    //    public void AddRange(Appointments events)
    //    {
    //        foreach (Appointments customEvent in events)
    //            this.Add(customEvent);
    //    }
    //    public int GetEventIndex(int eventId)
    //    {
    //        for (int i = 0; i < Count; i++)
    //            if (this[i].ID == eventId)
    //                return i;
    //        return -1;
    //    }
    //}

    //public class CustomEventDataSource
    //{
    //    Appointments events;
    //    public CustomEventDataSource(Appointments events)
    //    {
    //        if (events == null)
    //            //DevExpress.XtraScheduler.Native.Exceptions.ThrowArgumentNullException("events");
    //        this.events = events;
    //    }
    //    public CustomEventDataSource()
    //        : this(new Appointments())
    //    {
    //    }
    //    public Appointments Events { get { return events; } set { events = value; } }
    //    public int Count { get { return Events.Count; } }

    //    #region ObjectDataSource methods
    //    public object InsertMethodHandler(Appointments customEvent)
    //    {
    //        int id = customEvent.GetHashCode();
    //        customEvent.ID = id;
    //        Events.Add(customEvent);
    //        return id;
    //    }
    //    public void DeleteMethodHandler(Appointments customEvent)
    //    {
    //        int eventIndex = Events.GetEventIndex(customEvent.ID);
    //        if (eventIndex >= 0)
    //            Events.RemoveAt(eventIndex);
    //    }
    //    public void UpdateMethodHandler(Appointments customEvent)
    //    {
    //        int eventIndex = Events.GetEventIndex(customEvent.ID);
    //        if (eventIndex >= 0)
    //        {
    //            Events.RemoveAt(eventIndex);
    //            Events.Insert(eventIndex, customEvent);
    //        }
    //    }
    //    public IEnumerable SelectMethodHandler()
    //    {
    //        Appointments result = new Appointments();
    //        result.AddRange(Events);
    //        return result;
    //    }
    //    #endregion

    //    public object ObtainLastInsertedId()
    //    {
    //        if (Count < 1)
    //            return null;
    //        return Events[Count - 1].ID;
    //    }
    //}




}
