namespace ConsoleApp10.Data;

public static class Data{
    public static DataSet GetData(IEnumerable<char> input){
        var res = new DataSet();

        foreach(Letter s in input){
            if(s == '\n' || s == '\r') continue;
            
            if(!res.TryAdd(s, 1)){
                res.SetValue(s, res.GetValue(s) + 1);
            }
        }

        return res;
    }

    public static DataSet GetDataFromFile(string filename){
        using var file = new File(filename);

        return GetData(file);
    }
}
