namespace Node
{
    class Node
    {
        public int empId;
        public string name;
        public Node next;

        public Node(int id, string name)
        {
            this.empId = id;
            this.name = name;
            this.next = null;
        }
    }

    class EmployeeLinkedList
    {
        private Node head;
        public void InsertAtBeginning(int id, string name)
        {
            Node newNode = new Node(id, name);
            newNode.next = head;
            head = newNode;
        }
        public void InsertAtEnd(int id, string name)
        {
            Node newNode = new Node(id, name);

            if (head == null)
            {
                head = newNode;
                return;
            }

            Node temp = head;
            while (temp.next != null)
            {
                temp = temp.next;
            }

            temp.next = newNode;
        }

        public void Delete(int id)
        {
            if (head == null)
            {
                Console.WriteLine("List is empty.");
                return;
            }

            if (head.empId == id)
            {
                head = head.next;
                return;
            }

            Node temp = head;

            while (temp.next != null && temp.next.empId != id)
            {
                temp = temp.next;
            }

            if (temp.next == null)
            {
                Console.WriteLine("Employee not found.");
            }
            else
            {
                temp.next = temp.next.next; 
            }
        }

        public void Display()
        {
            if (head == null)
            {
                Console.WriteLine("List is empty.");
                return;
            }

            Node temp = head;
            while (temp != null)
            {
                Console.WriteLine($"{temp.empId} - {temp.name}");
                temp = temp.next;
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            EmployeeLinkedList list = new EmployeeLinkedList();

            int choice;
            do
            {
                Console.WriteLine("\n===== MENU =====");
                Console.WriteLine("1. Insert at Beginning");
                Console.WriteLine("2. Insert at End");
                Console.WriteLine("3. Delete by ID");
                Console.WriteLine("4. Display");
                Console.WriteLine("5. Exit");
                Console.Write("Enter choice: ");

                while (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.Write("Invalid input! Enter again: ");
                }

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter ID: ");
                        int id1 = int.Parse(Console.ReadLine());
                        Console.Write("Enter Name: ");
                        string name1 = Console.ReadLine();
                        list.InsertAtBeginning(id1, name1);
                        break;

                    case 2:
                        Console.Write("Enter ID: ");
                        int id2 = int.Parse(Console.ReadLine());
                        Console.Write("Enter Name: ");
                        string name2 = Console.ReadLine();
                        list.InsertAtEnd(id2, name2);
                        break;

                    case 3:
                        Console.Write("Enter ID to delete: ");
                        int delId = int.Parse(Console.ReadLine());
                        list.Delete(delId);
                        break;

                    case 4:
                        Console.WriteLine("\nEmployee List:");
                        list.Display();
                        break;

                    case 5:
                        Console.WriteLine("Exiting...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }

            } while (choice != 5);
        }
    }
}
