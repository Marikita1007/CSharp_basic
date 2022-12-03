using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Services;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using CSharp.Math;

//ctrl+E+W : text wrap shortcut

namespace CSharp
{

    //Enum
    public enum ShippingMethod
    {
        RegularAirMail = 1,
        RegisteredAirMail = 2,
        Express = 3,
    }

    public enum ImageOrientation
    {
        Landscape,
        Portrait,
    }

    public class Program
    {
        static void Main(string[] args)
        {

            var test = new Program();//How to call method in a same Class.
            test.test();
        }

        public void AllExercises()
        {
            /**
             *I can declare everything with var and C# understands. C# thinks numbers as integer 
             *so byte is need to be specified.
             */

            Console.WriteLine("Hello World !");


            Console.WriteLine("\nVARIABLE TYPES");
            //Declaring variables with specific types
            byte number = 2;
            int count = 10;

            //double型と認識数している数字の値を浮動小数点(float)と認識させるために数字の語尾にfを付ける
            //https://wa3.i-3-i.info/word14959.html 
            float totalPrice = 20.95f;
            Console.WriteLine("The variable number that declared by byte is " + number + ".");
            Console.WriteLine("The variable count that declared by count is " + count + ".");
            Console.WriteLine("The variable totalPrice that declared by float is " + totalPrice + ".");

            //characters are declared with single quotes.
            char character = 'A';

            //strings are declared with double quotes.  
            string firstName = "Marika";

            bool isWorking = false;

            Console.WriteLine(number);
            Console.WriteLine(totalPrice);
            Console.WriteLine(character);
            Console.WriteLine(firstName);
            Console.WriteLine(isWorking);

            //Min and Max numbers that I can declare inside dyte and float 
            Console.WriteLine("\nMinValue and MaxValue of byte and float.");
            Console.WriteLine("{0} {1}", "MinValue of byte is " + byte.MinValue + ".", "MaxValue of byte is " + byte.MaxValue + ".");
            Console.WriteLine("{0} {1}", "MinValue od float is " + float.MinValue + ".", "Max value of float is " + byte.MaxValue + ".\n");


            Console.WriteLine("TYPE CONVERSION");
            byte b = 1;
            int intNumber = b;
            Console.WriteLine("byte to int : " + intNumber + ".");


            /*
             * castは違う値のタイプを他の値のタイプに変更すること。
             * 値の前に()で何の値に変更したいのか宣言する。
             * 変更した値のタイプがその値の許容範囲なら変更可能。
             * */
            int one = 1;
            byte onebyte = (byte)one;
            Console.WriteLine("This int variable is converted to byte by cast : " + one + ".");

            /**
             * Even with "cast", we can't convert string to int.
             * This case, we use Convert.ToInt32().
             */
            //try + tab : try catch shortcut
            try
            {
                string numberString = "1234";
                int convertToInt = Convert.ToInt32(numberString);
                Console.WriteLine("This string variable is converted to int : " + convertToInt + ".");
            }
            catch (Exception)
            {

                Console.WriteLine("The number coundt not be converted to byte."); ;
            }

            try
            {
                string str = "true";
                bool convertStr = Convert.ToBoolean(str);
                Console.WriteLine(convertStr);
            }
            catch (Exception)
            {

                Console.WriteLine("The string could not be coverted to boolean.\n");
            }

            //演算子 大体JSと一緒
            Console.WriteLine("OPERATORS");

            var c = 10;
            var d = 3;
            Console.WriteLine("c + d = " + (c + d)); //13
            Console.WriteLine("c + d = " + c + d); //103
            Console.WriteLine("c / d = " + c / d); //The result is 3. Because these numbers are integer.
            Console.WriteLine("Use \"cast\" to convert int to float : " + (float)c / (float)d);

            //This class is in Person.cs 
            /* 
             * Shortcut to create a new class file
             * If I want to move a class to another file,
             * Choose the class name with the mouse and Alt + Enter
             */
            Console.WriteLine("\nCLASSES");
            var Marika = new Person();
            Marika.FirstName = "Marika";
            Marika.LastName = "Abe Lamour";
            Marika.Introduce();

            Calculator caluculator = new Calculator();
            var result = caluculator.Add(10, 23);
            Console.WriteLine(result);

            Console.WriteLine("\nARRAYS");
            var numbers = new int[3]; //The number inside [] shows length of the array.
            numbers[0] = 1;
            //Shortcut for duplicate text : Ctrl + D
            //Initialized int is 0 so if we don't declare the numbers, it returns initialized values
            Console.WriteLine(numbers[0]);
            Console.WriteLine(numbers[1]);
            Console.WriteLine(numbers[2]);

            var flags = new bool[3];
            flags[0] = true;

            //Inicialized boolean is false so flags[0] is true and athers are falses.
            Console.WriteLine(flags[0]);
            Console.WriteLine(flags[1]);
            Console.WriteLine(flags[2]);


            //ここから面倒だからforeach使用
            Console.WriteLine("\nInitializing Hay Say Jump ! during declaration");
            //Initializing an array during declaration 宣言時の配列の初期化
            var haySayJump = new string[8] { "Yamada", "Chinen", "Yuto", "Arioka", "Takaki", "Inoo", "Hikaru", "Yabu" };
            foreach (var item in haySayJump)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\nSTRINGS");
            //string and String are the same
            //All the Primitive Types(基本型) are Structure(such as int) class , but not System class.
            string nigiri = "Anago";
            String gunkan = "Ikura";

            //この二つは一緒
            Int32 m = 3;
            int n = 5;

            Console.WriteLine("\nEnum");
            //Enum is a set of value pairs(constants)

            //This value is declared on top of this class as enum ShippingMethod.
            var method = ShippingMethod.Express;
            Console.WriteLine((int)method);//Result is 3

            //What if we receive 3 from different place ? (ex: databaseID)
            var methodId = 3;
            Console.WriteLine((ShippingMethod)methodId);//Result is Express

            Console.WriteLine(method.ToString());//Convert enum to string by ToString

            //"Pursing" means convert variable to different string.
            //Let's purse this variable
            var methodName = "Express";
            var shippingMethod = (ShippingMethod)Enum.Parse(typeof(ShippingMethod), methodName);

            var k = 10; //integers are value type  
            var p = k;
            k++;
            /*
            When we copy the variable to a different value type, 
            a copy of the value is taken and stored in the target variable.
            That's why it's called value types, their value is copied.
            */
            Console.WriteLine(String.Format("k:{0}, p:{1}", k, p));

            //If/Else Exercice
            /* Write a program and ask the user to enter a number. 
             * The number should be between 1 to 10. 
             * If the user enters a valid number, display "Valid" on the console. 
             * Otherwise, display "Invalid". 
             * (This logic is used a lot in applications where values entered into input boxes need to be validated.)
             */
            Console.WriteLine("Enter a number between 1 to 10");
            int hour = Convert.ToInt32(Console.ReadLine());
            if (hour > 0 && hour <= 10)
                Console.WriteLine("Valid");
            else
                Console.WriteLine("Invalid");

            //Write a program which takes two numbers from the console and displays the maximum of the two.

            int firstInput = 0;
            int secondInput = 50;

            if (firstInput > secondInput)
                Console.WriteLine(firstInput);
            else
                Console.WriteLine(secondInput);

            //Write a program and ask the user to enter the width and height of an image.
            //Then tell if the image is landscape or portrait.
            Console.WriteLine("Enter width :");
            int width = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter height :");
            int height = Convert.ToInt32(Console.ReadLine());

            //私の解答
            if (width > height)
                Console.WriteLine("It's a landscape.");
            else if (height > width)
                Console.WriteLine("It's a portrait.");
            else
                Console.WriteLine("It's a square.");

            //先生の解答
            var orientation = width > height ? ImageOrientation.Landscape : ImageOrientation.Portrait;
            Console.Write("Image orientation is " + orientation);//Go to ImageOrientation Class


            /*Your job is to write a program for a speed camera. For simplicity, ignore the details such as camera, sensors, etc and focus purely on the logic. Write a program that asks the user to enter the speed limit. Once set, the program asks for the speed of a car. If the user enters a value less than the speed limit, program should display Ok on the console. If the value is above the speed limit, the program should calculate the number of demerit points. For every 5km/hr above the speed limit, 1 demerit points should be incurred and displayed on the console. If the number of demerit points is above 12, the program should display License Suspended.*/
            Console.WriteLine("Enter the speed limit :");
            int speedLimt = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Write the car speed :");
            int carSpeed = Convert.ToInt32(Console.ReadLine());

            if (carSpeed < speedLimt)
                Console.WriteLine("OK");
            else
            {
                const int kmPerDemeritPoint = 5;
                var demeritPoints = (carSpeed - speedLimt) / kmPerDemeritPoint;
                if (demeritPoints > 12)
                    Console.Write("License Suspended");
                else
                    Console.WriteLine("Demerit points :" + demeritPoints);
            }

            Console.WriteLine("\nExercice1\n");

            //iteration statement 反復ステートメント
            //1 : Write a program to count how many numbers between 1 and 100 are divisible by 3 with no remainder. Display the count on the console.
            //先生の答え
            var countInput = 0;
            for (var i = 0; i < 100; i++)
            {
                if (i % 3 == 0)
                    countInput++;
            }
            Console.WriteLine("There are {0} numbers divisible by 3 between 1 and 100", countInput);

            Console.WriteLine("\nExercice2\n");

            //2- Write a program and continuously ask the user to enter a number or "ok" to exit. Calculate the sum of all the previously entered numbers and display it on the console.
            //プログラムを作成し、ユーザに数値の入力または "ok "による終了を継続的に要求する。以前に入力されたすべての数値の合計を計算し、コンソールに表示する。
            //When We aren't sure how many time user would input, it's better to use while loop !
            var sum = 0;

            while (true)
            {
                Console.WriteLine("Enter a number or 'ok' to exit : (While loop)");
                var inputUser = Console.ReadLine();

                if (inputUser.ToLower() == "ok")//ToLower : It converts every character to lowercase
                    break;

                sum += Convert.ToInt32(inputUser);
            }
            Console.WriteLine("Sum of all numbers is : " + sum);

            Console.WriteLine("\nExercice3\n");

            //3- Write a program and ask the user to enter a number. Compute the factorial of the number and print it on the console. For example, if the user enters 5, the program should calculate 5 x 4 x 3 x 2 x 1 and display it as 5! = 120.
            //3- プログラムを作成し、ユーザーに数値を入力させる。その数値の階乗を計算し、コンソールに表示する。例えば、ユーザーが 5 を入力した場合、プログラムは 5 x 4 x 3 x 2 x 1 を計算し、5! = 120 と表示する必要があります。
            // Source code : https://www.javatpoint.com/factorial-program-in-csharp
            //My solution
            int x = 1;
            Console.WriteLine("Enter any number : (FACTORIAL)");
            var factorialInput = int.Parse(Console.ReadLine());
            for (int i = 1; i <= factorialInput; i++)
            {
                x = x * i;
            }
            Console.WriteLine("Factorial of " + factorialInput + " is " + x);

            //Mosh solution
            Console.Write("Enter a number: ");
            var factorialNumber = Convert.ToInt32(Console.ReadLine());

            var factorial = 1;
            for (var i = 1; i <= factorialNumber; i++)
                factorial *= i;

            Console.WriteLine("{0}! = {1}", factorialNumber, factorial);

            Console.WriteLine("\nExercice4\n");

            //4- Write a program that picks a random number between 1 and 10. Give the user 4 chances to guess the number. If the user guesses the number, display “You won"; otherwise, display “You lost". (To make sure the program is behaving correctly, you can display the secret number on the console first.)
            //4- 1から10の間の乱数を選ぶプログラムを書いてください。ユーザーに数字を当てるチャンスを4回与える。ユーザが数字を当てたら「あなたの勝ち」と表示し、そうでなければ「あなたの負け」と表示する。(プログラムが正しく動作していることを確認するために、最初にコンソールに秘密の数字を表示することができます)。
            Random rnd = new Random();
            int randomeNumber = (rnd.Next(1, 10));
            Console.WriteLine("The random number is " + randomeNumber);
            Console.WriteLine("Guess the number from 1 to 10 : ");

            for (int i = 1; i <= 4; i++)
            {
                Console.WriteLine("Guess again : ");
                var userGuess = Convert.ToInt32(Console.ReadLine());
                if (userGuess == randomeNumber)
                {
                    Console.WriteLine("You won");
                    break;
                }
                else
                {
                    Console.WriteLine("You Lost");
                }

            }

            //ARRAY 
            //Array type is a class it has many different methods to get the elements.

            //int[] numbersArray = new int[] { 3, 7, 9, 2, 14, 6 }; To make the code cleaner, write like down below
            var numbersArray = new[] { 3, 7, 9, 2, 14, 6 };

            //length
            Console.WriteLine("lengthe: " + numbersArray.Length);

            //IndexOf()
            var index = Array.IndexOf(numbersArray, 9);
            Console.WriteLine("Index of 9:" + index);

            //Clear()
            //Array.Clear(CLEARVARIABLENAME, STARTINGPOINTNUMBER, ENDINGPOITNUMBER);
            Array.Clear(numbersArray, 0, 2);

            //Usually foreach uses n ,but I already declared n above so I use y
            //Use to display all the elements 
            Console.WriteLine("Effect of Clear()");
            foreach (var y in numbersArray)
                Console.WriteLine(y);

            //Copy()
            int[] another = new int[3];
            Array.Copy(numbersArray, another, 3);

            Console.WriteLine("Effect of Copy()");
            foreach (int y in another)
                Console.WriteLine(y);

            //Sort()
            Array.Sort(numbersArray);

            Console.WriteLine("Effect of Sort()");
            foreach (int y in numbersArray)
                Console.WriteLine(y);

            //Reverse()
            Array.Reverse(numbersArray);
            Console.WriteLine("Effect of Reverse()");
            foreach (var y in numbersArray)
                Console.WriteLine(n);

            //Useful Methods
            //Add()
            //AddRange()
            //Remove()
            //RemoveAt() //Remove the object and given index
            //IndexOf()
            //Contains()
            //Count


            //Syntax (Rectangular 2D 長方形配列)
            //var matrix = new int[3, 5];
            //{
            //    { 1, 2, 3,4,5},
            //    { 6,7,8,9,10},
            //    { 11,12,13,14,15}
            //};
            //var element = matrix[0, 0];

            //Syntax (Rectangular 3D 長方形配列)
            var colors = new int[3, 5, 4];

            var numbersDemo = new List<int>() { 1, 2, 3, 4, };
            numbersDemo.Add(1);
            numbersDemo.AddRange(new int[3] { 5, 6, 7 });

            foreach (var y in numbersDemo)
                Console.WriteLine(y);

            Console.WriteLine("Index of 1 :" + numbersDemo.IndexOf(1));
            Console.WriteLine("Last Index of of 1 :" + numbersDemo.LastIndexOf(1));

            Console.WriteLine("Count: " + numbersDemo.Count);

            numbersDemo.Remove(1);
            //C# don't let edit array in foreach loop
            for (var i = 0; i < numbersDemo.Count; i++)
            {
                if (numbersDemo[i] == 1)
                    numbersDemo.Remove(numbersDemo[i]);
            }
            foreach (var y in numbersDemo)
                Console.WriteLine(number);

            numbersDemo.Clear();
            Console.WriteLine("Count: " + numbersDemo.Count);

            //Excercises Arrays and Lists (23/10/2022) 
            //For any of these exercises, ignore input validation unless otherwise directed. Assume the user enters values in the format that the program expects.

            //1 - When you post a message on Facebook, depending on the number of people who like your post, Facebook displays different information.

            //If no one likes your post, it doesn't display anything.
            //If only one person likes your post, it displays: [Friend's Name] likes your post.
            //If two people like your post, it displays: [Friend 1] and[Friend 2] like your post.
            //If more than two people like your post, it displays: [Friend 1], [Friend 2] and[Number of Other People] others like your post.

            //Write a program and continuously ask the user to enter different names, until the user presses Enter(without supplying a name). Depending on the number of names provided, display a message based on the above pattern.

            //Create an array list
            var names = new List<string>();

            while (true)
            {
                //私が今分からないのはどうやってuserinputを配列化するのか。
                Console.WriteLine("Enter a name or press Enter to exit : (While loop)");
                var userNameInput = Console.ReadLine();

                //When we ask user to press Enter : IsNullOrEmpty
                if (String.IsNullOrEmpty(userNameInput))
                    break;
                names.Add(userNameInput);
            }

            ////If more than two people like your post, it displays: [Friend 1], [Friend 2] and[Number of Other People] others like your post.
            if (names.Count > 2)
                Console.WriteLine("{0}, {1}, and {2} others like your post", names[0], names[1], names[2], names.Count - 2);

            //If two people like your post, it displays: [Friend 1] and[Friend 2] like your post.
            if (names.Count == 2)
                Console.WriteLine("{0} and {1} others like your post", names[0], names[1]);

            //If no one likes your post, it doesn't display anything.
            if (names.Count == 1)
            {

                Console.WriteLine("{0} others like your post", names[0]);
            }
            else
            {

            }
            Console.WriteLine();

            //2- Write a program and ask the user to enter their name. Use an array to reverse the name and then store the result in a new string. Display the reversed name on the console.
            //ユーザーに名前を入力するプログラムを書きましょう。名前を逆にするのに配列を使い、新しい文字列に結果を入れましょう。コンソールに逆になった名前を表示してください。

            //var userNameArray = an empty array with the same length as userNameInputTwo
            Console.WriteLine("Enter your names :"); //ユーザーに名前を入力するプログラムを書きましょう。
            var userInputName = Console.ReadLine(); //新しい文字列に結果を入れましょう
            var userNameArray = new char[userInputName.Length]; //名前を逆にするのに配列を使い
            // Stock each letter of userNameInputTwo inside the array userNames
            // Reverse the array so the letter inside the array are reversed
            // Stock inside a string each letter of the reversed array
            for (var i = 0; i < userInputName.Length; i++)
            {
                userNameArray[i] = userInputName[i];
                Console.WriteLine(userNameArray[i]);
            }
            Array.Reverse(userNameArray);
            string reversedUserName = "";
            for (var i = 0; i < userInputName.Length; i++)
            {
                reversedUserName += userNameArray[i].ToString();
            }
            Console.WriteLine(reversedUserName);
        }

