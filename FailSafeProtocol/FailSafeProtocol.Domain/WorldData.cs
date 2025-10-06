namespace FailSafeProtocol.Domain;

using System;
using System.Collections.Generic;
using System.Linq;

public enum DirectionType
{
    A,
    B,
    C,
    D
}

public enum Country
{
    // A
    UnitedStates, Canada, Bahamas, Barbados, Jamaica, TrinidadAndTobago,
    Mexico, Guatemala, Honduras, ElSalvador, Nicaragua, CostaRica, Panama,
    Cuba, DominicanRepublic, PuertoRico,

    // B
    UnitedKingdom, Ireland, Norway, Sweden, Finland, Denmark, Iceland,
    Netherlands, Belgium, Germany, Poland, Czechia, Slovakia,
    Estonia, Latvia, Lithuania, Russia, Belarus, Ukraine, Kazakhstan,

    // C
    Colombia, Venezuela, Ecuador, Peru, Bolivia, Chile, Argentina, Uruguay, Paraguay, Brazil,
    Guyana, Suriname, FrenchGuiana,

    // D (≤ 20)
    India, Pakistan, Bangladesh, SriLanka, Nepal, Myanmar, Thailand, Vietnam, Malaysia,
    Indonesia, Philippines, SaudiArabia, Iran, Iraq, Egypt, Nigeria, Ethiopia, Kenya,
    Australia, NewZealand
}

// Cities (only those referenced; all ≥ 100k)
public enum City
{
    // UnitedStates
    NewYork, LosAngeles, Chicago, Houston, Phoenix, Philadelphia, SanAntonio, SanDiego, Dallas,
    // Canada
    Toronto, Montreal, Vancouver, Calgary, Edmonton, Ottawa,
    // Bahamas
    Nassau,
    // Barbados
    Bridgetown,
    // Jamaica
    Kingston, SpanishTown, Portmore,
    // TrinidadAndTobago
    Chaguanas,

    // UnitedKingdom
    London, BirminghamUK, ManchesterUK, Glasgow, Leeds, Liverpool,
    // Ireland
    Dublin, Cork, Limerick,
    // Norway
    Oslo, Bergen, Stavanger,
    // Sweden
    Stockholm, Gothenburg, Malmo,
    // Finland
    Helsinki, Espoo, Tampere,
    // Denmark
    Copenhagen, Aarhus, Odense,
    // Iceland
    Reykjavik,
    // Netherlands
    Amsterdam, Rotterdam, TheHague, Utrecht, Eindhoven,
    // Belgium
    Brussels, Antwerp, Ghent, Charleroi,
    // Germany
    Berlin, Hamburg, Munich, Cologne, Frankfurt, Stuttgart, Dusseldorf, Dortmund, Essen, Bremen, Dresden, Leipzig, Hanover,
    // Poland
    Warsaw, Krakow, Lodz, Wroclaw, Poznan, Gdansk,
    // Czechia
    Prague, Brno, Ostrava,
    // Slovakia
    Bratislava, Kosice,
    // Estonia
    Tallinn, Tartu,
    // Latvia
    Riga,
    // Lithuania
    Vilnius, Kaunas,
    // Russia
    Moscow, SaintPetersburg, Novosibirsk, Yekaterinburg, NizhnyNovgorod, Kazan, Chelyabinsk, Omsk, Samara, RostovOnDon, Ufa, Krasnoyarsk, Perm, Voronezh, Volgograd,
    // Belarus
    Minsk, Gomel, Mogilev,
    // Ukraine
    Kyiv, Kharkiv, Odesa, Dnipro, Lviv, Zaporizhzhia,
    // Kazakhstan
    Almaty, Astana, Shymkent, Karaganda,

    // Mexico
    MexicoCity, Guadalajara, Monterrey, Puebla, Tijuana, Leon,
    // Guatemala
    GuatemalaCity, Mixco, VillaNueva,
    // Honduras
    Tegucigalpa, SanPedroSula, Choloma,
    // ElSalvador
    SanSalvador, Soyapango, SantaAnaSV,
    // Nicaragua
    Managua, LeonNI, Matagalpa,
    // CostaRica
    SanJoseCR, Alajuela, Heredia,
    // Panama
    PanamaCity, SanMiguelito,
    // Cuba
    Havana, SantiagoDeCuba, Camaguey, Holguin,
    // DominicanRepublic
    SantoDomingo, SantiagoDeLosCaballeros, SanCristobalDO,
    // PuertoRico
    SanJuanPR, Bayamon, CarolinaPR,
    // Colombia
    Bogota, Medellin, Cali, Barranquilla, Cartagena,
    // Venezuela
    Caracas, Maracaibo, ValenciaVE, Barquisimeto,
    // Ecuador
    Guayaquil, Quito, Cuenca,
    // Peru
    Lima, Arequipa, Trujillo,
    // Bolivia
    SantaCruz, ElAlto, LaPaz,
    // Chile
    Santiago, PuenteAlto, Antofagasta, VinaDelMar, Valparaiso,
    // Argentina
    BuenosAires, Cordoba, Rosario, Mendoza, LaPlata, MarDelPlata,
    // Uruguay
    Montevideo, Salto, Paysandu, LasPiedras,
    // Paraguay
    Asuncion, CiudadDelEste, SanLorenzo,
    // Brazil
    SaoPaulo, RioDeJaneiro, Brasilia, Salvador, Fortaleza, BeloHorizonte, Manaus, Curitiba, Recife, PortoAlegre,
    // Guyana
    Georgetown,
    // Suriname
    Paramaribo,
    // FrenchGuiana
    Cayenne,

