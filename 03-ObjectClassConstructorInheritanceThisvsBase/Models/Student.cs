namespace _03_ObjectClassConstructorInheritanceThisvsBase.Models
{
    internal class Student:Person
    {
        public string studentNumber;
        public string faculty;
        public double gpa;
        public int year;

        public Student(string firstName, string lastName, int age, string email, string id, string studentNumber, string faculty, double gpa, int year):base(firstName,lastName, age, email, id)
        {
            this.studentNumber = studentNumber;
            this.faculty = faculty;
            this.gpa = gpa;
            this.year = year;
        }

        public void ShowStudentInfo()
        {
            Console.WriteLine($"Tam ad: {GetFullName()}\nYas: {age}\nEmail: {email}\nID: {id}\nTelebe nomresi: {studentNumber}\nFakulte: {faculty}\nGPA: {gpa}\nKurs: {year}");
        }

        public double CalculateScholarship()
        {
            return gpa >= 90 ? 500 : gpa >= 80 ? 350 : gpa >= 70 ? 200 : 0;
        }
    }
}