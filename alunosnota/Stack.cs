namespace alunosnota
{
    internal class Stack
    {
        protected StudentNode? top = null;

        public bool Empty() { return top == null; }

        public void Push(Student item)
        {
            StudentNode node = new StudentNode(item);

            if (this.Empty())
            {
                this.top = node;
                return;
            }

            node.SetNext(this.top);
            this.top = node;
        }

        public Student? Pop()
        {
            if (this.top == null)
                return null;

            StudentNode node = this.top;
            this.top = this.top.Next();

            return node.GetData();
        }
    }
}
