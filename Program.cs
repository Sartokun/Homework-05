/*----------------------------------------------------------------
****โปรดอ่าน****
โค้ดนี้จัดทำเพื่อการอธิบายการทำงานของ method Find (Homework 5: ทดลองสร้าง Method Find)

-สร้าง method Find สำหรับค้นหา Node ใน Linked List ที่มี Data ตรงกันกับข้อมูลจาก parameter ของ method
- ส่งค่ากลับเป็น  Node ที่หาเจอ ถ้าหาไม่เจอ ให้ส่งค่ากลับเป็น null

*โปรดอ่านคำอธิบายและทดลองเขียนและทำความเข้าใจด้วยตัวเองก่อน หากไม่เข้าใจสามารถถามมาได้ผมจะตอบในช่วงที่สามารถตอบได้

*โดยมีโค้ดที่อาจารเขียนมาให้แล้วบางส่วน เราก็แค่เพิ่ม method Find เข้าไปจากโค้ดที่อาจารส่งมา
-Download Code สำหรับการบ้านได้ที่นี่
https://drive.google.com/file/d/1k8GQgoe2Xg9NNR_V_MMSg54su-4JUqek/view?usp=drive_link

**Trick(เล็กๆน้อยๆ)**
-หากต้องการจัดหน้าโค้ดให้เป็นระเบียบ โดยไม่ต้องมานั้งจัดเอง สามารถกด Alt + Shift + F (บน Windows) หรือ Option + Shift + F (บน macOS)
-หากต้องการเคลียร์หน้าจอ (Terminal) หรือ Command Prompt (หรือ Terminal อื่นๆ) 
 สามารถใช้คำสั่งเฉพาะของแต่ละระบบปฏิบัติการได้(พิมใน Terminal ได้เลย) cls (บน Windows) หรือ clear (บน macOS และ Linux) จากนั้นกด Enter

ด้วยความปรารถนาดีจาก ผู้สาวซาโต้จัง🌸🌈 (sarto_)
----------------------------------------------------------------*/

using System;

public class Node
{
    public string Data;
    public Node Next;

    public Node(string data)
    {
        Data = data;
        Next = null;
    }
}

public class LinkedList
{
    private Node _head;

    public LinkedList()
    {
        _head = null;
    }

    public void Add(Node node)
    {
        Console.WriteLine("Node with data: " + node.Data + " was added");

        if (_head == null)
        {
            _head = node;
            return;
        }

        Node currNode = _head;

        while (currNode.Next != null) // Not Found last Node
        {
            currNode = currNode.Next; // Move currNode
        }

        currNode.Next = node;
    }

    public void Print()
    {
        Console.WriteLine("Method Print() was called");

        Node currNode = _head;

        while (currNode != null)
        {
            Console.Write(currNode.Data + " ");
            currNode = currNode.Next;
        }

        Console.WriteLine("");
    }

    public void Insert(Node node, int position)
    {
        if (position == 0)
        {
            if (_head != null)
            {
                node.Next = _head;
            }
            _head = node;
            return;
        }

        Node currNode = _head;
        int count = 1;

        while (currNode != null)
        {
            if (count == position)
            {
                // Insert node
                node.Next = currNode.Next;
                currNode.Next = node;
                return;
            }

            // Move currNode if count is not equal to position
            currNode = currNode.Next;
            count += 1;
        }

        Console.WriteLine("Position " + position + " is out of range");
    }
    // Find the first node with data equal to the given data
    public Node Find(string searchData) //สร้าง method โดยส่งค่าเป็น Node และตั้งชื่อว่า Find โดยรับค่ามาเป็น string ตั้งชื่อว่า searchData
    {
        Node currNode = _head; //เรากำหนด Node currNode ให้ชี้ไปที่หัวของ LinkedList _head เพื่อเริ่มการค้นหาจากต้นของ LinkedList
        //โดยตัวแปร _head นี้คือตัวแปรที่ใช้เก็บอ้างอิงไปยังหัว (ตัวแรกสุด) ของ Linked List ที่ถูกสร้างขึ้นด้วยคลาส LinkedList. _head (สามารถกลับขึ้นไปดูได้ที่บรรทัดที่ 36 ถึง 43)

        while (currNode != null) //เราใช้ลูป while เพื่อวนลูปผ่าน Node ใน LinkedList จนกว่า currNode จะชี้ไปยัง null ซึ่งหมายถึงเราได้ค้นหาผ่านทุก Node ใน LinkedList
        //ในภาษาพูด(เข้าใจง่าย) คือ ใช้ while ที่เป็นลูปในการหา currNode ไปทีละตัว โดยจะทำงานในลูปก็ต่อเมื่อ currNode มีค่าอยู่ในตัวมันเอง และจะออกจากลูปเมื่อ currNode ไม่มีตัวถัดไปแล้วหรือ currNode ตัวนั้นเป็นค่าว่างนั้นเอง
        {
            if (currNode.Data == searchData)//เราตรวจสอบว่าข้อมูลที่อยู่ใน currNode ตรงกับข้อมูลที่เรากำลังค้นหา (searchData) หากเจอ Node ที่ตรงกัน เราจะส่งคืน Node นั้นออกและจบการทำงานของเมธอด
            {
                return currNode; // หากพบ Node ที่ตรงกับข้อมูลที่ค้นหา ให้ส่งคืน Node นั้น และจบการทำงานของเมธอด 
                //(การที่เราใช้ return มันจะส่งค่าที่เราตั้งไว้ ในที่นี้เราให้มันส่งค่า currNode และเมื่อส่งค่าไปแล้วจะจบการทำงานของเมธอดทันที)
            }
            currNode = currNode.Next; // ย้ายไปยัง Node ถัดไป
            //กำหนดค่า currNode ให้ไปตัวถัดไปโดยใช้ .Next ที่เราสร้างไว้(สามารถกลับขึ้นไปดูบรรทัดที่ 24 ถึง 34) เพราะมันจะเก็บค่าตัวถุดไปไว้ ดังนั้นจึงให้ค่า currNode เป็นตัวถัดไปเพื่อให้นำค่า currNode กลับขึ้นไปเช็คใน while ลูป
        }
        return null; // ถ้าไม่พบ Node ที่ตรงกับข้อมูลที่ค้นหา ให้ส่งคืนค่า null
        //การที่จะมาทำงานบรรทัดนี้คือ คำสั่ง while ลูปทำงานครบหมดทุกตัวแล้ว และไม่เจอค่าที่ตรงกับ searchData (ไม่เข้าเงื่อนไขที่บรรทัด 121) และส่งค่ากลับไปเป็นค่าว่าง(null) และจบการทำงานของเมธอด
    }

}



public class Program
{
    public static void Main(string[] args)
    {
        LinkedList myList = new LinkedList();

        Node node1 = new Node("Cat");
        Node node2 = new Node("Dog");
        Node node3 = new Node("Monkey");

        myList.Add(node1);
        myList.Add(node2);
        myList.Add(node3);

        myList.Insert(new Node("Capybara"), 0);

        myList.Print();

        Node foundNode = myList.Find("Dog");
        Console.WriteLine("Search for Dog");
        if (foundNode != null)
        {
            Console.WriteLine("Found Node: " + foundNode.Data);
        }
        else
        {
            Console.WriteLine("Node not found");
        }

        foundNode = myList.Find("Lion");
        Console.WriteLine("Search for Lion");
        if (foundNode != null)
        {
            Console.WriteLine("Found Node: " + foundNode.Data);
        }
        else
        {
            Console.WriteLine("Node not found");
        }
    }
}