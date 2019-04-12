using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mySmisLib
{
    public class LibraryBook
    {
        public int ID { get; set; }
        public string Country { get; set; }
        public int AuthorID { get; set; }
        public string Gender { get; set;}
        public string AuthorName { get; set; }
        public int PubID { get; set; }
        public string PubName { get; set; }
        public int BookID { get; set; }
        public string BookISBN { get; set; }
        public string BookTitle { get; set; }
        public int BookQty { get; set; }
        public int BookPages { get; set; }
        public string BookType { get; set; }
        public string BookDesc { get; set; }
        public string SubTitle { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModify { get; set; }
        public DateTime ReturnDate { get; set; }
        public DateTime ExpectedDate { get; set; }
        public string UserId { get; set; }
        public int xIDclassOne { get; set; }
        public int xIDclassTwo { get; set; }
        public int xIDclassThree { get; set; }
        public string xCodeBlock { get; set; }
        public string xCodeShelve { get; set; }
        public string xCodeStack { get; set; }
        public string xTitleBlock { get; set; }
        public string xTitleShelve { get; set; }
        public string xTitleStack { get; set; }
        public int xNumBooks { get; set; }
        public string xFullname { get; set; }
        public string xIndexNo { get; set; }
        public int Active { get; set; }
        public LibraryBook(){}
    }

    public class LibraryBookService
    {

        public bool AddAuthor(LibraryBook fp, string userID)
        {
            bool result = false;
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            string sqlInsert = "INSERT INTO `libraryauthor` (`fullname`, `gender`, `country`) VALUES (@fullname, @gender, @country)";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sqlInsert, con);
            cmd.Parameters.AddWithValue("@fullname", fp.AuthorName);
            cmd.Parameters.AddWithValue("@gender", fp.Gender);
            cmd.Parameters.AddWithValue("@country", fp.Country);
     
            if (cmd.ExecuteNonQuery() > 0)
            {
                result = true;
            }
            con.Close();
            return result;
        }
        public bool UpdateAuthor(LibraryBook fp, string userID)
        {
            bool result = false;
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            string sqlInsert = "UPDATE `libraryauthor` SET `fullname` =@fullname, `gender` =  @gender ,`country`= @country WHERE id = @id";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sqlInsert, con);
            cmd.Parameters.AddWithValue("@fullname", fp.AuthorName);
            cmd.Parameters.AddWithValue("@gender", fp.Gender);
            cmd.Parameters.AddWithValue("@country", fp.Country);
            cmd.Parameters.AddWithValue("@id", fp.ID);

            if (cmd.ExecuteNonQuery() > 0)
            {
                result = true;
            }
            con.Close();
            return result;
        }
        public bool DeleteAuthor(int ID, string userID)
        {
            bool result = false;
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            string sqlInsert = "UPDATE `libraryauthor` SET `active` =0 WHERE id = @id";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sqlInsert, con);
            
            cmd.Parameters.AddWithValue("@id", ID);

            if (cmd.ExecuteNonQuery() > 0)
            {
                result = true;
            }
            con.Close();
            return result;
        }
        public List<LibraryBook> GetAllAuthors(string userID)
        {
            List<LibraryBook> retVal = new List<LibraryBook>();
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            string sqlInsert = "SELECT `id`, `fullname`, `gender`, `country`, `active` FROM `libraryauthor` WHERE `active` = 1";
            MySqlDataReader dr = null;
            MySqlCommand cmd;
            con.Open();
            cmd = new MySqlCommand(sqlInsert, con);
            //cmd.Parameters.AddWithValue("@active", Active);
            dr = cmd.ExecuteReader();

            while (dr.Read()) //iterate through the records in the result dataset
            {
                LibraryBook Mod = new LibraryBook();
                Mod.ID = dr.GetInt32(0);
                Mod.AuthorName = dr.GetString(1);
                Mod.Gender = dr.GetString(2);
                Mod.Country = dr.GetString(3);
                Mod.Active = dr.GetInt32(4);
                Mod.xNumBooks = new LibraryBookService().CountAuthorLibraryBook(Mod.ID, userID);

                retVal.Add(Mod);
            }


            con.Close();

            return retVal;
        }
        public LibraryBook GetAuthors(int authorId,string userID)
        {
            LibraryBook Mod = new LibraryBook();
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            string sqlInsert = "SELECT `id`, `fullname`, `gender`, `country`, `active` FROM `libraryauthor` WHERE `active` = 1 AND id = @authorId";
            MySqlDataReader dr = null;
            MySqlCommand cmd;
            con.Open();
            cmd = new MySqlCommand(sqlInsert, con);
            cmd.Parameters.AddWithValue("@authorId", authorId);
            dr = cmd.ExecuteReader();

            while (dr.Read()) //iterate through the records in the result dataset
            {
                Mod = new LibraryBook();
                Mod.ID = dr.GetInt32(0);
                Mod.AuthorName = dr.GetString(1);
                Mod.Gender = dr.GetString(2);
                Mod.Country = dr.GetString(3);
                Mod.Active = dr.GetInt32(4);
                Mod.xNumBooks = new LibraryBookService().CountAuthorLibraryBook(Mod.ID, userID);

                //retVal.Add(Mod);
            }


            con.Close();

            return Mod;
        }
        
        public bool AddPublisher(LibraryBook fp, string userID)
        {
            bool result = false;
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            string sqlInsert = "INSERT INTO `librarypublisher`(`pubname`, `country`) VALUES (@pubname, @country)";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sqlInsert, con);
            cmd.Parameters.AddWithValue("@pubname", fp.PubName);
            cmd.Parameters.AddWithValue("@country", fp.Country);

            if (cmd.ExecuteNonQuery() > 0)
            {
                result = true;
            }
            con.Close();
            return result;
        }
        public bool UpdatePublisher(LibraryBook fp, string userID)
        {
            bool result = false;
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            string sqlInsert = "UPDATE `librarypublisher` SET `pubname` =@pubname , `country` = @country WHERE id = @id";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sqlInsert, con);
            cmd.Parameters.AddWithValue("@pubname", fp.PubName);
            cmd.Parameters.AddWithValue("@country", fp.Country);
            cmd.Parameters.AddWithValue("@id", fp.ID);

            if (cmd.ExecuteNonQuery() > 0)
            {
                result = true;
            }
            con.Close();
            return result;
        }
        public bool DeletePublisher(int ID, string userID)
        {
            bool result = false;
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            string sqlInsert = "UPDATE `librarypublisher` SET `actice` =0 WHERE id = @id";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sqlInsert, con);
            
            cmd.Parameters.AddWithValue("@id",ID);

            if (cmd.ExecuteNonQuery() > 0)
            {
                result = true;
            }
            con.Close();
            return result;
        }
        public List<LibraryBook> GetAllPublisher(string userID)
        {
            List<LibraryBook> retVal = new List<LibraryBook>();
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            string sqlInsert = "SELECT `id`, `pubname`, `country`, `active` FROM `librarypublisher` WHERE `active` = 1";
            MySqlDataReader dr = null;
            MySqlCommand cmd;
            con.Open();
            cmd = new MySqlCommand(sqlInsert, con);
            //cmd.Parameters.AddWithValue("@active", Active);
            dr = cmd.ExecuteReader();

            while (dr.Read()) //iterate through the records in the result dataset
            {
                LibraryBook Mod = new LibraryBook();
                Mod.ID = dr.GetInt32(0);
                Mod.PubName = dr.GetString(1);
                Mod.Country = dr.GetString(2);
                Mod.Active = dr.GetInt32(3);
                Mod.xNumBooks = new LibraryBookService().CountPublisherLibraryBook(Mod.ID, userID);

                retVal.Add(Mod);
            }


            con.Close();

            return retVal;
        }
        public LibraryBook GetPublisher(int pubId, string userID)
        {
            LibraryBook Mod = new LibraryBook();
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            string sqlInsert = "SELECT `id`, `pubname`, `country`, `active` FROM `librarypublisher` WHERE `active` = 1 AND id = @pubId";
            MySqlDataReader dr = null;
            MySqlCommand cmd;
            con.Open();
            cmd = new MySqlCommand(sqlInsert, con);
            cmd.Parameters.AddWithValue("@pubId", pubId);
            dr = cmd.ExecuteReader();

            while (dr.Read()) //iterate through the records in the result dataset
            {
                Mod = new LibraryBook();
                Mod.ID = dr.GetInt32(0);
                Mod.PubName = dr.GetString(1);
                Mod.Country = dr.GetString(3);
                Mod.Active = dr.GetInt32(4);
                Mod.xNumBooks = new LibraryBookService().CountPublisherLibraryBook(Mod.ID, userID);

                //retVal.Add(Mod);
            }


            con.Close();

            return Mod;
        }
        
        public bool AddBookAuthor(LibraryBook fp, string userID)
        {
            bool result = false;
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            string sqlInsert = "INSERT INTO `librarybookauthor`(`bookid`, `authorid`) VALUES (@bookid, @authorid)";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sqlInsert, con);
            cmd.Parameters.AddWithValue("@bookid", fp.BookID);
            cmd.Parameters.AddWithValue("@authorid", fp.AuthorID);

            if (cmd.ExecuteNonQuery() > 0)
            {
                result = true;
            }
            con.Close();
            return result;
        }        
        public bool AddBook(LibraryBook fp, string userID)
        {
            bool result = false;
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            string sqlInsert = "INSERT INTO `librarybook`(`isbn`, `title`, `authorid`, `pubid`, `npages`, `booktype`, `qty`, `classoneid`, `classtwoid`, `classthreeid`,dateCreated,dateModify,bookdesc,subtitle) VALUES (@isbn, @title, @authorid, @pubid, @npages, @booktype, @qty, @classoneid, @classtwoid, @classthreeid,@dateCreated,@dateModify,@bookdesc,@subtitle)";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sqlInsert, con);
            cmd.Parameters.AddWithValue("@isbn", fp.BookISBN);
            cmd.Parameters.AddWithValue("@title", fp.BookTitle);
            cmd.Parameters.AddWithValue("@authorid", fp.AuthorID);
            cmd.Parameters.AddWithValue("@pubid", fp.PubID);
            cmd.Parameters.AddWithValue("@npages", fp.BookPages);
            cmd.Parameters.AddWithValue("@booktype", fp.BookType);
            cmd.Parameters.AddWithValue("@qty",fp.BookQty);
            cmd.Parameters.AddWithValue("@classoneid", fp.xIDclassOne);
            cmd.Parameters.AddWithValue("@classtwoid", fp.xIDclassTwo);
            cmd.Parameters.AddWithValue("@classthreeid", fp.xIDclassThree);
            cmd.Parameters.AddWithValue("@dateCreated", fp.DateCreated);
            cmd.Parameters.AddWithValue("@dateModify", fp.DateModify);
            cmd.Parameters.AddWithValue("@bookdesc",fp.BookDesc);
            cmd.Parameters.AddWithValue("@subtitle", fp.SubTitle);

            if (cmd.ExecuteNonQuery() > 0)
            {
                result = true;
            }
            con.Close();
            return result;
        }
        public bool UpdateBook(LibraryBook fp, string userID)
        {
            bool result = false;
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            string sqlInsert = "INSERT INTO `librarybook`(`isbn`, `title`, `authorid`, `pubid`, `npages`, `booktype`, `qty`, `classoneid`, `classtwoid`, `classthreeid`,dateCreated,dateModify,bookdesc,subtitle) VALUES (@isbn, @title, @authorid, @pubid, @npages, @booktype, @qty, @classoneid, @classtwoid, @classthreeid,@dateCreated,@dateModify,@bookdesc,@subtitle)";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sqlInsert, con);
            cmd.Parameters.AddWithValue("@isbn", fp.BookISBN);
            cmd.Parameters.AddWithValue("@title", fp.BookTitle);
            cmd.Parameters.AddWithValue("@authorid", fp.AuthorID);
            cmd.Parameters.AddWithValue("@pubid", fp.PubID);
            cmd.Parameters.AddWithValue("@npages", fp.BookPages);
            cmd.Parameters.AddWithValue("@booktype", fp.BookType);
            cmd.Parameters.AddWithValue("@qty", fp.BookQty);
            cmd.Parameters.AddWithValue("@classoneid", fp.xIDclassOne);
            cmd.Parameters.AddWithValue("@classtwoid", fp.xIDclassTwo);
            cmd.Parameters.AddWithValue("@classthreeid", fp.xIDclassThree);
            cmd.Parameters.AddWithValue("@dateCreated", fp.DateCreated);
            cmd.Parameters.AddWithValue("@dateModify", fp.DateModify);
            cmd.Parameters.AddWithValue("@bookdesc", fp.BookDesc);
            cmd.Parameters.AddWithValue("@subtitle", fp.SubTitle);

            if (cmd.ExecuteNonQuery() > 0)
            {
                result = true;
            }
            con.Close();
            return result;
        }
        public bool ArchiveBook(int Id, string userID)
        {
            Boolean retVal = false;
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            string sqlInsert = "UPDATE `librarybook` SET active = 0 WHERE `id` = @id";
            MySqlDataReader dr = null;
            MySqlCommand cmd;
            con.Open();
            cmd = new MySqlCommand(sqlInsert, con);
            cmd.Parameters.AddWithValue("@id", Id);
            dr = cmd.ExecuteReader();

            if (dr.RecordsAffected > 0) //iterate through the records in the result dataset
            {
                retVal = true;
            }

            con.Close();

            return retVal;
        }
        public bool ExitLibraryBook(string isbn, string userID)
        {
            Boolean retVal = false;
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            string sqlInsert = "SELECT `id` FROM `librarybook` WHERE active = 1 AND `isbn` = @isbn";
            MySqlDataReader dr = null;
            MySqlCommand cmd;
            con.Open();
            cmd = new MySqlCommand(sqlInsert, con);
            cmd.Parameters.AddWithValue("@isbn", isbn);
            dr = cmd.ExecuteReader();

            if (dr.HasRows) //iterate through the records in the result dataset
            {

                retVal = true ;

            }


            con.Close();

            return retVal;
        }
        public bool DeleteLibraryClassification(int fp, string userID)
        {
            bool result = false;
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            string sqlInsert = "DELETE FROM `gradesystemvalue` WHERE gsvid = @gsvid";
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
        public List<LibraryBook> GetAllLibraryBook(string userID)
        {
            List<LibraryBook> retVal = new List<LibraryBook>();
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            string sqlInsert = "SELECT librarybook.`id`, librarybook.`isbn`, librarybook.`title`, librarybook.`authorid`, librarybook.`pubid`, librarybook.`npages`, librarybook.`booktype`, librarybook.`qty`, librarybook.`classoneid`, librarybook.`classtwoid`, librarybook.`classthreeid`, librarybook.`active`,librarybook.bookdesc,subtitle,libraryauthor.fullname,librarypublisher.pubname FROM `librarybook` INNER JOIN libraryauthor ON librarybook.pubid = libraryauthor.id INNER JOIN librarypublisher ON librarybook.authorid = librarypublisher.id WHERE librarybook.active = 1";
            MySqlDataReader dr = null;
            MySqlCommand cmd;
            con.Open();
            cmd = new MySqlCommand(sqlInsert, con);
            //cmd.Parameters.AddWithValue("@active", Active);
            dr = cmd.ExecuteReader();

            while (dr.Read()) //iterate through the records in the result dataset
            {
                LibraryBook Mod = new LibraryBook();
                Mod.ID = dr.GetInt32(0);
                Mod.BookISBN = dr.GetString(1);
                Mod.BookTitle = dr.GetString(2);
                Mod.AuthorID = dr.GetInt32(3);
                Mod.PubID = dr.GetInt32(4);
                Mod.BookPages = dr.GetInt32(5);
                Mod.BookType = dr.GetString(6);
                Mod.BookQty = dr.GetInt32(7);
                Mod.xIDclassOne = dr.GetInt32(8);
                Mod.xIDclassTwo = dr.GetInt32(9);
                Mod.xIDclassThree = dr.GetInt32(10);
                Mod.Active = dr.GetInt32(11);
                Mod.BookDesc = dr.GetString(12);
                Mod.SubTitle = dr.GetString(13);
                Mod.xTitleBlock = new LibraryClassificationService().GetLibraryClassOne(Mod.xIDclassOne, userID).TitleBlock;
                Mod.xTitleShelve = new LibraryClassificationService().GetLibraryClassTwo(Mod.xIDclassTwo, userID).TitleShelve;
                Mod.xTitleStack = new LibraryClassificationService().GetLibraryClassThree(Mod.xIDclassThree, userID).TitleStack;
                Mod.AuthorName = dr.GetString(14);
                Mod.PubName = dr.GetString(15);
                retVal.Add(Mod);
            }


            con.Close();

            return retVal;
        }

        public List<LibraryBook> GetAllLibraryBook(string bookType,string userID)
        {
            List<LibraryBook> retVal = new List<LibraryBook>();
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            string sqlInsert = "SELECT librarybook.`id`, librarybook.`isbn`, librarybook.`title`, librarybook.`authorid`, librarybook.`pubid`, librarybook.`npages`, librarybook.`booktype`, librarybook.`qty`, librarybook.`classoneid`, librarybook.`classtwoid`, librarybook.`classthreeid`, librarybook.`active`,librarybook.bookdesc,subtitle,libraryauthor.fullname,librarypublisher.pubname FROM `librarybook` INNER JOIN libraryauthor ON librarybook.pubid = libraryauthor.id INNER JOIN librarypublisher ON librarybook.authorid = librarypublisher.id WHERE librarybook.active = 1 AND librarybook.`booktype`= @bookType";
            MySqlDataReader dr = null;
            MySqlCommand cmd;
            con.Open();
            cmd = new MySqlCommand(sqlInsert, con);
            cmd.Parameters.AddWithValue("@bookType", bookType);
            dr = cmd.ExecuteReader();

            while (dr.Read()) //iterate through the records in the result dataset
            {
                LibraryBook Mod = new LibraryBook();
                Mod.ID = dr.GetInt32(0);
                Mod.BookISBN = dr.GetString(1);
                Mod.BookTitle = dr.GetString(2);
                Mod.AuthorID = dr.GetInt32(3);
                Mod.PubID = dr.GetInt32(4);
                Mod.BookPages = dr.GetInt32(5);
                Mod.BookType = dr.GetString(6);
                Mod.BookQty = dr.GetInt32(7);
                Mod.xIDclassOne = dr.GetInt32(8);
                Mod.xIDclassTwo = dr.GetInt32(9);
                Mod.xIDclassThree = dr.GetInt32(10);
                Mod.Active = dr.GetInt32(11);
                Mod.BookDesc = dr.GetString(12);
                Mod.SubTitle = dr.GetString(13);
                Mod.xTitleBlock = new LibraryClassificationService().GetLibraryClassOne(Mod.xIDclassOne, userID).TitleBlock;
                Mod.xTitleShelve = new LibraryClassificationService().GetLibraryClassTwo(Mod.xIDclassTwo, userID).TitleShelve;
                Mod.xTitleStack = new LibraryClassificationService().GetLibraryClassThree(Mod.xIDclassThree, userID).TitleStack;
                Mod.AuthorName = dr.GetString(14);
                Mod.PubName = dr.GetString(15);
                retVal.Add(Mod);
            }


            con.Close();

            return retVal;
        }
        public List<LibraryBook> GetAllAvailableLibraryBook(string userID)
        {
            List<LibraryBook> retVal = new List<LibraryBook>();
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            string sqlInsert = "SELECT librarybook.`id`, librarybook.`isbn`, librarybook.`title`, librarybook.`authorid`, librarybook.`pubid`, librarybook.`npages`, librarybook.`booktype`, librarybook.`qty`, librarybook.`classoneid`, librarybook.`classtwoid`, librarybook.`classthreeid`, librarybook.`active`,librarybook.bookdesc,subtitle,libraryauthor.fullname,librarypublisher.pubname,(librarybook.`qty` - (SELECT Count(librarybookborrow.id) FROM librarybookborrow WHERE librarybookborrow.bookid = librarybook.id AND DATE(librarybookborrow.returnDate) = '0001-01-01' )) AS numAvila FROM `librarybook` INNER JOIN libraryauthor ON librarybook.pubid = libraryauthor.id INNER JOIN librarypublisher ON librarybook.authorid = librarypublisher.id WHERE librarybook.active = 1 AND librarybook.`qty` > (SELECT Count(librarybookborrow.id) FROM librarybookborrow WHERE librarybookborrow.bookid = librarybook.id AND DATE(librarybookborrow.returnDate) = '0001-01-01' )";
            MySqlDataReader dr = null;
            MySqlCommand cmd;
            con.Open();
            cmd = new MySqlCommand(sqlInsert, con);
            //cmd.Parameters.AddWithValue("@bookType", bookType);
            dr = cmd.ExecuteReader();

            while (dr.Read()) //iterate through the records in the result dataset
            {
                LibraryBook Mod = new LibraryBook();
                Mod.ID = dr.GetInt32(0);
                Mod.BookISBN = dr.GetString(1);
                Mod.BookTitle = dr.GetString(2);
                Mod.AuthorID = dr.GetInt32(3);
                Mod.PubID = dr.GetInt32(4);
                Mod.BookPages = dr.GetInt32(5);
                Mod.BookType = dr.GetString(6);
                Mod.BookQty = dr.GetInt32(7);
                Mod.xIDclassOne = dr.GetInt32(8);
                Mod.xIDclassTwo = dr.GetInt32(9);
                Mod.xIDclassThree = dr.GetInt32(10);
                Mod.Active = dr.GetInt32(11);
                Mod.BookDesc = dr.GetString(12);
                Mod.SubTitle = dr.GetString(13);
                Mod.xTitleBlock = new LibraryClassificationService().GetLibraryClassOne(Mod.xIDclassOne, userID).TitleBlock;
                Mod.xTitleShelve = new LibraryClassificationService().GetLibraryClassTwo(Mod.xIDclassTwo, userID).TitleShelve;
                Mod.xTitleStack = new LibraryClassificationService().GetLibraryClassThree(Mod.xIDclassThree, userID).TitleStack;
                Mod.AuthorName = dr.GetString(14);
                Mod.PubName = dr.GetString(15);
                Mod.xNumBooks = dr.GetInt32(16);
                retVal.Add(Mod);
            }


            con.Close();

            return retVal;
        }
        public LibraryBook GetLibraryBook(int Id,string userID)
        {
            LibraryBook Mod = new LibraryBook();
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            string sqlInsert = "SELECT `id`, `isbn`, `title`, `authorid`, `pubid`, `npages`, `booktype`, `qty`, `classoneid`, `classtwoid`, `classthreeid`, `active`,bookdesc,subtitle FROM `librarybook` WHERE active = 1 AND id = @id";
            MySqlDataReader dr = null;
            MySqlCommand cmd;
            con.Open();
            cmd = new MySqlCommand(sqlInsert, con);
            cmd.Parameters.AddWithValue("@id", Id);
            dr = cmd.ExecuteReader();

            while (dr.Read()) //iterate through the records in the result dataset
            {
                Mod = new LibraryBook();
                Mod.ID = dr.GetInt32(0);
                Mod.BookISBN = dr.GetString(1);
                Mod.BookTitle = dr.GetString(2);
                Mod.AuthorID = dr.GetInt32(3);
                Mod.PubID = dr.GetInt32(4);
                Mod.BookPages = dr.GetInt32(5);
                Mod.BookType = dr.GetString(6);
                Mod.BookQty = dr.GetInt32(7);
                Mod.xIDclassOne = dr.GetInt32(8);
                Mod.xIDclassTwo = dr.GetInt32(9);
                Mod.xIDclassThree = dr.GetInt32(10);
                Mod.Active = dr.GetInt32(11);
                Mod.BookDesc = dr.GetString(12);
                Mod.SubTitle = dr.GetString(13);
                Mod.xTitleBlock = new LibraryClassificationService().GetLibraryClassOne(Mod.xIDclassOne, userID).TitleBlock;
                Mod.xTitleShelve = new LibraryClassificationService().GetLibraryClassTwo(Mod.xIDclassTwo, userID).TitleShelve;
                Mod.xTitleStack = new LibraryClassificationService().GetLibraryClassThree(Mod.xIDclassThree, userID).TitleStack;

                //retVal.Add(Mod);
            }


            con.Close();

            return Mod;
        }
        public int CountPublisherLibraryBook(int pubId ,string userID)
        {
            int retVal = 0;
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            string sqlInsert = "SELECT COUNT(`id`) FROM `librarybook` WHERE active = 1 AND `pubid` = @pubId";
            MySqlDataReader dr = null;
            MySqlCommand cmd;
            con.Open();
            cmd = new MySqlCommand(sqlInsert, con);
            cmd.Parameters.AddWithValue("@pubId", pubId);
            dr = cmd.ExecuteReader();

            while (dr.Read()) //iterate through the records in the result dataset
            {

                retVal = dr.GetInt32(0);
                
            }


            con.Close();

            return retVal;
        }
        public int CountAuthorLibraryBook(int authorId, string userID)
        {
            int retVal = 0;
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            string sqlInsert = "SELECT COUNT(`id`) FROM `librarybook` WHERE active = 1 AND `authorid` = @authorId";
            MySqlDataReader dr = null;
            MySqlCommand cmd;
            con.Open();
            cmd = new MySqlCommand(sqlInsert, con);
            cmd.Parameters.AddWithValue("@authorId", authorId);
            dr = cmd.ExecuteReader();

            while (dr.Read()) //iterate through the records in the result dataset
            {

                retVal = dr.GetInt32(0);

            }


            con.Close();

            return retVal;
        }


        public List<LibraryBook> GetAllBorrowLibraryBook(string bookType, string userID)
        {
            List<LibraryBook> retVal = new List<LibraryBook>();
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            string sqlInsert = "SELECT librarybook.`id`, librarybook.`isbn`, librarybook.`title`, librarybook.`authorid`, librarybook.`pubid`, librarybook.`npages`, librarybook.`booktype`, librarybook.`qty`, librarybook.`classoneid`, librarybook.`classtwoid`, librarybook.`classthreeid`, librarybook.`active`,librarybook.bookdesc,subtitle,libraryauthor.fullname,librarypublisher.pubname FROM `librarybook` INNER JOIN libraryauthor ON librarybook.pubid = libraryauthor.id INNER JOIN librarypublisher ON librarybook.authorid = librarypublisher.id WHERE librarybook.active = 1 AND librarybook.`booktype`= @bookType";
            MySqlDataReader dr = null;
            MySqlCommand cmd;
            con.Open();
            cmd = new MySqlCommand(sqlInsert, con);
            dr = cmd.ExecuteReader();

            while (dr.Read()) //iterate through the records in the result dataset
            {
                LibraryBook Mod = new LibraryBook();
                Mod.ID = dr.GetInt32(0);
                Mod.BookISBN = dr.GetString(1);
                Mod.BookTitle = dr.GetString(2);
                Mod.AuthorID = dr.GetInt32(3);
                Mod.PubID = dr.GetInt32(4);
                Mod.BookPages = dr.GetInt32(5);
                Mod.BookType = dr.GetString(6);
                Mod.BookQty = dr.GetInt32(7);
                Mod.xIDclassOne = dr.GetInt32(8);
                Mod.xIDclassTwo = dr.GetInt32(9);
                Mod.xIDclassThree = dr.GetInt32(10);
                Mod.Active = dr.GetInt32(11);
                Mod.BookDesc = dr.GetString(12);
                Mod.SubTitle = dr.GetString(13);
                Mod.xTitleBlock = new LibraryClassificationService().GetLibraryClassOne(Mod.xIDclassOne, userID).TitleBlock;
                Mod.xTitleShelve = new LibraryClassificationService().GetLibraryClassTwo(Mod.xIDclassTwo, userID).TitleShelve;
                Mod.xTitleStack = new LibraryClassificationService().GetLibraryClassThree(Mod.xIDclassThree, userID).TitleStack;
                Mod.AuthorName = dr.GetString(14);
                Mod.PubName = dr.GetString(15);
                retVal.Add(Mod);
            }


            con.Close();

            return retVal;
        }

    }
}
