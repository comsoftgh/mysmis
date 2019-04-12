using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mySmisLib
{
    public class LibraryClassification
    {
        public int ID { get; set; }
        public int IDclassOne { get; set; }
        public int IDclassTwo { get; set; }
        public int IDclassThree { get; set; }
        public string CodeBlock { get; set; }
        public string CodeShelve { get; set; }
        public string CodeStack { get; set; }
        public string TitleBlock { get; set; }
        public string TitleShelve { get; set; }
        public string TitleStack { get; set; }
        public int Active { get; set; }


        public LibraryClassification(){}
    }

    public class LibraryClassificationService
    {
        //public bool AddLibraryClassification(LibraryClassification fp, string userID)
        //{
        //    bool result = false;
        //    MySqlConnection con = new MySqlConnection(DbCon.connectionString);
        //    string sqlInsert = "INSERT INTO `gradesystemvalue`(`gsvpoint`, `gsvgrade`, `gsvlowscore`, `gsvupscore`, `gsvdescription`, `gsvgsid`, `gsvDateCreated`, `gsvLastModified`,gsvgstypeid) VALUES (@gsvpoint,@gsvgrade,@gsvlowscore,@gsvupscore,@gsvdescription,@gsvgsid,@gsvDateCreated,@gsvLastModified,@gsvgstypeid)";
        //    con.Open();
        //    MySqlCommand cmd = new MySqlCommand(sqlInsert, con);
        //    cmd.Parameters.AddWithValue("@gsvpoint", fp.GsPoint);
        //    cmd.Parameters.AddWithValue("@gsvgrade", fp.GsGrade);
        //    cmd.Parameters.AddWithValue("@gsvlowscore", fp.GsLowScore);
        //    cmd.Parameters.AddWithValue("@gsvupscore", fp.GsUpScore);
        //    cmd.Parameters.AddWithValue("@gsvdescription", fp.GSDescription);
        //    cmd.Parameters.AddWithValue("@gsvgsid", fp.GsgsId);
        //    cmd.Parameters.AddWithValue("@gsvDateCreated", fp.GsDateCreated);
        //    cmd.Parameters.AddWithValue("@gsvLastModified", fp.GsLastModified);
        //    cmd.Parameters.AddWithValue("@gsvgstypeid", fp.Gsvgstypeid);
        //    if (cmd.ExecuteNonQuery() > 0)
        //    {
        //        result = true;
        //    }
        //    con.Close();
        //    return result;
        //}
        //public bool UpdateLibraryClassification(LibraryClassification fp, string userID)
        //{
        //    bool result = false;
        //    MySqlConnection con = new MySqlConnection(DbCon.connectionString);
        //    string sqlInsert = "UPDATE `gradesystemvalue` SET `gsvpoint`=@gsvpoint,`gsvgrade`=@gsvgrade,`gsvlowscore`=@gsvlowscore,`gsvupscore`=@gsvupscore,`gsvdescription`=@gsvdescription,`gsvgsid`=@gsvgsid,`gsvLastModified`=@gsvLastModified,gsvgstypeid = @gsvgstypeid WHERE  gsvid = @gsvid";
        //    con.Open();
        //    MySqlCommand cmd = new MySqlCommand(sqlInsert, con);
        //    cmd.Parameters.AddWithValue("@gsvpoint", fp.GsPoint);
        //    cmd.Parameters.AddWithValue("@gsvgrade", fp.GsGrade);
        //    cmd.Parameters.AddWithValue("@gsvlowscore", fp.GsLowScore);
        //    cmd.Parameters.AddWithValue("@gsvupscore", fp.GsUpScore);
        //    cmd.Parameters.AddWithValue("@gsvdescription", fp.GSDescription);
        //    cmd.Parameters.AddWithValue("@gsvgsid", fp.GsgsId);
        //    cmd.Parameters.AddWithValue("@gsvLastModified", fp.GsLastModified);
        //    cmd.Parameters.AddWithValue("@gsvid", fp.GsId);
        //    cmd.Parameters.AddWithValue("@gsvgstypeid", fp.Gsvgstypeid);

        //    if (cmd.ExecuteNonQuery() > 0)
        //    {
        //        result = true;
        //    }
        //    con.Close();
        //    return result;
        //}
        //public bool DeleteLibraryClassification(int fp, string userID)
        //{
        //    bool result = false;
        //    MySqlConnection con = new MySqlConnection(DbCon.connectionString);
        //    string sqlInsert = "DELETE FROM `gradesystemvalue` WHERE gsvid = @gsvid";
        //    con.Open();
        //    MySqlCommand cmd = new MySqlCommand(sqlInsert, con);
        //    cmd.Parameters.AddWithValue("@id", fp);
        //    if (cmd.ExecuteNonQuery() > 0)
        //    {
        //        result = true;
        //    }
        //    con.Close();
        //    return result;
        //}
        public List<LibraryClassification> GetAllLibraryClassOne(int Active,string userID)
        {
            List<LibraryClassification> retVal = new List<LibraryClassification>();
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            string sqlInsert = "SELECT `id`, `code`, `title`, `active` FROM `libraryclassone` WHERE `active` = @active ";
            MySqlDataReader dr = null;
            MySqlCommand cmd;
            con.Open();
            cmd = new MySqlCommand(sqlInsert, con);
            cmd.Parameters.AddWithValue("@active", Active);
            dr = cmd.ExecuteReader();

            while (dr.Read()) //iterate through the records in the result dataset
            {
                LibraryClassification Mod = new LibraryClassification();
                Mod.ID = dr.GetInt32(0);
                Mod.CodeBlock = dr.GetString(1);
                Mod.TitleBlock = dr.GetString(2)+" ( "+ dr.GetString(1) +" )";
                Mod.Active = dr.GetInt32(3);
                retVal.Add(Mod);
            }


            con.Close();

            return retVal;
        }
        public List<LibraryClassification> GetAllLibraryClassTwo(int Active, string userID)
        {
            List<LibraryClassification> retVal = new List<LibraryClassification>();
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            string sqlInsert = "SELECT `id`, `classoneid`, `code`, `title`, `active` FROM `libraryclasstwo` WHERE `active` = @active ";
            MySqlDataReader dr = null;
            MySqlCommand cmd;
            con.Open();
            cmd = new MySqlCommand(sqlInsert, con);
            cmd.Parameters.AddWithValue("@active", Active);
            dr = cmd.ExecuteReader();

            while (dr.Read()) //iterate through the records in the result dataset
            {
                LibraryClassification Mod = new LibraryClassification();
                Mod.ID = dr.GetInt32(0);
                Mod.IDclassOne = dr.GetInt32(1);
                Mod.CodeShelve = dr.GetString(2);
                Mod.TitleShelve = dr.GetString(3) + " ( " + dr.GetString(2) + " )";
                Mod.Active = dr.GetInt32(4);
                retVal.Add(Mod);
            }


            con.Close();

            return retVal;
        }
        public List<LibraryClassification> GetAllLibraryClassTwo(int Active, int classOneId,string userID)
        {
            List<LibraryClassification> retVal = new List<LibraryClassification>();
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            string sqlInsert = "SELECT `id`, `classoneid`, `code`, `title`, `active` FROM `libraryclasstwo` WHERE `active` = @active AND `classoneid` = @classOneId ";
            MySqlDataReader dr = null;
            MySqlCommand cmd;
            con.Open();
            cmd = new MySqlCommand(sqlInsert, con);
            cmd.Parameters.AddWithValue("@active", Active);
            cmd.Parameters.AddWithValue("@classOneId", classOneId);
            dr = cmd.ExecuteReader();

            while (dr.Read()) //iterate through the records in the result dataset
            {
                LibraryClassification Mod = new LibraryClassification();
                Mod.ID = dr.GetInt32(0);
                Mod.IDclassOne = dr.GetInt32(1);
                Mod.CodeShelve = dr.GetString(2);
                Mod.TitleShelve = dr.GetString(3) + " ( " + dr.GetString(2) + " )";
                Mod.Active = dr.GetInt32(4);
                retVal.Add(Mod);
            }


            con.Close();

            return retVal;
        }
        public List<LibraryClassification> GetAllLibraryClassThree(int Active, string userID)
        {
            List<LibraryClassification> retVal = new List<LibraryClassification>();
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            string sqlInsert = "SELECT `id`, `classoneid`, `classtwoid`, `code`, `title`, `active` FROM `libraryclassthree` WHERE `active` = @active ";
            MySqlDataReader dr = null;
            MySqlCommand cmd;
            con.Open();
            cmd = new MySqlCommand(sqlInsert, con);
            cmd.Parameters.AddWithValue("@active", Active);
            dr = cmd.ExecuteReader();

            while (dr.Read()) //iterate through the records in the result dataset
            {
                LibraryClassification Mod = new LibraryClassification();
                Mod.ID = dr.GetInt32(0);
                Mod.IDclassOne = dr.GetInt32(1);
                Mod.IDclassTwo = dr.GetInt32(2);
                Mod.CodeStack = dr.GetString(3);
                Mod.TitleStack = dr.GetString(4) + " ( " + dr.GetString(3) + " )";
                Mod.Active = dr.GetInt32(5);
                retVal.Add(Mod);
            }


            con.Close();

            return retVal;
        }
        public List<LibraryClassification> GetAllLibraryClassThree(int Active,int classTwoId, string userID)
        {
            List<LibraryClassification> retVal = new List<LibraryClassification>();
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            string sqlInsert = "SELECT `id`, `classoneid`, `classtwoid`, `code`, `title`, `active` FROM `libraryclassthree` WHERE `active` = @active AND `classtwoid` =@classTwoId ";
            MySqlDataReader dr = null;
            MySqlCommand cmd;
            con.Open();
            cmd = new MySqlCommand(sqlInsert, con);
            cmd.Parameters.AddWithValue("@active", Active);
            cmd.Parameters.AddWithValue("@classTwoId", classTwoId);
            dr = cmd.ExecuteReader();

            while (dr.Read()) //iterate through the records in the result dataset
            {
                LibraryClassification Mod = new LibraryClassification();
                Mod.ID = dr.GetInt32(0);
                Mod.IDclassOne = dr.GetInt32(1);
                Mod.IDclassTwo = dr.GetInt32(2);
                Mod.CodeStack = dr.GetString(3);
                Mod.TitleStack = dr.GetString(4) + " ( " + dr.GetString(3) + " )";
                Mod.Active = dr.GetInt32(5);
                retVal.Add(Mod);
            }


            con.Close();

            return retVal;
        }
        public LibraryClassification GetLibraryClassOne(int classId, string userID)
        {
            LibraryClassification retVal = new LibraryClassification();
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            string sqlInsert = "SELECT `id`, `code`, `title`, `active` FROM `libraryclassone` WHERE `active` = @classId ";
            MySqlDataReader dr = null;
            MySqlCommand cmd;
            con.Open();
            cmd = new MySqlCommand(sqlInsert, con);
            cmd.Parameters.AddWithValue("@classId", classId);
            dr = cmd.ExecuteReader();

            while (dr.Read()) //iterate through the records in the result dataset
            {
                LibraryClassification Mod = new LibraryClassification();
                Mod.ID = dr.GetInt32(0);
                Mod.CodeBlock = dr.GetString(1);
                Mod.TitleBlock = dr.GetString(2) + " ( " + dr.GetString(1) + " )";
                Mod.Active = dr.GetInt32(3);
                //retVal.Add(Mod);
            }


            con.Close();

            return retVal;
        }
        public LibraryClassification GetLibraryClassTwo(int classId, string userID)
        {
            LibraryClassification retVal = new LibraryClassification();
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            string sqlInsert = "SELECT `id`, `classoneid`, `code`, `title`, `active` FROM `libraryclasstwo` WHERE `id` = @classId ";
            MySqlDataReader dr = null;
            MySqlCommand cmd;
            con.Open();
            cmd = new MySqlCommand(sqlInsert, con);
            cmd.Parameters.AddWithValue("@classId", classId);
            dr = cmd.ExecuteReader();

            while (dr.Read()) //iterate through the records in the result dataset
            {
                LibraryClassification Mod = new LibraryClassification();
                Mod.ID = dr.GetInt32(0);
                Mod.IDclassOne = dr.GetInt32(1);
                Mod.CodeShelve = dr.GetString(2);
                Mod.TitleShelve = dr.GetString(3) + " ( " + dr.GetString(2) + " )";
                Mod.Active = dr.GetInt32(4);
                //retVal.Add(Mod);
            }


            con.Close();

            return retVal;
        }
        public LibraryClassification GetLibraryClassThree(int classId, string userID)
        {
            LibraryClassification retVal = new LibraryClassification();
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            string sqlInsert = "SELECT `id`, `classoneid`, `classtwoid`, `code`, `title`, `active` FROM `libraryclassthree` WHERE `id` = @classId ";
            MySqlDataReader dr = null;
            MySqlCommand cmd;
            con.Open();
            cmd = new MySqlCommand(sqlInsert, con);
            cmd.Parameters.AddWithValue("@classId", classId);
            dr = cmd.ExecuteReader();

            while (dr.Read()) //iterate through the records in the result dataset
            {
                LibraryClassification Mod = new LibraryClassification();
                Mod.ID = dr.GetInt32(0);
                Mod.IDclassOne = dr.GetInt32(1);
                Mod.IDclassTwo = dr.GetInt32(2);
                Mod.CodeStack = dr.GetString(3);
                Mod.TitleStack = dr.GetString(4) + " ( " + dr.GetString(3) + " )";
                Mod.Active = dr.GetInt32(5);
                //retVal.Add(Mod);
            }


            con.Close();

            return retVal;
        }
        public List<LibraryClassification> GetAllLibraryClassification(string userID)
        {
            List<LibraryClassification> retVal = new List<LibraryClassification>();
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            string sqlInsert = "SELECT libraryclassone.id,libraryclassone.`code`,libraryclassone.title,libraryclasstwo.id,libraryclasstwo.`code`,libraryclasstwo.title,libraryclassthree.id,libraryclassthree.`code`,libraryclassthree.title FROM libraryclassone INNER JOIN libraryclasstwo ON libraryclassone.id = libraryclasstwo.classoneid INNER JOIN libraryclassthree ON libraryclasstwo.id = libraryclassthree.classtwoid WHERE libraryclassone.active = 1 AND libraryclasstwo.active = 1 AND libraryclassthree.active = 1 ORDER BY libraryclassone.id ";
            MySqlDataReader dr = null;
            MySqlCommand cmd;
            con.Open();
            cmd = new MySqlCommand(sqlInsert, con);
            //cmd.Parameters.AddWithValue("@active", Active);
            dr = cmd.ExecuteReader();

            while (dr.Read()) //iterate through the records in the result dataset
            {
                LibraryClassification Mod = new LibraryClassification();
                Mod.ID = dr.GetInt32(0);
                Mod.CodeBlock = dr.GetString(1);
                Mod.TitleBlock = dr.GetString(2) + " ( " + dr.GetString(1) + " )";
                Mod.IDclassTwo = dr.GetInt32(3);
                Mod.CodeShelve = dr.GetString(4);
                Mod.TitleShelve = dr.GetString(5) + " ( " + dr.GetString(4) + " )";
                Mod.IDclassThree = dr.GetInt32(6);
                Mod.CodeStack = dr.GetString(7);
                Mod.TitleStack = dr.GetString(8) + " ( " + dr.GetString(7) + " )";
                retVal.Add(Mod);
            }


            con.Close();

            return retVal;
        }
    }
}
