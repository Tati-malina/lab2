using System;
using System.Collections.Generic;
using System.Text;

namespace lab2
{
    static class ConsoleMenu
    {

        private static void SearchForSpecificCharacter(TheString _str, char character)
        {
            bool status;
            for (int i = 0; i < _str.GetStringValue().Length; i++)
            {
                status = default;
                foreach (var item in _str.SearchForSpecificCharacterIndex(_str.GetStringValue(), character))
                {
                    if (item == i)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(_str.GetStringValue()[i]);
                        Console.ResetColor();
                        status = true;
                    }
                }
                if (!status)
                {
                    Console.Write(_str.GetStringValue()[i]);
                }
            }
        }
        public static void StartConsole()
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.InputEncoding = System.Text.Encoding.Unicode;

            Console.WriteLine("Меню програми: ");
            Console.WriteLine("1 - Додати об'єкт в бінарне дерево\n2 - Вивести бінарне дерево (Postorder traversal)\n" +
                "3 - Пошук заданого символу в дереві\n4 - Пошук наявності об'єкта в дереві\n5 - Видалити дерево\n6 - Вийти з програми");

            var binaryTree = new BinaryTree<int>();
            TheString _string = null;
            int [] theArray = new int [0];
            
            bool status = true;
            while (status)
            {
                Console.WriteLine("----------------------------------");
                try
                {
                    Console.Write("\nОберіть бажану операцію:  "); string _choice = Console.ReadLine();
                    int choice = int.Parse(_choice); Console.WriteLine("----------------------------------");

                    switch (choice)
                    {
                        case 1:
                            {
                                Console.Write("Введіть дані для нового об'єкту :  "); 
                                string inputData = Console.ReadLine();
                              int input = int.Parse(inputData);
                             //   _string = new TheString(inputData);
                             //  binaryTree.Add(_string);
                               binaryTree.Add(input);
                                break;
                            }
                        case 2:
                            {
                                Console.WriteLine("Postorder traversal: ");
                                foreach (var item in binaryTree)
                                {
                                    //Console.WriteLine(item.GetStringValue());
                                  Console.WriteLine(item);
                                }
                                break;
                            }
                        case 3:
                            {
                                Console.Write("Введіть шукаємий символ: ");
                                string inputData = Console.ReadLine();
                                char _inputData = char.Parse(inputData);
                                
                                foreach (var item in binaryTree)
                                {
                                     //SearchForSpecificCharacter(item, _inputData);
                                    Console.WriteLine();
                                }
                                break;
                            }
                        case 4:
                            {
                                Console.WriteLine("Введіть значення шуканого об'єкта: ");
                                string objData = Console.ReadLine();
                                _string = new TheString(objData);

                                //if (binaryTree.NodeExists(_string))
                                //Console.WriteLine("Даний об'єкт існує в дереві!");
                                //else Console.WriteLine("Даний об'єкт не існує дереві!");

                                break;
                            }
                        case 5:
                            {
                                binaryTree.Clear();
                                break;
                            }
                        case 6:
                            {
                                status = false;
                                break;
                            }
                        case 7:
                            {
                                string inputData = Console.ReadLine();
                                int input = int.Parse(inputData);
                                TheArray.Add(ref theArray, input);
                                break;
                            }
                        case 8:
                            {
                                string inputData = Console.ReadLine();
                                int input = int.Parse(inputData);
                                TheArray.Remove(ref theArray, input);
                                break;
                            }
                        case 9:
                            {
                                foreach (var item in theArray)
                                {
                                    Console.WriteLine(item);
                                }
                                break;
                            }
                        default:
                            throw new Exception("Некоректне введення даних");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"\nException {e.Message}");
                    Console.WriteLine("************************************************");
                }
            }
        }
    }
}

