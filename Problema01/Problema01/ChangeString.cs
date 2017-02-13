using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Problema01
{
    public class ChangeString
    {
        Dictionary<int, string> Alfabeto()
        {
            Dictionary<int, string> alfabeto = new Dictionary<int, string>();
            alfabeto.Add(1, "a");
            alfabeto.Add(2, "b");
            alfabeto.Add(3, "c");
            alfabeto.Add(4, "d");
            alfabeto.Add(5, "e");
            alfabeto.Add(6, "f");
            alfabeto.Add(7, "g");
            alfabeto.Add(8, "h");
            alfabeto.Add(9, "i");
            alfabeto.Add(10, "j");
            alfabeto.Add(11, "k");
            alfabeto.Add(12, "l");
            alfabeto.Add(13, "m");
            alfabeto.Add(14, "n");
            alfabeto.Add(15, "ñ");
            alfabeto.Add(16, "o");
            alfabeto.Add(17, "p");
            alfabeto.Add(18, "q");
            alfabeto.Add(19, "r");
            alfabeto.Add(20, "s");
            alfabeto.Add(21, "t");
            alfabeto.Add(22, "u");
            alfabeto.Add(23, "v");
            alfabeto.Add(24, "w");
            alfabeto.Add(25, "x");
            alfabeto.Add(26, "y");
            alfabeto.Add(27, "z");

            return alfabeto;
        }

        public string build(string Parametro)
        {
            Dictionary<int, string> alfabeto = Alfabeto();
            string resultado = "";
            string parte = "";
            bool Upper = false;

            for (int i = 0; i < Parametro.Length; i++)
            {
                parte = Parametro.Substring(i, 1);

                if (!String.IsNullOrEmpty(parte) && Regex.IsMatch(parte, @"^[a-zA-Z]+$"))
                {
                    if (Regex.IsMatch(parte, @"^[A-Z]+$")) { Upper = true; } else { Upper = false; }
                    var letras = Upper ? alfabeto.Where(e => parte.Contains(e.Value.ToUpper())) : alfabeto.Where(e => parte.Contains(e.Value));
                    if (letras.Any())
                    {
                        if (Upper)
                        {
                            parte = alfabeto[letras.First().Key + (alfabeto.Count == letras.First().Key ? 0 : 1)].ToUpper();
                        }
                        else
                        {
                            parte = alfabeto[letras.First().Key + (alfabeto.Count == letras.First().Key ? 0 : 1)];
                        }
                    }
                }

                resultado = resultado + parte;
            }
            return resultado;
        }
    }
}