        /// 3 - Write a program and ask the user to enter 5 numbers. If a number has been previously entered, display 
        /// an error message and ask the user to re-try. Once the user successfully enters 5 unique numbers, sort them 
        /// and display the result on the console.
        public void Exercise3()
        {
            var numbers = new List<int>();

            while (numbers.Count < 5)
            {
                Console.Write("Enter a number: ");
                var number = Convert.ToInt32(Console.ReadLine());
                if (numbers.Contains(number))
                {
                    Console.WriteLine("You've previously entered " + number);
                    continue;
                }

                numbers.Add(number);
            }

            numbers.Sort();

            foreach (var number in numbers)
                Console.WriteLine(number);

        } 


        /// Write a program and ask the user to continuously enter a number or type "Quit" to exit. The list of numbers may 
        /// include duplicates. Display the unique numbers that the user has entered.
        public void Exercise4()
        {
            var numbers = new List<int>();

            while (true)
            {
                Console.WriteLine("Enter a number or write 'quit' to exit : ");
                var userInputs = Console.ReadLine();
                if(userInputs == "quit")
                {
                    break;
                }

                numbers.Add(Convert.ToInt32(userInputs));
            }

            numbers.Distinct().ToList().ForEach(x => Console.WriteLine(x));

        }

        //5- Write a program and ask the user to supply a list of comma separated numbers (e.g 5, 1, 9, 2, 10). If the list is empty or includes less than 5 numbers, display "Invalid List" and ask the user to re-try; otherwise, display the 3 smallest numbers in the list.
        //Event the correct answer is not working !!!!!!!!!!!!!!!!!!!
        public void Exercise5()
        {

            var numbers = new List<int>();
            string[] elements;

            while (true)
            {
                Console.WriteLine("supply a list of comma separated numbers (e.g 5, 1, 9, 2, 10)");

                var userInput = Console.ReadLine();

                if (!String.IsNullOrEmpty(userInput))
                {
                    elements = userInput.Split(',');
                    if (elements.Length >= 5)
                    {
                        break;
                    }
                }
                Console.WriteLine("Invalid List");
            }

            foreach(var number in elements)
            {
                numbers.Add(Convert.ToInt32(number));
            }

            var smallests = new List<int>();
            while(smallests.Count < 3)
            {
                var min = numbers[0];
                foreach(var number in numbers)
                {
                    if(number < min)
                    {
                        min = number;
                    }
                    smallests.Add(min);

                    numbers.Remove(min);
                }
            }
            Console.WriteLine("The 3 smallest numbers are : ");
            foreach(var number in numbers)
            {
                Console.WriteLine(number);
            }

        }

