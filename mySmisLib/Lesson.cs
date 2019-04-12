using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace mySmisLib
{
    public class Lesson
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ModuleID { get; set; }
        public int ClassID { get; set; }
        public string ClassName { get; set; }
        public string ModuleName { get; set; }
        public int Active { get; set; }
        public string Code { get; set; }
        public int Credit { get; set; }
        public string Type { get; set; }
        public Lesson() { }

    }
    public class LessonService
    {
        public bool insertLesson(Lesson insLesson,string userID)
            {
                bool result = false;
                MySqlConnection con = new MySqlConnection(DbCon.connectionString);
                string sqlInsert = "INSERT INTO `studentlessons`( `classID`, `moduleID`, `title`, `description`,`code`,`credit`,`type`) VALUES (@classID,@moduleID,@title,@description,@code,@credit,@type)";
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sqlInsert, con);
                cmd.Parameters.AddWithValue("@classID", insLesson.ClassID);
                cmd.Parameters.AddWithValue("@title", insLesson.Title);
                cmd.Parameters.AddWithValue("@description", insLesson.Description);
                cmd.Parameters.AddWithValue("@moduleID", insLesson.ModuleID);
                cmd.Parameters.AddWithValue("@code",insLesson.Code);
                cmd.Parameters.AddWithValue("@credit",insLesson.Credit);
                cmd.Parameters.AddWithValue("@type",insLesson.Type);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    result = true;
                }
                con.Close();
                return result;
            }

        public bool updateLesson(Lesson upLesson,string userID)
            {
                bool result = false;
                MySqlConnection con = new MySqlConnection(DbCon.connectionString);
                string sqlInsert = "UPDATE `studentlessons` SET `classID`=@classID,`moduleID`=@moduleID,`title`=@title,`description`=@description,`code`= @code , `credit` = @credit,`type`= @type WHERE id = @id";
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sqlInsert, con);
                cmd.Parameters.AddWithValue("@classID", upLesson.ClassID);
                cmd.Parameters.AddWithValue("@title", upLesson.Title);
                cmd.Parameters.AddWithValue("@description", upLesson.Description);
                cmd.Parameters.AddWithValue("@moduleID", upLesson.ModuleID);
                cmd.Parameters.AddWithValue("@id", upLesson.ID);
                cmd.Parameters.AddWithValue("@code", upLesson.Code);
                cmd.Parameters.AddWithValue("@credit", upLesson.Credit);
                cmd.Parameters.AddWithValue("@type", upLesson.Type);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    result = true;
                }
                con.Close();
                return result;
            }

        public bool deleteLesson(int delLesson,string userID)
            {
                bool result = false;
                MySqlConnection con = new MySqlConnection(DbCon.connectionString);
                string sqlInsert = "UPDATE `studentlessons` SET `active`= 0 WHERE id = @id";
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sqlInsert, con);
                cmd.Parameters.AddWithValue("@id", delLesson);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    result = true;
                }
                con.Close();
                return result;
            }

        public List<Lesson> GetAllLessons(string userID)
        {
            List<Lesson> listMod = new List<Lesson>();
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            string sqlInsert = "SELECT `id`, `classID`, `moduleID`, `title`, `description`, `active`, `code`, `credit`,`type` FROM `studentlessons` WHERE `active` = 1";
            MySqlDataReader dr = null;
            MySqlCommand cmd;
            con.Open();
            cmd = new MySqlCommand(sqlInsert, con);
            dr = cmd.ExecuteReader();

            while (dr.Read()) //iterate through the records in the result dataset
            {
                Lesson Mod = new Lesson();
                Mod.ID = dr.GetInt32(0);
                Mod.ClassID = dr.GetInt32(1);
                Mod.ModuleID = dr.GetInt32(2);
                Mod.Title = dr.GetString(3);
                Mod.Description = dr.GetString(4);
                Mod.Active = dr.GetInt32(5);
                Mod.Code = dr.GetString(6);
                Mod.Credit = dr.GetInt32(7);
                Mod.Type = dr.GetString(8);
                listMod.Add(Mod);
            }


            con.Close();
            return listMod;
        }

        public List<Lesson> GetAllLessonsByClassID(int classID,string userID)
        {
            List<Lesson> listMod = new List<Lesson>();
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            string sqlInsert = "SELECT `id`, `classID`, `moduleID`, `title`, `description`, `active`, `code`, `credit`,`type` FROM `studentlessons` WHERE `active` = 1 AND `classID` = @classID ";
            MySqlDataReader dr = null;
            MySqlCommand cmd;
            con.Open();
            cmd = new MySqlCommand(sqlInsert, con);
            cmd.Parameters.AddWithValue("@ClassID", classID);
            dr = cmd.ExecuteReader();

            while (dr.Read()) //iterate through the records in the result dataset
            {
                Lesson Mod = new Lesson();
                Mod.ID = dr.GetInt32(0);
                Mod.ClassID = dr.GetInt32(1);
                Mod.ModuleID = dr.GetInt32(2);
                Mod.Title = dr.GetString(3);
                Mod.Description = dr.GetString(4);
                Mod.Active = dr.GetInt32(5);
                Mod.Code = dr.GetString(6);
                Mod.Credit = dr.GetInt32(7);
                Mod.Type = dr.GetString(8);
                listMod.Add(Mod);
            }


            con.Close();
            return listMod;
        }

        public List<Lesson> GetAllLessonsNotInList(string lessonIds, int classId,string userID)
        {
            List<Lesson> listMod = new List<Lesson>();
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            string sqlInsert = string.Format("SELECT `id`, `classID`, `moduleID`, `title`, `description`, `active`, `code`, `credit`,`type` FROM `studentlessons` WHERE `active` = 1 AND classID = {1} AND `id` NOT IN ({0})", lessonIds,classId);
            MySqlDataReader dr = null;
            MySqlCommand cmd;
            con.Open();
            cmd = new MySqlCommand(sqlInsert, con);
            //cmd.Parameters.AddWithValue("@ClassID", classID);
            dr = cmd.ExecuteReader();

            while (dr.Read()) //iterate through the records in the result dataset
            {
                Lesson Mod = new Lesson();
                Mod.ID = dr.GetInt32(0);
                Mod.ClassID = dr.GetInt32(1);
                Mod.ModuleID = dr.GetInt32(2);
                Mod.Title = dr.GetString(3);
                Mod.Description = dr.GetString(4);
                Mod.Active = dr.GetInt32(5);
                Mod.Code = dr.GetString(6);
                Mod.Credit = dr.GetInt32(7);
                Mod.Type = dr.GetString(8);
                listMod.Add(Mod);
            }


            con.Close();
            return listMod;
        }
        public List<Lesson> GetAllLessonClassModule(string userID)
        {
            List<Lesson> listMod = new List<Lesson>();
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            string sqlInsert = "SELECT studentlessons.id,studentlessons.classID,studentlessons.moduleID,studentlessons.title,studentlessons.description,studentlessons.active,studentcourses.title AS classTitle,studentprograms.moduleName, studentlessons.code, studentlessons.credit,studentlessons.type FROM studentlessons LEFT JOIN studentcourses ON studentlessons.classID = studentcourses.id LEFT JOIN studentprograms ON studentcourses.moduleID = studentprograms.id WHERE studentlessons.active = 1";
            MySqlDataReader dr = null;
            MySqlCommand cmd;
            con.Open();
            cmd = new MySqlCommand(sqlInsert, con);
            dr = cmd.ExecuteReader();

            while (dr.Read()) //iterate through the records in the result dataset
            {
                Lesson Mod = new Lesson();
                Mod.ID = dr.GetInt32(0);
                Mod.ClassID = dr.GetInt32(1);
                Mod.ModuleID = dr.GetInt32(2);
                Mod.Title = dr.GetString(3);
                Mod.Description = dr.GetString(4);
                Mod.Active = dr.GetInt32(5);
                Mod.ClassName = dr.GetString(6);
                Mod.ModuleName = dr.GetString(7);
                Mod.Code = dr.GetString(8);
                Mod.Credit = dr.GetInt32(9);
                Mod.Type = dr.GetString(10);
                listMod.Add(Mod);
            }


            con.Close();
            return listMod;
        }
    }  
}