    // India
    Delhi, Mumbai, Bangalore, Hyderabad, Ahmedabad, Chennai, Kolkata, Surat, Pune, Jaipur,
    // Pakistan
    Karachi, Lahore, Faisalabad, Rawalpindi, Multan,
    // Bangladesh
    Dhaka, Chittagong, Khulna,
    // SriLanka
    Colombo, Dehiwala, Moratuwa,
    // Nepal
    Kathmandu, Pokhara,
    // Myanmar
    Yangon, Mandalay,
    // Thailand
    Bangkok, NakhonRatchasima, Nonthaburi,
    // Vietnam
    HoChiMinhCity, Hanoi, HaiPhong, DaNang,
    // Malaysia
    KualaLumpur, Klang, JohorBahru,
    // Indonesia
    Jakarta, Surabaya, Bandung, Bekasi, Medan, Tangerang, Depok, Semarang, Palembang, Makassar,
    // Philippines
    QuezonCity, Manila, DavaoCity, Caloocan, CebuCity, ZamboangaCity,
    // SaudiArabia
    Riyadh, Jeddah, Mecca, Medina, Dammam,
    // Iran
    Tehran, Mashhad, Isfahan, Karaj, Shiraz, Tabriz,
    // Iraq
    Baghdad, Basra, Mosul, Erbil,
    // Egypt
    Cairo, Giza, Alexandria, ShubraElKheima, PortSaid, Suez,
    // Nigeria
    Lagos, Kano, Ibadan, BeninCity, PortHarcourt, Kaduna, Maiduguri, Aba,
    // Ethiopia
    AddisAbaba, DireDawa, Mekelle,
    // Kenya
    Nairobi, Mombasa, Nakuru,
    // Australia
    Sydney, Melbourne, Brisbane, Perth, Adelaide,
    // NewZealand
    Auckland, Wellington, Christchurch
}

// Simple API surface
public static class WorldData
{
    // Direction → Countries
    private static readonly IReadOnlyDictionary<DirectionType, Country[]> DirectionToCountries =
    new Dictionary<DirectionType, Country[]>
    {
        // A: all modeled countries (includes Central America)
        { DirectionType.A, Enum.GetValues(typeof(Country)).Cast<Country>().ToArray() },

        // B: Northern Eurasia (≤ 20)
        { DirectionType.B, new[]
            {
                Country.UnitedKingdom, Country.Ireland, Country.Norway, Country.Sweden, Country.Finland,
                Country.Denmark, Country.Iceland, Country.Netherlands, Country.Belgium, Country.Germany,
                Country.Poland, Country.Czechia, Country.Slovakia, Country.Estonia, Country.Latvia,
                Country.Lithuania, Country.Russia, Country.Belarus, Country.Ukraine, Country.Kazakhstan
            }
        },

        // C: Latin America (without Central America)
        { DirectionType.C, new[]
            {
                Country.Mexico,
                Country.Cuba, Country.DominicanRepublic, Country.PuertoRico,
                Country.Colombia, Country.Venezuela, Country.Ecuador, Country.Peru, Country.Bolivia,
                Country.Chile, Country.Argentina, Country.Uruguay, Country.Paraguay, Country.Brazil,
                Country.Guyana, Country.Suriname, Country.FrenchGuiana
            }
        },

        // D: Southern Eurasia, Africa, Oceania (≤ 20)
        { DirectionType.D, new[]
            {
                Country.India, Country.Pakistan, Country.Bangladesh, Country.SriLanka, Country.Nepal,
                Country.Myanmar, Country.Thailand, Country.Vietnam, Country.Malaysia, Country.Indonesia,
                Country.Philippines, Country.SaudiArabia, Country.Iran, Country.Iraq, Country.Egypt,
                Country.Nigeria, Country.Ethiopia, Country.Kenya, Country.Australia, Country.NewZealand
            }
        }
    };