        //Dates and Time
        public void DateAndTime()
        {
            var dateTime = new DateTime(2022, 1, 1);
            var now = DateTime.Now;
            var today = DateTime.Today;

            Console.WriteLine(now.Hour); //Write current hour
            Console.WriteLine(now.Minute);//Wrtite current minutes

            var tomorrow = now.AddDays(1);//1 so its tomorrow
            var yesterday = now.AddDays(-1);//-1 so its yesterday

            Console.WriteLine(now.ToLongDateString());//ex: mardi 1 novembre 2022
            Console.WriteLine(now.ToShortDateString());//ex: 01 / 11 / 2022
            Console.WriteLine(now.ToLongTimeString());//ex: 22:59:39
            Console.WriteLine(now.ToShortTimeString());//ex: 22:59
            Console.WriteLine(now.ToString());//ex: 01 / 11 / 2022 22:59:39 This excute all od above

            Console.WriteLine(now.ToString("g")); //ex: 01/11/2022 23:04

            //Creating TimeSpan which represents lengths of time. 
            var timeSpan = new TimeSpan(1, 2, 3); //(1, 2, 3) is (hour minute second)

            var timeSpan1 = new TimeSpan(1, 0, 0);//When we aren't sure about minute and second.
            var timeSpan2 = TimeSpan.FromHours(1);//By writing FromHours, its more readble and we can know which time we are talking about.

            var start = DateTime.Now;
            var end = DateTime.Now.AddMinutes(2);
            var duration = end - start;
            Console.WriteLine("Duration: " + duration); //Duration: 00:02:00

            //Properties
            Console.WriteLine("Monutes : " + timeSpan.Minutes); //2
            Console.WriteLine("Total Minutes : " + timeSpan.TotalMinutes); //62,05

            //Add 
            Console.WriteLine("Add Example : " + timeSpan.Add(TimeSpan.FromMinutes(8))); //Add Example : 01:10:03
            Console.WriteLine("Subtract Example : " + timeSpan.Subtract(TimeSpan.FromMinutes(2)));//Subtract Example : 01:00:03

            //ToString
            Console.WriteLine("ToString : " + timeSpan.ToString());//ToString : 01:02:03

            //Parse
            Console.WriteLine("Parse : " + TimeSpan.Parse("01:02:03"));//Parse: 01:02:03

        }

