/*
 In questo esercizio dovrete leggere un file CSV, che cambia poco da quanto appena visto nel live-coding in classe,
e salvare tutti gli indirizzi contenuti al sul interno all’interno di una lista di oggetti istanziati a partire dalla classe Indirizzo.
Attenzione: gli ultimi 3 indirizzi presentano dei possibili “casi particolari” che possono accadere a questo genere di file: 
vi chiedo di pensarci e di gestire come meglio crediate queste casistiche.
 
 */

string path = @"./../../../addresses.csv";
StreamReader file = File.OpenText(path);

List<Address> list = new List<Address>();

while (!file.EndOfStream)
{

    string riga = file.ReadLine();
    string[] info = riga.Split(',');

    bool hasEmptyElements = info.Any(x => x == "");

    if ( info.Length == 6 && !hasEmptyElements)
    {

        try
        {
            string firstName = info[0];
            string lastName = info[1];
            string streetName = info[2];
            string city = info[3];
            string province = info[4];
            string zip = info[5];
            if(info[0] != "Name")
            {
                Address address = new Address(firstName, lastName, streetName, city, province, zip);
                list.Add(address);
            }

        }
        catch (IndexOutOfRangeException e)
        {
            Console.WriteLine($"{riga} Formato Stringa Non Corretto");
            Console.WriteLine(e);

        } catch (FormatException e)
        {
            Console.WriteLine($"{riga} Formato Dato Stringa Non Corretto");
            Console.WriteLine(e);
        }

    }
    else
    {
        Console.WriteLine($"!!! - {riga} Lindirizzo non contiene tutti i campi richiesti - !!!");
    }



    //list.Add(info);


}

file.Close();


foreach (Address address in list)
{

    Console.WriteLine($"Name: {address.FirstName}");
    Console.WriteLine($"Last Name: {address.LastName}");
    Console.WriteLine($"Street Name: {address.StreetName}");
    Console.WriteLine($"City: {address.City}");
    Console.WriteLine($"Province: {address.Province}");
    Console.WriteLine($"Zip: {address.Zip}");
    Console.WriteLine("//////////");
}


public class Address
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string StreetName { get; set; }
    public string City { get; set; }
    public string Province { get; set; }
    public string Zip { get; set; }

    public Address(string firstName, string lastName, string streetName, string city, string province, string zip)
    {
        FirstName = firstName;
        LastName = lastName;
        StreetName = streetName;
        City = city;
        Province = province;
        Zip = zip;
    }

    
}