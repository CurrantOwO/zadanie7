using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;

namespace zadanie5
{
    class Student
    {
        private int Id;
        private string FIO;
        private int Group;
        private string Data;
        private int a = 0;
        ArrayList inf = new ArrayList();
        public int id
        {
            get { return Id; }
            set { if (value >= 0) Id = value; }
        }
        public int grp
        {
            get { return Group; }
            set { if (value >= 0) Group = value; inf.Add(Group); }
        }
        public string fio
        {
            get { return FIO; }
            set { if (value != "" || value != " ") FIO = value; inf.Add(FIO); }
        }
        public string dat
        {
            get { return Data; }
            set { if (value != "" || value != " ") Data = value; inf.Add(Data); a++; }
        }
        public void Info()//список всех студентов
        {
            int li = 1;
            for (int i = 0; i < inf.Count; i++) {
                if (i == 0 || i % 3 == 0) { Console.WriteLine("Студент №" + li); li++; Console.WriteLine("\t" + inf[i]); }
                else { Console.WriteLine("\t" + inf[i]); }
            }
        }
        public void add()//добавляем данные
        {
            string n, d;
            Console.Write("Введите ФИО студента: ");
            n = Convert.ToString(Console.ReadLine());
            Console.Write("Введите номер группы: ");
            int g = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите дату рождения: ");
            d = Convert.ToString(Console.ReadLine());
            a++;
            id = a;
            fio = n;
            grp = g;
            dat = d;
            Info();
        }
        public void redakt()//изменяем
        {
            string n, d;
            Console.Write("Выберите номер студента: ");
            int nu = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите ФИО студента: ");
            n = Convert.ToString(Console.ReadLine());
            Console.Write("Введите номер группы: ");
            int g = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите дату рождения: ");
            d = Convert.ToString(Console.ReadLine());
            int du = nu;
            if (nu > 1) { for (int i = 1; i < du; i++) nu = nu + 2; }
            inf[nu - 1] = n;
            inf[nu] = d;
            inf[nu + 1] = g;
            Info();
        }
        public void Dell()//удоляем
        {
            Console.Write("Выберите номер студента: ");
            int nu = Convert.ToInt32(Console.ReadLine());
            int du = nu;
            if (nu > 1) { for (int i = 1; i < du; i++) nu = nu + 2; }
            inf.RemoveRange(nu - 1, 3);
            a--;
            Info();
        }
        public void Sid()//поиск по id
        {
            Console.Write("Выберите номер студента: ");
            int nu = Convert.ToInt32(Console.ReadLine());
            int du = nu;
            if (nu > 1) { for (int i = 1; i < du; i++) nu = nu + 2; }
            for (int i = nu - 1; i < du + 2; i++) { Console.WriteLine("\t" + inf[i]); }
        }
        public void Old()//считаем возраст у студенто под вводим id
        {
            Console.Write("Выберите номер студента: ");
            int nu = Convert.ToInt32(Console.ReadLine());
            int du = nu;
            if (nu > 1) { for (int i = 1; i < du; i++) nu = nu + 2; }
            string s = inf[nu] + "";
            Console.WriteLine(s);
            s = s.Substring(s.Length - 4);
            int z = Convert.ToInt32(s);
            z = 2020 - z;
            Console.WriteLine("В этом году студенту " + z);
        }
        public void Inic()//Выводим инициалы
        {
            Console.Write("Выберите номер студента: ");
            int nu = Convert.ToInt32(Console.ReadLine());
            int du = nu;
            if (nu > 1) { for (int i = 1; i < du; i++) nu = nu + 2; }
            string s = inf[nu-1] + "";
            Console.WriteLine(s);
            string[] inc = s.Split(' ');
            string z = inc[1], l = inc[2];
            s = inc[0] + " " + z[0] + ". " + l[0] + ". ";
            Console.WriteLine(s);
        }
        public void sor(char la)//сортировка по возрасту
        {
            if (la == 's') { Console.WriteLine("Суденты старше 18 лет:"); }
            else if (la == 'a') { Console.WriteLine("Суденты младше 18 лет:"); }
            for (int i = 1; i < inf.Count; i += 3)
            {
                string s = inf[i] + "";
                s = s.Substring(s.Length - 4);
                int z = Convert.ToInt32(s);
                z = 2020 - z;
                if (z > 18 && la == 's')
                {
                    Console.WriteLine("Студент №" + i % 3);
                    Console.WriteLine(inf[i - 1] + "\n" + inf[i] + "\n" + inf[i + 1]);
                }
                else if (z < 18 && la == 'a')
                {
                    Console.WriteLine("Студент №" + i % 3);
                    Console.WriteLine(inf[i - 1] + "\n" + inf[i] + "\n" + inf[i + 1]);
                }
            }            
        }
        public void ser()
        {
            string sa = Convert.ToString(Console.ReadLine());
            for (int i = 0; i < inf.Count; i += 3)
            {
                string s = inf[i] + "";
                int a = 0;
                for (int la = 0; la < sa.Length; la++) { if (sa[la] == s[la]) { a++; }
                }
                if(a == sa.Length) { Console.WriteLine(s); }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Student ak = new Student();
            ak.id = 01;
            ak.fio = "Зябликов Василий Петячкин";
            ak.dat = "12.10.2001";
            ak.grp = 12;
            ak.id = 02;
            ak.fio = "Зяблов Васий Потчкин";
            ak.dat = "12.10.2000";
            ak.grp = 12;
            ak.id = 03;
            ak.fio = "Баулов Валентин Валович";
            ak.dat = "02.12.2005";
            ak.grp = 6;

            Console.WriteLine("Что вы хотите сделать?\n1.Добавить студента\n2.Изменить данные студента\n3.Удалить студента\n" +
                "4.Информация по id\n5.Возраст по id\n6.Вызов инициалов\n7.Сортировать по возрасту\n8.Поиск по фамилиям");
            int num = Convert.ToInt32(Console.ReadLine());
            switch (num)
            {
                case 1: { ak.Info(); ak.add(); break; } //Добавить студента
                case 2: { ak.Info(); ak.redakt(); break; } //Изменить данные студента
                case 3: { ak.Info(); ak.Dell(); break; } //Удалить студента
                case 4: { ak.Sid(); break; } //Информация по id
                case 5: { ak.Old(); break; } //Возраст по id
                case 6: { ak.Inic(); break; } //Вывод Инициалов
                case 7: { ak.sor('s'); ak.sor('a'); break; } //Возвращающий только студентов старше 18 лет или младше 18 лет в зависимости от введённого параметра (параметры «s» -младше 18, «a» - старше 18).
                case 8: { ak.ser(); break; }
            
            }

        }
    }
}