using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;

namespace trwCh13Ex07
{
    class Program
    {
        
        static void Main(string[] args)
        {
            if (File.Exists("AllStudentsAndTheirGrades.txt"))
            {
                using (StreamReader getGrades = new StreamReader("AllStudentsAndTheirGrades.txt"))
                {
                    try
                    {
                        string indata;
                        while ((indata = getGrades.ReadLine()) != null)
                        {
                            Console.WriteLine(indata);
                        }

                        Console.ReadLine();
                    }
                    catch (System.IO.IOException e)
                    {
                        Console.WriteLine("\n\n" + e.Message);
                    }

                }

            }

            try
            {
                string indata;
                bool ItIsANum = false;
                int theGrade = 0;
                int numOfGrades = 0;
                double averageGrade = 0.00f;

                using (StreamReader getGrades = new StreamReader("AllStudentsAndTheirGrades.txt"))

                    while ((indata = getGrades.ReadLine()) != null)
                    {
                        if (indata == "#")
                        {
                            averageGrade = (double)theGrade / (double)numOfGrades;
                            Console.WriteLine("{0:F2} \n", averageGrade);
                            theGrade = 0;
                            averageGrade = 0;
                            numOfGrades = 0;
                            ItIsANum = false;
                        }

                        else if (ItIsANum)
                        {
                            theGrade += int.Parse(indata);
                            numOfGrades++;
                            
                        }

                        else if (indata == "|")
                            ItIsANum = true;

                        else
                            Console.Write(indata + ":   ");
                    }

                Console.ReadLine();

            }
            catch (System.IO.IOException e)
            {
                Console.WriteLine("\n\n" + e.Message);
            }


            /*File.Create("stupidassfile2.txt");

            using (StreamWriter writer = new StreamWriter("stupidassfile2.txt",true))
            {
                writer.Write("Word ");
                writer.WriteLine("word 2");
                writer.WriteLine("Line");
            }*/

        }
    }
}
