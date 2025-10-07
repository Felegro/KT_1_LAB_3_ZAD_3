open System
open System.IO

// Lecture3 - последовательности и рекурсивные функции для обхода каталогов
let rec getAllFiles dir =
    seq {
        // Lecture3 - yield! для добавления всех файлов из текущей папки
        yield! Directory.GetFiles(dir)
        // Lecture3 - рекурсивный обход подкаталогов
        for subDir in Directory.GetDirectories(dir) do
            yield! getAllFiles subDir
    }

// Lecture3 - использование последовательности для поиска файла
let findFile filename startDir =
    getAllFiles startDir
    |> Seq.exists (fun filePath -> Path.GetFileName(filePath) = filename)

// Lecture1 - основной код
[<EntryPoint>]
let main argv =
    printf "Введите имя файла для поиска: "
    let fileName = Console.ReadLine()
    
    printf "Введите начальный каталог: "
    let startDir = Console.ReadLine()
    
    // Lecture3 - обработка последовательности
    let found = findFile fileName startDir
    
    if found then
        printfn "Файл '%s' найден в каталоге '%s' или его подкаталогах" fileName startDir
    else
        printfn "Файл '%s' не найден в каталоге '%s'" fileName startDir
    
    0