        public void Strings()
        {
            var fullName = "Marika Abe ";
            Console.WriteLine("Trim: '{0}'", fullName.Trim()); //Trimming the last empty space. 
            Console.WriteLine("ToUpper: '{0}'", fullName.Trim().ToUpper());

            var index = fullName.IndexOf(' ');
            var firstName = fullName.Substring(0, index);
            var lastName = fullName.Substring(index + 1);
            Console.WriteLine("FirstName :" + firstName);//FirstName : Marika
            Console.WriteLine("LastName :" + lastName);//FirstName: Abe

            var names = fullName.Split(' ');
            Console.WriteLine("FirstName : " + names[0]);//FirstName : Marika
            Console.WriteLine("FirstName : " + names[1]);//FirstName: Abe

            Console.WriteLine(fullName.Replace("Abe", "Lamour")); //Marika Lamour

            if(String.IsNullOrEmpty(" ".Trim())) 
            {
                Console.WriteLine("Invalid");
            }

            if (String.IsNullOrWhiteSpace(" "))
            {
                Console.WriteLine("Invalid");
            }

            var str = "25";
            var age = Convert.ToByte(str);
            Console.WriteLine(age);

            float price = 29.95f;
            Console.WriteLine(price.ToString("C0"));
        }

        public void LongText()
        {
            var text = "This is going to be a really really really really really long text.";
            var summary = StringUtility.SummerizeText(text);
            Console.WriteLine(summary);
        }

