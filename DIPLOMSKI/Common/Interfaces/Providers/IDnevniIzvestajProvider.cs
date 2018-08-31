using System;

namespace Common.Interfaces.Providers
{
    public interface IDnevniIzvestajProvider
    {
        string NajprodavanijeJelo(DateTime d);
        string Promet(DateTime d);
        string BrojPorudzbina(DateTime d);
    }
}
