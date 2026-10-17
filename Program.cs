using PayPal.Api;
using SelectWithListLibrary;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainerDetails
{
    internal class Program
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
        static void Main(string[] args)
        {

            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("TrainerRegistrationForm");
                Console.WriteLine("============================");
                Console.WriteLine("1.AddTrainerDetails\n2.UpdateTrainerDetails\n3.DeleteTrainerDetails\n4.TrainerAllDetails\n5.SearchTrainId\n6.Exit");
                Console.Write("Select An Option(1-6): ");

                switch (Console.ReadLine())
                {
                    case "1": AddTrainerDetails(); break;
                    case "2": UpdateTrainerDetails(); break;
                    case "3": DeleteTrainerDetails(); break;
                    case "4": DisplayTrainerDetails(); break;
                    case "5": SearchBySid(); break;

                    case "6": running = false; Console.WriteLine("Exiting..."); break;
                    default:
                        Console.WriteLine("Invalid Option. Press any key to retry.");
                        Console.ReadKey();
                        break;
                }
            }
        }
        public static void AddTrainerDetails()
        {
            bool continueInserting = true;
            do
            {
                Console.Clear();
                Console.WriteLine("\n Insert Trainer Details");
                Console.WriteLine("==================================");
              
                Console.Write("Enter Trainer First Name: ");
                string tfname = Console.ReadLine();             
                Console.Write("Enter Trainer Last Name: ");
                string tlname = Console.ReadLine();
                Console.Write("Enter Course Name Only(DataScience,Java FullStack,Python FullStack,.Net Core&Angular," +
                     "AWSDevepos): ");
                string course = Console.ReadLine();
                Console.Write("Enter Trainer Email: ");
                string email = Console.ReadLine();
                Console.Write("Enter Trainer Age: ");
                int age = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Trainer Gender(Male or Female): ");
                string gender= Console.ReadLine();
                Console.Write("Enter Trainer Contact No: ");  
                string contno = Console.ReadLine();
                Console.WriteLine("Enter Trainer Qualification: ");
                string quli= Console.ReadLine();
                Console.WriteLine("Trainer Hire Date(YYYY-DD-MM): ");
                DateTime hirdate =Convert.ToDateTime( Console.ReadLine());
                Console.WriteLine(" Enter Salary : ");
                int salary = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Trainer City: ");
                string city = Console.ReadLine();

                try
                {

                    using (SqlConnection cn = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("sp_trainer", cn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            SqlParameter db = new SqlParameter("@Method", SqlDbType.VarChar, 20);
                            db.Value = "InsertTrainer";
                            cmd.Parameters.Add(db);
                            
                            
                            SqlParameter p1 = new SqlParameter("@FirstName", SqlDbType.VarChar, 50);
                            p1.Value = tfname;
                            cmd.Parameters.Add(p1);
                            SqlParameter p2 = new SqlParameter("@LastName", SqlDbType.VarChar, 50);
                            p2.Value = tlname;
                            cmd.Parameters.Add(p2);
                            SqlParameter p3 = new SqlParameter("@CourseName", SqlDbType.VarChar, 40);
                            p3.Value = course;
                            cmd.Parameters.Add(p3);
                            SqlParameter p5 = new SqlParameter("@Email", SqlDbType.VarChar, 60);
                            p5.Value = email;
                            cmd.Parameters.Add(p5);
                            SqlParameter p6 = new SqlParameter("@Age", SqlDbType.Int);
                            p6.Value = age;
                            cmd.Parameters.Add(p6);
                            SqlParameter p7 = new SqlParameter("@Gender", SqlDbType.VarChar, 10);
                            p7.Value = gender;
                            cmd.Parameters.Add(p7);
                            SqlParameter p8 = new SqlParameter("@ContactNo", SqlDbType.VarChar, 20);
                            p8.Value = contno;
                            cmd.Parameters.Add(p8);
                            SqlParameter p9 = new SqlParameter("@Qualification", SqlDbType.VarChar, 40);
                            p9.Value = quli;
                            cmd.Parameters.Add(p9);

                            SqlParameter p10 = new SqlParameter("@Hire_Date", SqlDbType.DateTime);
                            p10.Value = hirdate;
                            cmd.Parameters.Add(p10);
                            SqlParameter p11 = new SqlParameter("@Salary", SqlDbType.Int);
                            p11.Value = salary;
                            cmd.Parameters.Add(p11);
                            SqlParameter p12 = new SqlParameter("@City", SqlDbType.VarChar, 40);
                            p12.Value = city;
                            cmd.Parameters.Add(p12);

                            cn.Open();
                            int result = cmd.ExecuteNonQuery();

                            if (result > 0)
                            {
                                Console.WriteLine("\nTrainer Record Inserted Successfully!");
                            }
                            else
                            {
                                Console.WriteLine("\nNo records were inserted into the database.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\nError: " + ex.Message);
                }
                finally
                {
                    Console.WriteLine("Insert Operation Completed.");
                }

                Console.Write("\nDo You Want To Insert Another Record? (Yes/No): ");
                string userChoice = Console.ReadLine().Trim().ToUpper();

                if (userChoice == "NO")
                {
                    continueInserting = false;
                    Console.WriteLine("Returning to the Main Menu...");
                }

            } while (continueInserting);
        }
        /*Update Trainer Details*/
        public static void UpdateTrainerDetails()
        {
            bool continueUpdating = true;
            do
            {
                Console.Clear();
                Console.WriteLine("\n Update Trainer Details");
                Console.WriteLine("==================================");
                Console.Write("Enter Existing TrainerId: ");
                int trid = Convert.ToInt32(Console.ReadLine());
                
                Console.Write("Enter Trainer First Name: ");
                string tfname = Console.ReadLine();
                Console.Write("Enter Trainer Last Name: ");
                string tlname = Console.ReadLine();
                Console.Write("Enter Choose Available Course Only(DataScience,Java FullStack,Python FullStack,.Net Core&Angular," +
                     "AWSDevepos): ");
                string course = Console.ReadLine();
                Console.Write("Enter Trainer Email: ");
                string email = Console.ReadLine();
                Console.Write("Enter Trainer Age: ");
                int age = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Trainr Gender(Male or Female): ");
                string gender = Console.ReadLine();

                Console.Write("Enter Trainer Phone No: ");
                string contno = Console.ReadLine();
                Console.WriteLine("Enter Trainer Qualification: ");
                string quli = Console.ReadLine();

                Console.WriteLine("Trainer Hire Date(YYYY-DD-MM): ");
                DateTime hirdate = DateTime.Now;
                Console.WriteLine(" Enter Salary : ");
                int salary = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Trainer City: ");
                string city = Console.ReadLine();

                try
                {

                    using (SqlConnection cn = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("sp_trainer", cn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            SqlParameter db = new SqlParameter("@Method", SqlDbType.VarChar, 20);
                            db.Value = "UpdateTrainer";
                            cmd.Parameters.Add(db);
                            SqlParameter p1 = new SqlParameter("@Trainer_Id", SqlDbType.Int);
                            p1.Value = trid;
                            cmd.Parameters.Add(p1);
                            
                            SqlParameter p2 = new SqlParameter("@FirstName", SqlDbType.VarChar, 50);
                            p2.Value = tfname;
                            cmd.Parameters.Add(p2);
                            SqlParameter p3 = new SqlParameter("@LastName", SqlDbType.VarChar, 50);
                            p3.Value = tlname;
                            cmd.Parameters.Add(p3);
                            SqlParameter p4 = new SqlParameter("@CourseName", SqlDbType.VarChar, 40);
                            p4.Value = course;
                            cmd.Parameters.Add(p4);
                            SqlParameter p5 = new SqlParameter("@Email", SqlDbType.VarChar, 60);
                            p5.Value = email;
                            cmd.Parameters.Add(p5);
                            SqlParameter p6 = new SqlParameter("@Age", SqlDbType.Int);
                            p6.Value = age;
                            cmd.Parameters.Add(p6);
                            SqlParameter p7 = new SqlParameter("@Gender", SqlDbType.VarChar, 10);
                            p7.Value = gender;
                            cmd.Parameters.Add(p7);
                            SqlParameter p8 = new SqlParameter("@ContactNo", SqlDbType.VarChar, 20);
                            p8.Value = contno;
                            cmd.Parameters.Add(p8);
                            SqlParameter p9 = new SqlParameter("@Qualification", SqlDbType.VarChar, 40);
                            p9.Value = quli;
                            cmd.Parameters.Add(p9);

                            SqlParameter p10 = new SqlParameter("@Hire_Date", SqlDbType.DateTime);
                            p10.Value = hirdate;
                            cmd.Parameters.Add(p10);
                            SqlParameter p11 = new SqlParameter("@Salary", SqlDbType.Int);
                            p11.Value = salary;
                            cmd.Parameters.Add(p11);
                            SqlParameter p12 = new SqlParameter("@City", SqlDbType.VarChar, 40);
                            p12.Value = city;
                            cmd.Parameters.Add(p12);


                            cn.Open();
                            int result = cmd.ExecuteNonQuery();

                            if (result > 0)
                            {
                                Console.WriteLine("\nTrainer Record Inserted Successfully!");
                            }
                            else
                            {
                                Console.WriteLine("\nNo records were inserted into the database.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\nError: " + ex.Message);
                }
                finally
                {
                    Console.WriteLine("Insert Operation Completed.");
                }

                Console.Write("\nDo You Want To Insert Another Record? (Yes/No): ");
                string userChoice = Console.ReadLine().Trim().ToUpper();

                if (userChoice == "NO")
                {
                    continueUpdating = false;
                    Console.WriteLine("Returning to the Main Menu...");
                }

            } while (continueUpdating);
        }
        /* Delete Trainer Record Using Id */
        public static void DeleteTrainerDetails()
        {
            bool continueDeleting = false;
            do
            {
                Console.Clear();
                Console.WriteLine("Delete Trainer Details ");
                Console.WriteLine("============================");
                Console.WriteLine("Enter Exsting TrainerId: ");
                int trid = Convert.ToInt32(Console.ReadLine());

                try
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("sp_trainer", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            SqlParameter dbase = new SqlParameter("@Method", SqlDbType.VarChar, 20);
                            dbase.Value = "DeleteTrainer";
                            cmd.Parameters.Add(dbase);
                            SqlParameter p1 = new SqlParameter("@Trainer_Id", SqlDbType.Int);
                            p1.Value = trid;
                            cmd.Parameters.Add(p1);

                            con.Open();
                            int result = cmd.ExecuteNonQuery();
                            if (result > 0)
                            {
                                Console.WriteLine("\nTrainer Record Was Successfully");
                            }
                            else
                            {
                                Console.WriteLine("\nTrainer Id Was Not Found Given Table");
                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\nError:" + ex.Message);
                }
                finally
                {
                    Console.WriteLine("\nDelete Operation Completed ");
                }
                Console.Write("\nDo You Want To Delete Another Record? (Yes/No): ");
                string userChoice = Console.ReadLine().Trim().ToUpper();

                if (userChoice == "NO")
                {
                    continueDeleting = false;
                    Console.WriteLine("Returning to the Main Menu...");
                }
            } while (continueDeleting);
        }
        /* Display  Trainer Details */
        public static void DisplayTrainerDetails()
        {
            bool continueSelecting = true;
            do
            {
                Console.Clear();
                Console.WriteLine("\nDisplay Trainer Existing Record");
                Console.WriteLine("=============================");

                try
                {

                    using (SqlConnection cn = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("sp_trainer", cn))
                        {
                            cn.Open();
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.Add("@Method", SqlDbType.VarChar, 20).Value = "SelectTrainer";
                            SqlDataReader dr = cmd.ExecuteReader();


                            List<Trainer> trainerdeails = new List<Trainer>();
                            while (dr.Read())
                            {

                                int trid = Convert.ToInt32(dr["Trainer_Id"]);
                                string course = Convert.ToString(dr["CourseName"]);
                                string trname = Convert.ToString(dr["TrainerName"]);
                                string email = Convert.ToString(dr["Email"]);
                                int age = Convert.ToInt32(dr["Age"]);
                                string gender = Convert.ToString(dr["Gender"]);

                                string contno = Convert.ToString(dr["ContactNo"]);
                                string qulif = Convert.ToString(dr["Qualification"]);
                                DateTime hire = Convert.ToDateTime(dr["Hire_Date"]);
                                int salary = Convert.ToInt32(dr["Salary"]);
                                string city = Convert.ToString(dr["City"]);

                                Trainer t = new Trainer(trid, trname, course, email, age, gender, contno, qulif, hire, salary,city);
                                trainerdeails.Add(t);

                            }
                             foreach (Trainer trainerdet in trainerdeails)
                            {
                                Console.WriteLine("\nStudent Details");
                                Console.WriteLine("----------------------");
                                Console.WriteLine("TrainerId   :" + trainerdet.Trainer_Id);
                                Console.WriteLine("TrainerName :" + trainerdet.TrainerName);
                                Console.WriteLine("CourseName  :" + trainerdet.CourseName);
                                Console.WriteLine("Email       :" + trainerdet.Email);
                                Console.WriteLine("Gender      :" + trainerdet.Gender);
                                Console.WriteLine("Age         :" + trainerdet.Age);                              
                                Console.WriteLine("ContactNo   :" + trainerdet.ContactNo);
                                Console.WriteLine("Qualif      :" + trainerdet.Qualification);
                                Console.WriteLine("Hire_Date   :" + trainerdet.Hire_Date);
                                Console.WriteLine("Salary      :" + trainerdet.Salary);
                                Console.WriteLine("City        :"+  trainerdet.City);

                            }
                            Console.ReadLine();
                            cn.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\nError: " + ex.Message);
                }
                finally
                {
                    Console.WriteLine("Select Command  Completed.");
                }

                Console.Write("\n Do You Want To Add Another(Insert,Update,Delete) Record? (Yes/No): ");
                string userChoice = Console.ReadLine().Trim().ToUpper();

                if (userChoice == "NO")
                {
                    continueSelecting = false;
                    Console.WriteLine("Returning to the Main Menu...");
                }

            } while (continueSelecting);
        }
        //Display Details Search With Id //
        public static void SearchBySid()
        {
            bool continueSelecting = true;
            do
            {
                Console.Clear();
                Console.WriteLine("\nDisplay Existing Record");
                Console.WriteLine("=============================");
                Console.Write("Enter Existing  StudentId: ");
                int traid = Convert.ToInt32(Console.ReadLine());

                try
                {

                    using (SqlConnection cn = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("sp_trainer", cn))
                        {
                            cn.Open();
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.Add("@Method", SqlDbType.VarChar, 20).Value = "SelectTrainerId";

                            SqlParameter p1 = new SqlParameter("@Trainer_Id", SqlDbType.Int);
                            p1.Value = traid;
                            cmd.Parameters.Add(p1);
                            SqlDataReader dr = cmd.ExecuteReader();
                            bool found = false;
                            while (dr.Read())
                            {
                                found = true;
                                
                                string trname = Convert.ToString(dr["TrainerName"]);
                                string course = Convert.ToString(dr["CourseName"]);
                                string email = Convert.ToString(dr["Email"]);
                                int age = Convert.ToInt32(dr["Age"]);
                                string gender = Convert.ToString(dr["Gender"]);

                                string contno = Convert.ToString(dr["ContactNo"]);
                                string qulif = Convert.ToString(dr["Qualification"]);
                                DateTime hire = Convert.ToDateTime(dr["Hire_Date"]);
                                int salary = Convert.ToInt32(dr["Salary"]);
                                string city = Convert.ToString(dr["City"]);


                                Console.WriteLine("\nStudent Details");
                              
                                Console.WriteLine("----------------------");
                                Console.WriteLine("TrainerId   :" + traid);

                                Console.WriteLine("TrainerName :" + trname);
                                Console.WriteLine("CourseName  :" + course);
                                Console.WriteLine("Age         :" + age);
                                Console.WriteLine("Gender      :" + gender);
                                Console.WriteLine("ContactNo   :" + contno);
                                Console.WriteLine("Qualifi     :" + qulif);
                                Console.WriteLine("HireDate    :" + hire);
                                Console.WriteLine("Salary      :" + salary);
                                Console.WriteLine("City        :" + city);

                            }
                            if (!found)
                            {
                                Console.WriteLine("Trainer Id Was Not Found ");
                            }
                            dr.Close();
                        }
                        Console.ReadLine();
                        cn.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\nError: " + ex.Message);
                }

                finally
                {
                    Console.WriteLine("Search Command Completed.");
                }

                Console.Write("\n Do You Want To Process Another Record? (Yes/No):");
                string userChoice = Console.ReadLine().Trim().ToUpper();

                if (userChoice == "NO")
                {
                    continueSelecting = false;
                    Console.WriteLine("Returning to the Main Menu...");
                }

            } while (continueSelecting);
        }

    } 

}