        public void StringBuilders()
        {
            //StringBuilder can manupulates strings, therefore we can't search texts.
            var builder = new StringBuilder("Hello World"); //StringBuilder munupulates this text 
            builder
                .Append('-', 10) //----------
                .AppendLine() //Change the line 改行
                .Append("Header") //Header
                .AppendLine()
                .Append('-', 10)//----------
                .Replace('-', '+') // - becomes +
                .Remove(0, 10) //remove 0 to 10 text
                .Insert(0, new string('-', 10)); //Add - to the beginning of the StringBUilders

            Console.WriteLine(builder);

            Console.WriteLine("First Char: " + builder[0]);//We can look for the ordered character. 
        }

        public void StringExercise1()
        {
            //1- Write a program and ask the user to enter a few numbers separated by a hyphen. Work out if the numbers are consecutive. For example, if the input is "5-6-7-8-9" or "20-19-18-17-16", display a message: "Consecutive"; otherwise, display "Not Consecutive".
            //consecutive means numbers are in order like 1-2-3-4

            Console.WriteLine("Enter a few numbers separated by a hyphen: ");
            //var userInput = Console.ReadLine();

            //if (String.IsNullOrWhiteSpace(userInput))
            //{
            //    //UserInput is null or white space
            //    Console.WriteLine("Not Consecutive");
            //}
            //else//User did write something 
            //{
            //    var checkNumbers = userInput.Any(char.IsDigit);
            //    if (userInput.Contains("-") && checkNumbers && userInput.StartsWith())
            //    {
            //        foreach (var i in userInput)
            //        {
            //            char[] charSeparators = new char[] { '-' };
            //            string[] stringSeparators = new string[] { "[stop]" };
            //            string[] result;
            //            result = userInput.Split(charSeparators, StringSplitOptions.None);
            //            //I want to check if each numbers are separated by '-'... How ?
            //            foreach(string str in result)
            //            {
            //                Console.WriteLine(str);
            //            }

            //        }
            //    }
            //    else
            //    {
            //        Console.WriteLine("Consecutive");
            //    }
            //}
        }