    // Country → Cities
    private static readonly IReadOnlyDictionary<Country, City[]> CountryToCities =
        new Dictionary<Country, City[]>
        {
            // A
            { Country.UnitedStates, new[] { City.NewYork, City.LosAngeles, City.Chicago, City.Houston, City.Phoenix, City.Philadelphia, City.SanAntonio, City.SanDiego, City.Dallas } },
            { Country.Canada,       new[] { City.Toronto, City.Montreal, City.Vancouver, City.Calgary, City.Edmonton, City.Ottawa } },
            { Country.Bahamas,      new[] { City.Nassau } },
            { Country.Barbados,     new[] { City.Bridgetown } },
            { Country.Jamaica,      new[] { City.Kingston, City.SpanishTown, City.Portmore } },
            { Country.TrinidadAndTobago, new[] { City.Chaguanas } },

            // B
            { Country.UnitedKingdom, new[] { City.London, City.BirminghamUK, City.ManchesterUK, City.Glasgow, City.Leeds, City.Liverpool } },
            { Country.Ireland,       new[] { City.Dublin, City.Cork, City.Limerick } },
            { Country.Norway,        new[] { City.Oslo, City.Bergen, City.Stavanger } },
            { Country.Sweden,        new[] { City.Stockholm, City.Gothenburg, City.Malmo } },
            { Country.Finland,       new[] { City.Helsinki, City.Espoo, City.Tampere } },
            { Country.Denmark,       new[] { City.Copenhagen, City.Aarhus, City.Odense } },
            { Country.Iceland,       new[] { City.Reykjavik } },
            { Country.Netherlands,   new[] { City.Amsterdam, City.Rotterdam, City.TheHague, City.Utrecht, City.Eindhoven } },
            { Country.Belgium,       new[] { City.Brussels, City.Antwerp, City.Ghent, City.Charleroi } },
            { Country.Germany,       new[] { City.Berlin, City.Hamburg, City.Munich, City.Cologne, City.Frankfurt, City.Stuttgart, City.Dusseldorf, City.Dortmund, City.Essen, City.Bremen, City.Dresden, City.Leipzig, City.Hanover } },
            { Country.Poland,        new[] { City.Warsaw, City.Krakow, City.Lodz, City.Wroclaw, City.Poznan, City.Gdansk } },
            { Country.Czechia,       new[] { City.Prague, City.Brno, City.Ostrava } },
            { Country.Slovakia,      new[] { City.Bratislava, City.Kosice } },
            { Country.Estonia,       new[] { City.Tallinn, City.Tartu } },
            { Country.Latvia,        new[] { City.Riga } },
            { Country.Lithuania,     new[] { City.Vilnius, City.Kaunas } },
            { Country.Russia,        new[] { City.Moscow, City.SaintPetersburg, City.Novosibirsk, City.Yekaterinburg, City.NizhnyNovgorod, City.Kazan, City.Chelyabinsk, City.Omsk, City.Samara, City.RostovOnDon, City.Ufa, City.Krasnoyarsk, City.Perm, City.Voronezh, City.Volgograd } },
            { Country.Belarus,       new[] { City.Minsk, City.Gomel, City.Mogilev } },
            { Country.Ukraine,       new[] { City.Kyiv, City.Kharkiv, City.Odesa, City.Dnipro, City.Lviv, City.Zaporizhzhia } },
            { Country.Kazakhstan,    new[] { City.Almaty, City.Astana, City.Shymkent, City.Karaganda } },

            // C
            { Country.Mexico,        new[] { City.MexicoCity, City.Guadalajara, City.Monterrey, City.Puebla, City.Tijuana, City.Leon } },
            { Country.Guatemala,     new[] { City.GuatemalaCity, City.Mixco, City.VillaNueva } },
            { Country.Honduras,      new[] { City.Tegucigalpa, City.SanPedroSula, City.Choloma } },
            { Country.ElSalvador,    new[] { City.SanSalvador, City.Soyapango, City.SantaAnaSV } },
            { Country.Nicaragua,     new[] { City.Managua, City.LeonNI, City.Matagalpa } },
            { Country.CostaRica,     new[] { City.SanJoseCR, City.Alajuela, City.Heredia } },
            { Country.Panama,        new[] { City.PanamaCity, City.SanMiguelito } },
            { Country.Cuba,          new[] { City.Havana, City.SantiagoDeCuba, City.Camaguey, City.Holguin } },
            { Country.DominicanRepublic, new[] { City.SantoDomingo, City.SantiagoDeLosCaballeros, City.SanCristobalDO } },
            { Country.PuertoRico,    new[] { City.SanJuanPR, City.Bayamon, City.CarolinaPR } },
            { Country.Colombia,      new[] { City.Bogota, City.Medellin, City.Cali, City.Barranquilla, City.Cartagena } },
            { Country.Venezuela,     new[] { City.Caracas, City.Maracaibo, City.ValenciaVE, City.Barquisimeto } },
            { Country.Ecuador,       new[] { City.Guayaquil, City.Quito, City.Cuenca } },
            { Country.Peru,          new[] { City.Lima, City.Arequipa, City.Trujillo } },
            { Country.Bolivia,       new[] { City.SantaCruz, City.ElAlto, City.LaPaz } },
            { Country.Chile,         new[] { City.Santiago, City.PuenteAlto, City.Antofagasta, City.VinaDelMar, City.Valparaiso } },
            { Country.Argentina,     new[] { City.BuenosAires, City.Cordoba, City.Rosario, City.Mendoza, City.LaPlata, City.MarDelPlata } },
            { Country.Uruguay,       new[] { City.Montevideo, City.Salto, City.Paysandu, City.LasPiedras } },
            { Country.Paraguay,      new[] { City.Asuncion, City.CiudadDelEste, City.SanLorenzo } },
            { Country.Brazil,        new[] { City.SaoPaulo, City.RioDeJaneiro, City.Brasilia, City.Salvador, City.Fortaleza, City.BeloHorizonte, City.Manaus, City.Curitiba, City.Recife, City.PortoAlegre } },
            { Country.Guyana,        new[] { City.Georgetown } },
            { Country.Suriname,      new[] { City.Paramaribo } },
            { Country.FrenchGuiana,  new[] { City.Cayenne } },

            // D
            { Country.India,         new[] { City.Delhi, City.Mumbai, City.Bangalore, City.Hyderabad, City.Ahmedabad, City.Chennai, City.Kolkata, City.Surat, City.Pune, City.Jaipur } },
            { Country.Pakistan,      new[] { City.Karachi, City.Lahore, City.Faisalabad, City.Rawalpindi, City.Multan } },
            { Country.Bangladesh,    new[] { City.Dhaka, City.Chittagong, City.Khulna } },
            { Country.SriLanka,      new[] { City.Colombo, City.Dehiwala, City.Moratuwa } },
            { Country.Nepal,         new[] { City.Kathmandu, City.Pokhara } },
            { Country.Myanmar,       new[] { City.Yangon, City.Mandalay } },
            { Country.Thailand,      new[] { City.Bangkok, City.NakhonRatchasima, City.Nonthaburi } },
            { Country.Vietnam,       new[] { City.HoChiMinhCity, City.Hanoi, City.HaiPhong, City.DaNang } },
            { Country.Malaysia,      new[] { City.KualaLumpur, City.Klang, City.JohorBahru } },
            { Country.Indonesia,     new[] { City.Jakarta, City.Surabaya, City.Bandung, City.Bekasi, City.Medan, City.Tangerang, City.Depok, City.Semarang, City.Palembang, City.Makassar } },
            { Country.Philippines,   new[] { City.QuezonCity, City.Manila, City.DavaoCity, City.Caloocan, City.CebuCity, City.ZamboangaCity } },
            { Country.SaudiArabia,   new[] { City.Riyadh, City.Jeddah, City.Mecca, City.Medina, City.Dammam } },
            { Country.Iran,          new[] { City.Tehran, City.Mashhad, City.Isfahan, City.Karaj, City.Shiraz, City.Tabriz } },
            { Country.Iraq,          new[] { City.Baghdad, City.Basra, City.Mosul, City.Erbil } },
            { Country.Egypt,         new[] { City.Cairo, City.Giza, City.Alexandria, City.ShubraElKheima, City.PortSaid, City.Suez } },
            { Country.Nigeria,       new[] { City.Lagos, City.Kano, City.Ibadan, City.BeninCity, City.PortHarcourt, City.Kaduna, City.Maiduguri, City.Aba } },
            { Country.Ethiopia,      new[] { City.AddisAbaba, City.DireDawa, City.Mekelle } },
            { Country.Kenya,         new[] { City.Nairobi, City.Mombasa, City.Nakuru } },
            { Country.Australia,     new[] { City.Sydney, City.Melbourne, City.Brisbane, City.Perth, City.Adelaide } },
            { Country.NewZealand,    new[] { City.Auckland, City.Wellington, City.Christchurch } }
        };

