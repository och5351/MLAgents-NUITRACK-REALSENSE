public interface Observable
{
    void RegisterObserver(Observer o);
    void UnregisterObserver(Observer o);
    void NotifyObservers();
}
