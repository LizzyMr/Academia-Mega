using Domain;
using Infraestructure;
using Subscribers;

var bus = new EventBus();
var repo = new TaskRepository(bus);

bus.Subscribe(new EmailNotifier());
bus.Subscribe(new SmsNotifier());
bus.Subscribe(new ConsoleUI());

// LA PRUEBA

var task1 = repo.Add(new TaskItem { Title = "Aprender Patrón Observer" });
var task2 = repo.Add(new TaskItem { Title = "Conectar PubSub a todo el Proyecto" });

task1.Complete();
repo.Update(task1);
Console.WriteLine(task1.IsDone);

repo.Delete(task2.id);