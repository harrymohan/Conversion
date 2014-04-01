using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;
using System.ComponentModel;

namespace Conversion
{
    class Program
    {
        public static byte[] HexToBytes(string hexString) {
            if (hexString == null)
            return null;
            if (hexString.Length % 2 == 1)
            hexString = '0' + hexString;
            byte[] tData = new byte[hexString.Length / 2];
            for (int i = 0; i < tData.Length; i++)
                tData[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return tData;
            }
        public static string deprecatedString(String input)
        {
            string test;
            if (input == "")
            {
                return "No number read";
            }
            if (input[0] != '0')
            {
                //
                input = '0' + input;
                test = input.Substring(0, 8);
            }
            else
            {
               test = input.Substring(0, 8);
            }

            Console.WriteLine("deprecated String:{0}", test);
            return test;
        }


       

        public static double convertToDecimal(String str)
        {
            Console.WriteLine("Recieved String:{0}", str);
            //parse each character 
            int length = str.Length;
            Console.WriteLine("Length of incoming String:{0}", length);
            double sum=0;
            double inc=length-1;
            for (int i =0; i < length; i++)
            {
                //read each and every char
                double num;
                double hexa =16;
               
                if (str[i] == 'A')
                {
                    num = 10;
                }
                else
                    if (str[i] == 'B')
                    {
                        num = 11;
                    }
                    else
                        if (str[i] == 'C')
                        {
                            num = 12;
                        }
                        else
                            if (str[i] == 'D')
                            {
                                num = 13;
                            }
                            else
                                if (str[i] == 'E')
                                {
                                    num = 14;
                                }
                                else
                                    if (str[i] == 'F')
                                    {
                                        num = 15;
                                    }
                                    else
                                        num = str[i] - '0';
             
                sum += num * Math.Pow(hexa,inc);
                inc--;      
            }
           Console.WriteLine("Sum in Decimal :{0}", sum);
           return sum;
        }
        static void convertToBinary(double input)
        {
            byte[] byteArray = BitConverter.GetBytes(input);
            const string formatter = "{0,25:E16}{1,30}";
            Console.WriteLine(formatter, input,
                BitConverter.ToString(byteArray));
            int len = byteArray.Length;
            Console.WriteLine("Length of Byte Array: {0}", len);
            for (int i = 0; i < len; i++)
            {
                string yourByteString = Convert.ToString(byteArray[i], 2).PadLeft(8, '0');
                Console.WriteLine("Binary:{0}", yourByteString);
            }
           
        }

        static void Main(string[] args)
        {
            //String str = "02AB6700";
            String str = "04F96262453180";
            byte[] barr;
            string partial = "04F96262";
            double result = convertToDecimal(partial);
            Console.WriteLine("Partial:{0}", result);
            barr = HexToBytes(partial);
            Console.WriteLine("Byte[0]:{0},Byte[1]:{1},Byte[2]:{2},Byte[3]:{3}", barr[0], barr[1], barr[1], barr[2]);
            Console.WriteLine("First byte:{0}:",barr[0]);
            //shs
            Console.WriteLine("SHS Byte[0]:{0},Byte[1]:{1},Byte[2]:{2},Byte[3]:{3}", Convert.ToInt32(barr[0]), Convert.ToInt32(barr[1]), Convert.ToInt32(barr[2]), Convert.ToInt32(barr[3]));

            Console.WriteLine("SHS UTF8 Encoding" + System.Text.UTF8Encoding.UTF8.GetString(barr));

            //SHS

            int iii = BitConverter.ToInt32(barr, 0);
            Console.WriteLine("Number in int:{0}", iii);
            UInt32 number;
            Byte[] tempNumber = new byte[4];
            Array.Copy(barr, 0, tempNumber, 0, 4);
            Array.Reverse(tempNumber, 0, 4);
            number = BitConverter.ToUInt32(tempNumber, 0);
            Console.WriteLine("Number read:{0}", number);
            //big endian
            
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Big Edian:{0}", barr[i]);
              
            }
            //string p = partial.Substring(2,2);
          ////  Console.WriteLine("p:{0}", p);
          //  string test = deprecatedString(str);
          // Console.WriteLine("result:{0}", test);
            string hexString = "04F96262";
            int num = Int32.Parse(hexString, System.Globalization.NumberStyles.HexNumber);
            Console.WriteLine(num);


        }
    }
}
