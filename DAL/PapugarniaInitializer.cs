using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using NuGet.Frameworks;
using PapugarniaOnline.Data;
using PapugarniaOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PapugarniaOnline.DAL
{
    public static class PapugarniaInitializer
    {
        public static void Initialize(PapugarniaOnlineContext context)
            {
            context.Database.EnsureCreated();

            if (context.Parrots.Any())
            {
                return;   // DB has been seeded
            }


            var kop = new KindOfParrot[]
            {
                new KindOfParrot { Name="Ara" },
                new KindOfParrot { Name="Kakadu" },
                new KindOfParrot { Name="Żako" },
                new KindOfParrot { Name="Papużki nierozłączki" }
            };
            foreach(KindOfParrot k in kop)
            {
                context.KindOfParrots.Add(k);
            }
            context.SaveChanges();

            var parrot = new Parrot[]
            {
                new Parrot { Quantity = 7, KindOfParrot = kop[0] ,TypeDescription = "Ara to jeden z najpopularniejszych gatunków papug domowych . Niektóre źródła podają, że ptaki te mogą żyć nawet 80 lat! Zazwyczaj jednak ich długość życia to ok. 60 lat. Ary są bardzo wymagające. To duże ptaki – mogą osiągnąć długość do 95 cm (z ogonem), a rozpiętość ich skrzydeł sięga 1 m, poza tym mają masywne, mocne dzioby."},
                new Parrot { Quantity = 10 , KindOfParrot = kop[1], TypeDescription ="Jej długość dochodzi do 46 cm. Gdy się przestraszy, rozkłada swój ogromny, odstający, półokrągły grzebień na głowie. Kształtowi grzebienia, przypominającego parasol, zawdzięcza swoją angielską nazwę umbrella cockatoo. Normalnie grzebień znajduje się w pozycji leżącej. Spodnia strona skrzydeł oraz ogon mają barwę jasnożółtą i błyszczą się w czasie lotu papugi. Kakadu biała dożywa niekiedy 80 roku życia. "},
                new Parrot { Quantity = 20, KindOfParrot = kop[2] , TypeDescription="Choć żako jest papugą średniej wielkości (długość ciała wynosi 30–34 cm), to również ma duże wymagania. Należy do gatunków papug domowych gadających – doskonale naśladuje mowę ludzką i bardzo mocno zżywa się z człowiekiem. Często wybiera sobie swojego ulubionego opiekuna, a w stosunku do innych osób, zwłaszcza nowych, może się zachowywać agresywnie"},
                new Parrot { Quantity = 32, KindOfParrot = kop[3] , TypeDescription="Długość ciała ok. 15 cm, masa ciała 43–58 g, tułów dość krępy, ogon krótki. Korpus w kolorze jasnej zieleni. Na skrzydłach upierzenie szmaragdowo-zielone z ciemniejszymi lotkami. Łeb i szyja żółto-pomarańczowo-czerwone. Głowa proporcjonalnie duża w stosunku do reszty ciała. Ogon o barwie ciemnozielonej, z kuprem niebiesko-fioletowym. Kolor dzioba – intensywnie czerwony. Oczy duże, czarne z białą obwódką nagiej skóry dookoła. Cztery przeciwstawnie ustawione palce, skóra nóg szaro-różowa." }
            };
            foreach(Parrot p in parrot)
            {
                context.Parrots.Add(p);
            }
            context.SaveChanges();

            var kot = new KindOfTicket[]
            {
                new KindOfTicket { Name = "Dla jednej osoby" },
                new KindOfTicket { Name = "Rodzinny" },
                new KindOfTicket { Name = "Grupowy" }
            };
            foreach(KindOfTicket k in kot)
            {
                context.KindOfTickets.Add(k);
            }
            context.SaveChanges();

            var ticket = new Ticket[]
            {
                new Ticket { TicketName ="Bilet Ulgowy" , KindOfTicket = kot[0], Price=10 },
                new Ticket { TicketName ="Bilet Normalny" , KindOfTicket = kot[0] , Price=15 },
                new Ticket { TicketName ="Bilet Rodzinny" , KindOfTicket = kot[1], Price = 35 },
                new Ticket { TicketName = "Bilet Grupowy" , KindOfTicket = kot[2], Price = 40 }
            };
            foreach(Ticket t in ticket)
            {
                context.Tickets.Add(t);
            }
            context.SaveChanges();
        }
    }

    
}
