using System;
using lab_5_rpm; // Не забудь подключить свой неймспейс!

namespace lab_5_rpm
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Демонстрация паттерна Composite ===\n");

            // --- Шаг 1: Создаём файлы (листья) ---
            // Конструктор File принимает имя и размер (в КБ)
            File doc = new File("document.txt", 150);
            File photo = new File("photo.jpg", 2500);
            File music = new File("song.mp3", 4200);
            File archive = new File("backup.zip", 10000);

            // --- Шаг 2: Создаём папки (компоновщики) ---
            Folder mediaFolder = new Folder("Media");
            Folder docsFolder = new Folder("Documents");
            Folder rootFolder = new Folder("Root");

            // --- Шаг 3: Собираем иерархию с помощью Add() ---

            // Добавляем файлы в папку Media
            mediaFolder.Add(photo);
            mediaFolder.Add(music);

            // Добавляем файл в папку Documents
            docsFolder.Add(doc);

            // Добавляем файл и подпапку Media в корневую папку
            rootFolder.Add(archive);
            rootFolder.Add(docsFolder);
            rootFolder.Add(mediaFolder);

            // --- Шаг 4: Выводим размер корневой директории ---
            // Это ключевой момент: вызываем GetSize() только у rootFolder,
            // а он сам рекурсивно обойдёт всё дерево!
            long totalSize = rootFolder.GetSize();

            Console.WriteLine($"📁 Размер корневой директории '{rootFolder.Name}': {totalSize} KB");

            // --- Дополнительно: проверим размер подпапки ---
            Console.WriteLine($"📁 Размер папки '{mediaFolder.Name}': {mediaFolder.GetSize()} KB");

            // Ожидание нажатия клавиши, чтобы консоль не закрылась сразу
            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}