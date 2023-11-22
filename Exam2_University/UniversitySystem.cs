using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam2_University
{
    public class UniversitySystem
    {
        public void StartSystem()
        {
            using var dbContext = new UniversityContext();

            DepartmentService departmentService = new DepartmentService(dbContext);
            LectureService lectureService = new LectureService(dbContext);
            while (true)
            {
                departmentService.PrintDepartments();
                Console.WriteLine("---------------------------------");
                string inputDepartment = Console.ReadLine();

                Console.WriteLine("Jeigu norite sukurti departamenta - spauskite [N]");

                if (inputDepartment == "N")//Sukurti departamenta
                {
                    Console.Write("Iveskite departamento ID: ");
                    string inputId = Console.ReadLine();
                    Console.Write("Iveskite departamento pavadinima: ");
                    string inputName = Console.ReadLine();

                    departmentService.CreateDepartment(inputId, inputName);
                }

                Console.WriteLine("Jeigu norite prideti paskaitas - spauskite [A]");



                Department curentDepartment = departmentService.GetCurrentDepartment(inputDepartment);





                departmentService.PrintDepartmentMenu();
                Console.WriteLine("---------------------------------");
                string inputDepMenu = Console.ReadLine();

                if(inputDepMenu == "1")//Paskaitos
                {
                    departmentService.PrintLectures(curentDepartment.Lectures);
                    Console.WriteLine("---------------------------------");
                }
                else if(inputDepMenu == "2")//Studentai
                {
                    departmentService.PrintStudents(curentDepartment);
                    Console.WriteLine("---------------------------------");
                }

            }

           

        }
    }
}
