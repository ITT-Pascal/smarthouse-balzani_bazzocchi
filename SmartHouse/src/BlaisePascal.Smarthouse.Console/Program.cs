using BlaisePascal.SmartHouse.Domain.Electrodomestic.Luminous.Repositories;
using BlaisePascal.Smarthouse.Infrastructure.Repositories.LampRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.Smarthouse.Presentation.Controllers.Luminous;

namespace BlaisePascal.Smarthouse.Presentation
{
    public class Program
    {
        static void Main()
        {
            ILampRepository repository = new InMemoryLampRepository();
            LampController controller = new LampController(repository);
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                controller.ShowLamps();
                controller.ShowMenu();

                Console.Write("choose an option:");

                string choice = Console.ReadLine();

                switch(choice)
                {
                    case "1":
                        controller.AddLamp();
                        break;
                    case "2":
                        controller.RemoveLamp();
                        break;
                    case "3":
                        controller.SwitchOnLamp();
                        break;
                    case "4":
                        controller.SwitchOffLamp();
                        break;
                    case "5":
                        controller.SetIntensityLamp();
                        break;
                    case "6":
                        controller.DimmerLamp();
                        break;
                    case "0":
                        exit = true;
                        break;
                }
                Pause();
            }
        }
        static void Pause()
        {
            Console.WriteLine();
            Console.WriteLine("press ENTER to continue");
            Console.ReadLine();
        }
    }
}
