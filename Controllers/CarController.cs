using wt_lab3_3mvc_kleshchenok.Models;
using wt_lab3_3mvc_kleshchenok.Views;

namespace wt_lab3_3mvc_kleshchenok.Controllers;

public class CarController
{
    private readonly List<Car> cars;
    private readonly CarView view;

    public CarController()
    {
        cars = new List<Car>
        {
            new Car
            {
                Id = 1,
                Brand = "Toyota",
                Model = "Camry",
                Year = 2022,
                PricePerDay = 5000,
                IsAvailable = true
            },
            new Car
            {
                Id = 2,
                Brand = "BMW",
                Model = "X5",
                Year = 2023,
                PricePerDay = 12000,
                IsAvailable = true
            },
            new Car
            {
                Id = 3,
                Brand = "Kia",
                Model = "Rio",
                Year = 2020,
                PricePerDay = 3000,
                IsAvailable = false
            }
        };

        view = new CarView();
    }

    public void Index()
    {
        view.ShowCars(cars);
    }

    public void Show(int id)
    {
        var car = cars.FirstOrDefault(c => c.Id == id);

        if (car == null)
        {
            view.ShowMessage("Автомобиль не найден.");
            return;
        }

        view.ShowCar(car);
    }

    public void Add(Car car)
    {
        cars.Add(car);
        view.ShowMessage("Автомобиль успешно добавлен.");
    }

    public void Delete(int id)
    {
        var car = cars.FirstOrDefault(c => c.Id == id);

        if (car == null)
        {
            view.ShowMessage("Автомобиль не найден.");
            return;
        }

        cars.Remove(car);
        view.ShowMessage("Автомобиль успешно удалён.");
    }
    
    public void Run()
    {
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("МЕНЮ");
            Console.WriteLine("1. Показать все автомобили");
            Console.WriteLine("2. Найти автомобиль по ID");
            Console.WriteLine("3. Добавить автомобиль");
            Console.WriteLine("4. Удалить автомобиль");
            Console.WriteLine("5. Показать доступные автомобили");
            Console.WriteLine("6. Поиск по бренду");
            Console.WriteLine("0. Выход");
            Console.Write("Выберите действие: ");

            var command = Console.ReadLine();

            switch (command)
            {
                case "1": Index(); break;
                case "2": ShowCarByUserInput(); break;
                case "3": AddCarByUserInput(); break;
                case "4": DeleteCarByUserInput(); break;
                case "5": ShowAvailableCars(); break;
                case "6": SearchByBrandByUserInput(); break;
                case "0": return;
                default: view.ShowMessage("Неизвестная команда."); break;
            }
        }
    }
    private void ShowCarByUserInput()
    {
        Console.Write("Введите ID автомобиля: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            view.ShowMessage("Некорректный ID.");
            return;
        }

        Show(id);
    }

    private void AddCarByUserInput()
    {
        Console.Write("Введите ID: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            view.ShowMessage("Некорректный ID.");
            return;
        }

        Console.Write("Введите бренд: ");
        string brand = Console.ReadLine() ?? "";

        Console.Write("Введите модель: ");
        string model = Console.ReadLine() ?? "";

        Console.Write("Введите год выпуска: ");
        if (!int.TryParse(Console.ReadLine(), out int year))
        {
            view.ShowMessage("Некорректный год.");
            return;
        }

        Console.Write("Введите цену за сутки: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal price))
        {
            view.ShowMessage("Некорректная цена.");
            return;
        }

        var newCar = new Car
        {
            Id = id,
            Brand = brand,
            Model = model,
            Year = year,
            PricePerDay = price,
            IsAvailable = true
        };

        Add(newCar);
    }

    private void DeleteCarByUserInput()
    {
        Console.Write("Введите ID автомобиля: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            view.ShowMessage("Некорректный ID.");
            return;
        }

        Delete(id);
    }

    private void ShowAvailableCars()
    {
        var available = cars.Where(c => c.IsAvailable).ToList();
        view.ShowCars(available);
    }
   
    public void SearchByBrand(string brand)
    {
        var result = cars
            .Where(c => c.Brand.Contains(brand, StringComparison.OrdinalIgnoreCase))
            .ToList();

        if (result.Count == 0)
        {
            view.ShowMessage($"Автомобили бренда '{brand}' не найдены.");
            return;
        }

        view.ShowCars(result);
    }
    private void SearchByBrandByUserInput()
    {
        Console.Write("Введите бренд: ");
        string brand = Console.ReadLine() ?? "";
        SearchByBrand(brand);
    }
}