﻿using System;

class StudentReportCard
{
    static void Main()
    {
        Console.Write("Enter Total Students: ");
        int totalStudents = int.Parse(Console.ReadLine());

        string[,] students = new string[totalStudents, 5];

        for (int i = 0; i < totalStudents; i++)
        {
            Console.Write("Enter Student Name: ");
            students[i, 0] = Console.ReadLine();

            students[i, 1] = GetValidMarks("Enter English Marks (Out Of 100): ");
            students[i, 2] = GetValidMarks("Enter Math Marks (Out Of 100): ");
            students[i, 3] = GetValidMarks("Enter Computer Marks (Out Of 100): ");

            int total = int.Parse(students[i, 1]) +
                        int.Parse(students[i, 2]) +
                        int.Parse(students[i, 3]);

            students[i, 4] = total.ToString();
            Console.WriteLine("*********************************************");
        }

        for (int i = 0; i < totalStudents - 1; i++)
        {
            for (int j = i + 1; j < totalStudents; j++)
            {
                if (int.Parse(students[j, 4]) > int.Parse(students[i, 4]))
                {
                    for (int k = 0; k < 5; k++)
                    {
                        string temp = students[i, k];
                        students[i, k] = students[j, k];
                        students[j, k] = temp;
                    }
                }
            }
        }


        Console.WriteLine("****************Report Card*******************");
        for (int i = 0; i < totalStudents; i++)
        {
            Console.WriteLine("****************************************");
            Console.WriteLine($"Student Name: {students[i, 0]}, Position: {i + 1}, Total: {students[i, 4]}/300");
            Console.WriteLine("****************************************");
        }
    }

    static string GetValidMarks(string prompt)
    {
        int marks;
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out marks) && marks >= 0 && marks <= 100)
            {
                return marks.ToString();
            }
            else
            {
                Console.WriteLine("Invalid input! Please enter a number between 0 and 100.");
            }
        }
    }
}