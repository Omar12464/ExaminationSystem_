using ExaminationSystem_.BaseClass;

namespace ExaminationSystem_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the exam");
            Console.WriteLine("Enter Name of the Subject and its Id");
            int sub_Id=int.Parse(Console.ReadLine());
            string sub_Name=Console.ReadLine();
            Subject subject = new Subject(sub_Id, sub_Name);
            subject.CreateExam();
            subject.ExamSubject.ShowExam();
        }
    }
}
