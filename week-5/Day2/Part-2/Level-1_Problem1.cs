namespace StackUndo
{
    class StackUndo
    {
        private string[] stack;
        private int top;
        public StackUndo(int size)
        {
            stack = new string[size];
            top = -1;
        }
        public void Push(string action)
        {
            if (top == stack.Length - 1)
            {
                Console.WriteLine("Stack Overflow! Cannot add more actions.");
                return;
            }

            stack[++top] = action;
            Console.WriteLine($"Action Performed: {action}");
            Display();
        }

        public void Pop()
        {
            if (top == -1)
            {
                Console.WriteLine("Stack Underflow! No actions to undo.");
                return;
            }

            Console.WriteLine($"Undo Action: {stack[top--]}");
            Display();
        }

        public void Display()
        {
            Console.Write("Current State: ");

            if (top == -1)
            {
                Console.WriteLine("Empty");
                return;
            }

            for (int i = 0; i <= top; i++)
            {
                Console.Write(stack[i] + " ");
            }
            Console.WriteLine();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            StackUndo editor = new StackUndo(5);

            editor.Push("Type A");
            editor.Push("Type B");
            editor.Push("Type C");
            editor.Pop();  
            editor.Pop();  
        }
    }
}
