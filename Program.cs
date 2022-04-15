using System.Diagnostics;
using ConsoleApp10.Data;

namespace ConsoleApp10;

public static class Program{
    private const string Filename = "DataBase.txt";

    private static Dictionary<Letter, Letter> GetTable(string ms1, string ms2){
        Debug.Assert(ms1.Length == ms2.Length);

        var res = new Dictionary<Letter, Letter>(32);
        for(var i = 0; i < ms1.Length; i++){
            res.TryAdd(ms2[i], ms1[i]);
        }

        return res;
    }

    private static string Decode(string toDecode, Dictionary<Letter, Letter> table, out Dictionary<Letter, int> notFound){
        var res = "";

        notFound = new Dictionary<Letter, int>(32 - table.Count);
        foreach(Letter s in toDecode){
            if(table.TryGetValue(s, out var cur)) res = res + cur;
            else{
                if(!notFound.TryGetValue(s, out var n)){
                    n = notFound.Count;
                    notFound.Add(s, n);
                }

                res = res + n;
            }
        }

        return res;
    }

    public static void Main(){
        var message1 = "ЛЬАУЛВИУЛМГВЯВЛЬКЁЬЗГПЖЁЬКЁУГТЧЛЬГТУЗЮАУЭТУЁВСЧЗГПЪЁЧРЛЬТЮГПМГУКГТМВЛЛУЩТЁБГУГТЧОЕНЦХШЙ".ToLower();
        var message2 = "ЗЮЬБЗМЧБЗНХМПМЗЮАФЮРХЪЯФЮАФБХТЭЗЮХТБРЫЬБЕТБФМГЭРХЪШФЭЁЗЮТЫХЪНХБАХТНМЗЗБОТФКХБХТЭУВЛИЖСЩ".ToLower();

        var table = GetTable(message1, message2);
        var decodedMessage = Decode(message1.Substring(0, message1.Length - 7), table, out var notFound);

       Console.WriteLine(decodedMessage + '\n');
       Console.WriteLine(string.Join(' ', notFound) + '\n');

       var dataSet1 = Data.Data.GetData(decodedMessage);
       var dataSet2 = Data.Data.GetDataFromFile(Filename);

       Console.WriteLine(string.Join(' ', dataSet1.GetDoubleFractions()) + '\n');
       Console.WriteLine(string.Join(' ', dataSet2.GetDoubleFractions()) + '\n');
    }
}
