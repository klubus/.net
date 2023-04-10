using System;
using System.Collections.Generic;

namespace Common
{
    public class UslugaLogowanie
    {
        public static void PiszDoPliku(List<ILogowanie> zmienioneElementy)
        {
            foreach (var element in zmienioneElementy)
            {
                Console.WriteLine(element.Log());
            }
        }
    }
}
