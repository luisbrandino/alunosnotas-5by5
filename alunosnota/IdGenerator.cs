namespace alunosnota
{
    internal class IdGenerator
    {
        int currentId = 1; // primeiro aluno == nº 1

        public int NextId()
        {
            return currentId++;
        }
    }
}
