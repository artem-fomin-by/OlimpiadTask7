using System.Collections;
using System.Diagnostics;

namespace ConsoleApp10.Data;

public class DataSet : IEnumerable<KeyValuePair<Letter, int>>{
    public readonly Dictionary<Letter, int> Letters;
    public int Amount{ get; private set; }

    internal DataSet(){
        Letters = new Dictionary<Letter, int>(32);
        Amount = 0;
    }

    public bool TryAdd(Letter s, int value){
        if(Letters.TryAdd(s, value)){
            Amount++;
            return true;
        }

        return false;
    }

    public void SetValue(Letter s, int value){
        Debug.Assert(Letters.ContainsKey(s));

        Letters[s] = value;
        Amount++;
    }

    public int GetValue(Letter s){
        Debug.Assert(Letters.ContainsKey(s));

        return Letters[s];
    }

    private IEnumerable<KeyValuePair<Letter, int>> Enumerate(){
        return Letters;
    }

    public IEnumerator<KeyValuePair<Letter, int>> GetEnumerator(){
        return Enumerate().GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator(){
        return Enumerate().GetEnumerator();
    }

    public IEnumerable<KeyValuePair<Letter, double>> GetDoubleFractions(){
        return this.Select(x => new KeyValuePair<Letter, double>(x.Key, (double)x.Value / Amount));
    }

    public IEnumerable<KeyValuePair<Letter, decimal>> GetDecimalFractions(){
        return this.Select(x => new KeyValuePair<Letter, decimal>(x.Key, (decimal)x.Value / Amount));
    }
}
