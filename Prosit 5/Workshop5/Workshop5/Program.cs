﻿using System;
using System.Diagnostics;
using System.Threading;

class Program
{

    static void Main()
    {
        Process notepadProcess = new Process

        {

            StartInfo = new ProcessStartInfo
            {
                FileName = "notepad.exe",
                Arguments = "C:\\Windows\\win.ini"
            }
        };

        notepadProcess.Exited += NotepadProcess_Exited;
        notepadProcess.Start();

        Console.WriteLine("Processus parent : Le processus 'notepad.exe' a été lancé avec des paramètres.");
        Console.WriteLine("notepadProcess.ProcessName : " + notepadProcess.ProcessName);
        Console.WriteLine("notepadProcess.Id : " + notepadProcess.Id);


        while (!notepadProcess.HasExited)
        {
            Thread.Sleep(1000);
        }

    }

    private static void NotepadProcess_Exited(object? sender, EventArgs e)
    {
        Console.WriteLine("fin du process");
        Console.WriteLine("notepadProcess.Id : " + ((Process)sender).Id) ;

    }
}
