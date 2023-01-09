using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS_136
{
    class node
    {
        //deklarasi variabel
        public int rollno;
        public string nama;
        public string kelas;
        public node Next;

    }

    class CircularLinkedList
    {
        node LAST;
        public CircularLinkedList()
        {
            LAST = null;
        }

        //menambahkan node
        public void addnode()
        {
            int number;
            string nm;
            string kls;

            //deklarasi element
            Console.WriteLine("\nMasukkan no.induk siswa : ");
            number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nMasukkan Nama siswa : ");
            nm = Console.ReadLine();
            Console.WriteLine("\nMasukkan Kelas Siswa ");
            kls = Console.ReadLine();

            node newnode = new node();

            //membuat penyimpanan
            newnode.rollno = number;
            newnode.nama = nm;
            newnode.kelas = kls;


            //if list empty
            if (listempty())
            {
                newnode.Next = newnode;
                LAST = newnode;
            }
            //mulai proses pengurutan proses pengurutan data
            else if (number < LAST.Next.rollno)//node dari kiri
            {
                newnode.Next = LAST.Next;
                LAST.Next = newnode;
            }
            else if (number > LAST.rollno)//node dari kanan
            {
                newnode.Next = LAST.Next;
                LAST.Next = newnode;
                LAST = newnode;
            }
            //menambahkan node di tengah tengah
            else
            {
                node current, previous;
                current = previous = LAST.Next;

                int i = 0;
                while (i < number - 1)
                {
                    previous = current;
                    current = current.Next;
                    i++;
                }
                newnode.Next = current;
                previous.Next = newnode;
            }
        }
        //menambahkan medhod mencari data
        public bool Search(int rollnumber, ref node previous, ref node current)
        {
            for (previous = current = LAST.Next; current != LAST; previous = current, current = current.Next)
            {
                if (rollnumber == current.rollno)
                    return true;//return true if the node is found
            }
            if (rollnumber == LAST.rollno)
                return true;
            else
                return (false);
        }
        //menambahkan method delete
        public bool delNode(int number)
        {
            node previous, current;
            previous = current = LAST.Next;

            //mengecek spesifikasi isi nod sekarang masih ada didalam list atau tidak
            if (Search(number, ref previous, ref current) == false)
                return false;
            previous.Next = current.Next;

            //proses mendelete data
            if (LAST.Next.rollno == LAST.rollno)
            {
                LAST.Next = null;
                LAST = null;
            }
            else if (number == LAST.rollno)
            {
                LAST.Next = current.Next;
            }
            else
            {
                LAST = LAST.Next;
            }
            return true;
        }
        //mendisplay atau traverse semua node di list
        public void display()
        {
            //if list empty
            if (listempty())
                Console.WriteLine("\nList Is Empty : ");
            //menampilkan data
            else
            {
                Console.WriteLine("\nRecord in the list are : ");
                node currentNode;

                currentNode = LAST.Next;
                while (currentNode != LAST)
                {
                    Console.Write(currentNode.rollno + " " + currentNode.nama + " " + currentNode.kelas + "\n");
                    currentNode = currentNode.Next;
                }
                Console.Write(LAST.rollno + " " +LAST.nama +" " +LAST.kelas + "\n");
            }
        }
        public bool listempty()
        {
            if (LAST == null)
                return true;
            else
                return false;
        }

    }

    class Program
    {
        public void Demo()
        {
            Console.WriteLine("=========================");
            Console.WriteLine("------- DATA ANDA -------");
            Console.WriteLine("=========================");
            Console.WriteLine("1. Add a record to the list");
            Console.WriteLine("2. Delete a record from the list");
            Console.WriteLine("3. View all records in list");
            Console.WriteLine("4. Search for a record in the list");
            Console.WriteLine("5. Exit\n");
            Console.WriteLine("Enter your choice (1-6): ");
        }
        static void Main(string[] args)
        {
            Program menu = new Program();
            CircularLinkedList data = new CircularLinkedList();
            node a = new node();

            while (true)
            {
                try
                {
                    Console.WriteLine();
                    menu.Demo();
                    char ch = Convert.ToChar(Console.ReadLine());

                    switch (ch)
                    {
                        //add data
                        case '1':
                            {
                                data.addnode();
                            }
                            break;
                        //del node
                        case '2':
                            {
                                if (data.listempty())
                                {
                                    Console.WriteLine("\nlist is empty");
                                    break;
                                }
                                //pencarian node list yang akan didelete
                                Console.Write("\nMasukkan Data yang akan dihapus : ");
                                int value = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();

                                //output data yang didelete node
                                if (data.delNode(value) == false)
                                    Console.WriteLine("\nData tidak ditemukan");
                                else
                                    Console.WriteLine("Data dengan No" + " "+ value +" " +"dihapus dari list");
                            }
                            break;
                        //display atau traverse
                        case '3':
                            {
                                data.display();
                            }
                            break;
                        case '4':
                            {
                                if (data.listempty() == true)
                                {
                                    Console.WriteLine("\nList is empty");
                                    break;
                                }

                                //if list empyty
                                if (data.listempty() == true)
                                {
                                    Console.WriteLine("\nList is empty");
                                    break;
                                }

                                //proses pencarian
                                node previous, current;
                                previous = current = null;

                                Console.Write("\nMasukkan No.Induk Siswa : ");
                                int value = Convert.ToInt32(Console.ReadLine());

                                //memulai pencarian
                                if (data.Search(value, ref previous, ref current) == false)
                                    Console.WriteLine("\nData tidak ditemukan");
                                else//mencari output
                                {
                                    Console.WriteLine("\n====================");
                                    Console.WriteLine("----Data ditemukan----");
                                    Console.WriteLine("====================\n");
                                    Console.WriteLine("No.Induk Siswa       : " + current.rollno);
                                    Console.WriteLine("Nama Siswa    : " + current.nama);
                                    Console.WriteLine("Kelas Siswa : " + current.kelas);
                                }
                            }
                            break;
                        case '5':
                            return;
                        default:
                            {
                                Console.WriteLine("\ninvalid Option");
                                Console.ReadKey();
                                break;
                            }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}

//2.Circular Linked List
//3. Top merupakan bagian yang paling atas dari sebuah stack ibarat sebuah tempat bola tennis yang diambil dari yang paling atas
//4. Rear dan Front
//5. A. 5
//   B. post Order traversal
