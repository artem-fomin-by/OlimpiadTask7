namespace ConsoleApp10.Data;

public class Letter : IEquatable<Letter>{
    private readonly char Origin;

    private Letter(char origin){
        Origin = origin;
    }

    public static implicit operator char(Letter l){
        return l.Origin;
    }

    public static implicit operator Letter(char origin){
        return new Letter(origin);
    }

    public override int GetHashCode(){
        return Origin;
    }

    public bool Equals(Letter other){
        return Origin == other.Origin;
    }

    public override bool Equals(object? obj){
        return obj switch{
            Letter l when l == obj => true,
            Letter l => Equals(l),
            _ => false
        };
    }

    public override string ToString(){
        return Origin.ToString();
    }
}
