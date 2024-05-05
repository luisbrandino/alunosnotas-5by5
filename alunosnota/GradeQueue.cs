namespace alunosnota
{
    internal class GradeQueue : Queue
    {
        public int CountStudentGrades(int studentId)
        {
            int count = 0;

            StudentGradeNode? current = this.top;

            while (current != null)
            {
                if (current.GetData().GetStudentId() == studentId)
                    count++;

                current = current.Next();
            }

            return count;
        }

        public double GetStudentAverage(int studentId)
        {
            if (this.Empty())
                return double.NaN;

            int grades = this.CountStudentGrades(studentId);

            if (grades != 2)
                return double.NaN;

            double average = 0;

            StudentGradeNode? current = this.top;

            while (current != null)
            {
                if (current.GetData().GetStudentId() == studentId)
                    average += current.GetData().GetGrade();

                current = current.Next();
            }

            average /= grades;

            return average;
        }

        public bool HasStudent(int studentId)
        {
            if (studentId < 1)
                return false;

            if (Empty())
                return false;

            StudentGradeNode? current = this.top;

            while (current != null)
            {
                if (current.GetData().GetStudentId() == studentId)
                    return true;

                current = current.Next();
            }

            return false;
        }

    }
}
