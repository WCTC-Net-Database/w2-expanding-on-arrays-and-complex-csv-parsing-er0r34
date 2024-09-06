# Week 2 Assignment: Expanding on Arrays and Complex CSV Parsing

## Overview:
In this assignment, you will expand upon your Week 1 console application by incorporating more complex data structures such as arrays, as well as handling more sophisticated CSV parsing scenarios. The goal is to practice reading and writing character data from and to a CSV file with quotes and commas in the character names, as well as working with arrays for equipment.

## Learning Objectives:
- Practice handling arrays and complex string parsing in CSV files.
- Strengthen understanding of file I/O by reading from and writing to a CSV file.
- Learn to manage special cases, such as quoted strings containing commas in CSV data.

## Assignment Tasks:
1. **Expanding the Console Application**:
   - Build on the Week 1 console application.
   - Modify the program to handle CSV files with a header row and quoted names that contain commas.
    **Example Menu**
        ```bash
        1. Display Characters
        2. Add Character
        3. Level Up Character
        ```

2. **Array Handling**:
   - Properly parse equipment arrays stored in the CSV file, ensuring correct output and input handling.

3. **Advanced File I/O**:
   - Ensure the program reads the CSV file, processes the character data, and writes back updated data in the same format.

4. **Stretch Goal**:
   - Implement the [CsvHelper](https://joshclose.github.io/CsvHelper/) library to simplify CSV parsing and ensure the program can handle complex CSV structures.

## Tips
To help you complete the assignment, here are some useful C# methods and techniques for parsing CSV files:
- **IndexOf**: Use this method to find the position of a specific character or substring within a string. This is useful for locating commas or quotes.
    ```csharp
    int commaIndex = line.IndexOf(',');
    ```
- **Substring**: Extract a portion of a string starting from a specific index. This is useful for getting parts of the CSV line.
    ```csharp
    string name = line.Substring(0, commaIndex);
    ```
- **StartsWith and EndsWith**: Check if a string starts or ends with a specific character or substring. This is useful for handling quoted names.
    ```csharp
    if (line.StartsWith(""") && line.EndsWith(""")) { // Handle quoted name }
    ```
- **Trim**: Remove leading and trailing whitespace or specific characters from a string. This is useful for cleaning up parsed data.
    ```csharp
    string cleanedName = name.Trim('"');
    ```
- **Split**: Split a string into an array based on a delimiter. This is useful for parsing CSV fields and equipment arrays.
    ```csharp
    string[] fields = line.Split(','); 
    string[] equipment = fields[4].Split('|');
    ```
- **Replace**: Replace all occurrences of a specified string or character with another string or character. This can be useful for cleaning up data.
    ```csharp
    string cleanedLine = line.Replace(""", "");
    ```

## Rubric

| Category                          | Full Marks (100)              | Partial Marks (50-90)                   | Minimal Marks (10-40)                     | No Marks (0)                           |
|-----------------------------------|------------------------------|---------------------------------------|-----------------------------------------|----------------------------------------|
| **File I/O Operations**           | Successfully reads and writes character data from/to the CSV file with correct formatting and structure. | Reads/writes data but with minor formatting issues or data errors. | Able to read but not write, or vice versa, or contains significant errors. | Does not correctly read or write data. |
| **Array Handling**                | Correctly parses equipment arrays and handles them in both input and output. | Partially correct handling of arrays, with minor issues in parsing or display. | Arrays are improperly handled or not displayed correctly. | No array handling is implemented. |
| **String Parsing (Quotes/Commas)** | Properly handles quoted names and names with commas in the CSV file. | Mostly handles quoted names correctly, with occasional parsing issues. | Struggles with correctly parsing quoted names or handling commas. | Does not account for quoted names or commas in the CSV. |
| **Program Flow**                  | The program runs smoothly, and users can interact with it to level up characters without issues. | Program runs but with occasional issues in flow or logic (e.g., character not leveled properly). | Program flow is confusing or error-prone, making it difficult to use correctly. | Program does not run or crashes frequently. |
| **Stretch Goal: CsvHelper (+10%)**       | Successfully implements CsvHelper for handling complex CSV parsing, greatly simplifying the logic. | Implements CsvHelper but with some issues in integration or handling specific cases. | Attempts to implement CsvHelper but the logic is flawed or incomplete. | No attempt to implement CsvHelper. |

## Notes for Students:
Make sure to test your program thoroughly using different kinds of character names and equipment arrays. Pay special attention to quoted strings and handling commas within names.
