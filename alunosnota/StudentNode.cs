namespace alunosnota
{
    internal class StudentNode
    {
        StudentNode? next = null;
        Student data;

        public StudentNode(Student data)
        {
            this.data = data;
        }

        public StudentNode? Next() { return next; }

        public void SetNext(StudentNode? node) { next = node; }

        public Student GetData() { return data; }
    }
}
