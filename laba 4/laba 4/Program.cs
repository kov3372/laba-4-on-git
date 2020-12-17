using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace laba_4
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] directiry = Directory.GetFiles(@"D:\textLaba4");
            List<int> num = new List<int>();
            List<int> list = new List<int>();
            int[] rightName = { 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29 };




            for (int i = 0; i < directiry.Length; i++)
            {
                FileInfo f = new FileInfo(directiry[i]);
                string[] arr = f.Name.Split(".");
                string prob = arr[0];

                int p = 0;
                try
                {
                    if ((int.Parse(arr[0]) >= 10 && int.Parse(arr[0]) <= 29))
                    {
                        int[] ar = ReadAllInf(directiry[i]);
                        num.Add(TryFindProduct(ar, directiry[i]));
                        list.Add(int.Parse(arr[0]));
                    }
                    else
                    {
                        using (StreamWriter sw = new StreamWriter(@"D:\textLaba4\no_file.txt", true, System.Text.Encoding.Default))
                        {
                            sw.Write(directiry[i] + "\n");
                            continue;
                        }
                    }


                }
                catch (Exception ex)
                {
                    using (StreamWriter sw = new StreamWriter(@"D:\textLaba4\no_file.txt", true, System.Text.Encoding.Default))
                    {
                        sw.Write(directiry[i] + "\n");
                        continue;
                    }
                }



            }

            for (int i = 0; i < rightName.Length; i++)
            {

                bool flag = false;

                foreach (int e in list)
                {

                    if (e == rightName[i])
                    {
                        flag = true;
                    }

                }
                if (!flag)
                {
                    using (StreamWriter sw = new StreamWriter(@"D:\textLaba4\no_file.txt", true, System.Text.Encoding.Default))
                    {

                        sw.Write(rightName[i] + ".txt" + "\n");
                        break;
                    }

                }

            }



            int sum = 0;
            foreach (int n in num)
            {
                try
                {
                    sum = checked(sum + n);
                }
                catch (Exception ex)
                {
                    sum = (int)sum;
                }

            }

            Task2.Task(@"D:\Pictures", @"D:\");          
            Console.WriteLine("сума всіх добутків  {0}", sum);


        }


        public static int[] ReadAllInf(string directiry)
        {
            string[] inform = File.ReadAllLines(directiry);
            int[] array = new int[2];

            int len = inform.Length;
            if (inform.Length > 2)
            {

                using (StreamWriter sw = new StreamWriter(@"D:\textLaba4\bad_data.txt", true, System.Text.Encoding.Default))
                {
                    sw.Write(directiry + "\n");
                    return array;
                }
            }


            try
            {
                array[0] = int.Parse(inform[0]);
                array[1] = int.Parse(inform[1]);
            }
            catch (Exception exp)
            {
                using (StreamWriter sw = new StreamWriter(@"D:\textLaba4\bad_data.txt", true, System.Text.Encoding.Default))
                {
                    sw.Write(directiry + "\n");
                }
            }

            return array;
        }


        public static int TryFindProduct(int[] array, string directiry)
        {
            int rez = 0;
            try
            {
                rez = checked((int)(array[0] * array[1]));
            }
            catch (Exception ex)
            {
                using (StreamWriter sw = new StreamWriter(@"D:\textLaba4\overflow.txt", true, System.Text.Encoding.Default))
                {
                    sw.Write(directiry + "\n");
                }
            }

            return (array[0]) * array[1];
        }

    }
}

