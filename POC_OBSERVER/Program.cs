using System;
using System.Collections.Generic;

// Interfaz del Observador
public interface IObserver
{
    void Update(string email);
}

/// <summary>
/// Actúa como el sujeto (Subject) que mantiene una lista de observadores y notifica a los observadores cuando llega un nuevo correo electrónico.
/// </summary>
public class EmailSystem
{
    private List<IObserver> observers = new List<IObserver>();

    // Método para suscribirse a notificaciones
    public void Subscribe(IObserver observer)
    {
        observers.Add(observer);
    }

    // Método para desuscribirse de notificaciones
    public void Unsubscribe(IObserver observer)
    {
        observers.Remove(observer);
    }

    // Método para notificar a los observadores
    public void Notify(string email)
    {
        foreach (var observer in observers)
        {
            observer.Update(email);
        }
    }

    // Método para simular la llegada de un nuevo correo electrónico
    public void NewEmailArrived(string email)
    {
        Console.WriteLine("Nuevo correo electrónico recibido: " + email);
        Notify(email);
    }
}

/// <summary>
/// Observador (Observer) que implementa la interfaz IObserver y recibe notificaciones cuando llega un nuevo correo electrónico
/// </summary>
public class EmailNotification : IObserver
{
    public void Update(string email)
    {
        Console.WriteLine("Notificación por correo electrónico: Nuevo correo recibido - " + email);
    }
}

class Program
{
    static void Main(string[] args)
    {
        EmailSystem emailSystem = new EmailSystem();

        ///  creamos instancias de EmailNotification para los usuarios interesados en recibir notificaciones por correo electrónico. 
        EmailNotification user1 = new EmailNotification();
        EmailNotification user2 = new EmailNotification();

        ///  Suscribimos los observadores al sistema de correo electrónico(Subscribe).
        emailSystem.Subscribe(user1);
        emailSystem.Subscribe(user2);

        ///  Cuando llega un nuevo correo electrónico(NewEmailArrived), se notifica a todos los observadores suscritos(Notify).
        emailSystem.NewEmailArrived("ejemplo@dominio.com");

        ///  También podemos desuscribir a un observador del sistema de correo electrónico(Unsubscribe).
        emailSystem.Unsubscribe(user1);

        // Simulamos la llegada de otro nuevo correo electrónico
        emailSystem.NewEmailArrived("otro_ejemplo@dominio.com");
    }
}
