using System;

namespace Common.Interfaces.Managers
{
    public interface IDnevniIzvestajManager
    {
        string NajprodavanijeJelo(DateTime d);
        string Promet(DateTime d);
        string BrojPorudzbina(DateTime d);
    }
}
