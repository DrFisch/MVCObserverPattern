using System.ComponentModel;
using System.Collections.Generic;

namespace MVCObserverPattern.Models
{
    public class Produkt : INotifyPropertyChanged
    {
        private string _name;
        private decimal _preis;
        private int _lagerbestand;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        public decimal Preis
        {
            get { return _preis; }
            set
            {
                if (_preis != value)
                {
                    _preis = value;
                    OnPropertyChanged(nameof(Preis));  // Benachrichtigt die View
                }
            }
        }

        public int Lagerbestand
        {
            get { return _lagerbestand; }
            set
            {
                if (_lagerbestand != value)
                {
                    _lagerbestand = value;
                    OnPropertyChanged(nameof(Lagerbestand));  // Benachrichtigt die View
                }
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class ProduktManager
    {
        public List<Produkt> Produkte { get; set; } = new List<Produkt>
        {
            new Produkt { Name = "Laptop", Preis = 999.99M, Lagerbestand = 10 },
            new Produkt { Name = "Smartphone", Preis = 499.99M, Lagerbestand = 25 },
            new Produkt { Name = "Tablet", Preis = 299.99M, Lagerbestand = 15 }
        };

        public void AktualisiereProdukt(string produktName, decimal neuerPreis, int neuerLagerbestand)
        {
            var produkt = Produkte.Find(p => p.Name.Equals(produktName, StringComparison.OrdinalIgnoreCase));
            if (produkt != null)
            {
                produkt.Preis = neuerPreis;
                produkt.Lagerbestand = neuerLagerbestand;
            }
        }
    }
}
