using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ApiHS.Modelos
{
    public class Literals
    {
        public static ObservableCollection<string> MecanicaES = new ObservableCollection<string>();
        public static ObservableCollection<string> MecanicaLA = new ObservableCollection<string>();
        public static ObservableCollection<string> TipoBI = new ObservableCollection<string>();
        public static ObservableCollection<string> RarezaBI = new ObservableCollection<string>();
        public static ObservableCollection<string> TipoEsbirroBI = new ObservableCollection<string>();

        public static ObservableCollection<string> SelectorMecanica(string region)
        {
                if (region == "es_ES")
                {
                    MecanicaES = new ObservableCollection<string>();
                    MecanicaES.Add("Cualquiera");
                    MecanicaES.Add("Adaptación");
                    MecanicaES.Add("Arrasar");
                    MecanicaES.Add("Cargar");
                    MecanicaES.Add("Combo");
                    MecanicaES.Add("Congelación");
                    MecanicaES.Add("Contraarrestar");
                    MecanicaES.Add("Convocar");
                    MecanicaES.Add("Daño con hechizo");
                    MecanicaES.Add("Descubre");
                    MecanicaES.Add("Eco");
                    MecanicaES.Add("Embestir");
                    MecanicaES.Add("Escudo divino");
                    MecanicaES.Add("Grito de batalla");
                    MecanicaES.Add("Hechizo doble");
                    MecanicaES.Add("Inmune");
                    MecanicaES.Add("Inspirar");
                    MecanicaES.Add("Lacayo");
                    MecanicaES.Add("Magnetismo");
                    MecanicaES.Add("Megaviento furioso");
                    MecanicaES.Add("Misión");
                    MecanicaES.Add("Provocar");
                    MecanicaES.Add("Recluta");
                    MecanicaES.Add("Renacer");
                    MecanicaES.Add("Robo de vida");
                    MecanicaES.Add("Secreto");
                    MecanicaES.Add("Sigilo");
                    MecanicaES.Add("Silencio");
                    MecanicaES.Add("Sobrecarga");
                    MecanicaES.Add("Ultimo aliento");
                    MecanicaES.Add("Veneno");
                    MecanicaES.Add("Viento furioso");
                
                    return MecanicaES;
                }
                else
                {
                    MecanicaLA = new ObservableCollection<string>();
                    MecanicaLA.Add("Cualquiera");
                    MecanicaLA.Add("Adapta");
                    MecanicaLA.Add("Arrasar");
                    MecanicaLA.Add("Carga");
                    MecanicaLA.Add("Combo");
                    MecanicaLA.Add("Congelar");
                    MecanicaLA.Add("Contraarrestar");
                    MecanicaLA.Add("Convocar");
                    MecanicaLA.Add("Daño de hechizo");
                    MecanicaLA.Add("Develar");
                    MecanicaLA.Add("Eco");
                    MecanicaLA.Add("Acometida");
                    MecanicaLA.Add("Escudo divino");
                    MecanicaLA.Add("Grito de batalla");
                    MecanicaLA.Add("Hechizo doble");
                    MecanicaLA.Add("Inmune");
                    MecanicaLA.Add("Inspirar");
                    MecanicaLA.Add("Lacayo");
                    MecanicaLA.Add("Magnetismo");
                    MecanicaLA.Add("Megaviento furioso");
                    MecanicaLA.Add("Misión");
                    MecanicaLA.Add("Provocación");
                    MecanicaLA.Add("Recluta");
                    MecanicaLA.Add("Renacer");
                    MecanicaLA.Add("Robavida");
                    MecanicaLA.Add("Secreto");
                    MecanicaLA.Add("Sigilo");
                    MecanicaLA.Add("Silenciar");
                    MecanicaLA.Add("Sobrecarga");
                    MecanicaLA.Add("Estertor");
                    MecanicaLA.Add("Venenoso");
                    MecanicaLA.Add("Viento furioso");
                
                    return MecanicaLA;
                }
            
        }

        public static ObservableCollection<string> SelectorVariado(string tipoSelector)
        {
            if (tipoSelector == "tipo")
            {
                TipoBI = new ObservableCollection<string>();
                TipoBI.Add("Cualquiera");
                TipoBI.Add("Heroe");
                TipoBI.Add("Esbirro");
                TipoBI.Add("Hechizo");
                TipoBI.Add("Arma");

                return TipoBI;
            }
            else if (tipoSelector == "rareza")
            {
                RarezaBI= new ObservableCollection<string>();
                RarezaBI.Add("Cualquiera");
                RarezaBI.Add("Legendaria");
                RarezaBI.Add("Épica");
                RarezaBI.Add("Rara");
                RarezaBI.Add("Común");
                RarezaBI.Add("Básica");

                return RarezaBI;
            }
            else
            {
                TipoEsbirroBI= new ObservableCollection<string>();
                TipoEsbirroBI.Add("Cualquiera");
                TipoEsbirroBI.Add("Bestia");
                TipoEsbirroBI.Add("Demonio");
                TipoEsbirroBI.Add("Dragón");
                TipoEsbirroBI.Add("Elemental");
                TipoEsbirroBI.Add("Meca");
                TipoEsbirroBI.Add("Múrloc");
                TipoEsbirroBI.Add("Pirata");
                TipoEsbirroBI.Add("Tótem");
                TipoEsbirroBI.Add("Todas");

                return TipoEsbirroBI;
            }

        }

        public static Dictionary<int, string> TipoIN = new Dictionary<int, string>();
        public static Dictionary<int, string> RarezaIN = new Dictionary<int, string>();
        public static Dictionary<int, string> MecanicaIN = new Dictionary<int, string>();
        public static Dictionary<int, string> TipoEsbirroIN = new Dictionary<int, string>();

        public static Dictionary<int, string> TipoINSelector()
        {
            TipoIN = new Dictionary<int, string>();
            TipoIN.Add(-1,"");
            TipoIN.Add(0,"");
            TipoIN.Add(1, "hero");
            TipoIN.Add(2, "minion");
            TipoIN.Add(3, "spell");
            TipoIN.Add(4, "weapon");

            return TipoIN;
        }

        public static Dictionary<int, string> RarezaINSelector()
        {
            RarezaIN = new Dictionary<int, string>();
            RarezaIN.Add(-1,"");
            RarezaIN.Add(0, "");
            RarezaIN.Add(1, "legendary");
            RarezaIN.Add(2, "epic");
            RarezaIN.Add(3, "rare");
            RarezaIN.Add(4, "common");
            RarezaIN.Add(5, "free");

            return RarezaIN;
        }

        public static Dictionary<int, string> TipoEsbirroINSelector()
        {
            TipoEsbirroIN = new Dictionary<int, string>();
            TipoEsbirroIN.Add(-1,"");
            TipoEsbirroIN.Add(0,"");
            TipoEsbirroIN.Add(1, "beast");
            TipoEsbirroIN.Add(2,"demon");
            TipoEsbirroIN.Add(3, "dragon");
            TipoEsbirroIN.Add(4, "elemental");
            TipoEsbirroIN.Add(5, "mech");
            TipoEsbirroIN.Add(6, "murloc");
            TipoEsbirroIN.Add(7, "pirate");
            TipoEsbirroIN.Add(8, "totem");
            TipoEsbirroIN.Add(9, "all");

            return TipoEsbirroIN;
        }

        public static Dictionary<int, string> MecanicaINSelector()
        {
            MecanicaIN = new Dictionary<int, string>();
            MecanicaIN.Add(-1,"");
            MecanicaIN.Add(0,"");
            MecanicaIN.Add(1,"adapt");
            MecanicaIN.Add(2,"overkill");
            MecanicaIN.Add(3,"charge");
            MecanicaIN.Add(4,"combo");
            MecanicaIN.Add(5,"freeze");
            MecanicaIN.Add(6,"counter");
            MecanicaIN.Add(7,"invoke");
            MecanicaIN.Add(8,"spell damage");
            MecanicaIN.Add(9,"discover");
            MecanicaIN.Add(10,"echo");
            MecanicaIN.Add(11,"rush");
            MecanicaIN.Add(12,"divine shield");
            MecanicaIN.Add(13,"battlecry");
            MecanicaIN.Add(14,"twinspell");
            MecanicaIN.Add(15,"immune");
            MecanicaIN.Add(16,"inspire");
            MecanicaIN.Add(17,"lackey");
            MecanicaIN.Add(18,"magnetic");
            MecanicaIN.Add(19,"mega-windfury");
            MecanicaIN.Add(20,"quest");
            MecanicaIN.Add(21,"taunt");
            MecanicaIN.Add(22,"recruit");
            MecanicaIN.Add(23,"reborn");
            MecanicaIN.Add(24,"lifesteal");
            MecanicaIN.Add(25,"secret");
            MecanicaIN.Add(26,"stealth");
            MecanicaIN.Add(27,"silence");
            MecanicaIN.Add(28,"overload");
            MecanicaIN.Add(29,"deathrattle");
            MecanicaIN.Add(30,"poisonous");
            MecanicaIN.Add(31,"windfury");

            return MecanicaIN;
        }                  

    }
}
