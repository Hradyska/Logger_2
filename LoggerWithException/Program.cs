// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
using System.Text.Json;
using static LoggerWithException.FileService;

namespace LoggerWithException
{
    /// <summary>
    /// executed.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Enter point.
        /// </summary>
        /// <param name="args">arg1.</param>
        private static void Main(string[] args)
        {
            Starter.Run();
        }
    }
}