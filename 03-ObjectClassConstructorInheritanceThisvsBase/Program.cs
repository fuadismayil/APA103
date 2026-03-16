using _03_ObjectClassConstructorInheritanceThisvsBase.Models;

namespace _03_ObjectClassConstructorInheritanceThisvsBase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student student1 = new Student("Ali", "Aliyev", 19, "ali@edu.az", "ID001", "APA101", "Komputer muhendisliyi", 88.5, 2);
            Student student2 = new Student("Murad", "Muradov", 20, "murad@edu.az", "ID002", "APA102", "Informasiya texnologiyalari", 92.0, 3);
            Student student3 = new Student("Huseyn", "Huseynov", 18, "huseyn@edu.az", "ID003", "APA103", "Informasiya tehlukesizliyi", 68.5, 1);
            Teacher teacher1 = new Teacher("Ismayil", "Ismayilov", 45, "ismayil@edu.az", "ID004", "Komputer Elmleri", "Proqramlasdirma", 800, 15);
            Teacher teacher2 = new Teacher("Veli", "Veliyev", 35, "veli@edu.az", "ID005", "Riyaziyyat", "Ali Riyaziyyat", 700, 8);
            Administrator admin = new Administrator("Fuad", "Ismayilov", 35, "fuad@edu.az", "ID006", "Dekan", "Muhendislik", 5);

            student1.ShowStudentInfo();
            System.Console.WriteLine($"Teqaud: {student1.CalculateScholarship()} AZN\n");

            student2.ShowStudentInfo();
            System.Console.WriteLine($"Teqaud: {student2.CalculateScholarship()} AZN\n");

            student3.ShowStudentInfo();
            System.Console.WriteLine($"Teqaud: {student3.CalculateScholarship()} AZN\n");

            teacher1.ShowTeacherInfo();
            System.Console.WriteLine($"Maas: {teacher1.CalculateSalary()} AZN\n");

            teacher2.ShowTeacherInfo();
            System.Console.WriteLine($"Maas: {teacher2.CalculateSalary()} AZN\n");

            admin.ShowAdminInfo();
            admin.GrantAccess(student1);
            System.Console.WriteLine();

            Student[] students = {student1, student2, student3 };
            double totalScholarship = 0;

            for (int i = 0; i < students.Length; i++)
            {
                totalScholarship += students[i].CalculateScholarship();
            }
            System.Console.WriteLine($"Umumi teqaud xerci: {totalScholarship} AZN");

            Teacher[] teachers = { teacher1, teacher2 };
            double totalSalary = 0;

            for (int i = 0; i < teachers.Length; i++)
            {
                totalSalary += teachers[i].CalculateSalary();
            }
            System.Console.WriteLine($"Umumi maas xerci: {totalSalary} AZN");
        }
    }
}