        //注意：これらの演習では、特に指示がない限り、入力の検証は無視すること。ユーザはプログラムが期待する形式で値を入力すると仮定してください。例えば、プログラムがユーザが数値を入力することを想定している場合、入力が数値であるかどうかの検証は気にしないでください。プログラムをテストするときは、単に数字を入力してください。
        public void ConditionalExercise1()
        {
            //1 - プログラムを書き、ユーザーに数字を入力するよう求めます。数値は1から10の間でなければなりません。ユーザーが有効な数字を入力した場合、コンソールに "Valid "と表示する。そうでない場合は、「無効」と表示する。(このロジックは、入力ボックスに入力された値を検証する必要があるアプリケーションでよく使われる)

            Console.WriteLine("Enter a number. The number should be between 1 to 10: ");
            var userInput = Console.ReadLine();

            if (!String.IsNullOrEmpty(userInput))
            {
                var number = Convert.ToInt32(userInput);
                if(number <= 1 && number >= 10)
                {
                    Console.WriteLine("Valid");
                }
                else
                {
                    Console.WriteLine("Invalid");
                }
            }
            else
            {
                Console.WriteLine("Invalid");
            }

        }

        public void ConditionalExercise2()
        {
            //2- コンソールから2つの数値を受け取り、2つの数値の最大値を表示するプログラムを書いてください。
            Console.WriteLine("Enter a number: ");
            var number1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter a number again: ");
            var number2 = Convert.ToInt32(Console.ReadLine());

            if(number1 <= number2)
            {
                Console.WriteLine("The max number is " + number2);
            }
            else
            {
                Console.WriteLine("The max number is " + number1);
            }
        }

