using wt_lab3_3mvc_kleshchenok.Models;

namespace wt_lab3_3mvc_kleshchenok.Views;
public class CarView
{
    public void ShowCars(List<Car> cars)
    {
        Console.WriteLine("СПИСОК АВТОМОБИЛЕЙ");

        if (cars.Count == 0)
        {
            Console.WriteLine("Список пуст.");
            return;
        }

        foreach (var car in cars)
        {
            Console.WriteLine(
                $"{car.Id}. " +
                $"{car.Brand} {car.Model} ({car.Year}) | " +
                $"{car.PricePerDay} руб./сутки | " +
                $"Доступен: {(car.IsAvailable ? "да" : "нет")}"
            );
        }
    }

      public void ShowCar(Car car)
    {
        Console.WriteLine("АВТОМОБИЛЬ");
        Console.WriteLine($"ID: {car.Id}");
        Console.WriteLine($"Бренд: {car.Brand}");
        Console.WriteLine($"Модель: {car.Model}");
        Console.WriteLine($"Год выпуска: {car.Year}");
        Console.WriteLine($"Цена за сутки: {car.PricePerDay} руб.");
        Console.WriteLine($"Доступен: {(car.IsAvailable ? "да" : "нет")}");
    }

       public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }
}