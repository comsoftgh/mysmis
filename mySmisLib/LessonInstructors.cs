using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace mySmisLib
{
   public class LessonInstructors
    {
        public int ID { get; set; }
        public string TutorID { get; set; }
        public DateTime DateAssigned { get; set; }
        public int ClassID { get; set; }
        public string LessonTitle { get; set; }
        public string LessonDescription { get; set; }
        public string TutorName { get; set; }
        public int ModuleID { get; set; }
        public int LessonID { get; set; }
        public DateTime LastModified { get; set; }
        public string Code { get; set; }
        public int Credit { get; set; }
        public string Type { get; set; }
        public string SName { get; set; }
        public string FName { get; set; }
        public string ONames { get; set; }
        
        


        public LessonInstructors() { }

    }

    public class LessonInstructorServices
    {

        public bool AddLessonInstructor(LessonInstructors insLessInstr, string userID)
        {
            bool result = false;
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            string sqlInsert = "INSERT INTO `studentlessonsinstructors`( `lessonID`, `instructorID`, `createdDate`, `lastModified`) VALUES (@lessonID,@instructorID,@createdDate,@lastModified)";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sqlInsert, con);
            cmd.Parameters.AddWithValue("@lessonID", insLessInstr.LessonID);
            cmd.Parameters.AddWithValue("@instructorID", insLessInstr.TutorID);
            cmd.Parameters.AddWithValue("@createdDate", insLessInstr.DateAssigned);
            cmd.Parameters.AddWithValue("@lastModified", insLessInstr.LastModified);
                int affectedrows = cmd.ExecuteNonQuery();
                if (affectedrows > 0)
                {
                    result = true; 
                }
                con.Close();
                return result;
        }
        public List<LessonInstructors> GetAllLessonInstructorsByLessonID(int lessonID,string userID)
        {
            List<LessonInstructors> listMod = new List<LessonInstructors>();
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            string sqlInsert = "SELECT studentlessons.id,studentlessons.classID,studentlessons.moduleID,studentlessons.title,studentlessons.description,studentlessons.`code`,studentlessons.type,studentlessons.credit,IFNULL(tutors.fname,'Assign a Teaching Staff') AS fname,IFNULL(tutors.onames,'Assign a Teaching Staff') AS onames,IFNULL(tutors.sname,'Assign a Teaching Staff') AS sname,IFNULL(tutors.userId,'0') AS tutorId,studentlessonsinstructors.id AS lesstutorId FROM studentlessons INNER JOIN studentlessonsinstructors ON studentlessons.id = studentlessonsinstructors.lessonID INNER JOIN tutors ON tutors.userId = studentlessonsinstructors.instructorID WHERE studentlessonsinstructors.lessonID = @lessonID ";
            MySqlDataReader dr = null;
            MySqlCommand cmd;
            con.Open();
            cmd = new MySqlCommand(sqlInsert, con);
            cmd.Parameters.AddWithValue("@lessonID",lessonID);
            dr = cmd.ExecuteReader();

            while (dr.Read()) //iterate through the records in the result dataset
            {
                LessonInstructors Mod = new LessonInstructors();
                Mod.LessonID = dr.GetInt32(0);
                Mod.ClassID = dr.GetInt32(1);
                Mod.ModuleID = dr.GetInt32(2);
                Mod.LessonTitle = dr.GetString(3);
                Mod.LessonDescription = dr.GetString(4);
                Mod.Code = dr.GetString(5);
                Mod.Type = dr.GetString(6);
                Mod.Credit = dr.GetInt32(7);
                Mod.FName = dr.GetString(8);
                Mod.ONames = dr.GetString(9);
                Mod.SName = dr.GetString(10);
                Mod.TutorID = dr.GetString(11);
                Mod.ID = dr.GetInt32(12);
                if (dr.GetString(8) == "Assign a Teaching Staff") { Mod.TutorName = "Assign a Teaching Staff"; } else { Mod.TutorName = dr.GetString(8) + " " + dr.GetString(10); }
                listMod.Add(Mod);
            }


            con.Close();
            return listMod;
        }
        public List<LessonInstructors> GetAllLessonInstructors(string userID)
        {
            List<LessonInstructors> listMod = new List<LessonInstructors>();
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            string sqlInsert = "SELECT studentlessons.id,studentlessons.classID,studentlessons.moduleID,studentlessons.title,studentlessons.description,studentlessons.`code`,studentlessons.type,studentlessons.credit,IFNULL(tutors.fname,'Add Teaching Staff') AS fname,IFNULL(tutors.onames,'Add Teaching Staff') AS onames,IFNULL(tutors.sname,'Add Teaching Stafff') AS sname,IFNULL(tutors.userId,'0') AS tutorId,studentlessonsinstructors.id AS lesstutorId FROM studentlessons INNER JOIN studentlessonsinstructors ON studentlessons.id = studentlessonsinstructors.lessonID INNER JOIN tutors ON tutors.userId = studentlessonsinstructors.instructorID ";
            MySqlDataReader dr = null;
            MySqlCommand cmd;
            con.Open();
            cmd = new MySqlCommand(sqlInsert, con);
            
            dr = cmd.ExecuteReader();

            while (dr.Read()) //iterate through the records in the result dataset
            {
                LessonInstructors Mod = new LessonInstructors();
                Mod.LessonID = dr.GetInt32(0);
                Mod.ClassID = dr.GetInt32(1);
                Mod.ModuleID = dr.GetInt32(2);
                Mod.LessonTitle = dr.GetString(3);
                Mod.LessonDescription = dr.GetString(4);
                Mod.Code = dr.GetString(5);
                Mod.Type = dr.GetString(6);
                Mod.Credit = dr.GetInt32(7);
                Mod.FName = dr.GetString(8);
                Mod.ONames = dr.GetString(9);
                Mod.SName = dr.GetString(10);
                Mod.TutorID = dr.GetString(11);
                Mod.ID = dr.GetInt32(12);
                if (dr.GetString(8) == "Assign a Teaching Staff") { Mod.TutorName = "Assign a Teaching Staff"; } else { Mod.TutorName = dr.GetString(8) + " " + dr.GetString(10); }
                
                listMod.Add(Mod);
            }


            con.Close();
            return listMod;
        }
        public bool UpdateLessonInstructor(LessonInstructors upLessInstr)
        {
            bool result = false;
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            string sqlUpdate = "UPDATE `studentlessonsinstructors` SET `lessonID`=@lessonID,`instructorID`=@instructorID,`lastModified`=@lastModified WHERE id = @lessonID";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sqlUpdate, con);
            cmd.Parameters.AddWithValue("@lessonID", upLessInstr.LessonID);
            cmd.Parameters.AddWithValue("@instructorID", upLessInstr.TutorID);
            cmd.Parameters.AddWithValue("@lastModified", upLessInstr.LastModified);
            if (cmd.ExecuteNonQuery() > 0)
            {
                result = true;
            }
            con.Close();
            return result;
        }
        public bool DeleteLessonInstructor(int delLessInstr, string userID)
        {
            bool result = false;
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            string sqlUpdate = "delete from studentlessonsInstructors WHERE id=@lessonID";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sqlUpdate, con);
            cmd.Parameters.AddWithValue("@lessonID", delLessInstr);
            if (cmd.ExecuteNonQuery() > 0)
            {
                result = true;
            }
            con.Close();
            return result;
        }
        public bool IsLessonInstructorExit(int lessonId,string instructorID) 
        {
            bool results = false;
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            string sqlUpdate = "SELECT * FROM studentlessonsInstructors WHERE studentlessonsinstructors.lessonID = @lessonID AND studentlessonsinstructors.instructorID = @instructorID";
            con.Open();
            MySqlDataReader dr = null;
            MySqlCommand cmd = new MySqlCommand(sqlUpdate, con);
            cmd.Parameters.AddWithValue("@lessonID", lessonId);
            cmd.Parameters.AddWithValue("@instructorID", instructorID);
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                results = true;
            }
            con.Close();
            return results;
        }
    }
}
