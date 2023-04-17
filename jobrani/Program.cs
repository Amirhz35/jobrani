using jobrani;

string address = @"D:\tamrin\orders.csv";
string address2 = @"D:\tamrin\t.txt";
List<digimodel> digilist = new List<digimodel>();
digimodel digimodel;
string line;
string input;

using(StreamReader strread = new StreamReader(address))
{
    strread.ReadLine();
    while (!strread.EndOfStream)
    {
        line = strread.ReadLine();
        digimodel = new digimodel();

        //digimodel.ID_Order = Convert.ToInt32(line.Split(",")[0]);
        digimodel.ID_Customer = Convert.ToInt32(line.Split(",")[1]);
        //digimodel.ID_Item = Convert.ToInt32(line.Split(",")[2]);
        //digimodel.DateTime_CartFinalize = Convert.ToDateTime(line.Split(",")[3]);
        //digimodel.Amount_Gross_Order = Convert.ToInt32(line.Split(",")[4].Replace(".0", ""));
        //digimodel.city_name_fa = line.Split(",")[5];

        digilist.Add(digimodel);
    }
}

void odd()
{
    foreach (var item in digilist)
    {
        if (item.ID_Customer % 2 != 0)
            Console.WriteLine(item.ID_Customer);
    }
}
void prime()
{
    StreamWriter stwriter = new StreamWriter(address2);
    foreach(var item in digilist)
    {
        bool chek = true;
        int cond = Convert.ToInt32(Math.Sqrt(item.ID_Customer));
        for (int i = 2; (i <= cond); i++)
            if (item.ID_Customer % i == 0)
                chek = false;
        if (chek)
            stwriter.WriteLine(item.ID_Customer);
    }
}
void primeandodd()
{
    foreach (var item in digilist)
    {
        if (item.ID_Customer == 2)
            continue;
        bool chek = true;
        int cond = Convert.ToInt32(Math.Sqrt(item.ID_Customer));
        for (int i = 2; (i <= cond); i++)
            if (item.ID_Customer % i == 0)
                chek = false;
        if (chek)
            Console.WriteLine(item.ID_Customer);
    }
}
void lockkey()
{
    
    do
    {
        input = Console.ReadKey(true).KeyChar.ToString();

    } while (input != "1" && input != "2" && input != "3" );
}

Console.WriteLine("what task you want to do?? \n1_odd number\n2_prime number\n3_primeandodd number");
Console.WriteLine("please notice you can only use 1/2/3 ");
lockkey();

switch (input)
{
    case "1":
        odd(); 
        break;
    case "2":
        prime();
        break;
    case "3":
        primeandodd();
        break;
}