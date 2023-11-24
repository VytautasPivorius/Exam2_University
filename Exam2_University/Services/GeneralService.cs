using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam2_University
{
    public class GeneralService
    {
        //Priimama naudotojo ivestis,
        //padaroma validacija paverciant ivesti i skaiciu,
        public int ValidateInputStringToInt()
        {
            int id = -1;
            while (true)
            {
                Console.Write("Ivestis: ");
                string inputLectureAdd = Console.ReadLine().ToUpper();

                if (inputLectureAdd == "Q")
                {
                    break;
                }
                else if (!int.TryParse(inputLectureAdd, out id))
                {
                    continue;
                }
                break;
            }
            return id;
        }
    }
}
