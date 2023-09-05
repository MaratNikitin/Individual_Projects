using LinqDemo.Models;

int[] numbers = {1,2,3,4,5,6,7,8,9};

OddNumbersSortedDesc(numbers);

//MaleStudents();

static void OddNumbersSortedDesc(int[] numbers)
{
    Console.WriteLine("Odd numbers: ");

    IEnumerable<int> oddNumbers = from number in numbers where number % 2 != 0 orderby number descending select number;

    foreach (int number in oddNumbers)
    {
        Console.WriteLine(number);
    }
}

void MaleStudents()
{
    UniversityManager _universityManager = new();
    IEnumerable<Student> maleStudent = from Student student in _universityManager where student.Gender == "Male" select student;
    Console.WriteLine($"Male students: ");

    foreach (Student student in maleStudent)
    {
        student.Print();
    }
}