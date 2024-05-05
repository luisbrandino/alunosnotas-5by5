namespace alunosnota
{
    internal class StudentGradeNode
    {
        StudentGradeNode? next = null;
        StudentGrade data;

        public StudentGradeNode(StudentGrade data)
        {
            this.data = data;
        }

        public StudentGradeNode? Next() { return next; }

        public void SetNext(StudentGradeNode? node) { next = node; }

        public StudentGrade GetData() { return data; }
    }
}
