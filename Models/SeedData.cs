using AgeCalculatorFrom.Data;
using Microsoft.EntityFrameworkCore;

namespace AgeCalculatorFrom.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new PeopleContext(
                serviceProvider.GetRequiredService<DbContextOptions<PeopleContext>>()))
            {
                if (context == null || context.Cities == null)
                {
                    throw new ArgumentNullException("Null PeopleContext");
                }

                if (context.Cities.Any())
                {
                    return;
                }

                context.Cities.AddRange(
                    new City
                    {
                        Name = "Adana"
                    },
                    new City
                    {
                        Name = "Adıyaman"
                    },
                    new City
                    {
                        Name = "Afyonkarahisar"
                    },
                    new City
                    {
                        Name = "Ağrı"
                    },
                    new City
                    {
                        Name = "Amasya"
                    },
                    new City
                    {
                        Name = "Ankara"
                    },
                    new City
                    {
                        Name = "Antalya"
                    },
                    new City
                    {
                        Name = "Artvin"
                    },
                    new City
                    {
                        Name = "Aydın"
                    },
                    new City
                    {
                        Name = "Balıkesir"
                    },
                    new City
                    {
                        Name = "Bilecik"
                    },
                    new City
                    {
                        Name = "Bingöl"
                    },
                    new City
                    {
                        Name = "Bitlis"
                    },
                    new City
                    {
                        Name = "Bolu"
                    },
                    new City
                    {
                        Name = "Burdur"
                    },
                    new City
                    {
                        Name = "Bursa"
                    },
                    new City
                    {
                        Name = "Çanakkale"
                    },
                    new City
                    {
                        Name = "Çankırı"
                    },
                    new City
                    {
                        Name = "Çorum"
                    },
                    new City
                    {
                        Name = "Denizli"
                    },
                    new City
                    {
                        Name = "Diyarbakır"
                    },
                    new City
                    {
                        Name = "Edirne"
                    },
                    new City
                    {
                        Name = "Elazığ"
                    },
                    new City
                    {
                        Name = "Erzincan"
                    },
                    new City
                    {
                        Name = "Erzurum"
                    },
                    new City
                    {
                        Name = "Eskişehir"
                    },
                    new City
                    {
                        Name = "Gaziantep"
                    },
                    new City
                    {
                        Name = "Giresun"
                    },
                    new City
                    {
                        Name = "Gümüşhane"
                    },
                    new City
                    {
                        Name = "Hakkari"
                    },
                    new City
                    {
                        Name = "Hatay"
                    },
                    new City
                    {
                        Name = "Isparta"
                    },
                    new City
                    {
                        Name = "Mersin"
                    },
                    new City
                    {
                        Name = "İstanbul"
                    },
                    new City
                    {
                        Name = "İzmir"
                    },
                    new City
                    {
                        Name = "Kars"
                    },
                    new City
                    {
                        Name = "Kastomonu"
                    },
                    new City
                    {
                        Name = "Kayseri"
                    },
                    new City
                    {
                        Name = "Kırklareli"
                    },
                    new City
                    {
                        Name = "Kırşehir"
                    },
                    new City
                    {
                        Name = "Kocaeli"
                    },
                    new City
                    {
                        Name = "Konya"
                    },
                    new City
                    {
                        Name = "Kütahya"
                    },
                    new City
                    {
                        Name = "Malatya"
                    },
                    new City
                    {
                        Name = "Manisa"
                    },
                    new City
                    {
                        Name = "Kahramanmaraş"
                    },
                    new City
                    {
                        Name = "Mardin"
                    },
                    new City
                    {
                        Name = "Muğla"
                    },
                    new City
                    {
                        Name = "Muş"
                    },
                    new City
                    {
                        Name = "Nevşehir"
                    },
                    new City
                    {
                        Name = "Niğde"
                    },
                    new City
                    {
                        Name = "Ordu"
                    },
                    new City
                    {
                        Name = "Rize"
                    },
                    new City
                    {
                        Name = "Sakarya"
                    },
                    new City
                    {
                        Name = "Samsun"
                    },
                    new City
                    {
                        Name = "Siirt"
                    },
                    new City
                    {
                        Name = "Sinop"
                    },
                    new City
                    {
                        Name = "Sivas"
                    },
                    new City
                    {
                        Name = "Tekirdağ"
                    },
                    new City
                    {
                        Name = "Tokat"
                    },
                    new City
                    {
                        Name = "Trabzon"
                    },
                    new City
                    {
                        Name = "Tunceli"
                    },
                    new City
                    {
                        Name = "Şanlıurfa"
                    },
                    new City
                    {
                        Name = "Uşak"
                    },
                    new City
                    {
                        Name = "Van"
                    },
                    new City
                    {
                        Name = "Yozgat"
                    },
                    new City
                    {
                        Name = "Zonguldak"
                    },
                    new City
                    {
                        Name = "Aksaray"
                    },
                    new City
                    {
                        Name = "Bayburt"
                    },
                    new City
                    {
                        Name = "Karaman"
                    },
                    new City
                    {
                        Name = "Kırıkkale"
                    },
                    new City
                    {
                        Name = "Batman"
                    },
                    new City
                    {
                        Name = "Şırnak"
                    },
                    new City
                    {
                        Name = "Bartın"
                    },
                    new City
                    {
                        Name = "Ardahan"
                    },
                    new City
                    {
                        Name = "Iğdır"
                    },
                    new City
                    {
                        Name = "Yalova"
                    },
                    new City
                    {
                        Name = "Karabük"
                    },
                    new City
                    {
                        Name = "Kilis"
                    },
                    new City
                    {
                        Name = "Osmaniye"
                    },
                    new City
                    {
                        Name = "Düzce"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
