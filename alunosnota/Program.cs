using alunosnota;

IdGenerator idGenerator = new IdGenerator();

StudentStack studentStack = new StudentStack();
GradeQueue gradeQueue = new GradeQueue(); 

int inputInteger(string message, int? min = null, int? max = null)
{
    Console.Write(message);
    int value = int.Parse(Console.ReadLine());

    while (true)
    {
        bool correctValue = (min != null ? value >= min : true) && (max != null ? value <= max : true);

        if (correctValue)
            break;

        string invalid = min != null ? $"Valor precisa ser maior ou igual a {min}" : "";
        invalid += invalid == "" ? "Valor precisa ser " : max != null ? " e " : "";
        invalid += max != null ? $"menor ou igual a {max}" : "";
        invalid += ": ";

        Console.Write(invalid);
        value = int.Parse(Console.ReadLine());
    }

    return value;
}

void waitForAnyKey()
{
    Console.WriteLine("\nPressione qualquer tecla para continuar.");
    Console.ReadKey();
}

int selectStudent()
{
    Console.Clear();

    if (studentStack.Empty())
        return -1;

    Console.WriteLine("Números dos alunos: ");
    studentStack.DisplayStudentsIds();

    Console.WriteLine("\n");

    int studentId = inputInteger("Digite o número do aluno: ", min: 1);

    while (true)
    {
        if (studentStack.HasStudent(studentId))
            break;

        studentId = inputInteger("Aluno inexistente. Tente outro aluno: ", min: 1);
    }

    return studentId;
}

void registerStudent()
{
    Console.Clear();
    Console.Write("Digite o nome do aluno: ");
    string name = Console.ReadLine();

    Student student = new Student(name, idGenerator.NextId());

    Console.WriteLine("Aluno criado: ");
    Console.WriteLine(student);

    studentStack.Push(student);
}

void registerGrade()
{
    Console.Clear();

    if (studentStack.Empty())
    {
        Console.WriteLine("Não há estudantes cadastrados.");
        return;
    }

    int studentId = selectStudent();

    while (true)
    {
        if (gradeQueue.CountStudentGrades(studentId) < 2)
            break;

        int option = inputInteger("Aluno já possui duas notas. Deseja cancelar operação ou tentar outro número? (0 = Cancelar, 1 = Tentar novamente)", min: 0, max: 1);

        if (option == 0)
            return;

        studentId = selectStudent();
    }

    Console.Write("\nDigite a nota do aluno: ");
    double grade = double.Parse(Console.ReadLine());

    while (grade < 0)
    {
        Console.Write("Nota tem que ser maior que 0, tente novamente: ");
        grade = double.Parse(Console.ReadLine());
    }

    gradeQueue.Enqueue(new StudentGrade(grade, studentId));
}

void displayAverageGrade()
{
    if (gradeQueue.Empty())
    {
        Console.Clear();
        Console.WriteLine("Não há notas cadastradas.");
        return;
    }

    int studentId = selectStudent();

    Console.Clear();

    double average = gradeQueue.GetStudentAverage(studentId);

    if (Double.IsNaN(average))
    {
        Console.WriteLine($"Aluno {studentId} não tem notas suficientes cadastradas para gerar média.");
        return;
    }

    Console.WriteLine($"Média do aluno {studentId}: {average.ToString("0.0")}");
}

bool allStudentsHaveGrades()
{
    Student[]? students = studentStack.GetStudents();

    if (students == null)
        return false;

    for (int i = 0; i < students.Length; i++)
        if (!gradeQueue.HasStudent(students[i].GetId()))
            return false;

    return true;
}

void displayStudentsWithNoGrades()
{
    if (studentStack.Empty())
    {
        Console.Clear();
        Console.WriteLine("Não há estudantes cadastrados.");
        return;
    }

    if (gradeQueue.Empty())
    {
        Console.Clear();
        Console.WriteLine("Não há notas cadastradas.");
        return;
    }

    if (allStudentsHaveGrades())
    {
        Console.Clear();
        Console.WriteLine("Todos alunos possuem ao menos uma nota.");
        return;
    }

    Console.Clear();

    Student[]? students = studentStack.GetStudents();

    if (students == null)
        return;

    Console.WriteLine("Alunos que não possuem nenhuma nota cadastrada: ");

    for (int i = 0; i < students.Length; i++)
        if (!gradeQueue.HasStudent(students[i].GetId()))
            Console.WriteLine($"{students[i]}\n");
}

void removeStudent()
{
    Console.Clear();

    if (studentStack.Empty())
    {
        
        Console.WriteLine("Não há estudantes cadastrados.");
        return;
    }

    bool hasGrades = gradeQueue.HasStudent(studentStack.GetFirstStudent().GetId());

    if (hasGrades)
    {
        Console.WriteLine("Aluno possui ao menos uma nota e não pode ser excluído.");
        return;
    }

    Student? student = studentStack.Pop();

    Console.WriteLine($"Aluno {student.GetId()} excluído.");
}

void removeGrade()
{
    Console.Clear();

    if (gradeQueue.Empty())
    {

        Console.WriteLine("Não há notas cadastradas.");
        return;
    }

    StudentGrade? studentGrade = gradeQueue.Dequeue();

    Console.WriteLine($"Nota do aluno {studentGrade.GetStudentId()} excluída.");
}

int selectOperationMenu()
{
    Console.Clear();
    Console.WriteLine("[ 1 ] Cadastrar aluno\n[ 2 ] Cadastrar nota\n[ 3 ] Mostrar média\n[ 4 ] Listar alunos sem nota\n[ 5 ] Excluir aluno\n[ 6 ] Excluir nota\n[ 0 ] Sair");
    return inputInteger("Sua opção: ", min: 0, max: 6);
}

while (true)
{
    switch (selectOperationMenu())
    {
        case 1:
            registerStudent();
            waitForAnyKey();
            break;
        case 2:
            registerGrade();
            break;
        case 3:
            displayAverageGrade();
            waitForAnyKey();
            break;
        case 4:
            displayStudentsWithNoGrades();
            waitForAnyKey();
            break;
        case 5:
            removeStudent();
            waitForAnyKey();
            break;
        case 6:
            removeGrade();
            waitForAnyKey();
            break;
        default:
            Environment.Exit(0);
            break;
    }
}

