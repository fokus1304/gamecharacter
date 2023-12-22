﻿class Program
{
    static void Main()
    {
        //Ввод данных для создания главного персонажа
        Console.WriteLine("Введите имя главного персонажа:");
        string playerName = Console.ReadLine();

        Console.WriteLine("Введите здоровье главного персонажа:");
        int playerHealth = int.Parse(Console.ReadLine());

        Console.WriteLine("Введите координаты X главного персонажа:");
        int playerX = int.Parse(Console.ReadLine());

        Console.WriteLine("Введите координаты Y главного персонажа:");
        int playerY = int.Parse(Console.ReadLine());

        //Создание главного персонажа
        Character player = new Character(playerName, playerHealth, playerX, playerY);

        Console.WriteLine($"Главный персонаж {player.Name} создан.");

        //Ввод данных для создания врагов
        Console.WriteLine("Введите количество врагов:");
        int numberOfEnemies = int.Parse(Console.ReadLine());

        //Создаем массив врагов
        Character[] enemies = new Character[numberOfEnemies];
        for (int i = 0; i < enemies.Length; i++)
        {
            Console.WriteLine($"Введите имя врага {i + 1}:");
            string enemyName = Console.ReadLine();

            Console.WriteLine($"Введите здоровье врага {i + 1}:");
            int enemyHealth = int.Parse(Console.ReadLine());

            Console.WriteLine($"Введите координаты X врага {i + 1}:");
            int enemyX = int.Parse(Console.ReadLine());

            Console.WriteLine($"Введите координаты Y врага {i + 1}:");
            int enemyY = int.Parse(Console.ReadLine());

            //Создание врага
            enemies[i] = new Character(enemyName, enemyHealth, enemyX, enemyY);
            Console.WriteLine($"Враг {enemies[i].Name} создан. Здоровье: {enemies[i].Health}, Координаты: ({enemies[i].X}, {enemies[i].Y})");
        }

        bool exitGame = false;

        //Основной цикл игры
        while (!exitGame)
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Атаковать врага");
            Console.WriteLine("2. Переместиться по X или Y");
            Console.WriteLine("3. Вылечить себя");
            Console.WriteLine("4. Проверить друга или врага");
            Console.WriteLine("5. Выйти");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    //Атака врага
                    Console.WriteLine("Выберите врага для атаки (введите номер от 1 ):");
                    int enemyIndex = int.Parse(Console.ReadLine()) - 1;

                    if (enemyIndex >= 0 && enemyIndex < enemies.Length)
                    {
                        player.Attack(enemies[enemyIndex]);
                    }
                    else
                    {
                        Console.WriteLine("Некорректный номер врага.");
                    }
                    break;

                case 2:
                    //Перемещение главного персонажа
                    Console.WriteLine("Введите изменение координат X для перемещения главного персонажа:");
                    int moveX = int.Parse(Console.ReadLine());

                    Console.WriteLine("Введите изменение координат Y для перемещения главного персонажа:");
                    int moveY = int.Parse(Console.ReadLine());

                    player.Move(moveX, moveY);
                    break;

                case 3:
                    //Излечение главного персонажа
                    player.Heal();
                    break;

                case 4:
                    //Проверка друга или врага
                    Console.WriteLine("Выберите персонажа для сверки (введите номер от 1 ):");
                    int characterIndex = int.Parse(Console.ReadLine()) - 1;

                    if (characterIndex >= 0 && characterIndex < enemies.Length)
                    {
                        player.SetFriendOrFoe(enemies[characterIndex]);
                    }
                    else
                    {
                        Console.WriteLine("Некорректный номер персонажа.");
                    }
                    break;

                case 5:
                    //Выход из игры
                    exitGame = true;
                    Console.WriteLine("Игра завершена.");
                    break;

                default:
                    //Обработка некорректного выбора
                    Console.WriteLine("Некорректный выбор. Пожалуйста, введите число от 1 до 5.");
                    break;
            }
        }
    }
}