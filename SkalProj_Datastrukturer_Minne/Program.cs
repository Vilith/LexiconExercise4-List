using System;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Threading.Tasks;
using System.ComponentModel.Design;
using System.Xml.Linq;

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

        #region [ExamineList]
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
        #endregion

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>

        #region [ExamineQueue]
        static void ExamineQueue()
        {

            /*
            Uppgift 2:
                1. Simulera på papper. Gör en lättare skiss flödesdiagram?
                2. Implementera kod för att simulera kön med queue. 

            Svar:
                1. Bifogar bild gjord på draw.io
                2. Kod finnes nedan.
            */


            Queue<string> queue = new();
            bool queueRunning = true;

            //While loop for adding and removing customers from queue for as long as queueRunning is true.
            while (queueRunning)
            {

                Console.WriteLine($"{Environment.NewLine}Write +name to add a person to queue, - to remove from queue." +
                    $"{Environment.NewLine}Type * to go back to main menu.");
                string input = Console.ReadLine();

                //If input is null or empty the loop should return to mainmenu 
                //if (string.IsNullOrEmpty(input))
                //  break;

                char nav = input[0];
                string value = input.Substring(1);

                switch (nav)
                {
                    case '+':

                        queue.Enqueue(value);
                        Console.WriteLine($"{value} are now in the queue.");
                        Console.WriteLine($"{Environment.NewLine}Current queue: " + string.Join(", ", queue));
                        break;


                    case '-':
                        if (queue.Count > 0)
                        {
                            string removed = queue.Dequeue();
                            Console.WriteLine($"{removed} has been removed from the queue.");
                        }
                        else
                        {
                            Console.WriteLine($"Queue seems to be empty, nothing to remove");
                        }
                        Console.WriteLine($"{Environment.NewLine}Current queue: " + string.Join(", ", queue));
                        break;


                    case '*':

                        Console.WriteLine("Store shutting down");

                        if (queue.Count > 0)
                        {
                            Console.WriteLine($"Clearing queue from {queue.Count} person(s).");
                            queue.Clear();
                        }
                        else
                        {
                            Console.WriteLine("Queue were already empty.");
                        }

                        Console.WriteLine("Queue is now: (empty)");
                        queueRunning = false;
                        break;


                    default:
                        Console.WriteLine($"Input has to be either + or -");
                        break;

                }
            }
        }
        #endregion

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>

        #region [ExamineStack]
        static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */

            /*
            Stackar påminner om köer, men en stor skillnad är att stackar använder sig av Först In Sist 
            Ut (FILO) principen. Alltså gäller att det element som stoppas in först (push) är det som 
            kommer tas bort sist (pop).  
            1. Simulera ännu en gång ICA-kön på papper. Denna gång med en stack. Varför är det 
            inte så smart att använda en stack i det här fallet? 
            2. Implementera en ReverseText-metod som läser in en sträng från användaren och 
            med hjälp av en stack vänder ordning på teckenföljden för att sedan skriva ut den 
            omvända strängen till användaren.
            */

            /*
            Uppgift 3:
                1. Simulera på papper. Gör en lättare skiss flödesdiagram?
                2. Varför är det inte smart att använda en stack till detta fallet?                
                3. Implementera kod för att simulera kön med stack.

            Svar:
                1. Bifogar bild gjord på draw.io
                2. Är man först i kön till kassan, så ska man expedieras först också.
                3. Kod finnes nedan.

            */

            Stack<string> stack = new();
            bool examineRunning = true;

            while (examineRunning)
            {
                Console.WriteLine($"{Environment.NewLine}Write +name to push a person onto the stack" +
                    $"{Environment.NewLine}Write - to pop (remove) the last one." +
                    $"{Environment.NewLine}Write < to reverse a string" +
                    $"{Environment.NewLine}Write * to return to main menu.");

                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                    break;

                char nav = input[0];
                string value = input.Length > 1 ? input.Substring(1) : "";

                switch (nav)
                {

                    case '+':

                        stack.Push(value);
                        Console.WriteLine($"{value} pushed to the stack.");
                        break;


                    case '-':

                        if (stack.Count > 0)
                        {
                            string popped = stack.Pop();
                            Console.WriteLine($"{popped} was popped from the stack.");
                        }
                        else
                        {
                            Console.WriteLine($"Stack seems to be empty. There is nothing to pop.");
                        }
                        break;


                    case '<':

                        ReverseText();
                        break;


                    case '*':

                        Console.WriteLine("Store shutting down");
                        examineRunning = false;
                        break;


                    default:
                        Console.WriteLine($"Invalid input. Use +  -  !  or  *");
                        break;

                }
            }

        }
        

        static void ReverseText()
        {
            Console.WriteLine($"Input text to be reversed: ");
            string input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("No input entered.");
                return;
            }

            Stack<char> stack = new();

            foreach (char c in input)
                stack.Push(c);

            string reversed = "";
            while (stack.Count > 0)
                reversed += stack.Pop();

            Console.WriteLine($"You wrote: {input}" +
                $"{Environment.NewLine}Reversed: {reversed}");
        }
        #endregion

        #region [CheckParanthesis]
        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

            /*
            Ni bör nu ha tillräckliga kunskaper om ovannämnda datastrukturer för att lösa följande 
            problem. 
            Vi säger att en sträng är välformad om alla parenteser som öppnas även stängs korrekt. 
            Att en parentes öppnas och stängs korrekt dikteras av följande regler: 
            • ), }, ] får enbart förekomma efter respektive (, {, [ 
            • Varje parentes som öppnas måste stängas dvs ”(” följs av ”)” 
            Exempelvis är ([{}]({})) välformad men inte ({)}. Vidare kan en sträng innehålla andra tecken, 
            t ex är ”List<int> lista = new List<int>(){2, 3, 4};” välformad. Vi bryr oss alltså endast om 
            parenteser! 
            1. Skapa med hjälp av er nya kunskap funktionalitet för att kontrollera en välformad 
            sträng på papper. Du ska använda dig av någon eller några av de datastrukturer vi 
            precis gått igenom. Vilken datastruktur använder du?  
            2. Implementera funktionaliteten i metoden CheckParentheses. Låt programmet läsa 
            in en sträng från användaren och returnera ett svar som reflekterar huruvida 
            strängen är välformad eller ej.   
            */

            /*
            Uppgift 4:
                1. Simulera på papper. Gör en lättare skiss flödesdiagram?
                2. Implementera kod för att simulera kön med stack.

            Svar:
                1.
                2.
            */


        }
        #endregion
    }
}

