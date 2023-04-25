// <copyright file="Program.cs" company="Jose Robles">
// Copyright (c) Jose Robles. All Rights Reserved.
// </copyright>

namespace Final321.Frontend
{
    /// <summary>
    /// Internal class program - starts the app.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main function.
        /// </summary>
        private static void Main()
        {
            StoreMenu menu = new StoreMenu();
            menu.RunMenu();
        }
    }
}