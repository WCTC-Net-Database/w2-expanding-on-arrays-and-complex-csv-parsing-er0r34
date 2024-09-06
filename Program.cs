using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;

class Program
{
    static List<Character> characters;

    static void Main()
    {
        string filePath = "input.csv";
        characters = ReadCharactersFromCsv(filePath);
        characters = ReadCharactersFromCsv(filePath);

        while (true)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Display Characters");
            Console.WriteLine("2. Add Character");
            Console.WriteLine("3. Level Up Character");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    DisplayAllCharacters(characters);
                    break;
                case "2":
                    AddCharacter(characters);
                    WriteCharactersToCsv(filePath, characters);
                    break;
                case "3":
                    LevelUpCharacter(characters);
                    WriteCharactersToCsv(filePath, characters);
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static List<Character> ReadCharactersFromCsv(string filePath)
    {
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            NewLine = Environment.NewLine,
            HeaderValidated = null
        };

        using (var reader = new StreamReader(filePath))
        using (var csv = new CsvReader(reader, config))
        {
            csv.Context.RegisterClassMap<CharacterMap>();
            return new List<Character>(csv.GetRecords<Character>());
        }
    }

    static void WriteCharactersToCsv(string filePath, List<Character> characters)
    {
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            NewLine = Environment.NewLine
        };

        using (var writer = new StreamWriter(filePath))
        using (var csv = new CsvWriter(writer, config))
        {
            csv.Context.RegisterClassMap<CharacterMap>();
            csv.WriteRecords(characters);
            writer.Flush(); // Ensure all data is flushed to the file
        }
    }

    static void DisplayAllCharacters(List<Character> characters)
    {
        foreach (var character in characters)
        {
            string equipment = character.Equipment != null ? string.Join(", ", character.Equipment) : "None";
            Console.WriteLine($"Name: {character.Name}, Class: {character.CharacterClass}, Level: {character.Level}, HP: {character.HitPoints}, Equipment: {equipment}");
        }
    }

    static void AddCharacter(List<Character> characters)
    {
        Console.Write("Enter name: ");
        string name = Console.ReadLine();
        name = FormatName(name);

        Console.Write("Enter class: ");
        string characterClass = Console.ReadLine();
        Console.Write("Enter level: ");
        int level = int.Parse(Console.ReadLine());
        Console.Write("Enter hit points: ");
        int hitPoints = int.Parse(Console.ReadLine());
        Console.Write("Enter equipment (separated by '|'): ");
        string[] equipment = Console.ReadLine().Split('|');

        characters.Add(new Character
        {
            Name = name,
            CharacterClass = characterClass,
            Level = level,
            HitPoints = hitPoints,
            Equipment = equipment
        });
    }

    static string FormatName(string name)
    {
        var parts = name.Split(' ');
        if (parts.Length > 1)
        {
            return $"{parts[1]}, {parts[0]}";
        }
        return name;
    }

    static void LevelUpCharacter(List<Character> characters)
    {
        Console.Write("Enter the name of the character to level up: ");
        string nameToLevelUp = Console.ReadLine();

        foreach (var character in characters)
        {
            if (character.Name.Equals(nameToLevelUp, StringComparison.OrdinalIgnoreCase))
            {
                character.Level++;
                Console.WriteLine($"Character {character.Name} leveled up to level {character.Level}!");
                return;
            }
        }

        Console.WriteLine("Character not found.");
    }
}

public class Character
{
    [Name("Name")]
    public string Name { get; set; }

    [Name("Class")]
    public string CharacterClass { get; set; }

    [Name("Level")]
    public int Level { get; set; }

    [Name("HP")]
    public int HitPoints { get; set; }

    [Name("Equipment")]
    public string[] Equipment { get; set; }
}

public sealed class CharacterMap : ClassMap<Character>
{
    public CharacterMap()
    {
        Map(m => m.Name).Name("Name");
        Map(m => m.CharacterClass).Name("Class");
        Map(m => m.Level).Name("Level");
        Map(m => m.HitPoints).Name("HP");
        Map(m => m.Equipment).Name("Equipment").Convert(row => string.Join("|", row.Value.Equipment ?? new string[0]));
    }
}
