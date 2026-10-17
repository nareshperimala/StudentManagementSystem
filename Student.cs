using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SelectWithListLibrary
{
    public class StudentEntry
    {
        public int Student_Id, Age;
        public string FirstName, LastName, Gender, PhoneNo, Email, CourseName;
       
        public DateTime DOB,EnrollmentDate;
        public StudentEntry(int Student_Id,string FirstName,string LastName,int Age,string Gender,DateTime DOB,string PhoneNo,string Email,
            DateTime EnrollmentDate,string CourseName)
        {
            this.Student_Id = Student_Id;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Age = Age;
            this.Gender = Gender;
            this.DOB = DOB;
            this.PhoneNo = PhoneNo;
            this.Email = Email;
            this.EnrollmentDate= EnrollmentDate;
            this.CourseName = CourseName;
          
        }

    }
    public class StudentData
    {
        public int Student_Id, Age;
        public string FirstName, LastName, Gender, PhoneNo, Email, CourseName;

        public decimal FixedAmount, PaidAmount;
        public DateTime  EnrollmentDate;
        public StudentData(int Student_Id, string FirstName, string LastName, int Age, string Gender, string PhoneNo, string Email,
            DateTime EnrollmentDate, string CourseName, decimal FixedAmount,decimal PaidAmount)
        {
            this.Student_Id = Student_Id;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Age = Age;
            this.Gender = Gender;
          
            this.PhoneNo = PhoneNo;
            this.Email = Email;
            this.EnrollmentDate = EnrollmentDate;
            this.CourseName = CourseName;
            this.FixedAmount = FixedAmount;
            this.PaidAmount= PaidAmount;
         

        }

    }

    public class PaymentDetails
    {
        public int  Student_Id;
        public string StudentName,CourseName,PaymentMode, PaymentStatus;
        public DateTime PaymentDate;
        public decimal BalanceFees;
      

        public PaymentDetails(int Student_Id,string StudentName,string CourseName,decimal BalanceFees,
            DateTime PaymentDate,string PaymentMode,string PaymentStatus)
        {
      
            this.Student_Id= Student_Id;
            this.StudentName= StudentName;
            this.CourseName= CourseName;
            this.BalanceFees=BalanceFees;
            this.PaymentDate= PaymentDate;
            
            this.PaymentMode= PaymentMode;
            this.PaymentStatus= PaymentStatus;

        }
    }

    public class Trainer
    {
        public int Trainer_Id, Age, Salary;
        public string CourseName, TrainerName, Email, Gender, Qualification, ContactNo, City;
        public DateTime Hire_Date;
        public Trainer(int Trainer_Id, string TrainerName, string CourseName, string Email, int Age,
            string Gender, string Qualification, string ContactNo, DateTime Hire_Date, int Salary, string City)
        {
            this.Trainer_Id = Trainer_Id;

            this.TrainerName = TrainerName;
            this.CourseName = CourseName;
            this.Email = Email;
            this.Age = Age;
            this.Gender = Gender;
            this.Qualification = Qualification;
            this.ContactNo = ContactNo;
            this.Hire_Date = Hire_Date;
            this.Salary = Salary;
            this.City = City;
        }
    }

}

