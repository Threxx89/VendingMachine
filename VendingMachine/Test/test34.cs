using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Test
{
    class test34
    {
        private static List<Bread> bakeryBread = new List<Bread>();
        public static void Main2()
        {
            List<int> l = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse).ToList();


            for (int i = 0; i < l[0]; i++)
            {
                List<int> breadInfo = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse).ToList();
                bakeryBread.Add(new Bread(breadInfo[0], breadInfo[1]));
            }

            for (int i = 0; i < l[1]; i++)
            {
                string[] queryString = Console.ReadLine().Split(' ');
                if ("bake" == queryString[0])
                {
                    for (int z = 0; z < queryString.Length - 1; z++)
                    {
                        Bake(z, int.Parse(queryString[z + 1]));
                    }
                }
                else
                {
                    int totalAmount = 0;
                    List<int> oa = new List<int>();
                    for (int z = 0; z < queryString.Length - 1; z++)
                    {
                        oa.Add(int.Parse(queryString[z + 1]));
                    }

                    if (CanBuy(oa))
                    {
                        for (int z = 0; z < queryString.Length - 1; z++)
                        {
                            totalAmount += Buy(z, int.Parse(queryString[z + 1]));
                        }
                    }
                    else
                    {
                        totalAmount = -1;
                    }

                    Console.WriteLine(totalAmount);
                }
            }


        }
        private static void Bake(int index, int quantity)
        {
            bakeryBread[index].stock += quantity;
        }

        private static bool CanBuy(List<int> order)
        {
            for (int i = 0; i < order.Count; i++)
            {
                if (bakeryBread[i].stock < order[i])
                {
                    return false;
                }
            }
            return true;
        }

        private static int Buy(int index, int quantity)
        {
            bakeryBread[index].stock -= quantity;
            return bakeryBread[index].cost * quantity;
        }

        private class Bread
        {
            public int cost;
            public int stock;

            public Bread(int cost, int stock)
            {
                this.cost = cost;
                this.stock = stock;
            }

        }
    }
}
