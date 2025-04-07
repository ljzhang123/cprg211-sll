using Assignment3.ProblemDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Assignment3.Utility
{
	public class SLL : ILinkedListADT
	{
		private Node head;
		private Node tail;
		private int listSize;

		//public Node Head { get => head; set => head = value; }
		//public Node Tail { get => tail; set => tail = value; }
		//public int ListSize { get => listSize; set => listSize = value; }

		public SLL()
		{
			head = null;
			tail = null;
			listSize = 0;
		}

		public bool IsEmpty()
		{
			return listSize == 0;
		}

		public void Clear()
		{
			head = null;
			tail = null;
			listSize = 0;
			Console.WriteLine("List cleared");
		}

		public void Append(object data)
		{
			Node newNode = new Node(data);
			if (IsEmpty())
			{
				head = newNode;
				tail = newNode;
			}
			else
			{
				tail.Next = newNode;
				tail = newNode;
			}
			listSize++;
		}

		public void Prepend(object data)
		{
			Node newNode = new Node(data);
			if (IsEmpty())
			{
				head = newNode;
				tail = newNode;
			}
			else
			{
				newNode.Next = head;
				head = newNode;
			}
			listSize++;
		}

		public void Insert(object data, int index)
		{
			if (index < 0 || index > listSize)
			{
				throw new IndexOutOfRangeException(Exceptions.IndexOutOfRangeException());
			}

			if (index == 0)
			{
				Prepend(data);
				return;
			}

			if (index == listSize)
			{
				Append(data);
				return;
			}

			// insert in middle
			Node newNode = new Node(data);
			Node current = head;
			for (int i = 0; i < index - 1; i++)
			{
				current = current.Next;
			}
			newNode.Next = current.Next;
			current.Next = newNode;
			listSize++;
		}

		public void Replace(object data, int index)
        {
            if (index < 0 || index >= listSize)
            {
                throw new IndexOutOfRangeException(Exceptions.IndexOutOfRangeException());
            }
            Node current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            current.Data = data;
        }

		public int Size() 
		{
			Console.WriteLine(listSize);
			return listSize; 
		}

		public void Delete(int index)
		{
			if (index < 0 || index >= listSize)
			{
				throw new IndexOutOfRangeException(Exceptions.IndexOutOfRangeException());
			}
			if (index == 0)
			{
				head = head.Next;
				if (listSize == 1) 
				{
					tail = null;
				}
			}
			else
			{
				Node current = head;
				for (int i = 0; i < index - 1; i++)
				{
					current = current.Next;
				}
				// current.Next is the node to delete
				current.Next = current.Next.Next;
				if (index == listSize - 1)
				{
					tail = current;
				}
			}
			listSize--;
		}

		public object Retrieve(int index)
		{
			if (index < 0 || index >= listSize)
			{
				throw new IndexOutOfRangeException(Exceptions.IndexOutOfRangeException());
			}
			Node current = head;
			for (int i = 0; i < index; i++)
			{
				current = current.Next;
			}
			return current.Data;
		}

		public int IndexOf(object data)
		{
			Node current = head;
			int index = 0;
			while (current != null)
			{
				// Use Equals to allow proper object comparisons.
				if (current.Data.Equals(data))
				{
					return index;
				}
				index++;
				current = current.Next;
			}
			return -1;
		}

		public bool Contains(object data)
		{
			return IndexOf(data) != -1;
		}

		// EXTRA METHODS
		public void Reverse()
		{
			if (IsEmpty() || listSize == 1)
			{
				return;
			}

			Node prev = null;
			Node current = head;
			tail = head; // new tail will be the old head

			while (current != null)
			{
				Node next = current.Next;
				current.Next = prev;
				prev = current;
				current = next;
			}
			head = prev;
		}

		public void Sort()
		{
			// save nodes with users in a separate list
			List<Node> userNodes = new List<Node>();
			Node current = head;
			while (current != null)
			{
				if (current.Data is User)
				{
					userNodes.Add(current);
				}
				current = current.Next;
			}

			if (userNodes.Count == 0)
			{
				return;
			}

			// take out the data from each node and save in a list
			List<User> users = new List<User>();
			foreach (Node node in userNodes)
			{
				users.Add((User)node.Data);
			}

			// sort users by name
			List<User> sorted = users.OrderBy(user => user.Name).ToList();

			// overwrite the data of previously
			// saved collection of user nodes with sorted 
			for (int i = 0; i < userNodes.Count; i++)
			{
				userNodes[i].Data = sorted[i];
			}
		}

		public object[] ToArray()
		{
			object[] array = new object[listSize];
			Node current = head;
			int index = 0;
			while (current != null)
			{
				array[index] = current.Data;
				index++;
				current = current.Next;
			}
			return array;
		}

		public ILinkedListADT JoinLists(params ILinkedListADT[] lists)
		{
			SLL newList = this;
			foreach (SLL list in lists)
			{
				if (list != null)
				{
					Node current = list.head;
					while (current != null)
					{
						newList.Append(current.Data);
						current = current.Next;
					}
				}
			}
			return newList;
		}

		public ILinkedListADT[] Divide(int index)
		{
			if (index < 0 || index > listSize)
			{
				throw new IndexOutOfRangeException("Index out of range for dividing linked list");
			}

			SLL firstList = new SLL();
			SLL secondList = new SLL();
			Node current = head;
			int i = 0;

			while (current != null)
			{
				if (i < index)
				{
					firstList.Append(current.Data);
				}
				else
				{
					secondList.Append(current.Data);
				}
				i++;
				current = current.Next;
			}
			SLL[] dividedList = {firstList, secondList};
			return dividedList;
		}







		// print DATA of all Nodes in the Linked List
		public void PrintList()
		{
			if (CheckListNull() is true)
			{
				return;
			}
			for (Node tempNode = head; tempNode != null; tempNode = tempNode.Next)
			{
				Console.Write(tempNode.Data.ToString() + "  ");
			}
			Console.WriteLine();
		}

		// Return the head as NODE if list not empty
		public Node GetHead()
		{
			if (CheckListNull() is true)
			{
				return null;
			}
			return head;
		}

		// return the tail as NODE if list not empty
		public Node GetTail()
		{
			if (CheckListNull() is true)
			{
				return null;
			}
			return tail;
		}

		// return DATA of all Nodes, print Data of head and tail as well... helps to verify all values
		public void PrintData()
		{
			if (CheckListNull() is true)
			{
				return;
			}
			PrintList();
			Console.WriteLine("\nHEAD: " + GetHead().Data);
			Console.WriteLine("TAIL: " + GetTail().Data + "\n\n");
		}

		// return "List was Null" if list is empty.
		public bool CheckListNull()
		{
			if (head is null && tail is null)
			{
				Console.WriteLine("List was NULL\n\n");
				return true;
			}
			return false;
		}

		// When using a method that ads a Node to the list, if the list is empty run  this method
		// this is useful as there are many methods that add Nodes to the list... this can therefore be used universally
		public bool FixListNull(object data)
		{
			if (head is null && tail is null)
			{
				head = tail = new Node(data);
				return true;
			}
			return false;
		}
	}
}
