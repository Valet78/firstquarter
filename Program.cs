/*
Задача: 
Написать программу, которая из имеющегося массива строк формирует массив из строк, 
длина которых меньше либо равна 3 символа. Первоначальный массив можно ввести с 
клавиатуры или задать на старте выполнения алгоритма. При решении не рекомендуется 
коллекциями, лучше обойтись исключительно массивами.

Например: 
    ["hello", "2", "world", ":-)"] -> ["2", ":-)"]
    ["1234", "1567", "-2", "computer science"] -> ["2"]
    ["Russia", "Denmark", "Kazan"] -> []

*/

using System;
public class MainClass{
    public static void Main(){
        Console.Clear();
        
        Console.WriteLine("Ведите количество строк, которые Вы планируете ввести в массив:");
        int numN = inputNum("N = ");
        string [] inputMass = new string [numN];
        string [] outMass = new string [1] {String.Empty};
        Console.WriteLine("Теперь введите сами строки (конец строки - Enter):");
        InputDataMassive(numN);
        CheckValuesInMassive(numN);
        Console.Write("[");
        OutMassiveInConsole(numN, inputMass);
        Console.Write("] -> [");
        if (outMass.Length == 1 && outMass[0] == String.Empty) Console.Write("");
        else OutMassiveInConsole(outMass.Length, outMass);
        Console.WriteLine("]");

        // Вывод массивов
        void OutMassiveInConsole(int len, string [] massOut){
            for (int i = 0; i < len; i++){
                Console.Write("\"{0}\"", massOut[i]);
                if (i < len - 1) Console.Write(", ");
            }
        }
        
        // Проверяем полученный массив для формирования нового
        void CheckValuesInMassive(int num){
            int temp = 0;
            for (int i = 0; i < num; i++){
                if (inputMass[i].Length <= 3) {
                    if (outMass.Length < temp + 1) Array.Resize(ref outMass, outMass.Length + 1); 
                    outMass[temp] = inputMass[i];
                    temp++;                                       
                }
            }             
        }

        // Ввод данных в массив строк
        void InputDataMassive(int num){
            string ? inputStr = String.Empty;
            for(int i = 0; i < num; i++){
                inputStr = Console.ReadLine() ?? String.Empty; 
                if(inputStr == "") {
                    Console.WriteLine("Строка не должна быть пустой. Попробуйте ввести снова.");
                    --i;
                } else inputMass[i] = inputStr;
            }
        }
        
        // Ввод числа
       int inputNum(string text){
            int temp = 0;
            Console.Write(text);
            while (!TryInputText (Console.ReadLine() ?? String.Empty, ref temp)){
                Console.WriteLine("Введено некорректное число. Попробуйте снова.");
                Console.Write(text);
                temp = 0;
            }
            return temp;
       }

       // Проверка правильности ввода числа   
        bool TryInputText (string inputText, ref int inputInt){
            bool tryRes = true;            
            if(!Int32.TryParse(inputText, out inputInt)) tryRes = false; 
            if (inputInt < 1) tryRes = false;                                
            return tryRes;
        }
    }
}
