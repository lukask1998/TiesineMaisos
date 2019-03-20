using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TiesineMaisos
{
    class HashTable
    {
        class hashentry
        {
            int key;
            string data;

            public hashentry(int key, string data)
            {
                this.key = key;
                this.data = data;
            }

            public int getkey() { return key; }
            public string getdata() { return data; }
        }

        const int maxSize = 100000;
        hashentry[] table;

        public HashTable()
        {
            table = new hashentry[maxSize];

            for (int i = 0; i < maxSize; i++)
            {
                table[i] = null;
            }
        }

        public string retrieve(int key)
        {
            int hash = key % maxSize;

            while (table[hash] != null && table[hash].getkey() != key)
                hash = (hash + 1) % maxSize;

            if (table[hash] == null)
                return "nothing found!";
            else
                return table[hash].getdata();
        }

        public void insert(int key, string data)
        {
            if (!checkOpenSpace())
            {
                Console.WriteLine("table is at full capacity!");
                return;
            }

            int hash = (key % maxSize);

            while (table[hash] != null && table[hash].getkey() != key)
            {
                hash = (hash + 1) % maxSize;
            }

            table[hash] = new hashentry(key, data);
        }

        private bool checkOpenSpace() //checks for open spaces in the table for insertion
        {
            bool isOpen = false;
            for (int i = 0; i < maxSize; i++)
            {
                if (table[i] == null)
                {
                    isOpen = true;
                }
            }
            return isOpen;
        }

        public bool remove(int key)
        {
            int hash = key % maxSize;
            while (table[hash] != null && table[hash].getkey() != key)
            {
                hash = (hash + 1) % maxSize;
            }
            if (table[hash] == null)
            {
                return false;
            }
            else
            {
                table[hash] = null;
                return true;
            }
        }

        public void print()
        {
            for (int i = 0; i < table.Length; i++)
            {
                if (table[i] == null && i <= maxSize)
                {
                    continue;
                }
                else
                {
                    Console.WriteLine("{0}", table[i].getdata());
                }
            }
        }

        private int hash1(int key)
        {
            return key % maxSize;
        }

        private int hash2(int key)
        {
            //must be non-zero, less than array size, ideally odd
            return 5 - key % 5;
        }
    }
}
