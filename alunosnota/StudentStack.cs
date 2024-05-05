namespace alunosnota
{
    internal class StudentStack : Stack
    {
        public bool HasStudent(int studentId)
        {
            if (studentId < 1) 
                return false;

            if (Empty()) 
                return false;

            StudentNode? current = this.top;

            while (current != null)
            {
                if (current.GetData().GetId() == studentId) 
                    return true;

                current = current.Next();
            }

            return false;
        }

        public int Count()
        {
            int count = 0;

            StudentNode? current = this.top;

            while (current != null)
            {
                count++;
                current = current.Next();
            }

            return count;
        }

        public void DisplayStudentsIds()
        {
            StudentNode? current = this.top;

            while (current != null)
            {
                Console.Write($"{current.GetData().GetId()}");

                if (current.Next() != null)
                    Console.Write(" - ");

                current = current.Next();
            }
        }

        public Student? GetFirstStudent()
        {
            return this.top?.GetData();
        }

        public Student[]? GetStudents()
        {
            if (Empty())
                return null;

            Student[] students = new Student[this.Count()];

            StudentNode? current = this.top;
            int currentIndex = 0;

            while (current != null)
            {
                students[currentIndex++] = current.GetData();

                current = current.Next();
            }

            return students;
        }
    }
}
