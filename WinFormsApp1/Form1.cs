using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Security.Policy;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Threading;
using System.Collections;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        //Очередь: циклический буфер
        private class clqueue
        {
            //Чтение идет с головы, Добвление к хвосту списка.
            private int tail = -1, head = -1, cache = 256;
            private string[] sdata = new string[256];

            public void init(int length)
            {
                cache = length;
                sdata = new string[cache];
            }

            public void set(string data)
            {
                if (++tail >= cache) tail = 0;
                if (tail != head) { sdata[tail] = data; } else { tail--; };
            }

            public string get()
            {
                if (tail >= 0)
                {
                    if (++head >= cache) head = 0;
                    string res = sdata[head];
                    if (tail == head) { tail = -1; head = -1; }
                    return res;
                } else return "";
            }

            public string status()
            {
                return "Голова(начало) списка: "+Convert.ToString(head) +", Хвост(конец) списка: "+ Convert.ToString(tail);
            }

        }
        clqueue myqueue = new clqueue();

        public Form1()
        {
            InitializeComponent();
        }

        //Сортировка методом пузырька
        double qsort()
        {
            //Описание переменных
            int i, j;
            bool b;
            int[] data = new int[100000];
            DateTime tb, te;
            tb = DateTime.Now;
            //Подготовка тестовых данных
            for (i = 0; i < 100000; i++)
            { data[i] = i % 100; }
            //Сортировка
            b = true;
            while (b)
            {
                b = false;
                for (i = 0; i < 99999; i++)
                    if (data[i] > data[i + 1])
                    {
                        j = data[i];
                        data[i] = data[i + 1];
                        data[i + 1] = j;
                        b = true;
                    }
            }
            te = DateTime.Now;
            //Длительность сортировки
            return (te.Minute * 60000 + te.Second * 1000 + te.Millisecond - tb.Minute * 60000 - tb.Second * 1000 - tb.Millisecond);
        }

        double fsort()
        {
            int i, j;
            bool b;
            int[] data = new int[100000];
            DateTime tb, te;
            tb = DateTime.Now;
            for (i = 0; i < 100000; i++)
            { data[i] = i % 100; }
            b = true;
            while (b)
            {
                b = false;
                for (i = 0; i < 99999; i++)
                    if (data[i] > data[i + 1])
                    {
                        j = data[i];
                        data[i] = data[i + 1];
                        data[i + 1] = j;
                        b = true;
                    }
            }
            te = DateTime.Now;
            return (te.Minute * 60000 + te.Second * 1000 + te.Millisecond - tb.Minute * 60000 - tb.Second * 1000 - tb.Millisecond);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Text = Convert.ToString(qsort());
        }

        [DllImport("qit.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "qit_u")]
        private static extern byte[] qit_u(byte[] qcmd);

        private void button2_Click(object sender, EventArgs e)
        {
            myqueue.set("1"); myqueue.set("2"); myqueue.set("3"); myqueue.set("4"); myqueue.set("5");
            myqueue.set("+"); myqueue.set("7"); myqueue.set("8"); myqueue.set("9"); myqueue.set("!");
            button2.Text = myqueue.status(); ;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.Text += myqueue.get();
        }
    }
}