        public void ConditionalExercise3()
        {
            //3- Write a program and ask the user to enter the width and height of an image. Then tell if the image is landscape or portrait.

            Console.WriteLine("Enter height of an image: ");
            var height = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter width of an image: ");
            var width = Convert.ToInt32(Console.ReadLine());

            if(height > width)
            {
                Console.WriteLine("Your image is portrait");
            }
            else
            {
                Console.WriteLine("Your image is landscape");
            }

        }

        public void ConditionalExercise4()
        {
            //4- Your job is to write a program for a speed camera. For simplicity, ignore the details such as camera, sensors, etc and focus purely on the logic. Write a program that asks the user to enter the speed limit. Once set, the program asks for the speed of a car. If the user enters a value less than the speed limit, program should display Ok on the console. If the value is above the speed limit, the program should calculate the number of demerit points. For every 5km/hr above the speed limit, 1 demerit points should be incurred and displayed on the console. If the number of demerit points is above 12, the program should display License Suspended.
            //4- あなたの仕事は、スピードカメラ用のプログラムを書くことです。カメラやセンサーなどの詳細については無視し、純粋にロジックにのみ注目してください。ユーザーに制限速度を入力するよう求めるプログラムを書いてください。設定されると、プログラムは車の速度を尋ねます。ユーザーが制限速度より小さい値を入力した場合、プログラムはコンソールにOkを表示する必要があります。値が制限速度を超えている場合、プログラムは減点数を計算する必要があります。制限速度より毎時 5km 上で、1 つの減点ポイントは発生し、コンソールで表示されるべきです。減点ポイントが12点以上の場合、プログラムは「License Suspended（免許停止）」と表示します。

            Console.WriteLine("Enter the speed limit:");
            var speedLimit = Convert.ToInt32(Console.ReadLine()); // 100

            Console.WriteLine("What is the speed of a car ?:");
            var carSpeed = Convert.ToInt32(Console.ReadLine()); // 120

            if(speedLimit >= carSpeed)
            {
                Console.WriteLine("OK");
            }
            else
            {
                var overSpeed = carSpeed - speedLimit; // 120 - 100 = 20
                //Console.WriteLine(overSpeed);
                var overFive = 5;
                var fiveDevided = overSpeed / overFive; // 20 * 5 = 4 : you lost 4 points ! 
                //Console.WriteLine(fiveDevided);
                if (fiveDevided < 12)
                {
                    Console.WriteLine("You lost " + fiveDevided + " point(s)!");
                }
                else
                {
                    Console.WriteLine("License Suspended");
                }

            }
        }

