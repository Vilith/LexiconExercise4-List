using System;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Threading.Tasks;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParenthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            /*
            Uppgift 1:

                1.Skriv klart implementationen av ExamineList-metoden så att undersökningen blir genomförbar. 
                2.När ökar listans kapacitet ? (Alltså den underliggande arrayens storlek) 
                3.Med hur mycket ökar kapaciteten? 
                4.Varför ökar inte listans kapacitet i samma takt som element läggs till?
                5.Minskar kapaciteten när element tas bort ur listan? 
                6.När är det då fördelaktigt att använda en egendefinierad array istället för en lista?


            Svar: 
                
                2. När du överskrider nuvarande kapacitet. 5 element och 4 i kapacitet innebär att kapaciteten ökar till 8.
                3. Exponentiellt n*2
                4. Så att hela listan inte måste kopieras och byggas om för varje nytt element.
                5. Nej bara Count minskar
                6. En array är att föredra om man inte behöver ta bort eller lägga till
            */

            List<string> theList = new();
            bool isRunning = true;

            int cap = theList.Capacity; //Setting the lists capacity to an int for traceability.

            //Looping
            while (isRunning)
            {
                Console.WriteLine($"{Environment.NewLine}Type +text or -text to add/remove items on list" +
                    $"{Environment.NewLine}Type * to return to mainmenu");

                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                    break;

                char nav = input[0];
                string value = input.Substring(1);


                //Console.WriteLine($"Tecken: {nav}, Värde: {value}");

                switch (nav)
                {
                    case '+':
                        theList.Add(value);
                        Console.WriteLine($"Added {value} to the list");
                        break;

                    case '-':
                        theList.Remove(value);
                        Console.WriteLine($"Removed {value} from the list");
                        break;

                    case '*':
                        isRunning = false;
                        break;

                    default:
                        Console.WriteLine($"Input has to be either + or -");
                        break;
                }

                #region [Capacity]
                //Checking if the capacity has changed
                //The capacity increases exponantially starting with 4 -> 8 -> 16 -> 32
                //If the count is 4 and capacity is 4 it will stay at 4. Once count gets to 5 the capacity increases to 8.

                //The capacity will not decrease if you remove "items" from the list
                if (theList.Capacity != cap)
                {
                    Console.WriteLine($"Capacity changed: {cap} -> {theList.Capacity}");
                    cap = theList.Capacity;
                }
                #endregion

                #region [Capacity - elements and capacity]
                //Show amount of elements and the capacity
                Console.WriteLine($"{Environment.NewLine}Count: {theList.Count}, Capacity: {theList.Capacity}");
                #endregion

            }
        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */
            /*
            Datastrukturen kö(implementerad i Queue-klassen) fungerar enligt Först In Först Ut
            (FIFO) principen.Alltså att det element som läggs till först kommer vara det som tas bort
            först.
            1.Simulera följande kö på papper: 
            a.ICA öppnar och kön till kassan är tom
            b.Kalle ställer sig i kön
            c.Greta ställer sig i kön
            d.Kalle blir expedierad och lämnar kön
            e.Stina ställer sig i kön
            f.
            Greta blir expedierad och lämnar kön
            g.Olle ställer sig i kön
            h.      … 
            2.Implementera metoden ExamineQueue. Metoden ska simulera hur en kö fungerar
            genom att tillåta användaren att ställa element i kön(enqueue) och ta bort element
            ur kön(dequeue). Använd Queue-klassen till hjälp för att implementera metoden. 
            Simulera sedan ICA - kön med hjälp av ditt program.
            */


        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */
        }

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

        }

    }
}

