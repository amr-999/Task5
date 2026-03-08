namespace Task5
{
	class Instructor
	{

		public int InstructorId { get; set; }
		public string Name { get; set; }
		public string Specialization { get; set; }

		public Instructor(int instructorId, string name, string specialization)
		{
			InstructorId = instructorId;
			Name = name;
			Specialization = specialization;
		}
		public string PrintDetails()
		{
			return "Instructor Id: " + InstructorId + "  Name: " + Name +
					" Specialization: " + Specialization;
		}


	}
	class Course
	{
		public int CourseId { get; set; }
		public string Title { get; set; }
		public Instructor Instructor { get; set; }

		public Course(int courseId, string title, Instructor instructor)
		{
			CourseId = courseId;
			Title = title;
			Instructor = instructor;
		}
		public string PrintDetails()
		{
			string instructorInfo = Instructor.Name + " Id: " + Instructor.InstructorId;


			return "Course Id: " + CourseId + " Title: " + Title + " Instructor: " + instructorInfo;
		}

	}
	class Student
	{
		public int StudentId { get; set; }
		public string Name { get; set; }
		public int Age { get; set; }

		public List<Course> Courses { get; set; }

		public Student(int studentId, string name, int age)
		{
			StudentId = studentId;
			Name = name;
			Age = age;
			Courses = new List<Course>();
		}

		public bool Enroll(Course course)
		{
			for (int i = 0; i < Courses.Count; i++)
			{
				if (Courses[i].CourseId == course.CourseId)
					return false;
			}
			Courses.Add(course);
			return true;
		}
		public string PrintDetails()
		{
			string courseList = "";
			for (int i = 0; i < Courses.Count; i++)
			{
				courseList +=  Courses[i].Title + " Id: " + Courses[i].CourseId + " , ";
			}
			return "Student Id: " + StudentId + "  Name: " + Name
				+ "  Age: " + Age + " Courses: " + courseList;
		}
	}



	class StudentManager
	{
		public List<Student> Students { get; set; } = new List<Student>();
		public List<Course> Courses { get; set; } = new List<Course>();
		public List<Instructor> Instructors { get; set; } = new List<Instructor>();

		public bool AddStudent(Student student)
		{
			for (int i = 0; i < Students.Count; i++)
			{
				if (Students[i].StudentId == student.StudentId)
					return false;
			}
			Students.Add(student);
			return true;
		}
		public bool AddCourse(Course course)
		{
			for (int i = 0; i < Courses.Count; i++)
			{
				if (Courses[i].CourseId == course.CourseId)
					return false;
			}
			Courses.Add(course);
			return true;
		}
		public bool AddInstructor(Instructor instructor)
		{
			for (int i = 0; i < Instructors.Count; i++)
			{
				if (Instructors[i].InstructorId == instructor.InstructorId)
					return false;
			}
			Instructors.Add(instructor);
			return true;
		}
		public Student FindStudent(int studentId)
		{
			for (int i = 0; i < Students.Count; i++)
			{
				if (Students[i].StudentId == studentId)
					return Students[i];
			}
			return null;
		}
		public Student FindStudentByName(string name)
		{
			for (int i = 0; i < Students.Count; i++)
			{
				if (Students[i].Name == name)
					return Students[i];
			}
			return null;
		}
		public Course FindCourse(int courseId)
		{
			for (int i = 0; i < Courses.Count; i++)
			{
				if (Courses[i].CourseId == courseId)
					return Courses[i];
			}
			return null;
		}
		public Course FindCourseByName(string title)
		{
			for (int i = 0; i < Courses.Count; i++)
			{
				if (Courses[i].Title.ToLower() == title.ToLower())
					return Courses[i];
			}
			return null;
		}
		public Instructor FindInstructor(int instructorId)
		{
			for (int i = 0; i < Instructors.Count; i++)
			{
				if (Instructors[i].InstructorId == instructorId)
					return Instructors[i];
			}
			return null;
		}


		public bool EnrollStudentInCourse(int studentId, int courseId)
		{
			Student student = FindStudent(studentId);
			Course course = FindCourse(courseId);

			if (student == null || course == null)
				return false;

			return student.Enroll(course);
		}

		public bool UpdateStudent(int studentId, string newName, int newAge)
		{
			Student student = FindStudent(studentId);
			if (student == null)
				return false;

			student.Name = newName;
			student.Age = newAge;

			return true;
		}
		public bool DeleteStudent(int studentId)
		{
			for (int i = 0; i < Students.Count; i++)
			{
				if (Students[i].StudentId == studentId)
				{
					Students.RemoveAt(i);
					return true;
				}
			}
			return false;
		}
		public bool IsStudentEnrolledInCourse(int studentId, int courseId)
		{
			Student student = FindStudent(studentId);
			if (student == null) return false;

			for (int i = 0; i < student.Courses.Count; i++)
			{
				if (student.Courses[i].CourseId == courseId)
					return true;
			}
			return false;
		}
		public string GetInstructorByCourse(string courseTitle)
		{
			Course course = FindCourseByName(courseTitle);
			if (course == null) return "Course not found";
			if (course.Instructor == null) return "No instructor assigned this course";
			return course.Instructor.Name;
		}

	}
	internal class Program
	{
		static void Main(string[] args)
		{
			
			StudentManager manager = new StudentManager();

			int choice = 0;

			while (choice!= 14)
			{ 

			
			Console.WriteLine("\n1.  Add Student    ");
			Console.WriteLine("2.  Add Instructor ");
			Console.WriteLine("3.  Add Course  ");
			Console.WriteLine("4.  Enroll Student in Course ");
			Console.WriteLine("5.  Show All Students ");
			Console.WriteLine("6.  Show All Courses ");
			Console.WriteLine("7.  Show All Instructors  ");
			Console.WriteLine("8.  Find Student (ID or Name)");
			Console.WriteLine("9.  Find Course  (ID or Name) ");
			Console.WriteLine("10. Update Student Information");
			Console.WriteLine("11. Delete Student");
			Console.WriteLine("12. Check if Student is Enrolled");
			Console.WriteLine("13. Get Instructor by Course Name");
			Console.WriteLine("14. Exit ");

			Console.WriteLine("Enter your choice: ");
			 choice = Convert.ToInt32(Console.ReadLine());


				switch (choice)
				{
					case 1:
						{
							Console.WriteLine("Enter Student id: ");
							int id = Convert.ToInt32(Console.ReadLine());
							Console.WriteLine("Enter Student name: ");
							string name = Console.ReadLine();
							Console.WriteLine("Enter Student age: ");
							int age = Convert.ToInt32(Console.ReadLine());

							Student student = new Student(id, name, age);

							if (manager.AddStudent(student))
								Console.WriteLine($"Student {name} added");
							else
								Console.WriteLine("Student already exist");
							break;
						}
					case 2:
						{
							Console.WriteLine("Enter instructor id: ");
							int id = Convert.ToInt32(Console.ReadLine());
							Console.WriteLine("Enter instructor name: ");
							string name = Console.ReadLine();
							Console.WriteLine("Enter instructor Specialization : ");
							string spec = Console.ReadLine();

							Instructor instructor = new Instructor(id, name, spec);

							if (manager.AddInstructor(instructor))
								Console.WriteLine($"Instructor {name} added");
							else
								Console.WriteLine("Instructor already exist");
							break;
						}
					case 3:
						{
							Console.WriteLine("Enter course id: ");
							int id = Convert.ToInt32(Console.ReadLine());
							Console.WriteLine("Enter course title: ");
							string title = Console.ReadLine();
							Console.WriteLine("Enter instructor id: ");
							int instructorId = Convert.ToInt32(Console.ReadLine());

							Instructor instructor = manager.FindInstructor(instructorId);
							if (instructor == null)
							{
								Console.WriteLine("Instructor not found");
								break;
							}

							Course course = new Course(id, title, instructor);
							if (manager.AddCourse(course))
								Console.WriteLine($"Course {title} added");
							else
								Console.WriteLine("Course already exist");
							break;
						}
					case 4:
						{
							Console.WriteLine("Enter student id: ");
							int studentId = Convert.ToInt32(Console.ReadLine());
							Console.WriteLine("Enter course id: ");
							int courseId = Convert.ToInt32(Console.ReadLine());

							if (manager.FindStudent(studentId) == null)
							{
								Console.WriteLine("Student not found");
								break;
							}
							if (manager.FindCourse(courseId) == null)
							{
								Console.WriteLine("Course not found");
								break;
							}
							if (manager.EnrollStudentInCourse(studentId, courseId))
								Console.WriteLine("Enrollment done");
							else
								Console.WriteLine("Student already enrolled in this course");
							break;

						}
					case 5:
						{
							if (manager.Students.Count == 0)
							{
								Console.WriteLine("No students found");
								break;
							}
							for (int i = 0; i < manager.Students.Count; i++)
								Console.WriteLine(manager.Students[i].PrintDetails());
							break;
						}
					case 6:
						{
							if (manager.Courses.Count == 0)
							{
								Console.WriteLine("No courses found");
								break;
							}
							for (int i = 0; i < manager.Courses.Count; i++)
								Console.WriteLine(manager.Courses[i].PrintDetails());
							break;
						}
					case 7:
						{
							if (manager.Instructors.Count == 0)
							{
								Console.WriteLine("No instructors found");
								break;
							}
							for (int i = 0; i < manager.Instructors.Count; i++)
								Console.WriteLine(manager.Instructors[i].PrintDetails());
							break;
						}
					case 8:
						{
							Console.WriteLine("Search by: 1) Id   2) Name");
							string search = Console.ReadLine();

							Student student = null;
							if (search == "1")
							{
								Console.WriteLine("Enter student id: ");
								int id = Convert.ToInt32(Console.ReadLine());
								student = manager.FindStudent(id);
							}
							else
							{
								Console.WriteLine("Enter student name: ");
								string name = Console.ReadLine();
								student = manager.FindStudentByName(name);
							}
							if (student != null)
								Console.WriteLine(student.PrintDetails());
							else
								Console.WriteLine("Student not found");
							break;
						}
					case 9:
						{
							Console.WriteLine("Search by: 1) Id   2) Name");
							string search = Console.ReadLine();

							Course course = null;
							if (search == "1")
							{
								Console.WriteLine("Enter course id: ");
								int id = Convert.ToInt32(Console.ReadLine());
								course = manager.FindCourse(id);
							}
							else
							{
								Console.WriteLine("Enter course name: ");
								string name = Console.ReadLine();
								course = manager.FindCourseByName(name);
							}
							if (course != null)
								Console.WriteLine(course.PrintDetails());
							else
								Console.WriteLine("Course not found");
							break;
						}
					case 10:
						{
							Console.WriteLine("Enter student id: ");
							int id = Convert.ToInt32(Console.ReadLine());

							Student student = manager.FindStudent(id);
							if (student == null)
							{
								Console.WriteLine("Student not found");
								break;
							}
							Console.WriteLine("Current -> " + student.PrintDetails());
							Console.WriteLine("Enter new name");
							string newName = Console.ReadLine();
							Console.WriteLine("Enter new Age");
							int newAge = Convert.ToInt32(Console.ReadLine());

							if (manager.UpdateStudent(id, newName, newAge))
								Console.WriteLine("Student updated");
							else
								Console.WriteLine("Update failed");
							break;
						}
					case 11:
						{
							Console.WriteLine("Enter student id: ");
							int id = Convert.ToInt32(Console.ReadLine());
							if (manager.DeleteStudent(id))
								Console.WriteLine("Student deleted");
							else
								Console.WriteLine("Student not found");
							break;
						}
					case 12:
						{
							Console.WriteLine("Enter student id: ");
							int studentId = Convert.ToInt32(Console.ReadLine());
							Console.WriteLine("Enter course id: ");
							int courseId = Convert.ToInt32(Console.ReadLine());

							Student student = manager.FindStudent(studentId);
							Course course = manager.FindCourse(courseId);
							if (student == null)
							{
								Console.WriteLine("Student not found");
								break;
							}
							if (course == null)
							{
								Console.WriteLine("Course not found");
								break;
							}
							if (manager.IsStudentEnrolledInCourse(studentId, courseId))
								Console.WriteLine("Yes");
							else
								Console.WriteLine("No");
							break;
						}
					case 13:
						{
							Console.WriteLine("Enter course title");
							string title = Console.ReadLine();

							string result = manager.GetInstructorByCourse(title);
							Console.WriteLine(" Instructor: " + result);
							break;
						}
					case 14:
						break;
				}
			}
		}
	}
}
