//this is really quick and dirty leave me alone
//variables
//this is going to be really slow and REALLY SUCK
Dictionary<int, int> UnicodeSwitchboard = new Dictionary<int, int>();
int randInt = 0;
Random randRand = new Random();
bool valid = false;
int totalVals = 0;

//ensure the file exists for it to write the new switchboard to

string filePath = @"C:\Users\Public\Switchboard_Generator";
Directory.CreateDirectory(filePath);

filePath = @"C:\Users\Public\PRINCEWARE\SWTCHBRDS\Unicode_Switchboard.txt";
using (StreamWriter w = File.AppendText(filePath)) ;
//it now exists whether or not it did before idk
//delete it to wipe
File.Delete(filePath);
//create it as an empty file
using (StreamWriter w = File.AppendText(filePath)) ;
//it now exists and is empty

Console.WriteLine("How many vals will you generate? (Unicode is 65535 ints)");
totalVals = int.Parse(Console.ReadLine());

//okay now it'll loop until it has completed a switchboard in a file (yike)
for (int i = 0; i <= totalVals; i++)
{
    valid = false;
    Console.Write($"Now writing switch for {i} ; ");
    do
    {
        //new rand
        randInt = randRand.Next(0, totalVals + 1);
        Console.Write($"generated {randInt} ; ");
        if (!UnicodeSwitchboard.ContainsValue(randInt))
        {
            //doesn't contain it add and repeat
            Console.Write($"{randInt} was valid, adding switch... ; ");
            UnicodeSwitchboard.Add(i, randInt);
            Console.WriteLine($" ({i},{randInt}) added to dictionary, progressing...!!");
            Console.WriteLine();
            valid = true;
        } else
        {
            Console.Write($"{randInt} was not valid, trying again ; ");
        }
    } while (!valid);
}
Console.WriteLine("generation complete, when you hit enter the file write will commence..");
Console.ReadKey(true);
Console.WriteLine();
//write to file
for (int i = 0; i <= totalVals; i++)
{
    using StreamWriter file = new(filePath, append: true);
    //current val
    file.WriteLine(UnicodeSwitchboard[i].ToString());
}
Environment.Exit(0);