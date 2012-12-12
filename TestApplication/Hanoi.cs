using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gateway.Rules;
using Gateway;

namespace TestApplication
{
    public class Hanoi
    {
        public class Disk
        {
            public int size;
            public Pole pole;
            public int position;

            public Disk(int size)
            {
                this.size = size;
            }
        }

        public class Pole
        {
            public SortedList<int, Disk> disks = new SortedList<int, Disk>();


            public bool IsEmpty()
            {
                return disks.Count == 0;
            }

            public bool AllowDisk(Disk disk)
            {
                if (disk == null)
                {
                    return false;
                }
                if (disks.Count == 0)
                {
                    return true;
                }
                return GetTopDisk().size > disk.size;
            }

            public Disk GetTopDisk()
            {
                if (disks.Count > 0)
                {
                    return disks.Last().Value;
                }
                return null;
            }

            public void RemoveDisk()
            {
                disks.Remove(disks.Last().Key);
            }

            public void AddDisk(Disk disk)
            {

                if (AllowDisk(disk))
                {
                    disk.pole = this;
                    if (GetTopDisk() == null)
                        disk.position = 0;
                    else
                        disk.position = GetTopDisk().position + 1;
                    disks.Add(disk.position, disk);

                }
            }

        }

        Dictionary<int, Pole> poles = new Dictionary<int, Pole>();

        public Hanoi()
        {
            int numOfDisks = Input<int>.Get("S kolika disky chcete hrát (3-6)?").AddRule(new Rule<int>((i) => { return i >= 3 && i <= 6; }, "Počet disků musí být v intervalu <3, 6>."));
            poles.Add(0, new Pole());
            poles.Add(1, new Pole());
            poles.Add(2, new Pole());

            for (int i = 0; i < numOfDisks; i++)
            {
                poles[0].AddDisk(new Disk(numOfDisks - i));
            }
            Draw();
        }

        private void Draw()
        {
            Console.Clear();
            int width = Console.WindowWidth;
            int marg = width / 4 - 1;
            for (int i = 1; i <= 3; i++)
            {
                Console.SetCursorPosition(i * marg, 2);
                Console.Write("|");
                Console.SetCursorPosition(i * marg, 3);
                Console.Write("|");
                Console.SetCursorPosition(i * marg, 4);
                Console.Write("|");
                Console.SetCursorPosition(i * marg, 5);
                Console.Write("|");
                Console.SetCursorPosition(i * marg, 6);
                Console.Write("|");
                Console.SetCursorPosition(i * marg, 7);
                Console.Write("|");
                Console.SetCursorPosition(i * marg, 8);
                Console.Write("|");
                Console.SetCursorPosition(i * marg, 9);
                Console.Write("|");

                foreach(Disk d in poles[i-1].disks.Values)
                {

                }
            }
        }
    }
}
