//comment the code
//create modules/components
//Create Unit Tests & Document

using System;
using System.Text;
using System.IO;
using System.Collections.Generic;

namespace myproject
{
    public class Employees{
      /*
      *@param args
      */
      private string firstName;
      private string lastName;
      private int id;
      private int salary;
     
     //Default Constructer
      public Employees(){
         
      }
      //parameter Constructer
      public Employees(int id,string firstName,string lastName,int salary){
         this.id=id;
         this.firstName=firstName;
         this.lastName=lastName;
         this.salary=salary;
      }
      /**
	   * @return the FirtsName
	   */
      public string getFirstName(){
         return this.firstName;
      }
      /**
	   * @return the lastName
	   */
       public string getLastName(){
         return this.lastName;
      }
      /**
	   * @return the id
	   */
       public int getId(){
         return this.id;
      }
      /**
	   * @return the salary
	   */
       public int getSalary(){
         return this.salary;
      }
       /**
	    * @param firstName to set
	    */
        public void setFirstName(string firstName){
          this.firstName=firstName;
      }
      /**
	    * @param lastName to set
	    */
      public void setLastName(string lastName){
          this.lastName=lastName;
      }
      /**
	    * @param id to set
	    */
      public void setId(int id){
          this.id=id;
      }
      /**
	    * @param salary to set
	    */
      public void setSalary(int salary){
          this.salary=salary;
      }  
    
    }



    //Implementation Class Of Employee class
    public class EmployeeObject{
      public static void Main(string[] args){
         
         //List for storing Employee Details
           List<Employees> employee = new List<Employees>();

         Console.WriteLine("Enter the Number Of Employees:");
         int count=Convert.ToInt32(Console.ReadLine());
         //check count is positive or not
            if(count<=0){
            throw new NullReferenceException("Employee Count Should be positive Number");
            }
            
         if(count>0)
         {
            Console.WriteLine("enter The Employee details:"); 
         for(int i=1;i<=count;i++){
            Employees emp=new Employees();      //object for Employee 
          Console.WriteLine("enter Employee id:");
            int empid=Convert.ToInt32(Console.ReadLine());
             Console.WriteLine("enter Employee Firstname:");
            string fname=Console.ReadLine();
             Console.WriteLine("enter Employee LastName:");
            string lname=Console.ReadLine();
             Console.WriteLine("enter Employee Salary:");
            int sal=Convert.ToInt32(Console.ReadLine());
          /**
          *Set the value for firstname,lastename,id,salary
          */
         emp.setId(empid);
         emp.setFirstName(fname);
         emp.setLastName(lname);
         emp.setSalary(sal);    
         employee.Add(emp);   //add the employee object into list
         if(count>i)
         Console.WriteLine("Enter the Next Employee Details:");
         }


         //File Handling for storing employee Details
         string fpath = @"D:\Employee.txt"; 
          // Check file if exists
          if (File.Exists(fpath))
          {
             File.Delete(fpath);
          }
          /*
          *Write the Employee Object into file 
          */
          using (TextWriter wr = File.CreateText(fpath))
          {
             foreach (Employees item in employee)
           {
            wr.WriteLine(item.getId()+" "+item.getFirstName()+" "+item.getLastName()+" "+item.getSalary());
           }
          }

          /*
          *Read the Employee Details form file and print in the console
          */
          if (File.Exists(fpath))
          {
             // Open the file and read
             using (TextReader re = File.OpenText(fpath))
             {
               Console.WriteLine(re.ReadToEnd());
             }
          }
         

           //Update the EmployeeDetails
           Console.WriteLine("update............");
            Console.WriteLine("Do you want to upadte Employee Details:yes/no");
            string update=Console.ReadLine();
          
           int flag=0;
           if(update.Equals("yes")){
                        Console.WriteLine("Enter Employee Id for update:");
                        int num=Convert.ToInt32(Console.ReadLine());
                        foreach (Employees item in employee)
                        {
                              if(item.getId()==num)
                              {
                                 flag=1;
                                 Console.WriteLine("update Employee Firstname:");
                                 string fname=Console.ReadLine();
                                 Console.WriteLine("update Employee LastName:");
                                 string lname=Console.ReadLine();
                                 Console.WriteLine("update Employee Salary:");
                                 int sal=Convert.ToInt32(Console.ReadLine());
                                 item.setFirstName(fname);
                                 item.setLastName(lname);
                                 item.setSalary(sal);
                              }
                        }
                  if(flag==1){
                           Console.WriteLine("After Update...Employee Details:");
                           if (File.Exists(fpath))
                        {
                           File.Delete(fpath);
                        }
                        // Create the file
                        using (TextWriter wr = File.CreateText(fpath))
                        {
                           foreach (Employees item in employee)
                        {
                           wr.WriteLine(item.getId()+" "+item.getFirstName()+" "+item.getLastName()+" "+item.getSalary());
                        }
                        }
                           foreach (Employees i in employee)
                        {
                           Console.WriteLine(i.getId()+" "+i.getFirstName()+" "+i.getLastName()+" "+i.getSalary());
                        }
                      }
                  else{
                     Console.WriteLine("Employee id doesn't exists");
                  }
           }
           else{
            Console.WriteLine("No Updates in Employee Details");
           }
            
    
          

           //Delete the Employee
           int c=0;
           Console.WriteLine("Do you Want to Delete Employee:yes=1/no=0");
           int delete=Convert.ToInt32(Console.ReadLine());
           if(delete==1){
               Console.WriteLine("Delete............");
               Console.WriteLine("Enter Employee Id for delete:");
               int deleEmpId=Convert.ToInt32(Console.ReadLine());
               foreach (Employees item in employee)
                        {
                           c++;
                           if(item.getId()==deleEmpId){
                              break;
                           }
                          }
               if(c>count)
               {
                     Console.WriteLine("Employee Id Doesn't Exists");
               }
               else{
                        employee.RemoveAt(c-1);
                        Console.WriteLine("After Delete...Employee Details:");
                        if (File.Exists(fpath))
                     {
                        File.Delete(fpath);
                     }
                     // Create the file
                     using (TextWriter wr = File.CreateText(fpath))
                     {
                        foreach (Employees item in employee)
                     {
                        wr.WriteLine(item.getId()+" "+item.getFirstName()+" "+item.getLastName()+" "+item.getSalary());
                     }
                     }
                        foreach (Employees i in employee)
                     {
                        Console.WriteLine(i.getId()+" "+i.getFirstName()+" "+i.getLastName()+" "+i.getSalary());
                     }
               }
                  
             } 
         }
      }
    }
}
