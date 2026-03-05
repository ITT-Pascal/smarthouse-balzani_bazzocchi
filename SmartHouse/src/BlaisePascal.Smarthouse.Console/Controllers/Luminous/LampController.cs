using BlaisePascal.Smarthouse.Application.Devices.Luminous.LampDevice.Use_Cases.Commands;
using BlaisePascal.Smarthouse.Application.Devices.Luminous.LampDevice.Use_Cases.Queries;
using BlaisePascal.SmartHouse.Domain.Abstractions.ValueObjects;
using BlaisePascal.SmartHouse.Domain.Electrodomestic.Luminous.Repositories;
using BlaisePascal.SmartHouse.Domain.Electrodomestic.Luminous.Entities;
using System;
using System.Collections.Generic;
using System.Xml.Linq;
namespace BlaisePascal.Smarthouse.Presentation.Controllers.Luminous
{
    public class LampController
    {
        private readonly ILampRepository _lampRepository;

        public LampController(ILampRepository lampRepository)
        {
            _lampRepository = lampRepository;
        }
        public void AddLamp()
        {
            Console.Write("Inserisci il nome della lampada: ");
            string name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Errore: Il nome non può essere vuoto.");
                return;
            }
            Name lampName = new Name(name);
            AddLampCommand command = new AddLampCommand(_lampRepository);
            command.Execute(lampName);
            Console.WriteLine("Lampada aggiunta");
        }
        public void ShowLamps()
        {
            GetAllLampsQuery query = new GetAllLampsQuery(_lampRepository);
            List<Lamp> lamps = query.Execute();
            if (lamps.Count == 0)
            {
                Console.WriteLine("Nessuna lampada disponibile");
                return;
            }

            Console.WriteLine("\n--- LISTA LAMPADE ---");
            foreach (Lamp lamp in lamps)
            {
                Console.WriteLine($"- ID: {lamp.Id}");
                Console.WriteLine($"  Nome: {lamp.Name.name} | Stato: {lamp.Status} | Intensità: {lamp.Intensity.Value}%");
                Console.WriteLine("-----------------------");
            }
        }
        public void SwitchOnLamp()
        {
            Console.Write("Inserisci l'ID della lampada da accendere: ");
            string inputId = Console.ReadLine();

            if (Guid.TryParse(inputId, out Guid id))
            {
                SwitchOnLampCommand command = new SwitchOnLampCommand(_lampRepository);
                command.Execute(id);
                Console.WriteLine("Lampada accesa.");
            }
            else
            {
                Console.WriteLine("ID non valido.");
            }
        }
        public void SwitchOffLamp()
        {
            Console.Write("Inserisci l'ID della lampada da spegnere: ");
            string inputId = Console.ReadLine();

            if (Guid.TryParse(inputId, out Guid id))
            {
                SwitchOffLampCommand command = new SwitchOffLampCommand(_lampRepository);
                command.Execute(id);
                Console.WriteLine("Lampada spenta.");
            }
            else
            {
                Console.WriteLine("ID non valido.");
            }
        }
        public void SetIntensityLamp()
        {
            Console.Write("Inserisci l'ID della lampada: ");
            if (Guid.TryParse(Console.ReadLine(), out Guid id))
            {
                Console.Write("Inserisci la nuova intensità (0-100): ");
                if (int.TryParse(Console.ReadLine(), out int intensity))
                {
                    Intensity newIntensity = new Intensity(intensity);
                    SetIntensityLampCommand command = new SetIntensityLampCommand(_lampRepository);
                    command.Execute(id, newIntensity);
                    Console.WriteLine($"Comando eseguito: Intensità impostata a {intensity}%.");
                }
                else
                {
                    Console.WriteLine("Errore: L'intensità deve essere un numero intero.");
                }
            }
            else
            {
                Console.WriteLine("Errore: Formato ID non valido.");
            }
        }
        public void DimmerLamp()
        {
            Console.Write("Inserisci l'ID della lampada: ");
            if (Guid.TryParse(Console.ReadLine(), out Guid id))
            {
                Console.Write("Inserisci di quanto variare l'intensità");
                if (int.TryParse(Console.ReadLine(), out int amount))
                {
                    DimmerLampCommand command = new DimmerLampCommand(_lampRepository);
                    command.Execute(id, amount);
                    Console.WriteLine($"Dimmer applicato ({amount}).");
                }
                else
                {
                    Console.WriteLine("Errore: Il valore deve essere un numero intero.");
                }
            }
            else
            {
                Console.WriteLine("ID non valido.");
            }
        }
        public void RemoveLamp()
        {
            Console.Write("Inserisci l'ID della lampada da rimuovere: ");
            if (Guid.TryParse(Console.ReadLine(), out Guid id))
            {
                RemoveLampCommand command = new RemoveLampCommand(_lampRepository);
                command.Execute(id);
                Console.WriteLine("Lampada rimossa.");
            }
            else
            {
                Console.WriteLine("ID non valido.");
            }
        }
    }
}