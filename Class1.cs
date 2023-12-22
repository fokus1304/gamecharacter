using System;

class Character
{
    //Свойства персонажа
    public string Name { get; set; }
    public int Health { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public int Victories { get; private set; }

    //Конструктор класса Character для инициализации полей при создании объекта
    public Character(string name, int health, int x, int y)
    {
        Name = name;
        Health = health;
        X = x;
        Y = y;
        Victories = 0;
    }

    //Метод для перемещения персонажа по координатам
    public void Move(int deltaX, int deltaY)
    {
        X += deltaX;
        Y += deltaY;
        Console.WriteLine($"{Name} переместился на координаты ({X}, {Y})");
    }

    //Метод для атаки другого персонажа
    public void Attack(Character target)
    {
        Console.WriteLine($"{Name} атакует {target.Name}");

        int distance = CalculateDistance(target);

        if (distance == 0)
        {
            target.Health -= 20; //Пример уменьшения здоровья после атаки

            if (target.Health <= 0)
            {
                Victories++;
                Console.WriteLine($"{Name} одержал победу! Общее количество побед: {Victories}");
            }
        }
        else
        {
            Console.WriteLine($"{target.Name} находится слишком далеко для атаки.");
        }
    }

    //Метод для лечения персонажа
    public void Heal()
    {
        if (Victories >= 5)
        {
            Health = 100;
            Console.WriteLine($"{Name} полностью излечился после 5 побед. Текущее здоровье: {Health}");
        }
        else
        {
            Health += 10;
            Console.WriteLine($"{Name} излечился. Текущее здоровье: {Health}");
        }
    }

    //Метод для определения друга или врага
    public void SetFriendOrFoe(Character otherCharacter)
    {
        if (otherCharacter != this)
        {
            if (otherCharacter.Health > 0)
            {
                Console.WriteLine($"{Name} сверяет статус {otherCharacter.Name}...");

                if (otherCharacter.Health > 50)
                {
                    Console.WriteLine($"{otherCharacter.Name} - это ваш союзник.");
                }
                else
                {
                    Console.WriteLine($"{otherCharacter.Name} - это ваш враг!");
                    Victories = 0;
                }
            }
            else
            {
                Console.WriteLine($"{otherCharacter.Name} уже повержен.");
            }
        }
        else
        {
            Console.WriteLine("Персонаж не может проверить сам себя.");
        }
    }

    //Метод для вычисления расстояния между персонажами
    private int CalculateDistance(Character otherCharacter)
    {
        return Math.Abs(X - otherCharacter.X) + Math.Abs(Y - otherCharacter.Y);
    }
}
