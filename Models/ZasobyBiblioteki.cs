using System;
using System.ComponentModel.DataAnnotations; 

namespace BibliotekaProjekt.Models
{
    public abstract class Zasob
    {
        public int Id { get; set; } 

        [Required] 
        public string Tytul { get; set; }
        
        public int RokWydania { get; set; }
        
        public bool CzyWypozyczony { get; set; } = false;

        public abstract decimal ObliczKare(int dniSpoznienia);
    }

    public class Ksiazka : Zasob
    {
        public string Autor { get; set; }
        public int LiczbaStron { get; set; }

        public override decimal ObliczKare(int dniSpoznienia)
        {
            return dniSpoznienia * 0.50m;
        }
    }

    public class Film : Zasob
    {
        public string Rezyser { get; set; }
        public int CzasTrwaniaMinuty { get; set; }

        public override decimal ObliczKare(int dniSpoznienia)
        {
            if (dniSpoznienia > 0)
                return 5.00m + (dniSpoznienia * 2.00m);
            else
                return 0;
        }
    }
}