    // City → Population (approx.)
    private static readonly IReadOnlyDictionary<City, int> CityPopulation =
        new Dictionary<City, int>
        {
            // US / CA
            { City.NewYork, 8400000 }, { City.LosAngeles, 4000000 }, { City.Chicago, 2700000 }, { City.Houston, 2300000 }, { City.Phoenix, 1700000 },
            { City.Philadelphia, 1600000 }, { City.SanAntonio, 1500000 }, { City.SanDiego, 1400000 }, { City.Dallas, 1300000 },
            { City.Toronto, 2800000 }, { City.Montreal, 1700000 }, { City.Vancouver, 675000 }, { City.Calgary, 1300000 }, { City.Edmonton, 1000000 }, { City.Ottawa, 1000000 },
            { City.Nassau, 275000 }, { City.Bridgetown, 110000 }, { City.Kingston, 670000 }, { City.SpanishTown, 160000 }, { City.Portmore, 185000 }, { City.Chaguanas, 100000 },

            // B
            { City.London, 8900000 }, { City.BirminghamUK, 1100000 }, { City.ManchesterUK, 550000 }, { City.Glasgow, 630000 }, { City.Leeds, 800000 }, { City.Liverpool, 500000 },
            { City.Dublin, 600000 }, { City.Cork, 210000 }, { City.Limerick, 100000 },
            { City.Oslo, 700000 }, { City.Bergen, 285000 }, { City.Stavanger, 240000 },
            { City.Stockholm, 975000 }, { City.Gothenburg, 580000 }, { City.Malmo, 350000 },
            { City.Helsinki, 650000 }, { City.Espoo, 300000 }, { City.Tampere, 240000 },
            { City.Copenhagen, 650000 }, { City.Aarhus, 280000 }, { City.Odense, 180000 },
            { City.Reykjavik, 135000 },
            { City.Amsterdam, 820000 }, { City.Rotterdam, 650000 }, { City.TheHague, 550000 }, { City.Utrecht, 360000 }, { City.Eindhoven, 240000 },
            { City.Brussels, 1200000 }, { City.Antwerp, 520000 }, { City.Ghent, 260000 }, { City.Charleroi, 200000 },
            { City.Berlin, 3700000 }, { City.Hamburg, 1800000 }, { City.Munich, 1500000 }, { City.Cologne, 1100000 }, { City.Frankfurt, 760000 }, { City.Stuttgart, 630000 },
            { City.Dusseldorf, 620000 }, { City.Dortmund, 590000 }, { City.Essen, 580000 }, { City.Bremen, 560000 }, { City.Dresden, 560000 }, { City.Leipzig, 610000 }, { City.Hanover, 540000 },
            { City.Warsaw, 1800000 }, { City.Krakow, 780000 }, { City.Lodz, 670000 }, { City.Wroclaw, 640000 }, { City.Poznan, 540000 }, { City.Gdansk, 470000 },
            { City.Prague, 1300000 }, { City.Brno, 380000 }, { City.Ostrava, 280000 },
            { City.Bratislava, 440000 }, { City.Kosice, 240000 },
            { City.Tallinn, 440000 }, { City.Tartu, 100000 },
            { City.Riga, 630000 },
            { City.Vilnius, 600000 }, { City.Kaunas, 300000 },
            { City.Moscow, 12000000 }, { City.SaintPetersburg, 5400000 }, { City.Novosibirsk, 1600000 }, { City.Yekaterinburg, 1500000 }, { City.NizhnyNovgorod, 1200000 },
            { City.Kazan, 1250000 }, { City.Chelyabinsk, 1200000 }, { City.Omsk, 1200000 }, { City.Samara, 1150000 }, { City.RostovOnDon, 1100000 }, { City.Ufa, 1100000 },
            { City.Krasnoyarsk, 1100000 }, { City.Perm, 1000000 }, { City.Voronezh, 1050000 }, { City.Volgograd, 1000000 },
            { City.Minsk, 2000000 }, { City.Gomel, 500000 }, { City.Mogilev, 350000 },
            { City.Kyiv, 2800000 }, { City.Kharkiv, 1400000 }, { City.Odesa, 1000000 }, { City.Dnipro, 1000000 }, { City.Lviv, 720000 }, { City.Zaporizhzhia, 730000 },
            { City.Almaty, 2000000 }, { City.Astana, 1200000 }, { City.Shymkent, 1100000 }, { City.Karaganda, 500000 },

            // C
            { City.MexicoCity, 9200000 }, { City.Guadalajara, 1500000 }, { City.Monterrey, 1100000 }, { City.Puebla, 1500000 }, { City.Tijuana, 1800000 }, { City.Leon, 1500000 },
            { City.GuatemalaCity, 1000000 }, { City.Mixco, 500000 }, { City.VillaNueva, 500000 },
            { City.Tegucigalpa, 1200000 }, { City.SanPedroSula, 750000 }, { City.Choloma, 250000 },
            { City.SanSalvador, 570000 }, { City.Soyapango, 250000 }, { City.SantaAnaSV, 250000 },
            { City.Managua, 1000000 }, { City.LeonNI, 200000 }, { City.Matagalpa, 150000 },
            { City.SanJoseCR, 340000 }, { City.Alajuela, 300000 }, { City.Heredia, 120000 },
            { City.PanamaCity, 880000 }, { City.SanMiguelito, 375000 },
            { City.Havana, 2100000 }, { City.SantiagoDeCuba, 430000 }, { City.Camaguey, 320000 }, { City.Holguin, 350000 },
            { City.SantoDomingo, 3000000 }, { City.SantiagoDeLosCaballeros, 550000 }, { City.SanCristobalDO, 275000 },
            { City.SanJuanPR, 320000 }, { City.Bayamon, 200000 }, { City.CarolinaPR, 175000 },
            { City.Bogota, 7700000 }, { City.Medellin, 2500000 }, { City.Cali, 2200000 }, { City.Barranquilla, 1200000 }, { City.Cartagena, 1000000 },
            { City.Caracas, 2000000 }, { City.Maracaibo, 1500000 }, { City.ValenciaVE, 830000 }, { City.Barquisimeto, 800000 },
            { City.Guayaquil, 2700000 }, { City.Quito, 2000000 }, { City.Cuenca, 600000 },
            { City.Lima, 9500000 }, { City.Arequipa, 1000000 }, { City.Trujillo, 1100000 },
            { City.SantaCruz, 1800000 }, { City.ElAlto, 1000000 }, { City.LaPaz, 800000 },
            { City.Santiago, 5600000 }, { City.PuenteAlto, 700000 }, { City.Antofagasta, 400000 }, { City.VinaDelMar, 330000 }, { City.Valparaiso, 300000 },
            { City.BuenosAires, 3000000 }, { City.Cordoba, 1300000 }, { City.Rosario, 1200000 }, { City.Mendoza, 1100000 }, { City.LaPlata, 800000 }, { City.MarDelPlata, 600000 },
            { City.Montevideo, 1400000 }, { City.Salto, 130000 }, { City.Paysandu, 120000 }, { City.LasPiedras, 120000 },
            { City.Asuncion, 520000 }, { City.CiudadDelEste, 300000 }, { City.SanLorenzo, 250000 },
            { City.SaoPaulo, 12300000 }, { City.RioDeJaneiro, 6700000 }, { City.Brasilia, 3100000 }, { City.Salvador, 2900000 }, { City.Fortaleza, 2600000 }, { City.BeloHorizonte, 2500000 },
            { City.Manaus, 2200000 }, { City.Curitiba, 1900000 }, { City.Recife, 1600000 }, { City.PortoAlegre, 1500000 },
            { City.Georgetown, 118000 }, { City.Paramaribo, 240000 }, { City.Cayenne, 150000 },

            // D
            { City.Delhi, 19000000 }, { City.Mumbai, 12400000 }, { City.Bangalore, 8400000 }, { City.Hyderabad, 6800000 }, { City.Ahmedabad, 5600000 }, { City.Chennai, 7100000 },
            { City.Kolkata, 4500000 }, { City.Surat, 4700000 }, { City.Pune, 3100000 }, { City.Jaipur, 3000000 },
            { City.Karachi, 15000000 }, { City.Lahore, 11000000 }, { City.Faisalabad, 3800000 }, { City.Rawalpindi, 2100000 }, { City.Multan, 1900000 },
            { City.Dhaka, 8900000 }, { City.Chittagong, 2600000 }, { City.Khulna, 660000 },
            { City.Colombo, 560000 }, { City.Dehiwala, 200000 }, { City.Moratuwa, 170000 },
            { City.Kathmandu, 1400000 }, { City.Pokhara, 420000 },
            { City.Yangon, 5200000 }, { City.Mandalay, 1200000 },
            { City.Bangkok, 5800000 }, { City.NakhonRatchasima, 250000 }, { City.Nonthaburi, 250000 },
            { City.HoChiMinhCity, 9000000 }, { City.Hanoi, 8000000 }, { City.HaiPhong, 2000000 }, { City.DaNang, 1200000 },
            { City.KualaLumpur, 1800000 }, { City.Klang, 250000 }, { City.JohorBahru, 500000 },
            { City.Jakarta, 10000000 }, { City.Surabaya, 2800000 }, { City.Bandung, 2300000 }, { City.Bekasi, 2600000 }, { City.Medan, 2300000 }, { City.Tangerang, 2200000 }, { City.Depok, 2000000 }, { City.Semarang, 1700000 }, { City.Palembang, 1600000 }, { City.Makassar, 1400000 },
            { City.QuezonCity, 2900000 }, { City.Manila, 1850000 }, { City.DavaoCity, 1700000 }, { City.Caloocan, 1600000 }, { City.CebuCity, 1000000 }, { City.ZamboangaCity, 900000 },
            { City.Riyadh, 7700000 }, { City.Jeddah, 4300000 }, { City.Mecca, 2000000 }, { City.Medina, 1300000 }, { City.Dammam, 1200000 },
            { City.Tehran, 8800000 }, { City.Mashhad, 3000000 }, { City.Isfahan, 2000000 }, { City.Karaj, 2000000 }, { City.Shiraz, 1500000 }, { City.Tabriz, 1600000 },
            { City.Baghdad, 8000000 }, { City.Basra, 2600000 }, { City.Mosul, 1800000 }, { City.Erbil, 1200000 },
            { City.Cairo, 10000000 }, { City.Giza, 8800000 }, { City.Alexandria, 5200000 }, { City.ShubraElKheima, 1100000 }, { City.PortSaid, 760000 }, { City.Suez, 740000 },
            { City.Lagos, 14000000 }, { City.Kano, 3000000 }, { City.Ibadan, 3000000 }, { City.BeninCity, 1500000 }, { City.PortHarcourt, 1000000 }, { City.Kaduna, 1500000 }, { City.Maiduguri, 1000000 }, { City.Aba, 500000 },
            { City.AddisAbaba, 4700000 }, { City.DireDawa, 500000 }, { City.Mekelle, 500000 },
            { City.Nairobi, 4400000 }, { City.Mombasa, 1200000 }, { City.Nakuru, 600000 },
            { City.Sydney, 5300000 }, { City.Melbourne, 5200000 }, { City.Brisbane, 2500000 }, { City.Perth, 2100000 }, { City.Adelaide, 1400000 },
            { City.Auckland, 1700000 }, { City.Wellington, 220000 }, { City.Christchurch, 380000 }
        };

