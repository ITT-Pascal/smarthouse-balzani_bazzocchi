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
            try
            {
                Name lampName = new Name(name);
                AddLampCommand command = new AddLampCommand(_lampRepository);
                command.Execute(lampName);
                Console.WriteLine("Lampada aggiunta");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            
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

            Console.WriteLine("\n LISTA LAMPADE");
            foreach (Lamp lamp in lamps)
            {
                Console.WriteLine($"- ID: {lamp.Id}");
                Console.WriteLine($"  Nome: {lamp.Name.name} | Stato: {lamp.Status} | Intensità: {lamp.Intensity.Value}%");
                Console.WriteLine($"Creazione: {lamp.CreatedAtUtc} | Ultima Modifica: {lamp.LastModifiedAtUtc}");
                Console.WriteLine("-----------------------");
            }
        }
        public void SwitchOnLamp()
        {
            try
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
            catch(Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
           
        }
        public void SwitchOffLamp()
        {
            try
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
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }

        }
        public void SetIntensityLamp()
        {
            try
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
                        Console.WriteLine("L'intensità deve essere nel range.");
                    }
                }
                else
                {
                    Console.WriteLine("ID non valido.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }

        }
        public void DimmerLamp()
        {
            try
            {
                Console.Write("Inserisci l'ID della lampada: ");
                if (Guid.TryParse(Console.ReadLine(), out Guid id))
                {
                    Console.Write("Inserisci di quanto variare l'intensità: ");
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
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }
        public void RemoveLamp()
        {
            try
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
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }

        public void ShowMenu()
        {
            Console.WriteLine();
            Console.WriteLine("1 - Add lamp");
            Console.WriteLine("2 - Remove lamp");
            Console.WriteLine("3 - Switch ON");
            Console.WriteLine("4 - Switch OFF");
            Console.WriteLine("5 - Set Intensity");
            Console.WriteLine("6 - Dimmer");
            Console.WriteLine("0 - Exit");
            Console.WriteLine();
        }
    }
}