using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainController
{
    class LRM
    {
        //nazwa domeny lub podsieci do której należy dany LRM
        private string _areaName;

        //agent służący do komunikacji węzlów sterowania
        //...

        //słownik zawierający id_SNPP wraz z przypisanym do niego SNPP
        //private Dictionary<int, SNPP> _SnppDictionary;

        //słownik zawierający nazwę podsieci wraz z przypisanej do niej adresem agenta LRM
        private Dictionary<string, string> _LrmOverSubnetworksDictionary;



        public LRM()
        {

        }


        public void LocalTopologyMethod()
        {

        }

        /*
         * Przychodzi (1,5)
         * przegląda 1 i patrzy, czy jego areaName = areaName LRM'a
         * - 1 należy do jego area więc bierze losową wartość z availableLabels
         * 
         * przegląda 5 
         * - 5 nie należy do jego area wiec odnajduje w slowniku adres do LRM'a odpowiadającemu tej 5-tce
         * - wysyła do tego SNPNegotiation
         * -dostaje odpowiedź pozytywną (tamten tworzy SNP u siebie związany z tym połączeniem)
         * - tworzy SNP związany z SNPP o id 5
         * - tworzy SNP związany z SNPP o id 1
         * Wysyłamy odpowiedż do CC, że zostało zrealizowane 
         * 
         * 
         */

        /*
         * Przychodzi (7,9)
         * - sprawdzamy 7 i widzimy, że nie nalezy do naszej area
         * - losujemy dowolną lambde z możliwych na tym łączu
         * - odnajdujemy adres LRS'a zwiazanego z 7
         * - wysyłamy do niego SNPNegotiation
         * - dostajemy odpowiedz pozytywną (tamten tworzy SNP u siebie związany z tym połaczeniem)
         * 
         * -sprawdzamy 9
         * - odnajdujemy adres LRS'a zwiazanego z 9
         * - wysyłamy do niego SNPNegotiation
         * - dostajemy odpowiedz pozytywna
         * 
         * -tworzymy lokalne SNP zwiazane z 7 i 9
         * 
         */
    }
}
