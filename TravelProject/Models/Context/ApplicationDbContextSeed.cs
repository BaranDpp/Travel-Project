using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TravelProject.Models;
using static System.Net.WebRequestMethods;

namespace TravelProject.Models.Context
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedAsync(ApplicationDbContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (!context.UserRoles.Any())
            {
                var roles = new[] { "user", "admin" };

                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role))
                    {
                        await roleManager.CreateAsync(new IdentityRole(role));
                    }
                }
            }
            if (!context.Cities.Any())
            {
                // Seed Cities
                var cities = new List<City>
                {
                     new City { Name = "Paris", Country = "France", ImageUrl = "https://i.hizliresim.com/r0m8kj5.jpg" },
                    new City { Name = "New York", Country = "USA", ImageUrl = "https://i.hizliresim.com/1ivt7so.jpg" },
                    new City { Name = "Tokyo", Country = "Japan", ImageUrl = "https://i.hizliresim.com/j5i9yuf.png" },
                    new City { Name = "London", Country = "UK", ImageUrl = "https://i.hizliresim.com/fljhcck.jpg" },
                    new City { Name = "Rome", Country = "Italy", ImageUrl = "https://i.hizliresim.com/793r5x7.jpg" },
                    new City { Name = "Barcelona", Country = "Spain", ImageUrl = "https://i.hizliresim.com/17vecg9.jpg" },
                    new City { Name = "Bangkok", Country = "Thailand", ImageUrl = "https://i.hizliresim.com/njckime.jpg" },
                    new City { Name = "Dubai", Country = "UAE", ImageUrl = "https://i.hizliresim.com/qmn63r7.jpg" },
                    new City { Name = "Istanbul", Country = "Turkey", ImageUrl = "https://i.hizliresim.com/ayymzsj.jpg" },
                    new City { Name = "Sydney", Country = "Australia", ImageUrl = "https://i.hizliresim.com/hfpfqgg.jpg" },
                    new City { Name = "Rio de Janeiro", Country = "Brazil", ImageUrl = "https://i.hizliresim.com/ax2987l.jpg" },
                    new City { Name = "San Francisco", Country = "USA", ImageUrl = "https://i.hizliresim.com/4xfav0h.jpg" },
                    new City { Name = "Hong Kong", Country = "China", ImageUrl = "https://i.hizliresim.com/32g5xqc.jpg" },
                    new City { Name = "Singapore", Country = "Singapore", ImageUrl = "https://i.hizliresim.com/5cbdkge.jpg" },
                    new City { Name = "Amsterdam", Country = "Netherlands", ImageUrl = "https://i.hizliresim.com/ib44cic.jpg" },
                    new City { Name = "Los Angeles", Country = "USA", ImageUrl = "https://i.hizliresim.com/85hom4u.png" },
                    new City { Name = "Lisbon", Country = "Portugal", ImageUrl = "https://i.hizliresim.com/267aiwn.png" },
                    new City { Name = "Berlin", Country = "Germany", ImageUrl = "https://i.hizliresim.com/iajx3q5.png" },
                    new City { Name = "Vienna", Country = "Austria", ImageUrl = "https://i.hizliresim.com/qgb3mm4.jpg" },
                    new City { Name = "Moscow", Country = "Russia", ImageUrl = "https://i.hizliresim.com/r5u83yq.jpg" }
                };

                context.Cities.AddRange(cities);
                await context.SaveChangesAsync();

                // Seed Tourist Spots
                var touristSpots = new List<TouristSpot>
                {
     new TouristSpot
    {
        Name = "Louvre Museum",
        Description = "The world's largest art museum and a historic monument.",
        ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/a/a2/Louvre_Courtyard%2C_Looking_West.jpg/640px-Louvre_Courtyard%2C_Looking_West.jpg",
        CityId = cities.Single(c => c.Name == "Paris").CityId
    },
    new TouristSpot
    {
        Name = "Notre-Dame Cathedral",
        Description = "A medieval Catholic cathedral on the Île de la Cité.",
        ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/6/68/Paris%2C_Notre_Dame_--_2014_--_1458-65.jpg/640px-Paris%2C_Notre_Dame_--_2014_--_1458-65.jpg",
        CityId = cities.Single(c => c.Name == "Paris").CityId
    },
    new TouristSpot
    {
        Name = "Champs-Élysées",
        Description = "An avenue in the 8th arrondissement of Paris, known for its theatres, cafés, and luxury shops.",
        ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/7/78/Crowds_of_French_patriots_line_the_Champs_Elysees-edit2.jpg/640px-Crowds_of_French_patriots_line_the_Champs_Elysees-edit2.jpg",
        CityId = cities.Single(c => c.Name == "Paris").CityId
    },
    new TouristSpot
    {
        Name = "Sacré-Cœur",
        Description = "A Roman Catholic church and minor basilica, dedicated to the Sacred Heart of Jesus.",
        ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/a/a9/Sacre_Coeur_cor_Jesu-DSC_1455w.jpg/640px-Sacre_Coeur_cor_Jesu-DSC_1455w.jpg",
        CityId = cities.Single(c => c.Name == "Paris").CityId
    },
    new TouristSpot
    {
        Name = "Montmartre",
        Description = "A large hill in Paris's 18th arrondissement, known for its artistic history.",
        ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/7/75/Montmarte_2_%28pixinn.net%29.jpg/640px-Montmarte_2_%28pixinn.net%29.jpg",
        CityId = cities.Single(c => c.Name == "Paris").CityId
    },
    new TouristSpot
    {
        Name = "Palace of Versailles",
        Description = "A former royal residence located in Versailles, about 20 kilometers southwest of Paris.",
        ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/f/f1/Chateau_Versailles_Galerie_des_Glaces.jpg/640px-Chateau_Versailles_Galerie_des_Glaces.jpg",
        CityId = cities.Single(c => c.Name == "Paris").CityId
    },
                    new TouristSpot { Name = "Eiffel Tower", Description = "Eyfel Kulesi (Fransızca: La tour Eiffel [la tuʀ ɛˈfɛl]), Paris'teki demir kule. Kule, aynı zamanda tüm dünyada Fransa'nın sembolü halini almıştır. İsmini, inşa ettiren Fransız inşaat mühendisi Gustave Eiffel'den alır.[1] En büyük turizm cazibelerinden biri olan Eyfel Kulesi, yılda 6 milyon turist çeker. 2002 yılında toplam ziyaretçi sayısı 200 milyona ulaşmıştır.\r\n\r\nEyfel Kulesi 1887 ile 1889 yılları arasında Gustave Eiffel'in firması tarafından, Fransız Devrimi'nin 100. yıl kutlamaları çerçevesinde düzenlenen Expo 1889 Paris fuarının giriş kapısı olarak inşa edilmiştir. Aslında kulenin mimarı Gustave Eiffel değil, İsviçreli Maurice Koechlin 'in siparişi üzerine tasarlayan Stephen Sauvestre'dir. Meslektaşı Emile Nouguier ile beraber ilk tasarımları yapmıştır. Kulenin, 7.739.401 Frank 31 Sent tutan inşaat masrafları, Gustave Eiffel'in tahminlerinin 1 milyon frank üstündedir. 1889 yılındaki açılış tarihinden önceki 5 ayda 1,9 milyon kişi ziyaret edince, yıl sonuna kadar toplam masrafın 3/4'ü çıkartılmıştır.\r\n\r\n3.000 işçi 26 ay boyunca 18.038 adet demir parçayı 2,5 milyon perçinle bir araya getirdi. Hiç ölüm vakası yaşanmamış olması, o günün şartlarında şaşırtıcı bir durumdur.\r\n\r\nAncak kule, onu bir utanç lekesi olarak gören Paris halkının tepkisini de çekmiştir. Bazı sanatçılar devasa bir sokak lambasına benzetirken, bir fabrika bacası gibi Paris'in görsel itibarını zedeleyeceğini ileri sürmüşlerdir. Böylelikle devrin sanatçı ve edebiyatçı çevresinde bir kampanya başlatılmış, bu kampanya süresince ünlü sanatçıların imzaladığı bildiriler dağıtılmıştır. Bugün ise Eyfel Kulesi, Dünya'nın en güzel mimari yapılarından biri olarak kabul edilir. Parisliler onu Demir Bayan olarak adlandırırlar. İlk başlarda Eiffel, Kule'ye sadece 20 yıl için müsaade almıştı. Dolayısıyla, 1909 yılında kulenin sökülmesi gerekiyordu. Ancak kule, iletişim için çok uygun yüksekliğe ulaştığından ve yeni yüzyılda Atlantik ötesi haberleşmeye imkân tanıdığından, kalmasına izin verildi. Bu bağlamda Eyfel Kulesi radyo yayıncılığının gelişmesinde önemli rol oynamıştır. Eyfel Kulesi, radyo dalgalarını çok uzun mesafelere yayabilmesi avantajıyla, l. Dünya Savaşı’nda sinyal kesici ve bozucu olarak da kullanılmıştır. Eyfel Kulesi, günümüzde Paris'in en çok ziyaret edilen noktası olsa da, en tepedeki 27 metrelik radyo vericisiyle halen bir verici istasyonu olarak kullanılmaktadır.[2]", ImageUrl = "https://i.hizliresim.com/7m7r1i6.jpg", CityId = cities.Single(c => c.Name == "Paris").CityId },
                    new TouristSpot { Name = "Statue of Liberty", Description = "Özgürlük Heykeli (İngilizce: Statue of Liberty) ya da resmî adıyla Dünyayı Aydınlatan Özgürlük, ABD'nin New York şehrindeki Liberty (Özgürlük) adası üzerinde, inşa edildiği 1886 yılından bu yana Amerika'nın simgesi olan anıtsal heykeli ve gözlem kulesidir. Dünyanın en tanınan anıtlarından biridir.\r\n\r\nBakırdan yapılan Özgürlük Heykeli, Fransa tarafından kuruluşunun 100. yılı nedeniyle ABD'ye hediye edilmiştir. 1884-1886 yılları arasında inşa edilmiştir. ABD'nin New York şehrindeki Özgürlük Adası'nda yer alır.[1]\r\n\r\nHeykel, sağ elinde bir meşale, sol elinde ise bir kitabe tutar. Tabletin üstünde 4 Temmuz 1776 tarihi (Bağımsızlık Bildirgesi'nin tarihi) yazılıdır. Heykelin başındaki taç'ın 7 sivri ucu 7 kıtayı veya 7 denizi simgeler. Heykelin yüksekliği 46 metre, kaidesi ile beraber 93 metredir. Ziyaretçiler heykelin içinden meşaleye kadar 168 basamaklı bir merdivenden çıkabilirler. Heykelin meşale tutan sağ elinin yüksekliği 13 metredir. Meşalenin etrafındaki dehlizde 15 kişi bir arada dolaşabilir. Heykelin başının genişliği 2 metre, yüksekliği ise tacı ile birlikte 5 metredir.", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/e/ed/Currier_and_Ives_Liberty2.jpg", CityId = cities.Single(c => c.Name == "New York").CityId },
                    new TouristSpot { Name = "Tokyo Tower", Description = "A communications and observation tower.", ImageUrl = "https://example.com/tokyotower.jpg", CityId = cities.Single(c => c.Name == "Tokyo").CityId },
                    new TouristSpot { Name = "Big Ben", Description = "A famous clock tower.", ImageUrl = "https://example.com/bigben.jpg", CityId = cities.Single(c => c.Name == "London").CityId },
                    new TouristSpot { Name = "Colosseum", Description = "An ancient amphitheater.", ImageUrl = "https://example.com/colosseum.jpg", CityId = cities.Single(c => c.Name == "Rome").CityId },
                    new TouristSpot { Name = "Sagrada Familia", Description = "A large unfinished basilica.", ImageUrl = "https://example.com/sagradafamilia.jpg", CityId = cities.Single(c => c.Name == "Barcelona").CityId },
                    new TouristSpot { Name = "Grand Palace", Description = "A complex of buildings at the heart of Bangkok.", ImageUrl = "https://example.com/grandpalace.jpg", CityId = cities.Single(c => c.Name == "Bangkok").CityId },
                    new TouristSpot { Name = "Burj Khalifa", Description = "The tallest structure and building in the world.", ImageUrl = "https://example.com/burjkhalifa.jpg", CityId = cities.Single(c => c.Name == "Dubai").CityId },
                    new TouristSpot { Name = "Hagia Sophia", Description = "A historical mosque and former cathedral.", ImageUrl = "https://example.com/hagiasophia.jpg", CityId = cities.Single(c => c.Name == "Istanbul").CityId },
                    new TouristSpot { Name = "Sydney Opera House", Description = "A multi-venue performing arts centre.", ImageUrl = "https://example.com/sydneyoperahouse.jpg", CityId = cities.Single(c => c.Name == "Sydney").CityId },
                    new TouristSpot { Name = "Christ the Redeemer", Description = "A large statue of Jesus Christ.", ImageUrl = "https://example.com/christtheredeemer.jpg", CityId = cities.Single(c => c.Name == "Rio de Janeiro").CityId },
                    new TouristSpot { Name = "Golden Gate Bridge", Description = "A suspension bridge spanning the Golden Gate.", ImageUrl = "https://example.com/goldengatebridge.jpg", CityId = cities.Single(c => c.Name == "San Francisco").CityId },
                    new TouristSpot { Name = "Victoria Peak", Description = "A mountain in the western half of Hong Kong Island.", ImageUrl = "https://example.com/victoriapeak.jpg", CityId = cities.Single(c => c.Name == "Hong Kong").CityId },
                    new TouristSpot { Name = "Marina Bay Sands", Description = "An integrated resort fronting Marina Bay.", ImageUrl = "https://example.com/marinabaysands.jpg", CityId = cities.Single(c => c.Name == "Singapore").CityId },
                    new TouristSpot { Name = "Rijksmuseum", Description = "A Dutch national museum.", ImageUrl = "https://example.com/rijksmuseum.jpg", CityId = cities.Single(c => c.Name == "Amsterdam").CityId },
                    new TouristSpot { Name = "Hollywood Sign", Description = "An American landmark and cultural icon.", ImageUrl = "https://example.com/hollywoodsign.jpg", CityId = cities.Single(c => c.Name == "Los Angeles").CityId },
                    new TouristSpot { Name = "Belem Tower", Description = "A fortified tower located in the civil parish of Santa Maria.", ImageUrl = "https://example.com/belem.jpg", CityId = cities.Single(c => c.Name == "Lisbon").CityId },
                    new TouristSpot { Name = "Brandenburg Gate", Description = "An 18th-century neoclassical monument.", ImageUrl = "https://example.com/brandenburggate.jpg", CityId = cities.Single(c => c.Name == "Berlin").CityId },
                    new TouristSpot { Name = "Schönbrunn Palace", Description = "A former imperial summer residence.", ImageUrl = "https://example.com/schonbrunn.jpg", CityId = cities.Single(c => c.Name == "Vienna").CityId },
                    new TouristSpot { Name = "Red Square", Description = "A city square in Moscow.", ImageUrl = "https://example.com/redsquare.jpg", CityId = cities.Single(c => c.Name == "Moscow").CityId }
                };

                context.TouristSpots.AddRange(touristSpots);
                await context.SaveChangesAsync();
            }
            if (!context.Users.Any())
            {
                // Seed Users
                var adminUser = new User { UserName = "admin", Email = "admin@example.com" };
                var result = await userManager.CreateAsync(adminUser, "Password123!");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "admin");
                }

                var regularUser = new User { UserName = "user", Email = "user@example.com" };
                result = await userManager.CreateAsync(regularUser, "Password123!");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(regularUser, "user");
                }
            }

            if (!context.Reviews.Any())
            {
                // Seed Reviews
                var user = context.Users.First();
                var touristSpot = context.TouristSpots.First();

                var reviews = new List<Review>
                {
                    new Review { Rating = 5, Comments = "Amazing place!", UserId = user.Id, TouristSpotId = touristSpot.TouristSpotId },
                    // Diğer yorumlar...
                };

                context.Reviews.AddRange(reviews);
                await context.SaveChangesAsync();
            }

            if (!context.Favorites.Any())
            {
                // Seed Favorites
                var user = context.Users.First();
                var touristSpot = context.TouristSpots.First();

                var favorites = new List<Favorite>
                {
                    new Favorite { UserId = user.Id, TouristSpotId = touristSpot.TouristSpotId },
                    // Diğer favoriler...
                };

                context.Favorites.AddRange(favorites);
                await context.SaveChangesAsync();
            }
        }
    }
}