using System;
using System.Collections.Generic;
using System.Linq;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public Course Course { get; set; }
}

public class Course
{
    public int CourseId { get; set; }
    public string CourseName { get; set; }
}

public class StudentManager
{
    private List<Student> students = new List<Student>();

    public void AddStudent(Student student)
    {
        student.Id = students.Count + 1;
        students.Add(student);
    }

    public void ViewStudents()
    {
        Console.WriteLine("List of Students:");
        foreach (var student in students)
        {
            Console.WriteLine($"ID: {student.Id}, Name: {student.Name}, Age: {student.Age}, Course: {student.Course.CourseName}");
        }
    }

    public void UpdateStudent(int studentId, Student updatedStudent)
    {
        Student existingStudent = students.FirstOrDefault(s => s.Id == studentId);
        if (existingStudent != null)
        {
            existingStudent.Name = updatedStudent.Name;
            existingStudent.Age = updatedStudent.Age;
            existingStudent.Course = updatedStudent.Course;
        }
    }

    public void DeleteStudent(int studentId)
    {
        Student studentToDelete = students.FirstOrDefault(s => s.Id == studentId);
        if (studentToDelete != null)
        {
            students.Remove(studentToDelete);
        }
    }

    public List<Student> FindStudentsAboveAge(int age)
    {
        return students.Where(s => s.Age > age).ToList();
    }

    public List<Student> FindStudentsInCourse(string courseName)
    {
        return students.Where(s => s.Course.CourseName == courseName).ToList();
    }
}

public class CourseManager
{
    private List<Course> courses = new List<Course>();

    public void AddCourse(Course course)
    {
        courses.Add(course);
    }

    public void ViewCourses()
    {
        Console.WriteLine("List of Courses:");
        foreach (var course in courses)
        {
            Console.WriteLine($"Course ID: {course.CourseId}, Course Name: {course.CourseName}");
        }
    }
}

class Program
{
    static void Main()
    {
        // Creating instances of StudentManager and CourseManager
        StudentManager studentManager = new StudentManager();
        CourseManager courseManager = new CourseManager();

        // Adding courses
        Course mathCourse = new Course { CourseId = 1, CourseName = "Mathematics" };
        Course physicsCourse = new Course { CourseId = 2, CourseName = "Physics" };
        courseManager.AddCourse(mathCourse);
        courseManager.AddCourse(physicsCourse);

        // Adding students
        Student student1 = new Student { Name = "Alice", Age = 22, Course = mathCourse };
        Student student2 = new Student { Name = "Bob", Age = 25, Course = physicsCourse };
        Student student3 = new Student { Name = "Charlie", Age = 30, Course = mathCourse };

        studentManager.AddStudent(student1);
        studentManager.AddStudent(student2);
        studentManager.AddStudent(student3);

        // Viewing students and courses
        studentManager.ViewStudents();
        courseManager.ViewCourses();

        // Updating a student
        studentManager.UpdateStudent(1, new Student { Name = "Alicia", Age = 23, Course = physicsCourse });
        studentManager.ViewStudents();

        // Deleting a student
        studentManager.DeleteStudent(2);
        studentManager.ViewStudents();

        // LINQ Operations
        Console.WriteLine("Students above 25 years old:");
        var studentsAbove25 = studentManager.FindStudentsAboveAge(25);
        foreach (var student in studentsAbove25)
        {
            Console.WriteLine($"Name: {student.Name}, Age: {student.Age}, Course: {student.Course.CourseName}");
        }

        Console.WriteLine("\nStudents in Mathematics course:");
        var mathStudents = studentManager.FindStudentsInCourse("Mathematics");
        foreach (var student in mathStudents)
        {
            Console.WriteLine($"Name: {student.Name}, Age: {student.Age}, Course: {student.Course.CourseName}");
        }
    }
}