        private static readonly System.Collections.Generic.IReadOnlyDictionary<City, long> CityAreaSquareMeters =
    new System.Collections.Generic.Dictionary<City, long>
    {
        // US / CA
        { City.NewYork, 783_800_000L }, { City.LosAngeles, 1_302_000_000L }, { City.Chicago, 606_000_000L }, { City.Houston, 1_651_000_000L }, { City.Phoenix, 1_338_000_000L },
        { City.Philadelphia, 369_000_000L }, { City.SanAntonio, 1_307_000_000L }, { City.SanDiego, 964_000_000L }, { City.Dallas, 997_000_000L },
        { City.Toronto, 630_200_000L }, { City.Montreal, 431_500_000L }, { City.Vancouver, 115_000_000L }, { City.Calgary, 825_000_000L }, { City.Edmonton, 684_000_000L }, { City.Ottawa, 2_790_000_000L },
        { City.Nassau, 207_000_000L }, { City.Bridgetown, 40_000_000L }, { City.Kingston, 480_000_000L }, { City.SpanishTown, 15_000_000L }, { City.Portmore, 51_000_000L }, { City.Chaguanas, 59_000_000L },

        // B
        { City.London, 1_572_000_000L }, { City.BirminghamUK, 268_000_000L }, { City.ManchesterUK, 116_000_000L }, { City.Glasgow, 175_000_000L }, { City.Leeds, 552_000_000L }, { City.Liverpool, 112_000_000L },
        { City.Dublin, 118_000_000L }, { City.Cork, 187_000_000L }, { City.Limerick, 60_000_000L },
        { City.Oslo, 454_000_000L }, { City.Bergen, 464_000_000L }, { City.Stavanger, 71_000_000L },
        { City.Stockholm, 188_000_000L }, { City.Gothenburg, 448_000_000L }, { City.Malmo, 158_000_000L },
        { City.Helsinki, 213_000_000L }, { City.Espoo, 528_000_000L }, { City.Tampere, 689_000_000L },
        { City.Copenhagen, 86_000_000L }, { City.Aarhus, 91_000_000L }, { City.Odense, 304_000_000L },
        { City.Reykjavik, 273_000_000L },
        { City.Amsterdam, 219_000_000L }, { City.Rotterdam, 325_000_000L }, { City.TheHague, 98_000_000L }, { City.Utrecht, 99_000_000L }, { City.Eindhoven, 88_000_000L },
        { City.Brussels, 161_000_000L }, { City.Antwerp, 204_000_000L }, { City.Ghent, 157_000_000L }, { City.Charleroi, 102_000_000L },
        { City.Berlin, 891_000_000L }, { City.Hamburg, 755_000_000L }, { City.Munich, 310_000_000L }, { City.Cologne, 405_000_000L }, { City.Frankfurt, 248_000_000L }, { City.Stuttgart, 207_000_000L },
        { City.Dusseldorf, 217_000_000L }, { City.Dortmund, 280_000_000L }, { City.Essen, 210_000_000L }, { City.Bremen, 326_000_000L }, { City.Dresden, 328_000_000L }, { City.Leipzig, 297_000_000L }, { City.Hanover, 204_000_000L },
        { City.Warsaw, 517_000_000L }, { City.Krakow, 327_000_000L }, { City.Lodz, 293_000_000L }, { City.Wroclaw, 293_000_000L }, { City.Poznan, 262_000_000L }, { City.Gdansk, 262_000_000L },
        { City.Prague, 496_000_000L }, { City.Brno, 230_000_000L }, { City.Ostrava, 215_000_000L },
        { City.Bratislava, 367_000_000L }, { City.Kosice, 242_000_000L },
        { City.Tallinn, 159_000_000L }, { City.Tartu, 39_000_000L },
        { City.Riga, 307_000_000L },
        { City.Vilnius, 401_000_000L }, { City.Kaunas, 157_000_000L },
        { City.Moscow, 2_561_000_000L }, { City.SaintPetersburg, 1_439_000_000L }, { City.Novosibirsk, 505_000_000L }, { City.Yekaterinburg, 468_000_000L }, { City.NizhnyNovgorod, 411_000_000L },
        { City.Kazan, 516_000_000L }, { City.Chelyabinsk, 530_000_000L }, { City.Omsk, 572_000_000L }, { City.Samara, 541_000_000L }, { City.RostovOnDon, 348_000_000L }, { City.Ufa, 708_000_000L },
        { City.Krasnoyarsk, 379_000_000L }, { City.Perm, 800_000_000L }, { City.Voronezh, 596_000_000L }, { City.Volgograd, 859_000_000L },
        { City.Minsk, 409_000_000L }, { City.Gomel, 121_000_000L }, { City.Mogilev, 121_000_000L },
        { City.Kyiv, 839_000_000L }, { City.Kharkiv, 350_000_000L }, { City.Odesa, 163_000_000L }, { City.Dnipro, 405_000_000L }, { City.Lviv, 182_000_000L }, { City.Zaporizhzhia, 334_000_000L },
        { City.Almaty, 682_000_000L }, { City.Astana, 722_000_000L }, { City.Shymkent, 1_170_000_000L }, { City.Karaganda, 497_000_000L },

        // C
        { City.MexicoCity, 1_485_000_000L }, { City.Guadalajara, 187_000_000L }, { City.Monterrey, 324_000_000L }, { City.Puebla, 534_000_000L }, { City.Tijuana, 637_000_000L }, { City.Leon, 221_000_000L },
        { City.GuatemalaCity, 692_000_000L }, { City.Mixco, 99_000_000L }, { City.VillaNueva, 114_000_000L },
        { City.Tegucigalpa, 201_000_000L }, { City.SanPedroSula, 123_000_000L }, { City.Choloma, 47_000_000L },
        { City.SanSalvador, 72_000_000L }, { City.Soyapango, 29_000_000L }, { City.SantaAnaSV, 408_000_000L },
        { City.Managua, 267_000_000L }, { City.LeonNI, 820_000_000L }, { City.Matagalpa, 52_000_000L },
        { City.SanJoseCR, 45_000_000L }, { City.Alajuela, 388_000_000L }, { City.Heredia, 10_000_000L },
        { City.PanamaCity, 275_000_000L }, { City.SanMiguelito, 50_000_000L },
        { City.Havana, 728_000_000L }, { City.SantiagoDeCuba, 102_000_000L }, { City.Camaguey, 1_100_000_000L }, { City.Holguin, 655_000_000L },
        { City.SantoDomingo, 104_000_000L }, { City.SantiagoDeLosCaballeros, 76_000_000L }, { City.SanCristobalDO, 126_000_000L },
        { City.SanJuanPR, 199_000_000L }, { City.Bayamon, 115_000_000L }, { City.CarolinaPR, 120_000_000L },
        { City.Bogota, 1_587_000_000L }, { City.Medellin, 382_000_000L }, { City.Cali, 564_000_000L }, { City.Barranquilla, 166_000_000L }, { City.Cartagena, 572_000_000L },
        { City.Caracas, 433_000_000L }, { City.Maracaibo, 557_000_000L }, { City.ValenciaVE, 623_000_000L }, { City.Barquisimeto, 277_000_000L },
        { City.Guayaquil, 345_000_000L }, { City.Quito, 372_000_000L }, { City.Cuenca, 71_000_000L },
        { City.Lima, 2_672_000_000L }, { City.Arequipa, 3_000_000_000L }, { City.Trujillo, 110_000_000L },
        { City.SantaCruz, 535_000_000L }, { City.ElAlto, 118_000_000L }, { City.LaPaz, 472_000_000L },
        { City.Santiago, 641_000_000L }, { City.PuenteAlto, 88_000_000L }, { City.Antofagasta, 307_000_000L }, { City.VinaDelMar, 121_000_000L }, { City.Valparaiso, 401_000_000L },
        { City.BuenosAires, 203_000_000L }, { City.Cordoba, 576_000_000L }, { City.Rosario, 178_000_000L }, { City.Mendoza, 54_000_000L }, { City.LaPlata, 940_000_000L }, { City.MarDelPlata, 79_000_000L },
        { City.Montevideo, 201_000_000L }, { City.Salto, 141_000_000L }, { City.Paysandu, 120_000_000L }, { City.LasPiedras, 12_000_000L },
        { City.Asuncion, 118_000_000L }, { City.CiudadDelEste, 104_000_000L }, { City.SanLorenzo, 74_000_000L },
        { City.SaoPaulo, 1_521_110_000L }, { City.RioDeJaneiro, 1_221_000_000L }, { City.Brasilia, 5_802_000_000L }, { City.Salvador, 693_000_000L }, { City.Fortaleza, 314_000_000L }, { City.BeloHorizonte, 331_000_000L },
        { City.Manaus, 11_401_000_000L }, { City.Curitiba, 435_000_000L }, { City.Recife, 218_000_000L }, { City.PortoAlegre, 496_000_000L },
        { City.Georgetown, 70_000_000L }, { City.Paramaribo, 182_000_000L }, { City.Cayenne, 23_000_000L },

        // D
        { City.Delhi, 1_484_000_000L }, { City.Mumbai, 603_000_000L }, { City.Bangalore, 709_000_000L }, { City.Hyderabad, 625_000_000L }, { City.Ahmedabad, 464_000_000L }, { City.Chennai, 426_000_000L },
        { City.Kolkata, 206_000_000L }, { City.Surat, 326_000_000L }, { City.Pune, 331_000_000L }, { City.Jaipur, 467_000_000L },
        { City.Karachi, 3_780_000_000L }, { City.Lahore, 1_772_000_000L }, { City.Faisalabad, 1_300_000_000L }, { City.Rawalpindi, 259_000_000L }, { City.Multan, 133_000_000L },
        { City.Dhaka, 306_000_000L }, { City.Chittagong, 168_000_000L }, { City.Khulna, 59_000_000L },
        { City.Colombo, 37_000_000L }, { City.Dehiwala, 21_000_000L }, { City.Moratuwa, 23_000_000L },
        { City.Kathmandu, 50_000_000L }, { City.Pokhara, 55_000_000L },
        { City.Yangon, 598_000_000L }, { City.Mandalay, 121_000_000L },
        { City.Bangkok, 1_568_000_000L }, { City.NakhonRatchasima, 756_000_000L }, { City.Nonthaburi, 39_000_000L },
        { City.HoChiMinhCity, 2_095_000_000L }, { City.Hanoi, 3_358_000_000L }, { City.HaiPhong, 152_000_000L }, { City.DaNang, 1_285_000_000L },
        { City.KualaLumpur, 243_000_000L }, { City.Klang, 573_000_000L }, { City.JohorBahru, 220_000_000L },
        { City.Jakarta, 661_000_000L }, { City.Surabaya, 350_000_000L }, { City.Bandung, 167_000_000L }, { City.Bekasi, 206_000_000L }, { City.Medan, 265_000_000L }, { City.Tangerang, 153_000_000L }, { City.Depok, 200_000_000L }, { City.Semarang, 373_000_000L }, { City.Palembang, 369_000_000L }, { City.Makassar, 199_000_000L },
        { City.QuezonCity, 166_000_000L }, { City.Manila, 43_000_000L }, { City.DavaoCity, 2_444_000_000L }, { City.Caloocan, 55_000_000L }, { City.CebuCity, 315_000_000L }, { City.ZamboangaCity, 1_312_000_000L },
        { City.Riyadh, 1_973_000_000L }, { City.Jeddah, 1_600_000_000L }, { City.Mecca, 1_200_000_000L }, { City.Medina, 589_000_000L }, { City.Dammam, 800_000_000L },
        { City.Tehran, 730_000_000L }, { City.Mashhad, 351_000_000L }, { City.Isfahan, 551_000_000L }, { City.Karaj, 163_000_000L }, { City.Shiraz, 240_000_000L }, { City.Tabriz, 243_000_000L },
        { City.Baghdad, 673_000_000L }, { City.Basra, 190_000_000L }, { City.Mosul, 180_000_000L }, { City.Erbil, 120_000_000L },
        { City.Cairo, 606_000_000L }, { City.Giza, 87_000_000L }, { City.Alexandria, 300_000_000L }, { City.ShubraElKheima, 30_000_000L }, { City.PortSaid, 72_000_000L }, { City.Suez, 262_000_000L },
        { City.Lagos, 1_171_000_000L }, { City.Kano, 499_000_000L }, { City.Ibadan, 3_080_000_000L }, { City.BeninCity, 1_204_000_000L }, { City.PortHarcourt, 369_000_000L }, { City.Kaduna, 131_000_000L }, { City.Maiduguri, 137_000_000L }, { City.Aba, 49_000_000L },
        { City.AddisAbaba, 527_000_000L }, { City.DireDawa, 1_213_000_000L }, { City.Mekelle, 24_000_000L },
        { City.Nairobi, 696_000_000L }, { City.Mombasa, 295_000_000L }, { City.Nakuru, 290_000_000L },
        { City.Sydney, 12_367_000_000L }, { City.Melbourne, 9_993_000_000L }, { City.Brisbane, 15_842_000_000L }, { City.Perth, 6_418_000_000L }, { City.Adelaide, 1_827_000_000L },
        { City.Auckland, 1_086_000_000L }, { City.Wellington, 290_000_000L }, { City.Christchurch, 1_426_000_000L }
    };

