namespace alunosnota
{
    internal class StudentGrade
    {
        double grade;
        int studentId;

        public StudentGrade(double grade, int studentId)
        {
            this.grade = grade;
            this.studentId = studentId;
        }

        public double GetGrade() { return grade; }
        public int GetStudentId() {  return studentId; }
    }
}
