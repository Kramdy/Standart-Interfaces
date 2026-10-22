using System;
using System.Text;

namespace DZ_Generic_Collections
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            // Створіть клас MyClass, в якому створіть автовластивість типу int.
            // Створіть клас MyCollection<T>, який реалізує основний функціонал
            // колекції елементів. При створенні MyCollection<T> використовуйте
            // успадкування та реалізацію IEnumerable<T>, IEnumerator<T>.
            // У методі Main наповніть екземпляр колекції елементами MyClass,
            // виконайте двічі обхід цієї колекції з виведенням на екран значень
            // автовластивості елементів колекції.
            MyCollection<MyClass> numbers = new MyCollection<MyClass>();
            numbers.Add(new MyClass { Value = 10 });
            numbers.Add(new MyClass { Value = 20 });
            numbers.Add(new MyClass { Value = 30 });
            Console.WriteLine("Первый обход MyCollection<MyClass>:");
            foreach (MyClass item in numbers) Console.WriteLine(item.Value);
            Console.WriteLine("Второй обход MyCollection<MyClass>:");
            foreach (MyClass item in numbers) Console.WriteLine(item.Value);

            // ICloneable, IComparable, IComparer, GetEnumerator via yield.
            // Class Product (назва, дата, ціна). Створюєте вашу колекцію продуктів:
            // тестуєте foreach, клонування, різні сортировки за назвою, датою, ціною.
            // Используются продукты здорового питания.
            MyCollection<Product> products = new MyCollection<Product>();
            products.Add(new Product("Авокадо", new DateTime(2026, 10, 20), 85.50m));
            products.Add(new Product("Гречка", new DateTime(2026, 9, 15), 72.00m));
            products.Add(new Product("Йогурт натуральный", new DateTime(2026, 10, 25), 48.90m));
            products.Add(new Product("Киноа", new DateTime(2026, 8, 30), 160.00m));

            PrintProducts("\nИсходный список продуктов", products);
            Product clonedProduct = (Product)products[0].Clone();
            Console.WriteLine("\nКлонированный продукт: " + clonedProduct);
            Console.WriteLine("Это другой объект: " + (!object.ReferenceEquals(products[0], clonedProduct)));

            products.Sort(new ProductNameComparer());
            PrintProducts("\nСортировка по названию", products);
            products.Sort(new ProductDateComparer());
            PrintProducts("\nСортировка по дате", products);
            products.Sort(new ProductPriceComparer());
            PrintProducts("\nСортировка по цене", products);

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
        private static void PrintProducts(string title, MyCollection<Product> products)
        {
            Console.WriteLine(title + ":");
            foreach (Product product in products) Console.WriteLine(product);
        }
    }
}
