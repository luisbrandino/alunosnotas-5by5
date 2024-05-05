using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace alunosnota
{
    internal class Queue
    {
        protected StudentGradeNode? top = null;
        protected StudentGradeNode? rear = null;

        public bool Empty() { return top == null; }

        public void Enqueue(StudentGrade item)
        {
            StudentGradeNode node = new StudentGradeNode(item);

            if (this.Empty())
            {
                this.top = this.rear = node;
                return;
            }

            this.rear?.SetNext(node);
            this.rear = node;
        }

        public StudentGrade? Dequeue()
        {
            if (this.top == null)
                return null;

            StudentGradeNode node = this.top;

            this.top = this.top.Next();

            if (this.top == null)
                this.rear = null;

            return node.GetData();
        }
    }
}
