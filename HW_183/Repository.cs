﻿using System.Collections.Generic;

namespace HW_183
{
    class Repository
    {
        public readonly Dictionary<object[], string> AnimalDictionary = new Dictionary<object[], string>()
        {
            { new object[] {"Бесхвостые земноводные","Квакши","Ranoidea","Зелёная литория"},"Amphibian" },
            { new object[] {"Бесхвостые земноводные","Жерлянки","Жерлянки","Дальневосточная жерлянка"},"Amphibian" },
            { new object[] {"Хвостатые земноводные","Саламандровые","Малоазиатские тритоны","Малоазиатский тритон"},"Amphibian" },
            { new object[] {"Хвостатые земноводные","Саламандровые","Гладкие тритоны","Тритон Ланца"},"Amphibian" },
            { new object[] {"Хвостатые земноводные","Саламандровые","Тритоны","Гребенчатый тритон"},"Amphibian" },

            { new object[] {"Сирены","Дюгоневые","Морские коровы","Стеллерова корова"},"Mammal"},
            { new object[] {"Зайцеобразные","Пищуховые","Пищухи","Алтайская пищуха"},"Mammal"},
            { new object[] {"Зайцеобразные","Зайцевые","Зайцы","Маньчжурский заяц"},"Mammal"},
            { new object[] {"Грызуны","Бобровые","Бобры","Канадский бобр"},"Mammal"},
            { new object[] {"Насекомоядные","Ежовые","Степные ежи","Даурский ёж"},"Mammal"},

            { new object[] {"Буревестникообразные","Буревестниковые","Ardenna","Серый буревестник"} ,"Bird"},
            { new object[] {"Ястребообразные","Ястребиные","Орланы","Орлан-долгохвост"},"Bird"},
            { new object[] {"Курообразные","Фазановые","Улары","Кавказский улар"} ,"Bird"},
            { new object[] {"Гусеобразные","Утиные","Лебеди","Американский лебедь" },"Bird"},
            { new object[] {"Гагарообразные","Гагаровые","Гагары","Чернозобая гагара"},"Bird"},

            { new object[] {"Чешуйчатые","Psammophiidae","Ящеричные змеи","Ящеричная змея"} ,"Reptilia"},
            { new object[] {"Черепахи","Американские пресноводные черепахи","Trachemys","Красноухая черепаха"},"Reptilia"},
            { new object[] {"Чешуйчатые","Гекконовые","Тонкопалые гекконы","Каспийский геккон"},"Reptilia"},
            { new object[] {"Чешуйчатые","Веретеницевые","Веретеницы","Ломкая веретеница"},"Reptilia"},
            { new object[] {"Чешуйчатые","Ужеобразные","Лесные ужи","Полосатый лесной уж"} ,"Reptilia"},

            { new object[] {"Спиношипообразные","Галозавровые","Альдровандии","Aldrovandia phalacra"} ,"Osteichthyes"},
            { new object[] {"Гиодонтообразные","Гиодонтовые","Гиодоны","Hiodon alosoides"},"Osteichthyes"},
            { new object[] {"Сельдеобразные","Сельдевые","Сельди","Атлантическая сельдь"},"Osteichthyes"},
            { new object[] {"Галаксиеобразные","Галаксиевые","Галаксии","Galaxias platei"} ,"Osteichthyes"},
            { new object[] {"Атеринообразные","Атериновые","Атерины","Южноевропейская атерина"},"Osteichthyes"},

            { new object[] {"Archipelepidiformes","Archipelepididae Soehn","Archipelepis","Archipelepis bifurcata "} ,"Agnatha"},

            { new object[] {"Миногообразные", "Мордациевые", "Южные миноги", "Пресноводная южная минога" },"Petromyzontiformes"}
        };
    }
}
