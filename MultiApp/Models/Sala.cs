namespace MultiApp.Models
{
    public class Sala
    {
        public required string Nome { get; set; }
        public int BigliettiVenduti { get; set; }
        public int BigliettiRidottiVenduti { get; set; }
        public int CapienzaMassima { get; set; }

      
        public Sala() { }

        public Sala(string nome, int bigliettiVenduti, int bigliettiRidottiVenduti, int capienzaMassima)
        {
            Nome = nome;
            BigliettiVenduti = bigliettiVenduti;
            BigliettiRidottiVenduti = bigliettiRidottiVenduti;
            CapienzaMassima = capienzaMassima;
        }
    }
}




