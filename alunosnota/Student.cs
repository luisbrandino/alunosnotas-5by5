namespace alunosnota
{
    internal class Student
    {
        string name;
        int id;

        public Student(string name, int id)
        {
            this.name = name;
            this.id = id;
        }

        public string GetName() { return name; }

        public int GetId() { return id; }

        public override string ToString() { return $"Nome: {this.name}\nNúmero: {this.id}"; }
    }
}
