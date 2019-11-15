public interface IObserver
{
    void Notify(Observer o);
    void AddObserver(Observer ob);
    void RemoveObserver(Observer ob);
}
public abstract class Observer
{
    public abstract void OnNotify();
}
