using Domain.Events;

namespace Infraestructure;

public class EventBus : IObservable<TaskEvent>
{
    private readonly List<IObservable<TaskEvent>> _observers = [];

    public IDisposable Suscribe(IObserver<TaskEvent> observer)
    {
        if (!_observers.Contains(observer))
            _observers.Add(observer);

        return new Unsuscriber(_observers, observer);
    }

    public void Publish(TaskEvent ev)
    {
        foreach (var obs in _observers.ToArray())
            obs.OnNext(ev);
    }

    private sealed class Unsuscriber(List<IObserver<TaskEvent>> list, IObserver<TaskEvent> obs) : IDisposable
    {
        public void Dispose() => list.Remove(obs);
    }
}