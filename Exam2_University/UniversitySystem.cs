using Microsoft.EntityFrameworkCore;
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
            StudentService studentService = new StudentService(dbContext);
            GeneralService generalService = new GeneralService();
            while (true)
            {

                Console.Clear();
                Console.WriteLine("--------------MENIU--------------");
                Console.WriteLine("1 - DEPARTAMENTAI");
                Console.WriteLine("2 - STUDENTAI");
                Console.WriteLine("3 - PASKAITOS");
                Console.WriteLine("---------------------------------");
                Console.Write("Ivestis: ");
                string inputMainMenu = Console.ReadLine().ToUpper();


                if (inputMainMenu == "1")
                {
                    //INFORMACIJA:
                    //DEPARTAMENTAI - RODOMI VISI DEPARTAMENTAI IR GALIMYBE SUKURTI NAUJUS
                    while (true)
                    {
                        Console.Clear();
                        departmentService.PrintDepartments();
                        Console.WriteLine("---------------------------------");

                        Console.WriteLine("*Sukurti departamenta - spauskite [N]");
                        Console.WriteLine("*Rodyti departamenta - iveskite ID");
                        Console.WriteLine("*Grizti - spauskite [Q]");
                        Console.Write("Ivestis: ");
                        string inputDepartment = Console.ReadLine().ToUpper();

                        if (inputDepartment == "Q")
                        {
                            break;
                        }

                        if (inputDepartment == "N")
                        {
                            Console.Clear();
                            Department department = departmentService.CreateDepartment();

                            if(department.DepartmentId == null)
                            {
                                continue;
                            }
                            dbContext.Departments.Add(department);
                            

                            Console.WriteLine("*Jeigu norite prideti paskaitas - spauskite [A]");
                            Console.Write("Ivestis: ");
                            string inputLectureAdd = Console.ReadLine().ToUpper();

                            if (inputLectureAdd == "A")
                            {
                                lectureService.PrintLectures(dbContext.Lectures.ToList());

                                Console.WriteLine("Pasirinkite paskaita kuria norite prideti: ");
                                Console.WriteLine("Grizti - spauskite [Q]");
                                int inputUser = generalService.ValidateInputStringToInt();

                                if (inputUser == -1)
                                {
                                    break;
                                }

                                var lecture = departmentService.GetLectureById(inputUser);
                                department.Lectures.Add(lecture);

                            }
                            dbContext.SaveChanges();
                        }

                        Department curentDepartment = departmentService.GetCurrentDepartment(inputDepartment);

                        if (curentDepartment == null)
                        {
                            continue;
                        }

                        Console.Clear();
                        Console.WriteLine($"--------------{curentDepartment.Name}--------------");
                        Console.WriteLine("1 - Paskaitos");
                        Console.WriteLine("2 - Studentai");
                        Console.WriteLine("---------------------------------");
                        Console.Write("Ivestis: ");

                        string inputDepMenu = Console.ReadLine().ToUpper();

                        if (inputDepMenu == "1")
                        {
                            //INFORMACIJA:
                            //DEPARTAMENTO PASKAITOS - RODOMOS PASKAITOS KURIOS PRIKLAUSO PASIRINKTAM DEPARTAMENTUI


                            while (true)
                            {
                                Console.Clear();
                                var lectures = curentDepartment.Lectures;
                                lectureService.PrintLectures(lectures);
                                Console.WriteLine("---------------------------------");
                                Console.WriteLine("*Redaguoti paskaita - iveskite id");
                                Console.WriteLine("*Grizti - spauskite [Q]");
                                Console.Write("Ivestis: ");
                                string inputLecture = Console.ReadLine().ToUpper();

                                if (inputLecture == "Q")
                                {
                                    break;
                                }
                            }
                        }

                        else if (inputDepMenu == "2")
                        {
                            //INFORMACIJA:
                            //DEPARTAMENTO STUDENTAI - RODOMI STUDENTAI KURIE PRIKLAUSO PASIRINKTAM DEPARTAMENTUI.
                            //RODOMOS PASKAITOS KURIOS PRIKLAUSO KONKRECIAM STUDENTUI.
                            //STUDENTO PERKELIMAS I KITA DEPARTAMENTA.


                            Console.Clear();
                            while (true)
                            {
                                Console.Clear();
                                studentService.PrintStudents(curentDepartment.Students);
                                Console.WriteLine("---------------------------------");

                                Console.WriteLine("*Redaguoti studenta - iveskite asmens koda");
                                Console.WriteLine("*Grizti - spauskite [Q]");
                                Console.Write("Ivestis: ");

                                string inputStudent = Console.ReadLine().ToUpper();

                                if (inputStudent == "Q")
                                {
                                    break;
                                }
                                Student currentStudent = studentService.GetStudentById(curentDepartment,inputStudent);

                                if (currentStudent == null)
                                {
                                    continue;
                                }

                                while (true)
                                {
                                    Console.Clear();
                                    Console.WriteLine($"---------{currentStudent.FirstName} {currentStudent.LastName}---------");
                                    Console.WriteLine("1 - Rodyti paskaitas");
                                    Console.WriteLine("2 - Pakeisti departamenta");
                                    Console.WriteLine("3 - Prideti paskaitas");
                                    Console.WriteLine("*Grizti - spauskite [Q]");
                                    Console.WriteLine("---------------------------------");
                                    Console.Write("Ivestis: ");
                                    inputStudent = Console.ReadLine().ToUpper();

                                    if (inputStudent == "Q")
                                    {
                                        break;
                                    }

                                    if (inputStudent == "1")
                                    {
                                        Console.Clear();
                                        lectureService.PrintLectures(currentStudent.Lectures);
                                        Console.ReadLine();
                                    }
                                    else if (inputStudent == "2")
                                    {
                                        Console.Clear();
                                        Console.WriteLine("*Iveskite departamento ID:");
                                        Console.Write("Ivestis: ");
                                        string newDepartmentId = Console.ReadLine();

                                        var newDepartment = departmentService.GetDepartmentById(newDepartmentId);

                                        if (newDepartment != null)
                                        {
                                            currentStudent.Department = newDepartment;
                                            currentStudent.Lectures = newDepartment.Lectures;
                                        }
                                    }
                                    else if(inputStudent == "3")
                                    {
                                        while (true)
                                        {
                                            Console.Clear();
                                            Console.WriteLine($"--------------{curentDepartment.Name}--------------");
                                            lectureService.PrintLectures(currentStudent.Lectures);
                                            Console.WriteLine($"--------------ALL--------------");
                                            lectureService.PrintLectures(dbContext.Lectures.ToList());

                                            Console.WriteLine("*Iveskite paskaitos ID:");
                                            Console.WriteLine("*Grizti - spauskite [Q]");
                                            
                                            int inputUser = generalService.ValidateInputStringToInt();

                                            if(inputUser == -1)
                                            {
                                                break;
                                            }

                                            var lecture = lectureService.GetLectureById(inputUser);

                                            currentStudent.Lectures.Add(lecture);
                                            dbContext.SaveChanges();
                                        }
                                        
                                    }
                                    else
                                    {
                                        continue;
                                    }
                                }
                                
                            }
                        }
                    }
                }


                else if(inputMainMenu == "2")
                {
                    //INFORMACIJA:
                    //STUDENTAI - RODOMI VISI STUDENTAI IR GALIMYBE SUKURTI NAUJUS


                    while (true)
                    {
                        Console.Clear();
                        studentService.PrintStudents(dbContext.Students.Include(x => x.Department).ToList());
                        Console.WriteLine("---------------------------------");

                        Console.WriteLine("*Sukurti studenta - spauskite [N]");
                        Console.WriteLine("*Grizti - spauskite [Q]");
                        Console.Write("Ivestis: ");
                        string inputStudent = Console.ReadLine().ToUpper();

                        if(inputStudent == "Q")
                        {
                            break;
                        }

                        if (inputStudent == "N")
                        {
                            Console.Clear();
                            var student = studentService.CreateStudent();

                            if(student.StudentId != null)
                            {
                                dbContext.Students.Add(student);
                                dbContext.SaveChanges();
                            }
                            
                        }
                    }
                   
                }


                else if(inputMainMenu == "3")
                {
                    //INFORMACIJA:
                    //PASKAITOS - RODOMOS VISOS PASKAITOS IR GALIMYBE SUKURTI NAUJAS

                    while (true)
                    {
                        Console.Clear();
                        lectureService.PrintLectures(dbContext.Lectures.ToList());
                        Console.WriteLine("---------------------------------");
                        Console.WriteLine("*Sukurti paskaita - spauskite [N]");
                        Console.WriteLine("*Grizti - spauskite [Q]");
                        Console.Write("Ivestis: ");
                        string inputLecture = Console.ReadLine().ToUpper();

                        if (inputLecture == "Q")
                        {
                            break;
                        }

                        if (inputLecture == "N")
                        {
                            Console.Clear();
                            var lecture = lectureService.CreateLecture();
                            dbContext.Lectures.Add(lecture);

                            Console.WriteLine("*Jeigu norite priskirti departamentus - spauskite [A]");
                            Console.Write("Ivestis: ");
                            string inputDepartmentAdd = Console.ReadLine().ToUpper();
                            dbContext.SaveChanges();

                            if (inputDepartmentAdd == "A")
                            {
                                departmentService.PrintDepartments();

                                lectureService.AddDepartmentsToLecture(lecture);

                                dbContext.SaveChanges();
                            }
                            
                        }
                    }
                    
                }


                else
                {
                    continue;
                }
            }
        }
    }
}