    /// <summary>
    /// Returns a random country from the given direction.
    /// </summary>
    public static Country PickRandomCountry(DirectionType direction)
    {
        var countries = DirectionToCountries.TryGetValue(direction, out var list)
            ? list
            : Array.Empty<Country>();

        if (countries.Length == 0)
            throw new InvalidOperationException($"No countries configured for direction {direction}.");

        var rng = new Random();
        return countries[rng.Next(countries.Length)];
    }

    /// <summary>
    /// Returns a random country from the given direction.
    /// </summary>
    public static City PickRandomCity(Country country)
    {
        var citys = CountryToCities.TryGetValue(country, out var list)
            ? list
            : Array.Empty<City>();

        if (citys.Length == 0)
            throw new InvalidOperationException($"No citys configured for country {country}.");

        var rng = new Random();
        return citys[rng.Next(citys.Length)];
    }

    internal static IReadOnlyList<City> GetCities(Country country) =>
        CountryToCities.TryGetValue(country, out var cities) ? cities : Array.Empty<City>();

    public static int GetCityPopulation(City city) =>
        CityPopulation.TryGetValue(city, out var pop) ? pop : 0;

    public static long GetCityArea(City city) =>
        CityAreaSquareMeters.TryGetValue(city, out var pop) ? pop : 0;
}

// "Method on Country": implemented as an extension (idiomatic for enums in C#)
public static class CountryExtensions
{
    /// <summary>
    /// Returns the total population (sum of all modeled cities ≥ 100k for this country).
    /// </summary>
    public static int GetTotalPopulation(this Country country)
    {
        var cities = WorldData.GetCities(country);
        return cities.Sum(WorldData.GetCityPopulation);
    }
}
