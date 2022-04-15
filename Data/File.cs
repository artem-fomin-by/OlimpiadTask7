using System.Collections;

namespace ConsoleApp10.Data;

internal class File : IEnumerable<char>, IDisposable{
    public readonly string FileName;
    private readonly StreamReader Reader;

    public File(string path){
        FileName = path;
        Reader = new StreamReader(path);
    }

    public void Dispose(){
        Reader.Close();
    }

    private IEnumerable<char> Enumerate(){
        yield return (char) Reader.Read();

        while(!Reader.EndOfStream){
            yield return (char) Reader.Read();
        }
    }

    IEnumerator<char> IEnumerable<char>.GetEnumerator(){
        return Enumerate().GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator(){
        return Enumerate().GetEnumerator();
    }
}