        public void LoopExercise1()
        {
            //1- Write a program to count how many numbers between 1 and 100 are divisible by 3 with no remainder. Display the count on the console.
            // 1から100までの数字が3で割れて余りがないことを数えるプログラムを作成しなさい。その数をコンソールに表示せよ。
            // https://stackoverflow.com/questions/49191436/remainder-operator-c-sharp 
            // Use Remainder %
            
            var divisible = 0; 
            for(int i = 0; i < 100; i++)
            {
                if(i%3 == 0)
                {
                    divisible++;
                }
            }

            Console.WriteLine("There are {0} numbers divisibles by 3 from 1 to 100.", divisible); //{} get what's in the variable divisible. 
        }

        public void LoopExercise2()
        {
            //2- Write a program and continuously ask the user to enter a number or "ok" to exit. Calculate the sum of all the previously entered numbers and display it on the console.
            //2- プログラムを作成し、数値の入力または終了のための "ok "をユーザに継続的に求める。以前に入力されたすべての数値の合計を計算し、コンソールに表示する。
            //もう一回やる！

            var sum = 0;

            while (true)
            {
                Console.WriteLine("Enter a number or \"ok\" to exit: ");
                var userInput = Console.ReadLine();

                if (userInput.ToLower() == "ok")
                {
                    break;
                }

                var numbers = Convert.ToInt32(userInput);
                sum = numbers++;
            }

            Console.WriteLine("Sum of your input numbers are: " + sum);


        }

        public void LoopExercise3()
        {
            //3- Write a program and ask the user to enter a number. Compute the factorial of the number and print it on the console. For example, if the user enters 5, the program should calculate 5 x 4 x 3 x 2 x 1 and display it as 5! = 120.
            ///3- プログラムを書き、ユーザーに数字を入力させる。その数値の階乗を計算し、コンソールに表示せよ。例えば、ユーザが 5 を入力した場合、プログラムは 5 x 4 x 3 x 2 x 1 を計算し、5! = 120 と表示するはずである。

            var factorial = 1;

            Console.WriteLine("Enter a number: ");
            var userInput = Convert.ToInt32(Console.ReadLine());
            
            for(int i = 1; i <= userInput; i++)
            {
                factorial=factorial*i;
            }

            Console.WriteLine("Factorial of " + userInput + " is " + factorial);

        }

        public void LoopExercise4()
        {
            //4- Write a program that picks a random number between 1 and 10. Give the user 4 chances to guess the number. If the user guesses the number, display “You won"; otherwise, display “You lost". (To make sure the program is behaving correctly, you can display the secret number on the console first.)

            //4- 1から10の間の乱数を選ぶプログラムを書いてください。ユーザーに数字を当てるチャンスを4回与える。ユーザが数字を当てたら「あなたの勝ち」と表示し、そうでなければ「あなたの負け」と表示する。(プログラムが正しく動作していることを確認するために、最初にコンソールに秘密の数字を表示することができます)。

            var secretNumber = new Random().Next(1,10); //Create random number from 1 to 10
            Console.WriteLine("A random number created by Random().Next(1,10) is: " + secretNumber);

            Console.WriteLine("Guess a number between 1 and 10. You have 4 chances to guess: ");
            var userGuess = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i < 4; i++)
            {
                if(userGuess != secretNumber)
                {
                    Console.WriteLine("You still have chance to quess the number: ");
                    userGuess = Convert.ToInt32(Console.ReadLine());

                }
                else
                {
                    Console.WriteLine("You won");
                    return;
                }
            }

            Console.WriteLine("You lost");

        }

        public void LoopExercise5()
        {
            //5- Write a program and ask the user to enter a series of numbers separated by comma. Find the maximum of the numbers and display it on the console. For example, if the user enters “5, 3, 8, 1, 4", the program should display 8.
            //5- プログラムを作成し、ユーザにカンマで区切られた一連の数字を入力させる。数値の最大値を求め、コンソールに表示せよ。例えば、ユーザが「5, 3, 8, 1, 4」と入力した場合、プログラムは「8」を表示する。


            Console.WriteLine("Enter a series of numbers separated by comma. (Ex. 5, 3, 8, 1, 4)");
            var userInput = Console.ReadLine();
            var numbers = userInput.Split(','); ////This becomes string to an array contains strings ?

            // Assume the first number is the max
            var max = Convert.ToInt32(numbers[0]); 

            foreach(var str in numbers)
            {
                var number = Convert.ToInt32(str);
                if(number > max)
                {
                    max = number;
                }
            }

            Console.WriteLine("Max is " + max);
        }

        public void test()
        {
            Console.WriteLine("Write something: ");
            var userInput = Console.ReadLine();
            var number = userInput.Split(',');
            Console.WriteLine(number);
        }

    }

}


